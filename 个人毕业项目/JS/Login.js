function UserLogin() {
    $(document).keydown(function (e) {
        if (e.keyCode == 13)
            Login();
    });

}
function displayPrompt() {
    document.getElementById("prompt").style.display = "block";
}
function Login() {
    var UserName = $("#input-topright-loginInput").val();
    var UserPwd = $("#input-topright-loginInput").val();
    if (UserName == "" && UserPwd == "") {
        displayPrompt();
        document.getElementById("prompt").innerHTML = "<i id='promptIcon'></i>请输入账号和密码!";
        return;
    }
    else if (UserName == "") {
        displayPrompt();
        document.getElementById("prompt").innerHTML = "<i id='promptIcon'></i>请输入账号!";
        return;
    }
    else if (UserPwd == "") {
        displayPrompt();
        document.getElementById("prompt").innerHTML = "<i id='promptIcon'></i>请输入密码!";
        return;
    }
       
    var pr = "username" + UserName;
    $.ajax({
        url: "Login.ashx",
        type: "get",
        data: pr,
        async: false,
        cache: false,
        dataType: "json",
        success: function (data) {
            if (!isNaN(data)) {
                alert("用户名不存在！");
                return;
            }
            $.each(data, function (index, model) {
                if (UserPwd != model.UserPwd) {
                    alert("密码错误！");
                    return;
                }

                $("#input-topright-loginInput").val("")
                $("#input-topright-loginInput").val("")
                window.location.href = "Origin.html?userName=" + model.UserName;
            });
        }
    });
}