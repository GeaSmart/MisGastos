// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showModal(url, title) {
    $.ajax(
        {
            type: "GET",
            url: url,
            success: function (response) {
                $("#form-modal .modal-body").html(response);
                $("#form-modal .modal-title").html(title);
                $("#form-modal").modal('show');
            }
        }
    )
}

function jQueryAjaxPost(form) {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.isValid) {
                    $("#view-all").html(response.html);
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    $("#form-modal").modal('hide');

                    //notify notification
                    $.notify('Datos registrados', { globalPosition: 'top-center', className: 'success' });
                }
                else {
                    $("#form-modal .modal-body").html(response.html);
                }
            },
            error: function (error) {
                console.log(error)
            }
        })
    }
    catch (e) {
        console.log(e);
    }
    return false;
}

