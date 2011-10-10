define(['/scripts/text.js!/scripts/Templates/JavascriptTemplating/list.htm',
        '/scripts/text.js!/scripts/Templates/JavascriptTemplating/list_sub.htm'],
        function (template, subtemplate) {
            return {

                template: function (targetSelector, model) {
                    console.log('targetSelector', targetSelector);
                    console.log('element', $(targetSelector));

                    var outerTemplate = _.template(template);
                    var itemTemplate = _.template(subtemplate);

                    var items = '';

                    _.each(model, function (item) {
                        items += itemTemplate(item);
                    });

                    var text = outerTemplate({ model: model, list: items });

                    $(targetSelector).html(text);
                }
            }
        });