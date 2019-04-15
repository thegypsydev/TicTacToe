<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="TicTacToe.DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <h2 id ="heading_dashboard" runat="server" ClientIDMode="Static">Online Players</h2>
    
    <div>
        <table id="players_table" runat="server" ClientIDMode="Static">
            <thead>
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Username</th>
                <th>Games Played</th>
                <th>Games Won</th>
                <th>Status</th>
                <th></th>

            </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
    
    <div id="confirmBox" title="Challenege The Opponent" style="display: none">
  <p><span class="ui-icon ui-icon-info" style="float:left; margin:12px 12px 20px 0;"></span>
      If the User accepts your Request, you both would be connected.</p>
</div>
    
     <div id="acceptRequestBox" title="Accept the Challenge" style="display: none">
  <p id="challengersDetail" ><span class="ui-icon ui-icon-info" style="float:left; margin:12px 12px 20px 0;"></span>
     Let's Get It Started.</p>
</div>
    

    
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
  <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="js/dashboard.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>

</body>
</html>
