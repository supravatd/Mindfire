$(document).ready(function () {
    const queryString = window.location.search;
    const url = new URLSearchParams(queryString);
    var agencyId = parseInt(url.get('agencyId'));
    fetchAllNews(agencyId);
    var refreshInterval;
    var selectedCategories = [];

    var storedCategories = getCookie
        ('selectedCategories');
    if (storedCategories) {
        selectedCategories = storedCategories.split(',').map(Number);
        selectedCategories.forEach(function (categoryId) {
            $('.categoryTitle[data-id="' + categoryId + '"]').addClass('selected');
        });
    }

    $('.categoryTitle').click(function (e) {
        e.preventDefault();
        var categoryId = parseInt($(this).data('id'));
        $(this).toggleClass('selected');
        if ($(this).hasClass('selected')) {
            selectedCategories.push(categoryId);
        } else {
            var index = selectedCategories.indexOf(categoryId);
            if (index !== -1) {
                selectedCategories.splice(index, 1);
            }
        }
        setCookie('selectedCategories', selectedCategories.join(','), 30);

        clearInterval(refreshInterval);
        fetchNewsByCategories(selectedCategories, agencyId);
        autoRefreshNews(selectedCategories, agencyId);
    });

    function fetchNewsByCategories(categories, agencyId) {
        $.ajax({
            url: '/Feed/GetNewsByCategories',
            type: 'POST',
            data: {
                categories: categories,
                agencyId: agencyId
            },
            success: function (response) {
                $('#newsDisplay').empty();
                $.each(response.NewsData, function (index, newsItem) {
                    var publishDate = new Date(parseInt(newsItem.NewsPublishDateTime.substr(6)));
                    var formattedDate = publishDate.toLocaleString();
                    var newsLink = $('<a>')
                        .attr('href', newsItem.NewsLink)
                        .attr('target', '_blank')
                        .html('<h6>' + newsItem.NewsTitle + '</h6>' +
                            '<p>' + newsItem.NewsDescription + '</p>' +
                            '<small class="text-muted">Publish Date: ' +
                            formattedDate + '</small>')
                        .on('click', function () {
                            incrementClickCount(newsItem.NewsId);
                        });
                    $('#newsDisplay').append(newsLink);
                });
                if (response.NewsAdded) {
                    console.log('New news added.');
                }
            },
            error: function (xhr, status, error) {
                console.log('Error fetching news data:', error);
            }
        });
    }

    function autoRefreshNews(categories, agencyId) {
        refreshInterval = setInterval(function () {
            console.log('Auto refresh triggered');
            fetchNewsByCategories(categories, agencyId);
        }, 60000);
    }

    function incrementClickCount(newsId) {
        $.ajax({
            url: '/Feed/IncrementClickCount',
            type: 'POST',
            data: { newsId: newsId },
            success: function () {
                console.log('Click count incremented for news item with ID: ' + newsId);
            },
            error: function (xhr, status, error) {
                console.log('Error incrementing click count:', error);
            }
        });
    }

    function fetchAllNews(agencyId) {
        $.ajax({
            url: '/Feed/NewsFeed',
            type: 'GET',
            data: { agencyId: agencyId },
            success: function (response) {
                $('#newsDisplay').empty();

                if (response.NewsData && response.NewsData.length > 0) {
                    $.each(response.NewsData, function (index, newsItem) {
                        var publishDate = new Date(parseInt(newsItem.NewsPublishDateTime.substr(6)));
                        var formattedDate = publishDate.toLocaleString();

                        var newsLink = $('<a>')
                            .attr('href', newsItem.NewsLink)
                            .attr('target', '_blank')
                            .html('<h6>' + newsItem.NewsTitle + '</h6>' +
                                '<p>' + newsItem.NewsDescription + '</p>' +
                                '<small class="text-muted">Publish Date: ' +
                                formattedDate + '</small>')
                            .on('click', function () {
                                incrementClickCount(newsItem.NewsId);
                            });
                        $('#newsDisplay').append(newsLink);
                    });
                } else {
                    $('#newsDisplay').html('<p>No news available.</p>');
                }
            },
            error: function (xhr, status, error) {
                console.log('Error fetching news data:', error);
            }
        });
    }

    function setCookie(name, value, days) {
        var data = {
            name: name,
            value: value,
            days: days
        };

        $.ajax({
            url: '/Feed/SetSelectedCategories',
            type: 'POST',
            data: data,
            success: function (response) {
                if (response.success) {
                    console.log('Cookie set successfully');
                } else {
                    console.log('Failed to set cookie');
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error setting cookie:', textStatus, errorThrown);
            }
        });
    }

    function getCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }
});
