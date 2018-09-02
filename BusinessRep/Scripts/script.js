

jQuery(function($) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/Account/GetProfilePhoto",
        data: "{}",
        dataType: "json",
        success: function(data) {


            $("#avatar").attr('src', 'data:image/jpg;base64,' + data.base64imgage);
            

        },
        error: function() {

        }

    });

});