$(document).ready(function () {
    $("#startDateTimePicker").datetimepicker().on('change', function () {
        calculateTotalPrice();
    });

    $("#endDateTimePicker").datetimepicker().on('change', function () {
        calculateTotalPrice();
    });

    $('.service-header-label').on('click', function () {
        $(this)
            .parents('.service-area')
            .find('.service-details')
            .toggle('fast');
    });

    $('.service-cb').on('change', function () {
        var checkBox = $(this);
        var serviceType = checkBox.attr("serviceType");
        $("input[serviceType='" + serviceType + "'")
            .prop("disabled", this.checked);

        checkBox.prop("disabled", false);

        calculateTotalPrice();
    });

    function calculateTotalPrice() {
        var total = 0;
        $.each($("input[serviceType]:checked"), function (idx, value) {
            var totalHours = getTotalHours();
            var cost = parseInt($(value).attr("cost"), 10);
            var totalCost = cost * totalHours;
            total += totalCost;
        });

        $('#total').text(total);
    }

    function getTotalHours() {
        var start = new Date($('#startDateTimePicker').val());
        var end = new Date($('#endDateTimePicker').val());

        var totalHours = (end - start) / 36e5;

        return totalHours;
    }

    jQuery.validator.addMethod('future', function (value, element, params) {
        var now = new Date();
        if (Date.parse(value) < now) {
            return false;
        }
        return true;
    }, '');

    jQuery.validator.unobtrusive.adapters.add('future', function (options) {
        options.rules['future'] = {};
        options.messages['future'] = options.message;
    });

}(jQuery));
