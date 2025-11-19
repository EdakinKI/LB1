namespace View
{
    partial class FilterForm
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

        private void InitializeComponent()
        {
            this.ExerciseGroupBox = new System.Windows.Forms.GroupBox();
            this.CheckedListBoxExercise = new System.Windows.Forms.CheckedListBox();
            this.LabelSearch = new System.Windows.Forms.Label();
            this.TextBoxFilter = new System.Windows.Forms.TextBox();
            this.ButtonFilter = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ExerciseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExerciseGroupBox
            // 
            this.ExerciseGroupBox.Controls.Add(this.CheckedListBoxExercise);
            this.ExerciseGroupBox.Controls.Add(this.ButtonClose);
            this.ExerciseGroupBox.Controls.Add(this.LabelSearch);
            this.ExerciseGroupBox.Controls.Add(this.TextBoxFilter);
            this.ExerciseGroupBox.Location = new System.Drawing.Point(10, 15);
            this.ExerciseGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExerciseGroupBox.Name = "ExerciseGroupBox";
            this.ExerciseGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExerciseGroupBox.Size = new System.Drawing.Size(329, 223);
            this.ExerciseGroupBox.TabIndex = 0;
            this.ExerciseGroupBox.TabStop = false;
            this.ExerciseGroupBox.Text = "Выбор упражнения";
            // 
            // CheckedListBoxExercise
            // 
            this.CheckedListBoxExercise.CheckOnClick = true;
            this.CheckedListBoxExercise.FormattingEnabled = true;
            this.CheckedListBoxExercise.Location = new System.Drawing.Point(10, 23);
            this.CheckedListBoxExercise.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckedListBoxExercise.Name = "CheckedListBoxExercise";
            this.CheckedListBoxExercise.Size = new System.Drawing.Size(311, 72);
            this.CheckedListBoxExercise.TabIndex = 0;
            // 
            // LabelSearch
            // 
            this.LabelSearch.AutoSize = true;
            this.LabelSearch.Location = new System.Drawing.Point(8, 110);
            this.LabelSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(50, 16);
            this.LabelSearch.TabIndex = 1;
            this.LabelSearch.Text = "Поиск:";
            // 
            // TextBoxFilter
            // 
            this.TextBoxFilter.Location = new System.Drawing.Point(66, 110);
            this.TextBoxFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxFilter.Name = "TextBoxFilter";
            this.TextBoxFilter.Size = new System.Drawing.Size(255, 22);
            this.TextBoxFilter.TabIndex = 2;
            this.TextBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxFilter_KeyPress);
            // 
            // ButtonFilter
            // 
            this.ButtonFilter.Location = new System.Drawing.Point(16, 191);
            this.ButtonFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonFilter.Name = "ButtonFilter";
            this.ButtonFilter.Size = new System.Drawing.Size(100, 37);
            this.ButtonFilter.TabIndex = 3;
            this.ButtonFilter.Text = "Фильтр";
            this.ButtonFilter.UseVisualStyleBackColor = true;
            this.ButtonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(221, 176);
            this.ButtonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(100, 37);
            this.ButtonClose.TabIndex = 4;
            this.ButtonClose.Text = "Закрыть";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(124, 191);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(100, 37);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Отменить";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 251);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonFilter);
            this.Controls.Add(this.ExerciseGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтр";
            this.ExerciseGroupBox.ResumeLayout(false);
            this.ExerciseGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ExerciseGroupBox;
        private System.Windows.Forms.CheckedListBox CheckedListBoxExercise;
        private System.Windows.Forms.Label LabelSearch;
        private System.Windows.Forms.TextBox TextBoxFilter;
        private System.Windows.Forms.Button ButtonFilter;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonCancel;
    }
}