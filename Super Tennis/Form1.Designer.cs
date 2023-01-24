namespace Super_Tennis
{
    partial class SuperTennis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperTennis));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.playButton = new System.Windows.Forms.Button();
            this.maxPoints = new System.Windows.Forms.Label();
            this.pointsInput = new System.Windows.Forms.TextBox();
            this.playAgainButton = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.White;
            this.playButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Bauhaus 93", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.Lime;
            this.playButton.Location = new System.Drawing.Point(315, 306);
            this.playButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(150, 70);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "PLAY";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SuperTennis_KeyDown);
            this.playButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SuperTennis_KeyUp);
            // 
            // maxPoints
            // 
            this.maxPoints.BackColor = System.Drawing.Color.White;
            this.maxPoints.ForeColor = System.Drawing.Color.Lime;
            this.maxPoints.Location = new System.Drawing.Point(476, 297);
            this.maxPoints.Name = "maxPoints";
            this.maxPoints.Size = new System.Drawing.Size(154, 79);
            this.maxPoints.TabIndex = 1;
            this.maxPoints.Text = "Max Points:";
            // 
            // pointsInput
            // 
            this.pointsInput.Location = new System.Drawing.Point(476, 329);
            this.pointsInput.Name = "pointsInput";
            this.pointsInput.Size = new System.Drawing.Size(154, 47);
            this.pointsInput.TabIndex = 2;
            this.pointsInput.Text = "5";
            this.pointsInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playAgainButton
            // 
            this.playAgainButton.BackColor = System.Drawing.Color.White;
            this.playAgainButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playAgainButton.Enabled = false;
            this.playAgainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playAgainButton.Font = new System.Drawing.Font("Bauhaus 93", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgainButton.ForeColor = System.Drawing.Color.Lime;
            this.playAgainButton.Location = new System.Drawing.Point(215, 306);
            this.playAgainButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(150, 70);
            this.playAgainButton.TabIndex = 3;
            this.playAgainButton.Text = "PLAY\r\nAGAIN";
            this.playAgainButton.UseVisualStyleBackColor = false;
            this.playAgainButton.Visible = false;
            this.playAgainButton.Click += new System.EventHandler(this.playAgainButton_Click);
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.White;
            this.menuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuButton.Enabled = false;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Font = new System.Drawing.Font("Bauhaus 93", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.Color.Blue;
            this.menuButton.Location = new System.Drawing.Point(415, 306);
            this.menuButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(150, 70);
            this.menuButton.TabIndex = 4;
            this.menuButton.Text = "MAIN MENU";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Visible = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // SuperTennis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.pointsInput);
            this.Controls.Add(this.maxPoints);
            this.Controls.Add(this.playButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Bauhaus 93", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "SuperTennis";
            this.Text = "Super Tennis";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SuperTennis_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SuperTennis_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SuperTennis_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label maxPoints;
        private System.Windows.Forms.TextBox pointsInput;
        private System.Windows.Forms.Button playAgainButton;
        private System.Windows.Forms.Button menuButton;
    }
}

