using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LZW_zip
{
    internal static class LZW
    {
        private static string alphabet = "";

        private static Dictionary<string, int> dictioanry;
        private static List<string> list_dictioanry;
        public static int progress { get; private set; }
        public static ProgressBar progressBar { get; private set; }
        public static Compress_Form compress_Form { get; private set; }
        public static int last_initial_size { get; private set; }
        public static int last_compressed_size { get; private set; }

        static LZW()
        {
            for (int i = System.Char.MinValue; i < System.Char.MaxValue; i++)
            {
                alphabet += Convert.ToChar(i).ToString();
            }

            dictioanry = new Dictionary<string, int>();
            list_dictioanry = new List<string>();
            progressBar = null;

            progress = 0;
            last_initial_size = 0;
            last_compressed_size = 0;

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (dictioanry.ContainsKey(alphabet[i].ToString()))
                    continue;

                dictioanry.Add(alphabet[i].ToString(), dictioanry.Count);
            }
        }

        public static void SetProgressBar(ref ProgressBar pBar)
        {
            progressBar = pBar;
        }

        public static void SetForm(ref Compress_Form cForm)
        {
            compress_Form = cForm;
        }

        public static void ResetDictionary()
        {
            dictioanry.Clear();
            list_dictioanry.Clear();

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (dictioanry.ContainsKey(alphabet[i].ToString()))
                    continue;

                dictioanry.Add(alphabet[i].ToString(), dictioanry.Count);
            };
        }

        public static void ResetSizes()
        {
            last_initial_size = 0;
            last_compressed_size = 0;
        }

        public static void Compress(FileStream file, StreamWriter compressedFileWriter)
        {
            StreamReader reader = new StreamReader(file);

            string c = "";
            string s = "";

            progressBar.Maximum = 58;

            int fileLength = (int)file.Length;

            last_initial_size += fileLength;

            for (int i = 0; i < fileLength; i++)
            {
                try
                {
                    var g = reader.Read();
                    if (g == -1)
                        break;
                    c = Convert.ToChar(g).ToString();

                    if (dictioanry.ContainsKey(s + c))
                        s += c;
                    else
                    {
                        var sc = dictioanry[s];
                        if (s != "" && sc != -1)
                            compressedFileWriter.WriteLine(sc);
                        dictioanry.Add(s + c, dictioanry.Count);
                        s = c;
                    }

                    progressBar.Value = i * 100 / fileLength;
                    compress_Form.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ' ' + c);
                }
            }
            compressedFileWriter.WriteLine(dictioanry[s]);

        }

        public static void Decompress(StreamReader reader, StreamWriter decompressedFileWriter)
        {
            foreach (string s in dictioanry.Keys)
                list_dictioanry.Add(s);

            progress = 0;

            int c = 0;
            int p = 0;
            string prev = "";

            p = Convert.ToInt32(reader.ReadLine());
            decompressedFileWriter.Write(list_dictioanry[p]);
            prev = list_dictioanry[p];

            for (int i = 0; ; i++)
            {
                var r = reader.ReadLine();

                var str = "";

                if (r == null || r == 'e'.ToString())
                    break;

                c = Convert.ToInt32(r);

                if (c >= list_dictioanry.Count)
                    str = list_dictioanry[p] + prev;
                else
                    str = list_dictioanry[c];

                decompressedFileWriter.Write(str);

                prev = str[0].ToString();

                list_dictioanry.Add(list_dictioanry[p] + prev);

                p = c;

                progress = i;
            }
        }
    }
}
