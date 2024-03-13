$(document).ready(function () {
    GetCustomerAccountList();
    $("#txtPaidBalance").keyup(function () {
        debugger
        var total = 0;
        var p = Number($("#txtPreveusBalance").val());
        var q = Number($("#txtPaidBalance").val());
        var total = p - q;
        $("#txtttBalanceAmount").val(parseFloat(total).toFixed(2));
    });
});
var SaveCustomerAccount = function () {

    var checkbox = true;
    if ($("#Active").is(":checked")) {
        checkbox = true;
    }
    else {
        checkbox = false;
    }

    var Id = $("#hdnId").val();
    var MasterId = $("#hdnMasterId").val();
    var CustomerId = $("#hdnCustomerId").val();
    var PreveusBalance = $("#txtttBalanceAmount").val();
    var PaidBalance = $("#txtPaidBalance").val();
    var BalanceAmount = $("#txtttBalanceAmount").val();
    var PaymentMode = $("#txtPaymentMode").val();
    var TransactionNo = $("#txtTransactionNo").val();

    var model = {
        Id: Id,
        MasterId: MasterId,
        CustomerId: CustomerId,
        PreveusBalance: PreveusBalance,
        PaidBalance: PaidBalance,
        BalanceAmount: BalanceAmount,
        PaymentMode: PaymentMode,
        TransactionNo: TransactionNo,
    };

    $.ajax({
        url: "/Account/SaveCustomerAccount",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Paid Sucessfully");
            debugger
            location.href = "/Account/AccountIndex?CustomerId=" + CustomerId;
        }
    });
}
var GetCustomerAccountList = function () {
    debugger
    var CustomerId = $("#hdnCustomerId").val();
    var model = {
        CustomerId: CustomerId,
    
    };
    $.ajax({
        url: "/Account/GetCustomerAccountList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblAccount tbody").empty();
            $.each(response.Message, function (Index, elementvalue) {
                html += "<tr><td>" + elementvalue.CrateDate +
                    "</td><td>" + elementvalue.PreveusBalance +
                    "+" + elementvalue.NewInvoiceAmount + "=" + elementvalue.BalanceAmount + "</td><td>" + elementvalue.PaidBalance + "</td></tr>";
          
            });
            html += "<tr></td><th colspan='2'> Remaning Amount :</th><td>" + response.Message[response.Message.length - 1].BalanceAmount + "</td></tr>";
            $("#tblAccount tbody").append(html);
            if (response.Message.length > 0)
                $('#txtPreveusBalance').val(response.Message[response.Message.length - 1].BalanceAmount);
            else
                $('#txtPreveusBalance').val(0);
        }
    });
}

