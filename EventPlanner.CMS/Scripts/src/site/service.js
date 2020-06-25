$(document).ready(function () {
    $(".delete-service").on("click", function () {
        var isConfirmed = confirm("Are you sure you want to delete this type?");
        var deleteButton = $(this);
        if (isConfirmed) {
            $.ajax({
                url: "/Service/Delete/" + $(this).attr("data-service-id"),
                method: "post",
                success: function () {
                    deleteButton.parents("tr").remove();
                }
            });
        }
    });
});