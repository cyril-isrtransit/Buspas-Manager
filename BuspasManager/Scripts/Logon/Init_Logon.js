/////////////////////////////////Fonction Autres/////////////////////////////////

//Fonction permettant de remplir les champ start et end date avant le submit
function SubmitConnexion() {

    //On récupere le daterange et on le decoupe
    var UserName = document.getElementById("UserName").value;
    var Password = document.getElementById("Password").value;
    var jsonPassword = "UserName=" + UserName + "&Password=" + Password;
    
    //Requeste post qui envoi les donnees
    $.post("/Account/LogOn?" + jsonPassword, function (data) {
        if (data == "false") {
            AlertDanger();
        }
        else {
            window.location.href = data;
        }

    });


};



////////////////////////////////////////////////////////////////////////////////////





/////////////////////////////////Fonction INIT/////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////


