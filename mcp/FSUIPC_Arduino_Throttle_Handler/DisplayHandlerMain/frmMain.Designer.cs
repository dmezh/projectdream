namespace DisplayHandlerMain
{
    partial class frmMain
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
            this.btnToggleConnection = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtATIAS = new System.Windows.Forms.TextBox();
            this.txtATMACH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtATTYPE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnToggleConnection
            // 
            this.btnToggleConnection.Location = new System.Drawing.Point(12, 12);
            this.btnToggleConnection.Name = "btnToggleConnection";
            this.btnToggleConnection.Size = new System.Drawing.Size(134, 36);
            this.btnToggleConnection.TabIndex = 0;
            this.btnToggleConnection.Text = "Connect/Disconnect";
            this.btnToggleConnection.UseVisualStyleBackColor = true;
            this.btnToggleConnection.Click += new System.EventHandler(this.btnToggleConnection_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 221);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(421, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(104, 17);
            this.lblConnectionStatus.Text = "Connection Status";
            this.lblConnectionStatus.Click += new System.EventHandler(this.lblConnectionStatus_Click);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 15;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AP Set Speed (IAS)";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtATIAS
            // 
            this.txtATIAS.Location = new System.Drawing.Point(128, 69);
            this.txtATIAS.Name = "txtATIAS";
            this.txtATIAS.ReadOnly = true;
            this.txtATIAS.Size = new System.Drawing.Size(100, 20);
            this.txtATIAS.TabIndex = 4;
            // 
            // txtATMACH
            // 
            this.txtATMACH.Location = new System.Drawing.Point(128, 95);
            this.txtATMACH.Name = "txtATMACH";
            this.txtATMACH.ReadOnly = true;
            this.txtATMACH.Size = new System.Drawing.Size(100, 20);
            this.txtATMACH.TabIndex = 6;
            this.txtATMACH.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "AP Set Speed (Mach)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtATTYPE
            // 
            this.txtATTYPE.Location = new System.Drawing.Point(128, 121);
            this.txtATTYPE.Name = "txtATTYPE";
            this.txtATTYPE.ReadOnly = true;
            this.txtATTYPE.Size = new System.Drawing.Size(100, 20);
            this.txtATTYPE.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Current AT Ref Type";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 243);
            this.Controls.Add(this.txtATTYPE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtATMACH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtATIAS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnToggleConnection);
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToggleConnection;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtATIAS;
        private System.Windows.Forms.TextBox txtATMACH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtATTYPE;
        private System.Windows.Forms.Label label3;
    }
}

