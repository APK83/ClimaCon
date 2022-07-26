using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Climat_2
{
    class Conditioner
    {
        private Parameter temperature;
        private Parameter humidity;
        const int time_t = 1000;
        const int time_h = 2000;
        public Conditioner(Parameter temperature, Parameter humidity)//конструктор с параметрами
        {
            this.temperature = temperature;
            this.humidity = humidity;
        }

        //public Conditioner()//конструктор без параметров
        //{
        //    temperature = new Te
        //    temperature.value = 1;
        //    temperature.delta = 1;
        //    humidity.value = 20;
        //    humidity.delta = 5;
        //}

        public void ChangeTemperature(int newParam) //правила для изменения температуры
        {
            if (temperature.value < newParam)
                while (temperature.value < newParam)
                {
                    Thread.Sleep(time_t);
                    temperature.Increase(newParam);

                }
            else
            {
                while (temperature.value > newParam)
                {
                    Thread.Sleep(time_t);
                    temperature.Decrease(newParam);

                }
            }
        }
        public void ChangeHumidity(int newParam) //правила для изменения влажности
        {
            if (humidity.value > newParam)
                while (humidity.value > newParam)
                {
                    Thread.Sleep(time_h);
                    humidity.Decrease(newParam);
                }
            
        }
    }

}
