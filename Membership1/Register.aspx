<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Membership1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:CreateUserWizard ID="RegisterUser" runat="server"
            OnCreatedUser="RegisterUser_CreatedUser" BackColor="#E3EAEB"
            BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px"
            Font-Names="Verdana" Font-Size="0.8em">
            <ContinueButtonStyle BackColor="White" BorderColor="#C5BBAF"
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                ForeColor="#1C5E55" />
            <CreateUserButtonStyle BackColor="White" BorderColor="#C5BBAF"
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                ForeColor="#1C5E55" />
            <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
            <HeaderStyle BackColor="#666666" BorderColor="#E6E2D8" BorderStyle="Solid"
                BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White"
                HorizontalAlign="Center" />
            <NavigationButtonStyle BackColor="White" BorderColor="#C5BBAF"
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                ForeColor="#1C5E55" />
            <SideBarButtonStyle ForeColor="White" />
            <SideBarStyle BackColor="#1C5E55" Font-Size="0.9em" VerticalAlign="Top" />
            <StepStyle BorderWidth="0px" />
        </asp:CreateUserWizard>
        <div>
        </div>
    </form>
</body>
</html>
