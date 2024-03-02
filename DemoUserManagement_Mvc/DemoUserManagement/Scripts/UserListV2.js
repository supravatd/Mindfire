$(document).ready(function () {
    var currentPage = 1;
    var pageSize = 5;
    var sortBy = "UserId";
    var sortOrder = "asc";

    loadUserList(currentPage, sortBy, sortOrder);

    function loadUserList(page, sortBy, sortOrder) {
        $.ajax({
            url: "/UserListV2/UserListV2",
            type: "GET",
            data: { page: page, sortBy: sortBy, sortOrder: sortOrder },
            success: function (response) {
                renderUserList(response);
                renderPagination(response.totalPages, page);
            },
            error: function (xhr, status, error) {
                console.error("Error fetching user list:", error);
            }
        });
    }

    function renderUserList(users) {
        var userListTable = $("#userTable tbody");
        userListTable.empty();

        if (Array.isArray(users.data)) {
            users.data.forEach(function (user) {
                var row = $("<tr>");
                row.append($("<td>").text(user.UserId));
                row.append($("<td>").text(user.FirstName));
                row.append($("<td>").text(user.Email));
                row.append($("<td>").text(formatDate(user.Dob)));
                row.append($("<td>").text(user.MobileNo));
                row.append($("<td>").text(user.Gender));
                row.append($("<td>").text(user.Hobbies));
                row.append($("<td>").html('<a href="/Uploads/' + user.FileGuid + '" class="btn btn-link" download="' + encodeURIComponent(user.FileOriginal) + '">' + user.FileOriginal + '</a>'));
                row.append($("<td>").html('<a href="/UserFormV2/EditUserV2/' + user.UserId + '">Edit</a>'));

                userListTable.append(row);
            });
        } else {
            console.error("Response userList is not an array:", response.userList);
        }
    }

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
            loadNotes(page, pageSize);
        });
    }

    function formatDate(ticks) {
        var date = new Date(parseInt(ticks.substr(6)));
        return date.toLocaleDateString();
    }


    $(".sort-link").click(function (e) {
        e.preventDefault();
        var column = $(this).data("sortby");
        sortOrder = (sortOrder === "asc") ? "desc" : "asc";
        sortBy = column;
        loadUserList(currentPage, sortBy, sortOrder);
    });

    $(".pagination").on("click", ".page-link", function (e) {
        e.preventDefault();
        var page = $(this).text();
        loadUserList(page, sortBy, sortOrder);
    });
});
