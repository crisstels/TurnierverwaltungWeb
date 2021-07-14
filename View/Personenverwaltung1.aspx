﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personenverwaltung1.aspx.cs" Inherits="TurnierverwaltungWeb.View.Personenverwaltung1" %>

<!DOCTYPE html>

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
    <form id="form1" runat="server">
        <div>
        <h3 align="center">Personenverwaltung</h3>
        <div class="checkbox">
            <p>Mit welcher Rolle möchten Sie sich anmelden?</p>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True"  >
                <asp:ListItem >Fussball</asp:ListItem>
                <asp:ListItem >Basketball</asp:ListItem>
                <asp:ListItem >Volleyball</asp:ListItem>
                <asp:ListItem >Trainer</asp:ListItem>
            </asp:RadioButtonList>
            <br/>
            <asp:Button runat="server" id="BRolle" Text="Submit" onClick="button1_Click"/>
        </div>
    </div>
        <div class="form-horizontal">
            <h4 align="center">Please enter your information here....</h4>
            <div class="form-horizontal col-md-8">
                <div class="form-group">
                    <asp:Label ID="lbName" runat="server" Text="Name"  class="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbName" runat="server" placeholder="Enter your lastname here..."></asp:TextBox>
                    </div>
                    <asp:Label  ID="lbVorname" runat="server" Text="Vorname"  class="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox  ID="tbVorname" runat="server" placeholder="Enter your first name here..."></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbGeburtstag" runat="server" Text="Geburtstag"  class="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox  ID="tbGeburtstag" runat="server"  placeholder="Enter your birthday (DD-MM-YYYYY) here..."></asp:TextBox>
                    </div>
                    <asp:Label ID="lbGroesse" runat="server" Text="Groesse" class="col-md-3 control-label"  ></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbGroesse" runat="server" placeholder="Enter your height in cm here..."></asp:TextBox>
                    </div>
                </div>
                <div runat="server" id="testdiv" class="form-group">
                    <asp:Label ID="lbTrikotnummer" runat="server" Text="Trikotnummer" class="col-md-3 control-label" ></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbTrikotnummer" runat="server" AutoPostBack="True"  placeholder="Enter your shirt number here..."></asp:TextBox>
                    </div>
                    <asp:Label ID="lbPostion" runat="server" Text="Position" class="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbPosition" runat="server"  AutoPostBack="True" placeholder="Enter your position in a match here..."></asp:TextBox>
                    </div>
                </div>
                <div runat="server" id="volleyDiv" visible="false" class="form-group">
                    <asp:Label ID="lbSprunghoehe" runat="server" Text="Sprunghoehe" class="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbSprunghoehe" runat="server"  AutoPostBack="True"  placeholder="Enter your spike in cm here..."></asp:TextBox>
                    </div>
                </div>
                <div runat="server" id="basketDiv" visible="false" class="form-group">
                    <asp:Label ID="lbAnzahlKoerbe" runat="server" Text="Anzahl Koerbe" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbAnzeahlKoerbe" runat="server" AutoPostBack="True"  placeholder="Enter your number of slam-dunks here..."></asp:TextBox>
                    </div>
                </div>
                <div runat="server" id="fussDiv" visible="false" class="form-group">
                    <asp:Label ID="lbFuss" runat="server" Text="Fuss" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbFuss" runat="server"  AutoPostBack="True"  placeholder="Enter your strong foot here..."></asp:TextBox>
                    </div>
                </div>
                <div runat="server" id="trainerDiv" visible="false" class="form-group">
                    <asp:Label ID="lbSportart" runat="server" Text="Sportart" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbSportart" runat="server"  AutoPostBack="True" placeholder="Enter your sport here..."></asp:TextBox>
                    </div>
                    <asp:Label ID="lbJahreErfahrung" runat="server"  Text="Jahre Erfahrung" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="tbJahreErfahrung" runat="server"  AutoPostBack="True"  placeholder="Enter your year of expierence here..."></asp:TextBox>
                    </div>
                 </div>
        <div class="form-group">
            <div class="col-md-offset-4 col-md-8">
                <asp:Button ID="BPerson" runat="server" visible="false" Text="Submit" OnClick="btnOKPerson" CssClass="btn btn-primary btn-lg" />
            </div>
        </div>
       </div>
        </div>
    </form>
</body>
</html>
