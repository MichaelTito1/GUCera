<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="GUCera.StudentHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Student Home
    </title>
    <link rel="shortcut icon" href="/favicon.ico"/>
    <style>
        html, body {
           overflow:hidden;
            height: 100%;
            width:100%;
            background-color:#878f99;
        }
         .topPanel{
            display:flex;
            flex-direction:row;
            position:absolute;
            z-index:100;
            height:80px;
            left:-10px;
            right:-3px;
            top:-10px;
            background-color:#074f44;
            
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 1);
        }
           .logo{
            
            margin:10px;
            margin-left:7%;
            margin-top:20px;
            width:50px;
            height:50px;
        }
           #GUCera{
           margin:10px; 
           margin-left:1%;
           color:#eeeeee;
           font-size:50px;
           font-family:cursive
       }
           #fname{
           margin:35px; 
           margin-left:3%;
           color:#aaaaaa;
           font-size:30px;
           font-family:sans-serif;
       }
           #logout{
            display:block;
            background-color:#074f44;
            margin:auto;
            margin-left:50%;
            min-height:80px;
            
            width:100px;
            border:1px solid #074f44;
            border-left:3px solid #808080;
            
            color:#bbbbbb;
            font-size:20px;
            font-family: Circular, Helvetica, Arial, sans-serif;    
        }
        #logout:hover{
            
            color:#ffffff;
        }
        #form1{
            display:flex;
            flex-direction:row;
            margin-top:50px;
        }
        #baseDiv{
            margin:0 auto;
            padding:25px;
            padding-top:50px;
            width:70%;
            min-height:100vh;
            background-color:#ffffff;
          
        }
         #leftPanel{

            padding-top:30px;
            width:22%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 1);
        }
        .panelButton{
            width:100%;
            height:60px;
            font-size:20px;
            font-family:  Open Sans,Helvetica,sans-serif;
            background-color:#878f99;
            border:none;
            border-bottom:thin groove #ffffff;
            border-top:thin groove #ffffff;
            color:#eeeeee;

        }
        .panelButton:hover{
            background-color:#92a9ac;
        }
        .textDiv1{
           
            width:50%;
            margin-left:5%;
            display:block;
            font-family:  Open Sans,Helvetica,sans-serif;
            color:#334433;
            font-size:45px;
        }
         .textDiv2{
            float:left;
            margin-left:5%;
            width:40%;
            font-family:  Open Sans,Helvetica,sans-serif;
            color:#779977;
            font-size:30px;
            padding:10px 10px;
          
            
        }
         #baseDiv img{
             display:block;
             border-radius:300px;
             float:right;
             width:500px;
             height:600px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="topPanel">
        <img src="images//logo.png"/ class="logo"/>
        <asp:Label ID="GUCera" Text="GUCera" runat="server"></asp:Label>
        <asp:Label ID="fname" runat="server"></asp:Label>
        <asp:Button ID="logout" runat="server" Text="Logout" OnClick="logoutClick" />
    </div>
    
        <div id="leftPanel">
            
            <asp:Button class="panelButton" ID="addPhone" runat="server" Text="Add Phone Number" OnClick="addPhone_Click" />
            <asp:Button class="panelButton" ID="profile" runat="server" Text="My Profile" OnClick="profile_Click" />
           
            <asp:Button class="panelButton" ID="coursesToEnroll" runat="server" Text="Show available courses" OnClick="coursesToEnroll_Click" />
            <asp:Button class="panelButton" ID="creditCard" runat="server" Text="Add Credit Card" OnClick="creditCard_Click" />
            <asp:Button class="panelButton" ID="promo" runat="server" Text="View PromoCodes" OnClick="promo_Click" />
            <asp:Button class="panelButton" ID="enrolled" runat="server" Text="Enrolled Courses" OnClick="enrolled_Click" />
            
        </div>
        <div id="baseDiv" >
            <img src="images//home2.png" />
            <div class="textDiv1">
                <h1>
                Welcome to GUCera 
                </h1>
            </div>
            <div class="textDiv2">
                Build skills with courses, certificates, and degrees online from world-class universities and companies.
            </div>
            
        </div>
    </form>
</body>
</html>
