using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace imageGenerate
{
    public class ProductBanner
    {
        public int Width { get; set; } = 300;
        public int Height { get; set; } = 250;
        public Color BackgroundColor { get; set; } = Color.FromArgb(255, 170, 85);
        public Bitmap BackgroundImage { get; set; }
        public Bitmap ProductImage { get; set; }
        public string Title { get; set; } = "Title";
        public string Price { get; set; } = "Price";

        public Bitmap LastRendered { get; set; }

        public void SimpleRender()
        {
            Bitmap result = null;
            try
            {
                result = new Bitmap(Width, Height);
                var g = Graphics.FromImage(result);
                g.Clear(BackgroundColor);

                if (BackgroundImage != null)
                {
                    var x = (Width - BackgroundImage.Width) / 2;
                    var y = (Height - BackgroundImage.Height) / 2;

                    g.DrawImage(BackgroundImage, new Point(x, y));
                }

                if (ProductImage != null)
                {
                    var x = (Width - ProductImage.Width) >> 1;
                    var y = (Height - ProductImage.Height) >> 1;

                    g.DrawImage(ProductImage, new Point(x, y));
                }

                using (var font = new Font("Times New Roman", 16))
                {
                    using (var stringFormat = new StringFormat())
                    {
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Alignment = StringAlignment.Center;

                        var titleRect = new Rectangle(1, 1, Width - 1, Height / 3 - 1);
                        //g.DrawRectangle(new Pen(Color.Red, 1), titleRect);
                        g.DrawString(Title, font, Brushes.White, titleRect, stringFormat);

                        var priceRect = new Rectangle(1, 2 * Height / 3, Width - 1, Height / 3 - 1);
                        //g.DrawRectangle(new Pen(Color.Red, 1), priceRect);
                        g.DrawString(Price, font, Brushes.White, priceRect, stringFormat);
                    }
                }
            }
            catch (System.Exception) { }

            if (LastRendered != null)
                LastRendered.Dispose();

            LastRendered = result;
        }

        void Save(string fileFullPath, ImageFormat imageFormat)
        {
            if (LastRendered == null)
                return;

            try
            {
                LastRendered.Save(fileFullPath, imageFormat);
            }
            catch (System.Exception) { }
        }
        public void SavePng(string fileFullPath) => Save(fileFullPath, ImageFormat.Png);
        public void SaveJpg(string fileFullPath) => Save(fileFullPath, ImageFormat.Jpeg);
    }
}
