Primary system interface for windows. Messages to/from peripheral devices (ESP8266-Deep-sleep-with-PIR-wake-and-ESPnow-status-transmission 
and ESP32-Cam-remote-on-off-via-ESPnow-and-PIR-alert) are relayed to the C# Winform application via a ESP32 device (Central-Communications-Node) 
through serial comms (USB or UART).
C# application is capable of bidirectional communication with both the ESP32 (Central-Communications-Node) and the ESP32 cam units 
(ESP32-Cam-remote-on-off-via-ESPnow-and-PIR-alert). Connected ESP32 cam units are registered with the C# application through an included JSON
file and the units IP camera streams can be both initiated and terminated by the c# application by transmitting the relevent message and MAC address 
over serial to the ESP32 central node which broadcasts the appropriate command to the intended ESP32 cam unit.
Upon launching the C# application, a number of startup tests are launched. The applicatioon will list all available serial comm ports available 
to the host system and systematically test each port with a test message until it receives an appropriate response. Upon receipt of an appopriate
response, the serial port will be retained. Two additional tests are performed before normal operations can begin, a quick check to determine if a JSON 
file containing the MAC addresses of the ESP32 cams exists and a quick check to determine if the host system has network access by pinging
Google.com.
Upon success, the system will begin listening to the serial com for new messages and will allow the user to activate remote ESP32-cam units and
view their respective video streams.
