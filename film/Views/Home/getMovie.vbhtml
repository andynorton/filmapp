@Code
    ViewData("Title") = "getMovie"
End Code

<h2>@ViewData("FilmTitle")</h2>
<div>
<img src='@ViewData("FilmPoster")' /><p>@ViewData("FilmPlot")</p>
</div>
