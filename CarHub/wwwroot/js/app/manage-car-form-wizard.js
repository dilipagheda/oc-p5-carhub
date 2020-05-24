$(document).ready(function () {
    let stepperSettings = {
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        stepsOrientation: "vertical",
        labels: {
            cancel: "Cancel",
            current: "current step:",
            pagination: "Pagination",
            finish: "Submit",
            next: "Next",
            previous: "Previous",
            loading: "Loading ..."
        },
        onFinished: function (event, currentIndex) {
            $("#manage-car-form").submit();
        },

        onStepChanging: function (event, currentIndex, priorIndex) {
            console.log("currentIndex:" + currentIndex);
            console.log("priorIndex:" + priorIndex)
            console.log(event);
            var validator = $("#manage-car-form").validate({
                rules: {
                    CarMakeId: {
                        required: function (element) {
                            return $(element).children("option").filter(":selected").text() !== 'Add New..';
                        }
                    },
                    NewCarMakeName: {
                        required: function (element) {
                            return ($('CarMakeId').children("option").filter(":selected").text() === 'Add New..' && $(element).val().length === 0)
                        }
                    },
                    CarModelId: {
                        required: function (element) {
                            return $(element).children("option").filter(":selected").text() !== 'Add New..';
                        }
                    },
                    NewCarModelName: {
                        required: function (element) {
                            return ($('CarModelId').children("option").filter(":selected").text() === 'Add New..' && $(element).val().length === 0)
                        }
                    },
                    TrimId: {
                        required: function (element) {
                            return $(element).children("option").filter(":selected").text() !== 'Add New..';
                        }
                    },
                    NewTrimName: {
                        required: function (element) {
                            return ($('TrimId').children("option").filter(":selected").text() === 'Add New..' && $(element).val().length === 0)
                        }
                    },
                    Year: {
                        required: true
                    },
                    Kms: {
                        required: true,
                        min: 1,
                        max: 500000,
                    },
                    RegoNumber: {
                        required: true,
                    },
                    RegoExpiryDate: {
                        required: true
                    },
                    TransmissionType: {
                        required: true,
                    },
                    ColorId: {
                        required: function (element) {
                            return $(element).children("option").filter(":selected").text() !== 'Add New..';
                        }
                    },
                    NewColorName: {
                        required: function (element) {
                            return ($(ColorId).children("option").filter(":selected").text() === 'Add New..' && $(element).val().length === 0)
                        }
                    },
                    BodyTypeId: {
                        required: function (element) {
                            return $(element).children("option").filter(":selected").text() !== 'Add New..';
                        }
                    },
                    NewBodyTypeName: {
                        required: function (element) {
                            return ($(BodyTypeId).children("option").filter(":selected").text() === 'Add New..' && $(element).val().length === 0)
                        }
                    },
                    NoOfSeats: {
                        required: true,
                        min: 1,
                        max: 10,
                        
                    },
                    NoOfDoors: {
                        required: true,
                        min: 1,
                        max: 10,
                        
                    },
                    NoOfCylinders: {
                        required: true,
                        min: 1,
                        max: 10,
                        
                    },
                    DriveTypeId: {
                        required: function (element) {
                            return $(element).children("option").filter(":selected").text() !== 'Add New..';
                        }
                    },
                    NewDriveTypeName: {
                        required: function (element) {
                            return ($("#DriveTypeId").children("option").filter(":selected").text() === 'Add New..' && $(element).val().length === 0)
                        }
                    },
                    FuelTypeId: {
                        required: function (element) {
                            return $(element).children("option").filter(":selected").text() !== 'Add New..';
                        }
                    },
                    NewFuelTypeName: {
                        required: function (element) {
                            return ($("#FuelTypeId").children("option").filter(":selected").text() === 'Add New..' && $(element).val().length === 0)
                        }
                    },
                    Description: {
                        required: true,
                        minlength: 1,
                        maxlength: 1000
                    },
                    PurchaseDate: {
                        required: true,
                        
                    },
                    PurchasePrice: {
                        required: true,
                        min: 1,
                        max:100000
                        
                    },
                    PurchaseTypeId: {
                        required: function (element) {
                            return $(element).children("option").filter(":selected").text() !== 'Add New..';
                        }
                    },
                    NewPurchaseTypeName: {
                        required: function (element) {
                            return ($("#PurchaseTypeId").children("option").filter(":selected").text() === 'Add New..' && $(element).val().length === 0)
                        }
                    },
                    LotDate: {
                        required: true,
                        
                    },
                    SaleDate: {
                        required: false,
                        
                    },
                    SalePrice: {
                        required: false,
                        min: 1,
                        
                    },
                    InventoryStatusId: {
                        required: true
                    },
                    RepairDescription: {
                        required: false,
                        maxlength:1000
                    },
                    RepairCost: {
                        required: false,
                        max:30000
                    }
                }
            });

            switch (currentIndex) {
                case 0:
                    let step1 = validator.element("#CarMakeId") &&
                        validator.element("#NewCarMakeName") &&
                        validator.element("#CarModelId") &&
                        validator.element("#NewCarModelName") &&
                        validator.element("#TrimId") &&
                        validator.element("#NewTrimName");
                    return step1;
                case 1:
                    let step2 = validator.element("#Year") &&
                        validator.element("#Kms") &&
                        validator.element("#RegoNumber") &&
                        validator.element("#RegoExpiryDate");
                    return step2;
                case 2:
                    let step3 = validator.element("#TransmissionType") &&
                        validator.element("#ColorId") &&
                        validator.element("#NewColorName") &&
                        validator.element("#BodyTypeId") &&
                        validator.element("#NewBodyTypeName") &&
                        validator.element("#NoOfSeats") &&
                        validator.element("#NoOfDoors") &&
                        validator.element("#NoOfCylinders") &&
                        validator.element("#DriveTypeId") &&
                        validator.element("#NewDriveTypeName") &&
                        validator.element("#FuelTypeId") &&
                        validator.element("#NewFuelTypeName");
                    return step3;
                case 3:
                    let step4 = validator.element("#Description") &&
                        validator.element("#PurchaseDate") &&
                        validator.element("#PurchasePrice") &&
                        validator.element("#PurchaseTypeId") &&
                        validator.element("#NewPurchaseTypeName") &&
                        validator.element("#LotDate") &&
                        validator.element("#SaleDate") &&
                        validator.element("#SalePrice") &&
                        validator.element("#InventoryStatusId");
                    return step4;
                case 4:
                    let step5 = validator.element("#RepairDescription") &&
                        validator.element("#RepairCost");
                    return step5;
                default:
                    return true;
            }
        }
    }

    $("#manage-car-form-wizard").steps(stepperSettings);
});