namespace LZW_zip
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.compress_button = new System.Windows.Forms.Button();
            this.decompress_button = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_addFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_deleteFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_DeleteAll = new System.Windows.Forms.ToolStripButton();
            this.sizes_label = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog11";
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.CheckBoxes = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(386, 312);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            // 
            // compress_button
            // 
            this.compress_button.Location = new System.Drawing.Point(12, 375);
            this.compress_button.Name = "compress_button";
            this.compress_button.Size = new System.Drawing.Size(120, 23);
            this.compress_button.TabIndex = 6;
            this.compress_button.Text = "Заархивировать";
            this.compress_button.UseVisualStyleBackColor = true;
            this.compress_button.Click += new System.EventHandler(this.compress_button_Click);
            // 
            // decompress_button
            // 
            this.decompress_button.Location = new System.Drawing.Point(12, 346);
            this.decompress_button.Name = "decompress_button";
            this.decompress_button.Size = new System.Drawing.Size(120, 23);
            this.decompress_button.TabIndex = 5;
            this.decompress_button.Text = "Разархивировать";
            this.decompress_button.UseVisualStyleBackColor = true;
            this.decompress_button.Click += new System.EventHandler(this.decompress_button_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_addFile,
            this.toolStripButton_deleteFile,
            this.toolStripSeparator1,
            this.toolStripButton_DeleteAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(410, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_addFile
            // 
            this.toolStripButton_addFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_addFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_addFile.Image")));
            this.toolStripButton_addFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addFile.Name = "toolStripButton_addFile";
            this.toolStripButton_addFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_addFile.Text = "Добавить файлы";
            this.toolStripButton_addFile.Click += new System.EventHandler(this.toolStripButton_addFile_Click);
            // 
            // toolStripButton_deleteFile
            // 
            this.toolStripButton_deleteFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_deleteFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_deleteFile.Image")));
            this.toolStripButton_deleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_deleteFile.Name = "toolStripButton_deleteFile";
            this.toolStripButton_deleteFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_deleteFile.Text = "Удалить выбранные файлы";
            this.toolStripButton_deleteFile.Click += new System.EventHandler(this.toolStripButton_deleteFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_DeleteAll
            // 
            this.toolStripButton_DeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_DeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_DeleteAll.Image")));
            this.toolStripButton_DeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DeleteAll.Name = "toolStripButton_DeleteAll";
            this.toolStripButton_DeleteAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_DeleteAll.Text = "Удалить все";
            this.toolStripButton_DeleteAll.Click += new System.EventHandler(this.toolStripButton_DeleteAll_Click);
            // 
            // sizes_label
            // 
            this.sizes_label.AutoSize = true;
            this.sizes_label.Location = new System.Drawing.Point(180, 351);
            this.sizes_label.Name = "sizes_label";
            this.sizes_label.Size = new System.Drawing.Size(182, 39);
            this.sizes_label.TabIndex = 8;
            this.sizes_label.Text = "Размер исходного файла: 0,00 МБ\r\nРазмер архива: 0,00 МБ\r\nКоэффициент сжатия: 0%";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 410);
            this.Controls.Add(this.sizes_label);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.decompress_button);
            this.Controls.Add(this.compress_button);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LZW архиватор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button decompress_button;
        private System.Windows.Forms.Button compress_button;
        private System.Windows.Forms.ListView listView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_addFile;
        private System.Windows.Forms.ToolStripButton toolStripButton_deleteFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_DeleteAll;
        public System.Windows.Forms.Label sizes_label;
    }
}

