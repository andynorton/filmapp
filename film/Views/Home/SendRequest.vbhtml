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
            alert(data);
            $('#filmTitle').text(parsedData.Title);
            $('#filmPlot').text(parsedData.Plot);
            $('#filmPoster').attr("src", parsedData.Poster);

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
  <table>

    <tr>
        <td><b><span id="filmTitle"></span></b></td><td><img id="filmPoster" width="80px" /></td><td><span id="filmPlot"></span></td>
    </tr>
  </table>


