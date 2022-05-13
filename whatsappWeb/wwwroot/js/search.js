$(function () {
    $('form').submit(e => {
        e.preventDefault();

        const q = $('#search').val();

        $('#tbody').load('/Rankings/Search2?query='+q);
    })
});
