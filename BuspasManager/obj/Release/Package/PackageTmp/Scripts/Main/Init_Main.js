/////////////////////////////////Fonctions/////////////////////////////////

//Fonction permettant de modifier le profil
function ChangeUserProfil() {
    //Chaines pour lenvoi des donnees en base et sur le serveur
    var jsonProfil = "role=" + $("#role").val() + "&membershipuserusername=" + $("#membershipuserusername").val() + "&membershipuseremail=" + $("#membershipuseremail").val();
    var jsonPassword = "CurrentPassword=" + $("#CurrentPassword").val() + "&NewPassword=" + $("#NewPassword").val() + "&ConfirmPassword=" + $("#ConfirmPassword").val();

    //Requeste post qui envoi les donnees
    $.post("/Account/ChangePersonalPassword?" + jsonPassword, function (data) {
        $.post("/Account/EditPersonal?" + jsonProfil,
            function (data2) {
                if (data2 == "True") {
                    AlertSuccess();
                    $('#profile-dialog').modal('toggle');
                }
                else {
                    AlertDanger();
                }
            })
    });
};



//Si changement de valeur du checkbox
function OnchangeCheckboxI(IDaCheck, IDaChange) {
    if (document.getElementById(IDaCheck).checked == true) {
        document.getElementById(IDaChange).value = false;
    }
    else {
        document.getElementById(IDaChange).value = true;
    }
}


//Si changement de valeur du checkbox
function OnchangeCheckbox(IDaCheck, IDaChange) {

    if (document.getElementById(IDaCheck).checked == true) {
        document.getElementById(IDaChange).value = true;
    }
    else {
        document.getElementById(IDaChange).value = false;
    }
}


//Fonction permettant de rajouter des slache pour les chaines de caractere complexe
function addslashes(str) {
    str = str.replace(/\'/g, '\\\'');
    str = str.replace(/\"/g, '\\"');
    str = str.replace(/\\/g, '\\\\');
    str = str.replace(/\0/g, '\\0');
    return str;
}



//Fonction aui convertie le format militaire en 12h
function timeTo12HrFormat(time) {   // Take a time in 24 hour format and format it in 12 hour format
    var time_part_array = time.split(":");
    var ampm = 'AM';

    if (time_part_array[0] >= 12) {
        ampm = 'PM';
    }

    if (time_part_array[0] > 12) {
        time_part_array[0] = time_part_array[0] - 12;
    }

    formatted_time = time_part_array[0] + ':' + time_part_array[1] + ' ' + ampm;

    return formatted_time;
}



//Fonction Alert//
function AlertSuccess() {
    $.gritter.add({
        title: Languages.SuccessfullOperation,
        text: Languages.SuccessfullOperationText,
        class_name: "gritter-success",
        before_open: function () {
        },
        after_open: function (t) {
        },
        before_close: function (t) {
        },
        after_close: function (t) {
        }
    });
}


function AlertDanger() {
    $.gritter.add({
        title: Languages.OperationFailed,
        text: Languages.OperationFailedText,
        class_name: "gritter-danger",
        before_open: function () {
        },
        after_open: function (t) {
        },
        before_close: function (t) {
        },
        after_close: function (t) {
        }
    });
}


////////////////////////////////////////////////////////////////////////////////////





/////////////////////////////////Fonction INIT/////////////////////////////////
$(function () {

    //Requeste post permettant de preselectionner la langue en cour
    $.post("/Home/GetCulture",
        function (data2) {
            $("#select-required").val(data2);
            $("#select-required").trigger('change');
        })
});
////////////////////////////////////////////////////////////////////////////////////


