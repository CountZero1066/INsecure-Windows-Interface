using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INsecure_Windows_Interface
{
    internal class JSON_interface
    {
        public List<INsecure_Windows_Interface.MAC_addresses> Get_Device_MAC()
        {
            string input = (Properties.Resources.MAC_Devices_json);
            var mydevices = JsonConvert.DeserializeObject<List<MAC_addresses>>(input);

            return mydevices;
        }
    }
}
