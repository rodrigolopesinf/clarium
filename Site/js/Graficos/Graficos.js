$(document).ready(function () {
    $.ajax({
        url: "/Administrativa/Home/GetListaData",
        type: 'GET',
        contentType: "application/json; charset=utf-8",

        dataType: 'json'
    }).success(function (data) {
        $('#grafico').highcharts({
            chart: {
                type: 'column',
                options3d: {
                    enabled: true,
                    alpha: 15,
                    beta: 15,
                    viewDistance: 25,
                    depth: 40
                },
                marginTop: 80,
                marginRight: 40
            },

            title: {
                text: 'Gráfico do Total de Pesquisas Realizadas por Mês'
            },

            xAxis: {
                categories: Highcharts.getOptions().lang.shortMonths
            },

            yAxis: {
                allowDecimals: false,
                min: 0,
                title: {
                    text: 'Número de Visitas'
                }
            },

            tooltip: {
                headerFormat: '<b>{point.key}</b><br>',
                pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
            },

            plotOptions: {
                column: {
                    stacking: 'normal',
                    depth: 40
                }
            },

            series: [
                {
                    name: 'Normais',
                    data: data[0],
                    stack: 'Normais'
                },
                {
                    name: 'Avulso',
                    data: data[1],
                    stack: 'Avulso'
                },
                {
                    name: 'Instalação',
                    data: data[2],
                    stack: 'Instalacao'
                },
                {
                    name: 'Retirada',
                    data: data[3],
                    stack: 'Retirada'
                }
            ]

        });
    });
});