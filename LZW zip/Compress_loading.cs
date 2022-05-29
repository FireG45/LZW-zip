using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LZW_zip
{
    public partial class Compress_Form : Form
    {
        private List<string> files;
        private StreamWriter compressedFile;
        private object MainForm;
        private FileInfo fileInfo;
        private Label sizes_label;

        public Compress_Form(ref List<string> files, StreamWriter compressedFile, object MainForm, ref FileInfo fileInfo, ref Label sizes_label)
        {
            InitializeComponent();
            this.files = files;
            this.compressedFile = compressedFile;
            this.MainForm = MainForm;
            this.fileInfo = fileInfo;
            this.sizes_label = sizes_label;
        }

        private void Compress_Form_Shown(object sender, EventArgs e)
        {
            Action action;
            progressBar1.BeginInvoke(action = new Action(() =>
            {
                LZW.SetProgressBar(ref progressBar1);
                var filesSizes = 0;
                foreach (var item in files)
                {
                    try
                    {
                        FileStream f = File.Open(item, FileMode.Open);
                        filesSizes += (int)f.Length;
                        f.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                int i = 1;
                foreach (var filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show("Такого файла не сущетсвует!");
                        return;
                    }
                    FileStream file;
                    try
                    {
                        file = File.OpenRead(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    compressedFile.WriteLine(Path.GetFileName(filePath));
                    try
                    {

                        label1.Text = $"{i}/{files.Count} {Path.GetFileName(filePath)}";
                        LZW.Compress(file, compressedFile);
                        file.Close();
                        compressedFile.WriteLine('e');
                        i++;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    LZW.ResetDictionary();
                }
                compressedFile.Close();
                LZW.ResetDictionary();
                files.Clear();


                this.Close();


                float compressed_size = (float)fileInfo.Length / 1024 / 1024;
                float initial_size = (float)LZW.last_initial_size / 1024 / 1024;
                float coefficient = 100 - (compressed_size / initial_size) * 100;

                if (files.Count > 1)
                    sizes_label.Text = $"Размер исходных файлов: {initial_size} МБ\nРазмер архива: {compressed_size} МБ\nКоэффициент сжатия: {coefficient} %";
                else
                    sizes_label.Text = $"Размер исходного файла: {initial_size} МБ\nРазмер архива: {compressed_size} МБ\nКоэффициент сжатия: {coefficient} %";
            }));
        }
    }
}
