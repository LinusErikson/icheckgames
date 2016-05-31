$(document).ready(function () {
    $.ajax({
        type: 'GET',
        dataType: 'jsonp',
        crossDomain: true,
        jsonp: 'json_callback',
        url: 'http://www.giantbomb.com/api/game/'+$('#divId').data('myvalue')+'/?format=jsonp',
        data: { api_key: "d46581bb69a487551688b5e5fdc7a93fa8630096" },
        complete: function () {
            console.log('done');
        },
        success: function (data) {
            debugger;
            $('#proJumbo').append('<img src=' + data.results.image.screen_url + '>');
            $('#gameName').html(data.results.name);
            
        }
    })

    
    

    
});


