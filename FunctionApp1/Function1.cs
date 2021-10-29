using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("RotateImage")]
        public static void Run([BlobTrigger("original/{name}")] Stream image,
        [Blob("original/{name}", FileAccess.Write)] Stream input,
        [Blob("rotated/{name}", FileAccess.Write)] Stream rotated, string name, ILogger log)
        {
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(input);

            // inch vor xeloq ban
            // rotate 90 degree right
            myImage.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);

    //        myImage.Save(rotated, ImageFormat.Jpeg);

            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {image.Length} Bytes");
        }
    }
}
