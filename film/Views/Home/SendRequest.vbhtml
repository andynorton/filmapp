@Code
    ViewData("Title") = "SendRequest"
End Code

<script>
    function submitForm() {
 
        var searchTerm = $("input[id$=searchTerms]").val();
        $.ajax({
            url: "/home/GetResults",
            type: "POST",
            data: { searchTerms: searchTerm },
            dataType: "json",
            success: function (data) {
                var parsedData = JSON.parse(data);
                $("#results tr").remove();
                $(parsedData.Search).each(function (index, element) {
                    $('#results').append('<tr><td>' + element.Title + '</td><td><a href="getmovie/' + element.imdbID + '">View<a/></td></tr>');
                });
            },
            error: function () {
                alert("error");
            }
        });
    }
</script>

  @Html.TextBox("searchTerms")
  <input type="button" value="Submit" onclick="submitForm()" />
  <hr />
  <table id="results">
  </table>
