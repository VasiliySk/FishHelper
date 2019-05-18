using CheatEngine;
using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FishHelper.EsoWindow;
using static FishHelper.UserOptions;

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
        BindingList<AdressList> xAdressList, yAdressList, cAdressList; //Коллекции отфильтрованных адресов
        bool firstScan;
        private LowLevelKeyboardListener _listener; //  Слушаем нажатие клавиш
        public static bool stopAction;
        private CheatEngineLibrary lib;
        private TScanOption scanopt;
        private TVariableType varopt;   

        private const int wm_scandone = 0x8000 + 2;
        protected override void WndProc(ref Message m)
        {            
            int size, i;
            if (m.Msg == wm_scandone)
            {

                lvScanner.VirtualListSize = 0;
                lvScanner.Items.Clear();                
                size = lib.iGetBinarySize();                
                lib.iInitFoundList(varopt, size, false, false, false, false);
                if (scanopt != TScanOption.soUnknownValue)
                {
                    i = Math.Min((int)lib.iCountAddressesFound(), 10000000);
                    lvScanner.VirtualListSize = i;
                }
                lblStatus.Text ="Найдено "+  lib.iCountAddressesFound().ToString()+ " адресов.";
                btnNextScan.Enabled = true;

                double currentValue;
                if (firstScan)
                {                    
                    double xMin = double.Parse(txtXValue.Text, NumberStyles.AllowDecimalPoint)-0.01d;
                    double xMax = double.Parse(txtXValue.Text, NumberStyles.AllowDecimalPoint)+0.01d;
                    double yMin = double.Parse(txtYValue.Text, NumberStyles.AllowDecimalPoint)-0.01d;
                    double yMax = double.Parse(txtYValue.Text, NumberStyles.AllowDecimalPoint)+0.01d;
                    double cMin = double.Parse(txtCValue.Text, NumberStyles.AllowDecimalPoint)-0.01d;
                    double cMax = double.Parse(txtCValue.Text, NumberStyles.AllowDecimalPoint)+0.01d;

                    for (int k = 0; k < lvScanner.Items.Count; k++)
                    {                        
                        Double.TryParse(lvScanner.Items[k].SubItems[1].Text, out currentValue);
                        if ((currentValue >= xMin) && (currentValue <= xMax))
                        {
                            xAdressList.Add(new AdressList(lvScanner.Items[k].SubItems[0].Text, lvScanner.Items[k].SubItems[1].Text));
                        }
                        if ((currentValue >= yMin) && (currentValue <= yMax))
                        {
                            yAdressList.Add(new AdressList(lvScanner.Items[k].SubItems[0].Text, lvScanner.Items[k].SubItems[1].Text));
                        }
                        if ((currentValue >= cMin) && (currentValue <= cMax))
                        {
                            cAdressList.Add(new AdressList(lvScanner.Items[k].SubItems[0].Text, lvScanner.Items[k].SubItems[1].Text));
                        }
                    }
                }
                else
                {    
                    BindingList<AdressList> xFirstAdressList = new BindingList<AdressList>();
                    for (int s = 0; s< xAdressList.Count; s++)
                    {
                        xFirstAdressList.Add(new AdressList(xAdressList[s].mAdress, xAdressList[s].mValue));
                    }                    
                    xAdressList.Clear();
                    BindingList<AdressList> yFirstAdressList = new BindingList<AdressList>();
                    for (int s = 0; s < yAdressList.Count; s++)
                    {
                        yFirstAdressList.Add(new AdressList(yAdressList[s].mAdress, yAdressList[s].mValue));
                    }
                    yAdressList.Clear();
                    BindingList<AdressList> cFirstAdressList = new BindingList<AdressList>();
                    for (int s = 0; s < cAdressList.Count; s++)
                    {
                        cFirstAdressList.Add(new AdressList(cAdressList[s].mAdress, cAdressList[s].mValue));
                    }
                    cAdressList.Clear();

                    double xMin = double.Parse(txtXValue.Text, NumberStyles.AllowDecimalPoint) - 0.01d;
                    double xMax = double.Parse(txtXValue.Text, NumberStyles.AllowDecimalPoint) + 0.01d;
                    double yMin = double.Parse(txtYValue.Text, NumberStyles.AllowDecimalPoint) - 0.01d;
                    double yMax = double.Parse(txtYValue.Text, NumberStyles.AllowDecimalPoint) + 0.01d;
                    double cMin = double.Parse(txtCValue.Text, NumberStyles.AllowDecimalPoint) - 0.01d;
                    double cMax = double.Parse(txtCValue.Text, NumberStyles.AllowDecimalPoint) + 0.01d;
                    for (int k = 0; k < lvScanner.Items.Count; k++)
                    {                        
                        Double.TryParse(lvScanner.Items[k].SubItems[1].Text, out currentValue);
                        if ((currentValue >= xMin) && (currentValue <= xMax))
                        {
                            for (int z=0;z< xFirstAdressList.Count; z++)
                            {                                
                                if (xFirstAdressList[z].mAdress.Equals(lvScanner.Items[k].SubItems[0].Text))
                                {                                    
                                    xAdressList.Add(new AdressList(lvScanner.Items[k].SubItems[0].Text, lvScanner.Items[k].SubItems[1].Text));
                                }
                            }                            
                        }
                        if ((currentValue >= yMin) && (currentValue <= yMax))
                        {
                            for (int z = 0; z < yFirstAdressList.Count; z++)
                            {
                                if (yFirstAdressList[z].mAdress.Equals(lvScanner.Items[k].SubItems[0].Text))
                                {
                                    yAdressList.Add(new AdressList(lvScanner.Items[k].SubItems[0].Text, lvScanner.Items[k].SubItems[1].Text));
                                }
                            }
                        }
                        if ((currentValue >= cMin) && (currentValue <= cMax))
                        {
                            for (int z = 0; z < cFirstAdressList.Count; z++)
                            {
                                if (cFirstAdressList[z].mAdress.Equals(lvScanner.Items[k].SubItems[0].Text))
                                {
                                    cAdressList.Add(new AdressList(lvScanner.Items[k].SubItems[0].Text, lvScanner.Items[k].SubItems[1].Text));
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        public Form1()
        {
            data = new BindingList<FishPath>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            xAdressList = new BindingList<AdressList>();
            yAdressList = new BindingList<AdressList>();
            cAdressList = new BindingList<AdressList>(); 
            InitializeComponent();
            UserOptions.LoadSettings();//Загружаем настройки программы
            stopAction = false;
            //Подвязываем коллеции к таблицам
            dataGridView1.DataSource = data;
            dgvXAdressList.DataSource = xAdressList;
            dgvYAdressList.DataSource = yAdressList;
            dgvCAdressList.DataSource = cAdressList;
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 70;
            dgvXAdressList.Columns[0].Width = 90;
            dgvXAdressList.Columns[1].Width = 90;
            dgvYAdressList.Columns[0].Width = 90;
            dgvYAdressList.Columns[1].Width = 90;
            dgvCAdressList.Columns[0].Width = 90;
            dgvCAdressList.Columns[1].Width = 90;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - Convert.ToInt32(this.Height*1.5));//Переносим окно в левый нижний угол
            this.TopMost = true;
            cmbSelect.SelectedIndex = Properties.Settings.Default.SelectListAction; //Загружаем вариант по умолчанию из настроек           
            //Инициализируем классы
            esoWindow = new EsoWindow();            
            esoWindow.SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);//Сбрасываем счетчик выключения монитора         
            hero = new Hero();            
            fishHelperFile = new FishHelperFile();
            lib = new CheatEngineLibrary();
            lib.loadEngine();
            if (UserOptions.defaultFiles)
            {
                fishHelperFile.OpenFilePath(UserOptions.defaultPathFile, data);                
                fishHelperFile.OpenAdressFileAction(UserOptions.defaultAdressFile, textBoxCoordX, textBoxCoordY, textBoxCorner);
            }
        }

        //Делаем окно Always on Top
        private void chkbAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (UserOptions.alwaysOnTop)
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
                //Активируем окно, прожимаем дважды кнопку мыши 
                ActivateEsoWindow();

                hero.turnCornerVer2(esoWindow, textBoxCorner.Text, processHandle, txtTargetCorner.Text);

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
            if (UserOptions.hideToNotify) Hide(); //Если выбрано, что скрывать в панель уведомлений, то скрываем
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            Thread MyThread1 = new Thread(delegate ()
            {
                //Активируем окно, прожимаем дважды кноку мыши 
                ActivateEsoWindow();

            hero.Fishing(esoWindow, hWnd);

            esoWindow.CloseHandle(processHandle);
            });
            MyThread1.Start();
            MyThread1.Join();
            if (UserOptions.hideToNotify) //Восстанавливаем окно после того, как рыбалка закончена
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
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
            bool fishCycle = false;
            stopAction = false;
            if (UserOptions.hideToNotify) Hide(); //Если выбрано, что скрывать в панель уведомлений, то скрываем

            do
            {
                if (stopAction) break;
                RunAndFish(0);
                if (stopAction) break;
                if (cmbSelect.SelectedIndex == 1) fishCycle = true;
                if(cmbSelect.SelectedIndex == 2)
                {
                    RunAndFishBack(data.Count-1);
                    fishCycle = true;
                }

            } while (fishCycle);

            if (UserOptions.hideToNotify)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void RunAndFish(int count)
        {       
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            Thread MyThread1 = new Thread(delegate ()
             {
                 Random random = new Random();                 

                 //Активируем окно, прожимаем дважды кноку мыши 
                 ActivateEsoWindow();

                 for (int i = count; i < data.Count; i++)
                 {
                     if (stopAction) return;
                     esoWindow.SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);//Сбрасываем счетчик выключения монитора
                     SetRowColor(i);
                     if (data[i].holeType == true)
                     {
                         //Бежим к цели и потом рыбачим
                         hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, data[i].xCoord, data[i].yCoord, data[i].tCorner);
                         //Thread.Sleep(random.Next(1000, 2000));
                         hero.Fishing(esoWindow, hWnd);
                         //Thread.Sleep(random.Next(1000, 2000));
                     } else if (data[i].harvest == true)
                     {
                         //Бежим к цели и потом собираем ресурс
                         hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, data[i].xCoord, data[i].yCoord, data[i].tCorner);
                         //Thread.Sleep(random.Next(500, 1000));
                         hero.GatheringResources(esoWindow, hWnd);
                         Thread.Sleep(random.Next(3000, 4000)); //Дожидаемся, пока ресурс соберется
                     }
                     else
                     {
                         //Бежим к цели
                         hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, data[i].xCoord, data[i].yCoord, data[i].tCorner);
                         //Thread.Sleep(random.Next(1000, 2000));
                     }
                 }
                 esoWindow.CloseHandle(processHandle);
             });
            MyThread1.Start();
            MyThread1.Join();           

        }

        //Бежим и рыбачим в обратном порядке
        private void RunAndFishBack(int count)
        {
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            Thread MyThread1 = new Thread(delegate ()
            {
                Random random = new Random();

                //Активируем окно, прожимаем дважды кноку мыши 
                ActivateEsoWindow();

                for (int i = count; i >= 0; i--)
                {
                    if (stopAction) return;
                    esoWindow.SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);//Сбрасываем счетчик выключения монитора   
                    SetRowColor(i);
                    if (data[i].holeType == true)
                    {
                        //Бежим к цели и потом рыбачим
                        hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, data[i].xCoord, data[i].yCoord, data[i].tCorner);
                        //Thread.Sleep(random.Next(1000, 2000));                       
                        hero.Fishing(esoWindow, hWnd);
                        //Thread.Sleep(random.Next(1000, 2000));
                    }
                    else if (data[i].harvest == true)
                    {
                        //Бежим к цели и потом собираем ресурс
                        hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, data[i].xCoord, data[i].yCoord, data[i].tCorner);
                        //Thread.Sleep(random.Next(500, 1000));
                        hero.GatheringResources(esoWindow, hWnd);
                        Thread.Sleep(random.Next(3000, 4000)); //Дожидаемся, пока ресурс соберется
                    }
                    else
                    {
                        //Бежим к цели
                        hero.Run(esoWindow, processHandle, hWnd, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text, data[i].xCoord, data[i].yCoord, data[i].tCorner);
                        //Thread.Sleep(random.Next(1000, 2000));
                    }
                }
                esoWindow.CloseHandle(processHandle);
            });
            MyThread1.Start();
            MyThread1.Join();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();        
        }

        //Обработка нажатия функциональных клавиш
        void _listener_OnKeyPressed(object sender, KeyPressedArgs e){            
            String ePress = Convert.ToString(e.KeyPressed);            
            if (ePress.Equals(Convert.ToString((FunctionKeys)UserOptions.cancelAction)))
            {
                stopAction = true;
                return;
            }
            if (ePress.Equals(Convert.ToString((FunctionKeys)UserOptions.goGoGo)))
            {
                btnGoGoGo_Click(null, null);
                return;
            }
            if (ePress.Equals(Convert.ToString((FunctionKeys)UserOptions.goSelect)))
            {
                btnGoSelect_Click(null, null);
                return;
            }
            if (ePress.Equals(Convert.ToString((FunctionKeys)UserOptions.backSelect)))
            {
                btnBackSelect_Click(null, null);
                return;
            }
            if (ePress.Equals(Convert.ToString((FunctionKeys)UserOptions.fishing)))
            {
                btnFishing_Click(null, null);
                return;
            }
            if (ePress.Equals(Convert.ToString((FunctionKeys)UserOptions.fishingVer2)))
            {
                btnFishingVer2_Click(null, null);
                return;
            }
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
            bool fishCycle = false;
            stopAction = false;
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                if (oneCell.Selected) count = oneCell.RowIndex;                   
            }
            if (UserOptions.hideToNotify) Hide(); //Если выбрано, что скрывать в панель уведомлений, то скрываем
            do
            {
                if (stopAction) break;
                RunAndFish(count);
                if (stopAction) break;
                if (cmbSelect.SelectedIndex == 1)
                {
                    count = 0;
                    fishCycle = true;
                }
                if (cmbSelect.SelectedIndex == 2)
                {
                    RunAndFishBack(data.Count - 1);
                    count = 0;
                    fishCycle = true;
                }

            } while (fishCycle);

            if (UserOptions.hideToNotify)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
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
                    hero.turnCornerVer2(esoWindow, textBoxCorner.Text, processHandle,Convert.ToString(acturalCorner - 180));
                }
                else
                {
                    hero.turnCornerVer2(esoWindow, textBoxCorner.Text, processHandle, Convert.ToString(acturalCorner + 180));
                }

                Thread.Sleep(random.Next(1000, 2000));

                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr((ushort)Keys.W), new IntPtr(0));
                Thread.Sleep(random.Next(2000, 3000));
                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr((ushort)Keys.W), new IntPtr(0));

                esoWindow.CloseHandle(processHandle);
            })).Start();
        }
              
        //Автоматическая номерация строк
        private void dataGridView1_RowPrePaint_1(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView1.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView1.Rows[index].HeaderCell.Value = indexStr;
        }

        private void btnBackSelect_Click(object sender, EventArgs e)
        {
            int count = 0;
            bool fishCycle = false;
            stopAction = false;
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                if (oneCell.Selected) count = oneCell.RowIndex;
            }
            if (UserOptions.hideToNotify) Hide(); //Если выбрано, что скрывать в панель уведомлений, то скрываем
            do
            {
                if (stopAction) break;
                RunAndFishBack(count);
                if (stopAction) break;
                if (cmbSelect.SelectedIndex == 1)
                {
                    count = 0;
                    fishCycle = true;
                }
                if (cmbSelect.SelectedIndex == 2)
                {
                    RunAndFishBack(data.Count - 1);
                    count = 0;
                    fishCycle = true;
                }

            } while (fishCycle);
            if (UserOptions.hideToNotify)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

       //Задаем цвет строки
       private void SetRowColor(int i)
        {
            for (int j = 0; j < data.Count; j++)
            {
                dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.White;
            }
            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;            
       }

        //При сворачивании окна - отправляем его в трей
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized&&UserOptions.hideToNotify) Hide();
        }

        //Восстанавливаем окно
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        //Открываем форму настроек
        private void OptionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();            
            optionsForm.Owner = this;
            optionsForm.StartPosition = FormStartPosition.Manual;
            optionsForm.Location = new Point(this.Location.X+(this.Width - optionsForm.Width)/2, this.Location.Y + (this.Height - optionsForm.Height) / 2);                
            this.TopMost = false;
            optionsForm.ShowDialog();
        }

        //Отрабатывает каждый раз, когда форме передается фокус
        private void Form1_Activated(object sender, EventArgs e)
        {
            //Определяем, отображать форму поверх всех окон или нет
            if (UserOptions.alwaysOnTop)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }

            cmbSelect.SelectedIndex = Properties.Settings.Default.SelectListAction; //Загружаем вариант из настроек
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {

            ((Form1)this.Owner).textBoxCoordX.Text = "Работает"; //Передаем в родительскую форму данные.

            Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            lib.loadEngine();
        }    
               
        private void lvScanner_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            string address, value;
            try
            {
                ListViewItem lvi = new ListViewItem(); 	// create a listviewitem object
                lib.iGetAddress(e.ItemIndex, out address, out value);
                lvi.Text = address; 		// assign the text to the item
                ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem(); // subitem
                lvsi.Text = value; 	// the subitem text
                lvi.SubItems.Add(lvsi); 			// assign subitem to item
                e.Item = lvi; 		// assign item to event argument's item-property
            }
            catch (Exception ex)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lib.iResetValues();
            //lvScanner.Refresh();
        }                 

        private void btnNewScan_Click(object sender, EventArgs e)
        {
            lib.iNewScan();
            btnNextScan.Enabled = false;
            btnFirstScan.Enabled = true;
            lvScanner.VirtualListSize = 0;
            xAdressList.Clear();
            yAdressList.Clear();
            cAdressList.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lib.loadEngine();
        }

        private void btnFirstScan_Click(object sender, EventArgs e)
        {
            if (checkInputData()) {
                firstScan = true;
                double[] adressMassive = new double[6]
                {
                    double.Parse(txtXValue.Text, NumberStyles.AllowDecimalPoint)-0.01d,
                    double.Parse(txtXValue.Text, NumberStyles.AllowDecimalPoint)+0.01d,
                    double.Parse(txtYValue.Text, NumberStyles.AllowDecimalPoint)-0.01d,
                    double.Parse(txtYValue.Text, NumberStyles.AllowDecimalPoint)+0.01d,
                    double.Parse(txtCValue.Text, NumberStyles.AllowDecimalPoint)-0.01d,
                    double.Parse(txtCValue.Text, NumberStyles.AllowDecimalPoint)+0.01d
                };
                Tscanregionpreference writable = Tscanregionpreference.scanInclude,
                    executable = Tscanregionpreference.scanDontCare, copyOnWrite = Tscanregionpreference.scanExclude;                
                btnFirstScan.Enabled = false;

                writable = Tscanregionpreference.scanInclude;
                executable = Tscanregionpreference.scanDontCare;
                copyOnWrite = Tscanregionpreference.scanExclude;

                lib.iConfigScanner(writable, executable, copyOnWrite);
                lblStatus.Text = "Поиск начат. Ждите...";
                lib.iFirstScan(TScanOption.soValueBetween, TVariableType.vtDouble, TRoundingType.rtRounded, minDouble(adressMassive),
                 maxDouble(adressMassive), "$0000000000000000", "$7fffffffffffffff", false, false, false, false,
                 TFastScanMethod.fsmAligned, "4");
            }
            else
            {
                lblStatus.Text = "Не все значения заполнены!!!";
            }
        }

        //Определяем минимальное значение в массиве
        private String minDouble(double[] adressMassive)
        {
            double min = adressMassive[0];
            for (int i=0; i< adressMassive.Length; i++)
            {
                if (min > adressMassive[i])  min = adressMassive[i];
            }
            return Convert.ToString(min);
        }

        //Определяем максимальное значение в массиве
        private String maxDouble(double[] adressMassive)
        {
            double max = adressMassive[0];
            for (int i = 0; i < adressMassive.Length; i++)
            {
                if (max < adressMassive[i]) max = adressMassive[i];
            }
            return Convert.ToString(max);
        }

        //Проверяем, во все ли поля внесены данные.
        private bool checkInputData()
        {
            if (txtXValue.Text.Equals(""))
            {
                return false;
            }
            if (txtYValue.Text.Equals(""))
            {
                return false;
            }
            if (txtCValue.Text.Equals(""))
            {
                return false;
            }            
            return true;
        }

        private void btnNextScan_Click(object sender, EventArgs e)
        {            
            btnNextScan.Enabled = false;
            firstScan = false;
            double[] adressMassive = new double[6]
                {
                    double.Parse(txtXValue.Text, NumberStyles.AllowDecimalPoint)-0.01d,
                    double.Parse(txtXValue.Text, NumberStyles.AllowDecimalPoint)+0.01d,
                    double.Parse(txtYValue.Text, NumberStyles.AllowDecimalPoint)-0.01d,
                    double.Parse(txtYValue.Text, NumberStyles.AllowDecimalPoint)+0.01d,
                    double.Parse(txtCValue.Text, NumberStyles.AllowDecimalPoint)-0.01d,
                    double.Parse(txtCValue.Text, NumberStyles.AllowDecimalPoint)+0.01d
                };
            lib.iNextScan(TScanOption.soValueBetween, TRoundingType.rtRounded, minDouble(adressMassive), maxDouble(adressMassive),
    false, false, false, false, false, false, "");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            int selectedIndex = tabControl1.SelectedIndex;   
            if (selectedIndex == 1)
            {
                hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
                var wHwnd = esoWindow.GetWindowThreadProcessId(hWnd, out pid);
                
                if (pid!=0)
                {
                    lib.iOpenProcess(pid.ToString("X"));
                    lib.iInitMemoryScanner(Process.GetCurrentProcess().MainWindowHandle.ToInt32());
                    lblStatus.Text = "Процесс обнаружен.";                    
                    scanopt = TScanOption.soValueBetween;
                    varopt = TVariableType.vtDouble;
                    btnNewScan.Enabled = true;
                    btnFirstScan.Enabled = true;
                }
                else
                {
                    lblStatus.Text = "ESO не обнаружен.";
                }
            }            
        }                           

        private void btnXAdressCopy_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgvXAdressList.SelectedCells)
            {

                if (oneCell.Selected)
                    textBoxCoordX.Text = (String)dgvXAdressList[0, oneCell.RowIndex].Value; 
            }
        }

        private void btnYAdressCopy_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgvYAdressList.SelectedCells)
            {

                if (oneCell.Selected)
                    textBoxCoordY.Text = (String)dgvYAdressList[0, oneCell.RowIndex].Value;
            }
        }

        private void btnCAdressCopy_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgvCAdressList.SelectedCells)
            {

                if (oneCell.Selected)
                    textBoxCorner.Text = (String)dgvCAdressList[0, oneCell.RowIndex].Value;
            }
        }

        private void saveAdressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fishHelperFile.SaveAdressFileAs(saveFileDialogAdressFile, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text);
        }

        private void btnSaveToDefaultAdressFile_Click(object sender, EventArgs e)
        {
            fishHelperFile.SaveAdressFileAction(UserOptions.defaultAdressFile, textBoxCoordX.Text, textBoxCoordY.Text, textBoxCorner.Text);
        }

        private void btnXValue_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtXValue.Text = "";
            txtYValue.Text = "";
            txtCValue.Text = "";
        }

        private void btnCopyAdresses_Click(object sender, EventArgs e)
        {
            textBoxCoordX.Text = xAdressList[xAdressList.Count - 1].mAdress;
            textBoxCoordY.Text = yAdressList[yAdressList.Count - 1].mAdress;
            textBoxCorner.Text = cAdressList[cAdressList.Count - 1].mAdress;
        }

        //Переводим графические значения в текстовые
        private void btnOCR_Click(object sender, EventArgs e)
        {
            var Ocr = new AutoOcr();
            txtXValue.Text = "";
            txtYValue.Text = "";
            txtCValue.Text = "";
            Bitmap bitmap = new Bitmap(148, 28); //Задаем размер считываемой области
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(UserOptions.esoLocateX, UserOptions.esoLocateY, 0, 0, bitmap.Size); // Задаем первыми двумя цифрами координаты начала (верхний левый угол) считываемого прямоугольника            
            var Result = Ocr.Read(bitmap);
            string[] str = Result.Text.Split(' ');
            for (int i=0;i<str.Length;i++)
            {
                switch (i)
                {
                    case 0:
                        txtXValue.Text = str[i].Replace('.',',');
                        break;
                    case 1:
                        txtYValue.Text = str[i].Replace('.', ',');
                        break;
                    case 2:
                        txtCValue.Text = str[i].Replace('.', ',');
                        break;
                }
            }            
        }

        private void btnYValue_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void btnCValue_KeyPress(object sender, KeyPressEventArgs e)
        {
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
    }
}
