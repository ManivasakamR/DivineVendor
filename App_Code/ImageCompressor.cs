using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
/// <summary>
/// Summary description for ImageCompressor
/// </summary>
public class ImageCompressor
{
    public Bitmap OriginalBitmap = null;
    public ImageCompressor(string srcfile,string dstfile)
    {        
        OriginalBitmap = new Bitmap(srcfile);
        int new_wid = 680;
        int new_hgt = 510;

        using (Bitmap bm = new Bitmap(new_wid, new_hgt))
        {
            Point[] points =
            {
                        new Point(0, 0),
                        new Point(new_wid, 0),
                        new Point(0, new_hgt),
                 };
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(OriginalBitmap, points);
            }
            float dpix =72;
            float dpiy =72;
            bm.SetResolution(dpix, dpiy);
            bm.Save(dstfile, ImageFormat.Jpeg);
        }
    }  
}



