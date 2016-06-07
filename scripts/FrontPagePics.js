$(document).ready(function () {
    $.ajax({
        type: 'GET',
        dataType: 'jsonp',
        crossDomain: true,
        jsonp: 'json_callback',
        url: 'http://www.giantbomb.com/api/game/' + $('#pic1').data('pic1') + '/?format=jsonp',
        data: { api_key: "d46581bb69a487551688b5e5fdc7a93fa8630096" },
        complete: function () {
            console.log('done');
        },
        success: function (data) {
            debugger;
            $('#imgOne').attr('src',data.results.image.super_url);
            
        }
    })
    $.ajax({
        type: 'GET',
        dataType: 'jsonp',
        crossDomain: true,
        jsonp: 'json_callback',
        url: 'http://www.giantbomb.com/api/game/' + $('#pic2').data('pic2') + '/?format=jsonp',
        data: { api_key: "d46581bb69a487551688b5e5fdc7a93fa8630096" },
        complete: function () {
            console.log('done');
        },
        success: function (data) {
            debugger;
            $('#imgTwo').attr('src', data.results.image.super_url);

        }
    })
    $.ajax({
        type: 'GET',
        dataType: 'jsonp',
        crossDomain: true,
        jsonp: 'json_callback',
        url: 'http://www.giantbomb.com/api/game/' + $('#pic3').data('pic3') + '/?format=jsonp',
        data: { api_key: "d46581bb69a487551688b5e5fdc7a93fa8630096" },
        complete: function () {
            console.log('done');
        },
        success: function (data) {
            debugger;
            $('#imgThree').attr('src', data.results.image.super_url);

        }
    })
    $.ajax({
        type: 'GET',
        dataType: 'jsonp',
        crossDomain: true,
        jsonp: 'json_callback',
        url: 'http://www.giantbomb.com/api/game/' + $('#pic4').data('pic4') + '/?format=jsonp',
        data: { api_key: "d46581bb69a487551688b5e5fdc7a93fa8630096" },
        complete: function () {
            console.log('done');
        },
        success: function (data) {
            debugger;
            $('#imgFour').attr('src', data.results.image.super_url);

        }
    })

});