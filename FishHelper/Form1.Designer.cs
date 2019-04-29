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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelTargetX = new System.Windows.Forms.Label();
            this.textBoxCoordX = new System.Windows.Forms.TextBox();
            this.labelTargetY = new System.Windows.Forms.Label();
            this.textBoxCoordY = new System.Windows.Forms.TextBox();
            this.labelTargetCorner = new System.Windows.Forms.Label();
            this.textBoxCorner = new System.Windows.Forms.TextBox();
            this.chkbAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.lblCoordX = new System.Windows.Forms.Label();
            this.lblCoordY = new System.Windows.Forms.Label();
            this.lblCorner = new System.Windows.Forms.Label();
            this.btbTestAdress = new System.Windows.Forms.Button();
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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnGoGoGo = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnGoSelect = new System.Windows.Forms.Button();
            this.btnFishingVer2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.btnBackSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTargetX
            // 
            this.labelTargetX.AutoSize = true;
            this.labelTargetX.Location = new System.Drawing.Point(12, 26);
            this.labelTargetX.Name = "labelTargetX";
            this.labelTargetX.Size = new System.Drawing.Size(112, 13);
            this.labelTargetX.TabIndex = 1;
            this.labelTargetX.Text = "Адрес Х координаты";
            // 
            // textBoxCoordX
            // 
            this.textBoxCoordX.Location = new System.Drawing.Point(159, 23);
            this.textBoxCoordX.Name = "textBoxCoordX";
            this.textBoxCoordX.Size = new System.Drawing.Size(122, 20);
            this.textBoxCoordX.TabIndex = 2;
            // 
            // labelTargetY
            // 
            this.labelTargetY.AutoSize = true;
            this.labelTargetY.Location = new System.Drawing.Point(12, 52);
            this.labelTargetY.Name = "labelTargetY";
            this.labelTargetY.Size = new System.Drawing.Size(112, 13);
            this.labelTargetY.TabIndex = 3;
            this.labelTargetY.Text = "Адрес Y координаты";
            // 
            // textBoxCoordY
            // 
            this.textBoxCoordY.Location = new System.Drawing.Point(159, 49);
            this.textBoxCoordY.Name = "textBoxCoordY";
            this.textBoxCoordY.Size = new System.Drawing.Size(122, 20);
            this.textBoxCoordY.TabIndex = 4;
            // 
            // labelTargetCorner
            // 
            this.labelTargetCorner.AutoSize = true;
            this.labelTargetCorner.Location = new System.Drawing.Point(12, 78);
            this.labelTargetCorner.Name = "labelTargetCorner";
            this.labelTargetCorner.Size = new System.Drawing.Size(113, 13);
            this.labelTargetCorner.TabIndex = 5;
            this.labelTargetCorner.Text = "Адрес угла поворота";
            // 
            // textBoxCorner
            // 
            this.textBoxCorner.Location = new System.Drawing.Point(159, 75);
            this.textBoxCorner.Name = "textBoxCorner";
            this.textBoxCorner.Size = new System.Drawing.Size(122, 20);
            this.textBoxCorner.TabIndex = 6;
            // 
            // chkbAlwaysOnTop
            // 
            this.chkbAlwaysOnTop.AutoSize = true;
            this.chkbAlwaysOnTop.Checked = true;
            this.chkbAlwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbAlwaysOnTop.Location = new System.Drawing.Point(310, 554);
            this.chkbAlwaysOnTop.Name = "chkbAlwaysOnTop";
            this.chkbAlwaysOnTop.Size = new System.Drawing.Size(126, 17);
            this.chkbAlwaysOnTop.TabIndex = 7;
            this.chkbAlwaysOnTop.Text = "Поверх других окон";
            this.chkbAlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkbAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkbAlwaysOnTop_CheckedChanged);
            // 
            // lblCoordX
            // 
            this.lblCoordX.AutoSize = true;
            this.lblCoordX.Location = new System.Drawing.Point(305, 26);
            this.lblCoordX.Name = "lblCoordX";
            this.lblCoordX.Size = new System.Drawing.Size(131, 13);
            this.lblCoordX.TabIndex = 8;
            this.lblCoordX.Text = "<-Задайте адрес памяти";
            // 
            // lblCoordY
            // 
            this.lblCoordY.AutoSize = true;
            this.lblCoordY.Location = new System.Drawing.Point(305, 52);
            this.lblCoordY.Name = "lblCoordY";
            this.lblCoordY.Size = new System.Drawing.Size(131, 13);
            this.lblCoordY.TabIndex = 9;
            this.lblCoordY.Text = "<-Задайте адрес памяти";
            // 
            // lblCorner
            // 
            this.lblCorner.AutoSize = true;
            this.lblCorner.Location = new System.Drawing.Point(305, 78);
            this.lblCorner.Name = "lblCorner";
            this.lblCorner.Size = new System.Drawing.Size(131, 13);
            this.lblCorner.TabIndex = 10;
            this.lblCorner.Text = "<-Задайте адрес памяти";
            // 
            // btbTestAdress
            // 
            this.btbTestAdress.Location = new System.Drawing.Point(310, 104);
            this.btbTestAdress.Name = "btbTestAdress";
            this.btbTestAdress.Size = new System.Drawing.Size(126, 23);
            this.btbTestAdress.TabIndex = 11;
            this.btbTestAdress.Text = "Проверка адресов памяти";
            this.btbTestAdress.UseVisualStyleBackColor = true;
            this.btbTestAdress.Click += new System.EventHandler(this.btbTestAdress_Click);
            // 
            // btnCameraCorner
            // 
            this.btnCameraCorner.Location = new System.Drawing.Point(304, 522);
            this.btnCameraCorner.Name = "btnCameraCorner";
            this.btnCameraCorner.Size = new System.Drawing.Size(132, 26);
            this.btnCameraCorner.TabIndex = 12;
            this.btnCameraCorner.Text = "Поворот камеры";
            this.btnCameraCorner.UseVisualStyleBackColor = true;
            this.btnCameraCorner.Click += new System.EventHandler(this.btnCameraCorner_Click);
            // 
            // txtTargetCorner
            // 
            this.txtTargetCorner.Location = new System.Drawing.Point(304, 462);
            this.txtTargetCorner.Name = "txtTargetCorner";
            this.txtTargetCorner.Size = new System.Drawing.Size(132, 20);
            this.txtTargetCorner.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Целевой угол поворота";
            // 
            // txtboxXTarget
            // 
            this.txtboxXTarget.Location = new System.Drawing.Point(12, 462);
            this.txtboxXTarget.Name = "txtboxXTarget";
            this.txtboxXTarget.Size = new System.Drawing.Size(132, 20);
            this.txtboxXTarget.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 443);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "X координата";
            // 
            // txtboxYTarget
            // 
            this.txtboxYTarget.Location = new System.Drawing.Point(159, 462);
            this.txtboxYTarget.Name = "txtboxYTarget";
            this.txtboxYTarget.Size = new System.Drawing.Size(132, 20);
            this.txtboxYTarget.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Y координата";
            // 
            // btnTargetRun
            // 
            this.btnTargetRun.Location = new System.Drawing.Point(12, 488);
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
            this.label4.Location = new System.Drawing.Point(9, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Тестовые функции. Удалить после отладки";
            // 
            // btnFishing
            // 
            this.btnFishing.Location = new System.Drawing.Point(159, 488);
            this.btnFishing.Name = "btnFishing";
            this.btnFishing.Size = new System.Drawing.Size(132, 28);
            this.btnFishing.TabIndex = 21;
            this.btnFishing.Text = "Рыбачим!";
            this.btnFishing.UseVisualStyleBackColor = true;
            this.btnFishing.Click += new System.EventHandler(this.btnFishing_Click);
            // 
            // btnRunAndFish
            // 
            this.btnRunAndFish.Location = new System.Drawing.Point(304, 488);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(422, 179);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint_1);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(144, 315);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(119, 28);
            this.btnRemoveRow.TabIndex = 24;
            this.btnRemoveRow.Text = "Удалить строку";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnConsol
            // 
            this.btnConsol.Location = new System.Drawing.Point(12, 522);
            this.btnConsol.Name = "btnConsol";
            this.btnConsol.Size = new System.Drawing.Size(132, 28);
            this.btnConsol.TabIndex = 25;
            this.btnConsol.Text = "Консоль";
            this.btnConsol.UseVisualStyleBackColor = true;
            this.btnConsol.Click += new System.EventHandler(this.btnConsol_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(12, 315);
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
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(440, 24);
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
            this.exitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // openAdressStripMenuItem
            // 
            this.openAdressStripMenuItem.Name = "openAdressStripMenuItem";
            this.openAdressStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openAdressStripMenuItem.Text = "Открыть файл с адресами";
            this.openAdressStripMenuItem.Click += new System.EventHandler(this.openAdressStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // btnGoGoGo
            // 
            this.btnGoGoGo.Location = new System.Drawing.Point(269, 315);
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
            this.btnGoSelect.Location = new System.Drawing.Point(12, 349);
            this.btnGoSelect.Name = "btnGoSelect";
            this.btnGoSelect.Size = new System.Drawing.Size(220, 28);
            this.btnGoSelect.TabIndex = 29;
            this.btnGoSelect.Text = "Вперед с выбранного пункта";
            this.btnGoSelect.UseVisualStyleBackColor = true;
            this.btnGoSelect.Click += new System.EventHandler(this.btnGoSelect_Click);
            // 
            // btnFishingVer2
            // 
            this.btnFishingVer2.Location = new System.Drawing.Point(159, 522);
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
            this.label5.Location = new System.Drawing.Point(12, 386);
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
            this.cmbSelect.Location = new System.Drawing.Point(157, 383);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(279, 21);
            this.cmbSelect.TabIndex = 32;
            // 
            // btnBackSelect
            // 
            this.btnBackSelect.Location = new System.Drawing.Point(238, 349);
            this.btnBackSelect.Name = "btnBackSelect";
            this.btnBackSelect.Size = new System.Drawing.Size(196, 28);
            this.btnBackSelect.TabIndex = 33;
            this.btnBackSelect.Text = "Назад с выбранного пункта";
            this.btnBackSelect.UseVisualStyleBackColor = true;
            this.btnBackSelect.Click += new System.EventHandler(this.btnBackSelect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 570);
            this.Controls.Add(this.btnBackSelect);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFishingVer2);
            this.Controls.Add(this.btnGoSelect);
            this.Controls.Add(this.btnGoGoGo);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnConsol);
            this.Controls.Add(this.btnRemoveRow);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRunAndFish);
            this.Controls.Add(this.btnFishing);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTargetRun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtboxYTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxXTarget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTargetCorner);
            this.Controls.Add(this.btnCameraCorner);
            this.Controls.Add(this.btbTestAdress);
            this.Controls.Add(this.lblCorner);
            this.Controls.Add(this.lblCoordY);
            this.Controls.Add(this.lblCoordX);
            this.Controls.Add(this.chkbAlwaysOnTop);
            this.Controls.Add(this.textBoxCorner);
            this.Controls.Add(this.labelTargetCorner);
            this.Controls.Add(this.textBoxCoordY);
            this.Controls.Add(this.labelTargetY);
            this.Controls.Add(this.textBoxCoordX);
            this.Controls.Add(this.labelTargetX);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Помощник рыболова";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTargetX;
        private System.Windows.Forms.TextBox textBoxCoordX;
        private System.Windows.Forms.Label labelTargetY;
        private System.Windows.Forms.TextBox textBoxCoordY;
        private System.Windows.Forms.Label labelTargetCorner;
        private System.Windows.Forms.TextBox textBoxCorner;
        private System.Windows.Forms.CheckBox chkbAlwaysOnTop;
        private System.Windows.Forms.Label lblCoordX;
        private System.Windows.Forms.Label lblCoordY;
        private System.Windows.Forms.Label lblCorner;
        private System.Windows.Forms.Button btbTestAdress;
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
    }
}

