<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="GUCera.AdminHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="/favicon.ico"/>
    <style> 
         html, body {
           
            height:100%;
            width:100%;
            background-color:#878f99;
        }
         .topPanel{
            position:absolute;
            z-index:100;
            height:80px;
            left:-10px;
            right:-3px;
            top:-10px;
            background-color:#074f44;
            
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 1);
        }
           #GUCera{
           margin:10px; 
           margin-left:10%;
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
          
        #form1{
            display:flex;
            flex-direction:row;
            margin-top:50px;
        }
        #baseDiv{
            display:flex;
            flex-direction:row-reverse;
            margin:0 auto;
            padding:25px;
            padding-top:50px;
            width:65%;
            min-height:90vh;
            background-color:#ffffff;
        }
         #leftPanel{
            padding-top:30px;
            width:25%;
            margin-right:5px;
            height:auto;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 1);
            background-color:#878f99;
        }
        .home{
            width:100%;
            height:100px;
            font-size:20px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            background-color:#878f99;
            border:none;
            border-bottom:thin groove #ffffff;
            border-top:thin groove #ffffff;
            color:#eeeeee;
        }
        .home:hover{
            background-color:#92a9ac;
        }
        .inpContainer{
            padding:50px 20px;
            font-size:20px;
            color:#707070;
            display:flex;
            flex-direction:column;
            margin:3% auto;
            width:40%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0);
        }
        .inpContainer span{
            font-weight:bold;
            color:#AAAAAA;
            font-size:30px;
            margin:5% 0% 3% 0%;
            font-family: Brush New, Courier, monospace;   
        }
         #baseDiv img{
             display:block;                    
             float:right;
             width:500px;
             height:100%;
         }
          #logout{
              position:absolute;
              top:0px;
              right:100px;
            display:block;
            background-color:#074f44;
            
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="topPanel">
        <asp:Label ID="GUCera" Text="GUCera" runat="server"></asp:Label>
        <asp:Label ID="fname" runat="server"></asp:Label>
        <asp:Button ID="logout" runat="server" Text="Logout" OnClick="logoutClick" />
    </div>
    
            <div id="leftPanel" runat="server">
            <asp:Button ID="ViewCourses" CssClass="home" runat="server" Text="ViewAllcourses"  OnClick="ViewCourses_Click" />
            <asp:Button ID="NotAcceptedCourses" CssClass="home" runat="server" Text="ViewNotYetAcceptedCourses"  OnClick="NotAcceptedCourses_Click" />
            
            <asp:Button ID="Promo" CssClass="home" runat="server"  Text="CreatePromoCode"  OnClick="Promo_Click" />
            <asp:Button ID="Issue" CssClass="home" runat="server" Text="IssuePromoCodeToStudent"  OnClick="Issue_Click" />
            <asp:Button ID="Addmob" CssClass="home" runat="server" Text="AddmobileNumber"  OnClick="Addmob_Click" />
                 </div>            
            <div id="baseDiv" runat="server">
                <div class="inpContainer" runat="server">
                <asp:Label ID="Welcome" Text="WELCOME ABOARD!" style="font-size:96px;font-weight:bold;color:#074f44" runat="server"></asp:Label>
                 <asp:Label ID="Welcome2" Text="Congratulations on being a part of the team" style="margin-left:20px" runat="server"></asp:Label>
                    </div>
                <img src="images//admin.jpeg" />
            </div>
    </form>
</body>
</html>
