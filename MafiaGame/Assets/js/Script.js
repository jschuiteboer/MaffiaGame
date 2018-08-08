$(function() {
    const mapElement = $('#map');
    const tileInfoPanelElement = $('#tile-info-panel');

    function showTileInfo(tileElement) {
        var tile = $(tileElement).data('tile');
        var activitiesList = tileInfoPanelElement.find('#activities');
        var listItem = activitiesList.find('li').first();

        tileInfoPanelElement.removeClass('hidden');

        tileInfoPanelElement.find('#name').text(tile.Name);
        tileInfoPanelElement.find('#type').text(tile.Type);

        activitiesList.empty();

        for(var activity in tile.Activities) {
            listItem.find('#activity')
                .text(activity)
                .attr("href", tile.Activities[activity]);

            listItem.clone().appendTo(activitiesList);
        }
    }

    function setCameraPosition(x, y) {
        mapElement.find('#camera-offset')
            .attr('transform', 'translate(' + x + ',' + y + ')');
    }

    var camPos = { x: 0, y: 0 };

    mapElement.find('.tile').click(function() {
        showTileInfo(this);
    });
    
    mapElement.on('mousemove', function(e) {
        if(e.buttons) {
            camPos.x += e.originalEvent.movementX;
            camPos.y += e.originalEvent.movementY;

            setCameraPosition(camPos.x, camPos.y);
        }
    });

    showTileInfo($('#map .tile.current').first());
});