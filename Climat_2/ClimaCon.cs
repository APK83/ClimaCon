using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Climat_2
{
    public partial class ClimaCon : Form
    {
        Parameter indoorTemperature = new Parameter();
        Parameter humidity = new Parameter();
        Parameter rpm = new Parameter();
        Conditioner conditioner;
        Heater heater;
        Humidifier humidifier;
        Ventilation ventilation;
        static Random rnd = new Random();
        public PresetLoader presetLoader = new PresetLoader();
        Timer timer;
        int outdoorTemperature;

        public ClimaCon()
        {
            conditioner = new Conditioner(indoorTemperature, humidity);
            heater = new Heater(indoorTemperature);
            humidifier = new Humidifier(humidity);
            ventilation = new Ventilation(rpm, indoorTemperature, humidity);
            InitializeComponent();
            presetLoader.LoadConfig();
            txtTemperatureOutdoor.ReadOnly = true;
            txtTemperatureIndoor.ReadOnly = true;
            txtHumidityInfo.ReadOnly = true;
            txtFanRPM.ReadOnly = true;
            textPresetActiveInfo.ReadOnly = true;
            cbxVentilationPreset.Enabled = false;
            txtTemperatureOutdoor.Clear();
            txtTemperatureIndoor.Clear();
            txtHumidityInfo.Clear();
            txtFanRPM.Clear();
            textPresetActiveInfo.Clear();
            txtTemperatureOutdoor.Enabled = false;
            txtTemperatureIndoor.Enabled = false;
            txtHumidityInfo.Enabled = false;
            txtFanRPM.Enabled = false;
            textPresetActiveInfo.Enabled = false;
            cbxAutoPreset.Enabled = false;
            cbxChartSwitcher.Enabled = false;
            cbxHumidityAuto.Enabled = false;
            cbxTemperatureAuto.Enabled = false;
            btnlApplySettings.Enabled = false;
            numVentilationManual.Enabled = false;
            numHumidityManual.Enabled = false;
            numTemperatureManual.Enabled = false;
            cbxTemperatureAuto.Enabled = false;
            cbxHumidityAuto.Enabled = false;
            режимToolStripMenuItem.Enabled = false;
            btnAddPreset.Enabled = false;
            btnEditPreset.Enabled = false;
            btnDeletePreset.Enabled = false;
            btnAddToChart.Enabled = false;
            cbxChartSwitcher.Text = "Off";
            labUnitStatusT.Text = "Регулировка температуры: Откл.";
            labUnitStatusH.Text = "Регулировка влажности: Откл.";
            lblDateTime.Text = DateTime.Now.ToString("dd.mm.yyyy  HH:mm:ss", CultureInfo.CreateSpecificCulture("ru"));
            cbxAutoPreset.DataSource = presetLoader.Presets.Keys.ToList();
            cbxAutoPreset.SelectedValueChanged += CbxAutoPreset_SelectedValueChanged;
            if (cbxVentilationPreset.Text == "Manual")
            {
                numVentilationManual.Enabled = true;
            }
            if (cbxVentilationPreset.Text == "Off")
            {
                numVentilationManual.Enabled = false;
            }

        }
        private void startApp()//Запуск климатической установки и загрузка данных с датчиков
        {
            outdoorTemperature = rnd.Next(-37, 48);
            txtTemperatureOutdoor.Text = outdoorTemperature.ToString();
            indoorTemperature.SetValue(rnd.Next(10, 48));
            txtTemperatureIndoor.Text = indoorTemperature.value.ToString();
            humidity.SetValue(rnd.Next(20, 80));
            txtHumidityInfo.Text = humidity.value.ToString();
            numVentilationManual.Value = 0;
            txtFanRPM.Text = numVentilationManual.Text;
            if (cbxAutoPreset.Text == null || cbxAutoPreset.Text == "Off")
            {
                textPresetActiveInfo.Text = "Manual";
            }
            else
            {
                textPresetActiveInfo.Text = cbxAutoPreset.Text;
            }
            cbxAutoPreset.Enabled = true;
            cbxChartSwitcher.Enabled = true;
            cbxVentilationPreset.Enabled = true;
            cbxHumidityAuto.Enabled = true;
            cbxTemperatureAuto.Enabled = true;
            btnClimatOff.Enabled = true;
            btnClimatOn.Enabled = false;
            btnlApplySettings.Enabled = true;
            numVentilationManual.Enabled = true;
            numHumidityManual.Enabled = true;
            numTemperatureManual.Enabled = true;
            cbxVentilationPreset.Text = "Off";
            cbxTemperatureAuto.Enabled = true;
            cbxHumidityAuto.Enabled = true;
            режимToolStripMenuItem.Enabled = true;
            btnAddPreset.Enabled = true;
            btnEditPreset.Enabled = true;
            btnDeletePreset.Enabled = true;
            btnAddToChart.Enabled = true;
        }
        private void stopApp()//Остановка климатической установки, сброс показаний датчиков
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
            cbxAutoPreset.Text = "Off";
            txtTemperatureOutdoor.Clear();
            txtTemperatureIndoor.Clear();
            txtHumidityInfo.Clear();
            txtFanRPM.Clear();
            textPresetActiveInfo.Clear();
            txtTemperatureOutdoor.Enabled = false;
            txtTemperatureIndoor.Enabled = false;
            txtHumidityInfo.Enabled = false;
            txtFanRPM.Enabled = false;
            textPresetActiveInfo.Enabled = false;
            cbxAutoPreset.Enabled = false;
            cbxChartSwitcher.Enabled = false;
            cbxVentilationPreset.Enabled = false;
            cbxHumidityAuto.Enabled = false;
            cbxTemperatureAuto.Enabled = false;
            btnClimatOff.Enabled = false;
            btnClimatOn.Enabled = true;
            btnlApplySettings.Enabled = false;
            numVentilationManual.Enabled = false;
            numTemperatureManual.Enabled = false;
            numHumidityManual.Enabled = false;
            режимToolStripMenuItem.Enabled = false;
            btnAddPreset.Enabled = false;
            btnEditPreset.Enabled = false;
            btnDeletePreset.Enabled = false;
            btnAddToChart.Enabled = false;
            cbxTemperatureAuto.Checked = false;
            cbxHumidityAuto.Checked = false;
            labUnitStatusT.Text = "Регулировка температуры: Откл.";
            labUnitStatusH.Text = "Регулировка влажности: Откл.";


        }
        
        private void setValues()//Применение параметров и отображение.
        {
            int cp1 = indoorTemperature.value; //текущая температура
            int np1 = Convert.ToInt32(numTemperatureManual.Text);//новая температура
            int cp2 = humidity.value;//текущая влажность
            int np2 = Convert.ToInt32(numHumidityManual.Text);//новая влажность

            txtFanRPM.Text = (100 * rpm.value).ToString();
            txtTemperatureIndoor.Text = indoorTemperature.value.ToString();
            txtHumidityInfo.Text = humidity.value.ToString();
            labUnitStatusT.Text = "Поддержание температуры";
            labUnitStatusH.Text = "Поддержание влажности";
            if (outdoorTemperature >= -5 && cp1 > np1)
            {
                labUnitStatusT.Text = "Включен кондиционер: Охлаждение";
            }
            if (outdoorTemperature >= -5 && cp1 < np1)
            {
                labUnitStatusT.Text = "Включен кондиционер: Обогрев";
            }
            if (outdoorTemperature >= -5 && cp2 > np2)
            {
                labUnitStatusH.Text = "Включен кондиционер: Осушение";
            }
            if (cp2 < np2)
            {
                labUnitStatusH.Text = "Включен увлажнитель";
            }
            if (outdoorTemperature < -5 && cp1 > np1)
            {
                labUnitStatusT.Text = "Включена приточная вентиляция";
            }
            if (outdoorTemperature < -5 && cp1 < np1)
            {
                labUnitStatusT.Text = "Включен обогреватель";
            }
            if (outdoorTemperature < -5 && cp2 > np2)
            {
                labUnitStatusH.Text = "Включена отточная вентиляция";
            }
        }
        private void presetFan()
        {
            if (cbxVentilationPreset.Text == "Low")
            {
                numVentilationManual.Value = presetLoader.FanLow;
            }
            if (cbxVentilationPreset.Text == "Medium")
            {
                numVentilationManual.Value = presetLoader.FanMedium;
            }
            if (cbxVentilationPreset.Text == "High")
            {
                numVentilationManual.Value = presetLoader.FanHigh;
            }

        }
        private void applySettings()
        {
            int to = Convert.ToInt32(txtTemperatureOutdoor.Text);
            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = 100;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            try
            {
                //читаем заданные значения
                int np1 = Convert.ToInt32(numTemperatureManual.Text);//новая температура
                int np2 = Convert.ToInt32(numHumidityManual.Text);//новая влажность
                int np3 = Convert.ToInt32(numVentilationManual.Text);//новые обороты вентилятора
                Task pt1 = new Task(() => conditioner.ChangeTemperature(np1));// меняем параметры у кондиционера в двух разных потоках
                Task pt2 = new Task(() => conditioner.ChangeHumidity(np2));//передаем новое значение влажности
                Task pt3 = new Task(() => ventilation.ChangeVentilation(np3));//передаем новое значение оборотов вентилятора
                Task pt4 = new Task(() => heater.ChangeTemperature(np1));
                Task pt5 = new Task(() => humidifier.ChangeHumidity(np2));

                pt1.Start();
                pt2.Start();
                pt3.Start();
                pt4.Start();
                pt5.Start();
                if (cbxAutoPreset.Text == null || cbxAutoPreset.Text == "Off")
                {
                    textPresetActiveInfo.Text = "Manual";
                }
                else
                {
                    textPresetActiveInfo.Text = cbxAutoPreset.Text;
                }
                if (cbxAutoPreset.Text != "Off")
                {
                   MessageBox.Show("Автоматический режим включен!");
                }
                if (cbxAutoPreset.Text == "Off")
                {
                    cbxVentilationPreset.Enabled = true;
                    numHumidityManual.Enabled = true;
                    numTemperatureManual.Enabled = true;
                    MessageBox.Show("Ручной режим включен!");
                }

            }

            catch (FormatException)
            {
                MessageBox.Show("Не правильно заданы параметры");
            }
        }
        private void autoTemperature()
        {
            if (cbxTemperatureAuto.Checked)
            {
                numTemperatureManual.Value = presetLoader.AutoTemperature;
                numTemperatureManual.Enabled = false;
            }
            else
            {
                numTemperatureManual.Enabled = true;
            }
        }
        private void autoHumidity()
        {
            if (cbxHumidityAuto.Checked)
            {
                numHumidityManual.Value = presetLoader.AutoHumidity;
                numHumidityManual.Enabled = false;
            }
            else
            {
                numHumidityManual.Enabled = true;
            }
        }
        private void presetSelect()
        {
            string currentPresetName = cbxAutoPreset.SelectedValue.ToString();
            if (currentPresetName != "Off")
            {
                Preset preset = presetLoader.Presets[currentPresetName];
                numTemperatureManual.Value = preset.Temperature;
                numHumidityManual.Value = preset.Humidity;
                numVentilationManual.Value = preset.Ventilation;
                cbxTemperatureAuto.Checked = false;
                cbxHumidityAuto.Checked = false;
                cbxVentilationPreset.Text = "Auto";
            }
        }
        private void presetAdd()
        {
            var p_name = new AddToPreset();
            if (p_name.ShowDialog() == DialogResult.Yes)
            {
                var preset = new Preset() {
                    System = false,
                    Temperature = Convert.ToInt32(numTemperatureManual.Value),
                    Humidity = Convert.ToInt32(numHumidityManual.Value),
                    Ventilation = Convert.ToInt32(numVentilationManual.Value)
                };
                presetLoader.Presets.Add(p_name.SelectedName, preset);
                cbxAutoPreset.DataSource = presetLoader.Presets.Keys.ToList();
                presetLoader.SaveConfig();
            }
        }
        private void presetEdit()
        {
            if (cbxAutoPreset.Text != "Off" && cbxAutoPreset.Text != "Auto" && cbxAutoPreset.Text != "Eco" &&
                cbxAutoPreset.Text != "Effective" && cbxAutoPreset.Text != "Night")
            {
                var ep_name = cbxAutoPreset.Text;
                string message = "Вы уверены, что хотите изменить настройки режима?";
                string caption = "Подтверждение изменений";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    var preset = new Preset() {
                        System = false,
                        Temperature = Convert.ToInt32(numTemperatureManual.Value),
                        Humidity = Convert.ToInt32(numHumidityManual.Value),
                        Ventilation = Convert.ToInt32(numVentilationManual.Value)
                    };
                    presetLoader.Presets[ep_name] = preset;
                    presetLoader.SaveConfig();
                }
            }
            else
            {
                string message = "Ошибка! Выберете пользовальский режим.";
                string caption = "Ошибка изменения";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        private void presetDelete()
        {
            if (cbxAutoPreset.Text != "Off" && cbxAutoPreset.Text != "Auto" && cbxAutoPreset.Text != "Eco" &&
                cbxAutoPreset.Text != "Effective" && cbxAutoPreset.Text != "Night")
            {

                string message = "Вы уверены, что хотите удалить этот режим?";
                string caption = "Подтверждение удаления";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    presetLoader.Presets.Remove(cbxAutoPreset.Text);
                    cbxAutoPreset.DataSource = presetLoader.Presets.Keys.ToList();
                }
            }
            else
            {

                string message = "Ошибка! Выберете пользовальский режим.";
                string caption = "Ошибка удаления";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        private void chartAdd()
        {
            var week_list = new AddToWeekList();
            if (week_list.ShowDialog() == DialogResult.OK)
            {
                Show();

            }
        }
        //Кнопки управления
        private void CbxAutoPreset_SelectedValueChanged(object sender, EventArgs e)//Выбор автоматических режимов
        {
            presetSelect();
        }

        private void btnAddToChart_Click(object sender, EventArgs e)//кнопка "Добавить график"
        {
            chartAdd();
        }
        
        private void btnClimatOn_Click(object sender, EventArgs e)//кнопка "Включить климатическую установку"
        {
            startApp();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            setValues();
        }



        private void btnClimatOff_Click(object sender, EventArgs e)//кнопка "Выключить климатическую установку"
        {
            stopApp();
        }

        private void btnAddPreset_Click(object sender, EventArgs e)//кнопка "Добавить режим"
        {
            presetAdd();
        }

        private void btnEditPreset_Click(object sender, EventArgs e)//Кнопка "Изменить режим"
        {
            presetEdit();
        }
        private void btnDeletePreset_Click(object sender, EventArgs e)
        {
            presetDelete();
        }
        private void btnlApplySettings_Click(object sender, EventArgs e)//кнопка "Применить"
        {
            applySettings();
        }

        private void cbxTemperatureAuto_CheckedChanged(object sender, EventArgs e)
        {
            autoTemperature();
        }

        private void cbxHumidityAuto_CheckedChanged(object sender, EventArgs e)
        {
            autoHumidity();
        }

        private void cbxVentilationPreset_SelectedValueChanged(object sender, EventArgs e)
        {
            presetFan();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startApp();
        }

        private void остановкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopApp();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presetDelete();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presetAdd();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presetEdit();
        }

        private void автоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxTemperatureAuto.Checked = true;
            numTemperatureManual.Enabled = false;
            cbxAutoPreset.Text = "Off";
        }

        private void автоToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cbxHumidityAuto.Checked = true;
            numHumidityManual.Enabled = false;
            cbxAutoPreset.Text = "Off";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var about = new About();
            if (about.ShowDialog() == DialogResult.OK)
            {
                Show();

            }
        }
        private void ручнойВводToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numTemperatureManual.Enabled = true;
            cbxAutoPreset.Text = "Off";
        }

        private void ручнойВводToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            numHumidityManual.Enabled = true;
            cbxAutoPreset.Text = "Off";
        }

        private void lowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxVentilationPreset.Text = "Low";
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxVentilationPreset.Text = "Medium";
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxVentilationPreset.Text = "High";
        }

        private void ручнойВводToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            numVentilationManual.Enabled = true;
            cbxAutoPreset.Text = "Off";
        }
        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxAutoPreset.Text = "Auto";
        }

        private void ecoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxAutoPreset.Text = "Eco";
        }

        private void effectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxAutoPreset.Text = "Effective";
        }

        private void nightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxAutoPreset.Text = "Night";
        }

        private void вклToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxChartSwitcher.Text = "On";
        }

        private void выклToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxChartSwitcher.Text = "Off";
        }

        private void настройкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            var F = new AddToWeekList();
            if (F.ShowDialog() == DialogResult.OK)
            {
                Show();

            }
        }

        private void numVentilationManual_ValueChanged(object sender, EventArgs e)
        {
            if (numVentilationManual.Value > 0 && numVentilationManual.Value <= 9
                    || numVentilationManual.Value > 10 && numVentilationManual.Value <= 15
                    || numVentilationManual.Value > 16 && numVentilationManual.Value <= 31
                    || numVentilationManual.Value > 32)
            {
                cbxVentilationPreset.Text = "Manual";
            }
            if (numVentilationManual.Value == 0)
            {
                cbxVentilationPreset.Text = "Off";
            }
            if (numVentilationManual.Value == 10)
            {
                cbxVentilationPreset.Text = "Low";
            }
            if (numVentilationManual.Value == 16)
            {
                cbxVentilationPreset.Text = "Medium";
            }
            if (numVentilationManual.Value == 32)
            {
                cbxVentilationPreset.Text = "High";
            }
        }

        private void cbxChartSwitcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChartSwitcher.Text == "On")
            {
                string message = "График не создан. Хотите создать новый график?";
                string caption = "Ошибка графика";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    chartAdd();
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
