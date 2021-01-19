<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentProfile.aspx.cs" Inherits="GUCera.studentProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Profile
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
        #dataContainer{
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
         #Edit{
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
          #Save{
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
            visibility:hidden;
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
            width:50%;
            min-height:100px;
        }
        .inpContainer span{
            color:#707070 !important;
            font-size:20px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            margin-bottom:10px;
            margin-top:20px;

        }
        .textbox{
            padding-bottom:3px;
            width:100%;
            display:block;
            margin: 3px auto;
            font-size:20px;
            border-radius:7px;
            height:45px;
            border:1px solid #aaaaaa;
        }
        .RadioButton{
            background-color:#eeeeee;
            color:#777777;
            padding-bottom:3px;
            width:100%;
            display:block;
            margin: 3px auto;
            font-size:20px;
            border-radius:7px;
            
            border:1px solid #aaaaaa;
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
            <div id="dataContainer" runat="server">
                
            </div>
            <asp:Button ID="Edit" runat="server" Text="EDIT" OnClick="editclick"  />
             <div id="inpContainer" class="inpContainer" runat="server" style="visibility:hidden">
                <asp:Label ID="Label1" Text="First Name *" runat="server"></asp:Label>
                <asp:TextBox ID="firstname" class="textbox" maxlength="10" runat="server"></asp:TextBox>
                <asp:Label ID="lname" Text="Last Name *" runat="server"></asp:Label>               
                <asp:TextBox ID="lastname" class="textbox" maxlength="10" runat="server"></asp:TextBox>
                <asp:Label ID="pass" Text="Password *" runat="server"></asp:Label>
                <asp:TextBox ID="password"  class="textbox" maxlength="10" TextMode="Password" runat="server"></asp:TextBox>

            
                <asp:Label ID="gender"  Text="Gender" runat="server"></asp:Label>
                <asp:RadioButtonList class="RadioButton" ID="genderList" runat="server" >
                    <asp:ListItem Selected="True">Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
           
                <asp:Label ID="emailLbl" Text="Email *" runat="server"></asp:Label>
                <asp:TextBox ID="email" class="textbox" maxlength="10" runat="server"></asp:TextBox>

           
                <asp:Label ID="addressLbl" Text="Address" runat="server"></asp:Label>
                <asp:TextBox ID="address" class="textbox" MaxLength="10" runat="server"></asp:TextBox>
                <asp:Button ID="Save" runat="server" onclick="update" Text="Save"  />
                

            </div>
        </div>
        
    </form>
</body>
</html>
