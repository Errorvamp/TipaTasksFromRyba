using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDataSourcesWizard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void personBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.personBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.forlabaDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "forlabaDataSet.Question". При необходимости она может быть перемещена или удалена.
            this.questionTableAdapter.Fill(this.forlabaDataSet.Question);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "forlabaDataSet.Question". При необходимости она может быть перемещена или удалена.
            this.questionTableAdapter.Fill(this.forlabaDataSet.Question);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "forlabaDataSet.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.forlabaDataSet.Person);

        }
    }
}
