<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Personenverwaltung.aspx.cs" Inherits="TurnierverwaltungWeb.View.Personenverwaltung" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Personenverwaltung</title>
    <link rel="stylesheet" href="../Content/bootstrap.min.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                    <li><a href="./Personenverwaltung.aspx">Personenverwaltung</a></li>
                    <li><a href="#">Mannschaftsverwaltung</a></li>
                    <li><a href="#">Turnierverwaltung</a></li>
                </ul>
            </li>
        </ul>
    </div>
</nav>
<form id="HtmlForm" runat="server">
    <div>
        <h3 align="center">Personenverwaltung</h3>
        <div >
            <p>Mit welcher Rolle möchten Sie sich anmelden?</p>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem >Fussball</asp:ListItem>
                <asp:ListItem >Basketball</asp:ListItem>
                <asp:ListItem >Volleyball</asp:ListItem>
                <asp:ListItem >Trainer</asp:ListItem>
            </asp:RadioButtonList>
            <br/>
            <asp:Button runat="server" id="BRolle" Text="Submit" onClick="BRolle_OnClick"/>
        </div>
    </div>
</form>
</body>
</html>