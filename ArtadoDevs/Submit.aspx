<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Submit.aspx.cs" Inherits="ArtadoDevs.Submit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="/css/mdb.min.css" type="text/css" />
<link rel="stylesheet" href="/css/style.css" type="text/css" />
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link rel="preconnect" href="https://fonts.googleapis.com"/>
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
<link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100&family=Quicksand:wght@300&family=Zen+Kaku+Gothic+Antique:wght@300&display=swap" rel="stylesheet"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<link rel="shortcut icon" href="/images/favicon.ico"/>
<title>Artado Developers</title>
<style>
.fontlu{
font-family: 'Quicksand', sans-serif;
}
::-webkit-scrollbar{
border-radius: 100px;
}
::-webkit-scrollbar-thumb{
border: 1px solid #ffffff;
}
.bosluk_button{
margin-right: 3px;
}
</style>
</head>
<body style="background-color: #1C1C1C">
<form id="form1" runat="server">
<div class="container">
<div class="mb-3"></div>
        
<nav class="navbar navbar-expand-lg" style="border: 1px solid #3c3c3c; background-color: #262626; border-radius: 6px;">
<div class="container">
<a class="navbar-brand me-2" href="/">
<img src="/images/logo.png" width="40" loading="lazy" style="margin-top: -1px;"  />
</a>
          
<button class="navbar-toggler" type="button" data-mdb-toggle="collapse" data-mdb-target="#navbarButtonsExample" aria-controls="navbarButtonsExample" aria-expanded="false" aria-label="Toggle navigation">
<i class="bi bi-chevron-bar-contract"></i>
</button>
          
<div class="collapse navbar-collapse" id="navbarButtonsExample">
<ul class="navbar-nav me-auto mb-2 mb-lg-0">
<li class="nav-item">
    <a class="nav-link fontlu" href="#"><b>Store</b></a>
    </li>
    <li class="nav-item">
    <a class="nav-link fontlu" href="#"><b>Workshop</b></a>
    </li>
<li class="nav-item">
    <a class="nav-link fontlu" href="/#FAQ"><b><asp:Literal runat="server" Text="<%$Resources:Langs, FAQ%>" /></b></a>
</li>
</ul>
          
<div class="d-flex align-items-center">
<div class="form-outline text-light">
<i class="bi-search trailing"></i>
<input type="text" id="form" class="form-control form-icon-trailing"/>
<label class="form-label text-light" for="form1"><asp:Literal runat="server" Text="<%$Resources:Langs, Search%>" /></label>
</div>
</div>
</div>
</div>
</nav>
        
<div id="register" runat="server" class="row justify-content-center">
<h4 class="fontlu text-light text-center" style="margin-top: 50px"><b><asp:Literal runat="server" Text="<%$Resources:Langs, RegisterTitle%>" /></b></h4>
<p class="text-center text-light"><asp:Literal runat="server" Text="<%$Resources:Langs, RegisterText%>" /></p>
<div class="form-outline col-md-6 form-white mb-3 mx-1">
<input id="Mail" runat="server" type="email" class="form-control form-control-lg" />
<label class="form-label" for="formControlLg"><asp:Literal runat="server" Text="<%$Resources:Langs, EMail%>" /></label>
</div>
<div class="form-outline col-md-6 form-white mb-3 mx-1">
<input id="pass" runat="server" type="password" class="form-control form-control-lg" />
<label class="form-label" for="formControlLg"><asp:Literal runat="server" Text="<%$Resources:Langs, Password%>" /></label>
</div>
<div class="form-outline col-md-6 form-white mb-3 mx-1">
<input id="Username" runat="server" type="text" class="form-control form-control-lg" />
<label class="form-label" for="formControlLg"><asp:Literal runat="server" Text="<%$Resources:Langs, AuthorName%>" /></label>
</div>
<div class="form-outline col-md-6 form-white mb-3 mx-1">
<input id="Bio" runat="server" type="text" class="form-control form-control-lg" />
<label class="form-label" for="formControlLg"><asp:Literal runat="server" Text="<%$Resources:Langs, Description%>" /></label>
</div>
<div class="form-outline col-md-6 form-white mb-3 mx-1">
<input id="Site" runat="server" type="text" class="form-control form-control-lg" />
<label class="form-label" for="formControlLg"><asp:Literal runat="server" Text="<%$Resources:Langs, Website%>" /></label>
</div>
</div>

<div id="login" runat="server" class="row justify-content-center">
<h4 class="fontlu text-light text-center" style="margin-top: 50px"><b><asp:Literal runat="server" Text="<%$Resources:Langs, LoginTitle%>" /></b></h4>
<p class="text-center text-light"><asp:Literal runat="server" Text="<%$Resources:Langs, LoginText%>" /></p>
<div class="form-outline col-md-6 form-white mb-3 mx-1">
<input id="email" runat="server" type="text" class="form-control form-control-lg" />
<label class="form-label" for="formControlLg"><asp:Literal runat="server" Text="<%$Resources:Langs, EMail%>" /></label>
</div>
<div class="form-outline col-md-6 form-white mb-3 mx-1">
<input id="password_l" runat="server" type="password" class="form-control form-control-lg" />
<label class="form-label" for="formControlLg"><asp:Literal runat="server" Text="<%$Resources:Langs, Password%>" /></label>
</div>
</div>

<div id="Mail_Onay" runat="server" class="row justify-content-center">
<h4 class="fontlu text-light text-center" style="margin-top: 50px"><b><asp:Literal runat="server" Text="<%$Resources:Langs, EnterVerifyCode%>" /></b></h4>
<p class="text-center text-light"><asp:Literal runat="server" Text="<%$Resources:Langs, VerifyText%>" /></p>
<div class="form-outline col-md-6 form-white mb-3 mx-1">
<input id="code" runat="server" type="text" class="form-control form-control-lg" />
<label class="form-label" for="formControlLg"><asp:Literal runat="server" Text="<%$Resources:Langs, VerificationCode%>" /></label>
</div>
</div>

<asp:Label ID="Uyarı" runat="server" Text="Label"></asp:Label>

<div id="a_button" runat="server" class="d-flex justify-content-center align-items-center h-100">
<asp:Button ID="Button1" runat="server" class="btn btn-light btn-lg mb-3" href="#!" role="button" style="color: #9147ff !important;" Text="<%$Resources:Langs, Accept%>" OnClick="Accept" />
<br/>
</div>
<div id="a_button2" runat="server" class="d-flex justify-content-center align-items-center h-100">
<asp:Button ID="Button3" runat="server" class="btn btn-light btn-lg mb-3" href="#!" role="button" style="color: #9147ff !important;" Text="<%$Resources:Langs, Accept%>" OnClick="Login_Accept" />
<br/>
</div>
<div id="re_button" runat="server" class="d-flex justify-content-center align-items-center h-100">
<asp:Button ID="Button2" runat="server" class="btn btn-light btn-lg mb-3" href="#!" role="button" style="color: #9147ff !important;" Text="<%$Resources:Langs, SendAgain%>" OnClick="Resend" />
<br/>
</div>
<div id="tos" runat="server" style="font-size: small; text-decoration: none; color: white"><asp:Literal runat="server" Text="<%$Resources:Langs, TOSText%>" /></div>
<div id="r_button" runat="server" class="d-flex justify-content-center align-items-center h-100">
<asp:Button ID="RegisterB" runat="server" class="btn btn-light btn-lg mb-3" href="#!" role="button" style="color: #9147ff !important;" Text="<%$Resources:Langs, Register%>" OnClick="Register" />
<br/>
</div>
<div id="l_button" runat="server" class="d-flex justify-content-center align-items-center h-100">
<asp:Button ID="LoginB" runat="server" class="btn btn-light btn-lg mb-3" href="#!" role="button" style="color: #9147ff !important;" Text="<%$Resources:Langs, Login%>" OnClick="Login" />
<br/>
</div>

    

<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.22.1/moment.min.js"></script>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
<script src="js/main.js"></script>
<script src="js/mdb.min.js"></script>
</form>
</body>
</html>
