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
<form id="form1" runat="server">
    <p class="bg-primary">Turnierverwaltung</p>
    <div class="col-lg-6">
        <label for="firstname">Name</label>
            <div class="input-group">
              <input type="text" id="firstname" class="form-control" placeholder="Please enter your firstname here...">
              <span class="input-group-btn" >
                <button class="btn btn-default" type="button">Go!</button>
              </span>
            </div><!-- /input-group -->
          </div><!-- /.col-lg-6 -->
</form>
</body>
</html>