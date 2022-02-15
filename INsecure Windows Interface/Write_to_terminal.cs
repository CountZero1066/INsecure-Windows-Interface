using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INsecure_Windows_Interface
{
    internal class Write_to_terminal
    {
        private frm_main frm;
        public async Task Write(frm_main frm, String write_text, int write_speed, Color text_colour, bool highlight)
        {
            bool ready = false;
            if (ready)
            {
                await Task.Delay(1000);
            }
            else
            {
                ready = true;
                this.frm = frm;
                frm.rtb_output.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
                frm.rtb_output.SelectionColor = Color.White;
                frm.rtb_output.AppendText(Environment.NewLine);
                frm.rtb_output.AppendText(">");
                frm.rtb_output.SelectionColor = Color.FromArgb(text_colour.ToArgb());
                if (highlight)
                {
                    frm.rtb_output.SelectionBackColor = Color.Red;
                    frm.rtb_output.SelectionFont = new Font(frm.rtb_output.Font, FontStyle.Bold);
                }
                else
                {
                    frm.rtb_output.SelectionBackColor = Color.Empty;
                    frm.rtb_output.SelectionFont = new Font(frm.rtb_output.Font, FontStyle.Regular);
                }
                foreach (char c in write_text)
                {
                    await Task.Delay(write_speed);
                    frm.rtb_output.AppendText(c.ToString());
                }


                frm.rtb_output.SelectionColor = Color.White;
            }

        }

        public async Task Append_text(frm_main frm, String write_text, int write_speed, Color text_colour, Color highlight_colour, bool bold_regular)
        {
            this.frm = frm;
            frm.rtb_output.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            frm.rtb_output.SelectionColor = Color.White;
            frm.rtb_output.SelectionColor = Color.FromArgb(text_colour.ToArgb());
            frm.rtb_output.SelectionBackColor = Color.FromArgb(highlight_colour.ToArgb());

            if (bold_regular)
            {
                frm.rtb_output.SelectionFont = new Font(frm.rtb_output.Font, FontStyle.Bold);
            }
            else
            {
                frm.rtb_output.SelectionFont = new Font(frm.rtb_output.Font, FontStyle.Regular);
            }

            foreach (char c in write_text)
            {
                await Task.Delay(write_speed);
                frm.rtb_output.AppendText(c.ToString());
            }

            frm.rtb_output.SelectionFont = new Font(frm.rtb_output.Font, FontStyle.Regular);
            frm.rtb_output.SelectionColor = Color.White;
            frm.rtb_output.SelectionBackColor = Color.Empty;
        }

        public async Task Write_other(frm_main frm, String write_text, int write_speed, Color text_colour, bool highlight)
        {
            bool ready = false;
            if (ready)
            {
                await Task.Delay(1000);
            }
            else
            {
                ready = true;
                this.frm = frm;
                frm.rtb_other_data.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
                frm.rtb_other_data.SelectionColor = Color.White;
                frm.rtb_other_data.AppendText(Environment.NewLine);
                frm.rtb_other_data.AppendText(">");
                frm.rtb_other_data.SelectionColor = Color.FromArgb(text_colour.ToArgb());
                if (highlight)
                {
                    frm.rtb_other_data.SelectionBackColor = Color.Red;
                    frm.rtb_other_data.SelectionFont = new Font(frm.rtb_other_data.Font, FontStyle.Bold);
                }
                else
                {
                    frm.rtb_other_data.SelectionBackColor = Color.Empty;
                    frm.rtb_other_data.SelectionFont = new Font(frm.rtb_other_data.Font, FontStyle.Regular);
                }
                foreach (char c in write_text)
                {
                    await Task.Delay(write_speed);
                    frm.rtb_other_data.AppendText(c.ToString());
                }


                frm.rtb_other_data.SelectionColor = Color.White;
            }

        }

        public async Task Append_other(frm_main frm, String write_text, int write_speed, Color text_colour, Color highlight_colour, bool bold_regular)
        {
            this.frm = frm;
            frm.rtb_other_data.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            frm.rtb_other_data.SelectionColor = Color.White;
            frm.rtb_other_data.SelectionColor = Color.FromArgb(text_colour.ToArgb());
            frm.rtb_other_data.SelectionBackColor = Color.FromArgb(highlight_colour.ToArgb());

            if (bold_regular)
            {
                frm.rtb_other_data.SelectionFont = new Font(frm.rtb_other_data.Font, FontStyle.Bold);
            }
            else
            {
                frm.rtb_other_data.SelectionFont = new Font(frm.rtb_other_data.Font, FontStyle.Regular);
            }

            foreach (char c in write_text)
            {
                await Task.Delay(write_speed);
                frm.rtb_other_data.AppendText(c.ToString());
            }

            frm.rtb_other_data.SelectionFont = new Font(frm.rtb_other_data.Font, FontStyle.Regular);
            frm.rtb_other_data.SelectionColor = Color.White;
            frm.rtb_other_data.SelectionBackColor = Color.Empty;
        }
    }
}
