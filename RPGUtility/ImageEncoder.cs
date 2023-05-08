using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
//using static System.Net.Mime.MediaTypeNames;

namespace RPGUtility
{
    internal class ImageEncoder
    {
        public static byte[] BitmapImagetobytearray(BitmapImage image)
        {
            byte[] data;

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
        public static BitmapImage bytearraytoBitmap(byte[] data)
        {
            BitmapImage image;
            //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream(data))
            {
                image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
            //return data;
        }
    }
}
