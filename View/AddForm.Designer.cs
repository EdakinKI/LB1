namespace View
{
    partial class AddExerciseForm
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
            this.ComboBoxExercise = new System.Windows.Forms.ComboBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.LabelParameters = new System.Windows.Forms.Label();
            this.PanelRunning = new System.Windows.Forms.Panel();
            this.LabelRunningDistanceUnit = new System.Windows.Forms.Label();
            this.NumericRunningDistance = new System.Windows.Forms.NumericUpDown();
            this.LabelRunningDistance = new System.Windows.Forms.Label();
            this.LabelIntensityUnit = new System.Windows.Forms.Label();
            this.NumericIntensity = new System.Windows.Forms.NumericUpDown();
            this.LabelIntensity = new System.Windows.Forms.Label();
            this.PanelSwimming = new System.Windows.Forms.Panel();
            this.LabelSwimmingDistanceUnit = new System.Windows.Forms.Label();
            this.NumericSwimmingDistance = new System.Windows.Forms.NumericUpDown();
            this.LabelSwimmingDistance = new System.Windows.Forms.Label();
            this.ComboBoxStyle = new System.Windows.Forms.ComboBox();
            this.LabelStyle = new System.Windows.Forms.Label();
            this.PanelBenchPress = new System.Windows.Forms.Panel();
            this.LabelRepetitionsUnit = new System.Windows.Forms.Label();
            this.NumericRepetitions = new System.Windows.Forms.NumericUpDown();
            this.LabelRepetitions = new System.Windows.Forms.Label();
            this.LabelWeightUnit = new System.Windows.Forms.Label();
            this.NumericWeight = new System.Windows.Forms.NumericUpDown();
            this.LabelWeight = new System.Windows.Forms.Label();
            this.ButtonCreate = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonCreateRandom = new System.Windows.Forms.Button();
            this.ExerciseGroupBox.SuspendLayout();
            this.PanelRunning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRunningDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericIntensity)).BeginInit();
            this.PanelSwimming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericSwimmingDistance)).BeginInit();
            this.PanelBenchPress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRepetitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // ExerciseGroupBox
            // 
            this.ExerciseGroupBox.Controls.Add(this.ComboBoxExercise);
            this.ExerciseGroupBox.Location = new System.Drawing.Point(16, 15);
            this.ExerciseGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.ExerciseGroupBox.Name = "ExerciseGroupBox";
            this.ExerciseGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.ExerciseGroupBox.Size = new System.Drawing.Size(295, 62);
            this.ExerciseGroupBox.TabIndex = 0;
            this.ExerciseGroupBox.TabStop = false;
            this.ExerciseGroupBox.Text = "Выбор упражнения";
            // 
            // ComboBoxExercise
            // 
            this.ComboBoxExercise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxExercise.FormattingEnabled = true;
            this.ComboBoxExercise.Location = new System.Drawing.Point(8, 23);
            this.ComboBoxExercise.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxExercise.Name = "ComboBoxExercise";
            this.ComboBoxExercise.Size = new System.Drawing.Size(278, 24);
            this.ComboBoxExercise.TabIndex = 0;
            this.ComboBoxExercise.SelectedIndexChanged += new System.EventHandler(this.ComboBoxExercise_SelectedIndexChanged);
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(16, 92);
            this.LabelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(76, 16);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "Название:";
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(104, 89);
            this.TextBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxName.MaxLength = 50;
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(198, 22);
            this.TextBoxName.TabIndex = 2;
            // 
            // LabelParameters
            // 
            this.LabelParameters.AutoSize = true;
            this.LabelParameters.Location = new System.Drawing.Point(16, 129);
            this.LabelParameters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelParameters.Name = "LabelParameters";
            this.LabelParameters.Size = new System.Drawing.Size(85, 16);
            this.LabelParameters.TabIndex = 3;
            this.LabelParameters.Text = "Параметры:";
            // 
            // PanelRunning
            // 
            this.PanelRunning.Controls.Add(this.LabelRunningDistanceUnit);
            this.PanelRunning.Controls.Add(this.NumericRunningDistance);
            this.PanelRunning.Controls.Add(this.LabelRunningDistance);
            this.PanelRunning.Controls.Add(this.LabelIntensityUnit);
            this.PanelRunning.Controls.Add(this.NumericIntensity);
            this.PanelRunning.Controls.Add(this.LabelIntensity);
            this.PanelRunning.Location = new System.Drawing.Point(16, 149);
            this.PanelRunning.Margin = new System.Windows.Forms.Padding(4);
            this.PanelRunning.Name = "PanelRunning";
            this.PanelRunning.Size = new System.Drawing.Size(295, 98);
            this.PanelRunning.TabIndex = 4;
            // 
            // LabelRunningDistanceUnit
            // 
            this.LabelRunningDistanceUnit.AutoSize = true;
            this.LabelRunningDistanceUnit.Location = new System.Drawing.Point(251, 58);
            this.LabelRunningDistanceUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelRunningDistanceUnit.Name = "LabelRunningDistanceUnit";
            this.LabelRunningDistanceUnit.Size = new System.Drawing.Size(23, 16);
            this.LabelRunningDistanceUnit.TabIndex = 5;
            this.LabelRunningDistanceUnit.Text = "км";
            // 
            // NumericRunningDistance
            // 
            this.NumericRunningDistance.DecimalPlaces = 2;
            this.NumericRunningDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NumericRunningDistance.Location = new System.Drawing.Point(123, 56);
            this.NumericRunningDistance.Margin = new System.Windows.Forms.Padding(4);
            this.NumericRunningDistance.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NumericRunningDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NumericRunningDistance.Name = "NumericRunningDistance";
            this.NumericRunningDistance.Size = new System.Drawing.Size(120, 22);
            this.NumericRunningDistance.TabIndex = 3;
            this.NumericRunningDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // LabelRunningDistance
            // 
            this.LabelRunningDistance.AutoSize = true;
            this.LabelRunningDistance.Location = new System.Drawing.Point(4, 58);
            this.LabelRunningDistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelRunningDistance.Name = "LabelRunningDistance";
            this.LabelRunningDistance.Size = new System.Drawing.Size(80, 16);
            this.LabelRunningDistance.TabIndex = 2;
            this.LabelRunningDistance.Text = "Дистанция:";
            // 
            // LabelIntensityUnit
            // 
            this.LabelIntensityUnit.AutoSize = true;
            this.LabelIntensityUnit.Location = new System.Drawing.Point(251, 21);
            this.LabelIntensityUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelIntensityUnit.Name = "LabelIntensityUnit";
            this.LabelIntensityUnit.Size = new System.Drawing.Size(35, 16);
            this.LabelIntensityUnit.TabIndex = 4;
            this.LabelIntensityUnit.Text = "км/ч";
            // 
            // NumericIntensity
            // 
            this.NumericIntensity.DecimalPlaces = 2;
            this.NumericIntensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NumericIntensity.Location = new System.Drawing.Point(123, 19);
            this.NumericIntensity.Margin = new System.Windows.Forms.Padding(4);
            this.NumericIntensity.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.NumericIntensity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NumericIntensity.Name = "NumericIntensity";
            this.NumericIntensity.Size = new System.Drawing.Size(120, 22);
            this.NumericIntensity.TabIndex = 1;
            this.NumericIntensity.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // LabelIntensity
            // 
            this.LabelIntensity.AutoSize = true;
            this.LabelIntensity.Location = new System.Drawing.Point(4, 21);
            this.LabelIntensity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelIntensity.Name = "LabelIntensity";
            this.LabelIntensity.Size = new System.Drawing.Size(111, 16);
            this.LabelIntensity.TabIndex = 0;
            this.LabelIntensity.Text = "Интенсивность:";
            // 
            // PanelSwimming
            // 
            this.PanelSwimming.Controls.Add(this.LabelSwimmingDistanceUnit);
            this.PanelSwimming.Controls.Add(this.NumericSwimmingDistance);
            this.PanelSwimming.Controls.Add(this.LabelSwimmingDistance);
            this.PanelSwimming.Controls.Add(this.ComboBoxStyle);
            this.PanelSwimming.Controls.Add(this.LabelStyle);
            this.PanelSwimming.Location = new System.Drawing.Point(16, 149);
            this.PanelSwimming.Margin = new System.Windows.Forms.Padding(4);
            this.PanelSwimming.Name = "PanelSwimming";
            this.PanelSwimming.Size = new System.Drawing.Size(295, 98);
            this.PanelSwimming.TabIndex = 5;
            // 
            // LabelSwimmingDistanceUnit
            // 
            this.LabelSwimmingDistanceUnit.AutoSize = true;
            this.LabelSwimmingDistanceUnit.Location = new System.Drawing.Point(251, 58);
            this.LabelSwimmingDistanceUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSwimmingDistanceUnit.Name = "LabelSwimmingDistanceUnit";
            this.LabelSwimmingDistanceUnit.Size = new System.Drawing.Size(16, 16);
            this.LabelSwimmingDistanceUnit.TabIndex = 4;
            this.LabelSwimmingDistanceUnit.Text = "м";
            // 
            // NumericSwimmingDistance
            // 
            this.NumericSwimmingDistance.DecimalPlaces = 2;
            this.NumericSwimmingDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericSwimmingDistance.Location = new System.Drawing.Point(123, 56);
            this.NumericSwimmingDistance.Margin = new System.Windows.Forms.Padding(4);
            this.NumericSwimmingDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericSwimmingDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericSwimmingDistance.Name = "NumericSwimmingDistance";
            this.NumericSwimmingDistance.Size = new System.Drawing.Size(120, 22);
            this.NumericSwimmingDistance.TabIndex = 3;
            this.NumericSwimmingDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelSwimmingDistance
            // 
            this.LabelSwimmingDistance.AutoSize = true;
            this.LabelSwimmingDistance.Location = new System.Drawing.Point(4, 58);
            this.LabelSwimmingDistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSwimmingDistance.Name = "LabelSwimmingDistance";
            this.LabelSwimmingDistance.Size = new System.Drawing.Size(80, 16);
            this.LabelSwimmingDistance.TabIndex = 2;
            this.LabelSwimmingDistance.Text = "Дистанция:";
            // 
            // ComboBoxStyle
            // 
            this.ComboBoxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStyle.FormattingEnabled = true;
            this.ComboBoxStyle.Location = new System.Drawing.Point(123, 19);
            this.ComboBoxStyle.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxStyle.Name = "ComboBoxStyle";
            this.ComboBoxStyle.Size = new System.Drawing.Size(120, 24);
            this.ComboBoxStyle.TabIndex = 1;
            // 
            // LabelStyle
            // 
            this.LabelStyle.AutoSize = true;
            this.LabelStyle.Location = new System.Drawing.Point(4, 22);
            this.LabelStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelStyle.Name = "LabelStyle";
            this.LabelStyle.Size = new System.Drawing.Size(49, 16);
            this.LabelStyle.TabIndex = 0;
            this.LabelStyle.Text = "Стиль:";
            // 
            // PanelBenchPress
            // 
            this.PanelBenchPress.Controls.Add(this.LabelRepetitionsUnit);
            this.PanelBenchPress.Controls.Add(this.NumericRepetitions);
            this.PanelBenchPress.Controls.Add(this.LabelRepetitions);
            this.PanelBenchPress.Controls.Add(this.LabelWeightUnit);
            this.PanelBenchPress.Controls.Add(this.NumericWeight);
            this.PanelBenchPress.Controls.Add(this.LabelWeight);
            this.PanelBenchPress.Location = new System.Drawing.Point(16, 149);
            this.PanelBenchPress.Margin = new System.Windows.Forms.Padding(4);
            this.PanelBenchPress.Name = "PanelBenchPress";
            this.PanelBenchPress.Size = new System.Drawing.Size(295, 98);
            this.PanelBenchPress.TabIndex = 6;
            // 
            // LabelRepetitionsUnit
            // 
            this.LabelRepetitionsUnit.AutoSize = true;
            this.LabelRepetitionsUnit.Location = new System.Drawing.Point(251, 58);
            this.LabelRepetitionsUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelRepetitionsUnit.Name = "LabelRepetitionsUnit";
            this.LabelRepetitionsUnit.Size = new System.Drawing.Size(31, 16);
            this.LabelRepetitionsUnit.TabIndex = 5;
            this.LabelRepetitionsUnit.Text = "раз";
            // 
            // NumericRepetitions
            // 
            this.NumericRepetitions.Location = new System.Drawing.Point(123, 56);
            this.NumericRepetitions.Margin = new System.Windows.Forms.Padding(4);
            this.NumericRepetitions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericRepetitions.Name = "NumericRepetitions";
            this.NumericRepetitions.Size = new System.Drawing.Size(120, 22);
            this.NumericRepetitions.TabIndex = 3;
            this.NumericRepetitions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelRepetitions
            // 
            this.LabelRepetitions.AutoSize = true;
            this.LabelRepetitions.Location = new System.Drawing.Point(4, 58);
            this.LabelRepetitions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelRepetitions.Name = "LabelRepetitions";
            this.LabelRepetitions.Size = new System.Drawing.Size(90, 16);
            this.LabelRepetitions.TabIndex = 2;
            this.LabelRepetitions.Text = "Повторения:";
            // 
            // LabelWeightUnit
            // 
            this.LabelWeightUnit.AutoSize = true;
            this.LabelWeightUnit.Location = new System.Drawing.Point(251, 21);
            this.LabelWeightUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelWeightUnit.Name = "LabelWeightUnit";
            this.LabelWeightUnit.Size = new System.Drawing.Size(20, 16);
            this.LabelWeightUnit.TabIndex = 4;
            this.LabelWeightUnit.Text = "кг";
            // 
            // NumericWeight
            // 
            this.NumericWeight.DecimalPlaces = 2;
            this.NumericWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericWeight.Location = new System.Drawing.Point(123, 19);
            this.NumericWeight.Margin = new System.Windows.Forms.Padding(4);
            this.NumericWeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumericWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericWeight.Name = "NumericWeight";
            this.NumericWeight.Size = new System.Drawing.Size(120, 22);
            this.NumericWeight.TabIndex = 1;
            this.NumericWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelWeight
            // 
            this.LabelWeight.AutoSize = true;
            this.LabelWeight.Location = new System.Drawing.Point(4, 21);
            this.LabelWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelWeight.Name = "LabelWeight";
            this.LabelWeight.Size = new System.Drawing.Size(34, 16);
            this.LabelWeight.TabIndex = 0;
            this.LabelWeight.Text = "Вес:";
            // 
            // ButtonCreate
            // 
            this.ButtonCreate.Location = new System.Drawing.Point(16, 260);
            this.ButtonCreate.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonCreate.Name = "ButtonCreate";
            this.ButtonCreate.Size = new System.Drawing.Size(139, 37);
            this.ButtonCreate.TabIndex = 7;
            this.ButtonCreate.Text = "Создать";
            this.ButtonCreate.UseVisualStyleBackColor = true;
            this.ButtonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(173, 260);
            this.ButtonClose.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(138, 37);
            this.ButtonClose.TabIndex = 8;
            this.ButtonClose.Text = "Закрыть";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonCreateRandom
            // 
            this.ButtonCreateRandom.Location = new System.Drawing.Point(16, 305);
            this.ButtonCreateRandom.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonCreateRandom.Name = "ButtonCreateRandom";
            this.ButtonCreateRandom.Size = new System.Drawing.Size(295, 37);
            this.ButtonCreateRandom.TabIndex = 9;
            this.ButtonCreateRandom.Text = "Создать случайное";
            this.ButtonCreateRandom.UseVisualStyleBackColor = true;
            this.ButtonCreateRandom.Click += new System.EventHandler(this.ButtonCreateRandom_Click);
            // 
            // AddExerciseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 354);
            this.Controls.Add(this.PanelSwimming);
            this.Controls.Add(this.ButtonCreateRandom);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonCreate);
            this.Controls.Add(this.LabelParameters);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.PanelBenchPress);
            this.Controls.Add(this.ExerciseGroupBox);
            this.Controls.Add(this.PanelRunning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddExerciseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить упражнение";
            this.ExerciseGroupBox.ResumeLayout(false);
            this.PanelRunning.ResumeLayout(false);
            this.PanelRunning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRunningDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericIntensity)).EndInit();
            this.PanelSwimming.ResumeLayout(false);
            this.PanelSwimming.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericSwimmingDistance)).EndInit();
            this.PanelBenchPress.ResumeLayout(false);
            this.PanelBenchPress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRepetitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ExerciseGroupBox;
        private System.Windows.Forms.ComboBox ComboBoxExercise;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label LabelParameters;
        private System.Windows.Forms.Panel PanelRunning;
        private System.Windows.Forms.NumericUpDown NumericRunningDistance;
        private System.Windows.Forms.Label LabelRunningDistance;
        private System.Windows.Forms.NumericUpDown NumericIntensity;
        private System.Windows.Forms.Label LabelIntensity;
        private System.Windows.Forms.Panel PanelSwimming;
        private System.Windows.Forms.NumericUpDown NumericSwimmingDistance;
        private System.Windows.Forms.Label LabelSwimmingDistance;
        private System.Windows.Forms.ComboBox ComboBoxStyle;
        private System.Windows.Forms.Label LabelStyle;
        private System.Windows.Forms.Panel PanelBenchPress;
        private System.Windows.Forms.NumericUpDown NumericRepetitions;
        private System.Windows.Forms.Label LabelRepetitions;
        private System.Windows.Forms.NumericUpDown NumericWeight;
        private System.Windows.Forms.Label LabelWeight;
        private System.Windows.Forms.Button ButtonCreate;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonCreateRandom;
        private System.Windows.Forms.Label LabelIntensityUnit;
        private System.Windows.Forms.Label LabelRunningDistanceUnit;
        private System.Windows.Forms.Label LabelSwimmingDistanceUnit;
        private System.Windows.Forms.Label LabelWeightUnit;
        private System.Windows.Forms.Label LabelRepetitionsUnit;
    }
}