$(document).ready(function () {
    GetMemberList();
    DetailMember();
    MemberSubscriptionList();
    GetMemberProfile();
    ddlMember();
    GetProfile();
    GetMember();
    GetBridelst();
    GetGroomlst();
    EditProfile();
});


var saveMember = function () {
    debugger;
    $formData = new FormData();
    var Image = document.getElementById('file1');
    if (Image.files.length > 0) {
        for (var i = 0; i < Image.files.length; i++) {
            $formData.append('file1' + i, Image.files[i]);
        }
    }
    var Id = $("#hdnId").val();
    var SrNo = $("#txt").val();
    var OnBehalf = $("#txt").val();
    var FullName = $("#txtname").val();
    var Gender = "";
    if ($("#rdMale").prop('checked') == true)
        Gender = "Male";
    else
        Gender = "Female";
    var DOB = $("#txtdob").val();
    var Mobile = $("#txtmobile").val();
    var Email = $("#txtmail").val();
    var Height = $("#txtheight").val();
    var Religion = $("#txtreligion").val();
    var Caste = $("#txtcaste").val();
    var Country = $("#txtcountry").val();
    var City = $("#txtcity").val();
    var State = $("#txtstate").val();
    var Address = $("#txtaddress").val();
    var Landmark = $("#txtmothertongue").val();
    var PinCode = $("#txtPinCode").val();
    var Education = $("#txteducation").val();
    var Profession = $("#txtprofession").val();
    var Income = $("#txtincome").val();
    var Img = $("#file1").val();
    var MaritalStatus = $("#ddlstatus").val();
    var Password = $("#txtPass").val();
    var ConfirmPassword = $("#txt").val();
    var BloodGroup = $("#txt").val();
    var SkinComp = $("#txte").val();
    var TOB = $("#txttob").val();
    var POB = $("#txtpob").val();
    var Rashi = $("#ddlrashi").val();
    var Nakshatra = $("#ddlnakshatra").val();
    var SubCaste = $("#txtsubcaste").val();
    var Gotra = $("#txtgotra").val();
    var Manglik = $("#ddlmanglik").val();
    var Collage = $("#txtcollagename").val();
    var Organization = $("#txtorganization").val();
    var FatherName = $("#txtfname").val();
    var FatherOccupation = $("#txtfOccupation").val();
    var MotherName = $("#txtmname").val();
    var MotherOccupation = $("#txtmOccupation").val();
    var TotalFamilyMember = $("txttfm").val();
    var MotherTongue = $("#txtmothertongue").val();




    //if (FullName == "") {
    //    alert("Please enter your Full Name.");
    //    return;
    //}
    //else if (!/^[a-zA-Z\s]+$/.test(FullName)) {
    //    alert("Please enter a valid Full Name with only letters and spaces.");
    //    return;
    //}
    //if (Mobile == "") {
    //    alert("Please enter your Mobile Number.");
    //    return;
    //}
    //else if (!/^[6789]\d{9}$/.test(Mobile)) {
    //    alert("Please enter a valid Indian Mobile Number.");
    //    return;
    //}



    $formData.append('Id', Id);
    $formData.append('SrNo', SrNo);
    $formData.append('OnBehalf', OnBehalf);
    $formData.append('FullName', FullName);
    $formData.append('Gender', Gender);
    $formData.append('DOB', DOB);
    $formData.append('Mobile', Mobile);
    $formData.append('Email', Email);
    $formData.append('Height', Height);
    $formData.append('Religion', Religion);
    $formData.append('Caste', Caste);
    $formData.append('Country', Country);
    $formData.append('City', City);
    $formData.append('State', State);
    $formData.append('Address', Address);
    $formData.append('Landmark', Landmark);
    $formData.append('PinCode', PinCode);
    $formData.append('Education', Education);
    $formData.append('Profession', Profession);
    $formData.append('Income', Income);
    $formData.append('Img', Img);
    $formData.append('MaritalStatus', MaritalStatus);
    $formData.append('Password', Password);
    $formData.append('ConfirmPassword', ConfirmPassword);
    $formData.append('BloodGroup', BloodGroup);
    $formData.append('SkinComp', SkinComp);
    $formData.append('TOB', TOB);
    $formData.append('POB', POB);
    $formData.append('Rashi', Rashi);
    $formData.append('Nakshatra', Nakshatra);
    $formData.append('SubCaste', SubCaste);
    $formData.append('Gotra', Gotra);
    $formData.append('Manglik', Manglik);
    $formData.append('Collage', Collage);
    $formData.append('Organization', Organization);
    $formData.append('FatherName', FatherName);
    $formData.append('FatherOccupation', FatherOccupation);
    $formData.append('MotherName', MotherName);
    $formData.append('MotherTongue', MotherTongue);
    $formData.append('MotherOccupation', MotherOccupation);
    $formData.append('TotalFamilyMember', TotalFamilyMember);


    $.ajax({
        url: "/Member/saveMember",
        method: "post",
        data: $formData,
        contentType: false,
        dataType: "json",
        processData: false,
        async: false,

        success: function (response) {
            alert(response.Message);
            GetMemberList();
        },
    });
}

var GetMemberList = function () {
    debugger;

    $.ajax({
        url: "/Member/GetMemberList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblReg tbody").empty();


            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.FullName +
                    "</td><td>" + elementValue.Gender +
                    "</td><td>" + elementValue.Mobile +
                    "</td><td><img src ='../Content/Img/" + elementValue.Img + "' style='max-width:100px;max-height:80px;'/>" +
                    "</td><td><button type='button' class='btn btn-primary btn-sm' onclick='EditMember(" + elementValue.Id + ")'><i class='bi bi-pencil-square' aria-hidden='true'></i></button>&nbsp;&nbsp;<button type='button' class='btn btn-info btn-sm' onclick='DetailMember(" + elementValue.Id + ")'><i class='bi bi-eye-fill' aria-hidden='true'></i></button> &nbsp;&nbsp;<button type='button' class='btn btn-danger btn-sm' onclick='DeleteMember(" + elementValue.Id + ")'><i class='bi bi-trash-fill' aria-hidden='true'></i></button>&nbsp;</td></tr>";
            });


            $("#tblReg tbody").append(html);
        }
    });
};

var DeleteMember = function (Id) {
    debugger
    var confirmed = confirm("Are you sure you want to delete?");

    if (!confirmed) {
        alert("Deletion canceled.");
        return;
    }
    model = { Id: Id }

    $.ajax({
        url: "/Member/DeleteMember",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            GetMemberList();
        }
    });
}

var EditMember = function (Id) {
    debugger
    var model = { Id: Id };

    $.ajax({
        url: "/Member/EditMember",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {

            $("#exampleModalCenter").modal('show');

            $("#hdId").val(response.model.Id);
            $("#txtname").val(response.model.FullName);
            $("#txtmobile").val(response.model.Mobile);
            $("#txtdob").val(response.model.DOB);
            $("#file1").attr("src", "../Content/Img/" + response.model.Img);
            $("#txtcaste").val(response.model.Cast);
        }

    });

}


var DetailMember = function (Id) {
    debugger;
    var model = { Id: Id }
    $.ajax({
        url: "/Member/DetailMember",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#MemberModal").modal('show');

            $("#DetailMember").empty();

            var html = "";
            html += "<div class='row'>";
            html += "<div class='col-sm-6'>";
            html += "<b'></b>&nbsp&nbsp&nbsp<span><img src='../Content/Img/" + response.model.Img + "'style='max-width:300px;max-height:280px;'></span>";
            html += "</br>";
            html += "</div>";
            html += "<div class='col-sm-6'>";
            html += "<b>Full Name:</b>&nbsp&nbsp&nbsp<span>" + response.model.FullName + "</span>";
            html += "</br>";
            html += "<b>Contact Number:</b>&nbsp&nbsp&nbsp<span>" + response.model.Mobile + "</span>";
            html += "</br>";
            html += "<b>Date Of Birth:</b>&nbsp&nbsp&nbsp<span>" + response.model.DOB + "</span>";
            html += "</br>";
            html += "<b>Cast:</b>&nbsp&nbsp&nbsp<span>" + response.model.Cast + "</span>";
            html += "</br>";
            html += "</div>";
            html += "</div>";
            $("#DetailMember").append(html);

        }
    });
};

var MemberSubscriptionList = function () {
    debugger;
    var Id = $("#hdnId").val();
    var model = {
        Id: Id
    }
    $.ajax({
        url: "/Member/GetSubscriptionMemberId",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#MemberList").empty();


            $.each(response.model, function (index, elementValue) {

                html += "<div class='col-sm-4'>";
                html += "<div class='card mb-4'>";
                html += " <div class='card-body'>";
                html += " <img src='../Content/Img/" + elementValue.Img + "'class='img-fluid image-popup' style='height:300px; width:320px;'/>";
                html += " </div>";
                html += "<div class='text-center'>";
                html += "<div style='font-size-adjust'>" + elementValue.FullName + " </div>";
                html += "<a onclick='Member(" + elementValue.Id + ")' class='btn btn-outline-danger btn-buy-now'>More Details</a>";
                html += "</div>";
                html += " </div>";
                html += " </div>";

            });


            $("#MemberList").append(html);
        }
    });
};

var Member = function (Id) {
    window.location.href = "/Member/PremiumProfileIndex?Id=" + Id;
}

var ddlMember = function () {
    debugger;
    $.ajax({
        url: "/Member/GetMemberList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#ddlMember").empty();

            $.each(response.model, function (index, elementValue) {
                html += " <option value='" + elementValue.Id + "'>" + elementValue.FullName + "</option>";

            });


            $("#ddlMember").append(html);
        }
    });
};

var GetMemberProfile = function (Id) {
    debugger

    var MemberId = $("#hdnMemberId").val();
    var model = { Id: MemberId };

    $.ajax({
        url: "/Member/EditMember",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {
            var html = "";
            $("#UserProfile").empty();
            html += "<div class='col-sm-6'>";
            html += " <div class='card mb - 4'>";
            html += " <div class='card - body'>";
            html += "<center> <img src='../Content/Img/" + response.model.Img + "' class='img - fluid image - popup' style='height: 500px; width: 420px;'/></center>";
            html += " </div>";
            html += "</div>";
            html += "</div>";
            html += " <div class='col-sm-6 card mb-4'>";
            html += " <div class=''>";
            html += " <dl class='row card-body'>";
            html += " <dt class='col-sm-5 ProductName'>Name</dt>";
            html += "<dd class='col-sm-7'>" + response.model.FullName + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Gender</dt>";
            html += "<dd class='col-sm-7'>" + response.model.Gender + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Address</dt>";
            html += "<dd class='col-sm-7'>" + response.model.Address + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Mobile</dt>";
            html += "<dd class='col-sm-7'>" + response.model.Mobile + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Email</dt>";
            html += "<dd class='col-sm-7'>" + response.model.Email + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Religin</dt>";
            html += "<dd class='col-sm-7'>" + response.model.Religion + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Subcast</dt>";
            html += "<dd class='col-sm-7'>" + response.model.SubCaste + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Goutra</dt>";
            html += "<dd class='col-sm-7'>" + response.model.Gotra + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Education</dt>";
            html += "<dd class='col-sm-7'>" + response.model.Education + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Income</dt>";
            html += "<dd class='col-sm-7'>" + response.model.Income + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>BloodGroup</dt>";
            html += "<dd class='col-sm-7'>" + response.model.BloodGroup + "</dd>";
            html += " <dt class='col-sm-5 ProductName'>Skin Complex</dt>";
            html += "<dd class='col-sm-7'>" + response.model.SkinComp + "</dd>";
            html += "</dl>";
            html += "</div>";
            html += "</div>";
            html += " <div class='d-flex justify-content-evenly'>";
            html += "<button class='btn btn-primary py-3 px-5' type = 'submit' id = 'sendMessageButton' >Contact</button >";
            html += "</div>";
            $("#UserProfile").append(html);
        }
    });
}
var GetProfile = function () {
    debugger
    var Id = $("#hdnmemberId").val();
    var model = { Id: Id };

    $.ajax({
        url: "/Member/EditMember",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {

            /* $("#lblFile").text("src", "/Content/Img/" + response.model.Img);*/
            /* $("#lblFile").text("/Content/Img/" + response.model.Img);*/
            $("#lblFile").attr("src", "/Content/Img/" + response.model.Img);
            $("#lblfullname").text(response.model.FullName);
            $("#elblfullname").text(response.model.FullName);
            $("#hlblfullname").text(response.model.FullName);
            $("#lblProfession").text(response.model.Profession);
            $("#llblProfession").text(response.model.Profession);
            $("#lblAddress").text(response.model.Address);
            $("#lblgender").text(response.model.Gender);
            $("#lblMobil").text(response.model.Mobile);
            $("#lblmail").text(response.model.Email);
            $("#lblDob").text(response.model.DOB);
            $("#lblcast").text(response.model.Caste);
            $("#lbledu").text(response.model.Education);
            $("#lblhe").text(response.model.Height);


        }

    });

}
var EditProfile = function () {
    debugger
    var Id = $("#hdnmemberId").val();
    var model = { Id: Id };

    $.ajax({
        url: "/Member/EditMember",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {
            var html = "";
            $("#profile-edit").empty();
            html += "<div class='row mb-3'>";
            html += "<label for='profileImage' class='col-md-4 col-lg-3 col-form-label'>Profile Image</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='Image' type='file' class='form-control' id='file' value='" + response.model.Img + "'>";
            html += "<img src='../Content/Img/" + response.model.Img + "' alt='Profile' >";
            html += "<div class='pt-2'>";
            html += "<a href='#' class='btn btn-primary btn-sm' title='Upload new profile image'><i class='bi bi-upload'></i></a>";
            html += "<a href='#' class='btn btn-danger btn-sm' title='Remove my profile image'><i class='bi bi-trash'></i></a>";
            html += "</div>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='fullName' class='col-md-4 col-lg-3 col-form-label'>Full Name</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='fullName' type='text' class='form-control' id='fullName' value='" + response.model.FullName + "'>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='DateOfBirth' class='col-md-4 col-lg-3 col-form-label'>Date of Birth</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='DateOfBirth' type='text' class='form-control'id='DateofBirth' value='" + response.model.DOB + "'>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='Job' class='col-md-4 col-lg-3 col-form-label'>Job</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='job' type='text' class='form-control' id='Job' value='" + response.model.Profession + "'>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='Gender' class='col-md-4 col-lg-3 col-form-label'>Gender</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='Gender' type='text' class='form-control' id='Gender'value='" + response.model.Gender + "'>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='Address' class='col-md-4 col-lg-3 col-form-label'>Address</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='address' type='text' class='form-control' id='Address'value='" + response.model.Address + "'>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='Phone' class='col-md-4 col-lg-3 col-form-label'>Phone</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='phone' type='text' class='form-control' id='Phone'value='" + response.model.Mobile + "'>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='Email' class='col-md-4 col-lg-3 col-form-label'>Email</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='email' type='email' class='form-control' id='Email'value='" + response.model.Email + "'>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='Cast' class='col-md-4 col-lg-3 col-form-label'>Cast</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='Cast' type='email' class='form-control' id='Cast' value='" + response.model.Caste + "'>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='Education' class='col-md-4 col-lg-3 col-form-label'>Education</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='Education' type='text' class='form-control' id='Education'value='" + response.model.Education + "'>";
            html += "</div>";
            html += "</div>";

            html += "<div class='row mb-3'>";
            html += " <label for='Height' class='col-md-4 col-lg-3 col-form-label'>Height</label>";
            html += "<div class='col-md-8 col-lg-9'>";
            html += "<input name='Height' type='text' class='form-control' id='Height'value='" + response.model.Height + "'>";
            html += "</div>";
            html += "</div>";
            
            html
            html += "<div class='text-center'>"; 
                html+=" <button type='submit' class='btn btn-primary'onclick='saveMember()'>Save Changes</button>";
                html+="</div>";
            html += "</form>";
            $("#profile-edit").append(html);
        }

    });

}

var GetMember = function () {
    debugger;

    $.ajax({
        url: "/Member/GetallActiveMember",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#ProfileMember").empty();


            $.each(response.model, function (index, elementValue) {

                html += "<div class='col-sm-3'>";
                html += "<div class='card mb-4'>";
                html += "<div class='card-body'>";
                html += " <img src='../Content/Img/" + elementValue.Img + "' class='img-fluid image-popup' style='height:300px;'/>";
                html += "<br />";
                html += "<br />";
                html += "<div class='text-center'>";
                html += "<button type='button' class='btn btn-outline-danger btn-buy-now owl-height' onclick='window.location.href='../ProductDetail/ProductDetailIndex''>More Details</button>";
                html += "</div>";

                html += "</div>";
                html += "</div>";
                html += "</div>";
            });


            $("#ProfileMember").append(html);
        }
    });
};
var GetBridelst = function () {
    debugger;

    $.ajax({
        url: "/Member/GetBridelst",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#GetBride").empty();
            $.each(response.model, function (index, elementValue) {

                html += "<div class='col-sm-3'>";
                html += "<div class='bestSeller'>";
                html += "<img src='../Content/Img/" + elementValue.Img + "' class='img-fluid image-popup' />";
                html += "<br />";
                html += "<br />";
                html += "<div class='text-center'>";
                html += "<h6 style='color:black;' class='text-center'>" + elementValue.FullName + "</h6>";
                html += "<button type='button' class='btn btn-outline-danger btn-buy-now owl-height' onclick='window.location.href = '../ProductDetail/ProductDetailIndex''>More Details</button>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
            });
            $("#GetBride").append(html);
        }
    });
};
var GetGroomlst = function () {
    debugger;

    $.ajax({
        url: "/Member/GetGroomlst",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#GetGroomlst").empty();
            $.each(response.model, function (index, elementValue) {

                html += "<div class='col-sm-3'>";
                html += "<div class='bestSeller'>";
                html += "<img src='../Content/Img/" + elementValue.Img + "' class='img-fluid image-popup' />";
                html += "<br />";
                html += "<br />";
                html += "<div class='text-center'>";
                html += "<h6 style='color:black;' class='text-center'>" + elementValue.FullName + "</h6>";
                html += "<button type='button' class='btn btn-outline-danger btn-buy-now owl-height' onclick='window.location.href = '../ProductDetail/ProductDetailIndex''>More Details</button>";
                html += "</div>";
                html += "</div>";
                html += "</div>";

            });
            $("#GetGroomlst").append(html);
        }
    });
};