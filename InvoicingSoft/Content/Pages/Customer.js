$(document).ready(function () {
    GetCustomerList();
    getCustomerdetailbyid();
});
var SaveCustomer = function () {
    debugger
    var checkbox = true;
    if ($("#Active").is(":checked")) {
        checkbox = true;
    }
    else {
        checkbox = false;
    }

    var Id = $("#hdnId").val();
    var MasterId = $("#hdnMasterId").val();
    var CustomerName = $("#txtCustomerName").val();
    var Mobile = $("#txtMobile").val();
    var Email = $("#txtEmail").val();
    var GSTNo = $("#txtGSTNo").val();
    var Address = $("#txtAddress").val();
    var City = $("#txtCity").val();
    var State = $("#txtState").val();
    var ZipCode = $("#txtZipCode").val();
    var isActive = checkbox;
    if (CustomerName == "") {
        alert("Please Enter Customer Name");
        $("#txtCustomerName").focus();
        return false;
    }
    var model = {
        Id: Id,
        MasterId: MasterId,
        CustomerName: CustomerName,
        Mobile: Mobile,
        Email: Email,
        GSTNo: GSTNo,
        Address: Address,
        City: City,
        State: State,
        ZipCode: ZipCode,
        IsActive: isActive
    };

    $.ajax({
        url: "/Customer/SaveCustomer",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert(response.Message)
            GetCustomerList();
        }
    });
}
var GetCustomerList = function () {
    /*    var MasterId = $("#hdnMasterId").val();*/
    var MasterId = 1;
    var model = {
        MasterId: MasterId
    };

    $.ajax({
        url: "/Customer/GetCustomerList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblCustomer tbody").empty();
            $.each(response.Message, function (Index, elementvalue) {
                html += "<tr><td>" + elementvalue.CustomerName + "<br><a onclick='AccountData(" + elementvalue.Id + ")' type='button' class='btn btn-dark btn-sm'> Account</a>&nbsp;&nbsp;<a onclick='Invoice(" + elementvalue.Id + ")' type = 'button' class='btn btn-dark btn-sm'> Invoice</a ></td><td>" + elementvalue.Mobile +
                    "</td><td>" + elementvalue.GSTNo +
                    "</td><td>" + elementvalue.Address +
                    "</td><td>" + elementvalue.City + "</td><td><button type='button'class='btn btn-success btn-sm' onclick='EditCustomer(" + elementvalue.Id + ")'><i class='bi bi-pencil-square' aria-hidden='true'></i></button>&nbsp;<button type='button'class='btn btn-danger btn-sm' onclick='DeleteCustomer(" + elementvalue.Id + ")'><i class='bi bi-trash-fill'></i></button>&nbsp;<button type='button' class='btn btn-info btn-sm' onclick='GetDetails(" + elementvalue.Id + ")'><i class='bi bi-eye-fill'></i></button></td></tr>";
            });
            $("#tblCustomer tbody").append(html);
        }
    });
}
var AccountData = function (Id) {

    window.location.href = "/Account/AccountIndex?CustomerId=" + Id;
}
var Invoice = function (Id) {

    window.location.href = "/Customer/CustomerInvoiceListIndex?CustomerId=" + Id;
}
var DeleteCustomer = function (Id) {
    var model = { Id: Id };
    $.ajax({
        url: "/Customer/DeleteCustomer",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert(response.Message);
            GetCustomerList();
        }
    });
}
var EditCustomer = function () {

    var model = {
        Id: Id
    };
    $.ajax({
        url: "/Customer/GetCustomerDetailbyId",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#franchiseform").modal('show');
            $("#txtCustomerName").empty();
            $("#txtMobile").empty();
            $("#txtEmail").empty();
            $("#txtGSTNo").empty();
            $("#txtAddress").empty();
            $("#txtCity").empty();
            $("#txtState").empty();
            $("#txtZipCode").empty();
          
            $("#hdnId").val(response.Message.Id);
            $("#hdnMasterId").val(response.Message.MasterId);
            $("#txtCustomerName").val(response.Message.CustomerName);
            $("#txtMobile").val(response.Message.Mobile);
            $("#txtEmail").val(response.Message.Email);
            $("#txtGSTNo").val(response.Message.GSTNo);
            $("#txtAddress").val(response.Message.Address);
            $("#txtCity").val(response.Message.City);
            $("#txtState").val(response.Message.State);
            $("#txtZipCode").val(response.Message.ZipCode);
        }
    });
}
var GetDetails = function (Id) {
    var model = {
        Id: Id
    };
    $.ajax({
        url: "/Customer/GetCustomerDetailbyId",
        method: "post",
        type: "GET",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#CustomerDetailsModel").modal('show');
            $("#CustomerDetails").empty();
            var html = "";
            html += "<center>";
            html += "<table>";
            html += "<tr>";
            html += "<td><label>CustomerName:</label></td><td><span>" + response.Message.CustomerName + "</span></td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td><label>Mobile:</label></td><td><span>" + response.Message.Mobile + "</span></td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td><label>Email:</label></td><td><span>" + response.Message.Email + "</span></td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td><label>GST No:</label></td><td><span>" + response.Message.GSTNo + "</span></td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td><label>Address:</label></td><td><span>" + response.Message.Address + "</span></td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td><label>City:</label></td><td><span>" + response.Message.City + "</span></td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td><label>State:</label></td><td><span>" + response.Message.State + "</span></td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td><label>Zip Code:</label></td><td><span>" + response.Message.ZipCode + "</span></td>";
            html += "</tr>";
            html += "</table>";
            html += "</center>";
            $("#CustomerDetails").append(html);
        }
    });
};

var getCustomerdetailbyid = function () {
    debugger; 
    var Id = $("#custid").val();
    var model = {
        Id: Id
    };
    $.ajax({
        url: "/Customer/GetCustomerDetailbyId",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#lblid").text(response.Message.Id);
            $("#lblmasterid").text(response.Message.MasterId);
            $("#lblcustomername").text(response.Message.CustomerName);
            $("#lblmobile").text(response.Message.Mobile);
            $("#lblemail").text(response.Message.Email);
            $("#lblgstno").text(response.Message.GSTNo);
            $("#lbladdress").text(response.Message.Address);
            $("#lblcity").text(response.Message.City);
            $("#lblstate").text(response.Message.State);
            $("#lblzipcode").text(response.Message.ZipCode);
          //  $("#currentdate").text(Date.now);
        }
    });
}
