using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace W2.Web.Portal.Utils
{
    public class GAnalyticsStream : MemoryStream
    {

        private readonly Stream _base;
        private string _script = $"<script async src = \"https://www.googletagmanager.com/gtag/js?id=UA-52144110-1\" ></script>" + 
               "<script>"+
                    "window.dataLayer = window.dataLayer || [];" +
                    "function gtag() { dataLayer.push(arguments); }"+
                    "gtag('js', new Date());"+
                    "gtag('config', 'UA-52144110-1');"+
                "</script>";

        public GAnalyticsStream(Stream filter)
        {
            _base = filter;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {

            buffer = GetBufferWithScript(buffer); 
            _base.Write(buffer, offset, buffer.Length);
        }

        public byte[] GetBufferWithScript(byte[] buffer)
        {
            StringBuilder strBuffer = new StringBuilder( Encoding.UTF8.GetString(buffer));

            if (strBuffer != null && strBuffer.Length > 0)
                strBuffer = strBuffer.Replace("</body>", $"</body>{_script}");

            return Encoding.UTF8.GetBytes(strBuffer.ToString()); 

        }
        
    }
}