$.fn.extend({
    tile: function() {
        this.each(function() {
            this.getName = function() {
                return $(this).data('tile-name');
            };

            this.getType = function() {
                return $(this).data('tile-type');
            }
        });

        return this;
    }
});