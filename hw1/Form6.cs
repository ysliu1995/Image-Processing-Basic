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
    public partial class Form6 : Form
    {
        Bitmap openImg;
        Bitmap combined_img;
        Bitmap threshold_img;

        public Form6()
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
            Bitmap vertical_img = new Bitmap(openImg);
            Bitmap horizontal_img = new Bitmap(openImg);
            combined_img = new Bitmap(openImg);

            int[] Gx = new int[] { -1, -2, -1, 0, 0, 0, 1, 2, 1 };
            int[] Gy = new int[] { -1, 0, 1, -2, 0, 2, -1, 0, 1 };

            for (int x = 1; x < openImg.Width - 1; x++)
            {
                for (int y = 1; y < openImg.Height - 1; y++)
                {
                    Color RGB = openImg.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;

                    int v_sum = 0;
                    int h_sum = 0;
                    int c_sum = 0;

                    for (int c = -1; c < 2; c++)
                    {
                        for (int r = -1; r < 2; r++)
                        {
                            Color tmp_RGB = openImg.GetPixel(x + r, y + c);
                            int tmp_v = (tmp_RGB.R + tmp_RGB.G + tmp_RGB.B) / 3;
                            int vertical = 1;
                            int horizontal = 1;

                            vertical = tmp_v * Gx[(r + 1) * 3 + (c + 1)];
                            horizontal = tmp_v * Gy[(r + 1) * 3 + (c + 1)];
                            v_sum += vertical;
                            h_sum += horizontal;
                        }
                    }
                    c_sum = (int)Math.Sqrt(Math.Pow(v_sum, 2) + Math.Pow(h_sum, 2));
                    c_sum = Math.Max(0, c_sum);
                    c_sum = Math.Min(255, c_sum);
                    v_sum = Math.Max(0, v_sum);
                    v_sum = Math.Min(255, v_sum);
                    h_sum = Math.Max(0, h_sum);
                    h_sum = Math.Min(255, h_sum);



                    vertical_img.SetPixel(x, y, Color.FromArgb(v_sum, v_sum, v_sum));
                    horizontal_img.SetPixel(x, y, Color.FromArgb(h_sum, h_sum, h_sum));
                    combined_img.SetPixel(x, y, Color.FromArgb(c_sum, c_sum, c_sum));
                }
            }
            pictureBox2.Image = vertical_img;
            pictureBox3.Image = horizontal_img;
            pictureBox4.Image = combined_img;
            label2.Text = "Vertical";
            label3.Text = "Horizontal";
            label4.Text = "Combined";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            threshold_img = new Bitmap(combined_img);
            int threshold = trackBar1.Value;

            for (int x = 0; x < combined_img.Width; x++)
            {
                for (int y = 0; y < combined_img.Height; y++)
                {
                    Color RGB = combined_img.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;

                    if (v < threshold)
                    {
                        threshold_img.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        threshold_img.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            pictureBox5.Image = threshold_img;
        }
        private void trackbar_valueChanged(object source, EventArgs e)
        {
            threshold_img = new Bitmap(combined_img);
            int threshold = trackBar1.Value;

            for (int x = 0; x < combined_img.Width; x++)
            {
                for (int y = 0; y < combined_img.Height; y++)
                {
                    Color RGB = combined_img.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;

                    if (v < threshold)
                    {
                        threshold_img.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        threshold_img.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            pictureBox5.Image = threshold_img;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap overlap_img = new Bitmap(openImg);

            for (int x = 1; x < openImg.Width - 1; x++)
            {
                for (int y = 1; y < openImg.Height - 1; y++)
                {
                    Color RGB = threshold_img.GetPixel(x - 1, y - 1);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    if (v == 255)
                    {
                        overlap_img.SetPixel(x, y, Color.Green);
                    }
                }
            }
            pictureBox6.Image = overlap_img;
            label6.Text = "overlap";
        }
    }
}
