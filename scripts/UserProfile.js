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
            $('#realName').html(data[0])

        }
    });

});