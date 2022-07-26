using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Climat_2
{
    class Ventilation
    {
        private Parameter rpm = new Parameter();
        private Parameter temperature = new Parameter();
        private Parameter humidity = new Parameter();
        const int time_t = 1000;
        const int time_v = 100;
        const int time_h = 2000;

        public Ventilation(Parameter v, Parameter t, Parameter h)//конструктор с параметрами
        {
            rpm = v;
            temperature = t;
            humidity = h;
        }
        //public Ventilation()//конструктор без параметров
        //{
        //    rpm.value = 0;
        //    rpm.delta = 1;
        //    temperature.value = 1;
        //    temperature.delta = 1;
        //    humidity.value = 20;
        //    humidity.delta = 5;
        //}
        public void ChangeVentilation(int newParam) //правила для изменения влажности
        {
            if (rpm.value < newParam)
                while (rpm.value < newParam)
                {
                    Thread.Sleep(time_v);
                    rpm.Increase(newParam);

                }
            else
            {
                while (rpm.value > newParam)
                {
                    Thread.Sleep(time_v);
                    rpm.Decrease(newParam);

                }
            }
        }
        public void ChangeTemperature(int newParam) //правила для изменения температуры
        {
            if (temperature.value > newParam)
                while (temperature.value > newParam)
                {
                    Thread.Sleep(time_t);
                    temperature.Decrease(newParam);

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
