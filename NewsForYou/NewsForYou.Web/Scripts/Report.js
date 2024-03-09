$(document).ready(function () {
    var currentPage = 1;
    var pageSize = 5;
    var sortBy = "AgencyName";
    var sortOrder = "asc";

    function loadNewsReport(page, sortBy, sortOrder) {
        $.ajax({
            url: '/Report/ClickCountReport',
            type: 'POST',
            data: {
                startDate: $('#startDate').val(),
                endDate: $('#endDate').val(),
                page: page,
                sortBy: sortBy,
                pageSize: pageSize
            },
            success: function (response) {
                renderNewsReport(response.data);
                renderPagination(response.totalPages, page);
                allData = response.data;
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
            loadNewsReport(page, sortBy, sortOrder);
        });
    }

    $('#bttnGenerateReport').click(function (event) {
        event.preventDefault();
        loadNewsReport(currentPage, sortBy, sortOrder);
    });

    $(".sort-link").click(function (e) {
        e.preventDefault();
        var column = $(this).data("sortby");
        sortOrder = (sortOrder === "asc") ? "desc" : "asc";
        sortBy = column;
        loadNewsReport(currentPage, sortBy, sortOrder);
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
                var report = `<h3 style="text-align: center; color: #333;">Click Count Report</h3>`;
                report += `<div><table id="reportTable" style="width: 100%; border-collapse: collapse; margin-top: 20px;">
            <tr style="background-color: #f2f2f2;">
                <th style="border: 1px solid #ddd; padding: 8px;">Agency</th>
                <th style="border: 1px solid #ddd; padding: 8px;">Category</th>
                <th style="border: 1px solid #ddd; padding: 8px;">News Title</th>
                <th style="border: 1px solid #ddd; padding: 8px;"># of Click</th>
            </tr>`;

                for (var i = 0; i < response.data.length; i++) {
                    var news = response.data[i];
                    report += `<tr style="border: 1px solid #ddd; padding: 8px;">
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