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
    public partial class Form4 : Form
    {
        Bitmap openImg;

        public Form4()
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
            }

            int[] x_v = new int[256];
            int[] y_v = new int[256];
            for (int i = 0; i < 256; i++)
            {
                x_v[i] = i;
                y_v[i] = 0;
            }
            for (int x = 0; x < openImg.Width; x++)
            {
                for (int y = 0; y < openImg.Height; y++)
                {
                    Color RGB = openImg.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    y_v[v] += 1;
                }
            }
            chart1.Series["Series1"].Points.DataBindXY(x_v, y_v);
            chart1.Series["Series1"].IsVisibleInLegend = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap equal_img = new Bitmap(openImg);

            int[] x_v = new int[256];
            int[] y_v = new int[256];
            int[] a_v = new int[256];
            int[] b_v = new int[256];
            for (int i = 0; i < 256; i++)
            {
                x_v[i] = i;
                y_v[i] = 0;
                b_v[i] = 0;
            }
            for (int x = 0; x < openImg.Width; x++)
            {
                for (int y = 0; y < openImg.Height; y++)
                {
                    Color RGB = openImg.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    y_v[v] += 1;
                }
            }
            a_v[0] = y_v[0];
            for (int i = 1; i < 256; i++)
            {
                a_v[i] = y_v[i] + a_v[i - 1];
            }
            for (int i = 0; i < 256; i++)
            {
                b_v[i] = (int)Math.Round((double)(a_v[i] - a_v[0]) / (double)((openImg.Width * openImg.Height) - a_v[0]) * 255);
            }

            for (int x = 0; x < openImg.Width; x++)
            {
                for (int y = 0; y < openImg.Height; y++)
                {
                    Color RGB = openImg.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;

                    equal_img.SetPixel(x, y, Color.FromArgb(b_v[v], b_v[v], b_v[v]));
                }
            }

            pictureBox2.Image = equal_img;

            int[] after_v = new int[256];

            for (int x = 0; x < equal_img.Width; x++)
            {
                for (int y = 0; y < equal_img.Height; y++)
                {
                    Color RGB = equal_img.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    after_v[v] += 1;
                }
            }


            chart2.Series["Series1"].Points.DataBindXY(x_v, after_v);
            chart2.Series["Series1"].IsVisibleInLegend = false;
        }
    }
}
