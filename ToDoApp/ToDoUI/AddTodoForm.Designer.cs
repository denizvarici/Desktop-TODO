namespace ToDoUI
{
    partial class AddTodoForm
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
            label1 = new Label();
            tbxTodoTitle = new TextBox();
            label2 = new Label();
            rtbxTodoText = new RichTextBox();
            btnAddTodo = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Başlık : ";
            // 
            // tbxTodoTitle
            // 
            tbxTodoTitle.BackColor = Color.Cornsilk;
            tbxTodoTitle.Location = new Point(68, 12);
            tbxTodoTitle.Name = "tbxTodoTitle";
            tbxTodoTitle.Size = new Size(162, 27);
            tbxTodoTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 2;
            label2.Text = "Detay";
            // 
            // rtbxTodoText
            // 
            rtbxTodoText.BackColor = Color.Cornsilk;
            rtbxTodoText.Location = new Point(12, 76);
            rtbxTodoText.Name = "rtbxTodoText";
            rtbxTodoText.Size = new Size(450, 99);
            rtbxTodoText.TabIndex = 3;
            rtbxTodoText.Text = "";
            // 
            // btnAddTodo
            // 
            btnAddTodo.BackColor = Color.GreenYellow;
            btnAddTodo.Location = new Point(368, 181);
            btnAddTodo.Name = "btnAddTodo";
            btnAddTodo.Size = new Size(94, 29);
            btnAddTodo.TabIndex = 4;
            btnAddTodo.Text = "Ekle";
            btnAddTodo.UseVisualStyleBackColor = false;
            btnAddTodo.Click += btnAddTodo_Click;
            // 
            // AddTodoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightYellow;
            ClientSize = new Size(474, 230);
            Controls.Add(btnAddTodo);
            Controls.Add(rtbxTodoText);
            Controls.Add(label2);
            Controls.Add(tbxTodoTitle);
            Controls.Add(label1);
            Name = "AddTodoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Görev Ekle";
            Load += AddTodoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbxTodoTitle;
        private Label label2;
        private RichTextBox rtbxTodoText;
        private Button btnAddTodo;
    }
}