var click = false;
var path = '~/css/';

$('#css_toggle').on('click', function () {
    if (!click) {
        $('link[href*="style.css"]').attr('href', path + 'bootswatchDark.css');
        click = true;
        console.log('changed to bootswatchDark.css');
    } else {
        $('link[href*="style1.css"]').attr('href', path + 'bootswatchLight.css');
        click = false;
        console.log('changed to bootswatchLight.css');
    }
});