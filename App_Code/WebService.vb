Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class WebService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function Broadcast(Schedule As String, Message As String, Channel As String) As XmlDocument
        Dim result As String = ""
        Try

            Dim Convertedschedule = DateTime.Parse(Schedule)

            Dim con As New SqlConnection

            Dim cmd As New SqlCommand

            Dim appSettings As NameValueCollection = ConfigurationManager.AppSettings
            con.ConnectionString = appSettings.Item("Connection")

            con.Open()

            cmd = New SqlCommand("exec InsertBroadcast '" & Convertedschedule & "','" & Message & "','" & Channel & "'", con)
            result = cmd.ExecuteScalar()

            con.Close()

            'sp insert
            If Not result.Contains("Success") Then

                result = "<Result>Failed</Result><ErrorMessage>" & result & "</ErrorMessage>"
            Else

                result = "<Result>Success</Result>"
            End If

        Catch ex As Exception

            'result = result + "<Error>"
            'result = result + "<Message>"
            'result = result + "<Stacktrace>"
            'result = result + "<StackTrace>"
            'result = result + "<Message>"
            'result = result + "<Error>"

            result = result + "<ErrorMessage>"
            result = result + ex.Message
            result = result + "</ErrorMessage>"

        End Try


        Dim xmlresponse = "<?xml version='1.0' encoding ='utf-8'?>"
        xmlresponse = xmlresponse + "<Response>"
        xmlresponse = xmlresponse + result
        xmlresponse = xmlresponse + "</Response>"

        Dim xmldoc = New XmlDocument()
        xmldoc.LoadXml(xmlresponse)

        Return xmldoc

    End Function

    <WebMethod()>
    Public Function Article(type As String, Message As String, Channel As String) As XmlDocument
        Dim result As String = ""
        Try



            Dim con As New SqlConnection

            Dim cmd As New SqlCommand

            Dim appSettings As NameValueCollection = ConfigurationManager.AppSettings
            con.ConnectionString = appSettings.Item("Connection")

            con.Open()

            cmd = New SqlCommand("exec InsertArticle '" & type & "','" & Message & "','" & Channel & "'", con)
            result = cmd.ExecuteScalar()

            con.Close()

            'sp insert
            If Not result.Contains("Success") Then

                result = "<Result>Failed</Result><ErrorMessage>" & result & "</ErrorMessage>"
            Else

                result = "<Result>Success</Result>"
            End If

        Catch ex As Exception

            'result = result + "<Error>"
            'result = result + "<Message>"
            'result = result + "<Stacktrace>"
            'result = result + "<StackTrace>"
            'result = result + "<Message>"
            'result = result + "<Error>"

            result = result + "<ErrorMessage>"
            result = result + ex.Message
            result = result + "</ErrorMessage>"

        End Try


        Dim xmlresponse = "<?xml version='1.0' encoding ='utf-8'?>"
        xmlresponse = xmlresponse + "<Response>"
        xmlresponse = xmlresponse + result
        xmlresponse = xmlresponse + "</Response>"

        Dim xmldoc = New XmlDocument()
        xmldoc.LoadXml(xmlresponse)

        Return xmldoc
    End Function


End Class