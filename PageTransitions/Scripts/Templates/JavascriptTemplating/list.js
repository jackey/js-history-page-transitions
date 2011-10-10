define(['/scripts/text.js!/scripts/Templates/JavascriptTemplating/list.htm'], function (template) {
    return {

        template: function (targetSelector, model) {
            console.log('targetSelector', targetSelector);
            console.log('element', $(targetSelector));

            var compiled = _.template(template);
            var text = compiled(model);
            console.log('text of list', text);

            $(targetSelector).html(text);
        }
    }
});