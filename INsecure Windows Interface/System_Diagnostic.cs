using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace INsecure_Windows_Interface
{
    internal class System_Diagnostic
    {
        private frm_main frm;
        //------------------------------------------------------------------------------------------------------------------------------------
        public async Task<Boolean> test_serial_(frm_main frm)
        {
            this.frm = frm;
            Write_to_terminal w = new Write_to_terminal();
            await w.Write(frm, "---------------------------------------", 1, Color.White, false);
            frm.rtb_output.AppendText(Environment.NewLine);
            await w.Append_text(frm, " [Start up Diagnostic] ", 1, Color.Black, Color.White, true);

            await w.Write(frm, "Check Serial Com : ", 1, Color.White, false);
            frm.serialPort1.Open();

            if (frm.serialPort1.IsOpen)
            {
                DateTime startTime = DateTime.Now;
                frm.serialPort1.WriteLine("tst,nde");
                string return_message = "";
                while (return_message != "tst,Serial Com working")
                {
                    await Task.Delay(10);
                    return_message = String.Concat(frm.serialPort1.ReadExisting());

                    if (DateTime.Now.Subtract(startTime).Seconds >= 5)
                    {
                        await w.Append_text(frm, " FAIL ", 1, Color.Red, Color.Empty, true);
                        frm.rtb_output.AppendText(Environment.NewLine);
                        await w.Append_text(frm, " [Response Time Out] ", 1, Color.Red, Color.Empty, true);

                        return false;
                    }
                }
                await w.Append_text(frm, " PASS ", 1, Color.Green, Color.Empty, true);
                frm.serialPort1.Close();
                return true;


            }
            else
            {
                await w.Append_text(frm, " FAIL ", 1, Color.Red, Color.Empty, true);
                frm.rtb_output.AppendText(Environment.NewLine);
                await w.Append_text(frm, " [Serial Port Not Detected] ", 1, Color.Red, Color.Empty, true);
                frm.serialPort1.Close();

                return false;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------
        public async Task<Boolean> test_JSON_MAC_(frm_main frm)
        {
            this.frm = frm;
            Write_to_terminal w = new Write_to_terminal();

            await w.Write(frm, "Check JSON MAC  : ", 1, Color.White, false);
            if (Properties.Resources.MAC_Devices_json.Count() > 1)
            {
                await w.Append_text(frm, " PASS ", 1, Color.Green, Color.Empty, true);
                await w.Write(frm, "---------------------------------------", 1, Color.White, false);

                return true;
            }
            else
            {
                await w.Append_text(frm, " FAIL ", 1, Color.Red, Color.Empty, true);
                await w.Write(frm, "!JSON 'MAC' not found!", 1, Color.Red, false);
                await w.Write(frm, "---------------------------------------", 1, Color.White, false);

                return false;
            }


        }
        //------------------------------------------------------------------------------------------------------------------------------------
        public async Task<bool> Test_local_networkAsync(frm_main frm)
        {
            this.frm = frm;
            Write_to_terminal w = new Write_to_terminal();

            await w.Write(frm, "Check Network     : ", 1, Color.White, false);

            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            try
            {
                if (reply.Status == IPStatus.Success)
                {

                    await w.Append_text(frm, " PASS ", 1, Color.Green, Color.Empty, true);
                    return true;
                }
                else
                {
                    await w.Append_text(frm, " FAIL ", 1, Color.Red, Color.Empty, true);
                    return false;
                }
            }
            catch
            {
                await w.Append_text(frm, " ERROR ", 1, Color.Red, Color.Empty, true);
                return false;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------
        public async Task<String> Test_comm_ports(frm_main frm, String[] active_ports)
        {
            this.frm = frm;
            try
            {
                foreach (String port in active_ports)
                {
                    frm.serialPort1.PortName = port;
                    frm.serialPort1.BaudRate = 115200;
                    frm.serialPort1.Open();


                    string return_message = "";
                    DateTime startTime = DateTime.Now;
                    Write_to_terminal w = new Write_to_terminal();
                    frm.serialPort1.WriteLine("tst,nde");
                    while (return_message != "tst,Serial Com working")
                    {
                        await Task.Delay(100);
                        return_message = String.Concat(frm.serialPort1.ReadExisting());

                        if (DateTime.Now.Subtract(startTime).Seconds >= 5)
                        {
                            await w.Write(frm, "No Response from port: " + port, 1, Color.Red, false);
                            frm.serialPort1.Close();
                            break;
                        }
                    }

                    if (return_message == "tst,Serial Com working")
                    {
                        await w.Write(frm, "Response from port: " + port, 1, Color.White, false);
                        frm.serialPort1.Close();
                        return port;
                    }
                    if (frm.serialPort1.IsOpen)
                    {
                        frm.serialPort1.Close();
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return "fail";
        }
    }
}
