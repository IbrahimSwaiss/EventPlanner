$(document).ready(function () {
    $(".delete-place-type").on("click", function () {
        // confirmation
        var isConfirmed = confirm("Are you sure you want to delete this type?");
        var deleteButton = $(this);
        if (isConfirmed) {
            $.ajax({
                url: "/PlaceType/Delete/" + $(this).attr("data-place-type-id"),
                method: "post",
                success: function () {
                    deleteButton.parents("tr").remove();
                },
                error: function () {
                    alert("error on delete");
                }
            });
        }
    });
});