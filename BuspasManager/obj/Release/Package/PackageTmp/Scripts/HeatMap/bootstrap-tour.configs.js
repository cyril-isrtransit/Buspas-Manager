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
                        $("#general_tour").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(2);
                        }, 500);
                    }
                },
                {
                    element: "#add_modal",
                    title: Languages.ModalAddMessage_Tour,
                    content: Languages.ModalAddMessageContent_Tour,
                    backdrop: true,
                    placement: "left",
                    backdropPadding: "0px"
                },
                {
                    element: "#PredefinedMessages",
                    title: Languages.SelectPredefMessage_Tour,
                    content: Languages.SelectPredefMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#Title",
                    title: Languages.SelectTitleMessage_Tour,
                    content: Languages.SelectTitleMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#CategorieID",
                    title: Languages.SelectCategorieMessage_Tour,
                    content: Languages.SelectCategorieMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#StatusCode",
                    title: Languages.SelectStatusMessage_Tour,
                    content: Languages.SelectStatusMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#SendingPriority",
                    title: Languages.SelectSendingMessage_Tour,
                    content: Languages.SelectSendingMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#datepicker-disabled-past",
                    title: Languages.SelectDateRangeMessage_Tour,
                    content: Languages.SelectDateRangeMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: ".pager.bwizard-buttons",
                    title: Languages.BtnNavigationBottomMessage_Tour,
                    content: Languages.BtnNavigationBottomMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: ".bwizard-steps",
                    title: Languages.BtnNavigationTopMessage_Tour,
                    content: Languages.BtnNavigationTopMessageContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#schedule_tour").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(11);
                        }, 500);
                    }
                },
                {
                    element: "#table_schedule_tour",
                    title: Languages.ScheduleMessage_Tour,
                    content: Languages.ScheduleMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#text_tour").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(12);
                        }, 500);
                    }
                },
                {
                    element: "#text_language_code",
                    title: Languages.SelectLanguageTextMessage_Tour,
                    content: Languages.SelectLanguageTextMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#addRowText",
                    title: Languages.SelectAddRowTextMessage_Tour,
                    content: Languages.SelectAddRowTextMessageContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px"
                },
                {
                    element: "#tableTextMessages",
                    title: Languages.TableTextMessage_Tour,
                    content: Languages.TableTextMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#delRowText",
                    title: Languages.SelectDelRowTextMessage_Tour,
                    content: Languages.SelectDelRowTextMessageContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#audio_tour").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(16);
                        }, 500);
                    }
                },
                {
                    element: "#LanguageCodeAddAudio",
                    title: Languages.SelectLanguageAudioMessage_Tour,
                    content: Languages.SelectLanguageAudioMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#addRow",
                    title: Languages.SelectAddRowAudioMessage_Tour,
                    content: Languages.SelectAddRowAudioMessageContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px"
                },
                {
                    element: "#tableAudioMessages",
                    title: Languages.TableAudioMessage_Tour,
                    content: Languages.TableAudioMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#delRow",
                    title: Languages.SelectDelRowAudioMessage_Tour,
                    content: Languages.SelectDelRowAudioMessageContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#broadcast_tour").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(20);
                        }, 500); 
                    }
                },
                {
                    element: "#tableBroadcastMedias",
                    title: Languages.TableBroadcastMessage_Tour,
                    content: Languages.TableBroadcastMessageContent_Tour,
                    backdrop: true,
                    placement: "bottom",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#addBroadcastButton").trigger("click");
                        $("#Tab_VMS_Add_Link").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(21);
                        }, 500); 
                    }
                },
                {
                    element: $("#SupportCodeAdd"),
                    title: Languages.SelectBroadcastMediaMessage_Tour,
                    content: Languages.SelectBroadcastMediaMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#Tab_VMS_Add_Link",
                    title: Languages.TabVMSMessage_Tour,
                    content: Languages.TabVMSMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#Frequency",
                    title: Languages.SelectFrequencyMessage_Tour,
                    content: Languages.SelectFrequencyMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#data-table-VMS",
                    title: Languages.TableVMSMessage_Tour,
                    content: Languages.TableVMSMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#buttonCancelBroadcast",
                    title: Languages.BtnCancelMessage_Tour,
                    content: Languages.BtnCancelMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#buttonDownloadBrightSign",
                    title: Languages.BtnDownloadBrightSignMessage_Tour,
                    content: Languages.BtnDownloadBrightSignMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#buttonAddBroadcast",
                    title: Languages.BtnAddBroadcastMessage_Tour,
                    content: Languages.BtnAddBroadcastMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#Tab_Stop_Add_Link").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(28);
                        }, 500);
                    }
                },
                {
                    element: "#Tab_Stop_Add",
                    title: Languages.TabStopMessage_Tour,
                    content: Languages.TabStopMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#distance_stop",
                    title: Languages.SelectDistanceStopMessage_Tour,
                    content: Languages.SelectDistanceStopMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#select_stop_tour",
                    title: Languages.SelectStop_Tour,
                    content: Languages.SelectStopContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#Tab_Route_Add_Link").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(31);
                        }, 500);
                    }
                },
                {
                    element: "#Tab_Route_Add",
                    title: Languages.TabRouteMessage_Tour,
                    content: Languages.TabRouteMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: $("#RouteSelect2"),
                    title: Languages.SelectRouteMessage_Tour,
                    content: Languages.SelectRouteMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#addRouteRow",
                    title: Languages.SelectAddRowRouteMessage_TOur,
                    content: Languages.SelectAddRowRouteMessageContent_TOur,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#data-table-add-route_wrapper",
                    title: Languages.TableRouteMessage_Tour,
                    content: Languages.TableRouteMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#delRouteRow",
                    title: Languages.SelectDelRowRouteMessage_Tour,
                    content: Languages.SelectDelRowRouteMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#frequence_route",
                    title: Languages.SelectDistanceRouteMessage_Tour,
                    content: Languages.SelectDistanceRouteMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#Tab_Trigger_Add_Link").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(37);
                        }, 500);
                    }
                },
                {
                    element: "#Tab_Trigger_Add",
                    title: Languages.TabTriggerMessage_Tour,
                    content: Languages.TabTriggerMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#data-table-add-Audio",
                    title: Languages.TableTriggerMessage_Tour,
                    content: Languages.TableTriggerMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#Tab_Mobile_Add_Link").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(39);
                        }, 500);
                    }
                },
                {
                    element: "#Tab_Mobile_Add",
                    title: Languages.TabMobileMessage_Tour,
                    content: Languages.TabMobileMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#social_tour").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(40);
                        }, 500);
                    }
                },
                {
                    element: "#social_table",
                    title: Languages.TableSocialMessage_Tour,
                    content: Languages.TableSocialMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px"
                },
                {
                    element: "#submit_add_message",
                    title: Languages.BtnAddMessage_Tour,
                    content: Languages.BtnAddMessageContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $('#add-dialog').modal('toggle');
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(42);
                        }, 500);
                    }
                },
                {
                    element: "#messagesTable_length",
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
                    element: $("#messagesTable th:first-child"),
                    title: Languages.OrderColumn_Tour,
                    content: Languages.OrderColumnContent_Tour,
                    backdrop: true,
                    placement: "top",
                    backdropPadding: "0px",
                    onNext: function () {
                        tour.end();
                        $("#messagesTable tbody tr:nth-child(1)").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(46);
                        }, 500);
                    }
                },
                {
                    element: $("#messagesTable tbody tr:nth-child(1)"),
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
                            tour.goTo(47);
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
                        $("#messagesTable tbody tr:nth-child(1)").trigger("click");
                        setTimeout(function () {
                            tour.restart();
                            tour.goTo(48);
                        }, 500);
                    }
                },
                {
                    element: $("#messagesTable tbody tr:nth-child(1)").find(".boutonTd"),
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
