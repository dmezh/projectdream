// P:D - displayboss arduino display firmware

// Dan Mezhiborsky <dmezh@ieee.org>

/*
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

#include <CmdMessenger.h>
#include <U8g2lib.h>
#include <U8x8lib.h>
#include <Arduino.h>
#include <SPI.h>
#include <Wire.h>

// hard-coded display below
U8G2_SSD1309_128X64_NONAME0_2_4W_SW_SPI u8g2(U8G2_R0, 53, 51, 45, 47, 49);

// Useful variables
bool spdRef                   = 0;   // Current state of Led
int APspd;
String MachWith0;

// Attach a new CmdMessenger object to the default Serial port
CmdMessenger cmdMessenger = CmdMessenger(Serial);

// This is the list of recognized commands. These can be commands that can either be sent or received. 
// In order to receive, attach a callback function to these events
enum
{
  APspdSet              , // Command to request led to be set in specific state
  RefSet,
  kStatus              , // Command to report status
};

// Callbacks define on which received commands we take action
void attachCommandCallbacks()
{
  // Attach callback methods
  cmdMessenger.attach(OnUnknownCommand);
  cmdMessenger.attach(APspd, OnNewAPspd);
  cmdMessenger.attach(RefSet, OnNewRef);
}

// Called when a received command has no attached function
void OnUnknownCommand()
{
  cmdMessenger.sendCmd(kStatus,"Command without attached callback");
}

// Callback function to handle a new speed
void OnNewAPspd()
{
  // Read the new speed from serial into a nice int
  APspd = cmdMessenger.readIntArg();
  cmdMessenger.sendCmd(kStatus,APspd);
}

// Callback function to handle a new speed
void OnNewRef()
{
  spdRef = cmdMessenger.readBoolArg();
}

// Setup function
void setup() 
{
  // Listen on serial connection for messages from the PC
  Serial.begin(115200); 
  u8g2.begin(); //initialize the display

  // Adds newline to every command
  cmdMessenger.printLfCr();

  // Attach my application's user-defined callback methods
  attachCommandCallbacks();

  // Send the status to the PC that says the Arduino has booted
  cmdMessenger.sendCmd(kStatus,"Arduino has started!");
  
}

// Main loop
void loop() 
{
  cmdMessenger.feedinSerialData();
  u8g2.firstPage(); // initialize display
  MachWith0 = String(APspd) + "0"; //making the Mach string have the third digit (0). Needs to be done in separate step or bad things will happen.
  do {
    u8g2.setFont(u8g2_font_dmezh_7segment_36);
    u8g2.setCursor(72, 29);
    if (!spdRef) { //if the speedref type is NOT 1 (aka NOT Mach) then print the IAS:
      u8g2.print(APspd); //
      u8g2.setFont(u8g2_font_crox1h_tf);
      u8g2.setCursor(2, 12);
      u8g2.print("I A S");
    } else { //otherwise print the Mach:
      u8g2.print(MachWith0);
      u8g2.setFont(u8g2_font_crox1h_tf);
      u8g2.setCursor(2, 30);
      u8g2.print("M A C H");
      u8g2.setFont(u8g2_font_dmezh_7segment_36);
      u8g2.setCursor(55, 29);
      u8g2.print(".");
    }
  } while (u8g2.nextPage());
}
