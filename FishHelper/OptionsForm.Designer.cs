namespace FishHelper
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.chkbAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.chkHideToNotify = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGoGoGo = new System.Windows.Forms.ComboBox();
            this.cmbGoSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBackSelect = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFishing = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFishingVer2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCancel = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkDefaultFiles = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDefaultFilePath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSetDefaultFilePath = new System.Windows.Forms.Button();
            this.btnSetDefaultFileAdress = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDefaultFileAdress = new System.Windows.Forms.TextBox();
            this.openFileDialogPath = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogAdress = new System.Windows.Forms.OpenFileDialog();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtESOlocateY = new System.Windows.Forms.TextBox();
            this.txtESOlocateX = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 449);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(99, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkbAlwaysOnTop
            // 
            this.chkbAlwaysOnTop.AutoSize = true;
            this.chkbAlwaysOnTop.Checked = true;
            this.chkbAlwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbAlwaysOnTop.Location = new System.Drawing.Point(15, 34);
            this.chkbAlwaysOnTop.Name = "chkbAlwaysOnTop";
            this.chkbAlwaysOnTop.Size = new System.Drawing.Size(126, 17);
            this.chkbAlwaysOnTop.TabIndex = 8;
            this.chkbAlwaysOnTop.Text = "Поверх других окон";
            this.chkbAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // chkHideToNotify
            // 
            this.chkHideToNotify.AutoSize = true;
            this.chkHideToNotify.Checked = true;
            this.chkHideToNotify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideToNotify.Location = new System.Drawing.Point(15, 57);
            this.chkHideToNotify.Name = "chkHideToNotify";
            this.chkHideToNotify.Size = new System.Drawing.Size(170, 17);
            this.chkHideToNotify.TabIndex = 35;
            this.chkHideToNotify.Text = "Скрывать программу в трей";
            this.chkHideToNotify.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Основные настройки:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(152, 449);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbSelect
            // 
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Items.AddRange(new object[] {
            "Ничего не делать",
            "Повторить с начала списка в конец.",
            "Повторить с конца списка в начало."});
            this.cmbSelect.Location = new System.Drawing.Point(12, 115);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(224, 21);
            this.cmbSelect.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Вариант действия по умолчанию:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Клавиши быстрого запуска:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Вперед по списку:";
            // 
            // cmbGoGoGo
            // 
            this.cmbGoGoGo.FormattingEnabled = true;
            this.cmbGoGoGo.Location = new System.Drawing.Point(174, 320);
            this.cmbGoGoGo.Name = "cmbGoGoGo";
            this.cmbGoGoGo.Size = new System.Drawing.Size(64, 21);
            this.cmbGoGoGo.TabIndex = 42;
            // 
            // cmbGoSelect
            // 
            this.cmbGoSelect.FormattingEnabled = true;
            this.cmbGoSelect.Location = new System.Drawing.Point(174, 345);
            this.cmbGoSelect.Name = "cmbGoSelect";
            this.cmbGoSelect.Size = new System.Drawing.Size(64, 21);
            this.cmbGoSelect.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Вперед c выбранного пункта:";
            // 
            // cmbBackSelect
            // 
            this.cmbBackSelect.FormattingEnabled = true;
            this.cmbBackSelect.Location = new System.Drawing.Point(174, 370);
            this.cmbBackSelect.Name = "cmbBackSelect";
            this.cmbBackSelect.Size = new System.Drawing.Size(64, 21);
            this.cmbBackSelect.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Назад c выбранного пункта:";
            // 
            // cmbFishing
            // 
            this.cmbFishing.FormattingEnabled = true;
            this.cmbFishing.Location = new System.Drawing.Point(174, 395);
            this.cmbFishing.Name = "cmbFishing";
            this.cmbFishing.Size = new System.Drawing.Size(64, 21);
            this.cmbFishing.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Рыбачим";
            // 
            // cmbFishingVer2
            // 
            this.cmbFishingVer2.FormattingEnabled = true;
            this.cmbFishingVer2.Location = new System.Drawing.Point(174, 422);
            this.cmbFishingVer2.Name = "cmbFishingVer2";
            this.cmbFishingVer2.Size = new System.Drawing.Size(64, 21);
            this.cmbFishingVer2.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Рыбачим ver2";
            // 
            // cmbCancel
            // 
            this.cmbCancel.FormattingEnabled = true;
            this.cmbCancel.Location = new System.Drawing.Point(174, 295);
            this.cmbCancel.Name = "cmbCancel";
            this.cmbCancel.Size = new System.Drawing.Size(64, 21);
            this.cmbCancel.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Отмена действия:";
            // 
            // chkDefaultFiles
            // 
            this.chkDefaultFiles.AutoSize = true;
            this.chkDefaultFiles.Checked = true;
            this.chkDefaultFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultFiles.Location = new System.Drawing.Point(15, 80);
            this.chkDefaultFiles.Name = "chkDefaultFiles";
            this.chkDefaultFiles.Size = new System.Drawing.Size(193, 17);
            this.chkDefaultFiles.TabIndex = 53;
            this.chkDefaultFiles.Text = "Открывать файлы по умолчанию";
            this.chkDefaultFiles.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "Файлы по умолчанию:";
            // 
            // txtDefaultFilePath
            // 
            this.txtDefaultFilePath.Location = new System.Drawing.Point(70, 158);
            this.txtDefaultFilePath.Name = "txtDefaultFilePath";
            this.txtDefaultFilePath.Size = new System.Drawing.Size(115, 20);
            this.txtDefaultFilePath.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Маршрут:";
            // 
            // btnSetDefaultFilePath
            // 
            this.btnSetDefaultFilePath.Location = new System.Drawing.Point(189, 156);
            this.btnSetDefaultFilePath.Name = "btnSetDefaultFilePath";
            this.btnSetDefaultFilePath.Size = new System.Drawing.Size(53, 23);
            this.btnSetDefaultFilePath.TabIndex = 57;
            this.btnSetDefaultFilePath.Text = "Задать";
            this.btnSetDefaultFilePath.UseVisualStyleBackColor = true;
            this.btnSetDefaultFilePath.Click += new System.EventHandler(this.btnSetDefaultFilePath_Click);
            // 
            // btnSetDefaultFileAdress
            // 
            this.btnSetDefaultFileAdress.Location = new System.Drawing.Point(189, 182);
            this.btnSetDefaultFileAdress.Name = "btnSetDefaultFileAdress";
            this.btnSetDefaultFileAdress.Size = new System.Drawing.Size(53, 23);
            this.btnSetDefaultFileAdress.TabIndex = 60;
            this.btnSetDefaultFileAdress.Text = "Задать";
            this.btnSetDefaultFileAdress.UseVisualStyleBackColor = true;
            this.btnSetDefaultFileAdress.Click += new System.EventHandler(this.btnSetDefaultFileAdress_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Адреса:";
            // 
            // txtDefaultFileAdress
            // 
            this.txtDefaultFileAdress.Location = new System.Drawing.Point(70, 184);
            this.txtDefaultFileAdress.Name = "txtDefaultFileAdress";
            this.txtDefaultFileAdress.Size = new System.Drawing.Size(115, 20);
            this.txtDefaultFileAdress.TabIndex = 58;
            // 
            // openFileDialogPath
            // 
            this.openFileDialogPath.FileName = "openFileDialog1";
            // 
            // openFileDialogAdress
            // 
            this.openFileDialogAdress.FileName = "openFileDialog2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 13);
            this.label13.TabIndex = 61;
            this.label13.Text = "ESOlocate координаты:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 255);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 13);
            this.label14.TabIndex = 63;
            this.label14.Text = "Y:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 229);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 13);
            this.label15.TabIndex = 62;
            this.label15.Text = "X:";
            // 
            // txtESOlocateY
            // 
            this.txtESOlocateY.Location = new System.Drawing.Point(67, 252);
            this.txtESOlocateY.Name = "txtESOlocateY";
            this.txtESOlocateY.Size = new System.Drawing.Size(115, 20);
            this.txtESOlocateY.TabIndex = 65;
            // 
            // txtESOlocateX
            // 
            this.txtESOlocateX.Location = new System.Drawing.Point(67, 226);
            this.txtESOlocateX.Name = "txtESOlocateX";
            this.txtESOlocateX.Size = new System.Drawing.Size(115, 20);
            this.txtESOlocateX.TabIndex = 64;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 480);
            this.Controls.Add(this.txtESOlocateY);
            this.Controls.Add(this.txtESOlocateX);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSetDefaultFileAdress);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDefaultFileAdress);
            this.Controls.Add(this.btnSetDefaultFilePath);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDefaultFilePath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkDefaultFiles);
            this.Controls.Add(this.cmbCancel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbFishingVer2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbFishing);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbBackSelect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbGoSelect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbGoGoGo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkHideToNotify);
            this.Controls.Add(this.chkbAlwaysOnTop);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkbAlwaysOnTop;
        private System.Windows.Forms.CheckBox chkHideToNotify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbGoGoGo;
        private System.Windows.Forms.ComboBox cmbGoSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBackSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFishing;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFishingVer2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkDefaultFiles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDefaultFilePath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSetDefaultFilePath;
        private System.Windows.Forms.Button btnSetDefaultFileAdress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDefaultFileAdress;
        private System.Windows.Forms.OpenFileDialog openFileDialogPath;
        private System.Windows.Forms.OpenFileDialog openFileDialogAdress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtESOlocateY;
        private System.Windows.Forms.TextBox txtESOlocateX;
    }
}