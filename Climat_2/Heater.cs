using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Climat_2
{
    class Heater
    {
        private Parameter temperature;
        const int time_t = 1000;
        public Heater(Parameter t)//конструктор с параметрами
        {
            temperature = t;
        }

        public void ChangeTemperature(int newParam) //правила для изменения температуры
        {
            while (temperature.value < newParam)
            {
                temperature.Increase(newParam);
                Thread.Sleep(time_t);
            }
        }
    }
}
        

