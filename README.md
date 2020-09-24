# Simple app that protects a PDF file with a password of your choice

Code is using iText library, and is based on: https://itextpdf.com/en/demos/protect-pdf-files-free-online

With this app, no unprotected PDF file is uploaded and it's processed on your machine. 

# Example usage
``` PdfPasswordProtect.exe /input=.\Test.pdf /pw=x2TiM8BG66Cv ```

This will generate Test_Protected.pdf. 

On Mac or Linux you can run this app if you install _mono_: ``` mono PdfPasswordProtect.exe /input=Test.pdf /pw=test ``` 
