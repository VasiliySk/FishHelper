using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FishHelper.UserOptions;

namespace FishHelper
{
    public partial class OptionsForm : Form
    {        
        public OptionsForm()
        {
            InitializeComponent();
            //Привязываем комбобоксы с перечню FunctionKeys
            cmbCancel.DataSource = Enum.GetValues(typeof(FunctionKeys));
            cmbGoGoGo.DataSource = Enum.GetValues(typeof(FunctionKeys));
            cmbGoSelect.DataSource = Enum.GetValues(typeof(FunctionKeys));
            cmbBackSelect.DataSource = Enum.GetValues(typeof(FunctionKeys));
            cmbFishing.DataSource = Enum.GetValues(typeof(FunctionKeys));
            cmbFishingVer2.DataSource = Enum.GetValues(typeof(FunctionKeys));

            //Загружаем настройки
            chkbAlwaysOnTop.Checked = UserOptions.alwaysOnTop;
            chkHideToNotify.Checked = UserOptions.hideToNotify;
            cmbSelect.SelectedIndex = UserOptions.selectListAction;
            cmbCancel.SelectedIndex = UserOptions.cancelAction;
            cmbGoGoGo.SelectedIndex = UserOptions.goGoGo;
            cmbGoSelect.SelectedIndex = UserOptions.goSelect;
            cmbBackSelect.SelectedIndex = UserOptions.backSelect;
            cmbFishing.SelectedIndex = UserOptions.fishing;
            cmbFishingVer2.SelectedIndex = UserOptions.fishingVer2;           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UserOptions.alwaysOnTop = chkbAlwaysOnTop.Checked;
            UserOptions.hideToNotify = chkHideToNotify.Checked;
            UserOptions.selectListAction = cmbSelect.SelectedIndex;
            UserOptions.cancelAction = cmbCancel.SelectedIndex;
            UserOptions.goGoGo = cmbGoGoGo.SelectedIndex;
            UserOptions.goSelect = cmbGoSelect.SelectedIndex;
            UserOptions.backSelect = cmbBackSelect.SelectedIndex;
            UserOptions.fishing = cmbFishing.SelectedIndex;
            UserOptions.fishingVer2 = cmbFishingVer2.SelectedIndex;
            UserOptions.SaveSettings();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
