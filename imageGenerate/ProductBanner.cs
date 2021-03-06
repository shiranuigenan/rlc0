﻿using System;
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
        public Rectangle BackgroundImageRect { get; set; }

        public Bitmap ProductImage { get; set; }
        public Rectangle ProductImageRect { get; set; }

        public string Title { get; set; } = "Title";
        public Rectangle TitleRect { get; set; }
        public StringAlignment TitleVerticalAlignment { get; set; } = StringAlignment.Center;
        public StringAlignment TitleHorizontalAlignment { get; set; } = StringAlignment.Center;
        public Color TitleColor { get; set; } = Color.White;
        public string TitleFont { get; set; } = "Times New Roman";
        public float TitleFontSize { get; set; } = 16.0f;

        public string Price { get; set; } = "Price";
        public Rectangle PriceRect { get; set; }
        public StringAlignment PriceVerticalAlignment { get; set; } = StringAlignment.Center;
        public StringAlignment PriceHorizontalAlignment { get; set; } = StringAlignment.Center;
        public Color PriceColor { get; set; } = Color.White;
        public string PriceFont { get; set; } = "Times New Roman";
        public float PriceFontSize { get; set; } = 16.0f;

        public bool OldPriceEnable { get; set; } = false;
        public string OldPrice { get; set; } = "Price";
        public Rectangle OldPriceRect { get; set; }
        public StringAlignment OldPriceVerticalAlignment { get; set; } = StringAlignment.Center;
        public StringAlignment OldPriceHorizontalAlignment { get; set; } = StringAlignment.Center;
        public Color OldPriceColor { get; set; } = Color.White;
        public string OldPriceFont { get; set; } = "Times New Roman";
        public float OldPriceFontSize { get; set; } = 16.0f;

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
                    g.DrawImage(BackgroundImage, BackgroundImageRect);

                if (ProductImage != null)
                    g.DrawImage(ProductImage, ProductImageRect);

                using (var font = new Font(TitleFont, TitleFontSize))
                {
                    using (var stringFormat = new StringFormat())
                    {
                        stringFormat.LineAlignment = TitleVerticalAlignment;
                        stringFormat.Alignment = TitleHorizontalAlignment;

                        // g.DrawRectangle(new Pen(Color.Red, 1), TitleRect);

                        using (var brush = new SolidBrush(TitleColor))
                            g.DrawString(Title, font, brush, TitleRect, stringFormat);
                    }
                }

                using (var font = new Font(PriceFont, PriceFontSize))
                {
                    using (var stringFormat = new StringFormat())
                    {
                        stringFormat.LineAlignment = PriceVerticalAlignment;
                        stringFormat.Alignment = PriceHorizontalAlignment;

                        // g.DrawRectangle(new Pen(Color.Red, 1), PriceRect);
                        using (var brush = new SolidBrush(PriceColor))
                            g.DrawString(Price, font, brush, PriceRect, stringFormat);
                    }
                }

                if (OldPriceEnable)
                {
                    using (var font = new Font(OldPriceFont, OldPriceFontSize, FontStyle.Strikeout))
                    {

                        using (var stringFormat = new StringFormat())
                        {
                            stringFormat.LineAlignment = OldPriceVerticalAlignment;
                            stringFormat.Alignment = OldPriceHorizontalAlignment;

                            // g.DrawRectangle(new Pen(Color.Red, 1), OldPriceRect);
                            using (var brush = new SolidBrush(OldPriceColor))
                                g.DrawString(Price, font, brush, OldPriceRect, stringFormat);
                        }
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
