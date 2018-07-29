$.fn.extend({
    tile: function() {
        this.each(function() {
            this.getName = function() {
                return 'the name of the tile';
            };
        });

        return this;
    }
});