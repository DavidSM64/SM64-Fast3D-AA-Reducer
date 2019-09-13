namespace Fast3D_Overwriter
{
    partial class MainForm
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
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.LabelLoadROM = new System.Windows.Forms.Label();
            this.romPathTextBox = new System.Windows.Forms.TextBox();
            this.labelStatusText = new System.Windows.Forms.Label();
            this.buttonReduce = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(531, 9);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // LabelLoadROM
            // 
            this.LabelLoadROM.AutoSize = true;
            this.LabelLoadROM.Location = new System.Drawing.Point(12, 11);
            this.LabelLoadROM.Name = "LabelLoadROM";
            this.LabelLoadROM.Size = new System.Drawing.Size(80, 17);
            this.LabelLoadROM.TabIndex = 1;
            this.LabelLoadROM.Text = "Load ROM:";
            // 
            // romPathTextBox
            // 
            this.romPathTextBox.Location = new System.Drawing.Point(99, 9);
            this.romPathTextBox.Name = "romPathTextBox";
            this.romPathTextBox.ReadOnly = true;
            this.romPathTextBox.Size = new System.Drawing.Size(425, 22);
            this.romPathTextBox.TabIndex = 2;
            this.romPathTextBox.TabStop = false;
            // 
            // labelStatusText
            // 
            this.labelStatusText.Location = new System.Drawing.Point(0, 36);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(617, 23);
            this.labelStatusText.TabIndex = 3;
            this.labelStatusText.Text = "Status: No ROM loaded.";
            this.labelStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonReduce
            // 
            this.buttonReduce.Location = new System.Drawing.Point(214, 66);
            this.buttonReduce.Name = "buttonReduce";
            this.buttonReduce.Size = new System.Drawing.Size(188, 35);
            this.buttonReduce.TabIndex = 4;
            this.buttonReduce.Text = "Reduce the AA!";
            this.buttonReduce.UseVisualStyleBackColor = true;
            this.buttonReduce.Click += new System.EventHandler(this.buttonReduce_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 108);
            this.Controls.Add(this.buttonReduce);
            this.Controls.Add(this.labelStatusText);
            this.Controls.Add(this.romPathTextBox);
            this.Controls.Add(this.LabelLoadROM);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SM64 Fast3D Anti-Aliasing Reducer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label LabelLoadROM;
        private System.Windows.Forms.TextBox romPathTextBox;
        private System.Windows.Forms.Label labelStatusText;
        private System.Windows.Forms.Button buttonReduce;
    }
}

