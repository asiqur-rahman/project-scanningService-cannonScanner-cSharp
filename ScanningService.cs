using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Script.Serialization;

namespace ScannerService
{
    internal class ScanningService : IScanningService
    {
        public ScanningService()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
        }
        public string Scan()
        {
            List<string> img = new List<string>();
            try
            {
                List<CannonScanner> scanners = new List<CannonScanner>();
                var deviceManager = new WIA.DeviceManager();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WIA.WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }
                    scanners.Add(new CannonScanner(deviceManager.DeviceInfos[i]));
                }
                if (scanners.Any())
                {
                    var image = scanners[0].ScanPNG();
                    var imageBytes = (byte[])image.FileData.get_BinaryData();
                    var ms = new MemoryStream(imageBytes);
                    img.Add(ImageToBase64(Image.FromStream(ms)));
                    return (ImageToBase64(Image.FromStream(ms)));
                    //img.Add( "data:image/png;base64," + ImageToBase64(Image.FromStream(ms)));
                }
            }
            catch (Exception e)
            {

            }

            return (new JavaScriptSerializer().Serialize(img));
        }

        public string ImageToBase64(Image image)
        {
            string base64String = null;
            if (image != null)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
            return base64String;
        }
    }
}
