<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotAccessiblePage.aspx.cs" Inherits="GUCera.NotAccessiblePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="/favicon.ico"/>
    <title>Unauthorized</title>
     <style>
        html, body {
           
            height: 100%;
            width:100%;
            background-color:#878f99;
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
         
         .logo {
             margin: 10px;
             margin-left: 7%;
             margin-top: 20px;
             width: 50px;
             height: 50px;
         }
           #GUCera{
           margin:10px; 
           margin-left:1%;
           color:#eeeeee;
           font-size:50px;
           font-family:cursive
       }
        #form1{
            display:flex;
            flex-direction:row;
            margin-top:50px;
        }
        #baseDiv{
            display:flex;
            flex-direction:column;
            padding:30px 30px;
            padding-top:100px;
            margin:15% 0,5%,20%;
            width:80%;
            color:#993333;
            font-size:70px;
            
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
       
        
    </style>
</head>

<body>
     <div class="borderPanel" style="top:-10px;">
         <img src="images//logo.png" class="logo" />
         <asp:Label ID="GUCera" Text="GUCera" runat="server"></asp:Label>
     </div>
    <form id="form1" runat="server">
        <div id="baseDiv">
            You can not access this page!!
        </div>
    </form>
    <div class="borderPanel" style="bottom:-10px;"></div>
</body>
</html>
