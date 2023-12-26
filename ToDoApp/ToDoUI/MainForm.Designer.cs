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
            btnAdd = new Button();
            dgwDatas = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgwDatas).BeginInit();
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
            // dgwDatas
            // 
            dgwDatas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwDatas.Location = new Point(732, 540);
            dgwDatas.Name = "dgwDatas";
            dgwDatas.RowHeadersWidth = 51;
            dgwDatas.RowTemplate.Height = 29;
            dgwDatas.Size = new Size(523, 188);
            dgwDatas.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(1161, 505);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightYellow;
            ClientSize = new Size(1267, 740);
            Controls.Add(button1);
            Controls.Add(dgwDatas);
            Controls.Add(btnAdd);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Todo App";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgwDatas).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAdd;
        private DataGridView dgwDatas;
        private Button button1;
    }
}