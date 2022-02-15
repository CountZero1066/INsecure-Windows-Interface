using System;

namespace INsecure_Windows_Interface
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.rtb_other_data = new System.Windows.Forms.RichTextBox();
            this.btn_cam1 = new System.Windows.Forms.Button();
            this.btn_cam2 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.pb_cam = new System.Windows.Forms.PictureBox();
            this.lbl_clk = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_cam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtb_output
            // 
            this.rtb_output.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rtb_output.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtb_output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_output.Cursor = System.Windows.Forms.Cursors.Cross;
            this.rtb_output.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_output.ForeColor = System.Drawing.SystemColors.Window;
            this.rtb_output.Location = new System.Drawing.Point(273, 400);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtb_output.ShortcutsEnabled = false;
            this.rtb_output.Size = new System.Drawing.Size(264, 539);
            this.rtb_output.TabIndex = 1;
            this.rtb_output.TabStop = false;
            this.rtb_output.Text = "";
            // 
            // rtb_other_data
            // 
            this.rtb_other_data.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtb_other_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_other_data.Cursor = System.Windows.Forms.Cursors.Cross;
            this.rtb_other_data.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_other_data.ForeColor = System.Drawing.SystemColors.Window;
            this.rtb_other_data.Location = new System.Drawing.Point(6, 400);
            this.rtb_other_data.Name = "rtb_other_data";
            this.rtb_other_data.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtb_other_data.Size = new System.Drawing.Size(264, 175);
            this.rtb_other_data.TabIndex = 7;
            this.rtb_other_data.Text = "";
            // 
            // btn_cam1
            // 
            this.btn_cam1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btn_cam1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_cam1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_cam1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cam1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cam1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cam1.Location = new System.Drawing.Point(6, 338);
            this.btn_cam1.Name = "btn_cam1";
            this.btn_cam1.Size = new System.Drawing.Size(264, 56);
            this.btn_cam1.TabIndex = 8;
            this.btn_cam1.Text = "Camera 1";
            this.btn_cam1.UseVisualStyleBackColor = true;
            this.btn_cam1.Click += new System.EventHandler(this.btn_cam1_Click);
            // 
            // btn_cam2
            // 
            this.btn_cam2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btn_cam2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_cam2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_cam2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cam2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cam2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cam2.Location = new System.Drawing.Point(273, 338);
            this.btn_cam2.Name = "btn_cam2";
            this.btn_cam2.Size = new System.Drawing.Size(264, 56);
            this.btn_cam2.TabIndex = 9;
            this.btn_cam2.Text = "Camera 2";
            this.btn_cam2.UseVisualStyleBackColor = true;
            this.btn_cam2.Click += new System.EventHandler(this.btn_cam2_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // pb_cam
            // 
            this.pb_cam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_cam.Image = ((System.Drawing.Image)(resources.GetObject("pb_cam.Image")));
            this.pb_cam.Location = new System.Drawing.Point(6, 12);
            this.pb_cam.Name = "pb_cam";
            this.pb_cam.Size = new System.Drawing.Size(531, 323);
            this.pb_cam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_cam.TabIndex = 10;
            this.pb_cam.TabStop = false;
            // 
            // lbl_clk
            // 
            this.lbl_clk.AutoSize = true;
            this.lbl_clk.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clk.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_clk.Location = new System.Drawing.Point(12, 12);
            this.lbl_clk.Name = "lbl_clk";
            this.lbl_clk.Size = new System.Drawing.Size(55, 21);
            this.lbl_clk.TabIndex = 11;
            this.lbl_clk.Text = "lbl_clk";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 839);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(540, 941);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_clk);
            this.Controls.Add(this.pb_cam);
            this.Controls.Add(this.btn_cam2);
            this.Controls.Add(this.btn_cam1);
            this.Controls.Add(this.rtb_other_data);
            this.Controls.Add(this.rtb_output);
            this.Name = "frm_main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_cam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        public System.Windows.Forms.RichTextBox rtb_output;
        public System.Windows.Forms.RichTextBox rtb_other_data;
        private System.Windows.Forms.Button btn_cam1;
        private System.Windows.Forms.Button btn_cam2;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.PictureBox pb_cam;
        public System.Windows.Forms.Label lbl_clk;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer2;
    }
}

