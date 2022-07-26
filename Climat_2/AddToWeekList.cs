using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Climat_2
{
    public partial class AddToWeekList : Form
    {
        public AddToWeekList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Извините. Эта функция находиться в стадии разработки. Уже очень скоро вы сможете ей воспользоваться.";
            string caption = "Упс...";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnExitToChart_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClearToChart_Click(object sender, EventArgs e)
        {
            string message = "Извините. Эта функция находиться в стадии разработки. Уже очень скоро вы сможете ей воспользоваться.";
            string caption = "Упс...";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
