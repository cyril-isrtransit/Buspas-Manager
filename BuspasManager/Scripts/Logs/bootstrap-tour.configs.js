// Instance the tour
$(function () {

    function Init_Tour(){
        var tour = new Tour({
            steps: [
                {
                    element: ".pagination-inverse",
                    title: Languages.Table_Tour,
                    content: Languages.TableContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#data-table_length",
                    title: Languages.DisplayElement_Tour,
                    content: Languages.DisplayElementContent_Tour,
                    backdrop: true,
                    placement: "right",
                    backdropPadding: "0px"
                },
                {
                    element: ".dt-buttons",
                    title: Languages.ExportButon_Tour,
                    content: Languages.ExportButonContent_Tour,
                    backdrop: true,
                    placement: "right",
                    backdropPadding: "0px"
                },
                {
                    element: $(".dataTables_filter").find(".form-control.input-sm"),
                    title: Languages.SearchBar_Tour,
                    content: Languages.SearchBarContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px"
                },
                {
                    element: $(".pagination"),
                    title: Languages.TablePagination_Tour,
                    content: Languages.TablePaginationContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px"
                }
            ],
            storage: false
        });

        tour.init();
        tour.start();

    }

    $("#helper").click(function () {
        Init_Tour();
    });

})
