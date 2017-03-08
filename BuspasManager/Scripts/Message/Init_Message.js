
/////////////////////////////////Fonctions/////////////////////////////////

//Fonction permettant de mettre en cache les valeur de la ligne selectionne pour edition
function mise_en_cache_var_message(Ticker_ID, Ticker_Text, Tiker_Color, Tiker_URL, Start_Time, Finish_Time, IS_Valid_Hidden) {

    //Modification des variables générale
    document.getElementById("Ticker_ID_Edit").value = decodeURI(Ticker_ID);
    document.getElementById("Ticker_Text_Edit").value = decodeURI(Ticker_Text);
    document.getElementById("Tiker_Color_Edit").value = "#" + decodeURI(Tiker_Color);
    document.getElementById("Tiker_URL_Edit").value = decodeURI(Tiker_URL);
    document.getElementById("datetimepicker5").value = decodeURI(Start_Time);
    document.getElementById("datetimepicker6").value = decodeURI(Finish_Time);
    
    //Si actif alors on met le checkbox a actif
    if (IS_Valid_Hidden == "True" || IS_Valid_Hidden == "true" || IS_Valid_Hidden == "1") {
        document.getElementById("IS_Valid_Hidden_Edit").value = true;
        if (document.getElementById('IS_Valid_Edit').checked == true) {
        } else {
            $('#IS_Valid_Edit').trigger('click');
        }
    }
    else {
        document.getElementById("IS_Valid_Hidden_Edit").value = false;
        if (document.getElementById('IS_Valid_Edit').checked == true) {
            $('#IS_Valid_Edit').trigger('click');
        }
    }
    
}



//Fonction permettant l'ajout de message
function AddMessage() {
    
    if($('#formAddMessage').parsley().isValid())
    {
        
        OnchangeCheckbox('IS_Valid', 'IS_Valid_Hidden');

        var couleur = $("#TextColor").val();
        var out;

        out = couleur.substring(1, couleur.length);

        //Ajout en dynamique dans le tableau
        var table = $('#messagesTable').DataTable({
            dom: "lBfrtip",
            buttons: ["copy", "csv", "excel", "pdf", "print"],
            responsive: !0,
            autoFill: !0,
            colReorder: !0,
            keys: !0,
            rowReorder: !0,
            bDestroy: true,
            select: !0,
            columnDefs: [{
                "targets": 'sorting_disabled',
                "orderable": false,
            }]
        });
        
        $.post("Create", { Ticker_Text: $("#text").val(), Tiker_Color: out, Tiker_URL: $("#link").val(), Start_Time: $("#datetimepicker3").val(), Finish_Time: $("#datetimepicker4").val(), IS_Valid_Hidden: $("#IS_Valid_Hidden").val() },
            function (data) {
                if (data != "False") {
                    //Modale de success
                    AlertSuccess();
                    
                    var contenuStatus = "";

                    if ($("#IS_Valid_Hidden").val() == "true") {
                        contenuStatus = "<span class='label label-success'>" + Languages.Actives + "</span>";
                    }
                    if ($("#IS_Valid_Hidden").val() == "false") {
                        contenuStatus = "<span class='label label-danger'>" + Languages.Inactives + "</span>";
                    }
                    
                    var rowNode = table.row.add([
                        "<div class='idTd'>" + data + "</div>",
                        "<div class='textTd' style='color:#" + out + ";'>" + $("#text").val() + "</div>",
                        "<div class='colorTd'>#" + out + "</div>",
                        "<div class='statusTd'>" + contenuStatus + "</div>",
                        "<div class='linkTd'>" + $("#link").val() + "</div>",
                        "<div class='startTd'>" + $("#datetimepicker3").val() + "</div>",
                        "<div class='endTd'>" + $("#datetimepicker4").val() + "</div>",
                        "<div class='boutonTd'><a href='#edit-dialog' style='margin:2px;' onclick=\"mise_en_cache_var_message('" + data + "','" + $("#text").val() + "','" + out + "','" + $("#link").val() + "','" + $("#datetimepicker3").val() + "','" + $("#datetimepicker4").val() + "','" + $("#IS_Valid_Hidden").val() + "')\" class='btn btn-sm btn-primary' data-toggle='modal'><i class='fa fa-pencil'></i></a></div>"
                    ]).draw(false)
                    .node();

                    $(rowNode).attr("id", data);
                    $('#add-dialog').modal('toggle');
                }
                else {
                    AlertDanger();
                }
            });
    }
    else
    {
        AlertDanger();
    }

};



// Fonction de suppression multi-messages
$(function () {
    var messagesTable = $('#messagesTable').DataTable({
        dom: "lBfrtip",
        buttons: ["copy", "csv", "excel", "pdf", "print"],
        responsive: !0,
        autoFill: !0,
        colReorder: !0,
        keys: !0,
        rowReorder: !0,
        bDestroy: true,
        select: !0,
        columnDefs: [{
            "targets": 'sorting_disabled',
            "orderable": false,
        }]
    });

    //Messsage
    $('#messagesTable tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
        if ($('tr.selected').length == 0) {
            $("#buttonForSelection").fadeOut("slow");
        }
        else {
            $("#buttonForSelection").fadeIn("slow");
        }
    });

    $("#deleteMulti").click(function () {
        $("#messagesTable tbody tr.selected").each(function () {
            var thisLigne = $(this);
            $.get("Delete?id=" + $(this).attr('id'), function (data) {
                if (data == "True") {
                    //Modale de success
                    messagesTable.row(thisLigne).remove().draw(false);
                    AlertSuccess();
                }
                else {
                    AlertDanger();
                }
            });
        });
    });

    // Edition multi-messages
    $("#saveMultiEdit").click(function () {
        var status = $("#statusList option:selected").val();
        $("#messagesTable tbody tr.selected").each(function () {
            var thisLigne = $(this);
            $.post("EditSelected", { id: $(this).attr('id'), statusCode: $("#StatusList option:selected").val() }, function (data) {
                if (data == "True") {
                    //Modale de success
                    thisLigne.find(".statusTd").html($("#StatusList option:selected").text());
                    AlertSuccess();
                }
                else {
                    AlertDanger();
                }
            });
        });
    });

    // Fonction de suppression mono message
    $("#deleteMono").click(function () {
        var id = $("#message_id_del").val()
        $.get("Delete?id=" + id, function (data) {
            if (data == "True") {
                //Modale de success
                messagesTable.row($("#" + id)).remove().draw(false);
                AlertSuccess();
            }
            else {
                AlertDanger();
            }
        });
    });



});



////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////Fonction INIT//////////////////////////////////////


//Fonction permettant de remplir les champ start et end date avant le submit
function SubmitEditDetailMessage() {

    var ID = $("#Ticker_ID_Edit").val();

    var couleur = $("#Tiker_Color_Edit").val();
    var out;
    out = couleur.substring(1, couleur.length);

    //Edition en dynamique dans le tableau
    $.post("Edit", { Ticker_ID: ID, Ticker_Text: $("#Ticker_Text_Edit").val(), Tiker_Color: out, Tiker_URL: $("#Tiker_URL_Edit").val(), Start_Time: $("#datetimepicker5").val(), Finish_Time: $("#datetimepicker6").val(), IS_Valid_Hidden_Edit: $("#IS_Valid_Hidden_Edit").val() },
        function (data) {
            if (data != "False") {
                //Modale de success
                AlertSuccess();

                var contenuStatus = "";

                if ($("#IS_Valid_Hidden_Edit").val() == "true") {
                    contenuStatus = "<span class='label label-success'>" + Languages.Actives + "</span>";
                }
                if ($("#IS_Valid_Hidden_Edit").val() == "false") {
                    contenuStatus = "<span class='label label-danger'>" + Languages.Inactives + "</span>";
                }

                var thisLigne = $("#" + ID);
                thisLigne.find(".idTd").html(ID);
                thisLigne.find(".textTd").html("<div style='color:#" + out + ";'>" + $("#Ticker_Text_Edit").val() + "</div>");
                thisLigne.find(".colorTd").html("#" + out);
                thisLigne.find(".statusTd").html(contenuStatus);
                thisLigne.find(".linkTd").html($("#Tiker_URL_Edit").val());
                thisLigne.find(".startTd").html($("#datetimepicker5").val());
                thisLigne.find(".endTd").html($("#datetimepicker6").val());
                thisLigne.find(".boutonTd").html("<a href='#edit-dialog' style='margin:2px;' onclick=\"mise_en_cache_var_message('" + ID + "','" + $("#Ticker_Text_Edit").val() + "','" + out + "','" + $("#Tiker_URL_Edit").val() + "','" + $("#datetimepicker5").val() + "','" + $("#datetimepicker6").val() + "','" + $("#IS_Valid_Hidden_Edit").val() + "')\" class='btn btn-sm btn-primary' data-toggle='modal'><i class='fa fa-pencil'></i></a>");

                $('#edit-dialog').modal('toggle');
            }
            else {
                AlertDanger();
            }
        });

};


//Fonction permettant de cacher un block en fonction d<une checkbox
function Onchange_All_Checkbox(ID_Check, ID_To_Hide) {
    
    //Si toutes les routes sont selectionnés
    if ($("#" + ID_Check).attr('checked') == 'checked') {
        $('#' + ID_To_Hide).hide();
    }
    else {
        $('#' + ID_To_Hide).show();
    }
}

