<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="TurnierverwaltungWeb.View.Turnierverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Content/bootstrap.min.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<nav class="navbar navbar-default">
    <div>
        <ul class="nav navbar-nav">
            <li>
                <a class="navbar-brand" href="#"> Turnierverwaltung</a>
            </li>
            <li>
                <a href="#">Anmelden</a>
            </li>
        </ul>
    </div>
</nav>
    <form class="form-horizontal" runat="server">
        <div class="form-group">
            <asp:Label ID="lbName" runat="server" Text="Name" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbName" runat="server" placeholder="Enter your lastname here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbVorname" runat="server" Text="Vorname" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbVorname" runat="server" placeholder="Enter your first name here..."></asp:TextBox>
        </div>
        <div class="form-group col-sm-offset-2 col-sm-10">
            <asp:Button ID="BPerson" runat="server" Text="Submit" OnClick="btnOk_Click" CssClass="btn btn-default btn-lg" />
        </div>
    </form>
    <asp:Table ID="Person" runat="server" CssClass="table">
        <asp:TableHeaderRow CssClass="active">
            <asp:TableCell>ID</asp:TableCell>
            <asp:TableCell>Rolle</asp:TableCell>
            <asp:TableCell>Name</asp:TableCell>
            <asp:TableCell>Vorname</asp:TableCell>
            <asp:TableCell>Position</asp:TableCell>
            <asp:TableCell>TrikotNummer</asp:TableCell>
            <asp:TableCell>Geburtstag</asp:TableCell>
            <asp:TableCell>Größe</asp:TableCell>

        </asp:TableHeaderRow>
    </asp:Table>
</body>
</html>