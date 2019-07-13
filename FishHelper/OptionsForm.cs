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
            cmbAutoSearch.DataSource = Enum.GetValues(typeof(FunctionKeys));
            cmbFishing.DataSource = Enum.GetValues(typeof(FunctionKeys));
            cmbFishingVer2.DataSource = Enum.GetValues(typeof(FunctionKeys));

            //Загружаем настройки
            chkbAlwaysOnTop.Checked = UserOptions.alwaysOnTop;
            chkHideToNotify.Checked = UserOptions.hideToNotify;
            chkDefaultFiles.Checked = UserOptions.defaultFiles;            
            cmbSelect.SelectedIndex = UserOptions.selectListAction;
            txtDefaultFilePath.Text = UserOptions.defaultPathFile;
            txtDefaultFileAdress.Text = UserOptions.defaultAdressFile;
            txtESOlocateX.Text = Convert.ToString(UserOptions.esoLocateX);
            txtESOlocateY.Text = Convert.ToString(UserOptions.esoLocateY);
            cmbCancel.SelectedIndex = UserOptions.cancelAction;
            cmbGoGoGo.SelectedIndex = UserOptions.goGoGo;
            cmbGoSelect.SelectedIndex = UserOptions.goSelect;
            cmbBackSelect.SelectedIndex = UserOptions.backSelect;
            cmbAutoSearch.SelectedIndex = UserOptions.autoSearch;
            cmbFishing.SelectedIndex = UserOptions.fishing;
            cmbFishingVer2.SelectedIndex = UserOptions.fishingVer2;           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UserOptions.alwaysOnTop = chkbAlwaysOnTop.Checked;
            UserOptions.hideToNotify = chkHideToNotify.Checked;
            UserOptions.defaultFiles = chkDefaultFiles.Checked;            
            UserOptions.selectListAction = cmbSelect.SelectedIndex;
            UserOptions.defaultPathFile = txtDefaultFilePath.Text;
            UserOptions.defaultAdressFile = txtDefaultFileAdress.Text;
            UserOptions.esoLocateX = Convert.ToInt32(txtESOlocateX.Text);
            UserOptions.esoLocateY = Convert.ToInt32(txtESOlocateY.Text);
            UserOptions.cancelAction = cmbCancel.SelectedIndex;
            UserOptions.goGoGo = cmbGoGoGo.SelectedIndex;
            UserOptions.goSelect = cmbGoSelect.SelectedIndex;
            UserOptions.backSelect = cmbBackSelect.SelectedIndex;
            UserOptions.autoSearch = cmbAutoSearch.SelectedIndex;
            UserOptions.fishing = cmbFishing.SelectedIndex;
            UserOptions.fishingVer2 = cmbFishingVer2.SelectedIndex;
            UserOptions.SaveSettings();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }       

        private void btnSetDefaultFilePath_Click(object sender, EventArgs e)
        {
            openFileDialogPath.Filter = "Fish Helper files (*.fhf)|*.fhf";
            openFileDialogPath.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments) + "\\My Cheat Tables\\";
            if (openFileDialogPath.ShowDialog() == DialogResult.OK)
            {
                txtDefaultFilePath.Text = openFileDialogPath.FileName;
            }
        }

        private void btnSetDefaultFileAdress_Click(object sender, EventArgs e)
        {
            openFileDialogAdress.Filter = "Cheat Engine files (*.CT)|*.CT";
            openFileDialogAdress.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments) + "\\My Cheat Tables\\";
            if (openFileDialogAdress.ShowDialog() == DialogResult.OK)
            {
                txtDefaultFileAdress.Text = openFileDialogAdress.FileName;
            }
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
