/////////////////////////////////Fonctions/////////////////////////////////

//Fonction permettant de mettre en cache les valeur de la ligne selectionne pour edition
function mise_en_cache_var_user(user_email, user_name, user_role,IsLock) {
    
    //Modification des variables générale
    document.getElementById("user_sup_id").value = decodeURI(user_name);
    document.getElementById("user_email").value = decodeURI(user_email);
    document.getElementById("user_name").value = decodeURI(user_name);
    document.getElementById("user_name_disabled").value = decodeURI(user_name);
    document.getElementById("RoleEdit").value = decodeURI(user_role);
    $("#Role").trigger("change");

    //Si actif alors on met le checkbox a actif
    if (IsLock == "true" || IsLock == "True") {
        document.getElementById("checkbox_user_edit_form").value = false;
        document.getElementById("check_cache").style.display = 'block';
        if (document.getElementById('checkbox_user_edit').checked == true) {
        } else {
            $('#checkbox_user_edit').trigger('click');
        }
    }
    else {
        document.getElementById("checkbox_user_edit_form").value = false;
        document.getElementById("check_cache").style.display = 'none';
        if (document.getElementById('checkbox_user_edit').checked == true) {
            $('#checkbox_user_edit').trigger('click');
        }
    }
}



//Fonction permettant d'editer les categories
function EditUser() {

    var ID = $("#user_name").val();

    //Edition en dynamique dans le tableau
    $.post("Edit", { membershipuserusername: ID, membershipuseremail: $("#user_email").val(), password: $("#NewPassword").val(), role: $("#RoleEdit option:selected").val(), UnLock: $("#checkbox_user_edit_form").val() },
        function (data) {
            if (data != "False") {

                var butonActive = "";
                var boolcheck = false;

                if (document.getElementById('checkbox_user_edit').checked == true) {
                    butonActive = "<input type='checkbox' data-render-add-" + ID + "='switchery' data-theme='danger' data-disabled='true' checked />";
                    boolcheck = "true";
                }
                else {
                    butonActive = "<input type='checkbox' data-render-add-" + ID + "='switchery' data-theme='danger' data-disabled='true' />";
                    boolcheck = "false";
                }

                //Modale de success
                AlertSuccess();
                var thisLigne = $("#" + ID);
                thisLigne.find(".emailTd").html($("#user_email").val());
                thisLigne.find(".lockTd").html(butonActive);
                thisLigne.find(".roleTd").html($("#RoleEdit option:selected").text());
                thisLigne.find(".boutonTd").html("<a href='#edit-dialog' style='margin-right:2px;' onclick=\"mise_en_cache_var_user('" + $("#user_email").val() + "','" + ID + "','" + $("#RoleEdit option:selected").val() + "','" + boolcheck + "')\" class='btn btn-sm btn-primary' data-toggle='modal'><i class='fa fa-pencil'></i></a><a href='#delete-dialog' style='margin:2px;' onclick=\"mise_en_cache_var_user('" + $("#user_email").val() + "','" + ID + "','" + $("#RoleEdit option:selected").val() + "','" + $("#checkbox_user_edit_form").val() + "')\" class='btn btn-sm btn-danger' data-toggle='modal'><i class='glyphicon glyphicon-trash'></i></a>");

                $('#edit-dialog').modal('toggle');
                renderSwitcherI("add-" + ID);
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

    renderSwitcher();

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
            $.get("DeleteUser?user=" + $(this).attr('id'), function (data) {
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
        var UserName = $("#UserName").val();

        $.post("/Account/Register/", { ConfirmPassword: $("#ConfirmPassword").val(), UserName: UserName, Email: $("#Email").val(), Password: $("#Password").val(), Role: $("#Role option:selected").val() },
            function (data) {
                if (data != "False") {

                    //Modale de success
                    AlertSuccess();
                    var rowNode = Table.row.add([
                        "<div class='usernameTd'>" + UserName + "</div>",
                        "<div class='emailTd'>" + $("#Email").val() + "</div>",
                        "<div class='dateTd'>" + "" + "</div>",
                        "<div class='lockTd'>" + "<input type='checkbox' data-render-add-" + UserName + "='switchery' data-theme='danger' data-disabled='true' />" + "</div>",
                        "<div class='roleTd'>" + $("#Role option:selected").text() + "</div>",
                        "<div class='boutonTd'><a href='#edit-dialog' style='margin-right:2px;' onclick=\"mise_en_cache_var_user('" + $("#Email").val() + "','" + UserName + "','" + $("#Role option:selected").val() + "','" + "false" + "')\" class='btn btn-sm btn-primary' data-toggle='modal'><i class='fa fa-pencil'></i></a><a href='#delete-dialog' style='margin:2px;' onclick=\"mise_en_cache_var_user('" + $("#Email").val() + "','" + UserName + "','" + $("#Role option:selected").val() + "','" + "false" + "')\" class='btn btn-sm btn-danger' data-toggle='modal'><i class='glyphicon glyphicon-trash'></i></a></div>"
                    ]).draw(false)
                    .node();

                    $(rowNode).attr("id", UserName);

                    $(rowNode).find("input").each(function () {
                        var t = success;
                        if ($(this).attr("data-theme")) switch ($(this).attr("data-theme")) {
                            case "danger":
                                t = danger;
                                break;
                            case "primary":
                                t = primary;
                                break;
                            case "purple":
                                t = purple;
                                break;
                            case "warning":
                                t = warning;
                                break;
                            case "info":
                                t = info;
                                break;
                            case "lime":
                                t = lime;
                                break;
                            case "grey":
                                t = grey;
                                break;
                            case "inverse":
                                t = inverse
                        }
                        var a = {};
                        a.color = t, a.secondaryColor = $(this).attr("data-secondary-color") ? $(this).attr("data-secondary-color") : "#dfdfdf", a.className = $(this).attr("data-classname") ? $(this).attr("data-classname") : "switchery", a.disabled = $(this).attr("data-disabled") ? !0 : !1, a.disabledOpacity = $(this).attr("data-disabled-opacity") ? $(this).attr("data-disabled-opacity") : .5, a.speed = $(this).attr("data-speed") ? $(this).attr("data-speed") : "0.5s";
                        new Switchery(this, a)
                    })

                    $('#add-dialog').modal('toggle');

                    //renderSwitcherI("add-" + UserName);
                }
                else {
                    AlertDanger();
                }
            });
    });


    // Fonction de suppression mono message
    $("#deleteMono").click(function () {

        var id = $("#user_sup_id").val()
        $.get("DeleteUser?user=" + id, function (data) {
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


