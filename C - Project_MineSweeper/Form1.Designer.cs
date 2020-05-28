namespace C___Project_MineSweeper
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
            this.pictureBox_Canvas = new System.Windows.Forms.PictureBox();
            this.button_Reset = new System.Windows.Forms.Button();
            this.label_TotalMines = new System.Windows.Forms.Label();
            this.label_TotalFlagged = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Canvas
            // 
            this.pictureBox_Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Canvas.Location = new System.Drawing.Point(300, 191);
            this.pictureBox_Canvas.Name = "pictureBox_Canvas";
            this.pictureBox_Canvas.Size = new System.Drawing.Size(817, 788);
            this.pictureBox_Canvas.TabIndex = 0;
            this.pictureBox_Canvas.TabStop = false;
            this.pictureBox_Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Canvas_Paint);
            this.pictureBox_Canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Canvas_MouseClick);
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(300, 79);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(264, 88);
            this.button_Reset.TabIndex = 1;
            this.button_Reset.Text = "Reset";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // label_TotalMines
            // 
            this.label_TotalMines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_TotalMines.Location = new System.Drawing.Point(663, 79);
            this.label_TotalMines.Name = "label_TotalMines";
            this.label_TotalMines.Size = new System.Drawing.Size(183, 63);
            this.label_TotalMines.TabIndex = 2;
            // 
            // label_TotalFlagged
            // 
            this.label_TotalFlagged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_TotalFlagged.Location = new System.Drawing.Point(908, 79);
            this.label_TotalFlagged.Name = "label_TotalFlagged";
            this.label_TotalFlagged.Size = new System.Drawing.Size(176, 63);
            this.label_TotalFlagged.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Mines";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(903, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total Flagged";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 1096);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_TotalFlagged);
            this.Controls.Add(this.label_TotalMines);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.pictureBox_Canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Canvas;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Label label_TotalMines;
        private System.Windows.Forms.Label label_TotalFlagged;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

