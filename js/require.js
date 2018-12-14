$(function () {
    var form = $('#stajForm');    $("#yeniIsyeriIletisim").mask('0 (999) 999 99 99');    var handleSubmitForm = function (e) {
        var response = grecaptcha.getResponse();        if (response.length != 0) {
            var formInput = form.serialize();            $.post(form.attr('action'), formInput, function (data) {
                form.fadeOut("slow", function () {
                    form.before('<div class="mail-message"><p class="mail-head">Teşekkürler!</p><p>Stajınız eklenmiştir.</p></div>');
                });
            });
        }        else {
            var formInput = form.serialize();            $.post(form.attr('action'), formInput, function (data) {
                form.fadeOut("slow", function () {
                    form.before('<div class="mail-message"><p class="mail-head">Doğrulama Hatası !</p><p>Lütfen tekrar deneyiniz.</p></div>');
                });
            });
        }        return false;
    };    form.validate({
        rules: {
            yeniKonu: "required",            yeniIsyeri: "required",            yeniIsyeriAdres: "required",            yeniIsyeriIletisim: "required",            //ContactEmail: {
            //    required: true,            //    email: true
            //},
        },        messages: {
            yeniKonu: "Bu alan gereklidir",            yeniIsyeri: "Bu alan gereklidir",            yeniIsyeriAdres: "Bu alan gereklidir",            yeniIsyeriIletisim: "Bu alan gereklidir",            //ContactEmail: {
            //    required: "Bu alan gereklidir",            //    email: "Eposta adresi gereklidir"
            //},
        },        submitHandler: function (form) {            // some other code            // maybe disabling submit button            // then:            //$(form).submit();            handleSubmitForm();
        },
    });




});