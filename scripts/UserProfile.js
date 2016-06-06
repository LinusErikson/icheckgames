
$(document).ready(function () {
    
        $.ajax({
            type: 'GET',
            url: "/Default/getPlayerInfo",
            dataType: 'json',
            success: function (fList) {
                fList = JSON.parse(fList);
                $('#username').text(fList.response.players[0].personaname)
            }
        });

        $.ajax({
            type: 'GET',
            url: "/Default/getRecentGame",
            dataType: 'json',
            success: function (data) {
                data = JSON.parse(data);
                data.response.games.forEach(function (game) {
                    $('#recentlyGame').append('<li>' + game.name + '</li>')
                })
            }
        });


        $.ajax({
            type: 'GET',
            url: "/User/UserInfo",
            dataType: 'json',
            success: function (data) {
               // data = JSON.parse(data);
                debugger;
                    $('#realName').html(data[0])
               
            }
        });
       
});

































//$('#formen').submit(function (e) {
//    console.log('klickat');
//    $.ajax({
//        type: 'GET',
//        dataType: 'jsonp',
//        crossDomain: true,
//        jsonp: 'json_callback',
//        url: 'http://www.giantbomb.com/api/search/?format=jsonp',
//        data: { api_key: "d46581bb69a487551688b5e5fdc7a93fa8630096", query: $("#searchField").val()},
//        complete: function () {
//            console.log('done');
//        },
//        success: function (data) {
//            debugger;
//            data.results.forEach(function (game) {
//                $('#recentlyGame1').append('<li>' + game.name + '</li>');
//                $('#bilder').append('<li><img src=' + game.image.medium_url + '></li>');

//            })
//        }
//    });
//    e.preventDefault();