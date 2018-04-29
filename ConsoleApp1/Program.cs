using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ConsoleApp1
{
    class Program
    {
        public static string P_OutputStream = @"E:\itextTest1";

        static void Main(string[] args)
        {
            try
            {

                CreatePDFNoTemplate();
                Console.WriteLine("done");
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

           

        }

        private static void CreatePDFNoTemplate()
        {
            Document pdfDoc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream($"{P_OutputStream}/test.pdf" , FileMode.OpenOrCreate));

            pdfDoc.Open();
            pdfDoc.Add(new Paragraph("Some data"));
            PdfContentByte cb = writer.DirectContent;
            cb.MoveTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height / 2);
            cb.LineTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height);
            cb.Stroke();

            pdfDoc.Close();
        }
    }
}
