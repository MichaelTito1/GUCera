<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorCoursePage.aspx.cs" Inherits="GUCera.InstructorCoursePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Course Page
    </title>
    <link rel="shortcut icon" href="/favicon.ico"/>
    <style type="text/css">
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
        .subCreditContainer{
            color:#ffffff;  
            padding:3px;
            padding-left:20px;
            margin:auto;
            font-size:25px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            line-height:40px;
            width:40%;
            display:flex;
            flex-direction:column;
            background-color:#92a9ac;
            border-right:1px dashed;
            border-left:1px dashed;
            text-align:center;
        }
        .button{
            display:compact;
            background-color:rgb(29, 166, 77);
            /*margin:auto;*/
            min-height:65px;
            /*margin-top:10px;*/
            border-radius:50px;
            /*margin-bottom:50px;*/
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
            <asp:Button ID="home" runat="server" CssClass="panelButton" Text="Home" OnClick="home_Click" />
            <asp:Button ID="backButton" runat="server" CssClass="panelButton" OnClick="backClick" Text="back" />
        </div>
        <div id="baseDiv" runat="server">
             <div id="msg" runat="server"></div>
             <div class="subCreditContainer">
                <asp:Label ID="courseData" runat="server" CssClass="auto-style1" style="z-index: 1" Text=""></asp:Label>
             </div>
            <asp:Button ID="feed" runat="server" CssClass="button" OnClick="viewFeedback" Text="View Feedback" />
            <asp:Button ID="vAssign" runat="server" CssClass="button" OnClick="viewAssignments" Text="View Assignments" />
            <asp:Button ID="dAssign" runat="server" CssClass="button" OnClick="defineAssignments" Text="Define Assignments" />
            <asp:Button ID="cert" runat="server" CssClass="button" OnClick="issueCertificate" Text="Issue a Certificate" />
        </div>
        
    </form>
</body>
</html>
