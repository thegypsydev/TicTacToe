$(function() {
    var usernameFromCookies = window.Cookies.get("username");
    console.log("" + usernameFromCookies);

});

$('#one,#two,#three,#four,#five,#six,#seven,#eight,#nine')
    .click(function () {
    getCurrentPlayer($(this));
});


//Rendering Interval 
setInterval(function () {
    var usernameFromCookies = window.Cookies.get("username");

    $.ajax({

        type: 'POST',

        contentType: "application/json; charset=utf-8",

        url: "/Game.aspx/GetLiveMatchList",

        data: "",
        dataType: "json",
        success: function (response) {
            var d = response.d;
            for (var j = 0; j < d.length; j++) {
                var temp = d[j];
                var playerid = temp.GameId;

                if (playerid.indexOf(usernameFromCookies) !== -1) {
                    var buttonStatus = temp.ButtonStatus;
                    var buttonsArray = [];
                    for (var i = 0; i < buttonStatus.length ; i++) {
                        var a = buttonStatus[i];
                        var id = "";
                        if (a === 1)
                            id = "one";
                        else if (a === 2)
                            id = "two";
                        else if (a === 3)
                            id = "three";
                        else if (a === 4)
                            id = "four";
                        else if (a === 5)
                            id = "five";
                        else if (a === 6)
                            id = "six";
                        else if (a === 7)
                            id = "seven";
                        else if (a === 8)
                            id = "eight";
                        else if (a === 9)
                            id = "nine";

                        if (i % 2 !== 0) {
                            buttonsArray[a] = "0";
                            $("#" + id).text("0");
                        } else {
                            buttonsArray[a] = "X";
                            $("#" + id).text("X");

                        }

                    }


                }

               
            }
            
            
        },

        error: function (error) {
            alert("Some Error Occured");
            console.log(error);

        }

    });
}, 1000);

function getCurrentPlayer(abcd) {
     var idpassed = abcd.context.id;
    var username = window.Cookies.get("username");
    $.ajax({

        type: 'POST',

        contentType: "application/json; charset=utf-8",

        url: "/Game.aspx/GetCurrentChance",
        data: "{'username':'" + username + "'}",

        //data: "",
        dataType: "json",
        success: function (response) {
            var d = response.d;
            console.log("" + d);
            var data = JSON.parse(d);

            var current = data.Current;
            var player0 = data.Player0;
            var playerX = data.PlayerX;

            if (current === "X") {
                if (playerX === username) {
                    checkWinner(username,idpassed,"X");
                   // $("#" + idpassed).text("X");

                } else {
                    alert("Not Your Turn");
                }
            }
            if (current === "0") {
                if (player0 === username) {
                   /* $("#" + idpassed).text("0");
                    addMove(username,idpassed);
                    */
                    checkWinner(username, idpassed,"0");


                } else {
                    alert("Not Your Turn");
                }
            }

          },

        error: function (error) {
            alert("Some Error Occured");
            console.log(error);

        }

    });

}

function addMove(username, idpassed, playerClicked) {

    $.ajax({

        type: 'POST',

        contentType: "application/json; charset=utf-8",

        url: "/Game.aspx/AddMove",
        data: JSON.stringify({
            username: username,
            idPassed: idpassed

        }),
        dataType: "json",
        success: function (response) {
            console.log(response);
            $("#" + idpassed).text(""+playerClicked);
            //alert("Move Added");
        },

        error: function (error) {
            alert("Some Error Occured");
            console.log(error);

        }

    });

}

function checkWinner(username,idpassed,playerClicked) {
    $.ajax({

        type: 'POST',

        contentType: "application/json; charset=utf-8",

        url: "/Game.aspx/GameStatus",
        data: JSON.stringify({
            clickedBy: username

        }),
        dataType: "json",
        success: function (response) {

            var d = response.d;
            if (d === "Winner is X") {
                alert("Player X Won");
                window.location.replace("Dashboard.aspx");

            }
            else if (d === "Winner is 0") {
                alert("Player 0 Won");
                window.location.replace("Dashboard.aspx");

            }
            else if (d==="Game is a Tie") {
                alert("It's a Tie");
                window.location.replace("Dashboard.aspx");

            }else if (d === "proceed") {
                var filled = $("#" + idpassed).text();

                if (filled !== "") {
                    alert("Already Filled Block");

                } else {
                    addMove(username, idpassed, playerClicked);
                    getCurrentPlayer(idpassed);
                }
            }

            //Id needed here
            

            //Block filled
            //Add MOve
            //alert("Move Added");
        },

        error: function (error) {
            alert("Some Error Occured");
            console.log(error);

        }

    });

}