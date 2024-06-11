using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers.Forms
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name1 = FirstPlayerTextBox.Text;
            var name2 = SecondPlayerTextBox.Text;

            MainForm mainForm = new MainForm(name1, name2);
            mainForm.Show();
            mainForm.FormClosed += (s, args) => this.Close(); // Закрываем текущую форму после закрытия новой
            this.Hide();
        }
    }
}
