using System;
using System.Windows.Media.Imaging;
using System.Windows;
using System.ComponentModel;


namespace CustomExtensions
{
    public static class BitmapSourceExtension
    {
        public static BitmapSource ToBitmapSource(this System.Drawing.Image source)
        {
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(source);
            var bitSrc = bitmap.ToBitmapSource();
            bitmap.Dispose();
            bitmap = null;
            return bitSrc;
        }

        public static BitmapSource ToBitmapSource(this System.Drawing.Bitmap source)
        {
            BitmapSource bitSrc = null;

            var hBitmap = source.GetHbitmap();

            try
            {
                bitSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Win32Exception)
            {
                bitSrc = null;
            }
            finally
            {
                //NativeMethods.DeleteObject(hBitmap);

            }

            return bitSrc;
        }

    }
}

