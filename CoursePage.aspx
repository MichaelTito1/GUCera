<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoursePage.aspx.cs" Inherits="GUCera.CoursePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course</title>
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
         .dataContainer{
            display:flex;
            flex-direction:row;
            border-radius:0px;
            background-color:#FFFFFF ;
            width:80%;
            height:300px;
            margin-right:7%;
            margin-left:10%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.15);
            
        }
        .subDataContainer{
            color:#606060;  
            padding:3px;
            padding-left:10px;
            margin:auto;
            font-size:25px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            line-height:40px;
            width:50%;
            display:flex;
            flex-direction:column;
            border-right:1px dashed;
            border-left:1px dashed;
        }
        #Enroll{
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
        #rbl{
             display:flex;
            flex-direction:column;
            border-radius:0px;
            background-color:#FFFFFF ;
            width:70%;
            padding:5px 7%;
            margin:20px 7% 20px 15%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.15);
        }
        #rbl td{
            font-size:20px;
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
            <div id="container" runat="server" class="dataContainer">
            </div>
            <div id="instDiv" runat="server">
                <asp:RadioButtonList ID="rbl" runat="server"></asp:RadioButtonList>
            </div>
            <asp:Button ID="Enroll" runat="server" Text="Enroll" OnClick="Enroll_Click" />
       
        </div> 
    </form>
</body>
</html>
