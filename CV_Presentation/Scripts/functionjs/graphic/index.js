



function resultVote(key) {
    var id = key;
    var abc = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j"];

    $.ajax({
        url: "/ApiGraphic/Report?key=" + id,
        type: "get",
        success: (function (data) {
            console.log(data);

            $("#Lista").html(data[0][0]);
            $("#Respuesta").empty();
            for (var i = 0; i < data[2].length; i++) {
                if (data[2][i] != null) {
                    $("#Respuesta").append("<h3 class='op'>" + abc[i] + ". " + data[2][i] + "<h3>");
                }
            }
            var visible = data[0][5];

            if (visible == "False") {
                $("#chart_div").css("display", "none");
            } else {
                $("#chart_div").css("display", "block");
            }
            setTypeGrafic(data[0][1], data);
        })
    });
}


function loadcHART3D(json) {
    var ruta = "../../App_Data/graphic/" + json[0][4];
    console.log(ruta);
    $('body').css("background-image", "url(../../Resource/" + json[0][4] + ")");

    google.charts.load('current', { packages: ['corechart', 'bar'], callback: drawChart });
    function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Task');
        data.addColumn('number', 'Voto');
        console.log("chart" + json);

        for (var i = 0; i < json[2].length; i++) {
            if (json[2][i] != null) {
                console.log(json[0][i] + i + "red");
                data.addRows([[json[2][i], parseInt(json[3][i])]]);
                //parseInt(json[3][i])
            }
        }

        var options = {
            //title: json[0][0],
            colors: json[1],
            width: json[0][2],
            height: json[0][3],
            // backgroundColor:'transparent',
            is3D: true,
        };

        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
}

function loadColumn(json) {
    console.log("datos" + json[0].length);
    google.charts.load('current', { packages: ['corechart', 'bar'], callback: drawAxisTickColors });

    function drawAxisTickColors() {
        var data = new google.visualization.DataTable();

        data.addColumn('string', 'Opcion');
        data.addColumn('number', 'Voto');
        data.addColumn({ type: 'string', role: "style" })
        data.addColumn({ type: 'string', role: "annotation" })

        for (var i = 0; i < json[2].length; i++) {
            if (json[2][i] != null) {
                console.log(json[0][i] + i + "red");
                data.addRows([[json[2][i], parseInt(json[3][i]), json[1][i], json[2][i]]]);
            }
        }

        var options = {
            title: json[0][0],
            width: json[0][2],
            height: json[0][3],
            //backgroundColor: 'transparent',
            bar: { groupWidth: "95%" },
            legend: { position: "none" },
        };

        var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
}

function setTypeGrafic(type, json) {
    switch (type) {
        case "1":
            loaddrawChart(json);
            break;
        case "2":
            loadSlice(json); loadSlice
            break;
        case "3":
            loadcHART3D(json);
            break;
        case "4":
            loadDonut(json); loadDonut
            break;
        case "5":
            BarChart(json); BarChart
            break;
        case "6":
            BarChart(json);
            break;
        case "7":
            Gauge(json);
    }

}
/*PIE CHART*/
function loaddrawChart(json) {
    google.charts.load('current', { packages: ['corechart'], callback: drawChart });
    function drawChart() {
        var data = new google.visualization.DataTable();

        data.addColumn('string', 'Task');
        data.addColumn('number', 'Voto');
        console.log(json);
        for (var i = 0; i < json[2].length; i++) {
            if (json[2][i] != null) {
                console.log(json[0][i] + i + "red");
                data.addRows([[json[2][i], parseInt(json[3][i])]]);
            }
        }

        var options = {
            title: json[0][0],
            colors: json[1],
            width: json[0][2],
            height: json[0][3]
        };

        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
}


function loadSlice(json) {
    google.charts.load('current', { packages: ['corechart'], callback: drawChart });
    function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Task');
        data.addColumn('number', 'Voto');
        console.log(json);

        for (var i = 0; i < json[2].length; i++) {
            if (json[2][i] != null) {
                console.log(json[0][i] + i + "red");
                data.addRows([[json[2][i], parseInt(json[3][i])]]);
                //parseInt(json[3][i])
            }
        }
        var options = {
            title: json[0][0],
            colors: json[1],
            width: json[0][2],
            height: json[0][3],
            legend: 'none',
            pieSliceText: 'label',
            slices: {
                4: { offset: 0.2 },
                12: { offset: 0.3 },
                14: { offset: 0.4 },
                15: { offset: 0.5 }
            },

        };

        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
}
function loadDonut(json) {
    google.charts.load('current', { packages: ['corechart', 'bar'], callback: drawChart });
    function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Task');
        data.addColumn('number', 'Voto');
        console.log(json);

        for (var i = 0; i < json[2].length; i++) {
            if (json[2][i] != null) {
                console.log(json[0][i] + i + "red");
                data.addRows([[json[2][i], parseInt(json[3][i])]]);
                //parseInt(json[3][i])
            }
        }

        var options = {
            title: json[0][0],
            colors: json[1],
            width: json[0][2],
            height: json[0][3],
            pieHole: 0.4
        };

        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
}


/*BAR CHART */
function BarChart(json) {
    google.charts.load('current', { packages: ['corechart'], callback: drawChart });
    function drawChart() {
        var data = new google.visualization.DataTable();

        data.addColumn('string', 'Opcion');
        data.addColumn('number', 'Voto');
        data.addColumn({ type: 'string', role: "style" })
        data.addColumn({ type: 'string', role: "annotation" })


        for (var i = 0; i < json[2].length; i++) {
            if (json[2][i] != null) {
                console.log(json[0][i] + i + "red");
                data.addRows([[json[2][i], parseInt(json[3][i]), json[1][i], json[2][i]]]);
            }
        }

        var options = {
            title: json[0][0],
            colors: json[1],
            width: json[0][2],
            height: json[0][3],
            bar: { groupWidth: "75%" },
            legend: { position: "none" },
        };
        var chart = new google.visualization.BarChart(document.getElementById("chart_div"));
        chart.draw(data, options);
    }
}