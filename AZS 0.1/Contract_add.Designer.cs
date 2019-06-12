namespace AZS_0._1
{
    partial class Contract_add
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Сотрудник = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Поставщик = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Топливо = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Кол_во = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Цена = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Датапоставки = new System.Windows.Forms.DataGridViewCalendarColumn();
            this.Сумма = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Датазакл = new System.Windows.Forms.DataGridViewCalendarColumn();
            this.diplomruDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.diplom_ruDataSet = new AZS_0._1.Diplom_ruDataSet();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCalendarColumn1 = new System.Windows.Forms.DataGridViewCalendarColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCalendarColumn2 = new System.Windows.Forms.DataGridViewCalendarColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplomruDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplom_ruDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(883, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.обновитьToolStripMenuItem.Text = "Добавить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Сотрудник,
            this.Поставщик,
            this.Топливо,
            this.Кол_во,
            this.Цена,
            this.Датапоставки,
            this.Сумма,
            this.Датазакл});
            this.dataGridView1.DataSource = this.diplomruDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(883, 222);
            this.dataGridView1.TabIndex = 7;
            // 
            // Сотрудник
            // 
            this.Сотрудник.HeaderText = "Сотрудник";
            this.Сотрудник.Name = "Сотрудник";
            this.Сотрудник.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Сотрудник.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Сотрудник.Width = 175;
            // 
            // Поставщик
            // 
            this.Поставщик.HeaderText = "Поставщик";
            this.Поставщик.Name = "Поставщик";
            this.Поставщик.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Поставщик.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Поставщик.Width = 160;
            // 
            // Топливо
            // 
            this.Топливо.HeaderText = "Топливо";
            this.Топливо.Name = "Топливо";
            this.Топливо.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Топливо.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Кол_во
            // 
            this.Кол_во.HeaderText = "Кол-во топлива";
            this.Кол_во.Name = "Кол_во";
            // 
            // Цена
            // 
            this.Цена.HeaderText = "Цена за ед.";
            this.Цена.Name = "Цена";
            // 
            // Датапоставки
            // 
            this.Датапоставки.HeaderText = "Дата поставки";
            this.Датапоставки.Name = "Датапоставки";
            this.Датапоставки.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Датапоставки.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Сумма
            // 
            this.Сумма.HeaderText = "Сумма";
            this.Сумма.Name = "Сумма";
            this.Сумма.Visible = false;
            // 
            // Датазакл
            // 
            this.Датазакл.HeaderText = "Дата заключения";
            this.Датазакл.Name = "Датазакл";
            this.Датазакл.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Датазакл.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // diplomruDataSetBindingSource
            // 
            this.diplomruDataSetBindingSource.DataSource = this.diplom_ruDataSet;
            this.diplomruDataSetBindingSource.Position = 0;
            // 
            // diplom_ruDataSet
            // 
            this.diplom_ruDataSet.DataSetName = "Diplom_ruDataSet";
            this.diplom_ruDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Кол-во топлива";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Цена за ед.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewCalendarColumn1
            // 
            this.dataGridViewCalendarColumn1.HeaderText = "Дата поставки";
            this.dataGridViewCalendarColumn1.Name = "dataGridViewCalendarColumn1";
            this.dataGridViewCalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewCalendarColumn2
            // 
            this.dataGridViewCalendarColumn2.HeaderText = "Дата заключения";
            this.dataGridViewCalendarColumn2.Name = "dataGridViewCalendarColumn2";
            this.dataGridViewCalendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCalendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Contract_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(883, 267);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Contract_add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Contract_add";
            this.Load += new System.EventHandler(this.Contract_add_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplomruDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplom_ruDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource diplomruDataSetBindingSource;
        private Diplom_ruDataSet diplom_ruDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCalendarColumn dataGridViewCalendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCalendarColumn dataGridViewCalendarColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Сотрудник;
        private System.Windows.Forms.DataGridViewComboBoxColumn Поставщик;
        private System.Windows.Forms.DataGridViewComboBoxColumn Топливо;
        private System.Windows.Forms.DataGridViewTextBoxColumn Кол_во;
        private System.Windows.Forms.DataGridViewTextBoxColumn Цена;
        private System.Windows.Forms.DataGridViewCalendarColumn Датапоставки;
        private System.Windows.Forms.DataGridViewTextBoxColumn Сумма;
        private System.Windows.Forms.DataGridViewCalendarColumn Датазакл;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}