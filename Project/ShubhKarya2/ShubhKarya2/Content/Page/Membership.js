$(document).ready(function () {
    GetMembershipList();
});
var SaveMem = function () {
    debugger
    var id = $("#hdId").val();
    var memberId = $("#ddlMember").val();
    var subscriptionId = $("#dPackage").val();
    var startDate = $("#txtSdate").val();
    var dueDate = $("#txtddate").val();
    var amount = Number($("#txtamount").val());
    var discount = Number($("#txtdiscount").val());
    var totalAmount = amount - discount;
    $("#txttotalAmount").val(totalAmount);

    var model = {
        Id: id,
        MemberId: memberId,
        SubscriptionId: subscriptionId,
        StartDate: startDate,
        DueDate: dueDate,
        Amount: amount,
        Discount: discount,
        TotalAmount: totalAmount
    }
    $.ajax({
        url: "/Membership/SaveMem",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert(response.Message)
            GetMembershipList();
        }
    })
}
var GetMembershipList = function () {
    debugger;

    $.ajax({
        url: "/Membership/GetMembershipList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblMembership tbody").empty();


            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.FullName +
                    "</td><td> " + elementValue.Title +
                    "</td><td>" + elementValue.StartDate +
                    "</td><td>" + elementValue.DueDate +
                    "</td><td>" + elementValue.Amount +
                    "</td><td>" + elementValue.Discount +
                    "</td><td>" + elementValue.TotalAmount +
                    "</td><td>" + elementValue.IsActive +
                    "</td><td><button type='button' class='btn btn-primary btn-sm' onclick='EditMembership(" + elementValue.Id + ")'><i class='bi bi-pencil-square' aria-hidden='true'></i></button>&nbsp;&nbsp;&nbsp;&nbsp;<button type='button' class='btn btn-danger btn-sm' onclick='DeleteMembership(" + elementValue.Id + ")'><i class='bi bi-trash-fill' aria-hidden='true'></i></button>&nbsp;</td></tr>";
            });


            $("#tblMembership tbody").append(html);
        }
    });
};


var DeleteMembership = function (Id) {
    debugger
    var confirmed = confirm("Are you sure you want to delete?");

    if (!confirmed) {
        alert("Deletion canceled.");
        return;
    }
    model = { Id: Id }

    $.ajax({
        url: "/Membership/DeleteMembership",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            GetMembershipList();
        }
    });
}

var EditMembership = function (Id) {
    debugger
    var model = { Id: Id };

    $.ajax({
        url: "/Membership/EditMembership",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {
            $("#staticBackdrop").modal('show');

            $("#hdId").val(response.model.Id);
            $("#ddlMember").val(response.model.MemberId);
            $("#txtMem").val(response.model.subscriptionId);
            $("#txtSdate").val(response.model.StartDate);
            $("#txtddate").val(response.model.DueDate);
            $("#txtamount").val(response.model.Amount);
            $("#txtdiscount").val(response.model.Discount);
            var totalAmount = Number($("#txtamount").val()) - Number($("#txtdiscount").val());
            $("#txttotalAmount").val(totalAmount);
        }
    });
}

