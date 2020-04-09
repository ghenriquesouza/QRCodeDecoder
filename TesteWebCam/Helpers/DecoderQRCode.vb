Imports QRCodeDecoderLibrary
Imports System.Drawing

Public Class DecoderQRCode
    Private ReadOnly imagem As Bitmap
    Private ReadOnly QRCodeDecoder As QRDecoder
    Public Sub New(ByVal imagem As Bitmap)
        Me.imagem = imagem
        QRCodeDecoder = New QRDecoder()
    End Sub


    Public Function DecodeImagem() As String
        Dim arrayBytes = Me.QRCodeDecoder.ImageDecoder(Me.imagem)

        'If QRCodeDecoder.ECIAssignValue < 0 Then
        '    Return String.Empty
        'Else
        '    Return Me.QRCodeDecoder.ECIAssignValue.ToString()
        'End If

        Dim teste = TrataResultadoDecode(arrayBytes)
        Return teste
    End Function
    Private Function TrataResultadoDecode(ByVal dataArray As Byte()()) As String
        If IsNothing(dataArray) Then
            Return String.Empty
        End If
        If dataArray.Length >= 1 Then
            Return RetornaMensagem(QRDecoder.ByteArrayToStr(dataArray(0)))
        End If

        Return String.Empty
    End Function

    Private Function RetornaMensagem(ByVal Result As String) As String
        Dim Index As Integer
        Index = 0

        While Index < Result.Length AndAlso (Result(Index) >= " "c AndAlso Result(Index) <= "~"c)
            Index += 1
        End While

        If Index = Result.Length Then
            Return Result
        End If

        Dim Display As StringBuilder = New StringBuilder(Result.Substring(0, Index))

        While Index < Result.Length
            Dim OneChar As Char = Result(Index)

            If OneChar >= " "c AndAlso OneChar <= "~"c Then
                Display.Append(OneChar)
                Continue While
            End If

            If OneChar = vbCr Then
                Display.Append(vbCrLf)
                If Index + 1 < Result.Length AndAlso Result(Index + 1) = vbLf Then Index += 1
                Continue While
            End If

            If OneChar = vbLf Then
                Display.Append(vbCrLf)
                Continue While
            End If

            Display.Append("¿"c)
            Index += 1
        End While

        Return Display.ToString()
    End Function

End Class
