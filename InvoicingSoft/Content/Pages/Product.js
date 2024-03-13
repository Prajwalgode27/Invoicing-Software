
$(document).ready(function () {
    // Initialize functions
    GetallPurchessorderbyInvoiceNo();
    GetPurchesordertList();
    GetPurchesInvoiceId();

    // Event handlers
    $("#txtPQty").keyup(function () {
        calculateTotal();
    });

    $("#txtPDiscount").keyup(function () {
        calculateTotal();
    });

    $("#txtCess").keyup(function () {
        calculateTotal();
    });

    $("#txtPurchesOtherCharcge").keyup(function () {
        updateTotalAmount();
    });

    // Autocomplete
    $("#txtPParticular").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Product/purchespruductSearch",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term},
                success: function (data) {
                    if (data.hasOwnProperty('Error')) {
                        // Handle error
                        return;
                    }
                    response($.map(data.Message, function (item) {
                        return {
                            label: item.CustomerName,
                            value: item.CustomerName,
                            id: item.Id,
                            mobile: item.Mobile,
                            gstno: item.GSTNo,
                            address: item.Address,
                            city: item.City,
                            state: item.State,
                            zipcode: item.ZipCode,
                        };
                    }));
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    // Handle error
                }
            });
        },
        minLength: 3,
        select: function (event, ui) {
            // Set values
            $("#txtMobile").val(ui.item.mobile);
            $("#txtAddress").val(ui.item.address);
            $("#txtGSTNo").val(ui.item.gstno);
            $("#txtEmail").val(ui.item.email);
            $("#txtBItemName").focus();
            $("#hdncustomerId").val(ui.item.id);
            $("#txtCity").val(ui.item.city);
            $("#txtState").val(ui.item.state);
            $("#txtZipCode").val(ui.item.zipcode);
        }
    });
});

// Calculate total amount
function calculateTotal() {
    var rate = parseFloat($("#txtPPurchesRate").val()) || 0;
    var qty = parseFloat($("#txtPQty").val()) || 0;
    var gst = parseFloat($("#txtPGST").val()) || 0;
    var disc = parseFloat($("#txtPDiscount").val()) || 0;

    var totprice = rate * qty;
    var discvalue = (totprice * disc) / 100;
    var subtotal = totprice - discvalue;
    var gstvalue = (subtotal * gst) / 100;
    var totalamt = subtotal + gstvalue * 2;

    $("#txtPAmount").val(totprice.toFixed(2));
    $("#txtPCGST").val((gstvalue / 2).toFixed(2));
    $("#txtPSGST").val((gstvalue / 2).toFixed(2));
    $("#txtPtotal").val((subtotal + gstvalue).toFixed(2));
}

// Update total amount
function updateTotalAmount() {
    var r = parseFloat($("#hdnPurchesTotalAmount").val()) || 0;
    var q = parseFloat($("#txtPurchesOtherCharcge").val()) || 0;
    var amt = r + q;
    $("#lblPurchesTotalAmount").val(amt.toFixed(2));
}
var GetPurchesInvoiceId = function () {
    debugger;
    $.ajax({
        url: "/Stock/GetPurchesInvoiceId",
        method: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.hasOwnProperty('Message')) {
                var invoiceNo = response.Message;
                $("#lblPurchesInvoiceNo").val(invoiceNo);
                GetPurchesordertList(invoiceNo);
                TotalPurchesOrderTotal(invoiceNo);
            } else {
                // Handle error or unexpected response
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            // Handle error
        }
    });
};
var SaveProductOrder = function () {
    debugger

    $formData = new FormData();
    var ProductImage = document.getElementById('File1');
    if (ProductImage.files.length > 0) {
        for (var i = 0; i < ProductImage.files.length; i++) {
            $formData.append('File-' + i, ProductImage.files[i]);
        }

    }
    var checkbox = true;
    if ($("#Active").is(":checked")) {
        checkbox = true;
    }
    else {
        checkbox = false;
    }

    var MasterId = $("#hdnMasterId").val();
    var Id = $("#hdnpId").val();
    var PurchesInvoiceNo = $("#lblPurchesInvoiceNo").val();
    var Particular = $("#txtPParticular").val();
    var HSN = $("#txtPHSN").val();
    var UOM = $("#txtPUOM").val();
    var GST = $("#txtPGST").val();
    var MRP = $("#txtPMRP").val();
    var PurchesRate = $("#txtPPurchesRate").val();
    var SellingRate = $("#txtPSellingRate").val();
    var Quantity = $("#txtPQty").val();
    var Amount = $("#txtPAmount").val();
    var Discount = $("#txtPDiscount").val();
    var CGST = $("#txtPCGST").val();
    var SGST = $("#txtPSGST").val();
    var Cess = $("#txtPCess").val();
    var Total = $("#txtPtotal").val();
    var NetQuantity = $("#txtNetQuantity").val();
    var ManufacturingDate = $("#txtPManufacturingDate").val();
    var ExpiryDate = $("#txtPExpiryDate").val();
    var IsExpire = checkbox;

    if (Quantity == "") {
        alert("please Enter Particular");
        $("txtQty").focus();
        return false;
    }

    $formData.append('MasterId', MasterId);
    $formData.append('Id', Id);
    $formData.append('PurchesInvoiceNo', PurchesInvoiceNo);
    $formData.append('Particular', Particular);
    $formData.append('ProductImage', ProductImage);
    $formData.append('HSN', HSN);
    $formData.append('UOM', UOM);
    $formData.append('GST', GST);
    $formData.append('MRP', MRP);
    $formData.append('PurchesRate', PurchesRate);
    $formData.append('SellingRate', SellingRate);
    $formData.append('Quantity', Quantity);
    $formData.append('Amount', Amount);
    $formData.append('Discount', Discount);
    $formData.append('CGST', CGST);
    $formData.append('SGST', SGST);
    $formData.append('Cess', Cess);
    $formData.append('Total', Total);
    $formData.append('NetQuantity', NetQuantity);
    $formData.append('ManufacturingDate', ManufacturingDate);
    $formData.append('ExpiryDate', ExpiryDate);
    $formData.append('IsExpire', IsExpire);

    $.ajax({
        url: "/Product/PurchesStockOrder",
        method: "post",
        data: $formData,
        contentType: "application/json;charset=utf-8",
        contentType: false,
        processData: false,
        return: false,
        async: false,
        success: function (response) {
            GetPurchesordertList(response.Message)

            alert("Data Add Sucessfully");
        }
    });
}
var GetPurchesordertList = function () {
    var PurchesInvoiceNo = $("#lblPurchesInvoiceNo").val();
    var model = {
        MasterId: 1,
        PurchesInvoiceNo: PurchesInvoiceNo
    };

    $.ajax({
        url: "/Product/GetProductListByInvoiceNo",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            var html = "";
            $("#purchesorder").empty();
            $.each(response.Message, function (Index, elementvalue) {
                html += "<div class='post-item clearfix' onclick='toggleRowSelection(this)' data-product-id='" + elementvalue.Id + "'>";
                html += "<img src='../Content/Pages/image/" + elementvalue.ProductImage + "' alt='' data-product-id='" + elementvalue.Id + "'>";
                html += " <h4><a href=''>" + elementvalue.Particular + " MRP Rs" + elementvalue.MRP + " Rs</a></h4>";
                html += "<p>Expire Date:" + elementvalue.ExpiryDate + " Manufacturing Date" + elementvalue.ManufacturingDate + " Rate " + elementvalue.PurchesRate + " Rs GST " + elementvalue.GST + " %</p>";
                html += "</div>";
            });
            $("#purchesorder").append(html);
        }
    });
}
function toggleRowSelection(row) {
    $(row).toggleClass('selected');
}
function selectAllItems() {
    $('.post-item').addClass('selected');
}
function deleteSelected() {
    debugger
    var selectedItems = $('.selected');
    if (selectedItems.length === 0) {
        alert("Please select items to delete.");
        return;
    }
    var productIds = [];
    selectedItems.each(function () {
        var productId = $(this).data('product-id');
        if (productId !== undefined && productId !== null) {
            productIds.push(productId);
        }
    });
    if (productIds.length === 0) {
        alert("No valid product IDs selected for deletion.");
        return;
    }
    var dataToSend = {
        productIds: productIds
    };
    $.ajax({
        url: "/Product/DeletePurchesProduct",
        method: "post",
        data: JSON.stringify(dataToSend),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log('Selected items deleted successfully');
            GetPurchesordertList(); 
        },
        error: function (xhr, status, error) {
            console.error('Error deleting selected items:', error);
        }
    });
    selectedItems.remove();
}
var GetallPurchessorderbyInvoiceNo = function () {
    debugger;
    var PurchesInvoiceNo = $("#hdnPurchesInvoiceNo").val();
    var model = {
        MasterId: 1,
        PurchesInvoiceNo: PurchesInvoiceNo
    };

    $.ajax({
        url: "/Product/GetallPurchessorderbyInvoiceNo",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            debugger
            var html = "";
            $("#allpurchesorderlist tbody").empty();
            $.each(response.Message, function (Index, elementvalue) {
                html += "<tr><td><input type='checkbox' id='Activecheck_" + elementvalue.Id + "' class='ibtn'></td><td>" + elementvalue.Particular + "(" + elementvalue.Id + ")</td><td>" + elementvalue.Particular +
                    "</td><td>" + elementvalue.HSN +
                    "</td><td>" + elementvalue.UOM +
                    "</td><td>" + elementvalue.GST +
                    "</td><td>" + elementvalue.MRP +
                    "</td><td>" + elementvalue.PurchesRate +
                    "</td><td>" + elementvalue.SellingRate +
                    "</td><td>" + elementvalue.Quantity +
                    "</td><td>" + elementvalue.Amount +
                    "</td><td>" + elementvalue.Discount +
                    "</td><td>" + elementvalue.CGST +
                    "</td><td>" + elementvalue.SGST +
                    "</td><td>" + elementvalue.Cess +
                    "</td><td>" + elementvalue.Total +
                    "</td><td>" + elementvalue.ManufacturingDate +
                    "</td><td>" + elementvalue.ExpiryDate + "</td></tr>";
            });
            $("#allpurchesorderlist tbody").append(html);
        }
    });
};
function deleteSelectedRows() {
    debugger
    // Find all checkboxes that are checked
    var checkboxes = $(".ibtn:checked");

    // Loop through each checked checkbox
    checkboxes.each(function () {
        // Remove the corresponding row
        $(this).closest("tr").remove();
    });
}
var TotalPurchesOrderTotal = function () {
    var PurchesInvoiceNo = $("#lblPurchesInvoiceNo").val();
    var model = {
        MasterId: 1,
        PurchesInvoiceNo: PurchesInvoiceNo
    };
   
    $.ajax({
        url: "/Product/TotalPurchesOrderTotal",
        method: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.hasOwnProperty('Message')) {
                var message = response.Message;
                $("#lblTotalPurchesQuantity").val(message.TotalPurchesQuantity);
                $("#lblProductTaxableAmount").val(parseFloat(message.ProductTaxableAmount).toFixed(2));
                $("#lblTotalProductDiscount").val(message.TotalProductDiscount);
                $("#lblTotalTotalPurchesCGST").val(parseFloat(message.TotalPurchesCGST).toFixed(2));
                $("#lblTotalPurchesSGST").val(parseFloat(message.TotalPurchesSGST).toFixed(2));
                $("#lblTotalPurchrsCESS").val(parseFloat(message.TotalPurchrsCESS).toFixed(2));
                $("#lblPurchesTotalAmount").val(parseFloat(message.PurchesTotalAmount).toFixed(2));
                $("#hdnPurchesTotalAmount").val(parseFloat(message.PurchesTotalAmount).toFixed(2));
            } else {
                // Handle error or unexpected response
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            // Handle error
        }
    });
};

var UpdateProductOrder = function () {
    debugger;
    var selectedItems = $('.selected');
    if (selectedItems.length === 0) {
        alert("Please select items to delete.");
        return;
    }
    var productId = $(selectedItems[0]).data('product-id'); // Assuming you want to pass the productId of the first selected item.
    if (productId === undefined || productId === null) {
        alert("No valid product ID selected for deletion.");
        return;
    }
    var dataToSend = {
        productIds: productId
    };
    $.ajax({
        url: "/Product/UpdateProductOrder",
        method: "post",
        data: JSON.stringify(dataToSend),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {
            var expdate = response.Message.ExpiryDate.split("-");
            var exdate = expdate[2] + "-" + expdate[1] + "-" + expdate[0];
            var mnupdate = response.Message.ManufacturingDate.split("-");
            var mndate = mnupdate[2] + "-" + mnupdate[1] + "-" + mnupdate[0];

            $("#hdnpId").val(response.Message.Id);
            $("#lblPurchesInvoiceNo").val(response.Message.PurchesInvoiceNo);
            $("#hdnMasterId").val(response.Message.MasterId);
            $("#txtPParticular").val(response.Message.Particular);
            let img = response.Message.ProductImage;
            $('#imageDisplay').attr('src', '../Content/Pages/image/' + img);;
            $("#txtPHSN").val(response.Message.HSN);
            $("#txtPUOM").val(response.Message.UOM);
            $("#txtPGST").val(response.Message.GST);
            $("#txtPMRP").val(response.Message.MRP);
            $("#txtPPurchesRate").val(response.Message.PurchesRate);
            $("#txtPSellingRate").val(response.Message.SellingRate);
            $("#txtPQty").val(response.Message.Quantity);
            $("#txtPAmount").val(response.Message.Amount);
            $("#txtPDiscount").val(response.Message.Discount);
            $("#txtPCGST").val(response.Message.CGST);
            $("#txtPSGST").val(response.Message.SGST);
            $("#txtPCess").val(response.Message.Cess);
            $("#txtPtotal").val(response.Message.Total);
            $("#txtPManufacturingDate").val(mndate);
            $("#txtPExpiryDate").val(exdate);
           
            // Show the image
            $('#imageDisplay').show();
        }
    });
}
