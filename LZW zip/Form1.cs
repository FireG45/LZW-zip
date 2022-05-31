using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LZW_zip
{

    public partial class Form1 : Form
    {
        private List<string> files = new List<string>();

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            listView1.AllowDrop = true;
        }

        private void choose_file_button_Click(object sender, EventArgs e)
        {
            files.Clear();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Clear();
                foreach (var item in openFileDialog1.FileNames)
                {
                    listView1.Items.Add(item);
                    files.Add(item);
                }
            }
        }

        private void compress_button_Click(object sender, EventArgs e)
        {
            LZW.ResetSizes();
            if (listView1.Items.Count == 0)
            {
                EventHandler<EventArgs> @event = choose_file_button_Click;
                @event(this, new EventArgs());
            }

            foreach (var item in files)
            {
                if (Path.GetExtension(item).ToUpper() != ".TXT")
                {
                    MessageBox.Show("Неверный формат файла");
                    return;
                }
            }


            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "Все файлы (*.*)|*.*|Сжатые LZW файлы (*.lzw)|*.lzw";
            saveFileDialog1.FileName = "LZW Архив.lzw";
            StreamWriter compressedFile;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                compressedFile = new StreamWriter(File.Create(saveFileDialog1.FileName));
                compressedFile.WriteLine(files.Count);
            }
            else
                return;

            FileInfo fileInfo = new FileInfo(saveFileDialog1.FileName);
            Compress_Form compress_Form = new Compress_Form(ref files, compressedFile, sender, ref fileInfo, ref sizes_label);
            LZW.SetForm(ref compress_Form);
            compress_Form.Show();

            listView1.Clear();

        }

        private void decompress_button_Click(object sender, EventArgs e)
        {
            string archiveFilePath;

            sizes_label.Text = "";

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Сжатые LZW файлы (*.lzw)|*.lzw";
            openFileDialog1.FileName = "";
            StreamReader fileReader;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileReader = new StreamReader(File.Open(openFileDialog1.FileName, FileMode.Open));
                archiveFilePath = openFileDialog1.FileName;
            }
            else
                return;

            int FileCount = Convert.ToInt32(fileReader.ReadLine());

            Directory.CreateDirectory(archiveFilePath.Remove(archiveFilePath.Length - 4));

            for (int i = 0; i < FileCount; i++)
            {

                var fileName = fileReader.ReadLine();
                string decompressedFilePath = archiveFilePath;

                decompressedFilePath = decompressedFilePath.Remove(decompressedFilePath.Length - 4) + $"\\{fileName}";

                StreamWriter decompressedFile = new StreamWriter(File.Create(decompressedFilePath));
                LZW.Decompress(fileReader, decompressedFile);

                decompressedFile.Close();
                LZW.ResetDictionary();

            }
            MessageBox.Show($"Файл{(FileCount > 1 ? "(-ы)" : "")} разархивирован!");
            fileReader.Close();
            LZW.ResetDictionary();
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var item in fileList)
            {
                if (files.Contains(item))
                    continue;

                if (Path.GetExtension(item).ToUpper() != ".TXT")
                {
                    MessageBox.Show("Неверный формат файла");
                    continue;
                }

                listView1.Items.Add(item);
                files.Add(item);
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void toolStripButton_addFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in openFileDialog1.FileNames)
                {
                    listView1.Items.Add(item);
                    files.Add(item);
                }
            }
        }

        private void toolStripButton_deleteFile_Click(object sender, EventArgs e)
        {
            List<string> temp_list = new List<string>();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (!listView1.Items[i].Checked)
                {
                    temp_list.Add(listView1.Items[i].Text);
                }
            }

            files.Clear();
            listView1.Items.Clear();
            foreach (var item in temp_list)
            {
                listView1.Items.Add(item);
                files.Add(item);
            }
        }

        private void toolStripButton_DeleteAll_Click(object sender, EventArgs e)
        {
            files.Clear();
            listView1.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sizes_label.Text = "";
        }
    }
}
