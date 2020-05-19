$(document).ready(function () {
    /////STEPPER START//////
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
            alert("onFinished")
            $("#manage-car-form").submit();
        },

        onStepChanging: function (event, currentIndex, priorIndex) {
            console.log("currentIndex:" + currentIndex);
            console.log("priorIndex:" + priorIndex)
            var validator = $("#manage-car-form").validate({
                rules: {
                    CarMakeId: {
                        required: function (element) {
                            return $(element).val() !== 'add-new';
                        }
                    },
                    CarMakeName: {
                        required: function (element) {
                            return ($("#CarMakeId").val() === 'add-new' && $(element).val().length === 0)
                        }
                    },
                    CarModelId: {
                        required: function (element) {
                            return $(element).val() !== 'add-new';
                        }
                    },
                    CarModelName: {
                        required: function (element) {
                            return ($("#CarModelId").val() === 'add-new' && $(element).val().length === 0)
                        }
                    },
                    TrimId: {
                        required: function (element) {
                            return $(element).val() !== 'add-new';
                        }
                    },
                    TrimName: {
                        required: function (element) {
                            return ($("#TrimId").val() === 'add-new' && $(element).val().length === 0)
                        }
                    },
                    Year: {
                        required: function (element) {
                            return $(element).val() !== 'add-new';
                        }
                    },
                    YearName: {
                        required: function (element) {
                            return ($("#Year").val() === 'add-new' && $(element).val().length === 0)
                        },
                        maxlength: 4,
                        minlength:4
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
                            return $(element).val() !== 'add-new';
                        }
                    },
                    ColorName: {
                        required: function (element) {
                            return ($("#ColorId").val() === 'add-new' && $(element).val().length === 0)
                        }
                    },
                    BodyTypeId: {
                        required: function (element) {
                            return $(element).val() !== 'add-new';
                        }
                    },
                    BodyTypeName: {
                        required: function (element) {
                            return ($("#BodyTypeId").val() === 'add-new' && $(element).val().length === 0)
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
                            return $(element).val() !== 'add-new';
                        }
                    },
                    DriveTypeName: {
                        required: function (element) {
                            return ($("#BodyTypeId").val() === 'add-new' && $(element).val().length === 0)
                        }
                    },
                    FuelTypeId: {
                        required: function (element) {
                            return $(element).val() !== 'add-new';
                        }
                    },
                    FuelTypeName: {
                        required: function (element) {
                            return ($("#BodyTypeId").val() === 'add-new' && $(element).val().length === 0)
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
                            return $(element).val() !== 'add-new';
                        }
                    },
                    PurchaseTypeName: {
                        required: function (element) {
                            return ($("#PurchaseTypeId").val() === 'add-new' && $(element).val().length === 0)
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
            let step1 = validator.element("#CarMakeId") &&
                validator.element("#CarMakeName") &&
                validator.element("#CarModelId") &&
                validator.element("#CarModelName") &&
                validator.element("#TrimId") &&
                validator.element("#TrimName");

            let step2 = validator.element("#Year") &&
                validator.element("#YearName") &&
                validator.element("#Kms") &&
                validator.element("#RegoNumber") &&
                validator.element("#RegoExpiryDate");

            let step3 = validator.element("#TransmissionType") &&
                validator.element("#ColorId") &&
                validator.element("#ColorName") &&
                validator.element("#BodyTypeId") &&
                validator.element("#BodyTypeName") &&
                validator.element("#NoOfSeats") &&
                validator.element("#NoOfDoors") &&
                validator.element("#NoOfCylinders") &&
                validator.element("#DriveTypeId") &&
                validator.element("#DriveTypeName") &&
                validator.element("#FuelTypeId") &&
                validator.element("#FuelTypeName");

            let step4 = validator.element("#Description") &&
                validator.element("#PurchaseDate") &&
                validator.element("#PurchasePrice") &&
                validator.element("#PurchaseTypeId") &&
                validator.element("#PurchaseTypeName") &&
                validator.element("#LotDate") &&
                validator.element("#SaleDate") &&
                validator.element("#SalePrice") &&
                validator.element("#InventoryStatusId");

            let step5 = validator.element("#RepairDescription") &&
                validator.element("#RepairCost");

            switch (currentIndex) {
                case 0:
                    return step1;
                case 1:
                    return step2;
                case 2:
                    return step3;
                case 3:
                    return step4;
                case 4:
                    return step5;
                default:
                    return true;
            }
        }
    }

    $("#manage-car-form-wizard").steps(stepperSettings);
    /////STEPPER END//////
});