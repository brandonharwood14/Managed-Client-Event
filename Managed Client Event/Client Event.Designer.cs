namespace Managed_Client_Event
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.richResponse = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SerialData = new System.Windows.Forms.Label();
            this.TextBox_System_Log = new System.Windows.Forms.RichTextBox();
            this.ComboBox_Available_SerialPorts = new System.Windows.Forms.ComboBox();
            this.txtPortselect = new System.Windows.Forms.Label();
            this.ComboBox_Standard_Baudrates = new System.Windows.Forms.ComboBox();
            this.txtBaud = new System.Windows.Forms.Label();
            this.Button_Receive_Data = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 37);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(131, 63);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect to FSX and request Pitot switch and  Flaps events";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(12, 167);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(131, 23);
            this.buttonDisconnect.TabIndex = 1;
            this.buttonDisconnect.Text = "Disconnect from FSX";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // richResponse
            // 
            this.richResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richResponse.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richResponse.Location = new System.Drawing.Point(149, 39);
            this.richResponse.Name = "richResponse";
            this.richResponse.ReadOnly = true;
            this.richResponse.Size = new System.Drawing.Size(221, 151);
            this.richResponse.TabIndex = 3;
            this.richResponse.Text = "";
            this.richResponse.TextChanged += new System.EventHandler(this.richResponse_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Responses";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Flaps keys: F5 F6 F7 F8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pitot switch: shift-H";
            // 
            // SerialData
            // 
            this.SerialData.AutoSize = true;
            this.SerialData.Location = new System.Drawing.Point(152, 233);
            this.SerialData.Name = "SerialData";
            this.SerialData.Size = new System.Drawing.Size(59, 13);
            this.SerialData.TabIndex = 7;
            this.SerialData.Text = "Serial Data";
            // 
            // TextBox_System_Log
            // 
            this.TextBox_System_Log.Location = new System.Drawing.Point(149, 249);
            this.TextBox_System_Log.Name = "TextBox_System_Log";
            this.TextBox_System_Log.ReadOnly = true;
            this.TextBox_System_Log.Size = new System.Drawing.Size(221, 139);
            this.TextBox_System_Log.TabIndex = 8;
            this.TextBox_System_Log.Text = "";
            // 
            // ComboBox_Available_SerialPorts
            // 
            this.ComboBox_Available_SerialPorts.FormattingEnabled = true;
            this.ComboBox_Available_SerialPorts.Location = new System.Drawing.Point(12, 249);
            this.ComboBox_Available_SerialPorts.Name = "ComboBox_Available_SerialPorts";
            this.ComboBox_Available_SerialPorts.Size = new System.Drawing.Size(131, 21);
            this.ComboBox_Available_SerialPorts.TabIndex = 9;
            this.ComboBox_Available_SerialPorts.SelectedIndexChanged += new System.EventHandler(this.comboPortSelect_SelectedIndexChanged);
            // 
            // txtPortselect
            // 
            this.txtPortselect.AutoSize = true;
            this.txtPortselect.Location = new System.Drawing.Point(13, 233);
            this.txtPortselect.Name = "txtPortselect";
            this.txtPortselect.Size = new System.Drawing.Size(85, 13);
            this.txtPortselect.TabIndex = 10;
            this.txtPortselect.Text = "Select COM port";
            // 
            // ComboBox_Standard_Baudrates
            // 
            this.ComboBox_Standard_Baudrates.FormattingEnabled = true;
            this.ComboBox_Standard_Baudrates.Items.AddRange(new object[] {
            "115200",
            "9600"});
            this.ComboBox_Standard_Baudrates.Location = new System.Drawing.Point(12, 302);
            this.ComboBox_Standard_Baudrates.Name = "ComboBox_Standard_Baudrates";
            this.ComboBox_Standard_Baudrates.Size = new System.Drawing.Size(131, 21);
            this.ComboBox_Standard_Baudrates.TabIndex = 11;
            // 
            // txtBaud
            // 
            this.txtBaud.AutoSize = true;
            this.txtBaud.Location = new System.Drawing.Point(13, 286);
            this.txtBaud.Name = "txtBaud";
            this.txtBaud.Size = new System.Drawing.Size(91, 13);
            this.txtBaud.TabIndex = 12;
            this.txtBaud.Text = "Select Baud Rate";
            // 
            // Button_Receive_Data
            // 
            this.Button_Receive_Data.Location = new System.Drawing.Point(12, 345);
            this.Button_Receive_Data.Name = "Button_Receive_Data";
            this.Button_Receive_Data.Size = new System.Drawing.Size(131, 23);
            this.Button_Receive_Data.TabIndex = 13;
            this.Button_Receive_Data.Text = "Connect";
            this.Button_Receive_Data.UseVisualStyleBackColor = true;
            this.Button_Receive_Data.Click += new System.EventHandler(this.Button_Receive_Data_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 400);
            this.Controls.Add(this.Button_Receive_Data);
            this.Controls.Add(this.txtBaud);
            this.Controls.Add(this.ComboBox_Standard_Baudrates);
            this.Controls.Add(this.txtPortselect);
            this.Controls.Add(this.ComboBox_Available_SerialPorts);
            this.Controls.Add(this.TextBox_System_Log);
            this.Controls.Add(this.SerialData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richResponse);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "  SimConnect Managed Client Event";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.RichTextBox richResponse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SerialData;
        private System.Windows.Forms.RichTextBox TextBox_System_Log;
        private System.Windows.Forms.ComboBox ComboBox_Available_SerialPorts;
        private System.Windows.Forms.Label txtPortselect;
        private System.Windows.Forms.ComboBox ComboBox_Standard_Baudrates;
        private System.Windows.Forms.Label txtBaud;
        private System.Windows.Forms.Button Button_Receive_Data;
    }
}

