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
            data.Clear();
            Stream mystr = null;
            openFileDialog1.Filter = "Fish Helper files (*.fhf)|*.fhf";
            this.data = data;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystr = openFileDialog1.OpenFile()) != null)
                {
                    filePath = openFileDialog1.FileName;
                    StreamReader myread = new StreamReader(mystr);
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
                            for (int j = 0; j < 4; j++)
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
                                            string replacement = Regex.Replace(str[j], @"\t|\n|\r", ""); //Удаляем знак перехода строки
                                            if (replacement.Equals("true"))
                                            {
                                                fishPath.holeType = true;
                                            }
                                            else
                                            {
                                                fishPath.holeType = false;
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
                        saveToolStripMenuItem.Enabled = true;
                    }
                    catch { }
                }
            }
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
                    for (int j = 0; j < 4; j++)
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
    }
}
