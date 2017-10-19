Imports System.Linq
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient

Partial Class report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'xml in page
        'Page.Response.ContentType = "text/xml"
        'Dim reader As System.IO.StreamReader = New System.IO.StreamReader(Page.Request.InputStream)
        'Dim xmlData As String = reader.ReadToEnd()

        Dim xmlData As String = Request.QueryString("xml").Replace("!3C", "<").Replace("!3E", ">")
        'Dim xmlData As String = "<root><summary><daily date=""1/5/2016"" nbTrx=""10"" GrossSales=""1200000"" NetSales=""1000000"" MTDnbTrx=""10"" MTDGrossSales=""1200000"" MTDNetSales=""1000000"" YTDnbTrx=""10"" YTDGrossSales=""1200000"" YTDNetSales=""1000000""></daily></summary></root>"
        'Dim SW As System.IO.StreamWriter
        'SW = File.CreateText ( Server.MapPath(".")+@"\"+ Guid.NewGuid () + ".txt" )
        'SW.WriteLine(xmlData)
        'SW.Close()

        'Dim xmlDoc As XmlDocument = New XmlDocument()
        'xmlDoc.LoadXml(xmlData)
        'System.Diagnostics.Debug.Write(xmlDoc.OuterXml)
        Dim root As XElement = XElement.Parse(xmlData)
        Dim daily As IEnumerable(Of XElement) = From el In root.<summary>.<daily>
                                                Select el
        Dim salesDate As Date
        Dim nbTrx As Double, gSales As Double, nSales As Double
        Dim MTDnbTrx As Double, MTDgSales As Double, MTDnSales As Double
        Dim YTDnbTrx As Double, YTDgSales As Double, YTDnSales As Double

        Dim sqlstr As String
        For Each el As XElement In daily
            salesDate = el.@date
            nbTrx = el.@nbTrx
            gSales = el.@GrossSales
            nSales = el.@NetSales
            MTDnbTrx = el.@MTDnbTrx
            MTDgSales = el.@MTDGrossSales
            MTDnSales = el.@MTDNetSales
            YTDnbTrx = el.@YTDnbTrx
            YTDgSales = el.@YTDGrossSales
            YTDnSales = el.@YTDNetSales

            sqlstr = "exec dailySales '" & salesDate & "', '" & nbTrx & "', '" & gSales & "', '" & nSales & "', " &
                                                        "'" & MTDnbTrx & "', '" & MTDgSales & "', '" & MTDnSales & "', " &
                                                        "'" & YTDnbTrx & "', '" & YTDgSales & "', '" & YTDnSales & "'"
			Dim con As String = "Initial Catalog=BOT_reports;Data Source=oph-alpha;User Id=gov;password=ljcom2x"
			runSQL(sqlstr, con)
            System.Diagnostics.Debug.Write(sqlstr)
        Next

        Response.Write("done")
    End Sub

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
End Class
