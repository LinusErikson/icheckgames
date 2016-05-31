
var ids = [];
var id = ['Row' + 1];

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

                    $('#searchResults').append('<tr id='+id+' class=' + 'eztr><td class=' + 'eztd>' + game.name + '<img class=' + 'ezimg' + ' src=' + game.image.icon_url + '>' + '</td></tr>');
                    $('tr').each(function (index) {
                        id.pop();
                        id.push('Row' + (index + 2));
                    });
                    ids.push({ "id": game.id })

                    $('#'+id).click(function () {
                        window.location.href = '/GamePage/GameProfile/3030-';
                    })

                   
                })
              
            }
        })
       
});



   
 




