namespace FishHelper
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCameraCorner = new System.Windows.Forms.Button();
            this.txtTargetCorner = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxXTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtboxYTarget = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTargetRun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFishing = new System.Windows.Forms.Button();
            this.btnRunAndFish = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnConsol = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAdressStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAdressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnGoGoGo = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnGoSelect = new System.Windows.Forms.Button();
            this.btnFishingVer2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.btnBackSelect = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lvScanner = new System.Windows.Forms.ListView();
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.btnNextScan = new System.Windows.Forms.Button();
            this.btnFirstScan = new System.Windows.Forms.Button();
            this.btnNewScan = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnClean = new System.Windows.Forms.Button();
            this.txtCValue = new System.Windows.Forms.TextBox();
            this.txtYValue = new System.Windows.Forms.TextBox();
            this.txtXValue = new System.Windows.Forms.TextBox();
            this.btnSaveToDefaultAdressFile = new System.Windows.Forms.Button();
            this.btnCAdressCopy = new System.Windows.Forms.Button();
            this.btnYAdressCopy = new System.Windows.Forms.Button();
            this.btnXAdressCopy = new System.Windows.Forms.Button();
            this.btbTestAdress = new System.Windows.Forms.Button();
            this.lblCorner = new System.Windows.Forms.Label();
            this.lblCoordY = new System.Windows.Forms.Label();
            this.lblCoordX = new System.Windows.Forms.Label();
            this.textBoxCorner = new System.Windows.Forms.TextBox();
            this.labelTargetCorner = new System.Windows.Forms.Label();
            this.textBoxCoordY = new System.Windows.Forms.TextBox();
            this.labelTargetY = new System.Windows.Forms.Label();
            this.textBoxCoordX = new System.Windows.Forms.TextBox();
            this.labelTargetX = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvCAdressList = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvYAdressList = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvXAdressList = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.saveFileDialogAdressFile = new System.Windows.Forms.SaveFileDialog();
            this.btnCopyAdresses = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAdressList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYAdressList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXAdressList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCameraCorner
            // 
            this.btnCameraCorner.Location = new System.Drawing.Point(295, 500);
            this.btnCameraCorner.Name = "btnCameraCorner";
            this.btnCameraCorner.Size = new System.Drawing.Size(132, 26);
            this.btnCameraCorner.TabIndex = 12;
            this.btnCameraCorner.Text = "Поворот камеры";
            this.btnCameraCorner.UseVisualStyleBackColor = true;
            this.btnCameraCorner.Click += new System.EventHandler(this.btnCameraCorner_Click);
            // 
            // txtTargetCorner
            // 
            this.txtTargetCorner.Location = new System.Drawing.Point(295, 440);
            this.txtTargetCorner.Name = "txtTargetCorner";
            this.txtTargetCorner.Size = new System.Drawing.Size(132, 20);
            this.txtTargetCorner.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Целевой угол поворота";
            // 
            // txtboxXTarget
            // 
            this.txtboxXTarget.Location = new System.Drawing.Point(3, 440);
            this.txtboxXTarget.Name = "txtboxXTarget";
            this.txtboxXTarget.Size = new System.Drawing.Size(132, 20);
            this.txtboxXTarget.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "X координата";
            // 
            // txtboxYTarget
            // 
            this.txtboxYTarget.Location = new System.Drawing.Point(150, 440);
            this.txtboxYTarget.Name = "txtboxYTarget";
            this.txtboxYTarget.Size = new System.Drawing.Size(132, 20);
            this.txtboxYTarget.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Y координата";
            // 
            // btnTargetRun
            // 
            this.btnTargetRun.Location = new System.Drawing.Point(3, 466);
            this.btnTargetRun.Name = "btnTargetRun";
            this.btnTargetRun.Size = new System.Drawing.Size(132, 28);
            this.btnTargetRun.TabIndex = 19;
            this.btnTargetRun.Text = "Бежим к цели";
            this.btnTargetRun.UseVisualStyleBackColor = true;
            this.btnTargetRun.Click += new System.EventHandler(this.btnTargetRun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Тестовые функции. Удалить после отладки";
            // 
            // btnFishing
            // 
            this.btnFishing.Location = new System.Drawing.Point(150, 466);
            this.btnFishing.Name = "btnFishing";
            this.btnFishing.Size = new System.Drawing.Size(132, 28);
            this.btnFishing.TabIndex = 21;
            this.btnFishing.Text = "Рыбачим!";
            this.btnFishing.UseVisualStyleBackColor = true;
            this.btnFishing.Click += new System.EventHandler(this.btnFishing_Click);
            // 
            // btnRunAndFish
            // 
            this.btnRunAndFish.Location = new System.Drawing.Point(295, 466);
            this.btnRunAndFish.Name = "btnRunAndFish";
            this.btnRunAndFish.Size = new System.Drawing.Size(132, 28);
            this.btnRunAndFish.TabIndex = 22;
            this.btnRunAndFish.Text = "Бежим и рыбачим";
            this.btnRunAndFish.UseVisualStyleBackColor = true;
            this.btnRunAndFish.Click += new System.EventHandler(this.btnRunAndFish_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(422, 285);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint_1);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(135, 293);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(119, 28);
            this.btnRemoveRow.TabIndex = 24;
            this.btnRemoveRow.Text = "Удалить строку";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnConsol
            // 
            this.btnConsol.Location = new System.Drawing.Point(3, 500);
            this.btnConsol.Name = "btnConsol";
            this.btnConsol.Size = new System.Drawing.Size(132, 28);
            this.btnConsol.TabIndex = 25;
            this.btnConsol.Text = "Консоль";
            this.btnConsol.UseVisualStyleBackColor = true;
            this.btnConsol.Click += new System.EventHandler(this.btnConsol_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(3, 293);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(126, 28);
            this.btnAddRow.TabIndex = 26;
            this.btnAddRow.Text = "Добавить строку";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(435, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openAdressStripMenuItem,
            this.saveAdressToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // openAdressStripMenuItem
            // 
            this.openAdressStripMenuItem.Name = "openAdressStripMenuItem";
            this.openAdressStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.openAdressStripMenuItem.Text = "Открыть файл с адресами";
            this.openAdressStripMenuItem.Click += new System.EventHandler(this.openAdressStripMenuItem1_Click);
            // 
            // saveAdressToolStripMenuItem
            // 
            this.saveAdressToolStripMenuItem.Name = "saveAdressToolStripMenuItem";
            this.saveAdressToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.saveAdressToolStripMenuItem.Text = "Сохранить файл с адресами";
            this.saveAdressToolStripMenuItem.Click += new System.EventHandler(this.saveAdressToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionToolStripMenuItem1});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // OptionToolStripMenuItem1
            // 
            this.OptionToolStripMenuItem1.Name = "OptionToolStripMenuItem1";
            this.OptionToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.OptionToolStripMenuItem1.Text = "Настройки";
            this.OptionToolStripMenuItem1.Click += new System.EventHandler(this.OptionToolStripMenuItem1_Click);
            // 
            // btnGoGoGo
            // 
            this.btnGoGoGo.Location = new System.Drawing.Point(260, 293);
            this.btnGoGoGo.Name = "btnGoGoGo";
            this.btnGoGoGo.Size = new System.Drawing.Size(165, 28);
            this.btnGoGoGo.TabIndex = 28;
            this.btnGoGoGo.Text = "Вперед по списку!";
            this.btnGoGoGo.UseVisualStyleBackColor = true;
            this.btnGoGoGo.Click += new System.EventHandler(this.btnGoGoGo_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnGoSelect
            // 
            this.btnGoSelect.Location = new System.Drawing.Point(3, 327);
            this.btnGoSelect.Name = "btnGoSelect";
            this.btnGoSelect.Size = new System.Drawing.Size(220, 28);
            this.btnGoSelect.TabIndex = 29;
            this.btnGoSelect.Text = "Вперед с выбранного пункта";
            this.btnGoSelect.UseVisualStyleBackColor = true;
            this.btnGoSelect.Click += new System.EventHandler(this.btnGoSelect_Click);
            // 
            // btnFishingVer2
            // 
            this.btnFishingVer2.Location = new System.Drawing.Point(150, 500);
            this.btnFishingVer2.Name = "btnFishingVer2";
            this.btnFishingVer2.Size = new System.Drawing.Size(132, 28);
            this.btnFishingVer2.TabIndex = 30;
            this.btnFishingVer2.Text = "Рыбачим ver2";
            this.btnFishingVer2.UseVisualStyleBackColor = true;
            this.btnFishingVer2.Click += new System.EventHandler(this.btnFishingVer2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "После окончания списка:";
            // 
            // cmbSelect
            // 
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Items.AddRange(new object[] {
            "Ничего не делать",
            "Повторить с начала списка в конец.",
            "Повторить с конца списка в начало."});
            this.cmbSelect.Location = new System.Drawing.Point(148, 361);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(279, 21);
            this.cmbSelect.TabIndex = 32;
            // 
            // btnBackSelect
            // 
            this.btnBackSelect.Location = new System.Drawing.Point(229, 327);
            this.btnBackSelect.Name = "btnBackSelect";
            this.btnBackSelect.Size = new System.Drawing.Size(196, 28);
            this.btnBackSelect.TabIndex = 33;
            this.btnBackSelect.Text = "Назад с выбранного пункта";
            this.btnBackSelect.UseVisualStyleBackColor = true;
            this.btnBackSelect.Click += new System.EventHandler(this.btnBackSelect_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Помощник рыболова";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // lvScanner
            // 
            this.lvScanner.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAddress,
            this.colValue});
            this.lvScanner.Location = new System.Drawing.Point(262, 55);
            this.lvScanner.Name = "lvScanner";
            this.lvScanner.Size = new System.Drawing.Size(1, 1);
            this.lvScanner.TabIndex = 52;
            this.lvScanner.UseCompatibleStateImageBehavior = false;
            this.lvScanner.View = System.Windows.Forms.View.Details;
            this.lvScanner.VirtualMode = true;
            this.lvScanner.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvScanner_RetrieveVirtualItem);
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 100;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Значение X:";
            // 
            // btnNextScan
            // 
            this.btnNextScan.Enabled = false;
            this.btnNextScan.Location = new System.Drawing.Point(221, 14);
            this.btnNextScan.Name = "btnNextScan";
            this.btnNextScan.Size = new System.Drawing.Size(116, 23);
            this.btnNextScan.TabIndex = 42;
            this.btnNextScan.Text = "Следующий поиск";
            this.btnNextScan.UseVisualStyleBackColor = true;
            this.btnNextScan.Click += new System.EventHandler(this.btnNextScan_Click);
            // 
            // btnFirstScan
            // 
            this.btnFirstScan.Enabled = false;
            this.btnFirstScan.Location = new System.Drawing.Point(101, 14);
            this.btnFirstScan.Name = "btnFirstScan";
            this.btnFirstScan.Size = new System.Drawing.Size(114, 23);
            this.btnFirstScan.TabIndex = 41;
            this.btnFirstScan.Text = "Первый поиск";
            this.btnFirstScan.UseVisualStyleBackColor = true;
            this.btnFirstScan.Click += new System.EventHandler(this.btnFirstScan_Click);
            // 
            // btnNewScan
            // 
            this.btnNewScan.Enabled = false;
            this.btnNewScan.Location = new System.Drawing.Point(6, 14);
            this.btnNewScan.Name = "btnNewScan";
            this.btnNewScan.Size = new System.Drawing.Size(89, 23);
            this.btnNewScan.TabIndex = 40;
            this.btnNewScan.Text = "Новый поиск";
            this.btnNewScan.UseVisualStyleBackColor = true;
            this.btnNewScan.Click += new System.EventHandler(this.btnNewScan_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(441, 565);
            this.tabControl1.TabIndex = 55;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btnBackSelect);
            this.tabPage1.Controls.Add(this.cmbSelect);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnFishingVer2);
            this.tabPage1.Controls.Add(this.btnGoSelect);
            this.tabPage1.Controls.Add(this.btnGoGoGo);
            this.tabPage1.Controls.Add(this.btnAddRow);
            this.tabPage1.Controls.Add(this.btnConsol);
            this.tabPage1.Controls.Add(this.btnRemoveRow);
            this.tabPage1.Controls.Add(this.btnCameraCorner);
            this.tabPage1.Controls.Add(this.btnRunAndFish);
            this.tabPage1.Controls.Add(this.txtTargetCorner);
            this.tabPage1.Controls.Add(this.btnFishing);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtboxXTarget);
            this.tabPage1.Controls.Add(this.btnTargetRun);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtboxYTarget);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(433, 539);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основное окно";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCopyAdresses);
            this.tabPage2.Controls.Add(this.btnClean);
            this.tabPage2.Controls.Add(this.txtCValue);
            this.tabPage2.Controls.Add(this.txtYValue);
            this.tabPage2.Controls.Add(this.txtXValue);
            this.tabPage2.Controls.Add(this.btnSaveToDefaultAdressFile);
            this.tabPage2.Controls.Add(this.btnCAdressCopy);
            this.tabPage2.Controls.Add(this.btnYAdressCopy);
            this.tabPage2.Controls.Add(this.btnXAdressCopy);
            this.tabPage2.Controls.Add(this.btbTestAdress);
            this.tabPage2.Controls.Add(this.lblCorner);
            this.tabPage2.Controls.Add(this.lblCoordY);
            this.tabPage2.Controls.Add(this.lblCoordX);
            this.tabPage2.Controls.Add(this.textBoxCorner);
            this.tabPage2.Controls.Add(this.labelTargetCorner);
            this.tabPage2.Controls.Add(this.textBoxCoordY);
            this.tabPage2.Controls.Add(this.labelTargetY);
            this.tabPage2.Controls.Add(this.textBoxCoordX);
            this.tabPage2.Controls.Add(this.labelTargetX);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.dgvCAdressList);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.dgvYAdressList);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.dgvXAdressList);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lblStatus);
            this.tabPage2.Controls.Add(this.btnFirstScan);
            this.tabPage2.Controls.Add(this.lvScanner);
            this.tabPage2.Controls.Add(this.btnNewScan);
            this.tabPage2.Controls.Add(this.btnNextScan);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(433, 539);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Поиск адресов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(160, 79);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(113, 23);
            this.btnClean.TabIndex = 84;
            this.btnClean.Text = "Очистить значания";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // txtCValue
            // 
            this.txtCValue.Location = new System.Drawing.Point(80, 107);
            this.txtCValue.Name = "txtCValue";
            this.txtCValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCValue.Size = new System.Drawing.Size(64, 20);
            this.txtCValue.TabIndex = 83;
            this.txtCValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnCValue_KeyPress);
            // 
            // txtYValue
            // 
            this.txtYValue.Location = new System.Drawing.Point(80, 81);
            this.txtYValue.Name = "txtYValue";
            this.txtYValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtYValue.Size = new System.Drawing.Size(64, 20);
            this.txtYValue.TabIndex = 82;
            this.txtYValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnYValue_KeyPress);
            // 
            // txtXValue
            // 
            this.txtXValue.Location = new System.Drawing.Point(80, 55);
            this.txtXValue.Name = "txtXValue";
            this.txtXValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtXValue.Size = new System.Drawing.Size(64, 20);
            this.txtXValue.TabIndex = 81;
            this.txtXValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnXValue_KeyPress);
            // 
            // btnSaveToDefaultAdressFile
            // 
            this.btnSaveToDefaultAdressFile.Location = new System.Drawing.Point(243, 502);
            this.btnSaveToDefaultAdressFile.Name = "btnSaveToDefaultAdressFile";
            this.btnSaveToDefaultAdressFile.Size = new System.Drawing.Size(184, 23);
            this.btnSaveToDefaultAdressFile.TabIndex = 80;
            this.btnSaveToDefaultAdressFile.Text = "Сохранить в файл по умолчанию";
            this.btnSaveToDefaultAdressFile.UseVisualStyleBackColor = true;
            this.btnSaveToDefaultAdressFile.Click += new System.EventHandler(this.btnSaveToDefaultAdressFile_Click);
            // 
            // btnCAdressCopy
            // 
            this.btnCAdressCopy.Location = new System.Drawing.Point(262, 446);
            this.btnCAdressCopy.Name = "btnCAdressCopy";
            this.btnCAdressCopy.Size = new System.Drawing.Size(122, 23);
            this.btnCAdressCopy.TabIndex = 79;
            this.btnCAdressCopy.Text = "Скопировать адрес";
            this.btnCAdressCopy.UseVisualStyleBackColor = true;
            this.btnCAdressCopy.Click += new System.EventHandler(this.btnCAdressCopy_Click);
            // 
            // btnYAdressCopy
            // 
            this.btnYAdressCopy.Location = new System.Drawing.Point(262, 318);
            this.btnYAdressCopy.Name = "btnYAdressCopy";
            this.btnYAdressCopy.Size = new System.Drawing.Size(122, 23);
            this.btnYAdressCopy.TabIndex = 78;
            this.btnYAdressCopy.Text = "Скопировать адрес";
            this.btnYAdressCopy.UseVisualStyleBackColor = true;
            this.btnYAdressCopy.Click += new System.EventHandler(this.btnYAdressCopy_Click);
            // 
            // btnXAdressCopy
            // 
            this.btnXAdressCopy.Location = new System.Drawing.Point(262, 189);
            this.btnXAdressCopy.Name = "btnXAdressCopy";
            this.btnXAdressCopy.Size = new System.Drawing.Size(122, 23);
            this.btnXAdressCopy.TabIndex = 77;
            this.btnXAdressCopy.Text = "Скопировать адрес";
            this.btnXAdressCopy.UseVisualStyleBackColor = true;
            this.btnXAdressCopy.Click += new System.EventHandler(this.btnXAdressCopy_Click);
            // 
            // btbTestAdress
            // 
            this.btbTestAdress.Location = new System.Drawing.Point(243, 475);
            this.btbTestAdress.Name = "btbTestAdress";
            this.btbTestAdress.Size = new System.Drawing.Size(184, 23);
            this.btbTestAdress.TabIndex = 76;
            this.btbTestAdress.Text = "Проверка адресов памяти";
            this.btbTestAdress.UseVisualStyleBackColor = true;
            this.btbTestAdress.Click += new System.EventHandler(this.btbTestAdress_Click);
            // 
            // lblCorner
            // 
            this.lblCorner.AutoSize = true;
            this.lblCorner.Location = new System.Drawing.Point(259, 430);
            this.lblCorner.Name = "lblCorner";
            this.lblCorner.Size = new System.Drawing.Size(139, 13);
            this.lblCorner.TabIndex = 75;
            this.lblCorner.Text = "<-Выберите адрес памяти";
            // 
            // lblCoordY
            // 
            this.lblCoordY.AutoSize = true;
            this.lblCoordY.Location = new System.Drawing.Point(259, 302);
            this.lblCoordY.Name = "lblCoordY";
            this.lblCoordY.Size = new System.Drawing.Size(139, 13);
            this.lblCoordY.TabIndex = 74;
            this.lblCoordY.Text = "<-Выберите адрес памяти";
            // 
            // lblCoordX
            // 
            this.lblCoordX.AutoSize = true;
            this.lblCoordX.Location = new System.Drawing.Point(259, 172);
            this.lblCoordX.Name = "lblCoordX";
            this.lblCoordX.Size = new System.Drawing.Size(139, 13);
            this.lblCoordX.TabIndex = 73;
            this.lblCoordX.Text = "<-Выберите адрес памяти";
            // 
            // textBoxCorner
            // 
            this.textBoxCorner.Location = new System.Drawing.Point(262, 407);
            this.textBoxCorner.Name = "textBoxCorner";
            this.textBoxCorner.Size = new System.Drawing.Size(122, 20);
            this.textBoxCorner.TabIndex = 72;
            // 
            // labelTargetCorner
            // 
            this.labelTargetCorner.AutoSize = true;
            this.labelTargetCorner.Location = new System.Drawing.Point(259, 391);
            this.labelTargetCorner.Name = "labelTargetCorner";
            this.labelTargetCorner.Size = new System.Drawing.Size(116, 13);
            this.labelTargetCorner.TabIndex = 71;
            this.labelTargetCorner.Text = "Адрес угла поворота:";
            // 
            // textBoxCoordY
            // 
            this.textBoxCoordY.Location = new System.Drawing.Point(262, 279);
            this.textBoxCoordY.Name = "textBoxCoordY";
            this.textBoxCoordY.Size = new System.Drawing.Size(122, 20);
            this.textBoxCoordY.TabIndex = 70;
            // 
            // labelTargetY
            // 
            this.labelTargetY.AutoSize = true;
            this.labelTargetY.Location = new System.Drawing.Point(259, 263);
            this.labelTargetY.Name = "labelTargetY";
            this.labelTargetY.Size = new System.Drawing.Size(115, 13);
            this.labelTargetY.TabIndex = 69;
            this.labelTargetY.Text = "Адрес Y координаты:";
            // 
            // textBoxCoordX
            // 
            this.textBoxCoordX.Location = new System.Drawing.Point(262, 149);
            this.textBoxCoordX.Name = "textBoxCoordX";
            this.textBoxCoordX.Size = new System.Drawing.Size(122, 20);
            this.textBoxCoordX.TabIndex = 68;
            // 
            // labelTargetX
            // 
            this.labelTargetX.AutoSize = true;
            this.labelTargetX.Location = new System.Drawing.Point(259, 133);
            this.labelTargetX.Name = "labelTargetX";
            this.labelTargetX.Size = new System.Drawing.Size(115, 13);
            this.labelTargetX.TabIndex = 67;
            this.labelTargetX.Text = "Адрес Х координаты:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 391);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 13);
            this.label14.TabIndex = 66;
            this.label14.Text = "Найденные адреса C:";
            // 
            // dgvCAdressList
            // 
            this.dgvCAdressList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCAdressList.Location = new System.Drawing.Point(3, 407);
            this.dgvCAdressList.Name = "dgvCAdressList";
            this.dgvCAdressList.Size = new System.Drawing.Size(237, 104);
            this.dgvCAdressList.TabIndex = 65;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 263);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 13);
            this.label13.TabIndex = 64;
            this.label13.Text = "Найденные адреса Y:";
            // 
            // dgvYAdressList
            // 
            this.dgvYAdressList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYAdressList.Location = new System.Drawing.Point(3, 279);
            this.dgvYAdressList.Name = "dgvYAdressList";
            this.dgvYAdressList.Size = new System.Drawing.Size(237, 109);
            this.dgvYAdressList.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 13);
            this.label12.TabIndex = 62;
            this.label12.Text = "Найденные адреса X:";
            // 
            // dgvXAdressList
            // 
            this.dgvXAdressList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXAdressList.Location = new System.Drawing.Point(6, 149);
            this.dgvXAdressList.Name = "dgvXAdressList";
            this.dgvXAdressList.Size = new System.Drawing.Size(237, 111);
            this.dgvXAdressList.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Значение C:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Значение Y:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(8, 514);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 53;
            this.lblStatus.Text = "Статус: ";
            // 
            // btnCopyAdresses
            // 
            this.btnCopyAdresses.Location = new System.Drawing.Point(296, 79);
            this.btnCopyAdresses.Name = "btnCopyAdresses";
            this.btnCopyAdresses.Size = new System.Drawing.Size(123, 23);
            this.btnCopyAdresses.TabIndex = 85;
            this.btnCopyAdresses.Text = "Скопировать адреса";
            this.btnCopyAdresses.UseVisualStyleBackColor = true;
            this.btnCopyAdresses.Click += new System.EventHandler(this.btnCopyAdresses_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 586);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Помощник рыболова";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAdressList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYAdressList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXAdressList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCameraCorner;
        private System.Windows.Forms.TextBox txtTargetCorner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxXTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtboxYTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTargetRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFishing;
        private System.Windows.Forms.Button btnRunAndFish;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Button btnConsol;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnGoGoGo;
        private System.Windows.Forms.ToolStripMenuItem openAdressStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnGoSelect;
        private System.Windows.Forms.Button btnFishingVer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Button btnBackSelect;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem1;
        private System.Windows.Forms.ListView lvScanner;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnNextScan;
        private System.Windows.Forms.Button btnFirstScan;
        private System.Windows.Forms.Button btnNewScan;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvCAdressList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvYAdressList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvXAdressList;
        private System.Windows.Forms.Label labelTargetY;
        public System.Windows.Forms.TextBox textBoxCoordX;
        private System.Windows.Forms.Label labelTargetX;
        private System.Windows.Forms.Label lblCorner;
        private System.Windows.Forms.Label lblCoordY;
        private System.Windows.Forms.Label lblCoordX;
        private System.Windows.Forms.TextBox textBoxCorner;
        private System.Windows.Forms.Label labelTargetCorner;
        private System.Windows.Forms.TextBox textBoxCoordY;
        private System.Windows.Forms.Button btbTestAdress;
        private System.Windows.Forms.Button btnCAdressCopy;
        private System.Windows.Forms.Button btnYAdressCopy;
        private System.Windows.Forms.Button btnXAdressCopy;
        private System.Windows.Forms.ToolStripMenuItem saveAdressToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogAdressFile;
        private System.Windows.Forms.Button btnSaveToDefaultAdressFile;
        private System.Windows.Forms.TextBox txtCValue;
        private System.Windows.Forms.TextBox txtYValue;
        private System.Windows.Forms.TextBox txtXValue;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnCopyAdresses;
    }
}

