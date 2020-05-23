$(document).ready(function () {

    $("#RegoExpiryDate").datepicker({
        appendText: "(dd-mm-yyyy)",
        dateFormat: "dd-mm-yy"
    });

    $("#PurchaseDate").datepicker({
        appendText: "(dd-mm-yyyy)",
        dateFormat: "dd-mm-yy"
    });

    $("#LotDate").datepicker({
        appendText: "(dd-mm-yyyy)",
        dateFormat: "dd-mm-yy"
    });

    $("#SaleDate").datepicker({
        appendText: "(dd-mm-yyyy)",
        dateFormat: "dd-mm-yy"
    });

    function resetTrim() {
        $("#TrimId").empty();
        $("#TrimId").append($('<option>', { value: "",text: 'Select Trim' }));
        $("#TrimId").append($('<option>', { value: -1,text: 'Add New..' }));
    }

    function resetModel() {
        $("#CarModelId").empty();
        $("#CarModelId").append($('<option>', { value: "", text: 'Select Model' }));
        $("#CarModelId").append($('<option>', { value: -1,text: 'Add New..' }));
    }

    $("#CarMakeId").change(function () {
        var selectedText = $(this).find("option:selected").text();
        resetModel();
        resetTrim();
        if (selectedText.includes('Select')) {
            return;
        }
        if (selectedText === "Add New..") {
            $(".carmake-other").removeClass("other-hide");
            $(".carmake-other").addClass("other-show");
            return;
        } else {
            $(".carmake-other").addClass("other-hide");
            $(".carmake-other").removeClass("other-show");

            var selectedValue = $(this).val();
            console.log(selectedValue);
            $.ajax({
                type: 'GET',
                url: '/Home/CarModelsByMake' + '/' + selectedValue,
                success: function (result) {
                    result.forEach(item => {
                        $("#CarModelId").append($('<option>', { value: item.id, text: item.carModelName }));
                    });
                    //$('#CarModelId').selectpicker('refresh');
                }
            });
        }
    });

    $("#CarModelId").change(function () {

        var selectedText = $(this).find("option:selected").text();
        resetTrim();

        if (selectedText === "Add New..") {
            $(".carmodel-other").removeClass("other-hide");
            $(".carmodel-other").addClass("other-show");
            return;
        } else {
            $(".carmodel-other").addClass("other-hide");
            $(".carmodel-other").removeClass("other-show");
            var selectedValue = $(this).val();
            console.log(selectedValue);
            $.ajax({
                type: 'GET',
                url: '/Home/TrimsByModel' + '?modelId=' + selectedValue,
                success: function (result) {
                    result.forEach(item => {
                        $("#TrimId").append($('<option>', { value: item.id, text: item.trimName }));
                    });
                    //$('#TrimId').selectpicker('refresh');
                }
            });
        }
    });

    $("#TrimId").change(function () {
        var selectedText = $(this).find("option:selected").text();

        if (selectedText === "Add New..") {
            $(".trim-other").removeClass("other-hide");
            $(".trim-other").addClass("other-show");
            return;
        } else {
            $(".trim-other").addClass("other-hide");
            $(".trim-other").removeClass("other-show");
            return;
        }
    });

    $("#DriveTypeId").change(function () {
        var selectedText = $(this).find("option:selected").text();

        if (selectedText === "Add New..") {
            $(".drivetype-other").removeClass("other-hide");
            $(".drivetype-other").addClass("other-show");
            return;
        } else {
            $(".drivetype-other").addClass("other-hide");
            $(".drivetype-other").removeClass("other-show");
            return;
        }
    });

    $("#FuelTypeId").change(function () {
        var selectedText = $(this).find("option:selected").text();

        if (selectedText === "Add New..") {
            $(".fueltype-other").removeClass("other-hide");
            $(".fueltype-other").addClass("other-show");
            return;
        } else {
            $(".fueltype-other").addClass("other-hide");
            $(".fueltype-other").removeClass("other-show");
            return;
        }
    });

    $("#PurchaseTypeId").change(function () {
        var selectedText = $(this).find("option:selected").text();

        if (selectedText === "Add New..") {
            $(".purchasetype-other").removeClass("other-hide");
            $(".purchasetype-other").addClass("other-show");
            return;
        } else {
            $(".purchasetype-other").addClass("other-hide");
            $(".purchasetype-other").removeClass("other-show");
            return;
        }
    });

    $("#ColorId").change(function () {
        var selectedText = $(this).find("option:selected").text();

        if (selectedText === "Add New..") {
            $(".color-other").removeClass("other-hide");
            $(".color-other").addClass("other-show");
            return;
        } else {
            $(".color-other").addClass("other-hide");
            $(".color-other").removeClass("other-show");
            return;
        }
    });

    $("#BodyTypeId").change(function () {
        var selectedText = $(this).find("option:selected").text();

        if (selectedText === "Add New..") {
            $(".bodytype-other").removeClass("other-hide");
            $(".bodytype-other").addClass("other-show");
            return;
        } else {
            $(".bodytype-other").addClass("other-hide");
            $(".bodytype-other").removeClass("other-show");
            return;
        }
    });
});