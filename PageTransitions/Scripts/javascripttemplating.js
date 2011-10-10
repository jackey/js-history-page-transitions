(function ($) {
    $.fn.ajaxifyLink = function (targetSelector) {
        $(this).click(function () {
            var module = $(this).attr('data-module');
            var url = $(this).attr('href');

            var values = [module];

            $.get(url, function (data) {
                require(values, function (js) {
                    js.template(targetSelector, data);
                });
            });

            var state = { module: module, url: url };
            console.log('pushing history', state, url);
            history.pushState(state, 'teh title', url);

            return false;
        });
    }
})(jQuery);