Date.prototype.ddmmyyyy = function () {
    var mm = ("0" + (this.getUTCMonth() + 1)).slice(-2)
    var dd = ("0" + this.getUTCDate()).slice(-2);
    var hh = ("0" + this.getUTCHours()).slice(-2);
    var MM = ("0" + this.getUTCMinutes()).slice(-2);

    return dd + '-' + mm + '-' + this.getUTCFullYear() + ' ' + hh + ":" + MM;
};

$(function () {
    function GetLogs() {
        $.get("/Logs/GetLogs", function (data) {
            var donnees = JSON.parse(data);
            $("#notification-list").html("");
            if (Languages.currentLanguage == "en") {
                for (i in donnees) {
                    $("#notification-list").append(
                   "<li class='log popovers' tabindex='0' data-html='true' data-placement='left' data-toggle='popover' data-trigger='focus' title='" + donnees[i][8].Value + "' data-content='<p><strong>ID: </strong>" + donnees[i][2].Value + "</p><p><strong>Name: </strong>" + donnees[i][13].Value + "</p>'><div class='media'><i class='fa fa-" + donnees[i][5].Value + "'></i></div><div class='info'><div class='time'>" + new Date(Date.parse(donnees[i][1].Value)).ddmmyyyy() + "</div><div class='title'>" + donnees[i][3].Value + "</div><div class='desc'>" + donnees[i][6].Value + " " + donnees[i][8].Value + "</div></div></li>"
                );
                }
            }
            else if (Languages.currentLanguage == "fr") {
                for (i in donnees) {
                    $("#notification-list").append(
                   "<li class='log popovers' tabindex='0' data-html='true' data-placement='left' data-toggle='popover' data-trigger='focus' title='" + donnees[i][12].Value + "' data-content='<p><strong>ID: </strong>" + donnees[i][2].Value + "</p><p><strong>Name: </strong>" + donnees[i][13].Value + "</p>'><div class='media'><i class='fa fa-" + donnees[i][5].Value + "'></i></div><div class='info'><div class='time'>" + new Date(Date.parse(donnees[i][1].Value)).ddmmyyyy() + "</div><div class='title'>" + donnees[i][3].Value + "</div><div class='desc'>" + donnees[i][10].Value + " " + donnees[i][12].Value + "</div></div></li>"
                );
                }
            }
            $(".popovers").popover({ container: 'body', trigger: 'hover' });
        });
    }

    //GetLogs();

    /*$(".actuLogs").click(function () {
        GetLogs();
    });

    $("#data-table").DataTable({
        dom: "lBfrtip",
        buttons: ["copy", "csv", "excel", "pdf", "print"],
        responsive: !0,
        autoFill: !0,
        colReorder: !0,
        keys: !0,
        rowReorder: !0,
        bDestroy: true,
        select: !0
    });*/
});

