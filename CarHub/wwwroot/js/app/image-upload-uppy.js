$(document).ready(function () {

    //UPPY START////

    function onBeforeUploadHandler(files) {
        if (Object.keys(files).length <= 0) {
            // log to console
            uppy.log(`Aborting upload because only ${Object.keys(files).length} files were selected`)
            // show error message to the user
            uppy.info(`You have to select at least 1 file`, 'error', 500)
            $('#upload-image-validation').text('You have to select at least 1 file')
            return false
        }
    }

    var Core = Uppy.Core
    var Dashboard = Uppy.Dashboard
    var XHRUpload = Uppy.XHRUpload
    var uppy = Core({
        id: 'uppy',
        debug: true,
        autoProceed: false,
        restrictions: {
            maxFileSize: 1000000,
            maxNumberOfFiles: 5,
            minNumberOfFiles: 1,
            allowedFileTypes: ['image/*']
        },
        onBeforeUpload: onBeforeUploadHandler
    })

    uppy.use(Dashboard, {
        trigger: '.UppyModalOpenerBtn',
        inline: true,
        target: '.DashboardContainer',
        replaceTargetContent: true,
        showProgressDetails: true,
        note: 'Images only, 1-5 files, up to 1 MB',
        height: 470,
        metaFields: [
            { id: 'name', name: 'Name', placeholder: 'file name' },
        ],
        browserBackButtonClose: true,
        hideUploadButton: true
    })

    uppy.use(XHRUpload, {
        endpoint: '@Url.Action("UploadFile", "Admin")',
        method: 'post',
        formData: true,
        fieldName: 'File',
        metaFields: null
    })

    var options = {
        target: '#validation-errors',   // target element(s) to be updated with server response
        error: handleError,  // post-submit callback
        success: handleSuccess
        // other available options:
        //url:       url         // override for form's 'action' attribute
        //type:      type        // 'get' or 'post', override for form's 'method' attribute
        //dataType:  null        // 'xml', 'script', or 'json' (expected server response type)
        //clearForm: true        // clear all form fields after successful submit
        //resetForm: true        // reset the form after successful submit

        // $.ajax options can be used here too, for example:
        //timeout:   3000
    };

    // post-submit callback
    function handleError(responseText, statusText, xhr, $form) {

        console.log("dilip error");
        console.log(responseText.responseJSON);

        const response = responseText.responseJSON;
        if (!response.success) {
            const errors = response.errors;
            errors.forEach(error => {
                const fieldErrors = error.errors;
                fieldErrors.forEach(fieldError => {
                    $("#validation-errors ul").append(`<li>${fieldError.errorMessage}</li>`);
                });

            });
        }
    }

    function handleSuccess(responseText, statusText, xhr, $form) {

        console.log("dilip success");
        console.log(responseText);
        let inventoryId = responseText.inventoryId;
        uppy.setMeta({ InventoryId: inventoryId })
        uppy.upload().then((result) => {
            console.info('Successful uploads:', result.successful)
            if (result.successful) {
                window.location.href = '@Url.Action("Index", "Admin")'
            }

            if (result.failed.length > 0) {
                console.error('Errors:')
                result.failed.forEach((file) => {
                    console.error(file.error)
                })
            }
        })
    }

    //$('#manage-car-form').ajaxForm(options);

    // bind to the form's submit event
    $('#manage-car-form').submit(function () {

        console.log("dilip hahahaha");
        console.log(uppy.getFiles());

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

    //$('#manage-car-form').ajaxForm(function() {

    //});

    uppy.on('complete', result => {
        console.log('successful files:', result.successful)
        console.log('failed files:', result.failed)
    });





    //UPPY END////
});
