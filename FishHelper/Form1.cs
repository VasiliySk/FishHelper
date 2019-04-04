using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
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
        FishHelperFile fishHelperFile;
        IntPtr bytesRead;        
        private IntPtr processHandle;
        BindingList<FishPath> data;
        private LowLevelKeyboardListener _listener; //  Слушаем нажатие клавиш

        public Form1()
        {
            data = new BindingList<FishPath>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview            
            InitializeComponent();
            dataGridView1.DataSource = data;           
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - Convert.ToInt32(this.Height*1.5));//Переносим окно в левый нижний угол
            this.TopMost = true;
            //Инициализируем классы
            esoWindow = new EsoWindow();
            hero = new Hero();
            fishHelperFile = new FishHelperFile();
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

            esoWindow.CloseHandle(processHandle);
        }

        //Удаляем выделенную строку
        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                
                if (oneCell.Selected)
                    dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
            }
        }

        private void btnConsol_Click(object sender, EventArgs e)
        {
            Console.WriteLine(data.Count);
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine(data[i].tCorner);
            }            
        }
        
        //Добавляем строку
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {

                if (oneCell.Selected)
                    data.Insert(oneCell.RowIndex, new FishPath());
            }
        }

        //Выход из приложения
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Открываем файл
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fishHelperFile.OpenFile(openFileDialog1, data, saveToolStripMenuItem);
        }

        //Сохраняем файл
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fishHelperFile.SaveFile();
        }

        //Сохраняем файл как...
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fishHelperFile.SaveFileAs(saveFileDialog1, data, saveToolStripMenuItem);
        }

        //Бежим и рыбачим по списку
        private void btnGoGoGo_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            IntPtr hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
            var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd, out pid);
            processHandle = esoWindow.OpenProcess(0x10, false, pid);

            //Активируем окно, прожимаем дважды кноку мыши 
            ActivateEsoWindow(hWnd);


            for (int i=0; i<data.Count; i++)
            {
                if (data[i].holeType == true)
                {
                    //Бежим к цели и потом рыбачим
                    hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, data[i].xCoord, data[i].yCoord, data[i].tCorner);
                    Thread.Sleep(random.Next(1000, 2000));
                    hero.Fishing(esoWindow, hWnd);
                    Thread.Sleep(random.Next(1000, 2000));
                }
                else
                {
                    //Бежим к цели
                    hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, data[i].xCoord, data[i].yCoord, data[i].tCorner);
                    Thread.Sleep(random.Next(1000, 2000));
                }
            }
            esoWindow.CloseHandle(processHandle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();
        }

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            this.textBox1.Text += e.KeyPressed.ToString();
            if(e.KeyPressed == Keys.F12) this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _listener.UnHookKeyboard();
        }
    }
}
