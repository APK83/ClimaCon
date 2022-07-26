using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Climat_2
{
    class Humidifier
    {
        private Parameter humidity = new Parameter();
        const int time_h = 2000;
        public Humidifier(Parameter h)//конструктор с параметрами
        {
            humidity = h;
        }
        //public Humidifier()//конструктор без параметров
        //{
        //    humidity.value = 20;
        //    humidity.delta = 5;
        //}
        public void ChangeHumidity(int newParam) //правила для изменения влажности
        {
            if (humidity.value < newParam)
                while (humidity.value < newParam)
                {
                    Thread.Sleep(time_h);
                    humidity.Increase(newParam);
                }
            
        }
    }
}
