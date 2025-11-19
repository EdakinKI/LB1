namespace View
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ExercisesGroupBox = new System.Windows.Forms.GroupBox();
            this.ExerciseDataGridView = new System.Windows.Forms.DataGridView();
            this.exerciseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonFilter = new System.Windows.Forms.Button();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExercisesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExerciseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseBindingSource)).BeginInit();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExercisesGroupBox
            // 
            this.ExercisesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExercisesGroupBox.Controls.Add(this.ButtonClear);
            this.ExercisesGroupBox.Controls.Add(this.ButtonFilter);
            this.ExercisesGroupBox.Controls.Add(this.ButtonAdd);
            this.ExercisesGroupBox.Controls.Add(this.ButtonRemove);
            this.ExercisesGroupBox.Controls.Add(this.ExerciseDataGridView);
            this.ExercisesGroupBox.Location = new System.Drawing.Point(13, 32);
            this.ExercisesGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.ExercisesGroupBox.Name = "ExercisesGroupBox";
            this.ExercisesGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.ExercisesGroupBox.Size = new System.Drawing.Size(992, 304);
            this.ExercisesGroupBox.TabIndex = 0;
            this.ExercisesGroupBox.TabStop = false;
            this.ExercisesGroupBox.Text = "Лист упражнений";
            // 
            // ExerciseDataGridView
            // 
            this.ExerciseDataGridView.AllowUserToAddRows = false;
            this.ExerciseDataGridView.AllowUserToDeleteRows = false;
            this.ExerciseDataGridView.AllowUserToResizeRows = false;
            this.ExerciseDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExerciseDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExerciseDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ExerciseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExerciseDataGridView.DataSource = this.exerciseBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExerciseDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExerciseDataGridView.Location = new System.Drawing.Point(8, 23);
            this.ExerciseDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.ExerciseDataGridView.MultiSelect = false;
            this.ExerciseDataGridView.Name = "ExerciseDataGridView";
            this.ExerciseDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExerciseDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ExerciseDataGridView.RowHeadersVisible = false;
            this.ExerciseDataGridView.RowHeadersWidth = 51;
            this.ExerciseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExerciseDataGridView.Size = new System.Drawing.Size(976, 222);
            this.ExerciseDataGridView.TabIndex = 0;
            this.ExerciseDataGridView.SelectionChanged += new System.EventHandler(this.ExerciseDataGridView_SelectionChanged);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAdd.Location = new System.Drawing.Point(8, 253);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(133, 37);
            this.ButtonAdd.TabIndex = 1;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonRemove.Enabled = false;
            this.ButtonRemove.Location = new System.Drawing.Point(149, 253);
            this.ButtonRemove.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(133, 37);
            this.ButtonRemove.TabIndex = 2;
            this.ButtonRemove.Text = "Удалить";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonClear.Enabled = false;
            this.ButtonClear.Location = new System.Drawing.Point(710, 253);
            this.ButtonClear.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(133, 37);
            this.ButtonClear.TabIndex = 3;
            this.ButtonClear.Text = "Удалить всё";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonFilter
            // 
            this.ButtonFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonFilter.Location = new System.Drawing.Point(851, 253);
            this.ButtonFilter.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonFilter.Name = "ButtonFilter";
            this.ButtonFilter.Size = new System.Drawing.Size(133, 37);
            this.ButtonFilter.TabIndex = 4;
            this.ButtonFilter.Text = "Фильтр";
            this.ButtonFilter.UseVisualStyleBackColor = true;
            this.ButtonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1021, 28);
            this.MainMenuStrip.TabIndex = 5;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 349);
            this.Controls.Add(this.ExercisesGroupBox);
            this.Controls.Add(this.MainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор калорий";
            this.ExercisesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExerciseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseBindingSource)).EndInit();
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ExercisesGroupBox;
        private System.Windows.Forms.DataGridView ExerciseDataGridView;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonFilter;
        private new System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.BindingSource exerciseBindingSource;
    }
}