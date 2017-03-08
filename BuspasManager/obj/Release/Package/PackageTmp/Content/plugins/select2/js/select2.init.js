/**
Script de configuration de select2
**/

$(function () {

    // Initialisation de Select2 pour tous les <select>
    $("select").select2({
        width: "100%",
        minimumResultsForSearch: 6
    });

    $("label select").select2({
        minimumResultsForSearch: 6
    });
    // Modification de la liste code en fonction de la langue et vice versa sur la page languages
    $("#Code").on("select2:close", function (e) {
        $("#Description").val($("#Code").find(":selected").text()).trigger("change");
    });

    $("#Description").on("select2:close", function (e) {
        $("#Code").val($("#Description").find(":selected").text()).trigger("change");
    });

});