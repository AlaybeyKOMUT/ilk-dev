using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace gri_yöntemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            {
                pictureBox1.ImageLocation = sfd.FileName;//open file dialog ile seçilen resmi renklı isimli pictureboxa yükle.
            }
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ortalamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap ort = Yap(image);

            pictureBox2.Image = ort;



        }
        private Bitmap Yap(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;
                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);
                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }

        private void bT709ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap ort = Yap1(image);

            pictureBox3.Image = ort;



        }
        private Bitmap Yap1(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = Convert.ToInt16(bmp.GetPixel(j, i).R * 0.2125 + bmp.GetPixel(j, i).G * 0.7154 + bmp.GetPixel(j, i).B * 0.072);
                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);
                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }

        private void lumaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap ort = Yap2(image);

            pictureBox4.Image = ort;



        }
        private Bitmap Yap2(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = Convert.ToInt16(bmp.GetPixel(j, i).R * 0.3 + bmp.GetPixel(j, i).G * 0.59 + bmp.GetPixel(j, i).B * 0.11);
                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);
                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Kayıt = new SaveFileDialog();
            Kayıt.Filter = "Jpeg Resmi|*.jpg|Bitmap Resmi|*.bmp|Gif Resmi|*.gif";
            Kayıt.Title = "Resmi Kaydet";
            Kayıt.ShowDialog();
            if (Kayıt.FileName != "")
            {
                FileStream DosyaAkisi = (FileStream)Kayıt.OpenFile();
                // FileStream nesnesi ile kayıtı gerçekleştirecek. FileStream DosyaAkisi = (FileStream)saveFileDialog1.OpenFile();
                switch (Kayıt.FilterIndex)
                {
                    case 1: pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case 2: pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    case 3: pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Gif); break;
                }
                DosyaAkisi.Close();
            }
        }

        

        

        private void kanalÇıkarımıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap ort = Yap2(image);

            pictureBox6.Image = ort;
        }

        private void açıklıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap ort = Yap2(image);

            pictureBox5.Image = ort;
        }
    }
    
}

    


    