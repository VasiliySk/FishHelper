﻿using System;
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
        public static int selectListAction { get; set; }
        public static int cancelAction { get; set; }
        public static int goGoGo { get; set; }
        public static int goSelect { get; set; }
        public static int backSelect { get; set; }
        public static int fishing { get; set; }
        public static int fishingVer2 { get; set; }

        public enum FunctionKeys
        {
            Нет,F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12
        }

        //Сохраняем настройки
        public static void SaveSettings()
        {
            Properties.Settings.Default.AlwaysOnTop = alwaysOnTop;
            Properties.Settings.Default.HideToNotify = hideToNotify;
            Properties.Settings.Default.SelectListAction = selectListAction;
            Properties.Settings.Default.CancelAction = cancelAction;
            Properties.Settings.Default.GoGoGo = goGoGo;
            Properties.Settings.Default.GoSelect = goSelect;
            Properties.Settings.Default.BackSelect = backSelect;
            Properties.Settings.Default.Fishing = fishing;
            Properties.Settings.Default.FishingVer2 = fishingVer2;
            Properties.Settings.Default.Save();
        }

        //Загружаем настройки
        public static void LoadSettings()
        {
            alwaysOnTop = Properties.Settings.Default.AlwaysOnTop;
            hideToNotify = Properties.Settings.Default.HideToNotify;
            selectListAction = Properties.Settings.Default.SelectListAction;
            cancelAction = Properties.Settings.Default.CancelAction;
            goGoGo = Properties.Settings.Default.GoGoGo;
            goSelect = Properties.Settings.Default.GoSelect;
            backSelect = Properties.Settings.Default.BackSelect;
            fishing = Properties.Settings.Default.Fishing;
            fishingVer2 = Properties.Settings.Default.FishingVer2;
        }
    }
}