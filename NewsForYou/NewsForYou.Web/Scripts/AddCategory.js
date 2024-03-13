function populateDropdowns() {
    $.ajax({
        type: "POST",
        url: "/AddCategory/GetAgency",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var ddlAgency = $('#ddlAgency');
            ddlAgency.empty();
            ddlAgency.append($('<option></option>').val('').text('Select Agency'));
            $.each(response.d, function (key, value) {
                ddlAgency.append($("<option></option>").val(value.AgencyId).text(value.AgencyName));
            });
        },
        failure: function (response) {
            alert(response.d);
        }
    });

    $.ajax({
        type: "POST",
        url: "/AddCategory/GetCategory",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var ddlCategory = $('.ddlCategory');
            ddlCategory.empty();
            ddlCategory.append($('<option></option>').val('').text('Categories'));
            $.each(response.d, function (key, value) {
                ddlCategory.append($("<option></option>").val(value.CategoryId).text(value.CategoryTitle));
            });
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

$(document).ready(function () {
    populateDropdowns();

    $('#bttnAddAgency').click(function (e) {
        e.preventDefault();
        var agencyName = $('#txtAgencyName').val();
        var agencyLogoPath = $('#txtAgencyLogo').val();
        $.ajax({
            url: '/AddCategory/AddAgency',
            type: 'POST',
            data: {
                agencyName: agencyName,
                agencyFeedUrl: agencyLogoPath
            },
            success: function (response) {
                if (response.success) {
                    if (response.agencyId > 0) {
                        alert('Agency added successfully');
                        $('#txtAgencyName').val('');
                        $('#txtAgencyLogo').val('');
                        populateDropdowns();
                    }
                    else {
                        alert('Agency Not Added');
                    }
                } else {
                    alert('Error adding agency:', response.error);
                }
            },
            error: function (xhr, status, error) {
                console.error('Error adding agency:', error);
            }
        });
    });

    $('#bttnAddCategory').click(function (e) {
        e.preventDefault();
        var categoryTitle = $('#txtCategoryName').val();
        $.ajax({
            url: '/AddCategory/AddNewCategory',
            type: 'POST',
            data: { categoryTitle: categoryTitle },
            success: function (response) {
                if (response.success) {
                    if (response.categoryId > 0) {
                        alert("Category Added.");
                        $('#txtCategoryName').val('');
                        populateDropdowns();
                    }
                    else {
                        alert('Category Not Added');
                    }
                }
                else {
                    alert('Error adding category:', response.error);
                }
            },
            error: function (xhr, status, error) {
                console.error('Error adding category:', error);
            }
        });
    });

    $('#bttnAddFeedUrl').click(function () {
        var feedUrl = $('#txtFeedUrl').val();
        var agencyId = $('#ddlAgency').val();
        var categoryId = $('#ddlCategory').val();

        $.ajax({
            url: '/AddCategory/AddAgencyFeedUrl',
            type: 'POST',
            data: {
                feedUrl: feedUrl,
                agencyId: agencyId,
                categoryId: categoryId
            },
            success: function (response) {
                if (response.success) {
                    if (response.agencyFeedId > 0) {
                        alert('Feed URL added successfully');
                        $('#txtFeedUrl').val('');
                    }
                    else {
                        alert('Feed URL Not Saved');
                    }

                } else {
                    alert('Error adding feed URL:', response.error);
                }
            },
            error: function (xhr, status, error) {
                alert('Error adding feed URL:', error);
            }
        });
    });

    $('#bttnDeleteNews').click(function () {
        var confirmDelete = confirm("Are you sure you want to delete all news?");
        if (confirmDelete) {
            $.ajax({
                url: '/AddCategory/DeleteAllNews',
                type: 'POST',
                success: function (response) {
                    alert("All News Deleted.");
                },
                error: function (xhr, status, error) {
                    console.error('Error deleting news:', error);
                }
            });
        }
    });
});