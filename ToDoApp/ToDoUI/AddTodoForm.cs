using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoUI
{
    public partial class AddTodoForm : Form
    {
        private ITodoService _todoService;
        MainForm _mainForm;
        public AddTodoForm(MainForm mainForm)
        {
            InitializeComponent();
            _todoService = new TodoManager(new SQLiteTodoDal());
            _mainForm = mainForm;

        }

        private void btnAddTodo_Click(object sender, EventArgs e)
        {
            int groupBoxCountInForm = _mainForm.Controls.OfType<GroupBox>().Count();
            if(groupBoxCountInForm >= 16)
            {
                MessageBox.Show("Şu anda en fazla 16 adet not ekleyebilirsiniz. İlerleyen sürümlerde bu kısım geliştirilecektir.");
            }
            else
            {
                //Create Todo Object
                Todo todo = new Todo
                {
                    TodoTitle = tbxTodoTitle.Text,
                    TodoText = rtbxTodoText.Text,
                    TodoIsDoneInfo = 0
                };
                _todoService.Add(todo);
                _mainForm.DeleteUI();
            }
           
        }

        private void AddTodoForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimumSize = this.MaximumSize = this.Size;
            this.MaximizeBox = false;
        }
    }
}
