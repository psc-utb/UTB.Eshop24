$.validator.addMethod('firstlettercapcz',
function (value, element, params)
{
    if (!value || value == '')
        return true;


    const firstChar = value[0];
    if (firstChar.toUpperCase() === firstChar && firstChar.toLowerCase() !== firstChar)
    {
        return true;
    }

    return false;
});


$.validator.unobtrusive.adapters.add('firstlettercapcz', '',
function (options)
{
    var element = $(options.form).find('#Description')[0];

    options.rules['firstlettercapcz'] = [element, ''];
    options.messages['firstlettercapcz'] = options.message;
});
