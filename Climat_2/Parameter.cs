using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climat_2
{

    class Parameter
    {
        private object lockObject = new object();
        public int value { get; private set; }//значение
        public int delta { get; private set; }//как меняется

        public Parameter()
        {
            value = 0;
            delta = 1;
        }
        public Parameter(int currentValue, int curentDelta)
        {

            value = currentValue;
            delta = curentDelta;
        }      

        internal void Increase(int targetValue)
        {
            if (value < targetValue) 
            {
                lock (lockObject) 
                {
                    if (value < targetValue)
                    {
                        value += delta;
                    }
                }
            }
        }

        internal void Decrease(int targetValue)
        {
            if (value > targetValue)
            {
                lock (lockObject)
                {
                    if (value > targetValue)
                    {
                        value -= delta;
                    }
                }
            }
        }

        internal void SetValue(int v)
        {
            value = v;
        }
    }
}
