using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INsecure_Windows_Interface
{
    public partial class frm_main : Form
    {
        MJPEGStream stream1;
        public frm_main()
        {
            InitializeComponent();

        }
        public delegate void myDelegate(string indata);
        String active_port;
        Boolean stream_active = false;
        private async void frm_main_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            Boolean serial_test;
            Boolean network_test;
            Boolean JSON_test;

            Write_to_terminal w = new Write_to_terminal();

            await w.Append_text(this, "               [INsecure Ver0.9]               ", 0, Color.Black, Color.White, true);
            await w.Write(this, "---------------------------------------", 1, Color.White, false);

            rtb_output.AppendText(Environment.NewLine);
            await Task.Delay(800);

            await w.Append_text(this, " [STARTING] ", 1, Color.Black, Color.White, true);
            await w.Write(this, "", 40, Color.White, false);

            await w.Append_other(this, " [Discover Ports] ", 1, Color.Black, Color.White, true);
            string[] ports = SerialPort.GetPortNames();
            System_Diagnostic sd = new System_Diagnostic();
            for (int i = 0; i < ports.Length; i++)
            {
                await w.Write_other(this, ports[i], 1, Color.White, false);
            }

            active_port = await sd.Test_comm_ports(this, ports);
            if (active_port != null && active_port != "fail")
            {
                await w.Write_other(this, "", 1, Color.White, false);
                await w.Append_other(this, "Listening to port: " + active_port, 1, Color.White, Color.Empty, true);
            }
            else
            {
                await w.Write_other(this, "", 1, Color.White, false);
                await w.Append_other(this, " [NO PORT DETECTED] ", 1, Color.Red, Color.Empty, true);
            }
            await Task.Delay(200);

            serial_test = await sd.test_serial_(this);
            await Task.Delay(100);

            network_test = await sd.Test_local_networkAsync(this);
            await Task.Delay(100);

            JSON_test = await sd.test_JSON_MAC_(this);
            await Task.Delay(1000);

            rtb_other_data.AppendText(Environment.NewLine);
            if (serial_test && network_test && JSON_test)
            {
                await w.Append_other(this, ">", 1, Color.White, Color.Empty, false);
                await w.Append_other(this, "System Ready", 1, Color.White, Color.Empty, true);
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = active_port;
                    serialPort1.BaudRate = 115200;
                    serialPort1.Open();
                }
            }
            else
            {
                await w.Append_other(this, ">", 10, Color.White, Color.Empty, false);
                await w.Append_other(this, " STARTUP FAILED ", 1, Color.White, Color.Red, true);
                rtb_other_data.AppendText(Environment.NewLine);
                await w.Append_other(this, ">", 10, Color.White, Color.Empty, false);
                await w.Append_other(this, "address startup issues and reboot", 1, Color.Red, Color.Empty, true);
            }

                //serialPort1.PortName = active_port;
                //serialPort1.BaudRate = 115200;
                //serialPort1.Open();
        }

        private async void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            await Task.Delay(120);
            SerialPort sp = (SerialPort)sender;
            await Task.Delay(1000);
            try
            {
                string indata = sp.ReadExisting();
                this.BeginInvoke((new myDelegate(Text_Out)), indata);
            }
            catch (Exception ex)
            {
            }
            
        }
        public async void Text_Out(string indata)
        {
            await Task.Delay(1000);
            String read_data = "";
            Write_to_terminal w = new Write_to_terminal();
            read_data = read_data + indata.ToString();
            read_data.Trim();
            string remove_extraneous_chars = string.Join(" ", Regex.Split(read_data, @"(?:\r\n|\n|\r)"));

            if (remove_extraneous_chars.Length > 8) { 
                 String[] words = read_data.Split(',');
                 String[] temp_arr = new string[5];
                 rtb_other_data.AppendText(Environment.NewLine + read_data);
                 await Task.Delay(100);
                  int n = 0;
            foreach (var word in words)
            {
                temp_arr[n] = word;
                n++;
            }
            try
            {
                if (temp_arr[0] == "web" || temp_arr[0] == "eb")
                {
                    if (temp_arr[2].Length > 0)
                    {
                        await w.Write(this, "Camera stream @ " + temp_arr[2], 1, Color.White, false);
                            stream1 = new MJPEGStream(temp_arr[2]);
                            if (stream1 is null)
                            {
                                stream_active = false;  
                                pb_cam.Image = Properties.Resources.default_video;
                                await w.Write(this, " FAILED TO FIND STREAM", 1, Color.White,true);
                            }
                           else {
                                stream_active = true;   
                                stream1.NewFrame += Stream_Newframe;
                                stream1.Start();
                                // stream1.NewFrame += stream_NewframeAsync; 
                            }
                        }
                }
                else if (temp_arr[0] == "pir")
                {
                    if (temp_arr[2] == "1")
                    {
                        await w.Write(this, "PIR " + temp_arr[1] + " detected motion", 1, Color.White, false);
                    }
                    else if (temp_arr[2] == "0")
                    {
                        await w.Write(this, "PIR " + temp_arr[1] + " :unknown action", 1, Color.White, false);
                    }
                    else
                    {
                        await w.Write(this, "Unknown cmd from " + temp_arr[1], 1, Color.White, false);
                    }
                }
                else if (temp_arr[0] == "CAM")
                {
                    if (temp_arr[2] == "1")
                    {
                        await w.Write(this, "CAM " + temp_arr[1] + " preparing to stream", 1, Color.White, false);
                    }
                    else if (temp_arr[2] == "0")
                    {
                        await w.Write(this, "CAM " + temp_arr[1] + " stopping stream", 1, Color.White, false);
                    }
                    else
                    {
                       await w.Write(this, "Unknown cmd from " + temp_arr[1], 1, Color.White, false);
                    }
                }
                else
                {

                   await w.Write(this, "uknown serial input", 1, Color.White, false);
                }
            }
            catch (Exception ex)
            {
                await w.Write(this, "uknown exception occured", 1, Color.White, true);
            }
        }
        }

        void Stream_Newframe(object sender, NewFrameEventArgs eventArgs)
        {

            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();

            if (bmp is null)
            {
                stream_active = false;
                pb_cam.Image = Properties.Resources.default_video;
                
                
            }
            else
            {
                stream_active = true;
                pb_cam.Image = bmp;
            }
        }

            private async void btn_cam1_Click(object sender, EventArgs e)
        { 
            Start_Stop_Cam_btns s = new Start_Stop_Cam_btns();
            if (!stream_active)
            {
               
                if (serialPort1.IsOpen)
                {
                    await (s.Cam_1(this));
                }
                else
                {
                    Write_to_terminal w = new Write_to_terminal();
                    await w.Write(this, "Serial port not available", 1, Color.Red, false);
                }
            }
            else
            {
                stream1.Stop();
                stream_active = false;
                pb_cam.Image = Properties.Resources.default_video;
                await s.Terminate_stream_1(this);

            }
        }

        

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private async void btn_cam2_Click(object sender, EventArgs e)
        {
            Start_Stop_Cam_btns s = new Start_Stop_Cam_btns();
            if (!stream_active)
            {
                if (serialPort1.IsOpen)
                {
                    
                    await (s.Cam_2(this));
                }
                else
                {
                    Write_to_terminal w = new Write_to_terminal();
                    await w.Write(this, "Serial port not available", 1, Color.Red, false);
                }
            }
            else
            {
                stream1.Stop();
                stream_active = false;
                pb_cam.Image = Properties.Resources.default_video;
                await s.Terminate_stream_2(this);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_clk.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }



    }
}
