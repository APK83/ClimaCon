using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Climat_2
{
    public class Preset
    {
        public bool System { get; set; }
        public int Ventilation { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
    }

    public class PresetLoader
   {
        public Dictionary<string, Preset> Presets { get; private set; } = new Dictionary<string, Preset>();

        public int AutoTemperature { get; private set; }
        public int AutoHumidity { get; private set; }
        public int FanLow { get; private set; }
        public int FanMedium { get; private set; }
        public int FanHigh { get; private set; }

        public void LoadConfig()
        {
            string fullText = System.IO.File.ReadAllText("Preset.txt");
            foreach(string onePreset in fullText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] presetValues = onePreset.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                if (presetValues[0] == "Auto")
                {
                    AutoTemperature = int.Parse(presetValues[2]);
                    AutoHumidity = int.Parse(presetValues[3]);
                    FanMedium = int.Parse(presetValues[4]);
                }
                if (presetValues[0] == "Eco")
                {
                    FanLow = int.Parse(presetValues[4]);
                }
                if (presetValues[0] == "Effective")
                {
                    FanHigh = int.Parse(presetValues[4]);
                }
                    Presets.Add(presetValues[0], new Preset() {
                    System = presetValues[1] == "System",
                    Temperature = int.Parse(presetValues[2]),
                    Humidity = int.Parse(presetValues[3]),
                    Ventilation = int.Parse(presetValues[4])
                });
            }
        }
        public void SaveConfig()
        {
            StringBuilder configBuilder = new StringBuilder();
            foreach (KeyValuePair<string, Preset> onePreset in Presets)
            {
                string system = onePreset.Value.System ? "System": "User";
                configBuilder.Append($"{onePreset.Key};{system};{onePreset.Value.Temperature};{onePreset.Value.Humidity};{onePreset.Value.Ventilation}{Environment.NewLine}");
            }
            System.IO.File.WriteAllText("Preset.txt", configBuilder.ToString());
        }               
    }
}
