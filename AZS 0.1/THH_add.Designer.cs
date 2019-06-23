namespace AZS_0._1
{
    partial class THH_add
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
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diplom_ruDataSet = new AZS_0._1.Diplom_ruDataSet();
            this.diplomruDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Поставщик_тнн = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Заправка_тнн = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Топливо_тнн = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCalendarColumn1 = new System.Windows.Forms.DataGridViewCalendarColumn();
            this.Кол_во = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Цена = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата = new System.Windows.Forms.DataGridViewCalendarColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diplom_ruDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplomruDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(744, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // diplom_ruDataSet
            // 
            this.diplom_ruDataSet.DataSetName = "Diplom_ruDataSet";
            this.diplom_ruDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // diplomruDataSetBindingSource
            // 
            this.diplomruDataSetBindingSource.DataSource = this.diplom_ruDataSet;
            this.diplomruDataSetBindingSource.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Поставщик_тнн,
            this.Заправка_тнн,
            this.Топливо_тнн,
            this.Кол_во,
            this.Цена,
            this.Дата});
            this.dataGridView1.DataSource = this.diplomruDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(744, 139);
            this.dataGridView1.TabIndex = 5;
            // 
            // Поставщик_тнн
            // 
            this.Поставщик_тнн.HeaderText = "Поставщик";
            this.Поставщик_тнн.Name = "Поставщик_тнн";
            this.Поставщик_тнн.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Поставщик_тнн.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Поставщик_тнн.Width = 120;
            // 
            // Заправка_тнн
            // 
            this.Заправка_тнн.HeaderText = "Заправка";
            this.Заправка_тнн.Name = "Заправка_тнн";
            this.Заправка_тнн.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Заправка_тнн.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Заправка_тнн.Width = 175;
            // 
            // Топливо_тнн
            // 
            this.Топливо_тнн.HeaderText = "Топливо";
            this.Топливо_тнн.Name = "Топливо_тнн";
            this.Топливо_тнн.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Топливо_тнн.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.dataGridViewCalendarColumn1.HeaderText = "Дата";
            this.dataGridViewCalendarColumn1.Name = "dataGridViewCalendarColumn1";
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
            // Дата
            // 
            this.Дата.HeaderText = "Дата";
            this.Дата.Name = "Дата";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // THH_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(744, 175);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(744, 175);
            this.Name = "THH_add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "THH_add";
            this.Load += new System.EventHandler(this.THH_add_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diplom_ruDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplomruDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private Diplom_ruDataSet diplom_ruDataSet;
        private System.Windows.Forms.BindingSource diplomruDataSetBindingSource;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn Поставщик_тнн;
        private System.Windows.Forms.DataGridViewComboBoxColumn Заправка_тнн;
        private System.Windows.Forms.DataGridViewComboBoxColumn Топливо_тнн;
        private System.Windows.Forms.DataGridViewTextBoxColumn Кол_во;
        private System.Windows.Forms.DataGridViewTextBoxColumn Цена;
        private System.Windows.Forms.DataGridViewCalendarColumn Дата;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCalendarColumn dataGridViewCalendarColumn1;
    }
}