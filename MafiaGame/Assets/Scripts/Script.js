var tileInfoPanel = $('#tile-info-panel');

function showTileInfo(tile) {
    var properties = {
        name: tile.getName(),
        type: tile.getType(),
    }

    var container = tileInfoPanel.find('#row-container');
    var template = tileInfoPanel.find('#row-template').html();

    container.empty();

    $.each(properties, function(k, v) {
        var row = $(template);

        row.find('#label').html(k);
        row.find('#value').html(v);

        container.append(row);
    });
}

$(function() {
    $('#map circle')
        .tile()
        .click(function() {
            showTileInfo(this);
        });
    
    $('#map').on('mousemove', function(e) {
        if(e.buttons) {
            var elem = $(this);
            var viewBox = elem.attr('viewBox').match(/\S+/g);

            viewBox[0] = Number(viewBox[0]) - e.originalEvent.movementX / (elem.width() / Number(viewBox[2]));
            viewBox[1] = Number(viewBox[1]) - e.originalEvent.movementY / (elem.height() / Number(viewBox[3]));
            
            $(this).attr('viewBox', viewBox.join(' '));
        }
    });
});