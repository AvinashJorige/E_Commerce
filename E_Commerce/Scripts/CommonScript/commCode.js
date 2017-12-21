$(document).ready(function () {
    // LOGIN INFORAMATION 
    loginMaintaince();
});

function loginMaintaince() {
    try {
        //GET THE LOG INFO FROM SESSION STORAGE
        var logInfo = sessionStorage("logInfo", null, "get");
        if (logInfo) {
            $(".logIn_nav").hide();
            $(".signUp_nav").hide();
            $(".logName").html(logInfo.UserName);
        }
    } catch (e) {
        console.log("COMMCODE|LOGMAINTAINCE|ERROR: ", e);
    }
}