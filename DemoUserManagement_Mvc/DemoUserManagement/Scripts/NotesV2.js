$(document).ready(function () {
    var page = 1;
    var sortBy = "NoteId";
    var sortOrder = "asc";
    var objectId = $('#objectId').val();

    loadNotes(objectId, page, sortBy, sortOrder);

    function loadNotes(objectId, page, sortBy, sortOrder) {
        $.ajax({
            url: "/NotesV2/_NotesPartialV2",
            type: "GET",
            data: { objectId: objectId, page: page, sortBy: sortBy, sortOrder: sortOrder },
            success: function (response) {
                renderNotes(response.notes);
                renderPagination(response.totalPages, page);
            },
            error: function (xhr, status, error) {
                console.error("Error fetching notes:", error);
            }
        });
    }

    function renderNotes(notes) {
        var notesTable = $("#notesGrid tbody");
        notesTable.empty();

        notes.forEach(function (note) {
            var row = $("<tr>");
            row.append($("<td>").text(note.NoteId));
            row.append($("<td>").text(note.ObjectId));
            row.append($("<td>").text(note.ObjectType));
            row.append($("<td>").text(note.NoteData));
            row.append($("<td>").text(note.DateTimeAdded));
            notesTable.append(row);
        });
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

        //$(".page-link").click(function (e) {
        //    e.preventDefault();
        //    var page = $(this).text();
        //    loadNotes(page, pageSize);
        //});

        $(".sort-link").click(function (e) {
            e.preventDefault();
            var column = $(this).data("sortby");
            sortOrder = (sortOrder === "asc") ? "desc" : "asc";
            sortBy = column;
            var objectId = $('#objectId').val();
            loadNotes(objectId, currentPage, sortBy, sortOrder);
        });

        $(".pagination").on("click", ".page-link", function (e) {
            e.preventDefault();
            var page = $(this).text();
            var objectId = $('#objectId').val();
            loadNotes(objectId, page, sortBy, sortOrder);
        });
    }
});
