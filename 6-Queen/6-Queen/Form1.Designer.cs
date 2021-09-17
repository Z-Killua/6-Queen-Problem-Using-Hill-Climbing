
namespace _6_Queen
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
            this.board = new System.Windows.Forms.PictureBox();
            this.reset = new System.Windows.Forms.Button();
            this.attackingPairs = new System.Windows.Forms.Label();
            this.Move = new System.Windows.Forms.Button();
            this.Solve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.White;
            this.board.Location = new System.Drawing.Point(12, 44);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(180, 180);
            this.board.TabIndex = 0;
            this.board.TabStop = false;
            this.board.Click += new System.EventHandler(this.board_Click);
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.board_Paint);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(198, 44);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 1;
            this.reset.Text = "RESET";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // attackingPairs
            // 
            this.attackingPairs.AutoSize = true;
            this.attackingPairs.ForeColor = System.Drawing.Color.White;
            this.attackingPairs.Location = new System.Drawing.Point(12, 17);
            this.attackingPairs.Name = "attackingPairs";
            this.attackingPairs.Size = new System.Drawing.Size(74, 13);
            this.attackingPairs.TabIndex = 2;
            this.attackingPairs.Text = "attackingPairs";
            this.attackingPairs.Click += new System.EventHandler(this.attackingPairs_Click);
            // 
            // Move
            // 
            this.Move.Location = new System.Drawing.Point(198, 102);
            this.Move.Name = "Move";
            this.Move.Size = new System.Drawing.Size(75, 23);
            this.Move.TabIndex = 3;
            this.Move.Text = "MOVE";
            this.Move.UseVisualStyleBackColor = true;
            this.Move.Click += new System.EventHandler(this.Move_Click);
            // 
            // Solve
            // 
            this.Solve.Location = new System.Drawing.Point(198, 73);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(75, 23);
            this.Solve.TabIndex = 4;
            this.Solve.Text = "SOLVE";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.Solve_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(277, 236);
            this.Controls.Add(this.Solve);
            this.Controls.Add(this.Move);
            this.Controls.Add(this.attackingPairs);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.board);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox board;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label attackingPairs;
        private System.Windows.Forms.Button Move;
        private System.Windows.Forms.Button Solve;
    }
}

