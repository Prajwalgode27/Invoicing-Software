var SaveReg = function () {
    debugger;
    $formData = new FormData();
    var Image = document.getElementById('file1');
    if (Image.files.length > 0) {
        for (var i = 0; i < Image.files.length; i++)
        {
            $formData.append('file1-' + i, Image.files[i]);

        }
    }
   
    var fullname = $("#txtname").val();
    var mail = $("#txtmail").val();
    var mob = $("#txtmob").val();
    var gender = "";

    if ($('#rdoMale').prop('checked') == true)
        gender = "Male";
    else
        gender = "Female"; 

    var religion = $("#ddlReligion").val();
    var dob = $("#txtdob").val();
    var img = $("#file1").val();
    var password = $("#txtpwd").val();
    var confirmpassword = $("#txtcpwd").val();
    var address = $("#txtadd").val();

    if (fullname == "")
    {
        alert("Please Enter FullName");
        $("#txtname").focus();
        return false;
    }
   
    if (gender == "")
    {
        alert("Please Select Gender");
        $("#rdoMale").focus();
        return false;
    }
    if (religion == "")
    {
        alert("Please Select Religion");
        $("#ddlReligion").focus();
        return false;
    }
    if (password == "")
    {
        var filter = /^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[$@$!%?&])[A-Za-z\d$@$!%?&]{8,}/;
        if (!filter.test(password)) {
            alert("Please Enter Valid Password");
            $("#txtpwd").focus();
            return false;

        }
    }
    if (confirmpassword == "") {
        var filter = /^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[$@$!%?&])[A-Za-z\d$@$!%?&]{8,}/;
        if (!filter.test(confirm)) {
            alert("Please Enter Valid Password");
            $("#txtcpwd").focus();
            return false;

        }
    }

    if (mail == "")
    {
        var filter = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
        if (!filter.test(mail))
        {
            alert("Please Enter Valid Email");
            $("#txtmail").focus();
            return false;

        }
    }
    if (mob == "")
    {
        var filter = /^[0-9]{10}/;
        if (!filter.test(mob))
        {
            alert("please enter Mobile Number");
            $("#txtmob").focus();
            return false;
        }

    }

    $formData.append('FullName', fullname);
    $formData.append('Email', mail);
    $formData.append('Mobile', mob);
    $formData.append('Gender', gender);
    $formData.append('Religion', religion);
    $formData.append('DOB', dob);
    $formData.append('Img', img);
    $formData.append('Password', password);
    $formData.append('Confirmpassword', confirmpassword);
    $formData.append('Address', address);



    $.ajax({
        url: "/Home/saveregistration",
        method: "post",
        data: $formData,
        contentType: false,
        processData: false,
        async: false,
        success: function (responce) {
            location.reload();
            alert(responce.Message);
           
        }
    });

}

