$(document).ready(function () {
    $(".delete-event-type").on("click", function () {
        var isConfirmed = confirm("Are you sure you want to delete this type?");
        var deleteButton = $(this);
        if (isConfirmed) {
            $.ajax({
                url: "/EventType/Delete/" + $(this).attr("data-event-type-id"),
                method: "post",
                success: function () {
                    deleteButton.parents("tr").remove();
                }
            });
        }
    });


    $(".delete-service-type").on("click", function () {
        var isConfirmed = confirm("Are you sure you want to delete this type?");
        var deleteButton = $(this);
        if (isConfirmed) {
            $.ajax({
                url: "/ServiceType/Delete/" + $(this).attr("data-service-type-id"),
                method: "post",
                success: function () {
                    deleteButton.parents("tr").remove();
                }
            });
        }
    });

    $(".delete-place").on("click", function () {
        var isConfirmed = confirm("Are you sure you want to delete this type?");
        var deleteButton = $(this);
        if (isConfirmed) {
            $.ajax({
                url: "/Place/Delete/" + $(this).attr("data-place-id"),
                method: "post",
                success: function () {
                    deleteButton.parents("tr").remove();
                }
            });
        }
    });

    
});