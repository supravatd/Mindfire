$(document).ready(function () {
    var currentPage = 1;
    var pageSize = 3;
    var objectId = $('#objectId').val();

    loadNotes(currentPage, pageSize);

    function loadNotes(objectId, page, size) {
        $.ajax({
            url: "/NotesV2/_NotesPartialV2",
            type: "GET",
            data: { objectId: objectId, page: page, pageSize: size },
            success: function (response) {
                renderNotes(response.notes);
                renderPagination(response.totalPages, page);
            },
            error: function (xhr, status, error) {
                console.error("Error fetching notes:", error);
            }
        });
    }

    // Function to render notes table
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

    // Function to render pagination
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

        // Add click event listener to pagination links
        $(".page-link").click(function (e) {
            e.preventDefault();
            var page = $(this).text();
            loadNotes(page, pageSize);
        });
    }
});
