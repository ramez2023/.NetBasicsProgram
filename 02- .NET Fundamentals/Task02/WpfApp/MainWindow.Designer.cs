namespace WpfApp
{
    partial class MainWindow
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
            this.titleLabal = new System.Windows.Forms.Label();
            this.nameLabal = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabal
            // 
            this.titleLabal.AutoSize = true;
            this.titleLabal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabal.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.titleLabal.Location = new System.Drawing.Point(68, 37);
            this.titleLabal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabal.Name = "titleLabal";
            this.titleLabal.Size = new System.Drawing.Size(222, 39);
            this.titleLabal.TabIndex = 0;
            this.titleLabal.Text = "Main Window";
            // 
            // nameLabal
            // 
            this.nameLabal.AutoSize = true;
            this.nameLabal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabal.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.nameLabal.Location = new System.Drawing.Point(68, 96);
            this.nameLabal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabal.Name = "nameLabal";
            this.nameLabal.Size = new System.Drawing.Size(117, 39);
            this.nameLabal.TabIndex = 1;
            this.nameLabal.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(189, 98);
            this.nameTextBox.MinimumSize = new System.Drawing.Size(4, 20);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(283, 38);
            this.nameTextBox.TabIndex = 2;
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.Color.YellowGreen;
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(189, 183);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(131, 47);
            this.doneButton.TabIndex = 3;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 253);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabal);
            this.Controls.Add(this.titleLabal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "MainWindow";
            this.Text = "Main Window";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabal;
        private System.Windows.Forms.Label nameLabal;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button doneButton;
    }
}

