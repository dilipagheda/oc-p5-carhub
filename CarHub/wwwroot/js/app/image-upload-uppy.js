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
        endpoint: '/Admin/UploadFile',
        method: 'post',
        formData: true,
        fieldName: 'File',
        metaFields: null
    })

    uppy.on('complete', result => {
        console.log('successful files:', result.successful)
        console.log('failed files:', result.failed)
    });
    //UPPY END////
    //uppy.getPlugin('Url')
    //    .addFile('uploads/img/f9b615838fcc4972b5fcb2a5ebb9dd05.jpg')

    if (allImageData) {
        allImageData.forEach(image => {
            fetch(`/uploads/img/${image}`)
                .then((response) => response.blob()) // returns a Blob
                .then((blob) => {
                    uppy.addFile({
                        name: `${image}`,
                        type: blob.type,
                        data: blob // changed blob -> data
                    })
                })
        })
    }
});
