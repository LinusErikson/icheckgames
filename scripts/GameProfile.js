var gid;
var gName;
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
            $('#proPic').attr('src', data.results.image.super_url);
            $('#gameName').html(data.results.name);
            $('#gameDesc').html(data.results.deck);
            data.results.genres.forEach(function (genre) {
                $('#gameGenre').append('<li>' + genre.name + '</li>')
            });
            data.results.platforms.forEach(function(platform ){
                $('#gamePlatforms').append('<li>' + platform.name + '</li>')
            });
            $('#gameRelease').html(data.results.original_release_date);
            
            data.results.similar_games.forEach(function (sim) {
                $('#gameAlike').append('<li><a href=/gamepage/gameprofile/'+sim.id+'>' + sim.name + '</a></li>')
             
            })
            gid = data.results.id;
            gName = data.results.name;
        }
    })

    
    $('#checkButton').click(function () {
        $('#checkButton').attr("value", gName+'/' + gid)
    })

    $('#listButton').click(function () {
        $('#listButton').attr("value", gName + '/' + gid)
    })

    
});


