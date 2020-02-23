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
                Title = "Washing Boots",
                Price = "123.45 TL"
            };
            productBanner.SimpleRender();
            productBanner.SavePng("product-banner.png");
            productBanner.SaveJpg("product-banner.jpg");
        }
    }
}
