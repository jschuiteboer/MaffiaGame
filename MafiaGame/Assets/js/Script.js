function showTileInfo(element) {
    var panel = $('#tile-info-panel');
    var tile = $(element).data('tile');
    var activitiesList = panel.find('#activities');
    var listItem = activitiesList.find('li').first();

    panel.removeClass('hidden');

    panel.find('#name').text(tile.Name);
    panel.find('#type').text(tile.Type);

    activitiesList.empty();

    for(var activity in tile.Activities) {
        listItem.find('#activity')
            .text(activity)
            .attr("href", tile.Activities[activity]);

        listItem.clone().appendTo(activitiesList);
    }
}

$(function() {
    $('#map .tile').click(function() {
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

    showTileInfo($('#map .tile.current').first());
});