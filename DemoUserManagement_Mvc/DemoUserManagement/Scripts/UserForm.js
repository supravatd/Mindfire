$(document).ready(function () {
    function populateStates(countryId, targetDropdownId) {
        $.ajax({
            url: '/UserForm/GetStatesByCountry',
            type: 'GET',
            data: { countryId: countryId },
            success: function (result) {
                $('#' + targetDropdownId).html('');
                $.each(result, function (index, item) {
                    $('#' + targetDropdownId).append($('<option>', {
                        value: item.Value,
                        text: item.Text
                    }));
                });
            }
        });
    }
    
    $('#presentAddressCountry, #permanentAddressCountry').change(function () {
        var countryId = $(this).val();
        var targetDropdownId = $(this).attr('id') === 'presentAddressCountry' ? 'presentAddressState' : 'permanentAddressState';
        populateStates(countryId, targetDropdownId);
    });

    var isEditMode = $('#bttnUpdate').length > 0;

    if (isEditMode) {
        var presentCountryId = $('#presentAddressCountry').val();
        var permanentCountryId = $('#permanentAddressCountry').val();

        populateStates(presentCountryId, 'presentAddressState');

        populateStates(permanentCountryId, 'permanentAddressState');

        var presentStateId = $('#PresentAddress_StateId').val();
        if ($('#presentAddressState option[value="' + presentStateId + '"]').length > 0) {
            $('#presentAddressState').val(presentStateId);
        }

        var permanentStateId = $('#PermanentAddress_StateId').val();
        $('#permanentAddressState').val(permanentStateId);
    }
});


function SameAsPresent_Check() {
    var isSameAsPresent = $('#chkSameAsPresent').is(':checked');
    if (isSameAsPresent) {

        $('#PermanentAddress_DoorNo').val($('#PresentAddress_DoorNo').val());
        $('#PermanentAddress_Street').val($('#PresentAddress_Street').val());
        $('#PermanentAddress_City').val($('#PresentAddress_City').val());
        $('#PermanentAddress_PostalCode').val($('#PresentAddress_PostalCode').val());
        const presentAddCountry = $('#presentAddressCountry').val();
        const presentAddState = $('#presentAddressState').val();

        const presentAddCountryText = $('#presentAddressCountry option:selected').text();

        const presentAddStateText = $('#presentAddressState option:selected').text();

        const country = $("#permanentAddressCountry");
        country.html(`<option value="${presentAddCountry}">${presentAddCountryText}</option>`);
        country.val(presentAddCountry);

        const state = $("#permanentAddressState");
        state.html(`<option value="${presentAddState}">${presentAddStateText}</option>`);
        state.val(presentAddState);

    }
    else {
        // Clear permanent address fields
        $('#PermanentAddress_DoorNo').val('');
        $('#PermanentAddress_Street').val('');
        $('#PermanentAddress_City').val('');
        $('#PermanentAddress_PostalCode').val('');
        $('#permanentAddressCountry').val('');
        $('#permanentAddressState').val('').trigger('change');
    }
}