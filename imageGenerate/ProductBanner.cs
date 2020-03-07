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
        public Point BackgroundImagePos { get; set; }
        public Bitmap ProductImage { get; set; }
        public Point ProductImagePos { get; set; }
        public string Title { get; set; } = "Title";
        public Rectangle TitleRect { get; set; }
        public StringAlignment TitleVerticalAlignment { get; set; } = StringAlignment.Center;
        public StringAlignment TitleHorizontalAlignment { get; set; } = StringAlignment.Center;
        public string Price { get; set; } = "Price";
        public Rectangle PriceRect { get; set; }
        public StringAlignment PriceVerticalAlignment { get; set; } = StringAlignment.Center;
        public StringAlignment PriceHorizontalAlignment { get; set; } = StringAlignment.Center;
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
                    g.DrawImage(BackgroundImage, BackgroundImagePos);

                if (ProductImage != null)
                    g.DrawImage(ProductImage, ProductImagePos);

                using (var font = new Font("Times New Roman", 16))
                {
                    using (var stringFormat = new StringFormat())
                    {
                        stringFormat.LineAlignment = TitleVerticalAlignment;
                        stringFormat.Alignment = TitleHorizontalAlignment;

                        // g.DrawRectangle(new Pen(Color.Red, 1), TitleRect);
                        g.DrawString(Title, font, Brushes.White, TitleRect, stringFormat);
                    }
                    using (var stringFormat = new StringFormat())
                    {
                        stringFormat.LineAlignment = PriceVerticalAlignment;
                        stringFormat.Alignment = PriceHorizontalAlignment;

                        // g.DrawRectangle(new Pen(Color.Red, 1), PriceRect);
                        g.DrawString(Price, font, Brushes.White, PriceRect, stringFormat);
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
