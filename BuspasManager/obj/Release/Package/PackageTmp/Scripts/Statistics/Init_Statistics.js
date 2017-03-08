/////////////////////////////////Fonctions/////////////////////////////////

//Fonction permettant de mettre en cache les valeur de la ligne selectionne pour edition
function mise_en_cache_var_statistics(Quest_ID, Name, Description, From_Date, To_Date) {

    //Modification des variables générale
    document.getElementById("Quest_ID_Edit").value = decodeURI(Quest_ID);
    document.getElementById("Name_Edit").value = decodeURI(Name);
    document.getElementById("Description_Edit").value = decodeURI(Description);
    document.getElementById("datetimepicker5").value = decodeURI(From_Date);
    document.getElementById("datetimepicker6").value = decodeURI(To_Date);
    
}


//Fonction permettant d'editer les questions
function EditQuestion() {

    var ID = $("#Quest_ID_Edit").val();

    //Edition en dynamique dans le tableau
    $.post("Edit", { Quest_ID: ID, Name: $("#Name_Edit").val(), Description: $("#Description_Edit").val(), From_Date: $("#datetimepicker5").val(), To_Date: $("#datetimepicker6").val() },
        function (data) {
            if (data != "false") {
                //Modale de success
                AlertSuccess();

                var thisLigne = $("#" + ID);
                thisLigne.find(".Quest_IDTd").html(ID);
                thisLigne.find(".NameTd").html($("#Name_Edit").val());
                thisLigne.find(".DescriptionTd").html($("#Description_Edit").val());
                thisLigne.find(".From_DateTd").html($("#datetimepicker5").val());
                thisLigne.find(".To_DateTd").html($("#datetimepicker6").val());
                thisLigne.find(".boutonTd").html("<a href='#edit-dialog' style='margin-right:2px;' onclick=\"mise_en_cache_var_statistics('" + ID + "','" + $("#Name_Edit").val() + "','" + $("#Description_Edit").val() + "','" + $("#datetimepicker5").val() + "','" + $("#datetimepicker6").val() + "')\" class='btn btn-sm btn-primary' data-toggle='modal'><i class='fa fa-pencil'></i></a>");

                $('#edit-dialog').modal('toggle');
            }
            else {
                AlertDanger();
            }
        });
};

////////////////////////////////////////////////////////////////////////////////////





/////////////////////////////////Fonction INIT/////////////////////////////////
// Fonctions d'initialisations
$(function () {

    var Table = $('#data-table1').DataTable({
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



    $("#deleteMulti").click(function () {

        $("#data-table1 tbody tr.selected").each(function () {
            var thisLigne = $(this);
            $.get("Delete?id=" + $(this).attr('id'), function (data) {
                if (data == "True") {
                    //Modale de success
                    Table.row(thisLigne).remove().draw(false);
                    AlertSuccess();
                }
                else {
                    AlertDanger();
                }
            });
        });
    });


    jQuery(document).ready(function ($) {

        //D/claration du form builder
        var fbTemplate = document.getElementById('build-wrap'),
      options = {
          dataType: 'json'
      };
        var formBuilder = $(fbTemplate).formBuilder(options).data('formBuilder');

        $("#addMono").click(function (e) {

            //recuperation des info du form data
            e.preventDefault();
            
            var items = formBuilder.formData;
            var ListeItems = {},TableauItem = new Array();

            $.each($.parseJSON(items), function (cle, valeur) {
                ListeItems = {};
                switch(valeur.type) {
                    case "checkbox-group":
                        ListeItems.Type = 6;
                        break;
                    case "radio-group":
                        ListeItems.Type = 4;
                        break;
                    case "checkbox":
                        ListeItems.Type = 2;
                        break;
                    case "number":
                        ListeItems.Type = 1;
                        break;
                    case "text":
                        ListeItems.Type = 3;
                        break;
                }
                
                ListeItems.Value = valeur.label;
                
                //Cas dun checkbox multiple a traiter en boucle
                if (valeur.type == "checkbox-group" || valeur.type == "radio-group") {
                    $.each(valeur.values, function (cle2, valeur2) {
                        ListeItems.SubValue = ListeItems.SubValue + ";" + valeur2.label;
                    });
                } else {
                    ListeItems.SubValue = "";
                }
                TableauItem.push(ListeItems);
            });

            //Formatage a format JSON
            var ItemsJSON = JSON.stringify(TableauItem);
            
            $.post("Create", { Name: $("#Name").val(),Description: $("#Description").val(),From_Date: $("#datetimepicker3").val(),To_Date: $("#datetimepicker4").val(),ItemsJSON: ItemsJSON },
            function (data) {
                if (data != "False") {
                    //Modale de success
                    AlertSuccess();
                    var rowNode = Table.row.add([
                        "<div class='Quest_IDTd'>" + data + "</div>",
                        "<div class='NameTd'>" + $("#Name").val() + "</div>",
                        "<div class='descriptionTd'>" + $("#Description").val() + "</div>",
                        "<div class='From_DateTd'>" + $("#datetimepicker3").val() + "</div>",
                        "<div class='To_DateTd'>" + $("#datetimepicker4").val() + "</div>",
                        "<div class='boutonTd'><a onclick=\"javascript:location.href = 'Details/" + data + "';\" style='margin-right:2px;' class='btn btn-sm btn-grey'><i class='fa fa-info-circle'></i></a><a href='#edit-dialog' style='margin-right:2px;' onclick=\"mise_en_cache_var_statistics('" + data + "','" + $("#Name").val() + "','" + $("#Description").val() + "','" + $("#datetimepicker3").val() + "','" + $("#datetimepicker4").val() + "')\" class='btn btn-sm btn-primary' data-toggle='modal'><i class='fa fa-pencil'></i></a></div>"
                    ]).draw(false)
                    .node();

                    $(rowNode).attr("id", data);
                    $('#add-dialog').modal('toggle');
                }
                else {
                    AlertDanger();
                }
            });
        });
    });


});
////////////////////////////////////////////////////////////////////////////////////


