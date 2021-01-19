<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllNonAcceptedCourses.aspx.cs" Inherits="GUCera.AllNonAcceptedCourses" %>

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
            flex-direction:column;
            margin:0 auto;
            padding:25px;
            padding-top:50px;
            width:60%;
            min-height:100vh;
            background-color:#ffffff;
        }
        #upperDiv{
            display:flex;
            flex-direction:row;
            height:30%;
            padding:25px;
            margin:2% 0;
            margin-bottom:5px;
            padding-top:50px;
            background-color:#ffffff;
            width:85%;
        }
        #upperDiv input{
            font-size:27px;
            color:#074f44;
            font-weight:bold;
            display:flex;
            flex-direction:column;
            width:40%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 1);
            text-align:center;
        }
         #leftPanel{
            padding-top:30px;
            width:15%;
            margin-right:5px;
            height:auto;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.3);
            background-color:#878f99;
        }
        #home{
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
            font-size:25px;
        }
        .CourseContainer{
            display:flex;
            flex-direction:row;
            height:auto;
        }
        .CourseContainer input{
            font-size:20px;
            color:#707070;
            display:flex;
            flex-direction:column;
            margin:2% auto;
            width:40%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0);
            text-align:center;
            font-weight:bold;
        }
        input.Acc{
            color:#009933;
            font-size:23px;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0);
            font-weight:bold;
            text-align:center;
            width:15%;
            background-color:#333333;
        }
        .Acc:hover{
            color:#333333;
            background-color:#009933;
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
            <asp:Button ID="home" Text="Home" runat="server" OnClick="Home_Click" />
                </div>
            <div id="baseDiv" runat="server">
                <div id="msg" runat="server">
                                    </div>
                    <div id="upperDiv" runat="server">
                    </div>
            </div>
    </form>
</body>
</html>

