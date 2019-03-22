using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FishHelper
{
    //Класс, отвечающий за поведение игрока
    class Hero
    {
        //Заготовка под бег
        public void Run() { }

        //Заготовка под поворот угла обзора камеры
        public void changeViewingCorner() { }

        //Заготовка под рыбалку
        public void Fishing()
        {

        }

        //Поворот камеры

        public void turnCorner(EsoWindow esoWindow, String addrText, IntPtr processHandle, String targetCorner)
        {
            Point cursorPosition = new Point();

            esoWindow.GetCursorPos(out cursorPosition);

            var buffer = new byte[8];
            var addr = long.Parse(addrText, System.Globalization.NumberStyles.HexNumber);
            IntPtr bytesRead;
            var result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ","; //Задаем запятую, как разделитель между числом и дробной частью

            double trgCorner = Convert.ToDouble(targetCorner, nfi); //Целевой угол
            double acturalCorner = BitConverter.ToDouble(buffer, 0); //текущий угол
            double counterCorner = 0; //Счетчик, на сколько повернулся угол
            double lenghtCorner; //Длина, на которую надо повернуть угол
            double previousCorner; //Предыдущее значение угла
            bool rotationCorner; //Определяем, куда поворачивать. True - вперед, False - назад
                        
            if(trgCorner> acturalCorner)
            {                
                lenghtCorner = trgCorner - acturalCorner;
                rotationCorner = true;                
            }
            else
            {
                lenghtCorner = acturalCorner - trgCorner;
                rotationCorner = false;                
            }

            if (rotationCorner)
            {
                result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                previousCorner = BitConverter.ToDouble(buffer, 0);

                while (lenghtCorner> counterCorner)
                {
                    esoWindow.SetCursorPos(cursorPosition.X - 3, cursorPosition.Y);
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);                    
                    counterCorner = BitConverter.ToDouble(buffer, 0) - previousCorner + counterCorner;
                    previousCorner = BitConverter.ToDouble(buffer, 0);
                    Thread.Sleep(10);
                }
            }
            else
            {
                result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                previousCorner = BitConverter.ToDouble(buffer, 0);

                while (lenghtCorner > counterCorner)
                {
                    esoWindow.SetCursorPos(cursorPosition.X + 3, cursorPosition.Y);
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                    counterCorner = previousCorner - BitConverter.ToDouble(buffer, 0) + counterCorner;
                    previousCorner = BitConverter.ToDouble(buffer, 0);
                    Thread.Sleep(10);
                }
            }          
        }
    }
}
