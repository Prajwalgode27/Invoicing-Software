$(document).ready(function () {
    GetPackageList();
    ddlPackageList();
    ddlPackage();
});

var SavePackage = function () {

    debugger

    $formData = new FormData();

    var Image = document.getElementById('Photo');

    if (Image.files.length > 0) {

        for (var i = 0; i < Image.files.length; i++) {
            $formData.append('Photo-' + i, Image.files[i]);
        }
    }
    var id = $("#hdId").val();
    var title = $("#txtTitle").val();
    var description = $("#txtDesc").val();
    var duration = $("#txtDuration").val();
    var photo = $("#Photo").val();
    var amount = $("#txtAmount").val();

    if (title == "") {
        $("#title").text("Please Enter Title.")
        $("#txtTitle").focus();
        return false;
    }
    if (description == "") {
        $("#description").text("Please Enter Description.")
        $("#txtDesc").focus();
        return false;
    }
    if (title == "") {
        $("#duration").text("Please Enter Duration.")
        $("#txtDuration").focus();
        return false;
    }
    if (description == "") {
        $("#amount").text("Please Enter Amount.")
        $("#txtAmount").focus();
        return false;
    }
    $formData.append('Id', id);
    $formData.append('Title', title);
    $formData.append('Description', description);
    $formData.append('Duration', duration);
    $formData.append('Photo', photo);
    $formData.append("Amount", amount);

    $.ajax({
        url: "/Package/SavePackage",
        method: "Post",
        data: $formData,
        contentType: false,
        processData: false,
        async: false,

        success: function (response) {
            location.reload();
            alert(response.Message);
            GetPackageList();
        },
        return: false,
    });
}
var GetPackageList = function () {
    debugger;

    $.ajax({
        url: "/Package/GetPackageList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblPackage tbody").empty();


            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Title +
                    "</td><td><img src ='../Content/Img/" + elementValue.Photo + "' style='max-width:100px;max-height:80px;'/>" +
                    "</td><td>" + elementValue.Description +
                    "</td><td>" + elementValue.Duration +
                    "</td><td>" + elementValue.Amount +
                    "</td><td><button type='button' class='btn btn-primary btn-sm' onclick='EditPackage(" + elementValue.Id + ")'><i class='bi bi-pencil-square' aria-hidden='true'></i></button>&nbsp;&nbsp;<button type='button' class='btn btn-info btn-sm' onclick='DetailPackage(" + elementValue.Id + ")'><i class='bi bi-eye-fill' aria-hidden='true'></i></button> &nbsp;&nbsp;<button type='button' class='btn btn-danger btn-sm' onclick='DeletePackage(" + elementValue.Id + ")'><i class='bi bi-trash-fill' aria-hidden='true'></i></button>&nbsp;</td></tr>";
            });


            $("#tblPackage tbody").append(html);
        }
    });
};

var DeletePackage = function (Id) {
    debugger
    var confirmed = confirm("Are you sure you want to delete?");

    if (!confirmed) {
        alert("Deletion canceled.");
        return;
    }
    model = { Id: Id }

    $.ajax({
        url: "/Package/DeletePackage",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            GetPackageList();
        }
    });
}

var EditPackage = function (Id) {
    debugger
    var model = { Id: Id };

    $.ajax({
        url: "/Package/EditPackage",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {

            $("#hdId").val(response.model.Id);
            $("#txtTitle").val(response.model.Title);
            $("#txtDesc").val(response.model.Description);
            $("#txtDuration").val(response.model.Duration);
            $("#Photo").attr("src", "/Content/Img/" + response.model.Photo);
            $("#txtAmount").val(response.model.Amount);
        }
    });
}


var DetailPackage = function (Id) {
    debugger;
    var model = { Id: Id }
    $.ajax({
        url: "/Package/DetailPackage",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#PackageModal").modal('show');

            $("#DetailPackage").empty();

            var html = "<div class='row'>";

            
            html += "<div class='col-sm-6'>";
            html += "<b></b>&nbsp&nbsp&nbsp<span><img src='../Content/Img/" + response.model.Photo + "' style='max-width:300px;max-height:280px;'></span>";
            html += "</div>";

           
            html += "<div class='col-sm-6'>";
            html += "<table class='table'>";
            html += "<tr><td>Title</td><td>" + response.model.Title + "</td></tr>";
            html += "<tr><td>Description</td><td>" + response.model.Description + "</td></tr>";
            html += "<tr><td>Duration</td><td>" + response.model.Duration + "</td></tr>";
            html += "<tr><td>Amount</td><td>" + response.model.Amount + "</td></tr>";
            html += "</table>";
            html += "</div>";

         
            html += "</div>";
   
            $("#DetailPackage").append(html);
            
        }
    });
};
var ddlPackageList = function () {
 

    $.ajax({
        url: "/Package/ddlPackageList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#ddlPackage").empty();
            $.each(response.model, function (index, elementValue) {
                 html += " <li><a onclick='Index(" + elementValue.Id + ")'>" + elementValue.Title + "</a></li>";
               // html += " <option value='" + elementValue.Id + "'>" + elementValue.Title + "</option>";


            });
            $("#ddlPackage").append(html);
        }
    });
};
var Index = function (Id) {
    window.location.href = "/Member/PremiumIndex?Id=" + Id;
}

var ddlPackage = function () {
    debugger;
    $.ajax({
        url: "/Package/ddlPackageList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#dPackage").empty();

            $.each(response.model, function (index, elementValue) {
                html += " <option value='" + elementValue.Id + "'>" + elementValue.Title + "</option>";

            });


            $("#dPackage").append(html);
        }
    });
};