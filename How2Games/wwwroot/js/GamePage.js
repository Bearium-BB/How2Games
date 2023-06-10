$(document).ready(function () {
    var debounceTimeout;

    // Triggered when the input in the searchQueryQuestion field changes
    $('#searchQueryQuestion').on('input', function () {
        var searchQueryQuestion = $(this).val();
        if (searchQueryQuestion.trim() === '') {
            // If the search query is empty, hide the search results and return
            $('#searchResultsQuestion').empty().hide();
            return;
        }

        // Clear the previous debounce timeout
        clearTimeout(debounceTimeout);

        // Set a new debounce timeout of 300 milliseconds
        debounceTimeout = setTimeout(function () {
            // Make an AJAX request to the '/SearchBar/Search' URL
            var gameName = getParameterByName('GameName');
            $.ajax({
                url: '/SearchBar/SearchQuestion',
                type: 'POST',
                data: { searchQueryQuestion: searchQueryQuestion, gameName: gameName },
                success: function (result) {
                    if (result.trim() !== '') {
                        // If the result is not empty, display the search results and show them
                        $('#searchResultsQuestion').html(result).show();
                    } else {
                        // If the result is empty, hide the search results
                        $('#searchResultsQuestion').empty().hide();
                    }
                },
                error: function (xhr, status, error) {
                    // Log any errors to the console
                    console.log(xhr.responseText);
                }
            });
        }, 500);
    });
});


function getParameterByName(name) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)');
    var results = regex.exec(window.location.href);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

