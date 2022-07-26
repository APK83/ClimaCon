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
    public partial class AddToPreset : Form


    {
        public PresetLoader presetLoader = new PresetLoader();
        public AddToPreset()
        {
            InitializeComponent();
        }

        public string SelectedName { get { return txtPresetName.Text; } }
        
        private void btnSaveToPresetCancel_Click(object sender, EventArgs e)
        {
            string message = "Вы уверены, что хотите отменить создание режима?";
            string caption = "Отмена создания режима";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSaveToPreset_Click(object sender, EventArgs e)
        {
            if (txtPresetName.Text != "")
            { 
            string message = "Вы уверены, что хотите сохранить новый режим?";
            string caption = "Подтверждение создания режима";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
            }
            this.Close();
            }
            else
            {
                string message = "Не указано название режима!";
                string caption = "Ошибка!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                               
            }
        }
    }
}
