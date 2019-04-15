$(function () {
    var usernameFromCookies = window.Cookies.get("username");
    var prevCount = 0;


    setInterval(function() {
        $.ajax({

            type: 'POST',

            contentType: "application/json; charset=utf-8",

            url: "/Dashboard.aspx/GetUsersList",

            data: "",
            dataType: "json",
            success: function (response) {
                var d = response.d;

                var trHTML = '';
                var currentCount = d.length;
                if (currentCount>prevCount) {
                    for (var i = prevCount; i < currentCount; i++) {
                        item = d[i];
                        var username = item.Username;

                        console.log("previous" + prevCount + " current" + currentCount);

                        if (usernameFromCookies === username) {
                            window.Cookies.set("PlayerId", d[i].PlayerId);
                            myPlayerId = d[i].PlayerId;
                          
                            trHTML = '';
                        } else {
                            var playerid = d[i].PlayerId;
                            var receiver = d[i].Username;
                            trHTML = '<tr><td>' + d[i].Name + '</td><td>'
                            + d[i].Email + '</td><td>'
                            + d[i].Username + '</td><td>'
                            + d[i].GamesPlayed + '</td><td>'
                            + d[i].GamesWon + '</td><td>'
                            + d[i].Status
                            + '</td><td><a onClick="doConfirm(\'' + playerid + '\',\'' + receiver + '\');" style="color:blue;">Challenge Opponent</a></td></tr>';
                        }
                        $('#players_table').append(trHTML);

                    }
                    prevCount = currentCount;
                }

            },

            error: function (error) {
                alert("Some Error Occured");
                console.log(error);

            }

        });
    }, 1000);


    setInterval(function () {

        $.ajax({

            type: 'POST',

            contentType: "application/json; charset=utf-8",

            url: "/Dashboard.aspx/GetGameRequestsList",

            data: "",
            dataType: "json",
            success: function (response) {
                var d = response.d;
                for (var i = 0; i < d.length; i++) {
                    item = d[i];
                    console.log("" + item);

                    if (item.SentTo === Cookies.get("PlayerId")) {
                        //alert("You got a request");
                        acceptRequest(item.SenderName);


                    }

                }

            },

            error: function (error) {
                alert("Some Error Occured");
                console.log(error);

            }

        });
    }, 6000);

    setInterval(function () {

        $.ajax({

            type: 'POST',

            contentType: "application/json; charset=utf-8",

            url: "/Dashboard.aspx/GetLiveMatchList",

            data: "",
            dataType: "json",
            success: function (response) {
                var d = response.d;
                for (var i = 0; i < d.length; i++) {
                     var item = d[i];
                    console.log("" + item);

                    if (item.Sender === usernameFromCookies) {
                        window.location.replace("Game.aspx");
                    }

                    /*if (item.SentTo === Cookies.get("PlayerId")) {
                        //alert("You got a request");
                        acceptRequest(item.SenderName);


                    }*/

                }

            },

            error: function (error) {
                alert("Some Error Occured");
                console.log(error);

            }

        });
    }, 3000);


});

function Popup(message) {
    alert(""+message);
}


function doConfirm(playerid,reciever) {
    var sentby = window.Cookies.get("PlayerId");
    var sender = window.Cookies.get("username");


    $("#confirmBox").dialog({
        resizable: false,
        height: "auto",
        width: 400,
        modal: true,
        buttons: {
            "Challenge Opponent ": function () {
                $(this).dialog("close");
               console.log("sent by " + sentby+"  sentto "+playerid);

                $.ajax({

                    type: 'POST',

                    contentType: "application/json; charset=utf-8",

                    url: "/Dashboard.aspx/AddGameRequest",
                    data: JSON.stringify({
                        sentto: playerid,
                        sentby: sentby,
                        status: "Pending",
                        sender:sender,
                        receiver:reciever

                    }),
                    //data: "{'sentto':'" + playerid + "','senttby':'" + sentby + "','status':'Pending'}",
                    dataType: "json",
                    success: function (response) {
                        console.log(response);
                    },

                    error: function (error) {
                        alert("Some Error Occured");
                        console.log(error);

                    }

                });


            },
            Cancel: function () {
                $(this).dialog("close");
            }
        }
    });

}

function acceptRequest(senderName)
{
    // $("#acceptRequestBox .modal-body").text('pass your text here');
    var receiverName = window.Cookies.get("username");
    $("#challengersDetail").text('' + senderName + ' challenged you');


    $("#acceptRequestBox").dialog({
        resizable: false,
        height: "auto",
        width: 400,
        modal: true,

        buttons: {
            "Accept the Challenge": function () {
                $(this).dialog("close");
                challengeAccepted(senderName, receiverName);


            },
            "Deny": function () {
                $(this).dialog("close");
                denyRequest(senderName, receiverName);

            }
        }
    });

}


function denyRequest(senderName,receiverName) {
    
    $.ajax({

        type: 'POST',

        contentType: "application/json; charset=utf-8",

        url: "/Dashboard.aspx/RemoveRequest",

        data: JSON.stringify({
           sender:senderName,
            receiver:receiverName

        }),
        dataType: "json",
        success: function (response) {
            var d = response.d;
            console.log(response);


        },

        error: function (error) {
            alert("Some Error Occured");
            console.log(error);

        }

    });

}

function challengeAccepted(senderName, receiverName) {
    $.ajax({

        type: 'POST',

        contentType: "application/json; charset=utf-8",

        url: "/Dashboard.aspx/ChallengeAccepted",

        data: JSON.stringify({
            sender: senderName,
            receiver: receiverName

        }),
        dataType: "json",
        success: function (response) {
            var d = response.d;
            console.log(response);
            window.location.replace("Game.aspx");



        },

        error: function (error) {
            alert("Some Error Occured");
            console.log(error);

        }

    });

}