namespace ToDoUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnAdd = new Button();
            lblDeniz = new LinkLabel();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.GreenYellow;
            btnAdd.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(579, 669);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 59);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblDeniz
            // 
            lblDeniz.AutoSize = true;
            lblDeniz.Location = new Point(12, 711);
            lblDeniz.Name = "lblDeniz";
            lblDeniz.Size = new Size(161, 20);
            lblDeniz.TabIndex = 2;
            lblDeniz.TabStop = true;
            lblDeniz.Text = "www.denizvarici.com.tr";
            lblDeniz.VisitedLinkColor = Color.Blue;
            lblDeniz.LinkClicked += lblDeniz_LinkClicked;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightYellow;
            ClientSize = new Size(1267, 740);
            Controls.Add(lblDeniz);
            Controls.Add(btnAdd);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TODO App";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAdd;
        private LinkLabel lblDeniz;
    }
}