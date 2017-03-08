/////////////////////////////////Fonctions/////////////////////////////////

//Fonction permettant de mettre en cache les valeur de la ligne selectionne pour edition
function mise_en_cache_var_categorie(categorie_id, categorie_description) {

    //Modification des variables générale
    document.getElementById("categorie_id").value = decodeURI(categorie_id);
    document.getElementById("categorie_description").value = decodeURI(categorie_description);
    document.getElementById("categorie_del_id").value = decodeURI(categorie_id);
    
}


//Fonction permettant d'editer les categories
function EditCategory() {

    var ID = $("#categorie_id").val();

    //Edition en dynamique dans le tableau
    $.post("Edit", { ID: ID, Description: $("#categorie_description").val() },
        function (data) {
            if (data != "false") {
                //Modale de success
                AlertSuccess();

                var thisLigne = $("#" + ID);
                thisLigne.find(".descriptionTd").html($("#categorie_description").val());
                thisLigne.find(".boutonTd").html("<a href='#edit-dialog' style='margin-right:2px;' onclick=\"mise_en_cache_var_categorie('" + ID + "','" + $("#categorie_description").val() + "')\" class='btn btn-sm btn-primary' data-toggle='modal'><i class='fa fa-pencil'></i></a><a href='#delete-dialog' style='margin:2px;' onclick=\"mise_en_cache_var_categorie('" + ID + "','" + $("#categorie_description").val() + "')\" class='btn btn-sm btn-danger' data-toggle='modal'><i class='glyphicon glyphicon-trash'></i></a>");

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

    //Messsage
    $('#data-table1 tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
        if ($('tr.selected').length == 0) {
            $("#buttonForSelection").fadeOut("slow");
        }
        else {
            $("#buttonForSelection").fadeIn("slow");
        }
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


    $("#addMono").click(function () {
        $.post("Create", { Description: $("#Description").val() },
        function (data) {
            if (data != "False") {
                //Modale de success
                AlertSuccess();
                var rowNode = Table.row.add([
                    "<div class='descriptionTd'>" + $("#Description").val() + "</div>",
                    "<div class='boutonTd'><a href='#edit-dialog' style='margin-right:2px;' onclick=\"mise_en_cache_var_categorie('" + data + "','" + $("#Description").val() + "')\" class='btn btn-sm btn-primary' data-toggle='modal'><i class='fa fa-pencil'></i></a><a href='#delete-dialog' style='margin:2px;' onclick=\"mise_en_cache_var_categorie('" + data + "','" + $("#Description").val() + "')\" class='btn btn-sm btn-danger' data-toggle='modal'><i class='glyphicon glyphicon-trash'></i></a></div>"
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


    // Fonction de suppression mono message
    $("#deleteMono").click(function () {

        var id = $("#categorie_del_id").val()
        $.get("Delete?id=" + id, function (data) {
            if (data == "True") {
                //Modale de success
                Table.row($("#" + id)).remove().draw(false);
                AlertSuccess();
            }
            else {
                AlertDanger();
            }
        });
    });
});
////////////////////////////////////////////////////////////////////////////////////


