<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Startseite.aspx.cs" Inherits="TurnierverwaltungWeb.View.Startseite" %>

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
            <li class="dropdown">
                 <a href="#" class="dropdown" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Verwaltung<span class="caret"></span></a>
                 <ul class="dropdown-menu">
                     <li><a href="./Personenverwaltung">Personenverwaltung</a></li>
                     <li><a href="./Mannschaftsverwaltung">Mannschaftsverwaltung</a></li>
                     <li><a href="./Turnierverwaltung">Turnierverwaltung</a></li>
                 </ul>
            </li>
            <li><a href="./Turnierergebnis">Turnierergebnisse</a></li>
            <li><a href="./Rangliste">Rangliste</a></li>
        </ul>
    </div>
</nav>
<div>
    <h2 align="center">Willkommen zur Turnierverwaltung!<span class="material-icons md-48">emoji_events</span></h2>
    
</div>
<hr class="solid" />
<footer><p>Designed with <span style="vertical-align:bottom" class="material-icons md-18 red600">favorite</span> by Natalie</p>
</footer>  
</body>
</html>