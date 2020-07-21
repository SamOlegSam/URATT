// Нажатие вкладки Поддержка в модальном окне //

function support(ID) {
    $.ajax({
        url: "/Home/support/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//----------------------------------------------------//
//-------Добавление водителя--------------//
function AddDriver(ID) {
    $.ajax({
        url: "/Home/AddDriver/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//Сохранение добавления водителя//

function DriverAddSave(TabNumber, LastName, FirstName, MiddleName, dateroj, MobPhone, GorPhone, dateMed, Fil, Podrazd, Dolj, Class, IDNumber, Seria, Number, Propiska, Address, Vidan, SrokD, NumberVod, SrokDVodUd, NumberVoen, Zvanie, A, B, C, D, E)
{

    var isValid = true;

    if ($('#TabNumber').val() == "") {
        $('#TabNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TabNumber').css('border-color', 'lightgrey');
    }

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }

    if ($('#dateroj').val() == "") {
        $('#dateroj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#dateroj').css('border-color', 'lightgrey');
    }

    if ($('#MobPhone').val() == "") {
        $('#MobPhone').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MobPhone').css('border-color', 'lightgrey');
    }

    if ($('#GorPhone').val() == "") {
        $('#GorPhone').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#GorPhone').css('border-color', 'lightgrey');
    }

    if ($('#dateMed').val() == "") {
        $('#dateMed').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#dateMed').css('border-color', 'lightgrey');
    }

    if ($('#Fil').val() == "") {
        $('#Fil').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Fil').css('border-color', 'lightgrey');
    }


    if ($('#IDNumber').val() == "") {
        $('#IDNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#IDNumber').css('border-color', 'lightgrey');
    }

    if ($('#Seria').val() == "") {
        $('#Seria').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Seria').css('border-color', 'lightgrey');
    }

    if ($('#Number').val() == "") {
        $('#Number').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Number').css('border-color', 'lightgrey');
    }

    if ($('#Propiska').val() == "") {
        $('#Propiska').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Propiska').css('border-color', 'lightgrey');
    }

    if ($('#Address').val() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }

    if ($('#Vidan').val() == "") {
        $('#Vidan').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Vidan').css('border-color', 'lightgrey');
    }

    if ($('#SrokD').val() == "") {
        $('#SrokD').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SrokD').css('border-color', 'lightgrey');
    }

    if ($('#NumberVod').val() == "") {
        $('#NumberVod').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberVod').css('border-color', 'lightgrey');
    }

    if ($('#SrokDVodUd').val() == "") {
        $('#SrokDVodUd').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SrokDVodUd').css('border-color', 'lightgrey');
    }

    if ($('#NumberVoen').val() == "") {
        $('#NumberVoen').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberVoen').css('border-color', 'lightgrey');
    }

    if ($('#Zvanie').val() == "") {
        $('#Zvanie').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Zvanie').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var selected = []
    var checkboxes = document.querySelectorAll('input[name=inList]:checked');

    for (var i = 0; i < checkboxes.length; i++) {
        selected.push(checkboxes[i].value);
    }

    var data = {
                
        'TabNumber': $('#TabNumber').val(),
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'dateroj': $('#dateroj').val(),
        'MobPhone': $('#MobPhone').val(),
        'GorPhone': $('#GorPhone').val(),
        'dateMed': $('#dateMed').val(),
        'Fil': $('#Fil').val(),
        'Podrazd': $('#Podrazd').val(),
        'Dolj': $('#Dolj').val(),
        'Class': $('#Class').val(),
        'IDNumber': $('#IDNumber').val(),
        'Seria': $('#Seria').val(),
        'Number': $('#Number').val(),
        'Propiska': $('#Propiska').val(),
        'Address': $('#Address').val(),
        'Vidan': $('#Vidan').val(),
        'SrokD': $('#SrokD').val(),
        'NumberVod': $('#NumberVod').val(),
        'SrokDVodUd': $('#SrokDVodUd').val(),
        'NumberVoen': $('#NumberVoen').val(),
        'Zvanie': $('#Zvanie').val(),
        'array': selected
    };

    $.ajax({
        url: "/Home/DriverAddSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление водителя//

function DeleteDriver(ID) {
    $.ajax({
        url: "/Home/DeleteDriver/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления водителя //
function DeleteDriverOK(ID) {

    $.ajax({
        url: "/Home/DeleteDriverOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//
// Редактирование водителя //

function DriverEdit(ID) {
    $.ajax({
        url: "/Home/DriverEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования водителя //

function DriverEditSave() {

    var isValid = true;

    if ($('#TabNumber').val() == "") {
        $('#TabNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TabNumber').css('border-color', 'lightgrey');
    }

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }

    if ($('#dateroj').val() == "") {
        $('#dateroj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#dateroj').css('border-color', 'lightgrey');
    }

    if ($('#MobPhone').val() == "") {
        $('#MobPhone').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MobPhone').css('border-color', 'lightgrey');
    }

    if ($('#GorPhone').val() == "") {
        $('#GorPhone').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#GorPhone').css('border-color', 'lightgrey');
    }

    if ($('#dateMed').val() == "") {
        $('#dateMed').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#dateMed').css('border-color', 'lightgrey');
    }

    if ($('#Fil').val() == "") {
        $('#Fil').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Fil').css('border-color', 'lightgrey');
    }


    if ($('#IDNumber').val() == "") {
        $('#IDNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#IDNumber').css('border-color', 'lightgrey');
    }

    if ($('#Seria').val() == "") {
        $('#Seria').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Seria').css('border-color', 'lightgrey');
    }

    if ($('#Number').val() == "") {
        $('#Number').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Number').css('border-color', 'lightgrey');
    }

    if ($('#Propiska').val() == "") {
        $('#Propiska').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Propiska').css('border-color', 'lightgrey');
    }

    if ($('#Address').val() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }

    if ($('#Vidan').val() == "") {
        $('#Vidan').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Vidan').css('border-color', 'lightgrey');
    }

    if ($('#SrokD').val() == "") {
        $('#SrokD').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SrokD').css('border-color', 'lightgrey');
    }

    if ($('#NumberVod').val() == "") {
        $('#NumberVod').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberVod').css('border-color', 'lightgrey');
    }

    if ($('#SrokDVodUd').val() == "") {
        $('#SrokDVodUd').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SrokDVodUd').css('border-color', 'lightgrey');
    }

    if ($('#NumberVoen').val() == "") {
        $('#NumberVoen').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberVoen').css('border-color', 'lightgrey');
    }

    if ($('#Zvanie').val() == "") {
        $('#Zvanie').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Zvanie').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var selected = []
    var checkboxes = document.querySelectorAll('input[name=inList]:checked');

    for (var i = 0; i < checkboxes.length; i++) {
        selected.push(checkboxes[i].value);
    }

    var data = {
        
        'ID': $('#ID').val(),
        'IDPAS': $('#IDPAS').val(),
        'IDVU': $('#IDVU').val(),
        'IDVB': $('#IDVB').val(),
        'TabNumber': $('#TabNumber').val(),
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'dateroj': $('#dateroj').val(),
        'MobPhone': $('#MobPhone').val(),
        'GorPhone': $('#GorPhone').val(),
        'dateMed': $('#dateMed').val(),
        'Fil': $('#Fil').val(),
        'Podrazd': $('#Podrazd').val(),
        'Doljnost': $('#Doljnost').val(),
        'Class': $('#Class').val(),
        'IDNumber': $('#IDNumber').val(),
        'Seria': $('#Seria').val(),
        'Number': $('#Number').val(),
        'Propiska': $('#Propiska').val(),
        'Address': $('#Address').val(),
        'Vidan': $('#Vidan').val(),
        'SrokD': $('#SrokD').val(),
        'NumberVod': $('#NumberVod').val(),
        'SrokDVodUd': $('#SrokDVodUd').val(),
        'NumberVoen': $('#NumberVoen').val(),
        'Zvanie': $('#Zvanie').val(),
        'array': selected

    };

    $.ajax({
        url: "/Home/DriverEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//
//-------Добавление автомобиля--------------//
function AddCar(ID) {
    $.ajax({
        url: "/Home/AddCar/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//Сохранение добавления автомобиля//

function CarAddSave(GarNumber, Model, NumberGos, vod, Fil, DatePost, Tehosmotr, car, body, motor, year, Gruzopod, Whels, Spare, Odometer, MotoHour, fuel, VTank, BalanceTank, LinNorma, WithTrailer, Na100TonnKm, Mechanizm, Heater, Gorod100, Gorod300, Gorod1000, WithStop, Slowly, Offroad, Highway, Amortiz, Conditioning, Generator, AddBlue, Career, OilMotor, Transmission, Spec, Hydravlic, other)
{

    var isValid = true;

    if ($('#GarNumber').val() == "") {
        $('#GarNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#GarNumber').css('border-color', 'lightgrey');
    }

    if ($('#Model').val() == "") {
        $('#Model').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Model').css('border-color', 'lightgrey');
    }

    if ($('#NumberGos').val() == "") {
        $('#NumberGos').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberGos').css('border-color', 'lightgrey');
    }

    if ($('#Fil').val() == "") {
        $('#Fil').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Fil').css('border-color', 'lightgrey');
    }

    if ($('#body').val() == "") {
        $('#body').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#body').css('border-color', 'lightgrey');
    }

    if ($('#car').val() == "") {
        $('#car').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#car').css('border-color', 'lightgrey');
    }

    if ($('#motor').val() == "") {
        $('#motor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#motor').css('border-color', 'lightgrey');
    }

    if ($('#year').val() == "") {
        $('#year').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#year').css('border-color', 'lightgrey');
    }

    if ($('#Whels').val() == "") {
        $('#Whels').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Whels').css('border-color', 'lightgrey');
    }


    if ($('#Spare').val() == "") {
        $('#Spare').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Spare').css('border-color', 'lightgrey');
    }

    if ($('#Odometer').val() == "") {
        $('#Odometer').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Odometer').css('border-color', 'lightgrey');
    }

    if ($('#fuel').val() == "") {
        $('#fuel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#fuel').css('border-color', 'lightgrey');
    }

    if ($('#LinNorma').val() == "") {
        $('#LinNorma').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LinNorma').css('border-color', 'lightgrey');
    }      

    
    if (isValid == false) {
        return false;
    }

    //var selected = []
    //var checkboxes = document.querySelectorAll('input[name=inList]:checked');

    //for (var i = 0; i < checkboxes.length; i++) {
    //    selected.push(checkboxes[i].value);
    //}

    var data = {

        'GarNumber': $('#GarNumber').val(),
        'Model': $('#Model').val(),
        'NumberGos': $('#NumberGos').val(),
        'vod': $('#vod').val(),
        'Fil': $('#Fil').val(),
        'MobPhone': $('#MobPhone').val(),
        'GorPhone': $('#GorPhone').val(),
        'dateMed': $('#dateMed').val(),
        'Fil': $('#Fil').val(),
        'DatePost': $('#DatePost').val(),
        'Tehosmotr': $('#Tehosmotr').val(),
        'car': $('#car').val(),
        'body': $('#body').val(),
        'motor': $('#motor').val(),
        'year': $('#year').val(),
        'Gruzopod': $('#Gruzopod').val(),
        'Whels': $('#Whels').val(),
        'Spare': $('#Spare').val(),
        'Odometer': $('#Odometer').val(),
        'MotoHour': $('#MotoHour').val(),
        'fuel': $('#fuel').val(),
        'VMotor': $('#VMotor').val(),
        'VTank': $('#VTank').val(),
        'BalanceTank': $('#BalanceTank').val(),
        'LinNorma': $('#LinNorma').val(),
        'WithTrailer': $('#WithTrailer').val(),
        'Na100TonnKm': $('#Na100TonnKm').val(),
        'Mechanizm': $('#Mechanizm').val(),
        'Heater': $('#Heater').val(),
        'Gorod100': $('#Gorod100').val(),
        'Gorod300': $('#Gorod300').val(),
        'Gorod1000': $('#Gorod1000').val(),
        'WithStop': $('#WithStop').val(),
        'Slowly': $('#Slowly').val(),
        'Offroad': $('#Offroad').val(),
        'Highway': $('#Highway').val(),
        'Amortiz': $('#Amortiz').val(),
        'Conditioning': $('#Conditioning').val(),
        'Generator': $('#Generator').val(),
        'AddBlue': $('#AddBlue').val(),
        'Career': $('#Career').val()
        
        
    };

    $.ajax({
        url: "/Home/CarAddSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление автомобиля//

function DeleteCar(ID) {
    $.ajax({
        url: "/Home/DeleteCar/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления автомобиля //
function DeleteCarOK(ID) {

    $.ajax({
        url: "/Home/DeleteCarOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//
// Редактирование автомобиля //

function CarEdit(ID) {
    $.ajax({
        url: "/Home/CarEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования автомобиля //

function CarEditSave() {

    var isValid = true;

    if ($('#GarNumber').val() == "") {
        $('#GarNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#GarNumber').css('border-color', 'lightgrey');
    }

    if ($('#Model').val() == "") {
        $('#Model').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Model').css('border-color', 'lightgrey');
    }

    if ($('#NumberGos').val() == "") {
        $('#NumberGos').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberGos').css('border-color', 'lightgrey');
    }

    if ($('#Fil').val() == "") {
        $('#Fil').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Fil').css('border-color', 'lightgrey');
    }

    if ($('#body').val() == "") {
        $('#body').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#body').css('border-color', 'lightgrey');
    }

    if ($('#car').val() == "") {
        $('#car').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#car').css('border-color', 'lightgrey');
    }

    if ($('#motor').val() == "") {
        $('#motor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#motor').css('border-color', 'lightgrey');
    }

    if ($('#year').val() == "") {
        $('#year').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#year').css('border-color', 'lightgrey');
    }

    if ($('#Whels').val() == "") {
        $('#Whels').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Whels').css('border-color', 'lightgrey');
    }


    if ($('#Spare').val() == "") {
        $('#Spare').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Spare').css('border-color', 'lightgrey');
    }

    if ($('#Odometer').val() == "") {
        $('#Odometer').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Odometer').css('border-color', 'lightgrey');
    }

    if ($('#fuel').val() == "") {
        $('#fuel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#fuel').css('border-color', 'lightgrey');
    }

    if ($('#LinNorma').val() == "") {
        $('#LinNorma').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LinNorma').css('border-color', 'lightgrey');
    } 

    //if (isValid == false) {
    //    return false;
    //}

    //var selected = []
    //var checkboxes = document.querySelectorAll('input[name=inList]:checked');

    //for (var i = 0; i < checkboxes.length; i++) {
    //    selected.push(checkboxes[i].value);
    //}

    var data = {

        'ID': $('#ID').val(),
        'GarNumber': $('#GarNumber').val(),
        'Model': $('#Model').val(),
        'NumberGos': $('#NumberGos').val(),
        'vod': $('#vod').val(),
        'Fil': $('#Fil').val(),
        'DatePost': $('#DatePost').val(),
        'Tehosmotr': $('#Tehosmotr').val(),
        'car': $('#car').val(),
        'body': $('#body').val(),
        'motor': $('#motor').val(),
        'year': $('#year').val(),
        'Gruzopod': $('#Gruzopod').val(),
        'Whels': $('#Whels').val(),
        'Spare': $('#Spare').val(),
        'Odometer': $('#Odometer').val(),
        'MotoHour': $('#MotoHour').val(),
        'fuel': $('#fuel').val(),
        'VMotor': $('#VMotor').val(),
        'VTank': $('#VTank').val(),
        'BalanceTank': $('#BalanceTank').val(),
        'LinNorma': $('#LinNorma').val(),
        'WithTrailer': $('#WithTrailer').val(),
        'Na100TonnKm': $('#Na100TonnKm').val(),
        'Mechanizm': $('#Mechanizm').val(),
        'Heater': $('#Heater').val(),
        'Gorod100': $('#Gorod100').val(),
        'Gorod300': $('#Gorod300').val(),
        'Gorod1000': $('#Gorod1000').val(),
        'WithStop': $('#WithStop').val(),
        'Slowly': $('#Slowly').val(),
        'Offroad': $('#Offroad').val(),
        'Highway': $('#Highway').val(),
        'Amortiz': $('#Amortiz').val(),
        'Conditioning': $('#Conditioning').val(),
        'Generator': $('#Generator').val(),
        'AddBlue': $('#AddBlue').val(),
        'Career': $('#Career').val()


    };

    $.ajax({
        url: "/Home/CarEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//
//--------Справочники-------------//

//-------Добавление топлива--------------//
function AddFuel(ID) {
    $.ajax({
        url: "/Home/AddFuel/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//Сохранение добавления топлива//

function FuelAddSave() {

    var isValid = true;
                       
    
    if ($('#Fuel').val() == "") {
        $('#Fuel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Fuel').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }
        

    var data = {

        'Fuel': $('#Fuel').val(),
        'Priznak': $('#Priznak').val(),
        
    };

    $.ajax({
        url: "/Home/FuelAddSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление топлива//

function DeleteFuel(ID) {
    $.ajax({
        url: "/Home/DeleteFuel/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления топлива //
function DeleteFuelOK(ID) {

    $.ajax({
        url: "/Home/DeleteFuelOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//
// Редактирование толива //

function FuelEdit(ID) {
    $.ajax({
        url: "/Home/FuelEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования топлива //

function FuelEditSave() {

    var isValid = true;


    if ($('#Fuel').val() == "") {
        $('#Fuel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Fuel').css('border-color', 'lightgrey');
    }

    //if (isValid == false) {
    //    return false;
    //}
      

    var data = {

        'ID': $('#ID').val(),
        'Fuel': $('#Fuel').val(),
        'Priznak': $('#Priznak').val(),
       
    };

    $.ajax({
        url: "/Home/FuelEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//

//-------Добавление типа автомобиля--------------//
function AddTypeCar(ID) {
    $.ajax({
        url: "/Home/AddTypeCar/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//Сохранение добавления типа автомобиля//

function TypeCarAddSave() {

    var isValid = true;


    if ($('#TypeCar').val() == "") {
        $('#TypeCar').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TypeCar').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }


    var data = {

        'TypeCar': $('#TypeCar').val(),
        'Priznak': $('#Priznak').val(),

    };

    $.ajax({
        url: "/Home/TypeCarAddSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление типа автомобяля//

function DeleteTypeCar(ID) {
    $.ajax({
        url: "/Home/DeleteTypeCar/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Удаление подразделения//

function DeletePodr(ID) {
    $.ajax({
        url: "/Home/DeletePodr/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Удаление должности//

function DeleteDolj(ID) {
    $.ajax({
        url: "/Home/DeleteDolj/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления подразделения //
function DeletePodrOK(ID) {

    $.ajax({
        url: "/Home/DeletePodrOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//
//Подтверждение удаления должности//
function DeleteDoljOK(ID) {

    $.ajax({
        url: "/Home/DeleteDoljOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//

//Подтверждение удаления типа автомобиля //
function DeleteTypeCarOK(ID) {

    $.ajax({
        url: "/Home/DeleteTypeCarOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//
// Редактирование типа автомобиля //

function TypeCarEdit(ID) {
    $.ajax({
        url: "/Home/TypeCarEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования типа автомобиля //

function TypeCarEditSave() {

    var isValid = true;


    if ($('#TypeCar').val() == "") {
        $('#TypeCar').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TypeCar').css('border-color', 'lightgrey');
    }

    //if (isValid == false) {
    //    return false;
    //}


    var data = {

        'ID': $('#ID').val(),
        'TypeCar': $('#TypeCar').val(),
        'Priznak': $('#Priznak').val(),

    };

    $.ajax({
        url: "/Home/TypeCarEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//

// Редактирование подразделения //

function PodrEdit(ID) {
    $.ajax({
        url: "/Home/PodrEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования подразделения //

function PodrEditSave() {

    var isValid = true;


    if ($('#Podrazd').val() == "") {
        $('#Podrazd').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Podrazd').css('border-color', 'lightgrey');
    }

    
    var data = {

        'ID': $('#ID').val(),
        'Podrazd': $('#Podrazd').val(),
        'Priznak': $('#Priznak').val(),
        'Fil': $('#Fil').val()
    };

    $.ajax({
        url: "/Home/PodrEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//

// Редактирование должности //

function DoljEdit(ID) {
    $.ajax({
        url: "/Home/DoljEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования должности //

function DoljEditSave() {

    var isValid = true;


    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }


    var data = {

        'ID': $('#ID').val(),
        'Doljnost': $('#Doljnost').val(),
        'Priznak': $('#Priznak').val(),

    };

    $.ajax({
        url: "/Home/DoljEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//


//-------Добавление типа кузова--------------//
function AddTypeCarBody(ID) {
    $.ajax({
        url: "/Home/AddTypeCarBody/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//Сохранение добавления типа кузова//

function TypeCarBodyAddSave() {

    var isValid = true;


    if ($('#TypeCarBody').val() == "") {
        $('#TypeCarBody').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TypeCarBody').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }


    var data = {

        'TypeCarBody': $('#TypeCarBody').val(),
        'Priznak': $('#Priznak').val(),

    };

    $.ajax({
        url: "/Home/TypeCarBodyAddSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//

//-------Добавление подразделения--------------//
function AddPodr(ID) {
    $.ajax({
        url: "/Home/AddPodr/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//Сохранение добавления подразделения//

function PodrAddSave() {

    var isValid = true;


    if ($('#Podrazd').val() == "") {
        $('#Podrazd').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Podrazd').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }


    var data = {

        'Podrazd': $('#Podrazd').val(),
        'Fil': $('#Fil').val(),
        'Priznak': $('#Priznak').val(),

    };

    $.ajax({
        url: "/Home/PodrAddSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//

//-------Добавление должности--------------//
function AddDolj(ID) {
    $.ajax({
        url: "/Home/AddDolj/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//Сохранение добавления должности//

function DoljAddSave() {

    var isValid = true;


    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }


    var data = {

        'Doljnost': $('#Doljnost').val(),
        'Priznak': $('#Priznak').val(),

    };

    $.ajax({
        url: "/Home/DoljAddSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//


// Удаление типа кузова//

function DeleteTypeCarBody(ID) {
    $.ajax({
        url: "/Home/DeleteTypeCarBody/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления типа кузова //
function DeleteTypeCarBodyOK(ID) {

    $.ajax({
        url: "/Home/DeleteTypeCarBodyOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//
// Редактирование типа кузова //

function TypeCarBodyEdit(ID) {
    $.ajax({
        url: "/Home/TypeCarBodyEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования типа кузова //

function TypeCarBodyEditSave() {

    var isValid = true;


    if ($('#TypeCarBody').val() == "") {
        $('#TypeCarBody').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TypeCarBody').css('border-color', 'lightgrey');
    }

    //if (isValid == false) {
    //    return false;
    //}


    var data = {

        'ID': $('#ID').val(),
        'TypeCarBody': $('#TypeCarBody').val(),
        'Priznak': $('#Priznak').val(),

    };

    $.ajax({
        url: "/Home/TypeCarBodyEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//

//-------Добавление типа двигателя--------------//
function AddTypeMotor(ID) {
    $.ajax({
        url: "/Home/AddTypeMotor/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//Сохранение добавления типа двигателя//

function TypeMotorAddSave() {

    var isValid = true;


    if ($('#TypeMotor').val() == "") {
        $('#TypeMotor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TypeMotor').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }


    var data = {

        'TypeMotor': $('#TypeMotor').val(),
        'Priznak': $('#Priznak').val(),

    };

    $.ajax({
        url: "/Home/TypeMotorAddSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление типа двигателя//

function DeleteTypeMotor(ID) {
    $.ajax({
        url: "/Home/DeleteTypeMotor/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления типа двигателя //
function DeleteTypeMotorOK(ID) {

    $.ajax({
        url: "/Home/DeleteTypeMotorOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-------------------//
// Редактирование типа двигателя //

function TypeMotorEdit(ID) {
    $.ajax({
        url: "/Home/TypeMotorEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования типа двигателя //

function TypeMotorEditSave() {

    var isValid = true;


    if ($('#TypeMotor').val() == "") {
        $('#TypeMotor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TypeMotor').css('border-color', 'lightgrey');
    }

    //if (isValid == false) {
    //    return false;
    //}


    var data = {

        'ID': $('#ID').val(),
        'TypeMotor': $('#TypeMotor').val(),
        'Priznak': $('#Priznak').val(),

    };

    $.ajax({
        url: "/Home/TypeMotorEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//----------ОТЧЕТЫ---------//
function ReportDriverEXCEL() {
     window.location = "/Home/Export/";
    //var stringhref = "Export?";

    //stringhref += "Fil=" + $('#Fil').val()
    //window.location = stringhref;
}

//---------------Отчет согласно фильтра----------------//
function ReportFilter(ID) {
    $.ajax({
        url: "/Home/ReportFilter/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//----------------------------------------------------//
//-------------Просрочен паспорт--------//
function ReportPassportEXCEL() {
    window.location = "/Home/ReportPassportEXCEL/";
    //var stringhref = "Export?";       
}
//--------------Просрочено вод.удостоверение---------------//
function ReportVodUdEXCEL() {
    window.location = "/Home/ReportVodUdEXCEL/";
    //var stringhref = "Export?";
}
//-------------Непрошедшие медкомиссию------------------//
function ReportMedEXCEL() {
    window.location = "/Home/ReportMedEXCEL/";
    //var stringhref = "Export?";       
}

//---------------Отчет согласно фильтра передача данных в контроллер----------------//
function ReportFilterExcel(ID) {
        
    var stringhref = "Home/ReportFilterExcel?";

    stringhref += "Fil=" + $('#Fil').val() + "&" + "Podrazd=" + $('#Podrazd').val();
    //window.open(stringhref, '_blank');
    window.location = stringhref;
    close.modal;

}
//--------------------------------//
//----------------------------------------------------//
