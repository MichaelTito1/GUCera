<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditCard.aspx.cs" Inherits="GUCera.CreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Credit Cards
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
        #date{
            display:flex;
            flex-direction:row;
        }
        #date input,#cvvTb{
            width:25%;
        }
        #add{
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
        .CreditContainer{
            margin-bottom:5px;
            display:flex;
            flex-direction:row;
            background-color:#82999c;
            border:2px solid black;
            border-radius:10px;
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

                    <asp:Label ID="number" runat="server" Text="Number of card:"></asp:Label>
                    <asp:Label  ID="name" runat="server" Text="Card Holder Name:"></asp:Label>
                    <asp:Label  ID="expdate" runat="server" Text="Expiry date: (yyyy/mm/dd)"></asp:Label>
                    <asp:Label  ID="cvv" runat="server" Text="CVV:"></asp:Label>
                    
                   
                </div>
                <div class="inpContainer" 
                    style="border-radius:0px;background-color:#FFFFFF ;
                            width:80%;margin-right:7%;margin-left:10%;
                            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.15);">
                    <asp:TextBox  ID="numberTb" MaxLength="15" placeholder="1111222233334444" runat="server"></asp:TextBox>
                    <asp:TextBox  ID="nameTb" MaxLength="16" placeholder="ex:Ahmed" runat="server"></asp:TextBox>
                    <div id="date">
                        <asp:TextBox  ID="yyyy" MaxLength="4" placeholder="2021" style="width:50%" runat="server"></asp:TextBox>/
                        <asp:TextBox  ID="mm" MaxLength="2" placeholder="1" runat="server"></asp:TextBox>/
                        <asp:TextBox  ID="dd" MaxLength="2" placeholder="1" runat="server"></asp:TextBox>
                    </div>
                    <asp:TextBox  ID="cvvTb" MaxLength="3" placeholder="000" runat="server"></asp:TextBox>
                </div>
                
            </div>
            <asp:Button ID="add" runat="server" Text="ADD CREDITCARD" OnClick="add_Click" />
            <p style="display:block; margin-left:40px;margin-bottom:10px;font-size:30px;color:#808080">
                Your registered Creditcards

            </p>
            <div id="lowerDiv" runat="server">
                
            </div>
        </div>
    </form>
</body>
</html>
