using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw1
{
    public partial class Form3 : Form
    {
        Bitmap openImg;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            // 選擇我們需要開檔的類型
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { // 如果成功開檔
                openImg = new Bitmap(openFileDialog1.FileName);
                // 宣告存取影像的 bitmap
                pictureBox1.Image = openImg;
                // 讀取的影像展示到 pictureBox
                label1.Text = "Source";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap mean_img = new Bitmap(openImg);

            for (int x = 1; x < mean_img.Width - 1; x++)
            {
                for (int y = 1; y < mean_img.Height - 1; y++)
                {
                    Color RGB = mean_img.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    int[] arr = new int[9];

                    int flag = 0;
                    for (int c = -1; c < 2; c++)
                    {
                        for (int r = -1; r < 2; r++)
                        {
                            Color tmp_RGB = mean_img.GetPixel(x + r, y + c);
                            int tmp_v = (tmp_RGB.R + tmp_RGB.G + tmp_RGB.B) / 3;
                            arr[flag] = tmp_v;
                            flag++;
                        }
                    }
                    int avg = 0;
                    int tmp = 0;
                    for (int k = 0; k < 9; k++)
                    {
                        tmp += arr[k];
                    }
                    avg = tmp / 9;
                    mean_img.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            pictureBox2.Image = mean_img;
            label2.Text = "Mean";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap median_img = new Bitmap(openImg);

            for (int x = 1; x < median_img.Width - 1; x++)
            {
                for (int y = 1; y < median_img.Height - 1; y++)
                {
                    Color RGB = median_img.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    int[] arr = new int[9];

                    int flag = 0;
                    for (int c = -1; c < 2; c++)
                    {
                        for (int r = -1; r < 2; r++)
                        {
                            Color tmp_RGB = median_img.GetPixel(x + r, y + c);
                            int tmp_v = (tmp_RGB.R + tmp_RGB.G + tmp_RGB.B) / 3;
                            arr[flag] = tmp_v;
                            flag++;
                        }
                    }
                    Array.Sort(arr);
                    int median = arr[4];
                    median_img.SetPixel(x, y, Color.FromArgb(median, median, median));
                }
            }
            pictureBox3.Image = median_img;
            label3.Text = "Median";
        }
    }
}
