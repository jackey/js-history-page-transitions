(function ($) {
    $.fn.ajaxifyLink = function(targetSelector) {
        $(this).click(function () {
            var url = $(this).attr('href');
            $.get(url, function (data) { $(targetSelector).html(data); });

            history.pushState('{ state: true }', 'teh title', url);

            return false;
        });
    }
})(jQuery);