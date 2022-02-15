using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INsecure_Windows_Interface
{
    internal class Start_Stop_Cam_btns
    {
        private frm_main frm;
        public async Task Cam_1(frm_main frm)
        {
            this.frm = frm;

            Write_to_terminal w = new Write_to_terminal();

            frm.rtb_output.AppendText(Environment.NewLine);
            await w.Append_text(frm, " [START CAM_1] ", 1, Color.White, Color.Red, true);
            await w.Write(frm, "Device: ", 1, Color.White, false);
            JSON_interface j = new JSON_interface();
            var macadd = j.Get_Device_MAC();
            await w.Append_text(frm, macadd[0].D_Address, 2, Color.Green, Color.Empty, true);
            await w.Append_text(frm, " identified", 2, Color.White, Color.Empty, false);
            await w.Write(frm, "Attemping to start cam server", 2, Color.White, false);
            await w.Write(frm, "---------------------------------------", 1, Color.White, false);
            frm.serialPort1.WriteLine("cam," + macadd[0].D_Address + ",ON");
        }

        public async Task Cam_2(frm_main frm)
        {
            this.frm = frm;

            Write_to_terminal w = new Write_to_terminal();

            frm.rtb_output.AppendText(Environment.NewLine);
            await w.Append_text(frm, " [START CAM_2] ", 1, Color.White, Color.Red, true);
            await w.Write(frm, "Device: ", 1, Color.White, false);
            JSON_interface j = new JSON_interface();
            var macadd = j.Get_Device_MAC();
            await w.Append_text(frm, macadd[1].D_Address, 2, Color.Green, Color.Empty, true);
            await w.Append_text(frm, " identified", 2, Color.White, Color.Empty, false);
            await w.Write(frm, "Attemping to start cam server", 2, Color.White, false);
            await w.Write(frm, "---------------------------------------", 1, Color.White, false);
            frm.serialPort1.WriteLine("cam," + macadd[1].D_Address + ",ON");
        }
        public async Task Terminate_stream_1(frm_main frm)
        {
            this.frm = frm;

            Write_to_terminal w = new Write_to_terminal();
            JSON_interface j = new JSON_interface();
            var macadd = j.Get_Device_MAC();
            frm.serialPort1.WriteLine("cam," + macadd[0].D_Address + ",OFF");
            await w.Write(frm, "Terminating Stream", 1, Color.White, false);
        }
        public async Task Terminate_stream_2(frm_main frm)
        {
            this.frm = frm;

            Write_to_terminal w = new Write_to_terminal();
            JSON_interface j = new JSON_interface();
            var macadd = j.Get_Device_MAC();
            frm.serialPort1.WriteLine("cam," + macadd[1].D_Address + ",OFF");
            await w.Write(frm, "Terminating Stream", 1, Color.White, false);
        }
    }
}
