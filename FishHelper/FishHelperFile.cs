using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishHelper
{
    //Класс, отвечающий за чтение и сохранение файлов.
    class FishHelperFile
    {
        private String filePath;
        private BindingList<FishPath> data;

        //Открываем файл
        public void OpenFile(OpenFileDialog openFileDialog1, BindingList<FishPath> data, ToolStripMenuItem saveToolStripMenuItem)
        {            
            Stream mystr = null;
            openFileDialog1.Filter = "Fish Helper files (*.fhf)|*.fhf";
            openFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments)+ "\\My Cheat Tables\\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                if ((mystr = openFileDialog1.OpenFile()) != null)
                {
                    filePath = openFileDialog1.FileName;
                    OpenFilePath(filePath,data);
                    saveToolStripMenuItem.Enabled = true;
                }
            }
        }

        //Открываем файл с данными маршрута
        public void OpenFilePath(String filePath, BindingList<FishPath> data)
        {
            data.Clear();
            this.data = data;
            StreamReader myread;
            //Обработка ошибки, если файл не найден
            try
            {
                myread = new StreamReader(filePath);
            }
            catch (System.IO.FileNotFoundException)
            {
                return;
            }
            string[] str;
            int num = 0;
            try
            {
                string[] str1 = myread.ReadToEnd().Split('\n');
                num = str1.Length;
                for (int i = 0; i < num; i++)
                {
                    str = str1[i].Split(' ');
                    FishPath fishPath = new FishPath();
                    string replacement;
                    for (int j = 0; j < 5; j++)
                    {
                        try
                        {
                            switch (j)
                            {
                                case 0:
                                    fishPath.xCoord = str[j];
                                    break;
                                case 1:
                                    fishPath.yCoord = str[j];
                                    break;
                                case 2:
                                    fishPath.tCorner = str[j];
                                    break;
                                case 3:
                                    replacement = Regex.Replace(str[j], @"\t|\n|\r", ""); //Удаляем знак перехода строки
                                    if (replacement.Equals("true"))
                                    {
                                        fishPath.holeType = true;
                                    }
                                    else
                                    {
                                        fishPath.holeType = false;
                                    }
                                    break;
                                case 4:
                                    if (str.Length == 4)
                                    {
                                        fishPath.harvest = false;
                                    }
                                    else
                                    {
                                        replacement = Regex.Replace(str[j], @"\t|\n|\r", ""); //Удаляем знак перехода строки
                                        if (replacement.Equals("true"))
                                        {
                                            fishPath.harvest = true;
                                        }
                                        else
                                        {
                                            fishPath.harvest = false;
                                        }
                                    }
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            myread.Close();
                        }
                    }
                    data.Add(fishPath);
                }                
            }
            catch { }
        }

        //Сохраняем файл
        public void SaveFile()
        {            
            StreamWriter myWriter = new StreamWriter(filePath);
            WriteToFile(myWriter);
        }

        //Сохраняем файл как...
        public void SaveFileAs(SaveFileDialog saveFileDialog, BindingList<FishPath> data, ToolStripMenuItem saveToolStripMenuItem)
        {
            Stream myStream;
            this.data = data;
            saveFileDialog.Filter = "Fish Helper files (*.fhf)|*.fhf";
            saveFileDialog.DefaultExt = "fhf";
            saveFileDialog.AddExtension=true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if((myStream= saveFileDialog.OpenFile()) != null)                    
                {
                    filePath = saveFileDialog.FileName;
                    StreamWriter myWriter = new StreamWriter(myStream);
                    WriteToFile(myWriter);
                    myStream.Close();
                    saveToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void WriteToFile(StreamWriter myWriter)
        {            
            try
            {                
                for (int i = 0; i < data.Count; i++)
                {                    
                    for (int j = 0; j < 5; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                myWriter.Write(data[i].xCoord);
                                myWriter.Write(" ");
                                break;
                            case 1:
                                myWriter.Write(data[i].yCoord);
                                myWriter.Write(" ");
                                break;
                            case 2:
                                myWriter.Write(data[i].tCorner);
                                myWriter.Write(" ");
                                break;
                            case 3:
                                if (data[i].holeType)
                                {
                                    myWriter.Write("true");
                                }
                                else
                                {
                                    myWriter.Write("false");
                                }
                                myWriter.Write(" ");
                                break;
                            case 4:
                                if (data[i].harvest)
                                {
                                    myWriter.Write("true");
                                }
                                else
                                {
                                    myWriter.Write("false");
                                }
                                break;
                        }
                    }
                    if (i < data.Count - 1) myWriter.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myWriter.Close();
            }                      
        }

        //Открываем файл с адресами CheatEngine и загружаем в программу
        public void OpenAdressFile(OpenFileDialog openFileDialog2, TextBox textBoxCoordX, TextBox textBoxCoordY, TextBox textBoxCorner)
        {            
            openFileDialog2.Filter = "Cheat Engine files (*.CT)|*.CT";
            openFileDialog2.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments) + "\\My Cheat Tables\\";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {                
                if ((openFileDialog2.OpenFile()) != null)
                {
                    OpenAdressFileAction(openFileDialog2.FileName, textBoxCoordX, textBoxCoordY, textBoxCorner);
                }
            }
        }

        public void OpenAdressFileAction(String path, TextBox textBoxCoordX, TextBox textBoxCoordY, TextBox textBoxCorner)
        {
            StreamReader myread;
            //Обработка ошибки, если файл не найден
            try
            {
                myread = new StreamReader(path);
            }
            catch (System.IO.FileNotFoundException)
            {
                return;
            }

            int num = 0;
            int adressCount = 0;
            try
            {
                string[] str1 = myread.ReadToEnd().Split('\n');
                num = str1.Length;
                for (int i = 0; i < num; i++)
                {
                    if (str1[i].Contains("RealAddress"))
                    {
                        int indexStartOfAdress = str1[i].IndexOf("RealAddress=") + 12; //Определяем место начала адреса
                        int indexFinishOfAdress = str1[i].IndexOf("/>"); //Определяем место начала адреса                                

                        switch (adressCount)
                        {
                            case 0:
                                textBoxCoordX.Text = str1[i].Substring(indexStartOfAdress + 1, indexFinishOfAdress - indexStartOfAdress - 2); //Вырезаем адрес из найденной строки
                                adressCount++;
                                break;
                            case 1:
                                textBoxCoordY.Text = str1[i].Substring(indexStartOfAdress + 1, indexFinishOfAdress - indexStartOfAdress - 2); //Вырезаем адрес из найденной строки
                                adressCount++;
                                break;
                            case 2:
                                textBoxCorner.Text = str1[i].Substring(indexStartOfAdress + 1, indexFinishOfAdress - indexStartOfAdress - 2); //Вырезаем адрес из найденной строки
                                adressCount++;
                                break;
                        }
                    }
                }
            }
            catch { }
            finally { myread.Close(); }
        }

        //Сохраняем в файл данные об адресах.
        public void SaveAdressFileAs(SaveFileDialog saveFileDialog, String xAdress, String yAdress, String cAdress)
        {
            Stream myStream = null;
            saveFileDialog.Filter = "Cheat Engine files (*.CT)|*.CT";
            saveFileDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments) + "\\My Cheat Tables\\"; 
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream= saveFileDialog.OpenFile()) != null)
                {
                    SaveAdressFileAction(myStream, xAdress, yAdress, cAdress);
                    myStream.Close();
                }
            }          
        }

        public void SaveAdressFileAction (String path, String xAdress, String yAdress, String cAdress)
        {
            const string quote = "\"";
            StreamWriter myWriter = new StreamWriter(path);
            myWriter.Write("<RealAddress=" + quote + xAdress + quote + "/>");
            myWriter.WriteLine();
            myWriter.Write("<RealAddress=" + quote + yAdress + quote + "/>");
            myWriter.WriteLine();
            myWriter.Write("<RealAddress=" + quote + cAdress + quote + "/>");
            myWriter.WriteLine();
            myWriter.Close();
            
        }
        public void SaveAdressFileAction(Stream myStream, String xAdress, String yAdress, String cAdress)
        {
            const string quote = "\"";
            StreamWriter myWriter = new StreamWriter(myStream);
            myWriter.Write("<RealAddress=" + quote + xAdress + quote + "/>");
            myWriter.WriteLine();
            myWriter.Write("<RealAddress=" + quote + yAdress + quote + "/>");
            myWriter.WriteLine();
            myWriter.Write("<RealAddress=" + quote + cAdress + quote + "/>");
            myWriter.WriteLine();
            myWriter.Close();

        }
    }
}
