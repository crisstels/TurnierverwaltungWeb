<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="TurnierverwaltungWeb.View.Turnierverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Turnier hinzufuegen</title>
<link rel="stylesheet" href="../Content/bootstrap.min.css"/>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
      rel="stylesheet" />
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
            <li class="dropdown">
                 <a href="#" class="dropdown" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Verwaltung<span class="caret"></span></a>
                 <ul class="dropdown-menu">
                     <li><a href="./Personenverwaltung1">Personenverwaltung</a></li>
                     <li><a href="./Mannschaftsverwaltung">Mannschaftsverwaltung</a></li>
                     <li><a href="./Turnierverwaltung">Turnierverwaltung</a></li>
                 </ul>
            </li>
            <li><a href="./Turnierergebnis">Turnierergebnisse</a></li>
            <li><a href="./Rangliste">Rangliste</a></li>
        </ul>
    </div>
</nav>
    <form id="form1" runat="server">
        <div>
            <h3>Turnierverwaltung</h3>
        </div>
              <div>
                  <p style="justify-content:left">Wähle die Mannschaften aus:</p>
                    <div class="form-group">
                    <select multiple style="width:45%" class="form-control" runat="server" id="selMannschaftA" name="MannschaftA">
                    </select>
                    <select multiple style="width:45%" class="form-control" runat="server" id="selMannschaftB" name="MannschaftB"> 
                    </select>
                </div>
                <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label  ID="lbSportart" runat="server" Text="Sportart"  class="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox  ID="tbSportart" runat="server" placeholder="Enter here your kind of sport..."></asp:TextBox>
                    </div>
                    <asp:Label ID="lbErgebnisA" runat="server" Text="Ergebnis Mannschaft A" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbErgebnisA" runat="server" placeholder="Enter result of team A here..."></asp:TextBox>
                    </div>
                    <asp:Label ID="lbErgebnisB" runat="server" Text="Ergebnis Mannschaft B" CssClass="col-md-3 control-label label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbErgebnisB" runat="server" placeholder="Enter result of team B here..."></asp:TextBox>
                    </div>
                </div>
                </div>
           </div>
        <asp:Button runat="server" ID="Button1" align="center" Text="Add Team" onClick="addTeam_Click" CssClass="btn btn-primary btn-lg"/>
    </form>
<hr class="solid" />
<footer><p>Designed with <span style="vertical-align:bottom" class="material-icons md-18 red600">favorite</span> by Natalie</p>
</footer> 
</body>
</html>



