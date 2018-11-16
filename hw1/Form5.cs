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
    public partial class Form5 : Form
    {
        Bitmap openImg;

        public Form5()
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
                label1.Text = "Before";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap threshold_img = new Bitmap(openImg);
            int threshold = trackBar1.Value;

            for (int x = 0; x < openImg.Width; x++)
            {
                for (int y = 0; y < openImg.Height; y++)
                {
                    Color RGB = openImg.GetPixel(x, y);
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
            pictureBox2.Image = threshold_img;
        }
        private void trackbar_valueChanged(object source, EventArgs e)
        {
            Bitmap threshold_img = new Bitmap(openImg);
            int threshold = trackBar1.Value;

            for (int x = 0; x < openImg.Width; x++)
            {
                for (int y = 0; y < openImg.Height; y++)
                {
                    Color RGB = openImg.GetPixel(x, y);
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
            pictureBox2.Image = threshold_img;
        }
    }
}
