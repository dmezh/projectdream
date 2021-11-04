using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandMessenger;
using CommandMessenger.Transport.Serial;

namespace DisplayHandlerMain
{
    enum Command
    {
        APspdSet, // Command to send speed
        RefSet, // Command to send speedref type
    };
    public class ConnectedAVR
    {
        private SerialTransport _serialTransport;
        private CmdMessenger _cmdMessenger;

        public void Setup(int port)
        {

            _serialTransport = new SerialTransport();
            _serialTransport.CurrentSerialSettings.PortName = "COM" + port.ToString(); ;    // Set com port
            _serialTransport.CurrentSerialSettings.BaudRate = 115200;     // Set baud rate
            _serialTransport.CurrentSerialSettings.DtrEnable = false;     // Needs to be set to true for some types of arduinos

            // Initialize the command messenger with the Serial Port transport layer
            _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16);

            // Attach the callbacks to the Command Messenger
            AttachCommandCallBacks();

            // Start listening
            _cmdMessenger.Connect();
        }

        // Loop function
        public void SendSpd(int spd)
        {
            // Create command
            var command = new SendCommand((int)Command.APspdSet, spd);

            // Send command
            _cmdMessenger.SendCommand(command);

            Console.Write("Sending Speed:");
            Console.WriteLine(spd.ToString());


        }

        public void SendRef(bool spdref)
        {
            // Create command
            var command = new SendCommand((int)Command.RefSet, spdref);

            // Send command
            _cmdMessenger.SendCommand(command);

            Console.Write("Sending Ref:");
            Console.WriteLine(spdref.ToString());


        }

        // Exit function
        public void Exit()
        {
            // We will never exit the application
        }

        /// Attach command call backs. 
        private void AttachCommandCallBacks()
        {
            // No callbacks are currently needed
        }
    }
}
