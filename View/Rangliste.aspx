<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rangliste.aspx.cs" Inherits="TurnierverwaltungWeb.View.Rangliste" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Content/bootstrap.min.css"/>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
      rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        li.dropdown:hover .dropdown-menu {display: block}
        .material-icons.md-18 {font-size: 18px}
        .material-icons.red600 {color: #f00a0a}
    </style>
</head>
<body>
<nav class="navbar navbar-default">
    <div>
        <ul class="nav navbar-nav">
            <li><a class="navbar-brand" href="./Startseite"> Startseite</a></li>
            <li><a href="#">Anmelden</a></li>
            <li class="dropdown">
                 <a href="#" class="dropdown" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Verwaltung<span class="caret"></span></a>
                 <ul class="dropdown-menu">
                     <li><a href="./Personenverwaltung1">Personenverwaltung</a></li>
                     <li><a href="./Mannschaftsverwaltung">Mannschaftsverwaltung</a></li>
                     <li><a href="./Turnierverwaltung">Turnierverwaltung</a></li>
                     <li><a href="#">Rangliste</a></li>
                 </ul>
            </li>
        </ul>
    </div>
</nav>
<form id="form1" runat="server">
<div>
    <div class="checkbox">
            <p>Bitte wählen Sie eine Sportart aus, um die dazugehörige Rangliste sehen zu können</p>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True"  >
                <asp:ListItem >Fussball</asp:ListItem>
                <asp:ListItem >Basketball</asp:ListItem>
                <asp:ListItem >Volleyball</asp:ListItem>
            </asp:RadioButtonList>
    </div>
    <div>
        <asp:Button ID="bSportart" runat="server" text="submit" OnClick="bSportart_okClick"/>
    </div>
</div>
</form>
    <div>
        <asp:Table ID="Turnier" runat="server" CssClass="table">
        <asp:TableHeaderRow CssClass="active">
            <asp:TableCell>Mannschaft A</asp:TableCell>
            <asp:TableCell>Mannschaft B</asp:TableCell>
            <asp:TableCell>Ergebnis A</asp:TableCell>
            <asp:TableCell>Ergebnis B</asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
    </div>
<hr class="solid" />
<footer><p>Designed with <span style="vertical-align:bottom" class="material-icons md-18 red600">favorite</span> by Natalie</p>
</footer>  
</body>
</html>