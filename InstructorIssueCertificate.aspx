<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorIssueCertificate.aspx.cs" Inherits="GUCera.InstructorIssueCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issue Course Certificate</title>
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
        .inpContainer{
            padding:50px 20px;
            font-size:50px;
            color:#707070;
            display:flex;
            flex-direction:column;
            margin:auto;
            border-radius:10px;
            min-height:200px;
            
            width:90%;
            height:99%;
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
        </div>
        <div id="baseDiv" runat="server">
             <div id="msg" runat="server"></div>
            <div class="subCreditContainer">
                 <asp:Label ID="courseData" runat="server" Text=""></asp:Label>
            </div>
             <div id="upperDiv" runat="server">
                <div class="inpContainer">
                    To issue a certificate to a student, please enter the student ID below:<br />
                    <br />
                        Student ID
                    <div class="inpContainer" 
                    style="border-radius:0px;background-color:#FFFFFF ;
                            width:80%;margin-right:7%;margin-left:10%;
                            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.15);">
                        <asp:TextBox ID="student" runat="server"></asp:TextBox>
                        <asp:Button ID="submit" runat="server" OnClick="issue" Text="submit" />
                    </div>
                </div>
             </div>
            
        </div>
    </form>
</body>
</html>
