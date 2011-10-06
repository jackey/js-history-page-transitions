(function ($) {
    $.fn.ajaxifyLink = function (targetSelector) {
        $(this).click(function () {

            var History = window.History;
            if (!History.enabled) {
                return true;
            }

            var url = $(this).attr('href');
            $.get(url, function (data) { $(targetSelector).html(data); });

            History.pushState('{ state: true }', 'teh title', url);

            return false;
        });
    }
})(jQuery);