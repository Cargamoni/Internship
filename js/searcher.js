    $(document).ready(function () {
        function Contains(text_one, text_two) {
            if (text_one.indexOf(text_two) != -1)
                return true;
        }
        $("#searcher").keyup(function () {
            var searchText = $("#searcher").val().toLocaleLowerCase();
            $(".searchThese").each(function () {
                if (!Contains($(this).text().toLocaleLowerCase(), searchText)) {
                    $(this).hide();
                }
                else {
                    $(this).show();
                }
            });
        });
    });
