<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addPhone.aspx.cs" Inherits="GUCera.addPhone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Phone</title>
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
            width:30%;
            min-height:100px;
        }
        .inpContainer span{
            color:#707070 !important;
            font-size:20px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            margin-bottom:19px;

        }
        .inpContainer input{
            padding-bottom:3px;
            width:100%;
            display:block;
            margin: 3px auto;
            font-size:20px;
            border-radius:7px;
            height:45px;
            border:1px solid #aaaaaa;
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
                <div id="icid" class="inpContainer" runat="server">
                    <asp:Label ID="lbl" runat="server" Text="Add a new phone:" style="margin-bottom:30px;"></asp:Label>
                    <div style="display:flex;flex-direction:row">
                    <asp:TextBox ID="number" maxlength="11" placeholder="01234567890" runat="server" Style="margin-bottom:30px"></asp:TextBox>
                    <asp:Button ID="add" runat="server" Text="+" OnClick="add_Click" style="width:50px;height:50px"/>
                    </div>
                </div>
                
        </div>
    </form>
</body>
</html>
