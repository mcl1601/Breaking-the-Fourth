namespace Tool
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
            this.PlayerLabel = new System.Windows.Forms.Label();
            this.PlayerBox = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BulletBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GravityBox = new System.Windows.Forms.TextBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.PlayerLabel.Location = new System.Drawing.Point(116, 164);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(143, 26);
            this.PlayerLabel.TabIndex = 1;
            this.PlayerLabel.Text = "Player Speed";
            // 
            // PlayerBox
            // 
            this.PlayerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.PlayerBox.Location = new System.Drawing.Point(354, 164);
            this.PlayerBox.Name = "PlayerBox";
            this.PlayerBox.Size = new System.Drawing.Size(100, 32);
            this.PlayerBox.TabIndex = 2;
            this.PlayerBox.TextChanged += new System.EventHandler(this.PlayerBox_TextChanged);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(121, 41);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(343, 33);
            this.Title.TabIndex = 3;
            this.Title.Text = "Welcome to Speed Changer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bullet Speed";
            // 
            // BulletBox
            // 
            this.BulletBox.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BulletBox.Location = new System.Drawing.Point(354, 240);
            this.BulletBox.Name = "BulletBox";
            this.BulletBox.Size = new System.Drawing.Size(100, 33);
            this.BulletBox.TabIndex = 5;
            this.BulletBox.TextChanged += new System.EventHandler(this.BulletBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Gravity";
            // 
            // GravityBox
            // 
            this.GravityBox.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GravityBox.Location = new System.Drawing.Point(354, 314);
            this.GravityBox.Name = "GravityBox";
            this.GravityBox.Size = new System.Drawing.Size(100, 33);
            this.GravityBox.TabIndex = 7;
            this.GravityBox.TextChanged += new System.EventHandler(this.GravityBox_TextChanged);
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.Location = new System.Drawing.Point(214, 394);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(135, 46);
            this.DoneButton.TabIndex = 8;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(583, 485);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.GravityBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BulletBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.PlayerBox);
            this.Controls.Add(this.PlayerLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label PlayerLabel;
        private System.Windows.Forms.TextBox PlayerBox;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BulletBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GravityBox;
        private System.Windows.Forms.Button DoneButton;
    }
}

