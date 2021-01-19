<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFeedBack.aspx.cs" Inherits="GUCera.AddFeedBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        #upperDiv{
            padding:40px;
            display:flex;
            flex-direction:row;
            margin:auto;           
            width:45%;
            border-radius:10px;
            min-height:200px;
            border:1px solid #808080;
            background-color:#f0f0f0;
        }
        .inpContainer{
            padding:50px 20px;
            font-size:50px;
            color:#707070;
            display:flex;
            flex-direction:column;
            margin:auto;
            border-radius:10px;
            min-height:200px;
            
            width:30%;
            height:99%;
        }
        .inpContainer span{
            color:#404040;
            font-size:20px;
            margin:8% 0%;
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
        #Button1{
            display:block;
            background-color:rgb(29, 166, 77);
            margin:auto;
            min-height:65px;
            margin-top:10px;
            border-radius:50px;
            margin-bottom:50px;
            border:3.5px solid rgb(29, 166, 77);
            width:25%;
            color:#eeeeee;
            font-size:25px;
            font-family: Circular, Helvetica, Arial, sans-serif;    
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
             <div id="upperDiv" runat="server">
                <div class="inpContainer">
                    <asp:Label  ID="feedLabel" runat="server" Text="Write your feedback"></asp:Label>
                </div>
                <div class="inpContainer" 
                    style="border-radius:0px;background-color:#FFFFFF ;
                            width:80%;margin-right:7%;margin-left:10%;
                            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.15);">
                    <asp:TextBox ID="Comment" MaxLength="100" runat="server"></asp:TextBox>
                </div>
                
            </div>
            <asp:Button ID="Button1" runat="server" Text="submit your feedback" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
