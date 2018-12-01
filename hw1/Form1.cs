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
    public partial class Form1 : Form
    {
        Bitmap Before_img;
        Bitmap After_img;
        Bitmap openImg;
        Bitmap connect_img;
        Color[] color_change = {Color.BlueViolet, Color.Brown, Color.BurlyWood, Color.CadetBlue, Color.Chartreuse, Color.Chocolate, Color.Coral, Color.CornflowerBlue, Color.Cornsilk, Color.Crimson 
                               ,Color.Cyan, Color.DarkBlue, Color.DarkCyan, Color.DarkGoldenrod, Color.DarkGray, Color.DarkGreen, Color.DarkKhaki, Color.DarkMagenta, Color.DarkOliveGreen, Color.DarkOrange
                               ,Color.DarkOrchid, Color.DarkRed, Color.DarkSalmon, Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkSlateGray, Color.DarkTurquoise, Color.DarkViolet, Color.DeepPink, Color.DeepSkyBlue
                               ,Color.DimGray, Color.DodgerBlue, Color.Firebrick, Color.FloralWhite, Color.ForestGreen, Color.Fuchsia, Color.Gainsboro, Color.GhostWhite, Color.Gold, Color.Goldenrod};

        Stack<Bitmap> ImgStack;
        int flag;
        int width = 0;
        int height = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void check(int x, int y, int s)
        {
            if (x >= 0 && y >= 0 && x <= width && y <= height)
            {
                Color RGB = connect_img.GetPixel(x, y);
                int avg = (RGB.R + RGB.G + RGB.B) / 3;
                if (avg == 0)
                {
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            // 選擇我們需要開檔的類型
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { // 如果成功開檔
                openImg = new Bitmap(openFileDialog1.FileName);
                // 宣告存取影像的 bitmap
                pictureBox1.Image = openImg;
                pictureBox2.Image = null;
                // 讀取的影像展示到 pictureBox
                Before_img = new Bitmap(openImg);

                ImgStack = new Stack<Bitmap>();
                ImgStack.Push(Before_img);

                chart1.Visible = false;
                chart2.Visible = false;

                flag = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openImg = ImgStack.Peek();
            pictureBox1.Image = openImg;
            Bitmap image_r = new Bitmap(openImg);

            for (int y = 0; y < openImg.Height; y++)
            {
                for (int x = 0; x < openImg.Width; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = openImg.GetPixel(x, y);
                    // RGB 是 VS 內建的 class 可以直接讀取影像的色彩資訊 R = Red, G = Green, B =Blue
                    int R = Convert.ToInt32(RGB.R);

                    image_r.SetPixel(x, y, Color.FromArgb(R, R, R));
                }
            }

            pictureBox2.Image = image_r;
            label3.Text = "";
            After_img = new Bitmap(image_r);
            ImgStack.Push(After_img);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openImg = ImgStack.Peek();
            Bitmap image_g = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            for (int y = 0; y < openImg.Height; y++)
            {
                for (int x = 0; x < openImg.Width; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = openImg.GetPixel(x, y);
                    // RGB 是 VS 內建的 class 可以直接讀取影像的色彩資訊 R = Red, G = Green, B =Blue
                    int G = Convert.ToInt32(RGB.G);

                    image_g.SetPixel(x, y, Color.FromArgb(G, G, G));
                }
            }

            pictureBox2.Image = image_g;
            label3.Text = "";
            After_img = new Bitmap(image_g);
            ImgStack.Push(After_img);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openImg = ImgStack.Peek();
            Bitmap image_b = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            for (int y = 0; y < openImg.Height; y++)
            {
                for (int x = 0; x < openImg.Width; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = openImg.GetPixel(x, y);
                    // RGB 是 VS 內建的 class 可以直接讀取影像的色彩資訊 R = Red, G = Green, B =Blue
                    int B = Convert.ToInt32(RGB.B);


                    image_b.SetPixel(x, y, Color.FromArgb(B, B, B));
                }
            }

            pictureBox2.Image = image_b;
            label3.Text = "";
            After_img = new Bitmap(image_b);
            ImgStack.Push(After_img);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openImg = ImgStack.Peek();
            Bitmap image_gray = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            for (int y = 0; y < openImg.Height; y++)
            {
                for (int x = 0; x < openImg.Width; x++)
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

            pictureBox2.Image = image_gray;
            label3.Text = "";
            After_img = new Bitmap(image_gray);
            ImgStack.Push(After_img);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openImg = ImgStack.Peek();
            Bitmap mean_img = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            for (int y = 1; y < mean_img.Height - 1; y++)
            {
                for (int x = 1; x < mean_img.Width - 1; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = mean_img.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    int[] arr = new int[9];

                    //做filter的運算
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
                    //將平均值找出
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
            label3.Text = "";
            After_img = new Bitmap(mean_img);
            ImgStack.Push(After_img);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openImg = ImgStack.Peek();
            Bitmap median_img = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            for (int y = 1; y < median_img.Height - 1; y++)
            {
                for (int x = 1; x < median_img.Width - 1; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = median_img.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    int[] arr = new int[9];
                    //做filter的運算
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
                    //將陣列排序後找出中位數
                    Array.Sort(arr);
                    int median = arr[4];
                    median_img.SetPixel(x, y, Color.FromArgb(median, median, median));
                }
            }
            pictureBox2.Image = median_img;
            label3.Text = "";
            After_img = new Bitmap(median_img);
            ImgStack.Push(After_img);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openImg = ImgStack.Peek();
            Bitmap equal_img = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            //初始化
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
            //將圖片每個像素值的多寡記錄起來
            for (int y = 0; y < openImg.Height; y++)
            {
                for (int x = 0; x < openImg.Width; x++)
                {
                    Color RGB = openImg.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    y_v[v] += 1;
                }
            }

            chart1.Series["Series1"].Points.DataBindXY(x_v, y_v);
            chart1.Series["Series1"].IsVisibleInLegend = false;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.Visible = true;
            //找出CDF
            a_v[0] = y_v[0];
            for (int i = 1; i < 256; i++)
            {
                a_v[i] = y_v[i] + a_v[i - 1];
            }
            //運算均衡化之後的值
            for (int i = 0; i < 256; i++)
            {
                b_v[i] = (int)Math.Round((double)(a_v[i] - a_v[0]) / (double)((openImg.Width * openImg.Height) - a_v[0]) * 255);
            }

            for (int y = 0; y < openImg.Height; y++)
            {
                for (int x = 0; x < openImg.Width; x++)
                {
                    Color RGB = openImg.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;

                    equal_img.SetPixel(x, y, Color.FromArgb(b_v[v], b_v[v], b_v[v]));
                }
            }

            pictureBox2.Image = equal_img;
            After_img = new Bitmap(equal_img);
            ImgStack.Push(After_img);

            int[] after_v = new int[256];
            //將圖片每個像素值的多寡記錄起來
            for (int y = 0; y < equal_img.Height; y++)
            {
                for (int x = 0; x < equal_img.Width; x++)
                {
                    Color RGB = equal_img.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    after_v[v] += 1;
                }
            }

            chart2.Series["Series1"].Points.DataBindXY(x_v, after_v);
            chart2.Series["Series1"].IsVisibleInLegend = false;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 255;
            chart2.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            flag++;
            if (ImgStack.Count != 1)
            {
                while (flag != 0)
                {
                    ImgStack.Pop();
                    flag--;
                }
            }

            openImg = ImgStack.Peek();
            Bitmap vertical_img = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            int[] Gx = new int[] { -1, -2, -1, 0, 0, 0, 1, 2, 1 };
            int[] Gy = new int[] { -1, 0, 1, -2, 0, 2, -1, 0, 1 };
            for (int y = 1; y < openImg.Height - 1; y++)
            {
                for (int x = 1; x < openImg.Width - 1; x++)
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
                }
            }
            pictureBox2.Image = vertical_img;
            label3.Text = "";
            After_img = new Bitmap(vertical_img);
            ImgStack.Push(After_img);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            flag++;
            if(ImgStack.Count!=1)
            {
                while (flag != 0)
                {
                    ImgStack.Pop();
                    flag--;
                }
            }

            openImg = ImgStack.Peek();
            Bitmap horizontal_img = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            int[] Gx = new int[] { -1, -2, -1, 0, 0, 0, 1, 2, 1 };
            int[] Gy = new int[] { -1, 0, 1, -2, 0, 2, -1, 0, 1 };

            for (int y = 1; y < openImg.Height - 1; y++)
            {
                for (int x = 1; x < openImg.Width - 1; x++)
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



                    horizontal_img.SetPixel(x, y, Color.FromArgb(h_sum, h_sum, h_sum));
                }
            }
            pictureBox2.Image = horizontal_img;
            label3.Text = "";
            After_img = new Bitmap(horizontal_img);
            ImgStack.Push(After_img);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            flag++;
            if (ImgStack.Count != 1)
            {
                while (flag != 0)
                {
                    ImgStack.Pop();
                    flag--;
                }
            }

            openImg = ImgStack.Peek();
            Bitmap combined_img = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            int[] Gx = new int[] { -1, -2, -1, 0, 0, 0, 1, 2, 1 };
            int[] Gy = new int[] { -1, 0, 1, -2, 0, 2, -1, 0, 1 };

            for (int y = 1; y < openImg.Height - 1; y++)
            {
                for (int x = 1; x < openImg.Width - 1; x++)
                {
                    Color RGB = openImg.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;

                    int v_sum = 0;
                    int h_sum = 0;
                    int c_sum = 0;
                    //進行edge detection
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
                    //將運算完後的像素值訂在[0,255]的區間內
                    c_sum = (int)Math.Sqrt(Math.Pow(v_sum, 2) + Math.Pow(h_sum, 2));
                    c_sum = Math.Max(0, c_sum);
                    c_sum = Math.Min(255, c_sum);
                    v_sum = Math.Max(0, v_sum);
                    v_sum = Math.Min(255, v_sum);
                    h_sum = Math.Max(0, h_sum);
                    h_sum = Math.Min(255, h_sum);



                    combined_img.SetPixel(x, y, Color.FromArgb(c_sum, c_sum, c_sum));
                }
            }
            pictureBox2.Image = combined_img;
            label3.Text = "";
            After_img = new Bitmap(combined_img);
            ImgStack.Push(After_img);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Bitmap threshold_img = ImgStack.Pop();
            pictureBox1.Image = threshold_img;

            flag++;
            if (ImgStack.Count != 1)
            {
                while (flag != 0)
                {
                    if (ImgStack.Count > 1)
                    {
                        ImgStack.Pop();
                    }
                    flag--;
                }
            }
            openImg = ImgStack.Peek();
            Bitmap overlap_img = new Bitmap(openImg);

            for (int y = 1; y < openImg.Height - 1; y++)
            {
                for (int x = 1; x < openImg.Width - 1; x++)
                {
                    Color RGB = threshold_img.GetPixel(x - 1, y - 1);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    //將二值化之後的像素值為白色的設為綠色
                    if (v == 255)
                    {
                        overlap_img.SetPixel(x, y, Color.Green);
                    }
                }
            }
            pictureBox2.Image = overlap_img;
            label3.Text = "";
            After_img = new Bitmap(overlap_img);
            ImgStack.Push(After_img);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            width = openImg.Width - 1;
            height = openImg.Height - 1;

            openImg = ImgStack.Peek();
            connect_img = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            int s = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = connect_img.GetPixel(x, y);
                    int avg = (RGB.R + RGB.G + RGB.B) / 3;

                    //若像素值為零則遞迴檢查鄰近八邊是否也符合
                    if (avg == 0)
                    {
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
            label3.Text = "Num of Connected region : " + s.ToString();
            pictureBox2.Image = connect_img;
            After_img = new Bitmap(connect_img);
            ImgStack.Push(After_img);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ImgStack.Count > 1)
            {
                ImgStack.Pop();
                After_img = null;
                Before_img = ImgStack.Peek();
                pictureBox1.Image = Before_img;
                pictureBox2.Image = After_img;
                chart1.Visible = false;
                chart2.Visible = false;
                numericUpDown1.Value = 0;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                After_img.Save(sfd.FileName);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            openImg = ImgStack.Peek();
            Bitmap threshold_img = new Bitmap(openImg);
            pictureBox1.Image = openImg;

            //將User欲使用的threshold值紀錄
            int threshold = (int)numericUpDown1.Value;

            for (int y = 0; y < openImg.Height; y++)
            {
                for (int x = 0; x < openImg.Width; x++)
                {
                    Color RGB = openImg.GetPixel(x, y);
                    int v = (RGB.R + RGB.G + RGB.B) / 3;
                    //將每個像素值小於threshold的設為黑色，否則為白色
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
            After_img = new Bitmap(threshold_img);
            ImgStack.Push(After_img);
        }
    }
}
