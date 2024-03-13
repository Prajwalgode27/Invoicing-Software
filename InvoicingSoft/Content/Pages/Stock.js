
$(document).ready(function () {
    loadData();
});

function loadData() {
    GetInvoiceList();
    GetStockList();
    TotalStockReport();
    GetExpireStockList();
    GetAvailableStockList();
    GetUnavalibleStockList();
}
var SavePurchesDetails = function () {
    // Gather data from input fields
    var MasterId = $("#hdnMasterId").val();
    var PurchesInvoiceNo = $("#lblPurchesInvoiceNo").val();
    var Quantity = $("#lblTotalPurchesQuantity").val();
    var TaxAmount = $("#lblProductTaxableAmount").val();
    var Discount = $("#lblTotalProductDiscount").val();
    var CGST = $("#lblTotalTotalPurchesCGST").val();
    var SGST = $("#lblTotalPurchesSGST").val();
    var CESS = $("#lblTotalPurchrsCESS").val();
    var OtherCharge = $("#txtPurchesOtherCharcge").val();
    var TotalAmount = $("#lblPurchesTotalAmount").val();

    // Set default value for OtherCharge if empty
    if (OtherCharge === "") {
        OtherCharge = "0";
    }

    // Prepare data object to send in the AJAX request
    var data = {
        MasterId: MasterId,
        PurchesInvoiceNo: PurchesInvoiceNo,
        Quantity: Quantity,
        TaxAmount: TaxAmount,
        Discount: Discount,
        CGST: CGST,
        SGST: SGST,
        CESS: CESS,
        OtherCharge: OtherCharge,
        TotalAmount: TotalAmount,
    };

    // Send AJAX request to save purchase details
    $.ajax({
        url: "/Stock/SavePurchesDetails",
        method: "POST",
        data: JSON.stringify(data),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Handle success response
            alert("Save Successfully");
            // InvoiceResetReset();
            // GetInvoiceList();
        },
        error: function (xhr, status, error) {
            // Handle error response
            console.error(xhr.responseText);
            alert("Error occurred while saving purchase details.");
        }
    });
};

var GetInvoiceList = function () {
    debugger
    var masterId = 1; // Assuming a default value for demonstration
    var model = { MasterId: masterId };

    $.ajax({
        url: "/Stock/GetPurchesList",
        method: "POST",
        data: JSON.stringify(model),
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            var html = "";
            $("#tblpurchesList tbody").empty();
            $.each(response.Message, function (index, element) {
                html += "<tr><td>" + element.PurchesInvoiceNo +
                    "</td><td>" + element.CrateDate +
                    "</td><td>" + element.Quantity +
                    "</td><td>" + element.TotalAmount +
                    "</td><td><button class='btn btn-primary btn-sm' onclick='getOrder(" + element.PurchesInvoiceNo + ")'><i class='bi bi-eye-fill'></i></button></td></tr>";
            });
            $("#tblpurchesList tbody").append(html);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert("Error occurred while fetching invoice list.");
        }
    });
};

var GetStockList = function () {
    // var MasterId = $("#hdnMasterId").val();
    var MasterId = 1; // Assuming a default value for demonstration
    var model = { MasterId: MasterId };

    $.ajax({
        url: "/Stock/GetStockList",
        method: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            var html = "";
            $("#tblStock tbody").empty();
            $.each(response.Message, function (index, element) {
                html += "<tr><td>" + element.Particular + "(" + element.Id + ")" + "</td><td>" + element.PurchesInvoiceNo +
                    "</td><td>" + element.Particular +
                    "</td><td>" + element.MRP +
                    "</td><td>" + element.ExpiryDate +
                    "</td><td>" + element.NetQuantity +
                    "</td><td>" + element.PurchesRate +
                    "</td><td>" + element.Amount +
                    "</td><td>" + element.GST +
                    "</td><td>" + element.CGST +
                    "</td><td>" + element.SGST +
                    "</td><td>" + element.Total + "</td></tr>";
            });
            $("#tblStock tbody").append(html);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert("Error occurred while fetching stock list.");
        }
    });
};
var TotalStockReport = function () {
    var model = {
        MasterId: 1 // Assuming a default value for demonstration
    };

    $.ajax({
        url: "/Stock/TotalStockReport",
        method: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#lblTotalQuantity").text(response.Message.TotalQuantity);
            $("#lblTotalStockAmount").text(parseFloat(response.Message.TotalStockAmount).toFixed(2) + ' ' + "Rs");
            $("#lblTotalStock").text("Stock(" + response.Message.TotalStock + ")Report");
            $("#lblTotalExpireQuantity").text(response.Message.TotalExpireQuantity);
            $("#lblTotalExpireStockAmount").text(parseFloat(response.Message.TotalExpireStockAmount).toFixed(2) + ' ' + "Rs");
            $("#lblTotalExpireStock").text("Expire Stock(" + response.Message.TotalExpireStock + ")Report");
            $("#lblTotalAvailableStockQuantity").text(response.Message.TotalAvailableStockQuantity);
            $("#lblTotalAvailableStockAmount").text(parseFloat(response.Message.TotalAvailableStockAmount).toFixed(2) + ' ' + "Rs");
            $("#lblTotalAvailableStock").text("Available Stock(" + response.Message.TotalAvailableStock + ")Report");
            $("#lblTotalUnAvailableStocky").text("Unavailable Stock (" + response.Message.TotalUnAvailableStock + ")Report");
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert("Error occurred while fetching total stock report.");
        }
    });
};

var GetExpireStockList = function () {
    // var MasterId = $("#hdnMasterId").val();
    var MasterId = 1; // Assuming a default value for demonstration
    var model = { MasterId: MasterId };

    $.ajax({
        url: "/Stock/ExpireStockList",
        method: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            var html = "";
            $("#tblExpireStock tbody").empty();
            $.each(response.Message, function (index, element) {
                html += "<tr><td>" + element.Particular + "(" + element.Id + ")" + "</td><td>" + element.PurchesInvoiceNo +
                    "</td><td>" + element.Particular +
                    "</td><td>" + element.MRP +
                    "</td><td>" + element.ManufacturingDate +
                    "</td><td>" + element.ExpiryDate +
                    "</td><td>" + element.NetQuantity +
                    "</td><td>" + element.PurchesRate +
                    "</td><td>" + element.Amount +
                    "</td><td>" + element.GST +
                    "</td><td>" + element.CGST +
                    "</td><td>" + element.SGST +
                    "</td><td>" + element.Total + "</td></tr>";
            });
            $("#tblExpireStock tbody").append(html);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert("Error occurred while fetching expired stock list.");
        }
    });
};

var GetAvailableStockList = function () {
    // var MasterId = $("#hdnMasterId").val();
    var MasterId = 1; // Assuming a default value for demonstration
    var model = { MasterId: MasterId };

    $.ajax({
        url: "/Stock/GetAvailableStockList",
        method: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            var html = "";
            $("#tblAvailableStock tbody").empty();
            $.each(response.Message, function (index, element) {
                html += "<tr><td>" + element.Particular + "(" + element.Id + ")" + "</td><td>" + element.PurchesInvoiceNo +
                    "</td><td>" + element.Particular +
                    "</td><td>" + element.MRP +
                    "</td><td>" + element.ManufacturingDate +
                    "</td><td>" + element.ExpiryDate +
                    "</td><td>" + element.NetQuantity +
                    "</td><td>" + element.PurchesRate +
                    "</td><td>" + element.Amount +
                    "</td><td>" + element.GST +
                    "</td><td>" + element.CGST +
                    "</td><td>" + element.SGST +
                    "</td><td>" + element.Total + "</td></tr>";
            });
            $("#tblAvailableStock tbody").append(html);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert("Error occurred while fetching available stock list.");
        }
    });
};

var GetUnavalibleStockList = function () {
    // var MasterId = $("#hdnMasterId").val();
    var MasterId = 1; // Assuming a default value for demonstration
    var model = { MasterId: MasterId };

    $.ajax({
        url: "/Stock/GetUnavalibleStockList",
        method: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            var html = "";
            $("#tblGetUnavalibleStockList tbody").empty();
            $.each(response.Message, function (index, element) {
                html += "<tr><td>" + element.Particular +
                    "</td><td><img src='../Content/Pages/image/" + element.ProductImage + "' style='height: 88px; width: 100px; ' alt=''></td><td>" + element.MRP + "</td></tr>";
            });
            $("#tblGetUnavalibleStockList tbody").append(html);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert("Error occurred while fetching unavailable stock list.");
        }
    });
};
function getOrder(PurchesInvoiceNo) {
    window.location.href = "/Product/PurchesProductOrderIndex?PurchesInvoiceNo=" + PurchesInvoiceNo;
}