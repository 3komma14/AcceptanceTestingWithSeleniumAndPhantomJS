function getLocation() {
    getData("/Json.aspx");
}

function getData(providerUrl) {
    $("dd").text("");

    var startTime = new Date();
    $.ajax({
        url: providerUrl,
        dataType: "json",
        crossDomain: true
    })
                    .done(function (data) {
                        $("#ip").text(data.ip);
                        $("#country_code").text(data.country_code);
                        $("#country_name").text(data.country_name);
                        $("#region_code").text(data.region_code);
                        $("#region_name").text(data.region_name);
                        $("#city").text(data.city);
                        $("#zipcode").text(data.zipcode);
                        $("#latitude").text(data.latitude);
                        $("#longitude").text(data.longitude);
                        $("#metro_code").text(data.metro_code);
                        $("#areacode").text(data.areacode);

                        var endTime = new Date();
                        $("#ajaxTime").text("Ajax call took: " + Math.abs(endTime.getTime() - startTime.getTime()) + "ms");
                    })
                    .error(function (jqXHR, textStatus, errorThrown) {
                        alert(textStatus);
                    });
}

function getExternalLocation() {
    getData("http://freegeoip.net/json/");
}