using PdfSharpCore;
using PdfSharpCore.Pdf;
using System;
using System.IO;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace eMAS.Api.TerrenosComodatos.Extensions
{
    public class ServiceConvertirHtmlAPdf
    {
        public ServiceConvertirHtmlAPdf()
        { 
        }
        public Tuple<bool, string, byte[]> ConvertirHtmlAPdf(string htmlContent)
        {
            //var pdfBytes = new NReco.PdfGenerator.HtmlToPdfConverter().GeneratePdf(htmlContent.ToString());

            PdfDocument pdf = null;
            byte[] pdfBytes = null;
            try
            {
                pdf = PdfGenerator.GeneratePdf(htmlContent, PageSize.A4);
                //pdf = PdfGenerator.GeneratePdf(htmlContent, PageSize.A4, 20, null, null, null);

                using (MemoryStream stream = new MemoryStream())
                {
                    pdf.Save(stream, true);
                    pdfBytes = stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string, byte[]>(false, ex.Message, null);
            }

            return new Tuple<bool, string, byte[]>(true, "OK", pdfBytes);
        }
        
    }
}
