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
                ProductImagePos = new Point(79, 54),
                Title = "Washing Boots",
                TitleRect = new Rectangle(5, 5, 290, 75),
                TitleVerticalAlignment = StringAlignment.Center,
                TitleHorizontalAlignment = StringAlignment.Far,
                Price = "123.45 TL",
                PriceRect = new Rectangle(5, 170, 290, 75),
                PriceHorizontalAlignment = StringAlignment.Near,
                PriceVerticalAlignment = StringAlignment.Center

            };
            productBanner.SimpleRender();
            productBanner.SavePng("product-banner.png");
        }
    }
}
