<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcessGymMembership.aspx.cs" Inherits="WebApplication1.ProcessGymMembership" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        You have submitted the following information:</p>
    <form id="form1" runat="server">
    <p>
        FirstName:
        <asp:Label ID="lblFirstName" runat="server"></asp:Label><br />
        LastName:
        <asp:Label ID="lblLastName" runat="server"></asp:Label><br />
        GymMembershipID:
        <asp:Label ID="lblGymMembershipID" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnProceed" runat="server" onclick="btnProceed_Click" 
            Text="Proceed with Renewal" />
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <br />
    </p>
    <div>
    
    </div>
    </form>
</body>
</html>
