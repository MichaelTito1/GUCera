<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUCera.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="/favicon.ico"/>
    <title>
        Welcome
    </title>
    <style>
        
        html, body {
            overflow:hidden;
            height: 100%;
            width:100%;
            background-color:#ffffff;
        }
         .borderPanel{
            
            display:flex;
            flex-direction:row;
            position:absolute;
            z-index:100;
            height:90px;
            left:-10px;
            right:-3px;
            
            background-color:#074f44;
          
    
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 1);
        }
         .logo{
            display:flex;
            flex-direction:row;
            padding:130px;
            padding-left:100px;
        }
           #GUCera{
          
           
           color:#074f44;
           font-size:150px;
           font-family:cursive;
            
           }
           
        img{
            
            
            width:200px;
            height:200px;
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
            flex-direction:column;
            padding:30px 80px;
            padding-top:10px;
            margin:5% auto;
            margin-right:10%;
            width:55%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.15);
            
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
          #msg{
            color:#eeeeee;
            width:70%;
            
        }
        #msg span{
            color:red;
            height:10px;
            width:70%;
            font-size:18px;
        }
        #loginlbl{
            color:#aaaaaa;
            border:1px solid white;
            padding-bottom:5px;
            border-bottom:2px solid #aaaaaa ;
            margin-bottom:5%;
            
            text-align:center;
            font-size:35px;
        }
        .lbl{
            color:#707070;
            font-size:20px;
            margin:8% 0%;
            margin-bottom:0%;
            font-family: Circular, Helvetica, Arial, sans-serif;
        }
        .txt{
            padding-bottom:3px;
            width:100%;
            display:block;
            margin: 5px auto;
            font-size:20px;
            border-radius:7px;
            height:45px;
            border:1px solid #aaaaaa;

        }
        #signIn{
             display:block;
            background-color:rgb(29, 166, 77);
            margin:auto;
            min-height:65px;
            margin-top:10px;
            border-radius:50px;
            border:3.5px solid rgb(29, 166, 77);
            width:70%;
            color:#eeeeee;
            font-size:25px;
            font-family: Circular, Helvetica, Arial, sans-serif;
        }
        #register{
            font-size:15px;
            color:#bb2222;
            margin:5%;
            background-color:#ffffff;
            border:1px solid white;
        }
        #register:hover{
            text-decoration: underline;
        }
        
    </style>
</head>
<body>
     <div class="borderPanel" style="top:-10px;"></div>
    <form id="form1" runat="server">
        <div class="logo">
            <img src="images//logo.png"/>
            <asp:Label ID="GUCera" Text="GUCera" runat="server"></asp:Label>
            
             
        </div>
        <div id="baseDiv" runat="server">
         <asp:Label ID="loginlbl" Text="Login" runat="server"></asp:Label>
         <div id="msg" runat="server"></div>    
           
            <asp:Label class="lbl" Text="ID" runat="server"></asp:Label>
            <asp:TextBox ID="username" Class="txt" maxlength="10" runat="server"></asp:TextBox>
            
            <asp:Label class="lbl" Text="Password" runat="server"></asp:Label>
            <asp:TextBox ID="password" Class="txt" maxlength="10" TextMode="Password" runat="server"></asp:TextBox>
            
            
            
            <asp:Button ID="signIn" runat="server" OnClick="login" Text="Login" />
            <asp:Button ID="register" runat="server" Text="I don't have an Account" OnClick="register_Click" />
        </div>

    </form>
    <div class="borderPanel" style="bottom:-10px;"></div>
</body>
</html>
