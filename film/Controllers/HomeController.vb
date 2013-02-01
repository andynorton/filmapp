Imports System.Net
Imports System.IO

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewData("Message") = "Welcome to ASP.NET MVC!"

        Return View()
    End Function

    Function About() As ActionResult
        Return View()
    End Function

    Function SendRequest() As ActionResult
        Return View()

    End Function

    <HttpPost()> _
    Function GetResults(searchTerms As String) As JsonResult
        Dim request = HttpWebRequest.Create("http://www.omdbapi.com/?s=" & searchTerms)
        Dim serverResponse
        request.Method = "GET"
        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            Using reader As New StreamReader(response.GetResponseStream())
                serverResponse = reader.ReadToEnd()
            End Using
        End Using
        Return Json(serverResponse)
    End Function


    Function getMovie(id As String) As ActionResult
        Dim request = HttpWebRequest.Create("http://www.omdbapi.com/?i=" & id)
        Dim serverResponse
        request.Method = "GET"
        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            Using reader As New StreamReader(response.GetResponseStream())
                serverResponse = reader.ReadToEnd()
            End Using
        End Using

        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(serverResponse)

        For Each item As KeyValuePair(Of String, String) In dict
            If item.Key = "Title" Then
                ViewData("FilmTitle") = item.Value
            End If
            If item.Key = "Poster" Then
                ViewData("FilmPoster") = item.Value
            End If
            If item.Key = "Plot" Then
                ViewData("FilmPlot") = item.Value
            End If
        Next


        Return View()

    End Function


End Class
