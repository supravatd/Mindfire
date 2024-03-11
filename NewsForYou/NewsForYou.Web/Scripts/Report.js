$(document).ready(function () {
    var currentPage = 1;
    var pageSize = 5;

    function loadNewsReport(page) {
        $.ajax({
            url: '/Report/ClickCountReport',
            type: 'POST',
            data: {
                startDate: $('#startDate').val(),
                endDate: $('#endDate').val(),
                page: page,
                pageSize: pageSize
            },
            success: function (response) {
                if (response.data.length === 0) {
                    $('#newsTable tbody').html('<p>No data available.</p>');
                } else {
                    renderNewsReport(response.data);
                    renderPagination(response.totalPages, page);
                    allData = response.data;
                }
            },
            error: function (xhr, status, error) {
                console.error("Error generating report:", error);
            }
        });
    }

    function renderNewsReport(newsItems) {
        var newsTable = $("#newsTable tbody");
        newsTable.empty();

        newsItems.forEach(function (newsItem) {
            var row = $("<tr>");
            row.append($("<td>").text(newsItem.AgencyName));
            row.append($("<td>").text(newsItem.CategoryTitle));
            row.append($("<td>").text(newsItem.NewsTitle));
            row.append($("<td>").text(newsItem.ClickCount || '0'));
            newsTable.append(row);
        });
    };

    function renderPagination(totalPages, currentPage) {
        var pagination = $(".pagination");
        pagination.empty();

        for (var i = 1; i <= totalPages; i++) {
            var pageItem = $("<li>").addClass("page-item");
            var pageLink = $("<a>").addClass("page-link").attr("href", "#").text(i);
            if (i === currentPage) {
                pageItem.addClass("active");
            }
            pageItem.append(pageLink);
            pagination.append(pageItem);
        }
        $(".page-link").click(function (e) {
            e.preventDefault();
            var page = $(this).text();
            loadNewsReport(page);
        });
    }

    $('#bttnGenerateReport').click(function (event) {
        event.preventDefault();
        loadNewsReport(currentPage);
    });

    $(".sort-link").click(function (e) {
        e.preventDefault();
        var column = $(this).data("sortby");
        sortOrder = (sortOrder === "asc") ? "desc" : "asc";
        sortBy = column;
        loadNewsReport(currentPage);
    });

    $('#bttnGeneratePdf').on('click', function () {
        var startDate = $('#startDate').val();
        var endDate = $('#endDate').val();
        $.ajax({
            url: '/Report/GeneratePdf',
            type: 'GET',
            data: { startDate: startDate, endDate: endDate },
            dataType: 'json',
            success: function (response) {
                var report = `<h3>Click Count Report</h3>`;
                report += `<div><table id="reportTable">
            <tr>
                <th>Agency</th>
                <th>Category</th>
                <th>News Title</th>
                <th># of Click</th>
            </tr>`;

                for (var i = 0; i < response.data.length; i++) {
                    var news = response.data[i];
                    report += `<tr>
                    <td>${news.AgencyName}</td>
                    <td>${news.CategoryTitle}</td>
                    <td>${news.NewsTitle}</td>
                    <td>${news.ClickCount !== null ? news.ClickCount : 0}</td>
                </tr>`;
                }

                report += `</table></div>`;

                var reportElement = document.createElement('div');
                reportElement.innerHTML = report;

                html2pdf().from(reportElement).save('exported_report.pdf');
            },
            error: function (error) {
                console.log(error);
                alert('Export failed.');
            }
        });
    });

});