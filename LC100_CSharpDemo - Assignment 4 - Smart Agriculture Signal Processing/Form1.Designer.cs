namespace LC100_CSharpDemo
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_StartScan = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_OperationMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_IntegrationTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_SerialNumber = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDark = new System.Windows.Forms.Button();
            this.btnBlank = new System.Windows.Forms.Button();
            this.btnSample = new System.Windows.Forms.Button();
            this.chkT = new System.Windows.Forms.CheckBox();
            this.chkAbs = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IntegrationTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_StartScan
            // 
            this.button_StartScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartScan.Location = new System.Drawing.Point(343, 86);
            this.button_StartScan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_StartScan.Name = "button_StartScan";
            this.button_StartScan.Size = new System.Drawing.Size(158, 35);
            this.button_StartScan.TabIndex = 8;
            this.button_StartScan.Text = "Start Scan";
            this.button_StartScan.UseVisualStyleBackColor = true;
            this.button_StartScan.Click += new System.EventHandler(this.button_StartScan_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBox_OperationMode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDown_IntegrationTime);
            this.groupBox2.Location = new System.Drawing.Point(14, 78);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(304, 89);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instrumenmt Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "ms";
            // 
            // comboBox_OperationMode
            // 
            this.comboBox_OperationMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OperationMode.FormattingEnabled = true;
            this.comboBox_OperationMode.Location = new System.Drawing.Point(111, 18);
            this.comboBox_OperationMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_OperationMode.Name = "comboBox_OperationMode";
            this.comboBox_OperationMode.Size = new System.Drawing.Size(164, 20);
            this.comboBox_OperationMode.TabIndex = 5;
            this.comboBox_OperationMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_OperationMode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Operation Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Integration Time";
            // 
            // numericUpDown_IntegrationTime
            // 
            this.numericUpDown_IntegrationTime.DecimalPlaces = 1;
            this.numericUpDown_IntegrationTime.Location = new System.Drawing.Point(111, 42);
            this.numericUpDown_IntegrationTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDown_IntegrationTime.Name = "numericUpDown_IntegrationTime";
            this.numericUpDown_IntegrationTime.Size = new System.Drawing.Size(82, 21);
            this.numericUpDown_IntegrationTime.TabIndex = 3;
            this.numericUpDown_IntegrationTime.Value = new decimal(new int[] {
            50,
            0,
            0,
            65536});
            this.numericUpDown_IntegrationTime.ValueChanged += new System.EventHandler(this.numericUpDown_IntegrationTime_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_SerialNumber);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(553, 61);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instrument Informations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "::RAW\'";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Opening Session to \'USB0::0x1313::0x80A0::M";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(558, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start the application \"sample.exe\" and read out the 8 numerics serial number (wit" +
    "h leading zeros)";
            // 
            // textBox_SerialNumber
            // 
            this.textBox_SerialNumber.Location = new System.Drawing.Point(281, 30);
            this.textBox_SerialNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_SerialNumber.Name = "textBox_SerialNumber";
            this.textBox_SerialNumber.Size = new System.Drawing.Size(116, 21);
            this.textBox_SerialNumber.TabIndex = 1;
            this.textBox_SerialNumber.Text = "00345678";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(14, 212);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 248);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnDark
            // 
            this.btnDark.Location = new System.Drawing.Point(14, 183);
            this.btnDark.Name = "btnDark";
            this.btnDark.Size = new System.Drawing.Size(75, 23);
            this.btnDark.TabIndex = 10;
            this.btnDark.Text = "Dark";
            this.btnDark.UseVisualStyleBackColor = true;
            this.btnDark.Click += new System.EventHandler(this.btnDark_Click);
            // 
            // btnBlank
            // 
            this.btnBlank.Location = new System.Drawing.Point(95, 183);
            this.btnBlank.Name = "btnBlank";
            this.btnBlank.Size = new System.Drawing.Size(75, 23);
            this.btnBlank.TabIndex = 11;
            this.btnBlank.Text = "Blank";
            this.btnBlank.UseVisualStyleBackColor = true;
            this.btnBlank.Click += new System.EventHandler(this.btnBlank_Click);
            // 
            // btnSample
            // 
            this.btnSample.Location = new System.Drawing.Point(176, 183);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(75, 23);
            this.btnSample.TabIndex = 12;
            this.btnSample.Text = "Sample";
            this.btnSample.UseVisualStyleBackColor = true;
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // chkT
            // 
            this.chkT.AutoSize = true;
            this.chkT.Checked = true;
            this.chkT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkT.Location = new System.Drawing.Point(295, 187);
            this.chkT.Name = "chkT";
            this.chkT.Size = new System.Drawing.Size(105, 16);
            this.chkT.TabIndex = 13;
            this.chkT.Text = "Transmittance";
            this.chkT.UseVisualStyleBackColor = true;
            // 
            // chkAbs
            // 
            this.chkAbs.AutoSize = true;
            this.chkAbs.Location = new System.Drawing.Point(421, 185);
            this.chkAbs.Name = "chkAbs";
            this.chkAbs.Size = new System.Drawing.Size(92, 16);
            this.chkAbs.TabIndex = 14;
            this.chkAbs.Text = "Absorbance";
            this.chkAbs.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(295, 212);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(272, 248);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 471);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.chkAbs);
            this.Controls.Add(this.chkT);
            this.Controls.Add(this.btnSample);
            this.Controls.Add(this.btnBlank);
            this.Controls.Add(this.btnDark);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_StartScan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "LC100 CSharp Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IntegrationTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_StartScan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_IntegrationTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_SerialNumber;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox_OperationMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDark;
        private System.Windows.Forms.Button btnBlank;
        private System.Windows.Forms.Button btnSample;
        private System.Windows.Forms.CheckBox chkT;
        private System.Windows.Forms.CheckBox chkAbs;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

