$(document).ready(function ($) {

    GetcustomerordertList();
    GetCustomerInvoiceList();
    InvoiceDetails();
    TotalCustomerOrderDetails();
    getInvoiceNo();
    GetInvoiceList();
    $("#txtCustomerName").focus();
    $("#txtParticular").focus();

    console.log($("#isPrint").val());

    $("#txtQty").keyup(function () {
        debugger

        var disc = 0;
        if (disc != null) {
            disc == $("#txtDiscount").val();
        }
        else {
            disc = 0;
        }

        var rate = $("#txtRate").val();
        var qty = $("#txtQty").val();
        var gst = $("#txtGST").val();
        // var disc = $("#txtDiscount").val();
        var totprice = (parseFloat(rate).toFixed(2) * parseFloat(qty).toFixed(2));

        var cgst = (parseFloat(totprice).toFixed(2) / 100 * parseFloat(gst).toFixed(2) / 2);
        var discvalue = (parseFloat(totprice).toFixed(2) * parseFloat(disc).toFixed(2)) / 100;
        var subtotal = (parseFloat(totprice).toFixed(2) - parseFloat(discvalue).toFixed(2));
        var gstvalue = (parseFloat(subtotal).toFixed(2) * parseFloat(gst).toFixed(2)) / 100;
        var totalamt = (parseFloat(subtotal).toFixed(2) + parseFloat(cgst).toFixed(2) + parseFloat(cgst).toFixed(2));
        $("#txtAmount").val(totprice);
        $("#txtCGST").val(parseFloat(cgst).toFixed(2));
        $("#txtSGST").val(parseFloat(cgst).toFixed(2));
        // $("#txttotalamt").val(parseFloat(totalamt).toFixed(2));
        $("#txttotalamt").val((subtotal + gstvalue).toFixed(2));
    });
    $("#txtDiscount").keyup(function () {
        var rate = $("#txtRate").val();
        var qty = $("#txtQty").val();
        var gst = $("#txtGST").val();
        var disc = ($("#txtDiscount").val() == '' )? 0 : $("#txtDiscount").val();
  
        var totprice = (parseFloat(rate).toFixed(2) * parseFloat(qty).toFixed(2));
        var discvalue = (parseFloat(totprice).toFixed(2) * parseFloat(disc).toFixed(2)) / 100;
        var subtotal = (parseFloat(totprice).toFixed(2) - parseFloat(discvalue).toFixed(2));
        var gstvalue = (parseFloat(subtotal).toFixed(2) * parseFloat(gst).toFixed(2)) / 100;
        $("#txttotalamt").val((subtotal + gstvalue).toFixed(2));
    });

    $("#txtCESS").keyup(function () {

        var rate = $("#txtRate").val();
        var qty = $("#txtQty").val();
        var gst = $("#txtGST").val();
        var disc = $("#txtDiscount").val();
        var cess = (Number($("#txtCESS").val()) == '') ? 0 : $("#txtCESS").val();
        var totprice = (parseFloat(rate).toFixed(2) * parseFloat(qty).toFixed(2));
        var discvalue = (parseFloat(totprice).toFixed(2) * parseFloat(disc).toFixed(2)) / 100;
        var subtotal = (parseFloat(totprice).toFixed(2) - parseFloat(discvalue).toFixed(2));
        var gstvalue = (parseFloat(subtotal).toFixed(2) * parseFloat(gst).toFixed(2)) / 100;
        $("#txttotalamt").val((parseFloat(subtotal) + parseFloat(gstvalue) + parseFloat(cess)));
    });
    $("#txtOtherCharcge").keyup(function () {
 
        var r = Number($("#hdnamoutvalue").val());
        var q = ($("#txtOtherCharcge").val() == '') ? 0 : $("#txtOtherCharcge").val();
        var amt = parseFloat(r) + parseFloat(q);



        $("#lblTotalAmount").val(amt.toFixed(2));
    });
    if ($("#isPrint").val() == "True")
        printDiv('printableArea');

    $("#txtParticular").autocomplete({
        source: function (request, response) {
            debugger
            $.ajax({
                url: "/Product/purchespruductSearch",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data.Message, function (item) {
                        const listItem = `${item.Particular}(Expire Date${item.ExpiryDate}),Ouantity=${item.Quantity}`;
                        return {
                            label:listItem,
                            value: item.Particular,
                            id: item.Id,
                            uom: item.UOM,
                            hsn: item.HSN,
                            gst: item.GST,
                            mrp: item.MRP,
                            rate: item.PurchesRate,
                            ceratedate: item.CrateDate,
                        };

                    }))
                }
            })
        },
        minLength: 1,
        select: function (event, ui) {
            debugger
            $("#getparticular").val(ui.item.id);
            $("#txtUOM").val(ui.item.uom);
            $("#txtHSN").val(ui.item.hsn);
            $("#txtGST").val(ui.item.gst);
            $("#txtMRP").val(ui.item.mrp);
            $("#txtRate").val(ui.item.rate);
         
        },
        open: function () {
            // Optional: Style the autocomplete dropdown visually
            $(".ui-autocomplete").css("background-color", "#fff");
        }
    });
    $("#txtCustomerName").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "/Customer/ddlCustomerSearch",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    debugger
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

                    }))
                }
            })
        },
        minLength: 0,
        select: function (event, ui) {
            $("#hdncustomerId").val(ui.item.id);
            $("#txtMobile").val(ui.item.mobile);
            $("#txtEmail").val(ui.item.email);
            $("#lblGSTNo").val(ui.item.gstno);
            $("#lblAddress").val(ui.item.address);
            $("#lblCity").val(ui.item.city);
            $("#lblState").val(ui.item.state);
            $("#lblZipCode").val(ui.item.zipcode);
        },
    });

});
var getInvoiceNo = function () {
    $.ajax({
        url: "/Invoice/GetInvoiceNo",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            $("#lblInvoiceNo").val(response.Message);
            $("#lblInvoiceId").val(response.Message.Id);
            GetcustomerordertList(response.Message);
        }
    });
}
var SaveCustomerOrder = function () {
  
    var checkbox = true;
    if ($("#Active").is(":checked")) {
        checkbox = true;
    }
    else {
        checkbox = false;
    }

    var MasterId = $("#hdnMasterId").val();
    var InvoiceNo = $("#lblInvoiceNo").val();
    var CustomerId = $("#hdncustomerId").val();
    var ProductId = $("#getparticular").val();
    var Particular = $("#txtParticular").val();
    var HSN = $("#txtHSN").val();
    var UOM = $("#txtUOM").val();
    var GST = $("#txtGST").val();
    var MRP = $("#txtMRP").val();
    var Rate = $("#txtRate").val();
    var Quantity = $("#txtQty").val();
    var Amount = $("#txtAmount").val();
    var Discount = $("#txtDiscount").val();
    var CGST = $("#txtCGST").val();
    var SGST = $("#txtSGST").val();
    var CESS = $("#txtCESS").val();
    var TotalAmount = $("#txttotalamt").val();
    var isActive = checkbox;

    if (Quantity == "") {
        alert("please Enter Particular");
        $("txtQty").focus();
        return false;
    }

    var data = {
        MasterId: MasterId,
        InvoiceNo: InvoiceNo,
        CustomerId: CustomerId,
        ProductId: ProductId,
        Particular: Particular,
        HSN: HSN,
        UOM: UOM,
        GST: GST,
        MRP: MRP,
        Rate: Rate,
        Quantity: Quantity,
        Amount: Amount,
        Discount: Discount,
        CGST: CGST,
        SGST: SGST,
        CESS: CESS,
        TotalAmount: TotalAmount,
        IsActive: isActive
    };

    $.ajax({
        url: "/Invoice/SaveCustomerOrder",
        method: "post",
        data: JSON.stringify(data),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            getInvoiceNo();
            OrderReset();
            GetcustomerordertList();
            TotalCOrderDetails();
          /*  TotalCustomerOrderDetails();*/
            //var  element = document.getElementById(" clearproductdata ");
            // element.reset();
        }
    });
}
var GetcustomerordertList = function (InvoiceNo) {
    debugger
    var InvoiceNo = $("#lblInvoiceNo").val();
    var model = {
        InvoiceNo: InvoiceNo
    };

    $.ajax({
        url: "/Invoice/GetcustomerordertList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblorder tbody").empty();
            $.each(response.Message, function (Index, elementvalue) {
                html += "<tr><td>" + elementvalue.Particular +
                    "</td><td>" + elementvalue.HSN +
                    "</td><td>" + elementvalue.UOM +
                    "</td><td>" + elementvalue.GST +
                    "%</td><td>" + parseFloat(elementvalue.MRP).toFixed(2) +
                    "</td><td>" + parseFloat(elementvalue.Rate).toFixed(2) +
                    "</td><td>" + parseFloat(elementvalue.Amount).toFixed(2) +
                    "</td><td>" + elementvalue.Discount +
                    "%</td><td>" + elementvalue.Quantity +
                    "</td><td>" + parseFloat(elementvalue.CGST).toFixed(2) +
                    "</td><td>" + parseFloat(elementvalue.SGST).toFixed(2) +
                    "</td><td>" + parseFloat(elementvalue.CESS).toFixed(2) +
                    "</td><td>" + parseFloat(elementvalue.TotalAmount).toFixed(2) + "</td></tr>";
            });
            $("#tblorder tbody").append(html);
        }
    });
}
var TotalCOrderDetails = function () {
    debugger
    var InvoiceNo = $("#lblInvoiceNo").val();
    var model = {
        InvoiceNo: InvoiceNo
    };
    $.ajax({
        url: "/Invoice/TotalCustomerOrderDetails",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            $("#lblTotalQuantity").val(response.Message.TotalQuantity);
            $("#lblTaxableAmount").val(parseFloat(response.Message.TaxableAmount).toFixed(2));
            $("#lblTotalDiscount").val(response.Message.TotalDiscount);
            $("#lblTotalCGST").val(parseFloat(response.Message.TotalCGST).toFixed(2));
            $("#lblTotalSGST").val(parseFloat(response.Message.TotalSGST).toFixed(2));
            $("#lblTotalCESS").val(parseFloat(response.Message.TotalCESS).toFixed(2));
            $("#lblTotalAmount").val(parseFloat(response.Message.TotalAmount).toFixed(2));
            let html = "";
            $('#tbgstDetails').empty();
            $.each(response.Message.GSTDetails, function (Index, elementvalue) {
                html = "<tr><th>" + elementvalue.GST + '%' + "</th><td>" + elementvalue.Amount + "</td><td>" + elementvalue.CGST + "</td><td>" + elementvalue.SGST + "</td></tr>";
                let tbody = document.getElementById('tbgstDetails');
                let tr = document.createElement('tr');
                tbody.appendChild(tr);
                tr.innerHTML = html;
                tbody.appendChild(tr);
            });
            let i = response.Message.GSTDetails.length;
            for (let j = 5; i < j; i++) {
                let tbody = document.getElementById('tbgstDetails');
                let tr = document.createElement('tr');
                tbody.appendChild(tr);
                html = "<tr><th>0%</th><td>0</td><td>0</td><td>0</td></tr>";
                tr.innerHTML = html;
                tbody.appendChild(tr);
            }

            //if (response.Message.GSTDetails.length == 2)
            //    html += "<tr><th></th><td></td><td></td><td></td></tr><tr><th></th><td></td><td></td><td></td></tr><tr><th></th><td></td><td></td><td></td></tr>";
            //if (response.Message.GSTDetails.length == 3)
            //    html += "<tr><th></th><td></td><td></td><td></td></tr><tr><th></th><td></td><td></td><td></td></tr>";
            //if (response.Message.GSTDetails.length == 4)
            //    html += "<tr><th></th><td></td><td></td><td></td></tr>";

            //            //$("#lblTotalAmount").val(parseFloat(response.Message.TotalAmount).toFixed(2));

            //            let k = response.Message.TotalAmount;

            //            if (num = k) { // Use === for strict comparison
            //                if (num == 0) {
            //                    return "Zero";
            //                }

            //                num = ("0".repeat(2 * (num + "").length % 3) + num).match(/.{3}/g);
            //                let out = "",
            //                    T1 = ["", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"],
            //                    T2 = ["", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"],
            //                    SC = ["", "Thousand", "Million", "Billion", "Trillion", "Quadrillion"];

            //                out = num.forEach((n, i) => {
            //                    if (+n) {
            //                        let h = +n[0],
            //                            t = +n.substring(1),
            //                            S = SC[num.length - i - 1];
            //                        out += (out ? " " : "") + (h ? T1[h] + " Hundred" : "") + (h && t ? " " : "") + (t < 20 ? T1[t] : T2[+n[1]] + (+n[2] ? "-" : "") + T1[+n[2]]);
            //                        out += (out && S ? " " : "") + S;
            //                    }
            //                });

            //               // $("#lblTotalAmount").val(out);
            //            } else {
            //                // Handle the case where num is not equal to k
            //                // This part is missing in the provided code,
            //                // you need to add your logic here based on your needs.
            //            }

            //// GetBillList(response.Message); // Uncomment if needed
        }
    });
}
var TotalCustomerOrderDetails = function () {
    debugger
    var InvoiceNo = $("#lblInvoiceNo").val();
    var model = {
        InvoiceNo: InvoiceNo
    };
    $.ajax({
        url: "/Invoice/TotalCustomerOrderDetails",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            $("#lblTotalQuantity").val(response.Message.TotalQuantity);
            $("#lblTaxableAmount").val(parseFloat(response.Message.TaxableAmount).toFixed(2));
            $("#lblTotalDiscount").val(response.Message.TotalDiscount);
            $("#lblTotalCGST").val(parseFloat(response.Message.TotalCGST).toFixed(2));
            $("#lblTotalSGST").val(parseFloat(response.Message.TotalSGST).toFixed(2));
            $("#lblTotalCESS").val(parseFloat(response.Message.TotalCESS).toFixed(2));
            $("#lblTotalAmount").val(parseFloat(response.Message.TotalAmount).toFixed(2));
            let html = "";
            $('#tbgstDetails').empty();
            $.each(response.Message.GSTDetails, function (Index, elementvalue) {
                html = "<tr><th>" + elementvalue.GST + '%' + "</th><td>" + elementvalue.Amount + "</td><td>" + elementvalue.CGST + "</td><td>" + elementvalue.SGST + "</td></tr>";
                let tbody = document.getElementById('tbgstDetails');
                let tr = document.createElement('tr');
                tbody.appendChild(tr);
                tr.innerHTML = html;
                tbody.appendChild(tr);
            });
            let i = response.Message.GSTDetails.length;
            for (let j = 5; i < j; i++) {
                let tbody = document.getElementById('tbgstDetails');
                let tr = document.createElement('tr');
                tbody.appendChild(tr);
                html = "<tr><th>0%</th><td>0</td><td>0</td><td>0</td></tr>";
                tr.innerHTML = html;
                tbody.appendChild(tr);
            }
            
            //if (response.Message.GSTDetails.length == 2)
            //    html += "<tr><th></th><td></td><td></td><td></td></tr><tr><th></th><td></td><td></td><td></td></tr><tr><th></th><td></td><td></td><td></td></tr>";
            //if (response.Message.GSTDetails.length == 3)
            //    html += "<tr><th></th><td></td><td></td><td></td></tr><tr><th></th><td></td><td></td><td></td></tr>";
            //if (response.Message.GSTDetails.length == 4)
            //    html += "<tr><th></th><td></td><td></td><td></td></tr>";
            
//            //$("#lblTotalAmount").val(parseFloat(response.Message.TotalAmount).toFixed(2));
           
//            let k = response.Message.TotalAmount;

//            if (num = k) { // Use === for strict comparison
//                if (num == 0) {
//                    return "Zero";
//                }

//                num = ("0".repeat(2 * (num + "").length % 3) + num).match(/.{3}/g);
//                let out = "",
//                    T1 = ["", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"],
//                    T2 = ["", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"],
//                    SC = ["", "Thousand", "Million", "Billion", "Trillion", "Quadrillion"];

//                out = num.forEach((n, i) => {
//                    if (+n) {
//                        let h = +n[0],
//                            t = +n.substring(1),
//                            S = SC[num.length - i - 1];
//                        out += (out ? " " : "") + (h ? T1[h] + " Hundred" : "") + (h && t ? " " : "") + (t < 20 ? T1[t] : T2[+n[1]] + (+n[2] ? "-" : "") + T1[+n[2]]);
//                        out += (out && S ? " " : "") + S;
//                    }
//                });

//               // $("#lblTotalAmount").val(out);
//            } else {
//                // Handle the case where num is not equal to k
//                // This part is missing in the provided code,
//                // you need to add your logic here based on your needs.
//            }

//// GetBillList(response.Message); // Uncomment if needed
        }
    });
}
var printCustomerInvoice = function () {
    debugger
    var MasterId = $("#hdnMasterId").val();
    var InvoiceNo = $("#lblInvoiceNo").val();
    var CustomerId = $("#hdncustomerId").val();
    var Quantity = $("#lblTotalQuantity").val();
    var TaxAmount = $("#lblTaxableAmount").val();
    var Discount = $("#lblTotalDiscount").val();
    var CGST = $("#lblTotalCGST").val();
    var SGST = $("#lblTotalSGST").val();
    var CESS = $("#lblTotalCESS").val();
    var OtherCharge = $("#txtOtherCharcge").val();
    var TotalAmount = $("#lblTotalAmount").val();
    var CustomerName = $("#txtCustomerName").val();
    var Mobile = $("#txtMobile").val();
    var Email = $("#txtEmail").val();
    var GSTNo = $("#txtGSTNo").val();
    var Address = $("#txtAddress").val();
    var City = $("#txtCity").val();
    var State = $("#txtState").val();
    var ZipCode = $("#txtZipCode").val();
    if (CustomerName == "") {
        alert("Enter Customer Name");
        $("#txtCustomerName").focus();
        return false;
    }
    if (OtherCharge == "") {
        OtherCharge = "0";
    }
    var data = {
        MasterId: MasterId,
        InvoiceNo: InvoiceNo,
        CustomerId: CustomerId,
        Quantity: Quantity,
        TaxAmount: TaxAmount,
        Discount: Discount,
        CGST: CGST,
        SGST: SGST,
        CESS: CESS,
        OtherCharge: OtherCharge,
        TotalAmount: TotalAmount,
        CustomerName: CustomerName,
        Mobile: Mobile,
        Email: Email,
        GSTNo: GSTNo,
        Address: Address,
        City: City,
        State: State,
        ZipCode: ZipCode,
    };

    $.ajax({
        url: "/Invoice/SaveCustomerInvoice",
        method: "post",
        data: JSON.stringify(data),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            invoicePrint(response.Message)
            InvoiceResetReset();
            //  alert(" Save SucessFully");
            GetInvoiceList();
            location.reload();

        }
    });
}
var SaveCustomerInvoice = function () {
    debugger
    var MasterId = $("#hdnMasterId").val();
    var InvoiceNo = $("#lblInvoiceNo").val();
    var CustomerId = $("#hdncustomerId").val();
    var Quantity = $("#lblTotalQuantity").val();
    var TaxAmount = $("#lblTaxableAmount").val();
    var Discount = $("#lblTotalDiscount").val();
    var CGST = $("#lblTotalCGST").val();
    var SGST = $("#lblTotalSGST").val();
    var CESS = $("#lblTotalCESS").val();
    var OtherCharge = $("#txtOtherCharcge").val();
    var TotalAmount = $("#lblTotalAmount").val();
    var CustomerName = $("#txtCustomerName").val();
    var Mobile = $("#txtMobile").val();
    var Email = $("#txtEmail").val();
    var GSTNo = $("#txtGSTNo").val();
    var Address = $("#txtAddress").val();
    var City = $("#txtCity").val();
    var State = $("#txtState").val();
    var ZipCode = $("#txtZipCode").val();
    if (CustomerName == "") {
        alert("Enter Customer Name");
        $("#txtCustomerName").focus();
        return false;
    }
    if (OtherCharge == "") {
        OtherCharge = "0";
    }
    var data = {
        MasterId: MasterId,
        InvoiceNo: InvoiceNo,
        CustomerId: CustomerId,
        Quantity: Quantity,
        TaxAmount: TaxAmount,
        Discount: Discount,
        CGST: CGST,
        SGST: SGST,
        CESS: CESS,
        OtherCharge: OtherCharge,
        TotalAmount: TotalAmount,
        CustomerName: CustomerName,
        Mobile: Mobile,
        Email: Email,
        GSTNo: GSTNo,
        Address: Address,
        City: City,
        State: State,
        ZipCode: ZipCode,
    };

    $.ajax({
        url: "/Invoice/SaveCustomerInvoice",
        method: "post",
        data: JSON.stringify(data),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            //  invoicePrint(response.Message)
            alert(" Save SucessFully");
            InvoiceResetReset();
            GetInvoiceList();
            location.reload();

        }
    });
}
var GetCustomerInvoiceList = function () {
   
    var CustomerId = $("#txtCustomerId").val();
    var model = {
        CustomerId: CustomerId
    };
 

    $.ajax({
        url: "/Invoice/CustomerInvoiceList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#CustomerInvoiceList tbody").empty();
            $.each(response.Message, function (Index, elementvalue) {
                html += "<tr><td>" + elementvalue.InvoiceNo +
                    "</td><td>" + elementvalue.CustomerName +
                    "</td><td>" + elementvalue.CrateDate +
                    "</td><td>" + elementvalue.TotalAmount + "</td><td><button type='button' class='btn btn-success btn-sm' onclick='DeleteOrganization(" + String(elementvalue.InvoiceNo) + ")'><i class='bi bi-whatsapp'></i></button>&nbsp;<button type='button' class='btn btn-danger btn-sm' onclick='invoicePrint('" + String(elementvalue.InvoiceNo) + "')'><i class='bi bi-printer' aria-hidden='true'></i></button>&nbsp;<button class='btn btn-primary btn-sm' placeholder='Invoice' onclick='Invoice(" + elementvalue.InvoiceNo + ")'><i class='bi bi-eye-fill'></i></button></td></tr>";
            });
            $("#CustomerInvoiceList tbody").append(html);
        }
    });
}
var GetInvoiceList = function () {

    // var MasterId = $("#hdnMasterId").val();
    var MasterId = 1;
    var model = {
        MasterId: MasterId
    };

    $.ajax({
        url: "/Invoice/InvoiceList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
   
            var html = "";
            $("#tblInvoice tbody").empty();
            $.each(response.Message, function (Index, elementvalue) {
                html += "<tr><td>" + elementvalue.InvoiceNo +
                    "</td><td>" + elementvalue.CustomerName +
                    "</td><td>" + elementvalue.CrateDate +
                    "</td><td>" + elementvalue.TotalAmount + "</td><td><button type='button' class='btn btn-success btn-sm' onclick='DeleteOrganization(" + elementvalue.Id + ")'><i class='bi bi-whatsapp'></i></button>&nbsp;<button type='button' class='btn btn-danger btn-sm' onclick='invoicePrint("+elementvalue.InvoiceNo+")'><i class='bi bi-printer' aria-hidden='true'></i></button>&nbsp;<button class='btn btn-primary btn-sm' placeholder='Invoice' onclick='Invoice(" + elementvalue.InvoiceNo + ")'><i class='bi bi-eye-fill'></i></button></td></tr>";
            });
            $("#tblInvoice tbody").append(html);
        }
    });
}
var Invoice = function (InvoiceNo) {
    window.location.href = "/Invoice/InvoiceDetailsIndex?InvoiceNo=" + InvoiceNo + "&isPrint=false";
}
var invoicePrint = function (InvoiceNo) {
    window.location.href = "/Invoice/InvoiceDetailsIndex?InvoiceNo=" + InvoiceNo + "&isPrint=true";
}
var InvoiceDetails = function (InvoiceNo) {
    debugger
    var InvoiceNo = $("#lblInvoiceNo").val();
    var model = {
        InvoiceNo: InvoiceNo
    };
    $.ajax({
        url: "/Invoice/InvoiceDetails",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#lblCustomerName").text(response.Message.CustomerName);
            $("#lblAddress").text(response.Message.Address);
            $("#lblTotalDiscount").text(response.Message.City);
            $("#lblState").text(response.Message.State);
            $("#lblZipCode").text(response.Message.ZipCode);
            $("#lblGSTNo").text(response.Message.GSTNo);
            $("#lblMobile").text(response.Message.Mobile);
            $("#spnInvoiceNo").text(response.Message.InvoiceNo);
            $("#lblQuantity").text(response.Message.Quantity);
            $("#lblTaxAmount").text(response.Message.TaxAmount);
            $("#Tax").text(response.Message.TaxAmount);
            $("#lblDiscount").text(response.Message.Discount);
            $("#lblOtherCharge").text(response.Message.OtherCharge);
            $("#lblSGSTAmount").text(response.Message.SGST);
            $("#SGST").text(response.Message.SGST);
            $("#lblCGSTAmount").text(response.Message.CGST);
            $("#CGST").text(response.Message.CGST);
            $("#lblCESSAmount").text(response.Message.CESS);
            $("#TotalAmount").text(response.Message.TotalAmount);
            $("#lblCrateDate").text(response.Message.CrateDate);
            /*  GetBillList(response.Message);*/
        }
    });
    $.ajax({

        url: "/Invoice/GetcustomerordertList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblinvoiceorder tbody").empty();
            $.each(response.Message, function (Index, elementvalue) {
                html += "<tr><td>" + elementvalue.Particular +
                    "</td><td>" + elementvalue.UOM +
                    "</td><td>" + elementvalue.HSN +
                    "</td><td>" + elementvalue.GST +
                    "</td><td>" + elementvalue.MRP +
                    "</td><td>" + elementvalue.Rate +
                    "</td><td>" + elementvalue.Quantity +
                    "</td><td>" + elementvalue.Amount +
                    "</td><td>" + elementvalue.Discount +
                    "</td><td>" + elementvalue.CGST +
                    "</td><td>" + elementvalue.SGST +
                    "</td><td>" + elementvalue.CESS +
                    "</td><td>" + elementvalue.TotalAmount + "</td></tr>";
            });
            $("#tblinvoiceorder tbody").append(html);
        }
    });
}
function printDiv(divId) {
    var printContents = document.getElementById(divId).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;
    window.focus();
    window.print();
    document.body.innerHTML = originalContents;
    window.location.href = "/Invoice/InvoiceListIndex";
}
function OrderReset() {

    $("#txtParticular").val("");
    $("#txtHSN").val("");
    $("#txtUOM").val("");
    $("#txtGST").val("");
    $("#txtMRP").val("");
    $("#txtRate").val("");
    $("#txtQty").val("");
    $("#txtAmount").val("");
    $("#txtDiscount").val("");
    $("#txtCGST").val("");
    $("#txtSGST").val("");
    $("#txtCESS").val("");
    $("#txttotalamt").val("");
}
var clearData = function () {

    $("#hdnMasterId").clear();
    $("#getcustomername").reset();
    $("#getparticular").reset();
    $("#txtQty").reset();
    //$("#txtAmount").clear();
    //$("#txtDiscount").clear();
    //$("#txtCGST").clear();
    //$("#txtSGST").clear();
    //$("#txtCESS").clear();
    //$("#txttotalamt").clear();
}
function InvoiceResetReset() {

    $("#txtParticular").val("");
    $("#txtHSN").val("");
    $("#txtUOM").val("");
    $("#txtGST").val("");
    $("#txtMRP").val("");
    $("#txtRate").val("");
    $("#txtQty").val("");
    $("#txtAmount").val("");
    $("#txtDiscount").val("");
    $("#txtCGST").val("");
    $("#txtSGST").val("");
    $("#txtCESS").val("");
    $("#txttotalamt").val("");
    $("#hdnMasterId").val("");
    $("#lblInvoiceNo").val("");
    $("#hdncustomerId").val("");
    $("#lblTotalQuantity").val("");
    $("#lblTaxableAmount").val("");
    $("#lblTotalDiscount").val("");
    $("#lblTotalCGST").val("");
    $("#lblTotalSGST").val("");
    $("#lblTotalCESS").val("");
    $("#txtOtherCharcge").val("");
    $("#lblTotalAmount").val("");
    $("#txtMobile").val("");
    $("#txtAddress").val("");
    $("#txtGSTNo").val("");
    $("#txtEmail").val("");
    $("#hdncustomerId").val("");
    $("#txtMobile").val("");
    $("#txtEmail").val("");
    $("#txtGSTNo").val("");
    $("#txtAddress").val("");
    $("#txtCity").val("");
    $("#txtState").val("");
    $("#txtZipCode").val("");
    $("#txtCustomerName").val("");

}



