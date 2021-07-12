<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="TurnierverwaltungWeb.View.Turnierverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Content/bootstrap.min.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        li.dropdown:hover .dropdown-menu {display: block}
    </style>
</head>
<body>
<nav class="navbar navbar-default">
    <div>
        <ul class="nav navbar-nav">
            <li><a class="navbar-brand" href="#"> Turnierverwaltung</a></li>
            <li><a href="#">Anmelden</a></li>
            <li class="dropdown">
                 <a href="#" class="dropdown" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Verwaltung<span class="caret"></span></a>
                 <ul class="dropdown-menu">
                     <li><a href="#">Personenverwaltung</a></li>
                     <li><a href="#">Mannschaftsverwaltung</a></li>
                     <li><a href="#">Turnierverwaltung</a></li>
                 </ul>
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
        <div class="form-group">
            <asp:Label ID="lbRolle" runat="server" Text="Rolle" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbRolle" runat="server"  AutoPostBack="True" OnTextChanged="RoleInputChanged" placeholder="Enter your role here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbGeburtstag" runat="server" Text="Geburtstag" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbGeburtstag" runat="server"  placeholder="Enter your birthday (DD-MM-YYYYY) here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbGroesse" runat="server" Text="Groesse" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbGroesse" runat="server" placeholder="Enter your height in cm here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbTrikotnummer" runat="server" visible="false" Text="Trikotnummer" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbTrikotnummer" runat="server"  visible="false" AutoPostBack="True" OnTextChanged="RoleInputChanged" placeholder="Enter your shirt number here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbPostion" runat="server" visible="false" Text="Position" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbPosition" runat="server"  visible="false" AutoPostBack="True" OnTextChanged="RoleInputChanged" placeholder="Enter your position in a match here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbSprunghoehe" runat="server" visible="false" Text="Sprunghoehe" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbSprunghoehe" runat="server"  visible="false" AutoPostBack="True" OnTextChanged="RoleInputChanged" placeholder="Enter your spike in cm here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbAnzahlKoerbe" runat="server" visible="false" Text="Anzahl Koerbe" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbAnzeahlKoerbe" runat="server"  visible="false" AutoPostBack="True" OnTextChanged="RoleInputChanged" placeholder="Enter your number of slam-dunks here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbFuss" runat="server" visible="false" Text="Fuss" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbFuss" runat="server"  visible="false" AutoPostBack="True" OnTextChanged="RoleInputChanged" placeholder="Enter your strong foot here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbSportart" runat="server" visible="false" Text="Sportart" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbSportart" runat="server"  visible="false" AutoPostBack="True" OnTextChanged="RoleInputChanged" placeholder="Enter your sport here..."></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbJahreErfahrung" runat="server" visible="false" Text="Jahre Erfahrung" CssClass="col-sm-2 control-label"></asp:Label>
            <asp:TextBox ID="tbJahreErfahrung" runat="server"  visible="false" AutoPostBack="True" OnTextChanged="RoleInputChanged" placeholder="Enter your year of expierence here..."></asp:TextBox>
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
            <asp:TableCell>Geburtstag</asp:TableCell>
            <asp:TableCell>Größe</asp:TableCell>

        </asp:TableHeaderRow>
    </asp:Table>
</body>
</html>