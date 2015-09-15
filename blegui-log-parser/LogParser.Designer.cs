namespace RobotPajamas
{
    partial class LogParser
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
            this.loggingTextbox = new System.Windows.Forms.TextBox();
            this.loggingButton = new System.Windows.Forms.Button();
            this.handleTextbox = new System.Windows.Forms.TextBox();
            this.refreshLabel = new System.Windows.Forms.Label();
            this.filterGroup = new System.Windows.Forms.GroupBox();
            this.macTextbox = new System.Windows.Forms.TextBox();
            this.debuggerRadioButton = new System.Windows.Forms.RadioButton();
            this.macRadioButton = new System.Windows.Forms.RadioButton();
            this.handleRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.filterGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // loggingTextbox
            // 
            this.loggingTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loggingTextbox.Location = new System.Drawing.Point(12, 111);
            this.loggingTextbox.Multiline = true;
            this.loggingTextbox.Name = "loggingTextbox";
            this.loggingTextbox.ReadOnly = true;
            this.loggingTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.loggingTextbox.Size = new System.Drawing.Size(614, 285);
            this.loggingTextbox.TabIndex = 0;
            // 
            // loggingButton
            // 
            this.loggingButton.Location = new System.Drawing.Point(6, 14);
            this.loggingButton.Name = "loggingButton";
            this.loggingButton.Size = new System.Drawing.Size(152, 23);
            this.loggingButton.TabIndex = 1;
            this.loggingButton.Text = "Start Logging";
            this.loggingButton.UseVisualStyleBackColor = true;
            this.loggingButton.Click += new System.EventHandler(this.loggingButton_Click);
            // 
            // handleTextbox
            // 
            this.handleTextbox.Location = new System.Drawing.Point(81, 20);
            this.handleTextbox.Name = "handleTextbox";
            this.handleTextbox.Size = new System.Drawing.Size(100, 20);
            this.handleTextbox.TabIndex = 2;
            this.handleTextbox.Text = "0";
            // 
            // refreshLabel
            // 
            this.refreshLabel.AutoSize = true;
            this.refreshLabel.Location = new System.Drawing.Point(6, 49);
            this.refreshLabel.Name = "refreshLabel";
            this.refreshLabel.Size = new System.Drawing.Size(96, 13);
            this.refreshLabel.TabIndex = 3;
            this.refreshLabel.Text = "Refresh Time (sec)";
            // 
            // filterGroup
            // 
            this.filterGroup.Controls.Add(this.macTextbox);
            this.filterGroup.Controls.Add(this.debuggerRadioButton);
            this.filterGroup.Controls.Add(this.macRadioButton);
            this.filterGroup.Controls.Add(this.handleTextbox);
            this.filterGroup.Controls.Add(this.handleRadioButton);
            this.filterGroup.Location = new System.Drawing.Point(182, 12);
            this.filterGroup.Name = "filterGroup";
            this.filterGroup.Size = new System.Drawing.Size(187, 93);
            this.filterGroup.TabIndex = 4;
            this.filterGroup.TabStop = false;
            this.filterGroup.Text = "Filters";
            // 
            // macTextbox
            // 
            this.macTextbox.Enabled = false;
            this.macTextbox.Location = new System.Drawing.Point(81, 43);
            this.macTextbox.Name = "macTextbox";
            this.macTextbox.Size = new System.Drawing.Size(100, 20);
            this.macTextbox.TabIndex = 3;
            this.macTextbox.Text = "00:00:00:00:00:00";
            // 
            // debuggerRadioButton
            // 
            this.debuggerRadioButton.AutoSize = true;
            this.debuggerRadioButton.Location = new System.Drawing.Point(7, 68);
            this.debuggerRadioButton.Name = "debuggerRadioButton";
            this.debuggerRadioButton.Size = new System.Drawing.Size(72, 17);
            this.debuggerRadioButton.TabIndex = 2;
            this.debuggerRadioButton.Text = "Debugger";
            this.debuggerRadioButton.UseVisualStyleBackColor = true;
            this.debuggerRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // macRadioButton
            // 
            this.macRadioButton.AutoSize = true;
            this.macRadioButton.Location = new System.Drawing.Point(7, 44);
            this.macRadioButton.Name = "macRadioButton";
            this.macRadioButton.Size = new System.Drawing.Size(48, 17);
            this.macRadioButton.TabIndex = 1;
            this.macRadioButton.Text = "MAC";
            this.macRadioButton.UseVisualStyleBackColor = true;
            this.macRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // handleRadioButton
            // 
            this.handleRadioButton.AutoSize = true;
            this.handleRadioButton.Checked = true;
            this.handleRadioButton.Location = new System.Drawing.Point(7, 20);
            this.handleRadioButton.Name = "handleRadioButton";
            this.handleRadioButton.Size = new System.Drawing.Size(59, 17);
            this.handleRadioButton.TabIndex = 0;
            this.handleRadioButton.TabStop = true;
            this.handleRadioButton.Text = "Handle";
            this.handleRadioButton.UseVisualStyleBackColor = true;
            this.handleRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown);
            this.groupBox1.Controls.Add(this.loggingButton);
            this.groupBox1.Controls.Add(this.refreshLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 93);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(108, 47);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown.TabIndex = 6;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // LogParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.filterGroup);
            this.Controls.Add(this.loggingTextbox);
            this.Name = "LogParser";
            this.Text = "RPJ Log Parser";
            this.filterGroup.ResumeLayout(false);
            this.filterGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loggingTextbox;
        private System.Windows.Forms.Button loggingButton;
        private System.Windows.Forms.TextBox handleTextbox;
        private System.Windows.Forms.Label refreshLabel;
        private System.Windows.Forms.GroupBox filterGroup;
        private System.Windows.Forms.RadioButton debuggerRadioButton;
        private System.Windows.Forms.RadioButton macRadioButton;
        private System.Windows.Forms.RadioButton handleRadioButton;
        private System.Windows.Forms.TextBox macTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown;

    }
}

