using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.IO;
using System.Drawing;
using Detector.scr.Image_Processing;

namespace Peals.Hubs
{
    public class ReconocimientoHub : Hub
    {
        private static Segmentacion segmentacion;

        public ReconocimientoHub()
        {
            if (segmentacion == null)
                segmentacion = new Segmentacion(640, 480);
        }

        public void Send(String datos, bool esCara)
        {
            String base64String = datos.Replace("data:image/jpeg;base64,", "");
            byte[] imageBytes = Convert.FromBase64String(base64String);

            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            Image image = Image.FromStream(ms, true);
            Bitmap bmp = new Bitmap(image);

            bmp = segmentacion.iniciarWeb(bmp, esCara);
            String respuesta = segmentacion.getResultadoClasificacion();
            
            ImageConverter converter = new ImageConverter();
            imageBytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

            String respuestaBmp;
            respuestaBmp = Convert.ToBase64String(imageBytes);
            respuestaBmp = "data:image/jpeg;base64," + respuestaBmp;

            Clients.Caller.respuesta(respuestaBmp, respuesta);
        }

        public void resetear()
        {
            segmentacion.resetearMog();
        }

        //public void Send(String datos)
        //{
        //    String base64String = datos.Replace("data:image/jpeg;base64,", "");
        //    byte[] imageBytes = Convert.FromBase64String(base64String);

        //    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

        //    Image image = Image.FromStream(ms, true);
        //    Bitmap bmp = new Bitmap(image);

        //    PreProcessing pp = new PreProcessing();

        //    bmp = pp.prueba(bmp);
            
        //    ImageConverter converter = new ImageConverter();
        //    imageBytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

        //    String respuesta;
        //    respuesta = Convert.ToBase64String(imageBytes);
        //    respuesta = "data:image/jpeg;base64," + respuesta;
        //    Clients.Caller.respuesta(respuesta);
        //}
    }
}