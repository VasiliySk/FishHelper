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
            this.colomnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сolumnFish = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.chkbAlwaysOnTop.Location = new System.Drawing.Point(310, 518);
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
            this.lblCoordX.Location = new System.Drawing.Point(317, 26);
            this.lblCoordX.Name = "lblCoordX";
            this.lblCoordX.Size = new System.Drawing.Size(131, 13);
            this.lblCoordX.TabIndex = 8;
            this.lblCoordX.Text = "<-Задайте адрес памяти";
            // 
            // lblCoordY
            // 
            this.lblCoordY.AutoSize = true;
            this.lblCoordY.Location = new System.Drawing.Point(317, 52);
            this.lblCoordY.Name = "lblCoordY";
            this.lblCoordY.Size = new System.Drawing.Size(131, 13);
            this.lblCoordY.TabIndex = 9;
            this.lblCoordY.Text = "<-Задайте адрес памяти";
            // 
            // lblCorner
            // 
            this.lblCorner.AutoSize = true;
            this.lblCorner.Location = new System.Drawing.Point(317, 78);
            this.lblCorner.Name = "lblCorner";
            this.lblCorner.Size = new System.Drawing.Size(131, 13);
            this.lblCorner.TabIndex = 10;
            this.lblCorner.Text = "<-Задайте адрес памяти";
            // 
            // btbTestAdress
            // 
            this.btbTestAdress.Location = new System.Drawing.Point(320, 94);
            this.btbTestAdress.Name = "btbTestAdress";
            this.btbTestAdress.Size = new System.Drawing.Size(116, 23);
            this.btbTestAdress.TabIndex = 11;
            this.btbTestAdress.Text = "Проверка адресов памяти";
            this.btbTestAdress.UseVisualStyleBackColor = true;
            this.btbTestAdress.Click += new System.EventHandler(this.btbTestAdress_Click);
            // 
            // btnCameraCorner
            // 
            this.btnCameraCorner.Location = new System.Drawing.Point(304, 173);
            this.btnCameraCorner.Name = "btnCameraCorner";
            this.btnCameraCorner.Size = new System.Drawing.Size(132, 26);
            this.btnCameraCorner.TabIndex = 12;
            this.btnCameraCorner.Text = "Поворот камеры";
            this.btnCameraCorner.UseVisualStyleBackColor = true;
            this.btnCameraCorner.Click += new System.EventHandler(this.btnCameraCorner_Click);
            // 
            // txtTargetCorner
            // 
            this.txtTargetCorner.Location = new System.Drawing.Point(304, 145);
            this.txtTargetCorner.Name = "txtTargetCorner";
            this.txtTargetCorner.Size = new System.Drawing.Size(132, 20);
            this.txtTargetCorner.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Целевой угол поворота";
            // 
            // txtboxXTarget
            // 
            this.txtboxXTarget.Location = new System.Drawing.Point(12, 145);
            this.txtboxXTarget.Name = "txtboxXTarget";
            this.txtboxXTarget.Size = new System.Drawing.Size(132, 20);
            this.txtboxXTarget.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "X координата";
            // 
            // txtboxYTarget
            // 
            this.txtboxYTarget.Location = new System.Drawing.Point(159, 145);
            this.txtboxYTarget.Name = "txtboxYTarget";
            this.txtboxYTarget.Size = new System.Drawing.Size(132, 20);
            this.txtboxYTarget.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Y координата";
            // 
            // btnTargetRun
            // 
            this.btnTargetRun.Location = new System.Drawing.Point(12, 171);
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
            this.label4.Location = new System.Drawing.Point(9, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Тестовые функции. Удалить после отладки";
            // 
            // btnFishing
            // 
            this.btnFishing.Location = new System.Drawing.Point(12, 205);
            this.btnFishing.Name = "btnFishing";
            this.btnFishing.Size = new System.Drawing.Size(132, 28);
            this.btnFishing.TabIndex = 21;
            this.btnFishing.Text = "Рыбачим!";
            this.btnFishing.UseVisualStyleBackColor = true;
            this.btnFishing.Click += new System.EventHandler(this.btnFishing_Click);
            // 
            // btnRunAndFish
            // 
            this.btnRunAndFish.Location = new System.Drawing.Point(159, 205);
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
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colomnX,
            this.columnY,
            this.columnC,
            this.сolumnFish});
            this.dataGridView1.Location = new System.Drawing.Point(12, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(436, 239);
            this.dataGridView1.TabIndex = 23;
            // 
            // colomnX
            // 
            this.colomnX.HeaderText = "X";
            this.colomnX.Name = "colomnX";
            // 
            // columnY
            // 
            this.columnY.HeaderText = "Y";
            this.columnY.Name = "columnY";
            // 
            // columnC
            // 
            this.columnC.HeaderText = "Угол";
            this.columnC.Name = "columnC";
            // 
            // сolumnFish
            // 
            this.сolumnFish.HeaderText = "Рыба";
            this.сolumnFish.Name = "сolumnFish";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 547);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Помощник рыболова";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colomnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnY;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn сolumnFish;
    }
}

