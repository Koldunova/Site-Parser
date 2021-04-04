namespace ScanerShow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectGames1 = new System.Windows.Forms.ComboBox();
            this.pbGraph = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableCost = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.xmlGames = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.newGame = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.удалитьДанныеОбИгреToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.средняяЦенаИгрыЗаПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.игрыВДиапазонеЦенНаДатуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИгрПоДатеВыходаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableCost)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.selectGames1);
            this.groupBox1.Controls.Add(this.pbGraph);
            this.groupBox1.Location = new System.Drawing.Point(2, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 287);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Иcтория цен";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Игра:";
            // 
            // selectGames1
            // 
            this.selectGames1.FormattingEnabled = true;
            this.selectGames1.Location = new System.Drawing.Point(41, 24);
            this.selectGames1.Name = "selectGames1";
            this.selectGames1.Size = new System.Drawing.Size(408, 21);
            this.selectGames1.TabIndex = 1;
            this.selectGames1.SelectedIndexChanged += new System.EventHandler(this.selectGames1_SelectedIndexChanged);
            // 
            // pbGraph
            // 
            this.pbGraph.BackColor = System.Drawing.Color.DarkGray;
            this.pbGraph.Location = new System.Drawing.Point(9, 53);
            this.pbGraph.Name = "pbGraph";
            this.pbGraph.Size = new System.Drawing.Size(440, 219);
            this.pbGraph.TabIndex = 0;
            this.pbGraph.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableCost);
            this.groupBox2.Location = new System.Drawing.Point(463, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 470);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Цены на игру";
            // 
            // tableCost
            // 
            this.tableCost.AllowUserToAddRows = false;
            this.tableCost.AllowUserToDeleteRows = false;
            this.tableCost.AllowUserToOrderColumns = true;
            this.tableCost.AllowUserToResizeColumns = false;
            this.tableCost.AllowUserToResizeRows = false;
            this.tableCost.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.tableCost.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.tableCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableCost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.cost});
            this.tableCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tableCost.Location = new System.Drawing.Point(27, 19);
            this.tableCost.Name = "tableCost";
            this.tableCost.Size = new System.Drawing.Size(442, 436);
            this.tableCost.TabIndex = 0;
            this.tableCost.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableCost_CellContentClick);
            // 
            // date
            // 
            this.date.HeaderText = "Дата";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 197;
            // 
            // cost
            // 
            this.cost.HeaderText = "Стоимость игры";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            this.cost.Width = 200;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(2, 332);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 186);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройки для парсинга";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDelete);
            this.groupBox5.Controls.Add(this.xmlGames);
            this.groupBox5.Location = new System.Drawing.Point(0, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(446, 68);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Удаление игр";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(368, 45);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // xmlGames
            // 
            this.xmlGames.FormattingEnabled = true;
            this.xmlGames.Location = new System.Drawing.Point(7, 19);
            this.xmlGames.Name = "xmlGames";
            this.xmlGames.Size = new System.Drawing.Size(436, 21);
            this.xmlGames.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Controls.Add(this.newGame);
            this.groupBox4.Location = new System.Drawing.Point(0, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(446, 72);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Запись игры";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(365, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(7, 19);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(436, 20);
            this.newGame.TabIndex = 0;
            this.newGame.TextChanged += new System.EventHandler(this.newGame_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьДанныеОбИгреToolStripMenuItem,
            this.самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem,
            this.средняяЦенаИгрыЗаПериодToolStripMenuItem,
            this.игрыВДиапазонеЦенНаДатуToolStripMenuItem,
            this.списокИгрПоДатеВыходаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(962, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // удалитьДанныеОбИгреToolStripMenuItem
            // 
            this.удалитьДанныеОбИгреToolStripMenuItem.Name = "удалитьДанныеОбИгреToolStripMenuItem";
            this.удалитьДанныеОбИгреToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.удалитьДанныеОбИгреToolStripMenuItem.Text = "Удалить данные об игре";
            this.удалитьДанныеОбИгреToolStripMenuItem.Click += new System.EventHandler(this.удалитьДанныеОбИгреToolStripMenuItem_Click);
            // 
            // самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem
            // 
            this.самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem.Name = "самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem";
            this.самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem.Size = new System.Drawing.Size(268, 20);
            this.самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem.Text = "Самая дешовая и самая дорогая игра на дату";
            this.самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem.Click += new System.EventHandler(this.самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem_Click);
            // 
            // средняяЦенаИгрыЗаПериодToolStripMenuItem
            // 
            this.средняяЦенаИгрыЗаПериодToolStripMenuItem.Name = "средняяЦенаИгрыЗаПериодToolStripMenuItem";
            this.средняяЦенаИгрыЗаПериодToolStripMenuItem.Size = new System.Drawing.Size(182, 20);
            this.средняяЦенаИгрыЗаПериодToolStripMenuItem.Text = "Средняя цена игры за период";
            this.средняяЦенаИгрыЗаПериодToolStripMenuItem.Click += new System.EventHandler(this.средняяЦенаИгрыЗаПериодToolStripMenuItem_Click);
            // 
            // игрыВДиапазонеЦенНаДатуToolStripMenuItem
            // 
            this.игрыВДиапазонеЦенНаДатуToolStripMenuItem.Name = "игрыВДиапазонеЦенНаДатуToolStripMenuItem";
            this.игрыВДиапазонеЦенНаДатуToolStripMenuItem.Size = new System.Drawing.Size(183, 20);
            this.игрыВДиапазонеЦенНаДатуToolStripMenuItem.Text = "Игры в диапазоне цен на дату";
            this.игрыВДиапазонеЦенНаДатуToolStripMenuItem.Click += new System.EventHandler(this.игрыВДиапазонеЦенНаДатуToolStripMenuItem_Click);
            // 
            // списокИгрПоДатеВыходаToolStripMenuItem
            // 
            this.списокИгрПоДатеВыходаToolStripMenuItem.Name = "списокИгрПоДатеВыходаToolStripMenuItem";
            this.списокИгрПоДатеВыходаToolStripMenuItem.Size = new System.Drawing.Size(167, 20);
            this.списокИгрПоДатеВыходаToolStripMenuItem.Text = "Список игр по дате выхода";
            this.списокИгрПоДатеВыходаToolStripMenuItem.Click += new System.EventHandler(this.списокИгрПоДатеВыходаToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 513);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "SteamScaner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableCost)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectGames1;
        private System.Windows.Forms.PictureBox pbGraph;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tableCost;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox xmlGames;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox newGame;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьДанныеОбИгреToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem средняяЦенаИгрыЗаПериодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem игрыВДиапазонеЦенНаДатуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИгрПоДатеВыходаToolStripMenuItem;
    }
}

