$('#OrganizationId').change(function () {
    var OrganizationId = $(this).val();
    if (OrganizationId == "") {
        $("#BranchId").empty();
        var option = "<option value=''>Select...</option>";
        $("#BranchId").append(option);
        return;
    }
    var jsonData = { organizationId: OrganizationId }
    $.ajax({
        url: "/Branch/GetBranchByOrganization",
        type: "POST",
        data: JSON.stringify(jsonData),
        contentType: "application/json",
        success: function (response) {
            $("#BranchId").empty();
            var option = "<option value=''>Select...</option>";
            $("#BranchId").append(option);
            $.each(response, function (key, value) {
                var optionText = "<option value='" + value.Id + "'>" + value.Name + "</option>";
                $("#BranchId").append(optionText);
            });
        }

    });
});