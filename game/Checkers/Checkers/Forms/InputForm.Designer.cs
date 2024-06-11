namespace Checkers.Forms
{
    partial class InputForm
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
            this.FirstPlayerLabel = new System.Windows.Forms.Label();
            this.FirstPlayerTextBox = new System.Windows.Forms.TextBox();
            this.SecondPlayerTextBox = new System.Windows.Forms.TextBox();
            this.SecondPlayerLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstPlayerLabel
            // 
            this.FirstPlayerLabel.AutoSize = true;
            this.FirstPlayerLabel.Location = new System.Drawing.Point(29, 45);
            this.FirstPlayerLabel.Name = "FirstPlayerLabel";
            this.FirstPlayerLabel.Size = new System.Drawing.Size(138, 16);
            this.FirstPlayerLabel.TabIndex = 0;
            this.FirstPlayerLabel.Text = "Имя первого игрока";
            // 
            // FirstPlayerTextBox
            // 
            this.FirstPlayerTextBox.Location = new System.Drawing.Point(32, 78);
            this.FirstPlayerTextBox.Name = "FirstPlayerTextBox";
            this.FirstPlayerTextBox.Size = new System.Drawing.Size(186, 22);
            this.FirstPlayerTextBox.TabIndex = 1;
            // 
            // SecondPlayerTextBox
            // 
            this.SecondPlayerTextBox.Location = new System.Drawing.Point(32, 161);
            this.SecondPlayerTextBox.Name = "SecondPlayerTextBox";
            this.SecondPlayerTextBox.Size = new System.Drawing.Size(186, 22);
            this.SecondPlayerTextBox.TabIndex = 3;
            // 
            // SecondPlayerLabel
            // 
            this.SecondPlayerLabel.AutoSize = true;
            this.SecondPlayerLabel.Location = new System.Drawing.Point(29, 130);
            this.SecondPlayerLabel.Name = "SecondPlayerLabel";
            this.SecondPlayerLabel.Size = new System.Drawing.Size(137, 16);
            this.SecondPlayerLabel.TabIndex = 2;
            this.SecondPlayerLabel.Text = "Имя второго игрока";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 276);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SecondPlayerTextBox);
            this.Controls.Add(this.SecondPlayerLabel);
            this.Controls.Add(this.FirstPlayerTextBox);
            this.Controls.Add(this.FirstPlayerLabel);
            this.Name = "InputForm";
            this.Text = "Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstPlayerLabel;
        private System.Windows.Forms.TextBox FirstPlayerTextBox;
        private System.Windows.Forms.TextBox SecondPlayerTextBox;
        private System.Windows.Forms.Label SecondPlayerLabel;
        private System.Windows.Forms.Button button1;
    }
}