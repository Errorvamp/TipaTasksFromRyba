using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDataBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
private BindingSource sotrBindingSourse;
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "forlabaDataSet1.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.forlabaDataSet1.Person);
            // Загрузка таблицы данными:

            PersonTableAdapter.Fill(forlabaDataSet1.Person);

            // Создание BindingSource для таблицы Сотрудники:
            sotrBindingSourse = new
            BindingSource(forlabaDataSet1, "Сотрудники");
            // Настройка связывания для элементов TextBox:
            FamtextBox.DataBindings.Add("Text", sotrBindingSourse,
            "Фамилия_сотрудника");
            NametextBox.DataBindings.Add("Text",
            sotrBindingSourse, "Имя_сотрудника");
            SectiontextBox.DataBindings.Add("Text",
            sotrBindingSourse, "Отдел");


        }

        private void Previousbutton_Click(object sender, EventArgs e)
        {
            sotrBindingSourse.MovePrevious();
        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
            sotrBindingSourse.MoveNext();
        }
    }
}
