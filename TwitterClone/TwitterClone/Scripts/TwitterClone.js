$("#btnSignUp").click(function () {

    var serviceurl = 'CreateNewAccount';
    var activeInd = false;
    var isError = false;

    if ($("#ActiveInd").is(":checked")) { activeInd = true; }

    if ($("#User_ID").val() === "" || $("#User_ID").val() === null) {
        alert("Please Enter the User ID");
        isError = true;
    }
    if ($("#Password").val() === "" || $("#Password").val() === null) {
        alert("Please Enter the Password");
        isError = true;
    }
    if ($("#FullName").val() === "" || $("#FullName").val() === null) {
        alert("Please Enter the FullName");
        isError = true;
    }
    if ($("#Email").val() === "" || $("#Email").val() === null) {
        alert("Please Enter the valid Email");
        isError = true;
    }

    if (isError) { return false; }

    var UserModel = {
        'User_ID': $("#User_ID").val(),
        'Password': $("#Password").val(),
        'FullName': $("#FullName").val(),
        'Email': $("#Email").val(),
        'ActiveInd': activeInd
    };

    $.ajax({
        contentType: "application/json; charset=utf-8",
        url: serviceurl,
        data: UserModel,
        success: function (e) {
            alert("Successfully created");
        }
    });
});

$("#btnLogin").click(function () {

    var serviceurl = 'User/UserLogin';
    var isError = false;

    if ($("#User_ID").val() === "" || $("#User_ID").val() === null) {
        alert("Please Enter the User ID");
        isError = true;
    }
    if ($("#Password").val() === "" || $("#Password").val() === null) {
        alert("Please Enter the Password");
        isError = true;
    }

    if (isError) { return false; }

    var LoginViewModel = {
        'User_ID': $("#User_ID").val(),
        'Password': $("#Password").val()

    };

    $.ajax({
        contentType: "application/json; charset=utf-8",
        url: serviceurl,
        data: LoginViewModel,
        success: function (e) {
            if (e.isValidUser) {
                var UserViewModel = {
                    'User_ID': e.User_ID,
                    'Password': e.Password,
                    'FullName': e.FullName,
                    'Email': e.Email,
                    'Joined': e.Joined,
                    'ActiveInd': e.ActiveInd,
                    'isValidUser': e.isValidUser
                };
                //getMyTwitterClone(e);
                window.location.href = "User/MyTwitterClone?User_ID=" + e.User_ID;
            }
            else {
                alert("UserName and Password is Incorrect");
            }
        }
    });
});


$("#btnUpdate").click(function () {

    var serviceurl = 'TwitteSave';
    var isError = false;
        
    if ($("#TweetContent").val() === "" || $("#TweetContent").val() === null) {
        alert("Please Enter the TweetContent");
        isError = true;
    }

    if (isError) { return false; }

    var TwitteViewModel = {
        'User_ID': $("#User_ID").val(),
        'TweetContent': $("#TweetContent").val()
    };
    
    var userid = $("#User_ID").val();

    $.ajax({
        contentType: "application/json; charset=utf-8",
        url: serviceurl,
        data: TwitteViewModel,
        success: function (e) {
            var UserViewModel = {
                'User_ID': $("#User_ID").val()
            };
            $("#divTwitte").load('@Url.Action("Twitte","User",new{User_ID=userid})')
        }
    });
});


