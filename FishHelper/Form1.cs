using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
        IntPtr hWnd;
        private IntPtr processHandle;
        BindingList<FishPath> data;
        private LowLevelKeyboardListener _listener; //  Слушаем нажатие клавиш
        public static bool stopAction;

        public Form1()
        {
            data = new BindingList<FishPath>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview            
            InitializeComponent();
            stopAction = false;
            dataGridView1.DataSource = data;           
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - Convert.ToInt32(this.Height*1.5));//Переносим окно в левый нижний угол
            this.TopMost = true;            
            //Инициализируем классы
            esoWindow = new EsoWindow();
            esoWindow.SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);//Запрещаем спящий режим во время работы программы
            esoWindow.SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);//Запрещаем спящий режим во время работы программы
            esoWindow.SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);//Запрещаем спящий режим во время работы программы
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
            var buffer = new byte[8];
            //Активируем окно, прожимаем дважды кноку мыши 
            ActivateEsoWindow();

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

        private void ActivateEsoWindow()
        {
            stopAction = false;
            Random random = new Random();
            hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
            var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd, out pid);
            processHandle = esoWindow.OpenProcess(0x10, false, pid);            
            esoWindow.SetForegroundWindow(hWnd); //Активируем окно
            Thread.Sleep(random.Next(1000, 2000));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_MBUTTONDOWN, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(500,1000));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_MBUTTONUP, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(500, 1000));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_MBUTTONDOWN, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(500, 1000));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_MBUTTONUP, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(500, 1000));
        }

        private void btnCameraCorner_Click(object sender, EventArgs e)
        {     
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            (new Thread(delegate ()
            {
                //Активируем окно, прожимаем дважды кноку мыши 
                ActivateEsoWindow();

                hero.turnCorner(esoWindow, textBoxCorner.Text, processHandle, txtTargetCorner.Text);

                esoWindow.CloseHandle(processHandle);
            })).Start();            
        }

        private void btnTargetRun_Click(object sender, EventArgs e)
        {
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            (new Thread(delegate ()
            {
                //Активируем окно, прожимаем дважды кноку мыши 
                ActivateEsoWindow();

            //Бежим к цели
            hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text,textBoxCoordY.Text,textBoxCorner.Text,txtboxXTarget.Text,txtboxYTarget.Text,txtTargetCorner.Text);

            esoWindow.CloseHandle(processHandle);
            })).Start();
        }

        private void btnFishing_Click(object sender, EventArgs e)
        {
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            (new Thread(delegate ()
            {
                //Активируем окно, прожимаем дважды кноку мыши 
                ActivateEsoWindow();

            hero.Fishing(esoWindow, hWnd);

            esoWindow.CloseHandle(processHandle);
            })).Start();
        }

        private void btnRunAndFish_Click(object sender, EventArgs e)
        {
            Random random = new Random();          

            //Активируем окно, прожимаем дважды кноку мыши 
            ActivateEsoWindow();

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
            RunAndFish(0);
        }

        private void RunAndFish(int count)
        {
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            (new Thread(delegate ()
            {
                Random random = new Random();

                //Активируем окно, прожимаем дважды кноку мыши 
                ActivateEsoWindow();

                for (int i = count; i < data.Count; i++)
                {
                    if (data[i].holeType == true)
                    {
                        //Бежим к цели и потом рыбачим
                        hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, data[i].xCoord, data[i].yCoord, data[i].tCorner);
                        Thread.Sleep(random.Next(1000, 2000));
                        //int attempt = 0;
                        ////Делаем тридцать попыток начать рыбачить. А вдруг появится лунка )))
                        //while (attempt < 30)
                        //{
                        //    if (hero.isFishHole())
                        //    {
                        //        attempt = 30;
                        //    }
                        //    else
                        //    {
                        //        Thread.Sleep(random.Next(500, 1500));
                        //        attempt++;
                        //    }
                        //}
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
            })).Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();
        }

        //При нажатии на F12 останавливаем выполнение операции.
        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)        {

            if (e.KeyPressed == Keys.F12) stopAction = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        //Проверка на вводимые данные в таблицу. Ввести можно только цифры и запятую.
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex != 3) //Проверяем все столбцы, кроме последнего
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))           
            { 
                switch (e.KeyChar) //Обрабатываем точку и запятую
                {
                    case '.':
                        e.KeyChar = ',';
                        return;
                    case ',':
                        return;
                }               
                e.Handled = true;
            }
        }
        //Открываем диалог с выбором файла с адресами
        private void openAdressStripMenuItem1_Click(object sender, EventArgs e)
        {
            fishHelperFile.OpenAdressFile(openFileDialog2, textBoxCoordX, textBoxCoordY,textBoxCorner);
        }

        // Запускаем список с выбранной позиции
        private void btnGoSelect_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                if (oneCell.Selected) count = oneCell.RowIndex;                   
            }
            RunAndFish(count);
        }

        //Вариант рыбалки номер 2
        private void btnFishingVer2_Click(object sender, EventArgs e)
        {
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            (new Thread(delegate ()
            {
                Random random = new Random();
                //Активируем окно, прожимаем дважды кноку мыши 
                ActivateEsoWindow();

                hero.Fishing(esoWindow, hWnd);

                Thread.Sleep(random.Next(1000, 2000));

                var buffer = new byte[8];
                var addr = long.Parse(textBoxCorner.Text, NumberStyles.HexNumber);
                IntPtr bytesRead;
                var result = esoWindow.ReadProcessMemory(processHandle, new IntPtr(addr), buffer, (uint)buffer.Length, out bytesRead);

                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ","; //Задаем запятую, как разделитель между числом и дробной частью

                double acturalCorner = BitConverter.ToDouble(buffer, 0); //текущий угол

                if (acturalCorner - 180 > 0)
                {
                    hero.turnCorner(esoWindow, textBoxCorner.Text, processHandle,Convert.ToString(acturalCorner - 180));
                }
                else
                {
                    hero.turnCorner(esoWindow, textBoxCorner.Text, processHandle, Convert.ToString(acturalCorner + 180));
                }

                Thread.Sleep(random.Next(1000, 2000));

                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)Keys.W), new IntPtr(0));
                Thread.Sleep(random.Next(2000, 3000));
                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)Keys.W), new IntPtr(0));

                esoWindow.CloseHandle(processHandle);
            })).Start();
        }
    }
}
