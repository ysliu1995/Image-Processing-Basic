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
    public partial class Form2 : Form
    {
        Bitmap openImg;

        public Form2()
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

                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image_r = new Bitmap(openImg);
            Bitmap image_g = new Bitmap(openImg);
            Bitmap image_b = new Bitmap(openImg);

            for (int x = 0; x < openImg.Width; x++)
            {
                for (int y = 0; y < openImg.Height; y++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = openImg.GetPixel(x, y);
                    // RGB 是 VS 內建的 class 可以直接讀取影像的色彩資訊 R = Red, G = Green, B =Blue
                    int R = Convert.ToInt32(RGB.R);
                    int G = Convert.ToInt32(RGB.G);
                    int B = Convert.ToInt32(RGB.B);


                    image_r.SetPixel(x, y, Color.FromArgb(R, R, R));
                    image_g.SetPixel(x, y, Color.FromArgb(G, G, G));
                    image_b.SetPixel(x, y, Color.FromArgb(B, B, B));
                }
            }

            pictureBox2.Image = image_r;
            pictureBox3.Image = image_g;
            pictureBox4.Image = image_b;

            label2.Text = "R Channel";
            label3.Text = "G Channel";
            label4.Text = "B Channel";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image_gray = new Bitmap(openImg);

            for (int x = 0; x < openImg.Width; x++)
            {
                for (int y = 0; y < openImg.Height; y++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = openImg.GetPixel(x, y);
                    // RGB 是 VS 內建的 class 可以直接讀取影像的色彩資訊 R = Red, G = Green, B =Blue
                    int R = Convert.ToInt32(RGB.R);
                    int G = Convert.ToInt32(RGB.G);
                    int B = Convert.ToInt32(RGB.B);

                    int avg = (R + G + B) / 3;

                    image_gray.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }

            pictureBox5.Image = image_gray;

            label5.Text = "Grayscale";
        }
    }
}
