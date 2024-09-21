using System;
using ZXing;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;

namespace QRCoder
{
    public partial class QR : Form
    {
        PictureBox pictureBox1;
        PictureBox pictureBox2;
        public QR()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.White;
            pictureBox1 = new PictureBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Location = new Point(12, 47);
            this.Controls.Add(pictureBox1);
            pictureBox2 = new PictureBox();
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.Location = new Point(12, 259);
            this.Controls.Add(pictureBox2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                var options1 = new QrCodeEncodingOptions
                {
                    Height = 200,
                    Width = 200,
                    Margin = 1,
                    CharacterSet = "UTF-8"
                };
                var writer1 = new BarcodeWriter<Bitmap>
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = options1,
                    Renderer = new BitmapRenderer()
                };
                using (Bitmap bitmap = writer1.Write(textBox1.Text))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        Image image = Image.FromStream(memoryStream);
                        pictureBox1.Image = image;
                    }
                }
                var options2 = new ZXing.Common.EncodingOptions
                {
                    Height = 80,
                    Width = 200
                };
                var writer2 = new BarcodeWriter<Bitmap>
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = options2,
                    Renderer = new BitmapRenderer()
                };
                using (Bitmap bitmap = writer2.Write(textBox1.Text))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        Image image = Image.FromStream(memoryStream);
                        pictureBox2.Image = image;
                    }
                }
            }
        }
    }
}
