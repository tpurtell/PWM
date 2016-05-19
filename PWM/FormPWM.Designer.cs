namespace PWM
{
    partial class FormPWM
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lOne = new System.Windows.Forms.Label();
            this.vOne = new System.Windows.Forms.Label();
            this.lCurrent = new System.Windows.Forms.Label();
            this.vCurrent = new System.Windows.Forms.Label();
            this.lNew = new System.Windows.Forms.Label();
            this.tNew = new System.Windows.Forms.TextBox();
            this.bSet = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.tmr_Refresh = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lOne);
            this.flowLayoutPanel1.Controls.Add(this.vOne);
            this.flowLayoutPanel1.Controls.Add(this.lCurrent);
            this.flowLayoutPanel1.Controls.Add(this.vCurrent);
            this.flowLayoutPanel1.Controls.Add(this.lNew);
            this.flowLayoutPanel1.Controls.Add(this.tNew);
            this.flowLayoutPanel1.Controls.Add(this.bSet);
            this.flowLayoutPanel1.Controls.Add(this.btn_Refresh);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 140);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lOne
            // 
            this.lOne.AutoSize = true;
            this.lOne.Location = new System.Drawing.Point(2, 0);
            this.lOne.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lOne.Name = "lOne";
            this.lOne.Size = new System.Drawing.Size(56, 17);
            this.lOne.TabIndex = 5;
            this.lOne.Text = "Value 1";
            // 
            // vOne
            // 
            this.vOne.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.vOne, true);
            this.vOne.Location = new System.Drawing.Point(62, 0);
            this.vOne.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vOne.Name = "vOne";
            this.vOne.Size = new System.Drawing.Size(32, 17);
            this.vOne.TabIndex = 6;
            this.vOne.Text = "???";
            // 
            // lCurrent
            // 
            this.lCurrent.AutoSize = true;
            this.lCurrent.Location = new System.Drawing.Point(2, 17);
            this.lCurrent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCurrent.Name = "lCurrent";
            this.lCurrent.Size = new System.Drawing.Size(55, 17);
            this.lCurrent.TabIndex = 0;
            this.lCurrent.Text = "Current";
            // 
            // vCurrent
            // 
            this.vCurrent.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.vCurrent, true);
            this.vCurrent.Location = new System.Drawing.Point(61, 17);
            this.vCurrent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vCurrent.Name = "vCurrent";
            this.vCurrent.Size = new System.Drawing.Size(32, 17);
            this.vCurrent.TabIndex = 1;
            this.vCurrent.Text = "???";
            // 
            // lNew
            // 
            this.lNew.AutoSize = true;
            this.lNew.Location = new System.Drawing.Point(2, 34);
            this.lNew.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNew.Name = "lNew";
            this.lNew.Size = new System.Drawing.Size(35, 17);
            this.lNew.TabIndex = 2;
            this.lNew.Text = "New";
            // 
            // tNew
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.tNew, true);
            this.tNew.Location = new System.Drawing.Point(41, 36);
            this.tNew.Margin = new System.Windows.Forms.Padding(2);
            this.tNew.Name = "tNew";
            this.tNew.Size = new System.Drawing.Size(74, 22);
            this.tNew.TabIndex = 3;
            // 
            // bSet
            // 
            this.bSet.Location = new System.Drawing.Point(2, 62);
            this.bSet.Margin = new System.Windows.Forms.Padding(2);
            this.bSet.Name = "bSet";
            this.bSet.Size = new System.Drawing.Size(74, 25);
            this.bSet.TabIndex = 4;
            this.bSet.Text = "Set";
            this.bSet.UseVisualStyleBackColor = true;
            this.bSet.Click += new System.EventHandler(this.bSet_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(98, 62);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(74, 25);
            this.btn_Refresh.TabIndex = 7;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tmr_Refresh
            // 
            this.tmr_Refresh.Interval = 3000;
            this.tmr_Refresh.Tick += new System.EventHandler(this.tmr_Refresh_Tick);
            // 
            // FormPWM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 140);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormPWM";
            this.Text = "PWM";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lCurrent;
        private System.Windows.Forms.Label vCurrent;
        private System.Windows.Forms.Label lNew;
        private System.Windows.Forms.TextBox tNew;
        private System.Windows.Forms.Button bSet;
        private System.Windows.Forms.Label lOne;
        private System.Windows.Forms.Label vOne;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Timer tmr_Refresh;
    }
}

