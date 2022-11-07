$('#upload-btn').click((event) => {
    event.preventDefault();

    $.post('addImage/upload',
        {
            selectedFamilyMemberIds: $('.bootstrap-select').find('select').val()
        },
        () => location.reload(true)
    );
});