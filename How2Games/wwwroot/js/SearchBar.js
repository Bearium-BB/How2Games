$(document).ready(function () {
    $('#searchQuery').on('input', function () {
        var searchQuery = $(this).val();
        if (searchQuery.trim() === '') {
            $('#searchResults').empty().hide();
            return;
        }
        $.ajax({
            url: '/SearchBar/Search',
            type: 'POST',
            data: { searchQuery: searchQuery },
            success: function (result) {
                if (result.trim() !== '') {
                    $('#searchResults').html(result).show();
                } else {
                    $('#searchResults').empty().hide();
                }
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
            }
        });
    });

    $(document).on('click', function (e) {
        var target = $(e.target);
        if (!target.is('#searchQuery') && !target.is('#searchResults') && !target.parents().is('#SearchResultsContainer')) {
            $('#searchResults').hide();
        }
    });

    $('#searchQuery').on('click', function (e) {
        e.stopPropagation();
        var searchQuery = $(this).val();
        if (searchQuery.trim() !== '') {
            $('#searchResults').show();
        }
    });
});
