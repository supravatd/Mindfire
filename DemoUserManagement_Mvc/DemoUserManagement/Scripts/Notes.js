$(document).ready(function () {
    $('#notesGrid').on('click', 'th a', function (e) {
        e.preventDefault();

        var sortBy = $(this).data('sortby');
        $(this).toggleClass('asc desc');
        $('.notes-sort-link').removeClass('active');
        $(this).addClass('active');

        var sortOrder = $(this).hasClass('asc') ? 'asc' : 'desc';
        var objectId = parseInt($("#objectId").val());

        $.ajax({
            url: '/Notes/_NotesPartial',
            type: 'GET',
            data: { objectId: objectId, page: 1, sortBy: sortBy, sortOrder: sortOrder },
            success: function (result) {
                $('#notesGrid tbody').html($(result).find('tbody').html());
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });
    $('#notesGrid').on('click', '.pagination a', function (e) {
        e.preventDefault();

        var page = $(this).text();
        var sortBy = $('.notes-sort-link.active').data('sortby');
        var sortOrder = $('.notes-sort-link.active').hasClass('asc') ? 'asc' : 'desc';
        var objectId = parseInt($("#ObjectId").val());

        $.ajax({
            url: '/Notes/_NotesPartial',
            type: 'GET',
            data: { objectId: objectId, page: page, sortBy: sortBy, sortOrder: sortOrder },
            success: function (result) {
                $('#notesGrid tbody').html($(result).find('tbody').html());
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });
});

function addNotes() {
    var noteData = $('#txtNotes').val();
    var objectId = parseInt($("#ObjectId").val());
    var objectType = parseInt($("#ObjectType").val());

    $.ajax({
        type: "POST",
        url: "/Notes/AddNotes",
        data: JSON.stringify({ noteData: noteData, objectId: objectId, objectType: objectType }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Notes Added");
            var sortBy = $('.sort-link.active').data('sortby');
            var sortOrder = $('.sort-link.active').hasClass('asc') ? 'asc' : 'desc';
            $.ajax({
                url: '/Notes/_NotesPartial',
                type: 'GET',
                data: { objectId: objectId, page: 1, sortBy: sortBy, sortOrder: sortOrder },
                success: function (result) {
                    $('#NotesGrid').html(result);
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                }
            });
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}


