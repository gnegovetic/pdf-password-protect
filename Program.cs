using ConsoleCmdProc;
using iText.Kernel.Pdf;
using System;
using System.IO;


namespace PdfPasswordProtect
{

    class Program
    {
        static void Main(string[] args)
        {
            var cl = new CommandLine(true);
            cl.DefineOption("input", "Input File", true, false);
            cl.DefineOption("pw", "Password", true, false);

            cl.LoadArguments(args);

            string inputFile = cl.GetOptionValue("input")[0];
            string password = cl.GetOptionValue("pw")[0];


            // Code below copied from https://itextpdf.com/en/demos/protect-pdf-files-free-online
            string OUTPUT_FOLDER = Path.GetDirectoryName(inputFile);
            byte[] USERPASS = System.Text.Encoding.Default.GetBytes(password);
            byte[] OWNERPASS = System.Text.Encoding.Default.GetBytes(password);

            PdfReader pdfReader = new PdfReader(inputFile);

            WriterProperties writerProperties = new WriterProperties();
            writerProperties.SetStandardEncryption(USERPASS, OWNERPASS, EncryptionConstants.ALLOW_PRINTING, EncryptionConstants.ENCRYPTION_AES_128);

            string outputFile = Path.Combine(OUTPUT_FOLDER, Path.GetFileNameWithoutExtension(inputFile) + "_Protected.pdf");
            PdfWriter pdfWriter = new PdfWriter(new FileStream(outputFile, FileMode.Create), writerProperties);
            PdfDocument pdfDocument = new PdfDocument(pdfReader, pdfWriter);
            pdfDocument.Close();

            Console.WriteLine("Create file: " + outputFile);
        }

     }
}
