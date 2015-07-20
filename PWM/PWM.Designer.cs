namespace PWM
{
    partial class PWM
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lCurrent = new System.Windows.Forms.Label();
            this.vCurrent = new System.Windows.Forms.Label();
            this.lNew = new System.Windows.Forms.Label();
            this.tNew = new System.Windows.Forms.TextBox();
            this.bSet = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lCurrent);
            this.flowLayoutPanel1.Controls.Add(this.vCurrent);
            this.flowLayoutPanel1.Controls.Add(this.lNew);
            this.flowLayoutPanel1.Controls.Add(this.tNew);
            this.flowLayoutPanel1.Controls.Add(this.bSet);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(254, 113);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lCurrent
            // 
            this.lCurrent.AutoSize = true;
            this.lCurrent.Location = new System.Drawing.Point(3, 0);
            this.lCurrent.Name = "lCurrent";
            this.lCurrent.Size = new System.Drawing.Size(77, 25);
            this.lCurrent.TabIndex = 0;
            this.lCurrent.Text = "Current";
            // 
            // vCurrent
            // 
            this.vCurrent.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.vCurrent, true);
            this.vCurrent.Location = new System.Drawing.Point(86, 0);
            this.vCurrent.Name = "vCurrent";
            this.vCurrent.Size = new System.Drawing.Size(45, 25);
            this.vCurrent.TabIndex = 1;
            this.vCurrent.Text = "???";
            // 
            // lNew
            // 
            this.lNew.AutoSize = true;
            this.lNew.Location = new System.Drawing.Point(3, 25);
            this.lNew.Name = "lNew";
            this.lNew.Size = new System.Drawing.Size(51, 25);
            this.lNew.TabIndex = 2;
            this.lNew.Text = "New";
            // 
            // tNew
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.tNew, true);
            this.tNew.Location = new System.Drawing.Point(60, 28);
            this.tNew.Name = "tNew";
            this.tNew.Size = new System.Drawing.Size(100, 29);
            this.tNew.TabIndex = 3;
            // 
            // bSet
            // 
            this.bSet.Location = new System.Drawing.Point(3, 63);
            this.bSet.Name = "bSet";
            this.bSet.Size = new System.Drawing.Size(102, 38);
            this.bSet.TabIndex = 4;
            this.bSet.Text = "Set";
            this.bSet.UseVisualStyleBackColor = true;
            this.bSet.Click += new System.EventHandler(this.bSet_Click);
            // 
            // PWM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 113);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PWM";
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
    }
}

