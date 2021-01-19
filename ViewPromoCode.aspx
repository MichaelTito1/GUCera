<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPromoCode.aspx.cs" Inherits="GUCera.ViewPromoCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Promocode
    </title>
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
        #home{
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
        #home:hover{
            background-color:#92a9ac;
        }
        #lowerDiv{
            padding:7px;
            display:flex;
            flex-direction:column;
            margin:auto;           
            width:93%;
            border-radius:20px;
            min-height:700px;
            border:5px solid black;
            background-color:#b2c9cc;
        }
        .PromoContainer{
            margin-bottom:5px;
            display:flex;
            height:150px;
            flex-direction:row;
            background-color:#82999c;
            border:2px solid black;
            border-radius:10px;
        }
        .subPromoContainer{
            color:#ffffff;  
            padding:3px;
            padding-left:20px;
            margin:auto;
            font-size:25px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            line-height:40px;
            width:40%;
            height:145px;
            display:flex;
            flex-direction:column;
            background-color:#92a9ac;
            border-right:1px dashed;
            border-left:1px dashed;
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
        <img src="images//logo.png"/ class="logo"/>
        <asp:Label ID="GUCera" Text="GUCera" runat="server"></asp:Label>
        <asp:Label ID="fname" runat="server"></asp:Label>
    </div>
    <form id="form1" runat="server">
        <div id="leftPanel">
            <asp:Button ID="home" runat="server" Text="Home" OnClick="home_Click" />
        </div>
        <div id="baseDiv" runat="server">
            <div id="msg" runat="server"></div>
            <div id="containerDiv" runat="server">

            </div>
        </div>
    </form>
</body>
</html>
