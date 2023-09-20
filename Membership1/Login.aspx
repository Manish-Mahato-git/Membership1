<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Membership1.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Login ID="loginUser" runat="server" CreateUserText="Register"
                CreateUserUrl="~/Register.aspx"
                OnAuthenticate="SignIn" BackColor="#F7F7DE"
                BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="10pt" Height="135px" Width="286px">
                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
            </asp:Login>

            <%--<asp:Login ID="Login1" runat="server" CreateUserText="Register"></asp:Login>--%>
        </div>
    </form>
</body>
</html>