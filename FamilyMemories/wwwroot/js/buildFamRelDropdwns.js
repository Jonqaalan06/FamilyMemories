$('html').click((event) => {
    let selectedFamilyMemberIds = JSON.stringify($('.bootstrap-select').find('select').val());
    $('#FamMemberIds').val(selectedFamilyMemberIds)
});