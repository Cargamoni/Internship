﻿$(function () {
    var form = $('#stajForm');
        var response = grecaptcha.getResponse();
            var formInput = form.serialize();
                form.fadeOut("slow", function () {
                    form.before('<div class="mail-message"><p class="mail-head">Teşekkürler!</p><p>Stajınız eklenmiştir.</p></div>');
                });
            });
        }
            var formInput = form.serialize();
                form.fadeOut("slow", function () {
                    form.before('<div class="mail-message"><p class="mail-head">Doğrulama Hatası !</p><p>Lütfen tekrar deneyiniz.</p></div>');
                });
            });
        }
    };
        rules: {
            yeniKonu: "required",
            //    required: true,
            //},
        },
            yeniKonu: "Bu alan gereklidir",
            //    required: "Bu alan gereklidir",
            //},
        },
        },
    });




});