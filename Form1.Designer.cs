namespace lynxAudioEnc
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lstAudioFiles = new System.Windows.Forms.ListBox();
            this.btAddFile = new System.Windows.Forms.Button();
            this.btRmFile = new System.Windows.Forms.Button();
            this.btOutLoc = new System.Windows.Forms.Button();
            this.txtOutLoc = new System.Windows.Forms.TextBox();
            this.btStartEnc = new System.Windows.Forms.Button();
            this.cbKeepMeta = new System.Windows.Forms.CheckBox();
            this.cobBitrate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomBitrate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cobSampleRate = new System.Windows.Forms.ComboBox();
            this.txtCustomSampleRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHardCutoff = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cobEncoder = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cobRateControl = new System.Windows.Forms.ComboBox();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cobTVBR = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSameDirAsInput = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lstAudioFiles
            // 
            this.lstAudioFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstAudioFiles.ForeColor = System.Drawing.Color.White;
            this.lstAudioFiles.FormattingEnabled = true;
            this.lstAudioFiles.Location = new System.Drawing.Point(12, 41);
            this.lstAudioFiles.Name = "lstAudioFiles";
            this.lstAudioFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAudioFiles.Size = new System.Drawing.Size(646, 264);
            this.lstAudioFiles.TabIndex = 0;
            // 
            // btAddFile
            // 
            this.btAddFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddFile.ForeColor = System.Drawing.Color.White;
            this.btAddFile.Location = new System.Drawing.Point(12, 12);
            this.btAddFile.Name = "btAddFile";
            this.btAddFile.Size = new System.Drawing.Size(75, 23);
            this.btAddFile.TabIndex = 1;
            this.btAddFile.Text = "Add";
            this.btAddFile.UseVisualStyleBackColor = true;
            this.btAddFile.Click += new System.EventHandler(this.btAddFile_Click);
            // 
            // btRmFile
            // 
            this.btRmFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRmFile.ForeColor = System.Drawing.Color.White;
            this.btRmFile.Location = new System.Drawing.Point(93, 12);
            this.btRmFile.Name = "btRmFile";
            this.btRmFile.Size = new System.Drawing.Size(75, 23);
            this.btRmFile.TabIndex = 2;
            this.btRmFile.Text = "Remove";
            this.btRmFile.UseVisualStyleBackColor = true;
            this.btRmFile.Click += new System.EventHandler(this.btRmFile_Click);
            // 
            // btOutLoc
            // 
            this.btOutLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOutLoc.ForeColor = System.Drawing.Color.White;
            this.btOutLoc.Location = new System.Drawing.Point(12, 311);
            this.btOutLoc.Name = "btOutLoc";
            this.btOutLoc.Size = new System.Drawing.Size(114, 23);
            this.btOutLoc.TabIndex = 3;
            this.btOutLoc.Text = "Output Location";
            this.btOutLoc.UseVisualStyleBackColor = true;
            this.btOutLoc.Click += new System.EventHandler(this.btOutLoc_Click);
            // 
            // txtOutLoc
            // 
            this.txtOutLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtOutLoc.ForeColor = System.Drawing.Color.White;
            this.txtOutLoc.Location = new System.Drawing.Point(132, 311);
            this.txtOutLoc.Name = "txtOutLoc";
            this.txtOutLoc.Size = new System.Drawing.Size(526, 20);
            this.txtOutLoc.TabIndex = 4;
            // 
            // btStartEnc
            // 
            this.btStartEnc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStartEnc.ForeColor = System.Drawing.Color.White;
            this.btStartEnc.Location = new System.Drawing.Point(12, 470);
            this.btStartEnc.Name = "btStartEnc";
            this.btStartEnc.Size = new System.Drawing.Size(114, 23);
            this.btStartEnc.TabIndex = 5;
            this.btStartEnc.Text = "Start Encode";
            this.btStartEnc.UseVisualStyleBackColor = true;
            this.btStartEnc.Click += new System.EventHandler(this.btStartEnc_Click);
            // 
            // cbKeepMeta
            // 
            this.cbKeepMeta.AutoSize = true;
            this.cbKeepMeta.Checked = true;
            this.cbKeepMeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepMeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbKeepMeta.ForeColor = System.Drawing.Color.White;
            this.cbKeepMeta.Location = new System.Drawing.Point(559, 12);
            this.cbKeepMeta.Name = "cbKeepMeta";
            this.cbKeepMeta.Size = new System.Drawing.Size(96, 17);
            this.cbKeepMeta.TabIndex = 6;
            this.cbKeepMeta.Text = "Keep Metadata";
            this.cbKeepMeta.UseVisualStyleBackColor = true;
            // 
            // cobBitrate
            // 
            this.cobBitrate.BackColor = System.Drawing.SystemColors.Window;
            this.cobBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobBitrate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cobBitrate.FormattingEnabled = true;
            this.cobBitrate.Items.AddRange(new object[] {
            "32",
            "64",
            "96",
            "128",
            "160",
            "192",
            "224",
            "256",
            "288",
            "320"});
            this.cobBitrate.Location = new System.Drawing.Point(615, 340);
            this.cobBitrate.Name = "cobBitrate";
            this.cobBitrate.Size = new System.Drawing.Size(43, 21);
            this.cobBitrate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(540, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bitrate (kbps)";
            // 
            // txtCustomBitrate
            // 
            this.txtCustomBitrate.Location = new System.Drawing.Point(615, 367);
            this.txtCustomBitrate.MaxLength = 4;
            this.txtCustomBitrate.Name = "txtCustomBitrate";
            this.txtCustomBitrate.Size = new System.Drawing.Size(43, 20);
            this.txtCustomBitrate.TabIndex = 9;
            this.txtCustomBitrate.TextChanged += new System.EventHandler(this.txtCustomBitrate_TextChanged);
            this.txtCustomBitrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomBitrate_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(502, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Custom Bitrate (kbps)";
            // 
            // cobSampleRate
            // 
            this.cobSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSampleRate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cobSampleRate.FormattingEnabled = true;
            this.cobSampleRate.Items.AddRange(new object[] {
            "11025",
            "22050",
            "44100",
            "48000"});
            this.cobSampleRate.Location = new System.Drawing.Point(436, 340);
            this.cobSampleRate.Name = "cobSampleRate";
            this.cobSampleRate.Size = new System.Drawing.Size(60, 21);
            this.cobSampleRate.TabIndex = 11;
            // 
            // txtCustomSampleRate
            // 
            this.txtCustomSampleRate.Location = new System.Drawing.Point(436, 367);
            this.txtCustomSampleRate.MaxLength = 6;
            this.txtCustomSampleRate.Name = "txtCustomSampleRate";
            this.txtCustomSampleRate.Size = new System.Drawing.Size(60, 20);
            this.txtCustomSampleRate.TabIndex = 12;
            this.txtCustomSampleRate.TextChanged += new System.EventHandler(this.txtCustomSampleRate_TextChanged);
            this.txtCustomSampleRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomSampleRate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(342, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sample Rate (hz)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(304, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Custom Sample Rate (hz)";
            // 
            // txtHardCutoff
            // 
            this.txtHardCutoff.Location = new System.Drawing.Point(245, 340);
            this.txtHardCutoff.MaxLength = 6;
            this.txtHardCutoff.Name = "txtHardCutoff";
            this.txtHardCutoff.Size = new System.Drawing.Size(51, 20);
            this.txtHardCutoff.TabIndex = 15;
            this.txtHardCutoff.Text = "20000";
            this.txtHardCutoff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHardCutoff_KeyPress);
            this.txtHardCutoff.Leave += new System.EventHandler(this.txtHardCutoff_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(158, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Hard Cutoff (hz)";
            // 
            // cobEncoder
            // 
            this.cobEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobEncoder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cobEncoder.FormattingEnabled = true;
            this.cobEncoder.Items.AddRange(new object[] {
            "AAC (qaac)",
            "AAC (fdkaac)",
            "OGG Opus (vac-enc)",
            "OGG Vorbis (oggenc)",
            "MP3 (fhg-mp3enc v3.01)",
            "MP3 (lame)"});
            this.cobEncoder.Location = new System.Drawing.Point(459, 418);
            this.cobEncoder.Name = "cobEncoder";
            this.cobEncoder.Size = new System.Drawing.Size(199, 21);
            this.cobEncoder.TabIndex = 17;
            this.cobEncoder.SelectedIndexChanged += new System.EventHandler(this.cobEncoder_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(406, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Encoder";
            // 
            // cobRateControl
            // 
            this.cobRateControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobRateControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cobRateControl.FormattingEnabled = true;
            this.cobRateControl.Items.AddRange(new object[] {
            "Variable Bitrate (VBR)",
            "Constrained Variable Bitrate (CVBR)",
            "True Variable Bitrate (TVBR)",
            "Adaptive Bitrate (ABR)",
            "Constant Bitrate (CBR)"});
            this.cobRateControl.Location = new System.Drawing.Point(459, 445);
            this.cobRateControl.Name = "cobRateControl";
            this.cobRateControl.Size = new System.Drawing.Size(199, 21);
            this.cobRateControl.TabIndex = 19;
            this.cobRateControl.SelectedIndexChanged += new System.EventHandler(this.cobRateControl_SelectedIndexChanged);
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(87, 442);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(39, 20);
            this.txtThreadCount.TabIndex = 20;
            this.txtThreadCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThreadCount_KeyPress);
            this.txtThreadCount.Leave += new System.EventHandler(this.txtThreadCount_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 445);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Thread Count";
            // 
            // cobTVBR
            // 
            this.cobTVBR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobTVBR.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cobTVBR.FormattingEnabled = true;
            this.cobTVBR.Items.AddRange(new object[] {
            "0",
            "9",
            "18",
            "27",
            "36",
            "45",
            "54",
            "64",
            "73",
            "82",
            "91",
            "100",
            "109",
            "118",
            "127"});
            this.cobTVBR.Location = new System.Drawing.Point(459, 472);
            this.cobTVBR.Name = "cobTVBR";
            this.cobTVBR.Size = new System.Drawing.Size(199, 21);
            this.cobTVBR.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(335, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "True VBR Quality Level";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(353, 448);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Rate Control Option";
            // 
            // cbSameDirAsInput
            // 
            this.cbSameDirAsInput.AutoSize = true;
            this.cbSameDirAsInput.Checked = true;
            this.cbSameDirAsInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSameDirAsInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSameDirAsInput.ForeColor = System.Drawing.Color.White;
            this.cbSameDirAsInput.Location = new System.Drawing.Point(12, 385);
            this.cbSameDirAsInput.Name = "cbSameDirAsInput";
            this.cbSameDirAsInput.Size = new System.Drawing.Size(178, 17);
            this.cbSameDirAsInput.TabIndex = 25;
            this.cbSameDirAsInput.Text = "Output to same directory as input";
            this.cbSameDirAsInput.UseVisualStyleBackColor = true;
            this.cbSameDirAsInput.CheckedChanged += new System.EventHandler(this.cbSameDirAsInput_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(670, 506);
            this.Controls.Add(this.cbSameDirAsInput);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cobTVBR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtThreadCount);
            this.Controls.Add(this.cobRateControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cobEncoder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHardCutoff);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomSampleRate);
            this.Controls.Add(this.cobSampleRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomBitrate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cobBitrate);
            this.Controls.Add(this.cbKeepMeta);
            this.Controls.Add(this.btStartEnc);
            this.Controls.Add(this.txtOutLoc);
            this.Controls.Add(this.btOutLoc);
            this.Controls.Add(this.btRmFile);
            this.Controls.Add(this.btAddFile);
            this.Controls.Add(this.lstAudioFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "lynxAudioEnc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstAudioFiles;
        private System.Windows.Forms.Button btAddFile;
        private System.Windows.Forms.Button btRmFile;
        private System.Windows.Forms.Button btOutLoc;
        private System.Windows.Forms.TextBox txtOutLoc;
        private System.Windows.Forms.Button btStartEnc;
        private System.Windows.Forms.CheckBox cbKeepMeta;
        private System.Windows.Forms.ComboBox cobBitrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomBitrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cobSampleRate;
        private System.Windows.Forms.TextBox txtCustomSampleRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHardCutoff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cobEncoder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cobRateControl;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cobTVBR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbSameDirAsInput;
    }
}

