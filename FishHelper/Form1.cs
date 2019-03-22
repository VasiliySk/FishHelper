using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static FishHelper.EsoWindow;

namespace FishHelper
{
    public partial class Form1 : Form
    {     
        int pid; //Идентификатор игры
        EsoWindow esoWindow;
        Hero hero;
        IntPtr bytesRead;
        private System.Threading.Timer timer;
        private IntPtr processHandle;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - Convert.ToInt32(this.Height*1.5));//Переносим окно в левый нижний угол
            this.TopMost = true;
            //Инициализируем классы
            esoWindow = new EsoWindow();
            hero = new Hero();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var addr = long.Parse(textBoxCoordX.Text, System.Globalization.NumberStyles.HexNumber);  
            IntPtr hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
                        
            if (hWnd.ToInt32() > 0) //If found
            {                
                double targetX = 37.0d;
                var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd,out pid);              
                processHandle = esoWindow.OpenProcess(0x10, false, pid);
                var buffer = new byte[8];
                IntPtr bytesRead;
                //Активируем окно, прожимаем дважды кноку мыши 
                ActivateEsoWindow(hWnd);
                //Бежим до заданной точки
                var result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                while (targetX > BitConverter.ToDouble(buffer, 0))
                {
                    esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)System.Windows.Forms.Keys.W), new IntPtr(0));
                    System.Threading.Thread.Sleep(100);
                    result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                }

                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)System.Windows.Forms.Keys.W), new IntPtr(0));
                esoWindow.CloseHandle(processHandle);
            }
        }

        //Делаем окно Always on Top
        private void chkbAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbAlwaysOnTop.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void btbTestAdress_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
            var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd, out pid);
            processHandle = esoWindow.OpenProcess(0x10, false, pid);
            var buffer = new byte[8];
            //Активируем окно, прожимаем дважды кноку мыши 
            ActivateEsoWindow(hWnd);

            if (textBoxCoordX.Text != "")
            {
                var addr = long.Parse(textBoxCoordX.Text, System.Globalization.NumberStyles.HexNumber);
                var result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                lblCoordX.Text = Convert.ToString(BitConverter.ToDouble(buffer, 0));
            }

            if (textBoxCoordY.Text != "")
            {
                var addr = long.Parse(textBoxCoordY.Text, System.Globalization.NumberStyles.HexNumber);
                var result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                lblCoordY.Text = Convert.ToString(BitConverter.ToDouble(buffer, 0));
            }

            if (textBoxCorner.Text != "")
            {
                var addr = long.Parse(textBoxCorner.Text, System.Globalization.NumberStyles.HexNumber);
                var result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);
                lblCorner.Text = Convert.ToString(BitConverter.ToDouble(buffer, 0));
            }

            esoWindow.CloseHandle(processHandle);
        }

        private void ActivateEsoWindow(IntPtr hWnd)
        {
            esoWindow.SetForegroundWindow(hWnd); //Активируем окно
            System.Threading.Thread.Sleep(1000);
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONDOWN, new IntPtr(0), new IntPtr(0));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONUP, new IntPtr(0), new IntPtr(0));
            System.Threading.Thread.Sleep(1000);
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONDOWN, new IntPtr(0), new IntPtr(0));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONUP, new IntPtr(0), new IntPtr(0));
            System.Threading.Thread.Sleep(1000);
        }

        private void btnCameraCorner_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
            var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd, out pid);
            processHandle = esoWindow.OpenProcess(0x10, false, pid);
           
            //Активируем окно, прожимаем дважды кноку мыши 
            ActivateEsoWindow(hWnd);

            hero.turnCorner(esoWindow, textBoxCorner.Text, processHandle, txtTargetCorner.Text);          

            esoWindow.CloseHandle(processHandle);
        }       

    }
}
