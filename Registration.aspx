<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="GUCera.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Register
    </title>
    <link rel="shortcut icon" href="/favicon.ico"/>
    <style>
         body {
            height: 100%;
            width:100%;
            background-color:#878f99;
        }
         .topPanel{
            display:flex;
            flex-direction:row;
            position:absolute;
            z-index:100;
            height:150px;
            left:-10px;
            right:-3px;
            top:-10px;
            background-color:#074f44;
            
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 1);
        }
           #GUCera{
           margin:10px; 
           
           color:#eeeeee;
           font-size:80px;
           font-family:cursive
       }
           #welcome{
           margin:10px; 
           margin-top:60px;
           margin-left:30%;
           color:#bbbbbb;
           font-size:30px;
           font-family:cursive
       }
           .inpContainer{
            margin:30px auto;
            padding:50px 20px;
            font-size:50px;
            color:#707070;
            display:flex;
            flex-direction:column;
            min-height:100px;
            border-radius:0px;
            background-color:#FFFFFF ;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.15);
            width:50%;
            min-height:100px;
        }
        .inpContainer span{
            color:#707070 !important;
            font-size:20px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            margin-bottom:10px;
            margin-top:20px;

        }
        .textbox{
            padding-bottom:3px;
            width:100%;
            display:block;
            margin: 3px auto;
            font-size:20px;
            border-radius:7px;
            height:45px;
            border:1px solid #aaaaaa;
        }
        .RadioButton{
            background-color:#eeeeee;
            color:#777777;
            padding-bottom:3px;
            width:100%;
            display:block;
            margin: 3px auto;
            font-size:20px;
            border-radius:7px;
            
            border:1px solid #aaaaaa;
        }
          
        #form1{
            display:flex;
            flex-direction:row;
            margin-top:50px;
        }
        #baseDiv{
            margin:0 auto;
            padding:25px;
            padding-top:150px;
            width:75%;
            min-height:100vh;
            background-color:#ffffff;
          
        }
        .ButtonClass{
            display:block;
            background-color:rgb(29, 166, 77);
            margin:auto;
            min-height:65px;
            margin-top:80px;
            min-width:250px;
            border-radius:50px;
            border:3.5px solid rgb(29, 166, 77);
            width:25%;
            color:#eeeeee;
            font-size:25px;
            font-family: Circular, Helvetica, Arial, sans-serif;    
        }
        .login{
            display:block;
            background-color:#074f44;
            margin:auto;
            min-height:100px;
            
            width:100px;
            border:1px solid #074f44;
            border-left:3px solid #808080;
            
            color:#bbbbbb;
            font-size:20px;
            font-family: Circular, Helvetica, Arial, sans-serif;    
        }
        #loginPage:hover{
            
            color:#ffffff;
        }
        .ButtonClass:hover{
            background-color:#ffffff;
            color:rgb(29, 166, 77);
        }
        #msg{
            color:#eeeeee;
            width:70%;
            margin-left:25%;
        }
        #msg span{
            color:red;
            height:10px;
            width:70%;
            font-size:25px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="topPanel">
        <asp:Label ID="welcome" text="Welcome to " runat="server"></asp:Label>
        <asp:Label ID="GUCera" Text="GUCera" runat="server"></asp:Label>
        <asp:Button ID="loginPage" class="login" runat="server" Text="Login" OnClick="loginPage_Click"  />
    </div>
    
        <div id="baseDiv" runat="server">
            <div id="msg" runat="server"></div>
            <div id="inpContainer" class="inpContainer" runat="server">
                <asp:Label ID="type" Text="Type of User" runat="server"></asp:Label>
                <asp:RadioButtonList class="RadioButton" ID="UserType" runat="server">
                    <asp:ListItem selected="True" value="Student">Student</asp:ListItem>  
                    <asp:ListItem value="Instructor">Instructor</asp:ListItem>
                </asp:RadioButtonList>
           
                <asp:Label ID="fname" Text="First Name *" runat="server"></asp:Label>
                <asp:TextBox ID="firstname" class="textbox" maxlength="10" runat="server"></asp:TextBox>
                <asp:Label ID="lname" Text="Last Name *" runat="server"></asp:Label>               
                <asp:TextBox ID="lastname" class="textbox" maxlength="10" runat="server"></asp:TextBox>
                <asp:Label ID="pass" Text="Password *" runat="server"></asp:Label>
                <asp:TextBox ID="password"  class="textbox" maxlength="10" TextMode="Password" runat="server"></asp:TextBox>

            
                <asp:Label ID="gender"  Text="Gender" runat="server"></asp:Label>
                <asp:RadioButtonList class="RadioButton" ID="genderList" runat="server" >
                    <asp:ListItem Selected="True">Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
           
                <asp:Label ID="emailLbl" Text="Email *" runat="server"></asp:Label>
                <asp:TextBox ID="email" class="textbox" maxlength="10" runat="server"></asp:TextBox>

           
                <asp:Label ID="addressLbl" Text="Address" runat="server"></asp:Label>
                <asp:TextBox ID="address" class="textbox" MaxLength="10" runat="server"></asp:TextBox>
                <asp:Button ID="register" class="ButtonClass" runat="server" onclick="confirmRegistration" Text="Register"  />
                

            </div>
            
        </div>
    </form>
</body>
</html>
