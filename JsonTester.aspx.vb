Imports Microsoft.VisualBasic
Imports System.Xml
Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports System.Data
Imports System.Data.SqlClient


Public Class Jsontester
    Inherits System.Web.UI.Page

    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim stream As StreamReader = New StreamReader(Request.InputStream)
        Dim strmContents As String = stream.ReadToEnd()
        Dim action As String = ""

        Dim jsonStr As String = ""
        jsonStr = """update_id"":443597062,""message"":{""message_id"":57,""from"":{""id"":169440965,""first_name"":""Michael"",""last_name"":""Ryan"",""username"":""TanMichaelRyan""},""chat"":{""id"":169440965,""first_name"":""Michael"",""last_name"":""Ryan"",""username"":""TanMichaelRyan"",""type"":""private""},""date"":1476945669,""text"":""\/info"",""entities"":[{""type"":""bot_command"",""offset"":0,""length"":5}]}}"
        'If jsonStr = "" Then jsonStr = "{""ok"":true,""result"":[{""update_id"":139955189,""message"":{""message_id"":85,""from"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1448027691,""text"":""test""}},{""update_id"":139955190,""message"":{""message_id"":86,""from"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1448027694,""text"":""test2""}},{""update_id"":139955191,""message"":{""message_id"":87,""from"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1448030031,""text"":""test3""}},{""update_id"":139955192,""message"":{""message_id"":88,""from"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika""},""chat"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika"",""type"":""private""},""date"":1448038463,""text"":""\/start""}},{""update_id"":139955193,""message"":{""message_id"":89,""from"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika""},""chat"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika"",""type"":""private""},""date"":1448038476,""text"":""Testing savitri""}},{""update_id"":139955194,""message"":{""message_id"":90,""from"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika""},""chat"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika"",""type"":""private""},""date"":1448038634,""reply_to_message"":{""message_id"":89,""from"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika""},""chat"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika"",""type"":""private""},""date"":1448038476,""text"":""Testing savitri""},""text"":""Test reply""}}]}"
        'jsonStr = "{""ok"":true,""result"":[{""update_id"":139955189,""message"":{""message_id"":85,""from"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1448027691,""text"":""test""}},{""update_id"":139955190,""message"":{""message_id"":86,""from"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1448027694,""text"":""test2""}},{""update_id"":139955191,""message"":{""message_id"":87,""from"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1448030031,""text"":""test3""}},{""update_id"":139955192,""message"":{""message_id"":88,""from"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika""},""chat"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika"",""type"":""private""},""date"":1448038463,""text"":""\/start""}},{""update_id"":139955193,""message"":{""message_id"":89,""from"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika""},""chat"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika"",""type"":""private""},""date"":1448038476,""text"":""Testing savitri""}},{""update_id"":139955194,""message"":{""message_id"":90,""from"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika""},""chat"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika"",""type"":""private""},""date"":1448038634,""reply_to_message"":{""message_id"":89,""from"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika""},""chat"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika"",""type"":""private""},""date"":1448038476,""text"":""Testing savitri""},""text"":""Test reply""}}]}"
        'jsonStr = "{""ok"":true,""result"":[{""update_id"":139955511,""message"":{""message_id"":739,""from"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1448376264,""reply_to_message"":{""message_id"":736,""from"":{""id"":165283099,""first_name"":""Puji Syukur Bot"",""username"":""PujiSyukurBot""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1448376041,""forward_from"":{""id"":145134738,""first_name"":""Savitri"",""last_name"":""Rafika""},""forward_date"":1448376040,""text"":""Testing""},""text"":""ini test""}}]}"
        '     jsonStr = "{""ok"":true,""result"":[{""update_id"":489605305,""message"":{""message_id"":213,""from"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1448777320,""photo"":[{""file_id"":""AgADBQADsKcxGxzJIArGlypKownC3YJLvjIABF6hyUfGBaLW-1cAAgI"",""file_size"":1104,""width"":45,""height"":90},{""file_id"":""AgADBQADsKcxGxzJIArGlypKownC3YJLvjIABJ7ZD_mBJTpM-lcAAgI"",""file_size"":8816,""width"":159,""height"":320},{""file_id"":""AgADBQADsKcxGxzJIArGlypKownC3YJLvjIABOQfSeELpjEAAflXAAIC"",""file_size"":7794,""width"":173,""height"":348}],""caption"":""dua""}}]}"
        'jsonStr = "{""update_id"":268347487,""message"":{""message_id"":358,""from"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya""},""chat"":{""id"":169920796,""first_name"":""Samuel"",""last_name"":""Surya"",""username"":""Samuelsurya"",""type"":""private""},""date"":1463121920,""text"":""\/Reg"",""entities"":[{""type"":""bot_command"",""offset"":0,""length"":4}]}}"

        'write log
        Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")
            Log(jsonStr, w)
            'Log("Test2", w)
        End Using

        'Using r As StreamReader = File.OpenText("log.txt")
        'DumpLog(r)
        'End Using


        Dim var As String = ""
        Dim varkey As String = ""
        Dim prevGroup As String = ""
        Dim varGroup As String = ""

        Dim vOK As Boolean
        Dim vupdateId As String = "0"
        Dim vmsgId As String = "0"
        Dim vreplyId As String = ""
        Dim vchatId As String = ""
        Dim vchatfn As String = ""
        Dim vchatln As String = ""
        Dim vchatun As String = ""
        Dim vchattype As String = ""
        Dim vfromId As String = ""
        Dim vfromfn As String = ""
        Dim vfromln As String = ""
        Dim vfromun As String = ""

        Dim vffromId As String = ""
        Dim vffromfn As String = ""
        Dim vffromln As String = ""

        Dim vReplyText As String = ""
        Dim vText As String = "", vLat As String = "", vLong As String = ""
        Dim vPhoto1 As String = "", vPhoto2 As String = "", vPhoto3 As String = "", vPhotoCap As String = ""
        Dim vAudio As String = "", vVideo As String = "", vVoice As String = "", vDoc As String = "", vSticker As String = ""

        Dim msg As String = ""

        Dim id = Request.QueryString("id")
        '      id = "165283099:AAH2HR0xUcOCLJGd2FHlA3Wo-EprTS9SD_8"

        'Dim lastData As String = getLastMsg(id, jsonStr)

        Dim reader As New JsonTextReader(New StringReader(jsonStr))
        While reader.Read()
            If reader.Value IsNot Nothing Then
                Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value)
                Select Case var
                    Case "OK"
                        vOK = reader.Value : var = ""
                    Case "updateId" : vupdateId = reader.Value : var = ""
                    Case "firstname"
                        If varkey = "chat" Then vchatfn = reader.Value : var = ""
                        If varkey = "from" Then vfromfn = reader.Value : var = ""
                        If varkey = "forward" Then vffromfn = reader.Value : var = ""
                    Case "lastname"
                        If varkey = "chat" Then vchatln = reader.Value : var = ""
                        If varkey = "from" Then vfromln = reader.Value : var = ""
                        If varkey = "forward" Then vffromln = reader.Value : var = ""
                    Case "username"
                        If varkey = "chat" Then vchatun = reader.Value : var = ""
                        If varkey = "from" Then vfromun = reader.Value : var = ""
                        'If varkey = "forward" Then vffromun = reader.Value : var = ""
                    Case "title"
                        If varkey = "chat" Then vchatun = reader.Value : var = ""
                    Case "type"
                        If varkey = "chat" Then vchattype = reader.Value : var = ""
                        'If varkey = "from" Then vfromId = reader.Value : var = ""
                    Case "id"
                        If varkey = "chat" Then vchatId = reader.Value : var = ""
                        If varkey = "from" Then vfromId = reader.Value : var = ""
                        If varkey = "forward" Then vffromId = reader.Value : var = ""
                    Case "messageId"
                        If varGroup = "message" Then vmsgId = reader.Value : var = ""
                        If varGroup = "reply" Then vreplyId = reader.Value : var = ""
                    Case "text"
                        If varGroup = "message" Then
                            vText = reader.Value
                            var = ""
                        End If
                        If varGroup = "reply" Then vReplyText = reader.Value : var = "" : varGroup = prevGroup
                    Case "longitude"
                        vLong = reader.Value.ToString : var = ""
                    Case "latitude"
                        vLat = reader.Value.ToString : var = ""
                    Case "file_id"
                        Select Case True
                            Case varkey = "photo" And vPhoto1 = "" : vPhoto1 = reader.Value : var = ""
                            Case varkey = "photo" And vPhoto2 = "" : vPhoto2 = reader.Value : var = ""
                            Case varkey = "photo" And vPhoto3 = "" : vPhoto3 = reader.Value : var = ""
                            Case varkey = "audio" : vAudio = reader.Value : var = ""
                            Case varkey = "voice" : vVoice = reader.Value : var = ""
                            Case varkey = "video" : vVideo = reader.Value : var = ""
                            Case varkey = "document" : vDoc = reader.Value : var = ""
                            Case varkey = "sticker" : vSticker = reader.Value : var = ""
                        End Select
                    Case "caption"
                        If varkey = "photo" Then vPhotoCap = reader.Value : vText = "_photo" : var = ""
                    Case "file_name"
                        If varkey = "document" Then vPhotoCap = reader.Value : vText = "_doc" : var = ""

                    Case Else
                        Select Case reader.Value.ToString
                            Case "ok" : var = "OK"
                            Case "update_id" : var = "updateId"
                            Case "message_id" : var = "messageId"
                            Case "id" : var = "id"
                            Case "first_name" : var = "firstname"
                            Case "last_name" : var = "lastname"
                            Case "username" : var = "username"
                            Case "title" : var = "title"
                            Case "type" : var = "type"
                            Case "text" : var = "text" : action = "typing"
                            Case "longitude" : var = "longitude" : action = "find_location"
                            Case "latitude" : var = "latitude"
                            Case "file_id" : var = "file_id"
                            Case "caption" : var = "caption"
                            Case "file_name" : var = "file_name"

                            Case "from" : varkey = "from" : var = "from"
                            Case "forward_from" : varkey = "forward" : var = "from"
                            Case "chat" : varkey = "chat" : var = "chat"
                            Case "reply_to_message" : prevGroup = "message" : varGroup = "reply"
                            Case "message" : varGroup = "message"
                            Case "photo" : varkey = "photo" : vPhoto1 = "" : vPhoto2 = "" : vPhoto3 = "" : vPhotoCap = "" : action = "upload_photo"
                            Case "thumb" : varkey = "photo" : vPhoto1 = "" : vPhoto2 = "" : vPhoto3 = "" : vPhotoCap = ""
                            Case "audio" : varkey = "audio" : action = "upload_audio"
                            Case "video" : varkey = "video" : action = "upload_video"
                            Case "voice" : varkey = "voice" : action = "record_audio"
                            Case "sticker" : varkey = "sticker"
                            Case "document" : varkey = "document" : action = "upload_document"
                        End Select
                End Select
            Else
                Console.WriteLine("Token: {0}", reader.TokenType)
            End If
        End While

        'save all
        Dim lastData As String = getLastMsg(id, jsonStr)
        If vupdateId > lastData Then
            msg = saveData(id, vupdateId, vmsgId, vreplyId, vchatId, vchatfn, vchatln, vchatun, vchattype, vfromId, vfromfn, vfromln, vfromun, vffromId, vffromfn, vffromln, vReplyText, vText, vLong, vLat, vPhoto1, vPhoto2, vPhoto3, vPhotoCap, vVideo, vAudio, vVoice, vDoc, vSticker)

            Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")
                Log("MSG : " + msg, w)
                'Log("Test2", w)
            End Using
            'vchatId = "169920796"
            'msg = strmContents
            If msg = "" Then msg = "Your command is invalid. Use /help for available command."
            If msg = "/" Then msg = ""
            If msg <> "" Then


                Dim url As String = "https://api.telegram.org/bot" & id & "/sendMessage?chat_id=" & vchatId & "&parse_mode=HTML&text="

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

                        Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")
                            Log("URL : " & url & msg.Substring(0, cutlocation), w)

                        End Using

                        Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")
                            Log("Telegram Response : " & resultStr2, w)

                        End Using

                    End While

                    If msg.Contains("<Photos>") Then
                        photoid = msg.Substring(msg.IndexOf("<Photos>"))
                        msg = msg.Substring(0, msg.IndexOf("<Photos>"))
                    End If

                    resultStr2 = myWebClient2.DownloadString(url & msg)

                    Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")

                        Log("URL : " + url & msg, w)

                    End Using

                    Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")
                        Log("Telegram Response : " + resultStr2, w)

                    End Using



                Else
                    If msg.Contains("%26lt;Photos%26gt;") Then
                        photoid = msg.Substring(msg.IndexOf("%26lt;Photos%26gt;"), "%26lt;/Photos%26gt;".Length + msg.IndexOf("%26lt;/Photos%26gt;") - msg.IndexOf("%26lt;Photos%26gt;"))
                        msg = msg.Substring(0, msg.IndexOf("%26lt;Photos%26gt;")) & "%0A" & msg.Substring(msg.IndexOf("Klik /edit untuk edit data, /del untuk hapus data, /like untuk simpan favorit list"))
                        photoid = photoid.Replace("%26lt;", "<").Replace("%26gt;", ">")
                        Dim photos As XDocument = XDocument.Parse(photoid)
                        Dim url2 As String
                        Using w As StreamWriter = File.AppendText("d:\mike.txt")

                            Log(photos.ToString, w)

                        End Using

                        For Each photo In photos.Element("Photos").Elements("Photo")
                            url2 = "https://api.telegram.org/bot" & id & "/sendPhoto?chat_id=" & vchatId & "&photo=" & photo.Value
                            resultStr2 = myWebClient2.DownloadString(url2)
                            Using w As StreamWriter = File.AppendText("d:\mike.txt")

                                Log("test3", w)

                            End Using

                            Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")

                                Log("URL : " + url2 & msg, w)

                            End Using

                            Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")

                                Log("Telegram Response Photo: " + resultStr2, w)

                            End Using


                        Next

                    End If

                    Dim separator() As String = {"[#newchat#]"}
                    For Each sendmsg In msg.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                        resultStr2 = myWebClient2.DownloadString(url & sendmsg)

                        Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")

                            Log("URL : " + url & sendmsg, w)

                        End Using

                        Using w As StreamWriter = File.AppendText("D:\log telegram\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")

                            Log("Telegram Response : " + resultStr2, w)
                            w.WriteLine(vbCrLf + "--------------------------------------------------------------------------")
                        End Using
                    Next

                End If


            End If
        End If
    End Sub
    Function saveData(token As String, vupdateId As String, vmsgId As String, vreplyId As String, vchatId As String, vchatfn As String, vchatln As String, vchatun As String,
                    vchattype As String, vfromId As String, vfromfn As String, vfromln As String, vfromun As String, vffromId As String, vffromfn As String, vffromln As String,
                    vReplyText As String, vText As String, vLong As String, vLat As String, vPhoto1 As String, vPhoto2 As String, vPhoto3 As String, vPhotoCap As String, vvideo As String, vaudio As String, vvoice As String, vdoc As String, vsticker As String) As String

        Dim sql As String = "exec saveData '" & token & "', '" & vupdateId & "', '" & vmsgId & "', '" & vreplyId & "', '" & vchatId & "', '" & vchatfn & "', '" & vchatln & "', '" & vchatun & "', '" & vchattype & "', '" & vfromId & "', '" & vfromfn & "', '" & vfromln & "', '" & vfromun & "', '" & vffromId & "', '" & vffromfn & "', '" & vffromln & "', '" & vReplyText & "', '" & vText & "', '" & vLong & "', '" & vLat & "', '" & vPhoto1 & "', '" & vPhoto2 & "', '" & vPhoto3 & "', '" & vPhotoCap & "', '" & vvideo & "', '" & vaudio & "', '" & vvoice & "', '" & vdoc & "', '" & vsticker & "'"
		'vOK, vupdateId, vmsgId, vreplyId, vchatId, vchatfn, vchatln, vchatun, vchattype, vfromId, vfromfn, vfromln, vfromun, vReplyText, vText)

		Dim con As String = "Initial Catalog=BOT;Data Source=oph-alpha;User Id=gov;password=ljcom2x"
		Dim r = runSQLwithResult(sql, con)


        Return r
    End Function
    Function getLastMsg(token As String, jsonstr As String) As String
        Dim sql As String = "exec getLastData '" & token & "', '" & Replace(jsonstr, "'", "''") & "'"
		Dim con As String = "Initial Catalog=BOT;Data Source=oph-alpha;User Id=gov;password=ljcom2x"
		Dim id As String = runSQLwithResult(sql, con)

        Return id
    End Function

    Function runSQL(ByVal sqlstr As String, Optional ByVal sqlconstr As String = "") As Boolean
        Dim r As Boolean
        Dim myConnectionString As String
        ' If the connection string is null, usse a default.
        myConnectionString = Session("ODBC")
        If myConnectionString = "" And sqlconstr = "" Then
            r = False 'Return False
            'Exit Function
        End If

        If sqlconstr <> "" Then
            myConnectionString = sqlconstr
        End If
        Try
            Dim myConnection As New SqlConnection(myConnectionString)
            '        Dim myInsertQuery As String = "INSERT INTO Customers (CustomerID, CompanyName) Values('NWIND', 'Northwind Traders')"
            Dim myInsertQuery As String = sqlstr
            Dim myCommand As New SqlCommand(myInsertQuery)
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandTimeout = 600
            myCommand.ExecuteNonQuery()
            myCommand.Connection.Close()
            myConnection.Close()
        Catch ex As SqlException
            'contentofError = ex.Message & "<br>"
            r = False
        Catch ex As Exception
            'contentofError = ex.Message & "<br>"
            'Return False
            r = False
        End Try
        'GC.Collect()
        Return r

    End Function

    Function runSQLwithResult(ByVal sqlstr As String, Optional ByVal sqlconstr As String = "") As String
        Dim result As String

        Dim myConnectionString As String
        ' If the connection string is null, usse a default.
        myConnectionString = Session("ODBC")
        If myConnectionString = "" And sqlconstr = "" Then
            'SignOff()
            Return ""
            Exit Function
        End If


        If sqlconstr <> "" Then
            myConnectionString = sqlconstr
        End If
        Try
            Dim myConnection As New SqlConnection(myConnectionString)
            '        Dim myInsertQuery As String = "INSERT INTO Customers (CustomerID, CompanyName) Values('NWIND', 'Northwind Traders')"
            Dim myInsertQuery As String = sqlstr
            '
            Dim myCommand As New SqlCommand(myInsertQuery)
            Dim Reader As SqlClient.SqlDataReader

            myCommand.Connection = myConnection
            myConnection.Open()
            Dim myCommand1 As New SqlCommand("SET ARITHABORT ON", myConnection)
            Dim myCommand2 As New SqlCommand("SET QUOTED_IDENTIFIER On", myConnection)
            myCommand1.ExecuteNonQuery()
            myCommand2.ExecuteNonQuery()
            myCommand.CommandTimeout = 600
            Reader = myCommand.ExecuteReader()

            Reader.Read()
            If Reader.HasRows Then
                result = Reader.GetValue(0).ToString
            Else
                result = ""
            End If
            myCommand.Connection.Close()
            myConnection.Close()
        Catch ex As SqlException
            'contentofError = ex.Message & "<br>"
            Return ""
        Catch ex As Exception
            'contentofError = ex.Message & "<br>"
            Return ""
        End Try
        'GC.Collect()
        Return result
    End Function

    Public Function SelectSqlSrvRows(ByVal connection As String, ByVal query As String) As DataSet
        Dim conn As New SqlConnection(connection)
        Dim adapter As New SqlDataAdapter
        Dim dataSet As New DataSet
        Try
            adapter.SelectCommand = New SqlCommand(query, conn)
            adapter.SelectCommand.CommandTimeout = 0
            adapter.Fill(dataSet)

        Catch ex As SqlException
            'contentofError = query & ex.Message & "<br>"
        Catch ex As Exception
            'contentofError = query & ex.Message & "<br>"
        End Try
        adapter = Nothing
        conn.Close()
        'GC.Collect()
        Return dataSet

    End Function


    Public Shared Sub Log(logMessage As String, w As TextWriter)
        w.Write(vbCrLf + "Log Entry : ")
        w.WriteLine("{0} {1}: {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), logMessage)
        'w.WriteLine("  :{0}", logMessage)
        w.WriteLine("-------------------------------")
    End Sub

    Public Shared Sub DumpLog(r As StreamReader)
        Dim line As String
        line = r.ReadLine()
        While Not (line Is Nothing)
            Console.WriteLine(line)
            line = r.ReadLine()
        End While
    End Sub
End Class
