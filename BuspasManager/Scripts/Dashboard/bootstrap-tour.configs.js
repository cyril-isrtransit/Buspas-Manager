// Instance the tour
$(function () {

function Init_Tour(){
    var tour = new Tour({
    steps: [
        {
            element: $("#sidebar"),
            title: Languages.SidebarMenu_Tour,
            content: Languages.SidebarMenuContent_Tour,
            backdrop: true,
            placement: "right",
            backdropPadding: "0px",
            onNext: function () {
                tour.end();
                $(".sidebar-minify-btn").trigger("click");
                setTimeout(function () {
                    tour.restart();
                    tour.goTo(1);
                }, 500);
            }
        },
        {
            element: $("a.sidebar-minify-btn"),
            title: Languages.SidebarMenuButon_Tour,
            content: Languages.SidebarMenuButonContent_Tour,
            backdrop: false,
            placement: "right",
            backdropPadding: "0px",
            onNext: function () {
                tour.end();
                $(".sidebar-minify-btn").trigger("click"); 
                $(".navbar-user").find(".dropdown-toggle").trigger("click");
                setTimeout(function () {
                    tour.restart();
                    tour.goTo(2);
                }, 500);
            }
        },
        {
            element: $(".navbar-user").find("ul.dropdown-menu"),
            title: Languages.UserMenu_Tour,
            content: Languages.UserMenuContent_Tour,
            backdrop: false,
            placement: "left",
            backdropPadding: "0px",
            onNext: function () {
                tour.end();
                $("#profileDialog").trigger("click");
                setTimeout(function () {
                    tour.restart();
                    tour.goTo(3);
                }, 500);
            }
        },
        {
            element: $("#profile-dialog").find(".modal-dialog"),
            title: Languages.DialogProfil_Tour,
            content: Languages.DialogProfilContent_Tour,
            backdrop: true,
            placement: "left",
            backdropPadding: "0px",
            onNext: function () {
                tour.end();
                $('#profile-dialog').modal('toggle');
                setTimeout(function () {
                    tour.restart();
                    tour.goTo(4);
                }, 500);
            }
        },
        {
            element: $(".fa-align-left"),
            title: Languages.LogButon_Tour,
            content: Languages.LogButonContent_Tour,
            backdrop: false,
            placement: "left",
            backdropPadding: "0px"
        },
        {
            element: $(".btn-scroll-to-top"),
            title: Languages.TopButon_Tour,
            content: Languages.TopButonContent_Tour,
            backdrop: false,
            placement: "left",
            backdropPadding: "0px"
        },
        {
            element: "#statsRow",
            title: Languages.Statistics,
            content: Languages.StatisticsHelper,
            backdrop: true,
            placement: "bottom",
            backdropPadding: "0px"
        },
        {
            element: "#widget-stat-inactive",
            title: Languages.InactiveMessagesInRange,
            content: Languages.InactiveMessagesInRangeText,
            backdrop: true,
            placement: "bottom",
            backdropPadding: "0px"
        },
        {
            element: "#widget-stat-future",
            title: Languages.InactiveInFuture,
            content: Languages.InactiveInFutureText,
            backdrop: true,
            placement: "bottom",
            backdropPadding: "0px"
        },

        {
            element: "#widget-stat-outdated",
            title: Languages.OutdatedMessages,
            content: Languages.OutdatedMessagesText,
            backdrop: true,
            placement: "bottom",
            backdropPadding: "0px"
        },
        {
            element: "#widget-stat-active",
            title: Languages.ActiveMessagesInRange,
            content: Languages.ActiveMessagesInRangeText,
            backdrop: true,
            placement: "bottom",
            backdropPadding: "0px"
        },
        {
            element: "#messagesCategories",
            title: Languages.MessagesPerCategory,
            content: Languages.MessagesPerCategoryText,
            backdrop: true,
            placement: "right",
            backdropPadding: "0px"
        },
        {
            element: "#activeMedias",
            title: Languages.ActiveMessagesPerSupport,
            content: Languages.ActiveMessagesPerSupportText,
            backdrop: true,
            placement: "left",
            backdropPadding: "0px"
        },
        {
            element: "#calendarmessages",
            title: Languages.CalendarMessages,
            content: Languages.CalendarMessagesContent,
            backdrop: true,
            placement: "top",
            backdropPadding: "0px"
        },
        {
            element: "#currentmessages",
            title: Languages.CurentMessages,
            content: Languages.CurentMessagesText,
            backdrop: true,
            placement: "top",
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
