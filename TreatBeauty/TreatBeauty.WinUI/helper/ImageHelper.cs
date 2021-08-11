using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatBeauty.WinUI.helper
{
    public class ImageHelper
    {
        public static byte[] ConvertFromImageToByte(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image?.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();

        }
        public static Image ConvertFromByteToImage(byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);
            return  Image.FromStream(ms);
        }
    }
}
