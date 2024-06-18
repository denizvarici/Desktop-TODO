using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System.Diagnostics;

namespace ToDoUI
{
    public partial class MainForm : Form
    {
        private ITodoService _todoService;

        private int initialX = 10;
        private int initialY = 10;
        private int groupBoxWidth = 300;
        private int groupBoxHeight = 150;
        private int gapBetweenGroupBoxes = 10;
        private int groupBoxesPerRow = 4;

        private int richTextBoxWidth = 250;
        private int richTextBoxHeight = 70;
        public MainForm()
        {
            InitializeComponent();
            _todoService = new TodoManager(new SQLiteTodoDal());
            CreateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dgwTodos.DataSource = _todoService.GetAll();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimumSize = this.MaximumSize = this.Size;
            this.MaximizeBox = false;

            int groupBoxCount = this.Controls.OfType<GroupBox>().Count();
            if (groupBoxCount == 0)
            {
                MessageBox.Show("Merhabalar!\nUygulamama Hoþgeldiniz. Aþaðýdaki +'ya basarak yapacaðýnýz iþi unutmamak için not alabilir daha sonra o notu düzenleyebilir ve kaydettiðiniz nottaki iþinizi tamamladýysanýz tamamlandý olarak iþaretleyebilirsiniz! Uygulamam geliþtirilmeye devam edecektir. \n     Deniz Varýcý");
            }

        }

        public void CreateUI()
        {
            int currentX = initialX;
            int currentY = initialY;
            int groupBoxCount = 0;
            foreach (var todo in _todoService.GetAll())
            {
                // groupBox olusturuyorum
                GroupBox groupBox = new GroupBox();
                groupBox.Text = todo.TodoTitle;
                groupBox.Size = new System.Drawing.Size(groupBoxWidth, groupBoxHeight);
                groupBox.Location = new System.Drawing.Point(currentX, currentY);
                groupBox.Name = todo.Id.ToString();

                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Text = todo.TodoText;
                richTextBox.ReadOnly = true;
                richTextBox.Size = new System.Drawing.Size(richTextBoxWidth, richTextBoxHeight);
                richTextBox.Location = new System.Drawing.Point(10, 20);
                richTextBox.BackColor = Color.Cornsilk;
                richTextBox.Name = todo.Id.ToString();

                Button deleteButton = new Button();
                deleteButton.Text = "X";
                deleteButton.TextAlign = ContentAlignment.TopCenter;
                deleteButton.Size = new System.Drawing.Size(30, 30);
                deleteButton.Location = new System.Drawing.Point(270, 10);
                deleteButton.Click += DeleteButton_Click;
                deleteButton.BackColor = Color.Red;
                deleteButton.Name = todo.Id.ToString();

                Button editButton = new Button();
                editButton.Text = "Düzenle";
                editButton.TextAlign = ContentAlignment.MiddleCenter;
                editButton.Size = new System.Drawing.Size(80, 30);
                editButton.Location = new System.Drawing.Point(220, 120);
                editButton.Click += EditButton_Click;
                editButton.BackColor = Color.Aqua;
                editButton.Name = todo.Id.ToString();

                Label label = new Label();
                label.Text = "TAMAMLANDI!";
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Size = new System.Drawing.Size(120, 30);
                label.Location = new System.Drawing.Point(25, 120);
                label.BackColor = Color.White;
                label.Name = todo.Id.ToString();






                currentX += groupBoxWidth + gapBetweenGroupBoxes;
                groupBoxCount++;

                if (groupBoxCount % groupBoxesPerRow == 0)
                {
                    currentX = initialX;
                    currentY += groupBoxHeight + gapBetweenGroupBoxes;
                }

                if (todo.TodoIsDoneInfo == 1)
                {
                    groupBox.BackColor = Color.GreenYellow;
                    groupBox.Controls.Add(deleteButton);
                    groupBox.Controls.Add(richTextBox);
                    groupBox.Controls.Add(label);
                }
                else
                {
                    groupBox.Controls.Add(editButton);
                    groupBox.Controls.Add(deleteButton);
                    groupBox.Controls.Add(richTextBox);
                }

                this.Controls.Add(groupBox);
            }

        }

        public void DeleteUI()
        {
            //collection bozulmasýný önlemek için listeye atýyoruz.
            List<GroupBox> groupBoxesToDelete = new List<GroupBox>();
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    groupBoxesToDelete.Add(groupBox);
                }
            }
            foreach (var groupBoxToDelete in groupBoxesToDelete)
            {
                this.Controls.Remove(groupBoxToDelete);
                groupBoxToDelete.Dispose(); // Bellekten temizle
            }

            //DELETE edilecek obje halledildikten sonra yeniden ui create edilir.
            CreateUI();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            _todoService.Delete(Convert.ToInt32(clickedButton.Name));
            DeleteUI();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == null)
                return;
            GroupBox currentGroupBox = clickedButton.Parent as GroupBox;

            if (currentGroupBox == null)
                return;

            Button submitButton = new Button();
            submitButton.Text = "Kaydet";
            submitButton.TextAlign = ContentAlignment.TopCenter;
            submitButton.Size = new System.Drawing.Size(80, 30);
            submitButton.Location = new System.Drawing.Point(140, 120);
            submitButton.Click += SubmitChangesButton_Click;
            submitButton.BackColor = Color.GreenYellow;
            submitButton.Name = clickedButton.Name;


            CheckBox checkBox = new CheckBox();
            checkBox.Text = "Tamamlandý";
            checkBox.Size = new System.Drawing.Size(120, 20);
            checkBox.Location = new System.Drawing.Point(10, 120);
            checkBox.Name = clickedButton.Name;


            currentGroupBox.Controls.Add(checkBox);
            currentGroupBox.Controls.Add(submitButton);


            clickedButton.Enabled = false;
            clickedButton.BackColor = Color.Gray;


            foreach (Control control in currentGroupBox.Controls)
            {
                if (control is RichTextBox richTextBox)
                {
                    richTextBox.ReadOnly = false;
                    richTextBox.BackColor = Color.White;
                    break;
                }
            }

        }
        private void SubmitChangesButton_Click(object sender, EventArgs e)
        {
            string todoTitle;
            string todoText;
            int todoIsDoneInfo;


            Button clickedButton = sender as Button;
            if (clickedButton == null)
                return;
            GroupBox currentGroupBox = clickedButton.Parent as GroupBox;

            if (currentGroupBox == null)
                return;

            todoTitle = currentGroupBox.Text;
            todoText = currentGroupBox.Controls.OfType<RichTextBox>().FirstOrDefault().Text;
            todoIsDoneInfo = Convert.ToInt32(currentGroupBox.Controls.OfType<CheckBox>().FirstOrDefault().Checked);
            currentGroupBox.Controls.OfType<RichTextBox>().FirstOrDefault().ReadOnly = true;
            currentGroupBox.Controls.OfType<RichTextBox>().FirstOrDefault().BackColor = Color.Cornsilk;



            Todo todo = new Todo
            {
                Id = Convert.ToInt32(clickedButton.Name),
                TodoTitle = todoTitle,
                TodoText = todoText,
                TodoIsDoneInfo = todoIsDoneInfo
            };
            _todoService.Update(todo);

            foreach (Control control2 in currentGroupBox.Controls)
            {
                if (control2 is Button editButton)
                {
                    if (todoIsDoneInfo == 1)
                    {
                        Label label = new Label();
                        label.Text = "TAMAMLANDI!";
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        label.Size = new System.Drawing.Size(120, 30);
                        label.Location = new System.Drawing.Point(25, 120);
                        label.BackColor = Color.White;
                        label.Name = todo.Id.ToString();
                        currentGroupBox.Controls.Add(label);
                        currentGroupBox.Controls.Remove(editButton);
                        currentGroupBox.Controls.Remove(clickedButton);
                        currentGroupBox.Controls.Remove(currentGroupBox.Controls.OfType<CheckBox>().FirstOrDefault());
                        currentGroupBox.BackColor = Color.GreenYellow;
                        break;
                    }
                    else
                    {
                        editButton.Enabled = true;
                        editButton.BackColor = Color.Aqua;
                        currentGroupBox.Controls.Remove(clickedButton);
                        currentGroupBox.Controls.Remove(currentGroupBox.Controls.OfType<CheckBox>().FirstOrDefault());
                        break;
                    }

                }
            }

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTodoForm addTodoForm = new AddTodoForm(this);
            addTodoForm.Show();
        }

        private void lblDeniz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.denizvarici.com.tr";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }



}

