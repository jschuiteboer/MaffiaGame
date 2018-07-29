$(function() {
    $('svg.map circle')
        .tile()
        .click(function() {
            $('.panel.tile-info .panel-body')
                .html(this.getName());
        });
});