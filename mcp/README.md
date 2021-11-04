# MCP

The MCP is a complicated panel - here are the solutions we came up with.

## Displays
The IAS, altitude, heading, and vspeed displays are seemingly custom LCD
panels on the real deal. These are a pain in the ass to source
(not to mention very expensive), and a good solution is to use little OLED
panels to simulate the look of the displays.

What you need are some I2C/SPI OLED modules and some code to glue those to
the simulation and to make them look like the originals.

IAS, heading, altitude: SSD1309 2.42" 128*64 OLED panels - like
[here](https://www.amazon.com/Diymore-Digital-Display-SSD1309-Electronic/dp/B07XRFFPCT)
or
[here](https://www.aliexpress.com/item/32871927644.html)

vspeed: SSD1305 2.23" 128*32 OLED panel - like
[here](https://www.aliexpress.com/item/32832409846.html)

And a microcontroller to drive them, plus FSUIPC.

### Code

I'm going to leave some Arduino and Windows code here for driving a display.
The font for the digits is one I modified myself - `u8g2_font_dmezh_7segment_36`. I will do
my best to find it, but in the meantime you should be able to use another u8g2 font with the same
height instead.
