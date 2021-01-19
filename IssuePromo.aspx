<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssuePromo.aspx.cs" Inherits="GUCera.IssuePromo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="/favicon.ico"/>
    <style>
         html, body {
           
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
            margin:0 auto;
            padding:25px;
            padding-top:50px;
            width:75%;
            min-height:100vh;
            background-color:#ffffff;
        }
         #leftPanel{
            padding-top:30px;
            width:15%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 1);
        }
        #Home{
            width:100%;
            height:60px;
            font-size:30px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            background-color:#878f99;
            border:none;
            border-bottom:thin groove #ffffff;
            border-top:thin groove #ffffff;
            color:#eeeeee;
        }
        #Home:hover{
            background-color:#92a9ac;
        }
        .inpContainer{
            padding:50px 20px;
            font-size:20px;
            color:#707070;
            display:flex;
            flex-direction:column;
            margin:auto;
            border-radius:10px;
            width:30%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.5);
        }
        .inpContainer span{
            color:#074f44;
            font-size:30px;
            margin:8% 0% 3% 0%;
            font-family: Circular, Helvetica, Arial, sans-serif;

            
        }
        .inpContainer input{
            padding-bottom:3px;
            width:100%;
            display:block;
            margin: 7px auto;
            font-size:20px;
            border-radius:7px;
            height:45px;
            border:1px solid #aaaaaa;
        }
        #IssueP{
            height:60px;
            font-size:30px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            background-color:#074f44;
            border:none;
            border-bottom:thin groove #ffffff;
            border-top:thin groove #ffffff;
            border-color:#074f44;
            border-radius:10px;
            color:white;
        }
        #IssueP:hover{
            background-color:white;
            color:#074f44;
        }
           #msg{
            color:#eeeeee;
            width:70%;
            
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
    <div class="topPanel">
        <asp:Label ID="GUCera" Text="GUCera" runat="server"></asp:Label>
        <asp:Label ID="fname" runat="server"></asp:Label>
    </div>
    <form id="form1" runat="server">
        <div id="leftPanel">
            <asp:Button ID="Home" Text="Home" runat="server" OnClick="Home_Click" />
        </div>
        <div id="baseDiv">
            <div id="msg" runat="server">
            </div>
            <div class="inpContainer">
        <div>
            <asp:Label ID="codde" Text="Code *" runat="server"></asp:Label>
            <asp:TextBox ID="Code" MaxLength="6" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="SID" Text="StudentID *" runat="server"></asp:Label>
            <asp:TextBox ID="StudentID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="IssueP" runat="server" Text="Issue" OnClick="IssueP_Click" />
            </div>
                <img src="images//percentage.jpeg" />
                </div>
        </div>
    </form>
</body>
</html>
