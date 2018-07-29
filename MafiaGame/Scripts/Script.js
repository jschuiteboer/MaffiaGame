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
    $('svg.map circle')
        .tile()
        .click(function() {
            showTileInfo(this);
        });
});