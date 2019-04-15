<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="TicTacToe.Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


    <div class="game-board">
  <div id='one' clientidmode="Static" class="box"></div>
  <div id="two" clientidmode="Static" class="box"></div>
  <div id="three" clientidmode="Static" class="box"></div>
  <div id="four" clientidmode="Static" class="box"></div>
  <div id="five" clientidmode="Static" class="box"></div>
  <div id="six" clientidmode="Static" class="box"></div>
  <div id="seven" clientidmode="Static" class="box"></div>
  <div id="eight" clientidmode="Static" class="box"></div>
  <div id="nine" clientidmode="Static" class="box"></div>
</div>
    

    <link href="css/game.css" rel="stylesheet" />
    S 

    
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="js/game.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>

</body>
</html>
