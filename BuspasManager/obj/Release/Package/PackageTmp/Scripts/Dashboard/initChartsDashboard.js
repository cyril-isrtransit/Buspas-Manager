/**
Fichier d'initialisation des graphiques du Dashboard
**/

$(function () {

    // Récupération du count des messages publiés et insertion dans l'objet correspondant à son support
    function GetAll() {
        $.get("GetMediasAll", function (data) {
            var table = $.parseJSON(data);
            $.each(table, function (key, value) {
                Resultat[value.label].all = value.data;
            });
            GetActives(); // Appel de la fonction suivante
        });
    };

    // Récupération du count des messages non-publiés et insertion dans l'objet correspondant à son support
    function GetActives() {
        $.get("GetMediasActives", function (data) {
            var table = $.parseJSON(data);
            $.each(table, function (key, value) {
                Resultat[value.label].actifs = value.data;
            })
            createCharts(); // Appel de la fonction suivante
        });
    };


    // Génération des graphiques
    function createCharts() {
        var colors = [["#531C6A", "#893CA9"], ["#1714A9", "#2682D5"], ["#A43600", "#E06A0A"], ["#0D5543", "#1abc9c"], ["#ff0000", "#d65151"], ["#cdc502", "#ffff8f"]]; // Couples de couleurs possibles
        var count = 0;
        $.each(Resultat, function (index, value) {
            $("#messagesPerMedia").append(
                "<div class='col-sm-6 m-b-20'><div class='chart-summary-container'><div class='chart-title' style='color : " + colors[count][0] + ";'>" + value.description + "</div><div class='row'><div class='col-sm-4'><canvas id='" + value.code.trim() + "' width='55px' height='55px'></canvas></div><div class='col-sm-8'><div class='chart-summary'><div class='text'>" + Languages.TotalMessages1 + " " + value.description + " " + Languages.TotalMessages2 + "</div><div class='number'>" + value.all + "</div></div><div class='chart-summary'><div class='text'>" + Languages.TotalActiveMessages1 + " " + value.description + "  " + Languages.TotalActiveMessages2 + "</div><div class='number'>" + value.actifs + " <small>" + round((value.actifs / value.all) * 100, 2) + " %</small></div></div></div></div></div></div>"
                ); // Génération d'une DIV par support

            var ctx = $("#" + value.code.trim())
            if (value.all > 0) {
                var data = {
                    labels: [
                        Languages.Actives,
                        Languages.Inactives,
                    ],
                    datasets: [
                        {
                            data: [value.actifs, value.all - value.actifs],
                            backgroundColor: [
                                colors[count][0],
                                colors[count][1]
                            ],
                            hoverBackgroundColor: [
                                colors[count][0],
                                colors[count][1]
                            ],
                            borderWidth: 0
                        }]
                };

                var options = {
                    legend: {
                        display: false
                    },
                };
            }
            else { // En cas d'absence de message
                var data = {
                    labels: [
                        Languages.NoMessage
                    ],
                    datasets: [
                        {
                            data: [1],
                            backgroundColor: [
                                "#C0C0C0"
                            ],
                            hoverBackgroundColor: [
                                "#C0C0C0"
                            ],
                            borderWidth: 0
                        }]
                };
                var options = {
                    legend: {
                        display: false
                    },
                    tooltips: {
                        enabled: false
                    },
                };
            }


            var srviChart = new Chart(ctx, {
                type: 'doughnut',

                animation: {
                    animateScale: true
                },
                data: data,
                options: options
            });

            if (count < 5) {
                count++;
            }
            else {
                count = 0;
            }

        });
    }





    function drawChart() {
        var pubs = [];
        var alls = [];

        $.each(categories, function (key, value) {
            pubs.push(resultats[value].pub);
            alls.push(resultats[value].all - resultats[value].pub);
        });




        var data = {
            labels: categories,
            datasets: [
                {
                    label: Languages.Actives,
                    backgroundColor: "rgba(150,255,0,0.2)",
                    borderColor: "rgba(150,255,0,1)",
                    borderWidth: 1,
                    data: pubs
                },
        {
            label: Languages.Inactives,
            backgroundColor: "rgba(255,99,132,0.2)",
            borderColor: "rgba(255,99,132,1)",
            borderWidth: 1,
            data: alls
        }
            ]
        }
        var ctx = $("#messagesPerCategories")

        var myBarChart = new Chart(ctx, {
            type: 'bar',
            data: data,
            options: {
                scales: {
                    xAxes: [{
                        stacked: true
                    }],
                    yAxes: [{
                        stacked: true
                    }]
                }
            }
        });
    }

    // Fonction d'arrondi de nombres
    function round(value, decimals) {
        return Number(Math.round(value + 'e' + decimals) + 'e-' + decimals);
    }

    $.get("GetOutdatedMessages", function (data) {
        var OutdatedMessages = data;
        $("#ActiveOutdatedMessages").html(OutdatedMessages);
        $.get("GetActiveMessages", function (dat) {
            var ActiveMessages = dat;
            $("#ActiveOutdatedMessagespc").html("( " + round(OutdatedMessages / ActiveMessages * 100, 2) + Languages.OfActiveMessages + " )");
            $("#widget-stat-outdated").slideDown("slow");
        });
    });

    //Message inactif dans la plage
    $.get("GetInactiveMessagesInScope", function (data) {
        var InactiveMessagesInScope = data;
        $("#InactiveMessagesInScope").html(InactiveMessagesInScope);
        $.get("GetMessagesInScope", function (dat) {
            var MessagesInScope = dat;
            $("#InactiveMessagesInScopepc").html("( " + round(InactiveMessagesInScope / MessagesInScope * 100, 2) + Languages.OfMessagesInScope + " )");
            $("#widget-stat-inactive").slideDown("slow");
        });

    });

    //Message a activer dans la plage future
    $.get("GetInactiveMessagesInFutureScope", function (data) {
        var InactiveMessagesInFutureScope = data;
        $("#InactiveMessagesInFutureScope").html(InactiveMessagesInFutureScope);
        $.get("GetMessagesInFutureScope", function (dat) {
            var MessagesInFutureScope = dat;

            if (MessagesInFutureScope == 0) {
                var result = 0;
            }
            else {
                var result = InactiveMessagesInFutureScope / MessagesInFutureScope * 100;
            }

            $("#InactiveMessagesInFutureScopepc").html("( " + round(result, 2) + Languages.OfMessagesInFuture + " )");
            $("#widget-stat-future").slideDown("slow");
        });

    });

    //Message actifs en cour de diffusions
    $.get("GetActiveMessagesInScope", function (data) {
        var ActiveMessagesInScope = data;
        
        $("#ActiveMessagesInScope").html(ActiveMessagesInScope);
        $.get("GetActiveMessages", function (dat) {
            var ActiveMessages = $.parseJSON(dat);
            $("#ActiveMessagesInScopepc").html("( " + round(ActiveMessagesInScope / ActiveMessages * 100, 2) + Languages.OfActiveMessages + " )");
            $("#widget-stat-active").slideDown("slow");
        });
    });


    

    //Requete pour remplir le calendrier
    $.get("/Home/GetMessageCalendar", function (data) {
        var event = Array();
        var resultatsAll = $.parseJSON(data);
        
        $.each(resultatsAll, function (key, data) {

            if (data.IS_Valid) {
                var color = '#7ECA85';
            }
            else{
                var color = '#EC595B';
            }
            
            event.push({ title: data.Ticker_Text, Ticker_ID: data.Ticker_ID, color: color, start: data.Start_Time, end: data.Finish_Time, Tiker_URL: data.Tiker_URL, Ticker_Text: data.Ticker_Text, IS_Valid: data.IS_Valid, Tiker_Color: data.Tiker_Color });
        });

        var language = Languages.currentLanguage;

        $("#calendar").fullCalendar({
            locale: language,
            header: {
                left: "month,agendaWeek,agendaDay",
                center: "title",
                right: "prev,today,next "
            },
            droppable: false,
            selectable: false,
            selectHelper: true,
            editable: false,
            eventLimit: !0,
            events: event,
            eventRender: function (event, element) {
                element.attr('href', 'javascript:void(0);');
                element.click(function () {
                    $('#eventContent').modal('show');
                    $("#startTime").html(moment(event.start).format('YYYY-MM-DD'));
                    $("#endTime").html(moment(event.end).format('YYYY-MM-DD'));
                    $("#Ticker_ID").html(event.Ticker_ID);
                    $("#text").html(event.Ticker_Text);
                    $("#eventStatus").html(event.IS_Valid);
                    $("#color").html(event.Tiker_Color);
                    $("#link").html(event.Tiker_URL);
                    $("#eventLink").attr('href', event.Tiker_URL);
                });
            }
        })
    });
})
