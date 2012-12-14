//if (!Modernizr.inputtypes.date) {
//    $(function () {
//        $("input[type='date']")
//                    .datepicker()
//                    .get(0)
//                    .setAttribute("type", "text");
//    })
//}
$(document).ready(function () {
    $('.datefield').datepicker({ dateFormat: "dd/mm/yy" });
});