<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="TurnierverwaltungWeb.View.Mannschaftsverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mannschaftsverwaltung</title>
    <link rel="stylesheet" href="../Content/bootstrap.min.css"/>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
      rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <div class="form-horizontal">
            <div>
            <p>Wählen Sie bitte eine Sportart aus</p>
            <select id="selSport" runat="server" name="selSport">
                <option value="fussball">Fussball</option>
                <option value="basketball">Basketball</option>
                <option value="volleyball">Volleyball</option>
            </select>
        </div>
        <div class="form-horizontal col-md-8">
        <div class="form-group">
          <asp:Label ID="lbName" runat="server" Text="Mannschaftsname"  class="col-md-1 control-label"></asp:Label>
          <div class="col-md-2">
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
          </div>
        </div>
            </div>
        </div>        
            <div>
                <div class="form-group">
                    <p style="justify-content:left">Wähle die Mannschaftsmitglieder aus:</p>
                    <select multiple style="width:45%" class="form-control" runat="server" id="selMannschaft" name="Mannschaft">
                        <option visible="true" id="optleer" value="empty">noch keine Teilnehmer vorhanden</option>
                    </select>
                </div>
                <asp:Button runat="server" ID="addSpieler" Text="Add Spieler" onClick="addSpieler_Click" CssClass="btn btn-primary btn-lg"/>
           </div>
        <div>
            <p runat="server" style="margin:10px" ID="lbAddMannschaft" >Wenn Sie eine vollständige Mannschaft registrieren wollen, dann klicken Sie hier: </p>
            <div class="col-md-2">
                <asp:Button runat="server" ID="addMannschaft" Text="Add Mannschaft" onClick="addMannschaft_onClick" CssClass="btn btn-primary btn-lg"/>
            </div>
        </div>
    </form>
    <asp:Table ID="Mannschaft" runat="server" CssClass="table">
        <asp:TableHeaderRow CssClass="active">
            <asp:TableCell>Name</asp:TableCell>
            <asp:TableCell>Sportart</asp:TableCell>
            <asp:TableCell>Spieler</asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
<br />
<hr class="solid" />
<footer><p>Designed with <span style="vertical-align:bottom" class="material-icons md-18 red600">favorite</span> by Natalie</p>
</footer>
</body>
</html>
