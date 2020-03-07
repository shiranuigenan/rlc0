using System;
using imageGenerate;
using System.Drawing;
//using System.Drawing.Imaging;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var backgroundImage = new Bitmap("back.jpg");
            var washingBoots = new Bitmap("washing-boots.jpg");

            var productBanner = new ProductBanner
            {
                BackgroundColor = Color.FromArgb(51, 63, 85),
                //BackgroundImage = backgroundImage,
                ProductImage = washingBoots,
                ProductImageRect = new Rectangle(79, 54, 142, 142),
                Title = "Washing Boots",
                TitleRect = new Rectangle(5, 5, 290, 75),
                TitleVerticalAlignment = StringAlignment.Center,
                TitleHorizontalAlignment = StringAlignment.Far,
                TitleColor = Color.Red,
                TitleFont = "Arial",
                TitleFontSize = 24.0f,
                Price = "123.45 TL",
                PriceRect = new Rectangle(5, 170, 290, 75),
                PriceHorizontalAlignment = StringAlignment.Near,
                PriceVerticalAlignment = StringAlignment.Center,
                PriceColor = Color.Blue,
                PriceFont = "Courier New",
                PriceFontSize = 12.0f,
            };
            productBanner.SimpleRender();
            productBanner.SavePng("product-banner.png");
        }
    }
}
