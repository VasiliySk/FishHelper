using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
        private IntPtr processHandle;        

        public Form1()
        {
            BindingList<FishPath> data = new BindingList<FishPath>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            data.Add(new FishPath(20, 50, 57, true));
            InitializeComponent();
            dataGridView1.DataSource = data;
            data.Add(new FishPath(20.1f, 50.2f, 57.12f, true));
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - Convert.ToInt32(this.Height*1.5));//Переносим окно в левый нижний угол
            this.TopMost = true;
            //Инициализируем классы
            esoWindow = new EsoWindow();
            hero = new Hero();
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
            Random random = new Random();
            esoWindow.SetForegroundWindow(hWnd); //Активируем окно
            Thread.Sleep(random.Next(1000, 2000));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_RBUTTONDOWN, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(500,1000));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_RBUTTONUP, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(500, 1000));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_RBUTTONDOWN, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(500, 1000));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_RBUTTONUP, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(500, 1000));
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

        private void btnTargetRun_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
            var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd, out pid);
            processHandle = esoWindow.OpenProcess(0x10, false, pid);

            //Активируем окно, прожимаем дважды кноку мыши 
            ActivateEsoWindow(hWnd);

            //Бежим к цели
            hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text,textBoxCoordY.Text,textBoxCorner.Text,txtboxXTarget.Text,txtboxYTarget.Text,txtTargetCorner.Text);

            esoWindow.CloseHandle(processHandle);
        }

        private void btnFishing_Click(object sender, EventArgs e)
        {
            
            IntPtr hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
            var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd, out pid);
            processHandle = esoWindow.OpenProcess(0x10, false, pid);

            //Активируем окно, прожимаем дважды кноку мыши 
            ActivateEsoWindow(hWnd);

            hero.Fishing(esoWindow, hWnd);

            esoWindow.CloseHandle(processHandle);
        }

        private void btnRunAndFish_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            IntPtr hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
            var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd, out pid);
            processHandle = esoWindow.OpenProcess(0x10, false, pid);

            //Активируем окно, прожимаем дважды кноку мыши 
            ActivateEsoWindow(hWnd);

            //Бежим к цели и потом рыбачим
            hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, txtboxXTarget.Text, txtboxYTarget.Text, txtTargetCorner.Text);
            Thread.Sleep(random.Next(1000, 2000));
            hero.Fishing(esoWindow, hWnd);

        }

       
    }
}
