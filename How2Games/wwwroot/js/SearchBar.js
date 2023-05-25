$(document).ready(function () {
    // Triggered when the input in the searchQuery field changes
    $('#searchQuery').on('input', function () {
        var searchQuery = $(this).val();
        if (searchQuery.trim() === '') {
            // If the search query is empty, hide the search results and return
            $('#searchResults').empty().hide();
            return;
        }

        // Make an AJAX request to the '/SearchBar/Search' URL
        $.ajax({
            url: '/SearchBar/Search',
            type: 'POST',
            data: { searchQuery: searchQuery },
            success: function (result) {
                if (result.trim() !== '') {
                    // If the result is not empty, display the search results and show them
                    $('#searchResults').html(result).show();
                } else {
                    // If the result is empty, hide the search results
                    $('#searchResults').empty().hide();
                }
            },
            error: function (xhr, status, error) {
                // Log any errors to the console
                console.log(xhr.responseText);
            }
        });
    });

    // Triggered when any element in the document is clicked
    $(document).on('click', function (e) {
        var target = $(e.target);
        // Check if the clicked element is the searchQuery input field, searchResults element,
        // or any of their parent elements (within the SearchResultsContainer)
        if (!target.is('#searchQuery') && !target.is('#searchResults') && !target.parents().is('#SearchResultsContainer')) {
            // If the clicked element is outside the searchQuery and searchResults elements, hide the searchResults
            $('#searchResults').hide();
        }
    });

    // Triggered when the searchQuery input field is clicked
    $('#searchQuery').on('click', function (e) {
        e.stopPropagation(); // Prevent the click event from propagating to the document
        var searchQuery = $(this).val();
        if (searchQuery.trim() !== '') {
            // If the search query is not empty, show the searchResults
            $('#searchResults').show();
        }
    });
});
