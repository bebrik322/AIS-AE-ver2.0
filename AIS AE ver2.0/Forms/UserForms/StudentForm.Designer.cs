namespace AIS_AE_ver2._0
{
    partial class StudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            this.StudentTabs = new System.Windows.Forms.TabControl();
            this.JournalTab = new System.Windows.Forms.TabPage();
            this.StudentPrintButton = new System.Windows.Forms.Button();
            this.StudentSaveButton = new System.Windows.Forms.Button();
            this.StudentNameOutput = new System.Windows.Forms.Label();
            this.HelloStudentLabel = new System.Windows.Forms.Label();
            this.GradesInfoOutputLabel = new System.Windows.Forms.Label();
            this.GradesInfoLabel = new System.Windows.Forms.Label();
            this.JournalGridView = new System.Windows.Forms.DataGridView();
            this.JournalSubjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalTeacherColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalGradeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SheduleTab = new System.Windows.Forms.TabPage();
            this.GroupLabel = new System.Windows.Forms.Label();
            this.GroupComboBox = new System.Windows.Forms.ComboBox();
            this.DayTabControl = new System.Windows.Forms.TabControl();
            this.MondayTab = new System.Windows.Forms.TabPage();
            this.MondayDataGridView = new System.Windows.Forms.DataGridView();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuesdayTab = new System.Windows.Forms.TabPage();
            this.TuesdayDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WednesdayTab = new System.Windows.Forms.TabPage();
            this.WednesdayDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThursdayTab = new System.Windows.Forms.TabPage();
            this.ThursdayDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FridayTab = new System.Windows.Forms.TabPage();
            this.FridayDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.StudentAVGGradeButton = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentTabs.SuspendLayout();
            this.JournalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalGridView)).BeginInit();
            this.SheduleTab.SuspendLayout();
            this.DayTabControl.SuspendLayout();
            this.MondayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MondayDataGridView)).BeginInit();
            this.TuesdayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayDataGridView)).BeginInit();
            this.WednesdayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayDataGridView)).BeginInit();
            this.ThursdayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayDataGridView)).BeginInit();
            this.FridayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FridayDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentTabs
            // 
            this.StudentTabs.Controls.Add(this.JournalTab);
            this.StudentTabs.Controls.Add(this.SheduleTab);
            this.StudentTabs.Location = new System.Drawing.Point(12, 32);
            this.StudentTabs.Name = "StudentTabs";
            this.StudentTabs.SelectedIndex = 0;
            this.StudentTabs.Size = new System.Drawing.Size(776, 406);
            this.StudentTabs.TabIndex = 0;
            // 
            // JournalTab
            // 
            this.JournalTab.Controls.Add(this.label1);
            this.JournalTab.Controls.Add(this.StudentAVGGradeButton);
            this.JournalTab.Controls.Add(this.StudentPrintButton);
            this.JournalTab.Controls.Add(this.StudentSaveButton);
            this.JournalTab.Controls.Add(this.StudentNameOutput);
            this.JournalTab.Controls.Add(this.HelloStudentLabel);
            this.JournalTab.Controls.Add(this.GradesInfoOutputLabel);
            this.JournalTab.Controls.Add(this.GradesInfoLabel);
            this.JournalTab.Controls.Add(this.JournalGridView);
            this.JournalTab.Location = new System.Drawing.Point(4, 25);
            this.JournalTab.Name = "JournalTab";
            this.JournalTab.Padding = new System.Windows.Forms.Padding(3);
            this.JournalTab.Size = new System.Drawing.Size(768, 377);
            this.JournalTab.TabIndex = 0;
            this.JournalTab.Text = "Журнал";
            this.JournalTab.UseVisualStyleBackColor = true;
            // 
            // StudentPrintButton
            // 
            this.StudentPrintButton.Location = new System.Drawing.Point(670, 334);
            this.StudentPrintButton.Name = "StudentPrintButton";
            this.StudentPrintButton.Size = new System.Drawing.Size(92, 23);
            this.StudentPrintButton.TabIndex = 6;
            this.StudentPrintButton.Text = "Друк";
            this.StudentPrintButton.UseVisualStyleBackColor = true;
            this.StudentPrintButton.Click += new System.EventHandler(this.StudentPrintButton_Click);
            // 
            // StudentSaveButton
            // 
            this.StudentSaveButton.Location = new System.Drawing.Point(670, 305);
            this.StudentSaveButton.Name = "StudentSaveButton";
            this.StudentSaveButton.Size = new System.Drawing.Size(92, 23);
            this.StudentSaveButton.TabIndex = 5;
            this.StudentSaveButton.Text = "Зберегти";
            this.StudentSaveButton.UseVisualStyleBackColor = true;
            this.StudentSaveButton.Click += new System.EventHandler(this.StudentSaveButton_Click);
            // 
            // StudentNameOutput
            // 
            this.StudentNameOutput.AutoSize = true;
            this.StudentNameOutput.Location = new System.Drawing.Point(100, 308);
            this.StudentNameOutput.Name = "StudentNameOutput";
            this.StudentNameOutput.Size = new System.Drawing.Size(100, 16);
            this.StudentNameOutput.TabIndex = 4;
            this.StudentNameOutput.Text = "Не визначено";
            // 
            // HelloStudentLabel
            // 
            this.HelloStudentLabel.AutoSize = true;
            this.HelloStudentLabel.Location = new System.Drawing.Point(6, 308);
            this.HelloStudentLabel.Name = "HelloStudentLabel";
            this.HelloStudentLabel.Size = new System.Drawing.Size(88, 16);
            this.HelloStudentLabel.TabIndex = 3;
            this.HelloStudentLabel.Text = "Студент(ка):";
            // 
            // GradesInfoOutputLabel
            // 
            this.GradesInfoOutputLabel.AutoSize = true;
            this.GradesInfoOutputLabel.Location = new System.Drawing.Point(6, 358);
            this.GradesInfoOutputLabel.Name = "GradesInfoOutputLabel";
            this.GradesInfoOutputLabel.Size = new System.Drawing.Size(100, 16);
            this.GradesInfoOutputLabel.TabIndex = 2;
            this.GradesInfoOutputLabel.Text = "Не визначено";
            // 
            // GradesInfoLabel
            // 
            this.GradesInfoLabel.AutoSize = true;
            this.GradesInfoLabel.Location = new System.Drawing.Point(6, 333);
            this.GradesInfoLabel.Name = "GradesInfoLabel";
            this.GradesInfoLabel.Size = new System.Drawing.Size(261, 16);
            this.GradesInfoLabel.TabIndex = 1;
            this.GradesInfoLabel.Text = "Бали не виставлені по цим предметам:";
            // 
            // JournalGridView
            // 
            this.JournalGridView.AllowUserToAddRows = false;
            this.JournalGridView.AllowUserToDeleteRows = false;
            this.JournalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JournalGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JournalSubjectColumn,
            this.JournalTeacherColumn,
            this.JournalGradeColumn,
            this.JournalDateColumn});
            this.JournalGridView.Location = new System.Drawing.Point(0, 0);
            this.JournalGridView.Name = "JournalGridView";
            this.JournalGridView.ReadOnly = true;
            this.JournalGridView.RowHeadersWidth = 51;
            this.JournalGridView.RowTemplate.Height = 24;
            this.JournalGridView.Size = new System.Drawing.Size(768, 296);
            this.JournalGridView.TabIndex = 0;
            // 
            // JournalSubjectColumn
            // 
            this.JournalSubjectColumn.HeaderText = "Предмет";
            this.JournalSubjectColumn.MinimumWidth = 6;
            this.JournalSubjectColumn.Name = "JournalSubjectColumn";
            this.JournalSubjectColumn.ReadOnly = true;
            this.JournalSubjectColumn.Width = 120;
            // 
            // JournalTeacherColumn
            // 
            this.JournalTeacherColumn.HeaderText = "Викладач";
            this.JournalTeacherColumn.MinimumWidth = 6;
            this.JournalTeacherColumn.Name = "JournalTeacherColumn";
            this.JournalTeacherColumn.ReadOnly = true;
            this.JournalTeacherColumn.Width = 150;
            // 
            // JournalGradeColumn
            // 
            this.JournalGradeColumn.HeaderText = "Бал";
            this.JournalGradeColumn.MinimumWidth = 6;
            this.JournalGradeColumn.Name = "JournalGradeColumn";
            this.JournalGradeColumn.ReadOnly = true;
            this.JournalGradeColumn.Width = 125;
            // 
            // JournalDateColumn
            // 
            this.JournalDateColumn.HeaderText = "Дата виставлення";
            this.JournalDateColumn.MinimumWidth = 6;
            this.JournalDateColumn.Name = "JournalDateColumn";
            this.JournalDateColumn.ReadOnly = true;
            this.JournalDateColumn.Width = 150;
            // 
            // SheduleTab
            // 
            this.SheduleTab.Controls.Add(this.GroupLabel);
            this.SheduleTab.Controls.Add(this.GroupComboBox);
            this.SheduleTab.Controls.Add(this.DayTabControl);
            this.SheduleTab.Location = new System.Drawing.Point(4, 25);
            this.SheduleTab.Name = "SheduleTab";
            this.SheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.SheduleTab.Size = new System.Drawing.Size(768, 377);
            this.SheduleTab.TabIndex = 1;
            this.SheduleTab.Text = "Розклад";
            this.SheduleTab.UseVisualStyleBackColor = true;
            // 
            // GroupLabel
            // 
            this.GroupLabel.AutoSize = true;
            this.GroupLabel.Location = new System.Drawing.Point(525, 9);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(110, 16);
            this.GroupLabel.TabIndex = 3;
            this.GroupLabel.Text = "Оберіть группу:";
            // 
            // GroupComboBox
            // 
            this.GroupComboBox.FormattingEnabled = true;
            this.GroupComboBox.Location = new System.Drawing.Point(641, 6);
            this.GroupComboBox.Name = "GroupComboBox";
            this.GroupComboBox.Size = new System.Drawing.Size(121, 24);
            this.GroupComboBox.TabIndex = 2;
            this.GroupComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupComboBox_SelectedIndexChanged);
            // 
            // DayTabControl
            // 
            this.DayTabControl.Controls.Add(this.MondayTab);
            this.DayTabControl.Controls.Add(this.TuesdayTab);
            this.DayTabControl.Controls.Add(this.WednesdayTab);
            this.DayTabControl.Controls.Add(this.ThursdayTab);
            this.DayTabControl.Controls.Add(this.FridayTab);
            this.DayTabControl.Location = new System.Drawing.Point(-4, 36);
            this.DayTabControl.Name = "DayTabControl";
            this.DayTabControl.SelectedIndex = 0;
            this.DayTabControl.Size = new System.Drawing.Size(776, 345);
            this.DayTabControl.TabIndex = 1;
            // 
            // MondayTab
            // 
            this.MondayTab.Controls.Add(this.MondayDataGridView);
            this.MondayTab.Location = new System.Drawing.Point(4, 25);
            this.MondayTab.Name = "MondayTab";
            this.MondayTab.Padding = new System.Windows.Forms.Padding(3);
            this.MondayTab.Size = new System.Drawing.Size(768, 316);
            this.MondayTab.TabIndex = 0;
            this.MondayTab.Text = "Понеділок";
            this.MondayTab.UseVisualStyleBackColor = true;
            // 
            // MondayDataGridView
            // 
            this.MondayDataGridView.AllowUserToAddRows = false;
            this.MondayDataGridView.AllowUserToDeleteRows = false;
            this.MondayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MondayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Subject,
            this.Teacher,
            this.StartTime,
            this.EndTime});
            this.MondayDataGridView.Location = new System.Drawing.Point(0, 0);
            this.MondayDataGridView.Name = "MondayDataGridView";
            this.MondayDataGridView.ReadOnly = true;
            this.MondayDataGridView.RowHeadersWidth = 51;
            this.MondayDataGridView.RowTemplate.Height = 24;
            this.MondayDataGridView.Size = new System.Drawing.Size(768, 316);
            this.MondayDataGridView.TabIndex = 0;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Предмет";
            this.Subject.MinimumWidth = 6;
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            this.Subject.Width = 125;
            // 
            // Teacher
            // 
            this.Teacher.HeaderText = "Викладач";
            this.Teacher.MinimumWidth = 6;
            this.Teacher.Name = "Teacher";
            this.Teacher.ReadOnly = true;
            this.Teacher.Width = 135;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Початок";
            this.StartTime.MinimumWidth = 6;
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 130;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "Кінець";
            this.EndTime.MinimumWidth = 6;
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Width = 130;
            // 
            // TuesdayTab
            // 
            this.TuesdayTab.Controls.Add(this.TuesdayDataGridView);
            this.TuesdayTab.Location = new System.Drawing.Point(4, 25);
            this.TuesdayTab.Name = "TuesdayTab";
            this.TuesdayTab.Padding = new System.Windows.Forms.Padding(3);
            this.TuesdayTab.Size = new System.Drawing.Size(768, 316);
            this.TuesdayTab.TabIndex = 1;
            this.TuesdayTab.Text = "Вівторок";
            this.TuesdayTab.UseVisualStyleBackColor = true;
            // 
            // TuesdayDataGridView
            // 
            this.TuesdayDataGridView.AllowUserToAddRows = false;
            this.TuesdayDataGridView.AllowUserToDeleteRows = false;
            this.TuesdayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TuesdayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.TuesdayDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TuesdayDataGridView.Name = "TuesdayDataGridView";
            this.TuesdayDataGridView.ReadOnly = true;
            this.TuesdayDataGridView.RowHeadersWidth = 51;
            this.TuesdayDataGridView.RowTemplate.Height = 24;
            this.TuesdayDataGridView.Size = new System.Drawing.Size(768, 316);
            this.TuesdayDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Предмет";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Викладач";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 135;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Початок";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Кінець";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // WednesdayTab
            // 
            this.WednesdayTab.Controls.Add(this.WednesdayDataGridView);
            this.WednesdayTab.Location = new System.Drawing.Point(4, 25);
            this.WednesdayTab.Name = "WednesdayTab";
            this.WednesdayTab.Size = new System.Drawing.Size(768, 316);
            this.WednesdayTab.TabIndex = 2;
            this.WednesdayTab.Text = "Середа";
            this.WednesdayTab.UseVisualStyleBackColor = true;
            // 
            // WednesdayDataGridView
            // 
            this.WednesdayDataGridView.AllowUserToAddRows = false;
            this.WednesdayDataGridView.AllowUserToDeleteRows = false;
            this.WednesdayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WednesdayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.WednesdayDataGridView.Location = new System.Drawing.Point(0, 0);
            this.WednesdayDataGridView.Name = "WednesdayDataGridView";
            this.WednesdayDataGridView.ReadOnly = true;
            this.WednesdayDataGridView.RowHeadersWidth = 51;
            this.WednesdayDataGridView.RowTemplate.Height = 24;
            this.WednesdayDataGridView.Size = new System.Drawing.Size(768, 316);
            this.WednesdayDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Предмет";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Викладач";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 135;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Початок";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 130;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Кінець";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 130;
            // 
            // ThursdayTab
            // 
            this.ThursdayTab.Controls.Add(this.ThursdayDataGridView);
            this.ThursdayTab.Location = new System.Drawing.Point(4, 25);
            this.ThursdayTab.Name = "ThursdayTab";
            this.ThursdayTab.Size = new System.Drawing.Size(768, 316);
            this.ThursdayTab.TabIndex = 3;
            this.ThursdayTab.Text = "Четвер";
            this.ThursdayTab.UseVisualStyleBackColor = true;
            // 
            // ThursdayDataGridView
            // 
            this.ThursdayDataGridView.AllowUserToAddRows = false;
            this.ThursdayDataGridView.AllowUserToDeleteRows = false;
            this.ThursdayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ThursdayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.ThursdayDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ThursdayDataGridView.Name = "ThursdayDataGridView";
            this.ThursdayDataGridView.ReadOnly = true;
            this.ThursdayDataGridView.RowHeadersWidth = 51;
            this.ThursdayDataGridView.RowTemplate.Height = 24;
            this.ThursdayDataGridView.Size = new System.Drawing.Size(768, 316);
            this.ThursdayDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Предмет";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Викладач";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 135;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Початок";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 130;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Кінець";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 130;
            // 
            // FridayTab
            // 
            this.FridayTab.Controls.Add(this.FridayDataGridView);
            this.FridayTab.Location = new System.Drawing.Point(4, 25);
            this.FridayTab.Name = "FridayTab";
            this.FridayTab.Size = new System.Drawing.Size(768, 316);
            this.FridayTab.TabIndex = 4;
            this.FridayTab.Text = "П\'ятниця";
            this.FridayTab.UseVisualStyleBackColor = true;
            // 
            // FridayDataGridView
            // 
            this.FridayDataGridView.AllowUserToAddRows = false;
            this.FridayDataGridView.AllowUserToDeleteRows = false;
            this.FridayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FridayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
            this.FridayDataGridView.Location = new System.Drawing.Point(0, 0);
            this.FridayDataGridView.Name = "FridayDataGridView";
            this.FridayDataGridView.ReadOnly = true;
            this.FridayDataGridView.RowHeadersWidth = 51;
            this.FridayDataGridView.RowTemplate.Height = 24;
            this.FridayDataGridView.Size = new System.Drawing.Size(768, 316);
            this.FridayDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Предмет";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 125;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Викладач";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 135;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Початок";
            this.dataGridViewTextBoxColumn15.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 130;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Кінець";
            this.dataGridViewTextBoxColumn16.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 130;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 3);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "<< Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(93, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(136, 23);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Закрити програму";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // StudentAVGGradeButton
            // 
            this.StudentAVGGradeButton.AutoSize = true;
            this.StudentAVGGradeButton.Location = new System.Drawing.Point(564, 308);
            this.StudentAVGGradeButton.Name = "StudentAVGGradeButton";
            this.StudentAVGGradeButton.Size = new System.Drawing.Size(100, 16);
            this.StudentAVGGradeButton.TabIndex = 7;
            this.StudentAVGGradeButton.Text = "Не визначено";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Середній бал:";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.StudentTabs);
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизований: студент";
            this.StudentTabs.ResumeLayout(false);
            this.JournalTab.ResumeLayout(false);
            this.JournalTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalGridView)).EndInit();
            this.SheduleTab.ResumeLayout(false);
            this.SheduleTab.PerformLayout();
            this.DayTabControl.ResumeLayout(false);
            this.MondayTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MondayDataGridView)).EndInit();
            this.TuesdayTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayDataGridView)).EndInit();
            this.WednesdayTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayDataGridView)).EndInit();
            this.ThursdayTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayDataGridView)).EndInit();
            this.FridayTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FridayDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl StudentTabs;
        private System.Windows.Forms.TabPage JournalTab;
        private System.Windows.Forms.TabPage SheduleTab;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ComboBox GroupComboBox;
        private System.Windows.Forms.TabControl DayTabControl;
        private System.Windows.Forms.TabPage MondayTab;
        private System.Windows.Forms.TabPage TuesdayTab;
        private System.Windows.Forms.TabPage WednesdayTab;
        private System.Windows.Forms.TabPage ThursdayTab;
        private System.Windows.Forms.TabPage FridayTab;
        private System.Windows.Forms.DataGridView MondayDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridView TuesdayDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView WednesdayDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridView ThursdayDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridView FridayDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridView JournalGridView;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.Label GradesInfoLabel;
        private System.Windows.Forms.Label GradesInfoOutputLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalSubjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalTeacherColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalGradeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalDateColumn;
        private System.Windows.Forms.Label HelloStudentLabel;
        private System.Windows.Forms.Label StudentNameOutput;
        private System.Windows.Forms.Button StudentSaveButton;
        private System.Windows.Forms.Button StudentPrintButton;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StudentAVGGradeButton;
    }
}