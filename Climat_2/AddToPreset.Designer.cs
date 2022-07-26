
namespace Climat_2
{
    partial class AddToPreset
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPresetName = new System.Windows.Forms.TextBox();
            this.btnSaveToPreset = new System.Windows.Forms.Button();
            this.btnSaveToPresetCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите название режима:";
            // 
            // txtPresetName
            // 
            this.txtPresetName.Location = new System.Drawing.Point(164, 42);
            this.txtPresetName.Name = "txtPresetName";
            this.txtPresetName.Size = new System.Drawing.Size(254, 20);
            this.txtPresetName.TabIndex = 1;
            // 
            // btnSaveToPreset
            // 
            this.btnSaveToPreset.Location = new System.Drawing.Point(247, 118);
            this.btnSaveToPreset.Name = "btnSaveToPreset";
            this.btnSaveToPreset.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToPreset.TabIndex = 2;
            this.btnSaveToPreset.Text = "Сохранить";
            this.btnSaveToPreset.UseVisualStyleBackColor = true;
            this.btnSaveToPreset.Click += new System.EventHandler(this.btnSaveToPreset_Click);
            // 
            // btnSaveToPresetCancel
            // 
            this.btnSaveToPresetCancel.Location = new System.Drawing.Point(343, 118);
            this.btnSaveToPresetCancel.Name = "btnSaveToPresetCancel";
            this.btnSaveToPresetCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToPresetCancel.TabIndex = 3;
            this.btnSaveToPresetCancel.Text = "Отмена";
            this.btnSaveToPresetCancel.UseVisualStyleBackColor = true;
            this.btnSaveToPresetCancel.Click += new System.EventHandler(this.btnSaveToPresetCancel_Click);
            // 
            // AddToPreset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 161);
            this.Controls.Add(this.btnSaveToPresetCancel);
            this.Controls.Add(this.btnSaveToPreset);
            this.Controls.Add(this.txtPresetName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddToPreset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание пользовательского режима";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPresetName;
        private System.Windows.Forms.Button btnSaveToPreset;
        private System.Windows.Forms.Button btnSaveToPresetCancel;
    }
}