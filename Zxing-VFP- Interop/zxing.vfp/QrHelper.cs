using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace zxing.vfp
{
    [ProgId("zxing.QrHelper"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class QrHelper
    {
        public string GenerateQr(int width, int height, string text)
        {
            string imagenQr;

            try
            {
                BarcodeWriter bw = new BarcodeWriter();

                EncodingOptions encOptions = new EncodingOptions
                {
                    Width = width,
                    Height = height,
                    Margin = 1,
                    PureBarcode = false,

                };

                encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.Q);
                encOptions.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
                bw.Renderer = new BitmapRenderer();
                bw.Options = encOptions;
                bw.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = bw.Write(text);

                imagenQr = GetTempFilePathWithExtension(".jpg");
                bm.Save(imagenQr, ImageFormat.Jpeg);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return imagenQr;

        }


        private string GetTempFilePathWithExtension(string extension)
        {
            var path = Path.GetTempPath();
            var fileName = Guid.NewGuid() + extension;
            return Path.Combine(path, fileName);
        }
    }
}
