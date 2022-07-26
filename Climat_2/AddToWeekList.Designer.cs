
namespace Climat_2
{
    partial class AddToWeekList
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
            this.btnSavwToChart = new System.Windows.Forms.Button();
            this.btnClearToChart = new System.Windows.Forms.Button();
            this.btnExitToChart = new System.Windows.Forms.Button();
            this.dataWeekList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.weeklistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataWeekList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weeklistBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSavwToChart
            // 
            this.btnSavwToChart.Location = new System.Drawing.Point(142, 272);
            this.btnSavwToChart.Name = "btnSavwToChart";
            this.btnSavwToChart.Size = new System.Drawing.Size(93, 26);
            this.btnSavwToChart.TabIndex = 0;
            this.btnSavwToChart.Text = "Сохранить";
            this.btnSavwToChart.UseVisualStyleBackColor = true;
            this.btnSavwToChart.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClearToChart
            // 
            this.btnClearToChart.Location = new System.Drawing.Point(260, 273);
            this.btnClearToChart.Name = "btnClearToChart";
            this.btnClearToChart.Size = new System.Drawing.Size(93, 25);
            this.btnClearToChart.TabIndex = 1;
            this.btnClearToChart.Text = "Очистить график";
            this.btnClearToChart.UseVisualStyleBackColor = true;
            this.btnClearToChart.Click += new System.EventHandler(this.btnClearToChart_Click);
            // 
            // btnExitToChart
            // 
            this.btnExitToChart.Location = new System.Drawing.Point(379, 273);
            this.btnExitToChart.Name = "btnExitToChart";
            this.btnExitToChart.Size = new System.Drawing.Size(93, 25);
            this.btnExitToChart.TabIndex = 2;
            this.btnExitToChart.Text = "Отмена";
            this.btnExitToChart.UseVisualStyleBackColor = true;
            this.btnExitToChart.Click += new System.EventHandler(this.btnExitToChart_Click);
            // 
            // dataWeekList
            // 
            this.dataWeekList.AutoGenerateColumns = false;
            this.dataWeekList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataWeekList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataWeekList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataWeekList.DataSource = this.weeklistBindingSource;
            this.dataWeekList.Location = new System.Drawing.Point(0, 0);
            this.dataWeekList.Name = "dataWeekList";
            this.dataWeekList.Size = new System.Drawing.Size(483, 253);
            this.dataWeekList.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "День недели";
            this.Column1.Items.AddRange(new object[] {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота",
            "Воскресенье"});
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 98;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Начало работы";
            this.Column2.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 109;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Окончание работы";
            this.Column3.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 127;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Режим работы";
            this.Column4.Items.AddRange(new object[] {
            "Auto",
            "Eco",
            "Effective",
            "Night"});
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 107;
            // 
            // weeklistBindingSource
            // 
            this.weeklistBindingSource.DataSource = typeof(Climat_2.week_list);
            // 
            // AddToWeekList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 310);
            this.Controls.Add(this.dataWeekList);
            this.Controls.Add(this.btnExitToChart);
            this.Controls.Add(this.btnClearToChart);
            this.Controls.Add(this.btnSavwToChart);
            this.MaximizeBox = false;
            this.Name = "AddToWeekList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка графика работы";
            ((System.ComponentModel.ISupportInitialize)(this.dataWeekList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weeklistBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSavwToChart;
        private System.Windows.Forms.Button btnClearToChart;
        private System.Windows.Forms.Button btnExitToChart;
        private System.Windows.Forms.DataGridView dataWeekList;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.BindingSource weeklistBindingSource;
    }
}