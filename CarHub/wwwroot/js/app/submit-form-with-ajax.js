$(document).ready(function () {

    var options = {
        target: '#validation-errors',   // target element(s) to be updated with server response
        error: handleError,  // post-submit callback
        success: handleSuccess,
        timeout:   60000
    };

    // post-submit callback
    function handleError(responseText, statusText, xhr, $form) {
        const response = responseText.responseJSON;
        if (!response.success) {
            const errors = response.errors;
            $("#validation-errors ul").empty();
            errors.forEach(error => {
                const fieldErrors = error.errors;
                fieldErrors.forEach(fieldError => {
                    $("#validation-errors ul").append(`<li>${fieldError.errorMessage}</li>`);
                });

            });
        }
    }

    function handleSuccess(responseText, statusText, xhr, $form) {
        let inventoryId = responseText.inventoryId;
        uppy.setMeta({ InventoryId: inventoryId })
        uppy.upload().then((result) => {
            console.info('Successful uploads:', result.successful)
            if (result.successful) {
                window.location.href = '/Admin/Index'
            }

            if (result.failed.length > 0) {
                console.error('Errors:')
                result.failed.forEach((file) => {
                    console.error(file.error)
                })
            }
        })
    }

    // bind to the form's submit event
    $('#manage-car-form').submit(function (e) {
        //validate fields
        if (uppy.getFiles().length === 0) {
            $('#upload-image-validation').text('You have to select at least 1 file')
            return false
        }
        // inside event callbacks 'this' is the DOM element so we first
        // wrap it in a jQuery object and then invoke ajaxSubmit
        $(this).ajaxSubmit(options);

        // !!! Important !!!
        // always return false to prevent standard browser submit and page navigation
        return false;
    });

});
