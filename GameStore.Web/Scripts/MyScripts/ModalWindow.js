
    $(document).ready(function () {
        $('#Add').click(function (event) {
            event.preventDefault();
            $.get(this.href, function (response) {
                $('.divForAdd').html(response);
            });
            $('#Add-Model').modal({
                backdrop: 'static',
            }, 'show');
        });
        $('.editDialog').click(function (event) {
            event.preventDefault();
            $.get(this.href, function (response) {
                $('.divForUpdate').html(response);
            });
            $('#Edit-Model').modal({
                backdrop: 'static',
            }, 'show');
        });
    });
