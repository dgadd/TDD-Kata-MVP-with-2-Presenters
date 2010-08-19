<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Gym Renewal<br />
        First Name
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
        Last Name
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
&nbsp;<br />
        Gym Membership ID
        <asp:TextBox ID="txtGymMembershipID" runat="server"></asp:TextBox>
&nbsp;<br />
        <br />
        <asp:Button ID="btnRenewGymMembership" runat="server" 
            onclick="btnRenewGymMembership_Click" Text="Renew Gym Membership" />
    
    </div>
    </form>
</body>
</html>
