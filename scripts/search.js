$(document).ready(function () {
        $.ajax({
            type: 'GET',
            dataType: 'jsonp',
            crossDomain: true,
            jsonp: 'json_callback',
            url: 'http://www.giantbomb.com/api/search/?format=jsonp',
            data: { api_key: "d46581bb69a487551688b5e5fdc7a93fa8630096", query: $('#myValue').val() },
            complete: function () {
                console.log('done');
            },
            success: function (data) {
                data.results.forEach(function (game) {
                   
                    var url = "/gamepage/gameprofile/" + game.id;
                    $('#searchResults').append('<tr data-href='+url+' class=' + 'eztr><td class=' + 'eztd>' + game.name + '<img class=' + 'ezimg' + ' src=' + game.image.icon_url + '>' + '</td></tr>');

                    $('.eztr').click(function () {
                        window.location = $(this).data("href");
                    })

                })
              
            }
        })
       
});



   
 




