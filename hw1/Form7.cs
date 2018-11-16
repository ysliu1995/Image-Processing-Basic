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
    public partial class Form7 : Form
    {
        Color[] color_change = {Color.BlueViolet, Color.Brown, Color.BurlyWood, Color.CadetBlue, Color.Chartreuse, Color.Chocolate, Color.Coral, Color.CornflowerBlue, Color.Cornsilk, Color.Crimson 
                               ,Color.Cyan, Color.DarkBlue, Color.DarkCyan, Color.DarkGoldenrod, Color.DarkGray, Color.DarkGreen, Color.DarkKhaki, Color.DarkMagenta, Color.DarkOliveGreen, Color.DarkOrange
                               ,Color.DarkOrchid, Color.DarkRed, Color.DarkSalmon, Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkSlateGray, Color.DarkTurquoise, Color.DarkViolet, Color.DeepPink, Color.DeepSkyBlue
                               ,Color.DimGray, Color.DodgerBlue, Color.Firebrick, Color.FloralWhite, Color.ForestGreen, Color.Fuchsia, Color.Gainsboro, Color.GhostWhite, Color.Gold, Color.Goldenrod};

        Bitmap openImg;
        Bitmap connect_img;

        int width = 0;
        int height = 0;

        public Form7()
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
        }
        private void check(int x, int y, int s)
        {
            if (x >= 0 && y >= 0 && x <= width && y <= height)
            {
                Color RGB = connect_img.GetPixel(x, y);
                int avg = (RGB.R + RGB.G + RGB.B) / 3;
                if (avg == 0)
                {
                    //connect_img.SetPixel(x, y, Color.Red);
                    connect_img.SetPixel(x, y, color_change[s % color_change.Length]);
                    check(x - 1, y - 1, s);
                    check(x, y - 1, s);
                    check(x + 1, y - 1, s);
                    check(x - 1, y, s);
                    check(x + 1, y, s);
                    check(x - 1, y + 1, s);
                    check(x, y + 1, s);
                    check(x + 1, y + 1, s);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            width = openImg.Width - 1;
            height = openImg.Height - 1;

            connect_img = new Bitmap(openImg);

            int s = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = connect_img.GetPixel(x, y);
                    int avg = (RGB.R + RGB.G + RGB.B) / 3;

                    if (avg == 0)
                    {
                        //connect_img.SetPixel(x, y, Color.Red);
                        connect_img.SetPixel(x, y, color_change[s % color_change.Length]);
                        check(x - 1, y - 1, s);
                        check(x, y - 1, s);
                        check(x + 1, y - 1, s);
                        check(x - 1, y, s);
                        check(x + 1, y, s);
                        check(x - 1, y + 1, s);
                        check(x, y + 1, s);
                        check(x + 1, y + 1, s);
                        s++;
                    }
                }
            }
            label1.Text = "Num of Connected region : " + s.ToString();
            pictureBox2.Image = connect_img;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
