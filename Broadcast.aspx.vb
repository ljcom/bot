
Imports System.Data.SqlClient
Imports System.Net

Partial Class Broadcast
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim msg As String = "Deskripsi singkat perusahaan : %0AJJ%0A%0ALokasi Penempatan: : %0ABB%0ACantumkan Link URL dari CV LinkedIn anda: : %0ACC%0AApa yang membuat anda tertarik memilih pekerjaan ini? : %0ADD%0AApa yang anda tidak harapakn dari pekerjaan baru anda ini? : %0AEE%0ABerapa income dan fasilitas yang anda harapkan? : %0AFF%0ABerapa minimal income bersih per bulan yang harus anda dapatkan dalam jangka pendek ini? : %0AGG%0APrestasi apa yang anda banggakan yang telah anda raih sampai saat ini? : %0AHH%0AApa yang anda harus raih 5-10 tahun ke depan? : %0AII%0ATanggal Lahir anda? : %0AKK%0AJenis Kelamin? : %0ALL%0A%26lt;Photos%26gt;%0A%26lt;Photo%26gt;AgADBQADs6cxG8V2GQoilKgDozZLrzv-vTIABDgZI2D6BbEO31gBAAEC%26lt;/Photo%26gt;%26lt;/Photos%26gt;%0A%0AKlik /edit untuk edit data, /del untuk hapus data, /like untuk simpan favorit list"

        Dim id = "149745166:AAGVcQx1iPKaOSZ68sS2P_MxNtK2mAY99Io"
        Dim vchatid = "169440965"


        If msg = "" Then msg = "Your command is invalid. Use /help for availablse command."
        If msg = "/" Then msg = ""
        If msg <> "" Then


            Dim url As String = "https://api.telegram.org/bot" & ID & "/sendMessage?chat_id=&parse_mode=HTML&text="

            Dim myWebClient2 = New WebClient()
            Dim resultStr2 As String
            Dim photoid As String

            If msg.Length > 4000 Then



                While msg.Length > 4000


                    Dim cutlocation As Integer = 3800


                    While Not msg.Substring(cutlocation, 200).Contains("%0A") And cutlocation > 0
                        cutlocation -= 200

                    End While


                    If cutlocation <= 0 Then

                        cutlocation = 3800

                    Else
                        cutlocation = cutlocation + msg.Substring(cutlocation, 200).IndexOf("%0A")
                    End If


                    resultStr2 = myWebClient2.DownloadString(url & msg.Substring(0, cutlocation))

                    msg = msg.Substring(cutlocation)



                End While

                If msg.Contains("<Photos>") Then
                    photoid = msg.Substring(msg.IndexOf("<Photos>"))
                    msg = msg.Substring(0, msg.IndexOf("<Photos>"))
                End If

                resultStr2 = myWebClient2.DownloadString(url & msg)





            Else



                If msg.Contains("%26lt;Photos%26gt;") Then
                    photoid = msg.Substring(msg.IndexOf("%26lt;Photos%26gt;"), "%26lt;/Photos%26gt;".Length + msg.IndexOf("%26lt;/Photos%26gt;") - msg.IndexOf("%26lt;Photos%26gt;"))
                    msg = msg.Substring(0, msg.IndexOf("%26lt;Photos%26gt;")) & "%0A" & msg.Substring(msg.IndexOf("Klik /edit untuk edit data, /del untuk hapus data, /like untuk simpan favorit list"))
                    'photoid = photoid.Replace("%26lt;", "<").Replace("%26gt;", ">")
                    'Dim photos As XDocument = XDocument.Parse(photoid)
                    'Dim url2 As String

                    'For Each photo In photos.Element("Photos").Elements("Photo")
                    '    url2 = "https://api.telegram.org/bot" & id & "/sendPhoto?chat_id=" & vchatid & "&photo=" & photo.Value
                    '    resultStr2 = myWebClient2.DownloadString(url2)
                    'Next

                End If

                resultStr2 = myWebClient2.DownloadString(url & msg)
            End If
        End If

    End Sub
End Class
