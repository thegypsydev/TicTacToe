$(function () {
    $("#login_btn").click(function () {
        var username = $("#username_login").val();
        var pwd = $("#password_login").val();
        $(".error").remove();

        if (username.length < 1)
            $("#username_login").after("<span class=\"error\">This field is required</span>");
        if (pwd.length < 1)
            $("#password_login").after("<span class=\"error\">This field is required</span>");

        if (username.length > 0 && pwd.length > 0) {
            $.ajax({

                type: 'POST',

                contentType: "application/json; charset=utf-8",

                url: "/Default.aspx/Verify_User",

                data: "{'username':'" + username + "','pwd':'" + pwd + "'}",
                dataType:"json",
                success: function (response) {
                    var d = response.d;
                    console.log("" + d);
                    if (d==="success") {
                        Cookies.set("username", username);

                        window.location.replace("DashBoard.aspx");

                    }
                    else if (d==="alreadyLoggedIn") {
                        // alert("AlreadyLoggedIn");
                        window.location.replace("DashBoard.aspx");

                    }
                    else if (d === "invalidCredentials") {
                        alert("Invalid Credentials");
                      // $("invalid_user").attr("visibility", "visible");
                    }
                },

                error: function (error) {
                    alert("Some Error Occured");
                    console.log(error);

                }

            });
        }


    });
});