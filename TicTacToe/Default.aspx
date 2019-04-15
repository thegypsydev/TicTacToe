<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TicTacToe.Default" %>


<asp:Content runat="server" ContentPlaceHolderID="HeaderPlaceHolder">
    <link href="css/defaultpage.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="default_heading">Tic-Tac-Toe Online</h1>
      <div class="clearfix" >
        <div class="login_form">
            <h3> Login</h3>
              <div class="form-group">
                <label class="col-md-2 control-label">
                    Username: 
                </label>
                  <input id="username_login" type="text" name="username" value="" class="col-md-10" runat="server" clientidmode="Static"/>
                  <span class="error" id="error_username" runat="server">This field is required</span><br>
            </div>
            <div class="form-group">
                <label class="col-md-2 control-label">
                    Password: 
                </label>
                <input id="password_login" type="password" name="password" value="" class="col-md-10" runat="server" clientidmode="Static"/>
                                  <span class="error" id="error_pwd" runat="server">This field is required</span><br>
<br>
            </div> 
            
            <div id="invalid_user" runat="server" clientidmode="Static" >
                Inavlid Credentials
            </div>
        </div>
       
        <div>
            <input type="button" value="Login" id="login_btn" clientidmode="Static" runat="server"/>
        </div>
       
     </div>
    <div id="default_main_content" >
        <h3>Tic Tac Toe</h3> (also called Noughts and crosses, Xs and Os, XOX Game) is a very popular children’s pencil and paper game, which is often enjoyed by many adults, as well. <br>
        Because of its simplicity, the game may seem trivial at first, however, Tic Tac Toe involves its share of analytics and rapidity.  <br>
        The game is a lot of fun for people of all ages and provides one with a great brain workout too!  <br>
        You may play Tic Tac Toe online with other players or challenge Paper Man, a robot, in order to win points and obtain a higher ranking! <br>
         Do read our strategies and tactics to help you achieve your goal to become the Number One player!  <br>
        This multiplayer game enables you to play live with hundreds of real players from the entire globe, wherever you may be and whatever language you may speak! <br>

</div>
    
    
    <div>
       <h2>Rules of Tic Tac Toe</h2> <br>
Two players challenge each other by using a 3×3 grid in Tic Tac Toe.<br>
    One player chooses noughts , the opposing player uses crosses and the first one to align 3 of their identical symbols, either noughts or crosses, (horizontally, vertically or diagonally) wins the game.
    </div>
    
    <script src="js/validatelogin.js"></script>

</asp:Content>
