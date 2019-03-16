using System;
using System.Windows.Forms;
using static FishHelper.EsoWindow;

namespace FishHelper
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var addr = long.Parse(textBoxCoordX.Text, System.Globalization.NumberStyles.HexNumber);

            EsoWindow esoWindow = new EsoWindow();
            IntPtr hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
                        
            if (hWnd.ToInt32() > 0) //If found
            {
                int pid;
                double targetX = 51.7d;
                var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd,out pid);
               // label1.Text = pid.ToString();
                var processHandle = esoWindow.OpenProcess(0x10, false, pid);
                var buffer = new byte[8];
                IntPtr bytesRead;
                //Активируем окно, прожимаем дважды кноку мыши 
                esoWindow.SetForegroundWindow(hWnd); //Активируем окно
                System.Threading.Thread.Sleep(1000);
                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONDOWN, new IntPtr(0), new IntPtr(0));
                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONUP, new IntPtr(0), new IntPtr(0));
                System.Threading.Thread.Sleep(1000);
                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONDOWN, new IntPtr(0), new IntPtr(0));
                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONUP, new IntPtr(0), new IntPtr(0));
                System.Threading.Thread.Sleep(1000);
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
           
    }
}
