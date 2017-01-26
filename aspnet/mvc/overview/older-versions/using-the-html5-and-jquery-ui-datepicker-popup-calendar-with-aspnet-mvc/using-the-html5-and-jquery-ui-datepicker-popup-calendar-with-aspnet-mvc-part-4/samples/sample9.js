if (!Modernizr.inputtypes.date) {
    $(function () {
        $("input[type='date']")
                    .datepicker()
                    .get(0)
                    .setAttribute("type", "text");
    })
}