<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PromoCodeCreation.aspx.cs" Inherits="GUCera.PromoCodeCreation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            padding:50px 20px;
            font-size:20px;
            color:#707070;
            display:flex;
            flex-direction:column;
            margin:auto;
            border-radius:10px;
            min-height:200px;
            width:30%;
            box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.15);
        }
        .inpContainer span{
            color:#074f44;
            font-size:30px;
            margin:8% 0% 3% 0%;
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
        #baseDiv img{
             display:block;
             float:right;
             width:500px;
             height:60%;
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
        #PromoCreate{
            height:60px;
            font-size:30px;
            font-family: Circular, Helvetica, Arial, sans-serif;
            background-color:#074f44;
            border:none;
            border-bottom:thin groove #ffffff;
            border-top:thin groove #ffffff;
            border-color:#074f44;
            border-radius:10px;
            color:white;
        }
        #PromoCreate:hover{
            background-color:white;
            color:#074f44;
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
                <asp:Button ID="home" runat="server" Text="Home" OnClick="home_Click"/>
           </div>
         <div id="baseDiv" runat="server">
          <div id="msg" runat="server"></div>
           <img src="images//promocode.png"/>
            <div id="upperDiv" runat="server">
                <div class="inpContainer">
        <div>
                    <asp:Label ID="ppcode" Class="label" Text="CODE *" runat="server"></asp:Label> </div>
                    <asp:TextBox ID="Code" placeholder="Ex : G0988" maxlength="6" runat="server"></asp:TextBox>
                <asp:Label ID="Issue" Class="label" Text="IssueDate *" runat="server"></asp:Label>
              <asp:Calendar ID="IssueDate" style="margin-left:17.5%" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" CellPadding="1" DayNameFormat="Shortest">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                  <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003300" Font-Bold="True" Font-Size="10pt" ForeColor="White" BorderColor="#3366CC" BorderWidth="1px" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                  <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
                <asp:Label ID="Expiry" Class="label" Text="ExpiryDate *" runat="server"></asp:Label>
        <asp:Calendar ID="ExpiryDate" style="margin-left:17.5%" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003300" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="White" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
           <asp:Label ID="Disc" Class ="label" Text="Discount *" runat="server"></asp:Label>
        <asp:TextBox ID="Discount" placeholder="EX : 40.00" MaxLength="5" runat="server"></asp:TextBox>
        <sub>in the form of xx.xx</sub>
         <asp:Label ID="id" Class="label" Text="AdminID *" runat="server"></asp:Label>
        <asp:TextBox ID="AdminId" placeholder="Your id" runat="server"></asp:TextBox>
        <asp:Button ID="PromoCreate" runat="server" Text="Create" OnClick="PromoCreate_Click" />
                    </div>
                </div>
             </div>
    </form>
</body>
</html>
