using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishHelper
{
    //Класс, отвечающий за сохранение и загрузку настроек приложения
    public static class UserOptions
    {
        public static bool alwaysOnTop { get; set; }
        public static bool hideToNotify { get; set; }
        public static bool defaultFiles { get; set; }        
        public static int selectListAction { get; set; }
        public static String defaultPathFile { get; set; }
        public static String defaultAdressFile { get; set; }
        public static String defaultFilePackage { get; set; }
        public static int esoLocateX { get; set; }
        public static int esoLocateY { get; set; }
        public static int cancelAction { get; set; }
        public static int goGoGo { get; set; }
        public static int goSelect { get; set; }
        public static int backSelect { get; set; }
        public static int autoSearch { get; set; }
        public static int fishing { get; set; }
        public static int fishingVer2 { get; set; }
        public static bool autoStartServer { get; set; }
        public static int portServer { get; set; }
        public static int widthServer { get; set; }
        public static int heightServer { get; set; }
        public static String caviarPrice { get; set; }
        public static String ambroziaPrice { get; set; }
        public static String baitPrice { get; set; }
        public static String baitChance { get; set; }
        public static String miriamPrice { get; set; }
        public static String bervezPrice { get; set; }


        public enum FunctionKeys
        {
            Нет,F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12
        }

        //Сохраняем настройки
        public static void SaveSettings()
        {
            Properties.Settings.Default.AlwaysOnTop = alwaysOnTop;
            Properties.Settings.Default.HideToNotify = hideToNotify;
            Properties.Settings.Default.DefaultFiles = defaultFiles;            
            Properties.Settings.Default.SelectListAction = selectListAction;
            Properties.Settings.Default.DefaultPathFile = defaultPathFile;
            Properties.Settings.Default.DefaultAdressFile = defaultAdressFile;
            Properties.Settings.Default.DefaultFilePackage = defaultFilePackage;
            Properties.Settings.Default.ESOlocateX = esoLocateX;
            Properties.Settings.Default.ESOlocateY = esoLocateY;
            Properties.Settings.Default.CancelAction = cancelAction;
            Properties.Settings.Default.GoGoGo = goGoGo;
            Properties.Settings.Default.GoSelect = goSelect;
            Properties.Settings.Default.BackSelect = backSelect;
            Properties.Settings.Default.AutoSearch = autoSearch;
            Properties.Settings.Default.Fishing = fishing;
            Properties.Settings.Default.FishingVer2 = fishingVer2;
            Properties.Settings.Default.AutoStartServer = autoStartServer;
            Properties.Settings.Default.PortServer = portServer;
            Properties.Settings.Default.WidthServer = widthServer;
            Properties.Settings.Default.HeightServer = heightServer;
            Properties.Settings.Default.CaviarPrice = caviarPrice;
            Properties.Settings.Default.AmbroziaPrice = ambroziaPrice;
            Properties.Settings.Default.BaitPrice = baitPrice;
            Properties.Settings.Default.BaitChance = baitChance;
            Properties.Settings.Default.MiriamPrice = miriamPrice;
            Properties.Settings.Default.BervezPrice = bervezPrice;
            Properties.Settings.Default.Save();
        }

        //Загружаем настройки
        public static void LoadSettings()
        {
            alwaysOnTop = Properties.Settings.Default.AlwaysOnTop;
            hideToNotify = Properties.Settings.Default.HideToNotify;
            defaultFiles = Properties.Settings.Default.DefaultFiles;            
            selectListAction = Properties.Settings.Default.SelectListAction;
            defaultPathFile = Properties.Settings.Default.DefaultPathFile;
            defaultAdressFile = Properties.Settings.Default.DefaultAdressFile;
            defaultFilePackage = Properties.Settings.Default.DefaultFilePackage;
            esoLocateX = Properties.Settings.Default.ESOlocateX;
            esoLocateY = Properties.Settings.Default.ESOlocateY;
            cancelAction = Properties.Settings.Default.CancelAction;
            goGoGo = Properties.Settings.Default.GoGoGo;
            goSelect = Properties.Settings.Default.GoSelect;
            backSelect = Properties.Settings.Default.BackSelect;
            autoSearch = Properties.Settings.Default.AutoSearch;
            fishing = Properties.Settings.Default.Fishing;
            fishingVer2 = Properties.Settings.Default.FishingVer2;
            autoStartServer = Properties.Settings.Default.AutoStartServer;
            portServer = Properties.Settings.Default.PortServer;
            widthServer = Properties.Settings.Default.WidthServer;
            heightServer = Properties.Settings.Default.HeightServer;
            caviarPrice = Properties.Settings.Default.CaviarPrice;
            ambroziaPrice = Properties.Settings.Default.AmbroziaPrice;
            baitPrice = Properties.Settings.Default.BaitPrice;
            baitChance = Properties.Settings.Default.BaitChance;
            miriamPrice = Properties.Settings.Default.MiriamPrice;
            bervezPrice = Properties.Settings.Default.BervezPrice;
        }
    }
}
