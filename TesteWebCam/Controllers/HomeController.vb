Imports System.IO
Imports System.Drawing
Imports QRCodeDecoderLibrary

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    <HttpPost()>
    Function UploadImagem(ByVal imagem As String) As ActionResult
        Dim bitMap = TransformaBase64toBitmap(imagem)
        Dim respostaDecoder = DecodificaQrCode(bitMap)
        Dim respostaXing = DecodificaQrCodeZXing(bitMap)

        Return Json(respostaDecoder, JsonRequestBehavior.AllowGet)
    End Function

    Private Function TransformaBase64toBitmap(ByVal imagemBase64 As String) As Bitmap

        Dim imagemBytes = Convert.FromBase64String(imagemBase64)
        Dim fileName = "imagem.jpg"

        ' IO.File.WriteAllBytes(String.Format("{0}{1}", HttpContext.Server.MapPath("~/Content/Images/"), fileName), imagemBytes)

        Dim imageConverter As New Drawing.ImageConverter()
        Dim imageRetorno = TryCast(imageConverter.ConvertFrom(imagemBytes), Bitmap)
        ' imageRetorno.Save("teste.bmp")
        Return imageRetorno
    End Function

    Private Function DecodificaQrCode(ByVal imagem As Bitmap) As String
        Return New DecoderQRCode(imagem).DecodeImagem()
    End Function

    Private Function DecodificaQrCodeZXing(ByVal imagem As Bitmap) As String
        Dim reader = New ZXing.BarcodeReader()
        Dim result = reader.Decode(imagem)
        Return result.Text
    End Function

End Class
