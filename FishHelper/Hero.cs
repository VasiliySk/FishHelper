﻿using AutoIt;
using System;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using static FishHelper.EsoWindow;

namespace FishHelper
{
    //Класс, отвечающий за поведение игрока
    class Hero
    {
        enum TargetStatus {X_bigger_Y_bigger,X_less_Y_less, X_bigger_Y_less, X_less_Y_bigger };
        TargetStatus tStatus;
        Random random;
        //Переменные для анализа картинки
        Bitmap bitmap;
        Graphics graphics;
        ImageConverter converter;
        MD5CryptoServiceProvider md5;
        byte[] rawImageData;
        byte[] hash;
        String actualHash;
        private const String fishHole = "81-32-3C-53-F9-56-8E-3A-52-79-B2-EA-7B-CD-EA-F0"; //Рыбное место
        private const String waitFish = "DC-EF-62-B0-A3-E0-24-C6-44-6D-0C-2A-2C-D1-95-51"; //Закинули удочку, ждем рыбу.
        private const String catchFish = "F5-65-2C-94-18-EB-D4-6F-36-BE-EC-60-31-1C-3C-6B"; //Вытягиваем рыбу
        private const String fightStatus = "7F-D3-50-1E-95-D7-BA-C7-61-F9-D5-9D-62-57-FE-BE"; //Персонаж в бою

        //конструктор
        public Hero()
        {
            bitmap = new Bitmap(30, 3); //Задаем размер считываемой области
            graphics = Graphics.FromImage(bitmap as Image);
            converter = new ImageConverter();
            md5 = new MD5CryptoServiceProvider();
            random = new Random();
        }
        
        //Заготовка под бег
        public void Run(EsoWindow esoWindow, IntPtr processHandle, IntPtr hWnd, String xAddress, String yAdress, String cAdress, String xTarget, String yTarget, String cTarget) {

            if (Form1.stopAction) return; //Прекращаем функцию, если нажато F12

            int timeCount = 0;
            IntPtr bytesRead;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ","; //Задаем запятую, как разделитель между числом и дробной частью            

            //Создаем массивы, куда будут считываться данные из памяти
            var bufferX = new byte[8];
            var bufferY = new byte[8];
            var bufferC = new byte[8];
            //Переводим адреса памяти из String в Hex
            var addrX = long.Parse(xAddress, System.Globalization.NumberStyles.HexNumber);
            var addrY = long.Parse(yAdress, System.Globalization.NumberStyles.HexNumber);
            var addrC = long.Parse(cAdress, System.Globalization.NumberStyles.HexNumber);
            //Читаем текущие значения X, Y, Corner
            var resultX = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addrX), bufferX, (uint)bufferX.Length, out bytesRead);
            var resultY = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addrY), bufferY, (uint)bufferY.Length, out bytesRead);
            var resultC = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addrC), bufferC, (uint)bufferC.Length, out bytesRead);
            //Переводим текущие значения X, Y, Corner в Double
            double actualX = BitConverter.ToDouble(bufferX, 0);
            double actualY = BitConverter.ToDouble(bufferY, 0);
            double actualC = BitConverter.ToDouble(bufferC, 0);

            Console.WriteLine("Целевые координаты: "+"X: "+ xTarget + " Y: " + yTarget + " C: " + cTarget);
            Console.WriteLine("Текущие координаты: " + "X: " + Convert.ToString(actualX) + " Y: " + Convert.ToString(actualY) + " C: " + Convert.ToString(actualC));

            //Переводим целевые значения из String в Double с использованием заданного
            double targetX = Convert.ToDouble(xTarget, nfi);
            double targetY = Convert.ToDouble(yTarget, nfi);          
            //Расчет катетов прямоугольного треугольника
            double katetX = Math.Abs(targetX - actualX);
            double katetY = Math.Abs(targetY - actualY);
            //Находим тангенс угла и угол а          
            double cornerA = Math.Atan(katetY / katetX) * 180 / Math.PI;
            //Поворачиваем к цели
            if ((targetX > actualX) && (targetY > actualY)) //Если оба целевых значения больше текущих
            {
                turnCornerVer3(esoWindow, cAdress, processHandle, Convert.ToString(270 - cornerA));
                tStatus = TargetStatus.X_bigger_Y_bigger;
            }

            if ((targetX < actualX) && (targetY < actualY)) //Если оба целевых значения меньше текущих
            {
                turnCornerVer3(esoWindow, cAdress, processHandle, Convert.ToString(90-cornerA));
                tStatus = TargetStatus.X_less_Y_less;
            }

            if ((targetX > actualX) && (targetY < actualY)) //Если целевой X больше, а Y - меньше
            {
                turnCornerVer3(esoWindow, cAdress, processHandle, Convert.ToString(270 + cornerA));
                tStatus = TargetStatus.X_bigger_Y_less;
            }

            if ((targetX < actualX) && (targetY > actualY)) //Если целевой X меньше, а Y - больше
            {
                turnCornerVer3(esoWindow, cAdress, processHandle, Convert.ToString(90 + cornerA));
                tStatus = TargetStatus.X_less_Y_bigger;
            }

            //Бежим к цели
            while (ReachTarget(targetX, actualX, targetY, actualY))
            {
                if (Form1.stopAction) break;
                if (timeCount > 30000)
                {
                    Form1.stopAction = true;
                    break;
                }
                if (isFight()) {
                    esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)Keys.W), new IntPtr(0));
                    Fight(esoWindow, hWnd); //Если в бою, то воюем.
                } 
                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)System.Windows.Forms.Keys.W), new IntPtr(0));
                Thread.Sleep(50);
                timeCount = timeCount + 50;
                resultX = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addrX), bufferX, (uint)bufferX.Length, out bytesRead);
                resultY = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addrY), bufferY, (uint)bufferY.Length, out bytesRead);
                actualX = BitConverter.ToDouble(bufferX, 0);
                actualY = BitConverter.ToDouble(bufferY, 0);
            }

            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)Keys.W), new IntPtr(0));
            if (!Form1.stopAction&& cTarget!=null)
            {
                if (!cTarget.Equals("")) turnCornerVer3(esoWindow, cAdress, processHandle, cTarget);
            }
        }
        
        //Определяем, рыбное ли это место или нет
        public bool isFishHole()
        {         
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // Задаем первыми двумя цифрами координаты начала (верхний левый угол) считываемого прямоугольника 

            //Рассчитываем хэш код картинки            
            rawImageData = converter.ConvertTo(bitmap, typeof(byte[])) as byte[];
            hash = md5.ComputeHash(rawImageData);
            //конвертируем в строку
            actualHash = BitConverter.ToString(hash);

            switch (actualHash)
            {
                case fishHole:
                    return true;
                default:
                    return false;
            }
        }

        //Определяем, в бою мы или нет
        public bool isFight()
        {
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // Задаем первыми двумя цифрами координаты начала (верхний левый угол) считываемого прямоугольника 

            //Рассчитываем хэш код картинки            
            rawImageData = converter.ConvertTo(bitmap, typeof(byte[])) as byte[];
            hash = md5.ComputeHash(rawImageData);
            //конвертируем в строку
            actualHash = BitConverter.ToString(hash);

            switch (actualHash)
            {
                case fightStatus:
                    return true;
                default:
                    return false;
            }
        }

        //Рыбачим
        public void Fishing(EsoWindow esoWindow, IntPtr hWnd)
        {
            bool stopFish = false;                       

            while (!stopFish)
            {
                if (Form1.stopAction) return;
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // Задаем первыми двумя цифрами координаты начала (верхний левый угол) считываемого прямоугольника 

                //Рассчитываем хэш код картинки            
                rawImageData = converter.ConvertTo(bitmap, typeof(byte[])) as byte[];
                hash = md5.ComputeHash(rawImageData);
                //конвертируем в строку
                actualHash = BitConverter.ToString(hash);
                switch (actualHash)
                {
                    case fishHole:                        
                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)System.Windows.Forms.Keys.E), new IntPtr(0));
                        Thread.Sleep(random.Next(70,100));
                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)System.Windows.Forms.Keys.E), new IntPtr(0));
                        break;
                    case waitFish:                        
                        break;
                    case catchFish:                        
                        Thread.Sleep(random.Next(500, 1000));
                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)System.Windows.Forms.Keys.E), new IntPtr(0));
                        Thread.Sleep(random.Next(70, 100));
                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)System.Windows.Forms.Keys.E), new IntPtr(0));
                        Thread.Sleep(random.Next(3000, 4000));
                        break;
                    case fightStatus:
                        Fight(esoWindow,hWnd);
                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)System.Windows.Forms.Keys.S), new IntPtr(0));
                        Thread.Sleep(random.Next(2000));
                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)System.Windows.Forms.Keys.S), new IntPtr(0));
                        Thread.Sleep(random.Next(70, 100));
                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)System.Windows.Forms.Keys.W), new IntPtr(0));
                        Thread.Sleep(random.Next(1500));
                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)System.Windows.Forms.Keys.W), new IntPtr(0));
                        break;
                    default:                        
                        stopFish = true;
                        break;
                }

                Thread.Sleep(random.Next(500, 1000));
            }
        }

        public void turnCornerVer2(EsoWindow esoWindow, String addrText, IntPtr processHandle, String targetCorner)
        {
            Point cursorPosition = new Point();

            esoWindow.GetCursorPos(out cursorPosition);

            var buffer = new byte[8];
            var addr = long.Parse(addrText, NumberStyles.HexNumber);
            IntPtr bytesRead;
            var result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ","; //Задаем запятую, как разделитель между числом и дробной частью

            double trgCorner = Convert.ToDouble(targetCorner, nfi); //Целевой угол
            double acturalCorner = BitConverter.ToDouble(buffer, 0); //текущий угол
            double previousCorner; //Предыдущее значение угла
            double targetDistance; //Количество градусов, на которое нужно повернуть взгляд
            double coveredDistance; //пройденное количесто градусов угла

            if (trgCorner > acturalCorner) //Целевой угол больше текущего
            {
                if ((trgCorner - acturalCorner) < 180) //Если разница меньше 180, то поворачиваем по часовой стрелке
                {
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                    previousCorner = BitConverter.ToDouble(buffer, 0);
                    targetDistance = trgCorner - acturalCorner;
                    coveredDistance = 0;
                    while(targetDistance> coveredDistance)
                    {
                        if (Form1.stopAction) return;
                        esoWindow.SetCursorPos(cursorPosition.X - 3, cursorPosition.Y);
                        result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                        coveredDistance = BitConverter.ToDouble(buffer, 0) - previousCorner + coveredDistance;                       
                        previousCorner = BitConverter.ToDouble(buffer, 0);
                        Thread.Sleep(10);
                    }
                }
                else //Если разница больше 180, то поворачиваем против часовой стрелки
                {
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                    previousCorner = BitConverter.ToDouble(buffer, 0);
                    targetDistance = CornerDistance(trgCorner, acturalCorner);
                    coveredDistance = 0;
                    while (targetDistance > coveredDistance)
                    {
                        if (Form1.stopAction) return;
                        esoWindow.SetCursorPos(cursorPosition.X + 3, cursorPosition.Y);
                        result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                        coveredDistance = CornerDistance(BitConverter.ToDouble(buffer, 0), previousCorner) + coveredDistance;                        
                        previousCorner = BitConverter.ToDouble(buffer, 0);
                        Thread.Sleep(10);
                    }
                }
            }
            else //Целевой угол меньше текущего
            {
                if ((acturalCorner - trgCorner) < 180) //Если разница меньше 180, то поворачиваем против часовой стрелки
                {
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                    previousCorner = BitConverter.ToDouble(buffer, 0);
                    targetDistance =  acturalCorner - trgCorner;
                    coveredDistance = 0;
                    while (targetDistance > coveredDistance)
                    {
                        if (Form1.stopAction) return;
                        esoWindow.SetCursorPos(cursorPosition.X + 3, cursorPosition.Y);
                        result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                        coveredDistance = previousCorner -BitConverter.ToDouble(buffer, 0)  + coveredDistance;
                        previousCorner = BitConverter.ToDouble(buffer, 0);
                        Thread.Sleep(10);
                    }
                }
                else //Если разница больше 180, то поворачиваем по часовой стрелке
                {
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                    previousCorner = BitConverter.ToDouble(buffer, 0);
                    targetDistance = CornerDistance(acturalCorner, trgCorner);                    
                    coveredDistance = 0;
                    while (targetDistance > coveredDistance)
                    {
                        if (Form1.stopAction) return;
                        esoWindow.SetCursorPos(cursorPosition.X - 3, cursorPosition.Y);
                        result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                        coveredDistance = CornerDistance(BitConverter.ToDouble(buffer, 0), previousCorner) + coveredDistance;                        
                        previousCorner = BitConverter.ToDouble(buffer, 0);
                        Thread.Sleep(10);
                    }
                }
            }
        }


        public void turnCornerVer3(EsoWindow esoWindow, String addrText, IntPtr processHandle, String targetCorner)
        {
            Point cursorPosition = new Point();

            esoWindow.GetCursorPos(out cursorPosition);

            var buffer = new byte[8];
            var addr = long.Parse(addrText, NumberStyles.HexNumber);
            IntPtr bytesRead;
            var result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ","; //Задаем запятую, как разделитель между числом и дробной частью

            double trgCorner = Convert.ToDouble(targetCorner, nfi); //Целевой угол
            double acturalCorner = BitConverter.ToDouble(buffer, 0); //текущий угол 
            int screenX = Screen.PrimaryScreen.Bounds.Width;
            int numberОfTurns = 0;  

            if (trgCorner > acturalCorner) //Целевой угол больше текущего
            {
                int X = AutoItX.MouseGetPos().X;
                int Y = AutoItX.MouseGetPos().Y;
                if (((trgCorner - acturalCorner) * 8.7184d) > (Screen.PrimaryScreen.Bounds.Width / 2))
                {
                    numberОfTurns = Convert.ToInt32(Math.Truncate(((trgCorner - acturalCorner) * 8.7184d) / (Screen.PrimaryScreen.Bounds.Width / 2)));                    
                    for (int i = 0; i < numberОfTurns; i++)
                    {
                        AutoItX.MouseMove(X - screenX/2 + 1, Y, 1);
                        Thread.Sleep(50);                        ;
                    }
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                    acturalCorner = BitConverter.ToDouble(buffer, 0);                    
                }
                Thread.Sleep(500);
                AutoItX.MouseMove(X - Convert.ToInt32((trgCorner- acturalCorner)*8.7184d), Y, 1); //8.7184 - коэффициент, полученный эксперементальным расчетным путем
            }
            else //Целевой угол меньше текущего
            {
                int X = AutoItX.MouseGetPos().X;
                int Y = AutoItX.MouseGetPos().Y;
                if (((acturalCorner - trgCorner) * 8.7184d) > (Screen.PrimaryScreen.Bounds.Width / 2))
                {
                    numberОfTurns = Convert.ToInt32(Math.Truncate(((acturalCorner - trgCorner) * 8.7184d) / (Screen.PrimaryScreen.Bounds.Width / 2)));
                    for (int i = 0; i < numberОfTurns; i++)
                    {
                        AutoItX.MouseMove(X + screenX / 2 - 1, Y, 1);
                        Thread.Sleep(50);
                    }
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                    acturalCorner = BitConverter.ToDouble(buffer, 0);
                }
                Thread.Sleep(500);
                AutoItX.MouseMove(X + Convert.ToInt32((acturalCorner - trgCorner) * 8.7184d), Y, 1); //8.7184 - коэффициент, полученный эксперементальным расчетным путем
            }
        }

        //Рассчитываем дистанцию поворота между двумя углами
        private double CornerDistance(double acturalCorner, double trgCorner)
        {
            double cornerDistance;
            if((acturalCorner> trgCorner)&&((acturalCorner- trgCorner) > 180)) //Обрабатываем ситуацию перехода через 0, в случае если acturalCorner чуть меньше 360, а trgCorner больше 0 и двигаемся по часовой стрелке
            {
                cornerDistance = 360 - acturalCorner + trgCorner;
                return cornerDistance;
            }

            if ((trgCorner > acturalCorner) && ((trgCorner - acturalCorner) > 180)) //Обрабатываем ситуацию перехода через 0, в случае если acturalCorner чуть больше 0, а trgCorner меньше 360
            {
                cornerDistance = 360 - trgCorner + acturalCorner;
                return cornerDistance;
            }

            cornerDistance = Math.Abs(acturalCorner - trgCorner);
            return cornerDistance;
        }

        //Поворот камеры

        public void turnCorner(EsoWindow esoWindow, String addrText, IntPtr processHandle, String targetCorner)
        {
            Point cursorPosition = new Point();

            esoWindow.GetCursorPos(out cursorPosition);

            var buffer = new byte[8];
            var addr = long.Parse(addrText, NumberStyles.HexNumber);
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
                    if (Form1.stopAction) break;
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
                    if (Form1.stopAction) break;
                    esoWindow.SetCursorPos(cursorPosition.X + 3, cursorPosition.Y);
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                    counterCorner = previousCorner - BitConverter.ToDouble(buffer, 0) + counterCorner;
                    previousCorner = BitConverter.ToDouble(buffer, 0);
                    Thread.Sleep(10);
                }
            }          
        }

        //Определяем, достигли ли цели или нет
        private bool ReachTarget(double targetX, double actualX, double targetY, double actualY)
        {
            if (tStatus == TargetStatus.X_bigger_Y_bigger)
            {
                if ((targetX > actualX) || (targetY > actualY))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (tStatus == TargetStatus.X_less_Y_less)
            {
                if ((targetX < actualX) || (targetY < actualY))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (tStatus == TargetStatus.X_bigger_Y_less)
            {
                if ((targetX > actualX) || (targetY < actualY))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (tStatus == TargetStatus.X_less_Y_bigger)
            {
                if ((targetX < actualX) || (targetY > actualY))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;

        }      

        //Собираем ресурс
        public void GatheringResources(EsoWindow esoWindow, IntPtr hWnd)
        {            
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)Keys.E), new IntPtr(0));
            Thread.Sleep(random.Next(70, 100));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)Keys.E), new IntPtr(0));
        }
        //Воюем
        public void Fight(EsoWindow esoWindow, IntPtr hWnd)
        {
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)Keys.D1), new IntPtr(0));
            Thread.Sleep(random.Next(70, 100));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)Keys.D1), new IntPtr(0));
            Thread.Sleep(2000);
            //Пока в бое, жмем клавишу 1 раз в 2 секунды
            while (isFight())
            {
                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)Keys.D1), new IntPtr(0));
                Thread.Sleep(random.Next(70, 100));
                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)Keys.D1), new IntPtr(0));
                Thread.Sleep(2000);
            }
        }
    }
}
