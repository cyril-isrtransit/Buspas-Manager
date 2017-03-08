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
                    element: "#add_button",
                    title: Languages.AddButon_Tour,
                    content: Languages.AddButonContent_Tour,
                    backdrop: true,
                    placement: "left",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $('#add-dialog').modal('toggle');
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(2);
                        }, 500);
                    }
                },
                {
                    element: "#add_modal",
                    title: Languages.AddWindow_Tour,
                    content: Languages.ModalUserContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px"
                },
                {
                    element: "#addMono",
                    title: Languages.AddWindow_Tour,
                    content: Languages.AddWindowAdd_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $('#add-dialog').modal('toggle');
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(4);
                        }, 500);
                    }
                },
                {
                    element: "#data-table1_length",
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
                    element: $("#data-table1 th:first-child"),
                    title: Languages.OrderColumn_Tour,
                    content: Languages.OrderColumnContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#data-table1 tbody tr:nth-child(1)").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(8);
                        }, 500);
                    }
                },
                {
                    element: $("#data-table1 tbody tr:nth-child(1)").find(".lockTd"),
                    title: Languages.LockButonChange_Tour,
                    content: Languages.LockButonChangeContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px"
                },
                {
                    element: $("#data-table1 tbody tr:nth-child(1)"),
                    title: Languages.MultiSelect_Tour,
                    content: Languages.MultiSelectContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#buttonForSelection").find(".dropdown-toggle").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(10);
                        }, 500);
                    }
                },
                {
                    element: $("#buttonForSelection"),
                    title: Languages.MultiSelectButon_Tour,
                    content: Languages.MultiSelectButonContent_Tour,
                    backdrop: true,
                    placement: "left",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#data-table1 tbody tr:nth-child(1)").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(11);
                        }, 500);
                    }
                },
                {
                    element: $("#data-table1 tbody tr:nth-child(1)").find(".boutonTd"),
                    title: Languages.EditDeleteButon_Tour,
                    content: Languages.EditDeleteButonContent_Tour,
                    backdrop: true,
                    placement: "left",
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
