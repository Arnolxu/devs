<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArtadoDevs.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="css/mdb.min.css" type="text/css" />
<link rel="stylesheet" href="css/style.css" type="text/css" />
<link rel="shortcut icon" href="/images/favicon.ico"/>
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link rel="preconnect" href="https://fonts.googleapis.com"/>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100&family=Quicksand:wght@300&family=Zen+Kaku+Gothic+Antique:wght@300&display=swap" rel="stylesheet"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
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
                    <input type="text" id="form1" class="form-control form-icon-trailing"/>
                    <label class="form-label text-light" for="form1"><asp:Literal runat="server" Text="<%$Resources:Langs, Search%>" /></label>
                  </div>
                </div>
              </div>
            </div>
          </nav>

          <div class="p-5 text-center bg-image mb-4" style="background-image: url('/images/background.jpg'); height: 500px; margin-top: 58px; border-radius: 6px;">
            <div class="mask" style="background-color: rgba(0, 0, 0, 0.6);">
            <div class="d-flex justify-content-center align-items-center h-100">
                <div class="text-white">
                    <img src="/images/logo.png" width="60" class="img-fluid mb-4"/>
                    <h4 class="mb-5 fontlu" style="max-width: 550px;"><b><asp:Literal runat="server" Text="<%$Resources:Langs, WelcomeText%>" /></b></h4>
                    <a href="/Submit" class="btn btn-light btn-lg mb-3" role="button" style="color: #9147ff !important;"><asp:Literal runat="server" Text="<%$Resources:Langs, Login%>" /></a><br/>
                </div>
            </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-4">
                <div class="card mb-3" style="border: 1px solid #ffffff; background: transparent;">
                    <div class="card-body align-items-center justify-content-center text-center">
                        <img src="/images/gamepad.png" class="img-fluid" style="height: 100px;"/>
                        <br/>
                        <h4 class="fontlu text-light mb-1"><b><asp:Literal runat="server" Text="<%$Resources:Langs, IntroTitle1%>" /></b></h4>
                        <p class="fontlu text-gray"><b><asp:Literal runat="server" Text="<%$Resources:Langs, IntroText1%>" /></b></p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card mb-3" style="border: 1px solid #ffffff; background: transparent;">
                    <div class="card-body align-items-center justify-content-center text-center">
                        <img src="/images/web.png" class="img-fluid" style="height: 80px; margin-bottom: 10px; margin-top: 10px;"/>
                        <br/>
                        <h4 class="fontlu text-light mb-1"><b><asp:Literal runat="server" Text="<%$Resources:Langs, IntroTitle2%>" /></b></h4>
                        <p class="fontlu text-gray"><b><asp:Literal runat="server" Text="<%$Resources:Langs, IntroText2%>" /></b></p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card mb-3" style="border: 1px solid #ffffff; background: transparent;">
                    <div class="card-body align-items-center justify-content-center text-center">
                        <img src="/images/art.png" class="img-fluid" style="height: 100px;"/>
                        <br/>
                        <h4 class="fontlu text-light mb-1"><b><asp:Literal runat="server" Text="<%$Resources:Langs, IntroTitle3%>" /></b></h4>
                        <p class="fontlu text-gray"><b><asp:Literal runat="server" Text="<%$Resources:Langs, IntroText3%>" /></b></p>
                    </div>
                </div>
            </div>
        </div>
        <br/>
        <h4 class="text-light text-center fontlu" id="FAQ"><b><asp:Literal runat="server" Text="<%$Resources:Langs, FAQFull%>" /></b></h4>
        <br/>
        <div class="accordion mb-4" id="accordionFAQ" style="border: 1px solid white; border-radius: 6px;">
            <div class="accordion-item text-light fontlu" style="background: transparent;">
              <h2 class="accordion-header" id="faqHeading1">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  style="background-color: transparent;"
                  data-mdb-toggle="collapse"
                  data-mdb-target="#collapseOne"
                  aria-expanded="false"
                  aria-controls="collapseOne"
                >
                 <asp:Label ID="Label1" runat="server" Font-Bold="true" class="text-white" Text="<%$Resources:Langs, FAQTitle1%>"></asp:Label>
                </button>
              </h2>
              <div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne" data-mdb-parent="#accordionExample">
                <div class="accordion-body">
                    <asp:Label ID="Label2" runat="server" Text="<%$Resources:Langs, FAQText1%>"></asp:Label>
                </div>
              </div>
            </div>


            <div class="accordion-item text-light fontlu" style="background: transparent;">
              <h2 class="accordion-header" id="faqHeading2">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-mdb-toggle="collapse"
                  data-mdb-target="#collapseTwo"
                  style="background-color: transparent;"
                  aria-expanded="false"
                  aria-controls="collapseTwo"
                >
               <asp:Label ID="Label3" runat="server" Font-Bold="true" class="text-white" Text="<%$Resources:Langs, FAQTitle2%>"></asp:Label>
            </button>
              </h2>
              <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-mdb-parent="#accordionExample">
                <div class="accordion-body">
                  <asp:Label ID="Label4" runat="server" Text="<%$Resources:Langs, FAQText2%>"></asp:Label>
                </div>
              </div>
            </div>


            <div class="accordion-item text-light fontlu" style="background: transparent;">
              <h2 class="accordion-header" id="faqHeading3">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  style="background-color: transparent;"
                  data-mdb-toggle="collapse"
                  data-mdb-target="#collapseThree"
                  aria-expanded="false"
                  aria-controls="collapseThree"
                >
               <asp:Label ID="Label5" runat="server" Font-Bold="true" class="text-white" Text="<%$Resources:Langs, FAQTitle3%>"></asp:Label>
            </button>
              </h2>
              <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-mdb-parent="#accordionExample">
                <div class="accordion-body">
                  <asp:Label ID="Label6" runat="server" Text="<%$Resources:Langs, FAQText3%>"></asp:Label>
                </div>
              </div>
            </div>
          </div>

          <br/>
          <h4 class="fontlu text-center text-light"><b><asp:Literal runat="server" Text="<%$Resources:Langs, FAQFull%>" /></b></h4>
          <br/>
          <div class="accordion mb-4" id="accordionBetaFAQ" style="border: 1px solid white; border-radius: 6px;">
            <div class="accordion-item text-light fontlu" style="background: transparent;">
              <h2 class="accordion-header" id="betaHeading1">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  style="background-color: transparent;"
                  data-mdb-toggle="collapse"
                  data-mdb-target="#collapseFour"
                  aria-expanded="false"
                  aria-controls="collapsefour"
                >
                 <asp:Label ID="Label7" runat="server" Font-Bold="true" class="text-white" Text="<%$Resources:Langs, BetaFAQTitle1%>"></asp:Label>
                </button>
              </h2>
              <div id="collapseFour" class="accordion-collapse collapse" aria-labelledby="headingOne" data-mdb-parent="#accordionExample">
                <div class="accordion-body">
                  <asp:Label ID="Label8" runat="server" Text="<%$Resources:Langs, BetaFAQText1%>"></asp:Label>
                </div>
              </div>
            </div>
            <div class="accordion-item text-light fontlu" style="background: transparent;">
              <h2 class="accordion-header" id="betaHeading2">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-mdb-toggle="collapse"
                  data-mdb-target="#collapseSix"
                  style="background-color: transparent;"
                  aria-expanded="false"
                  aria-controls="collapseTwo"
                >
                <asp:Label ID="Label9" runat="server" Font-Bold="true" class="text-white" Text="<%$Resources:Langs, BetaFAQTitle2%>"></asp:Label>
            </button>
              </h2>
              <div id="collapseSix" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-mdb-parent="#accordionExample">
                <div class="accordion-body">
                  <asp:Label ID="Label10" runat="server" Text="<%$Resources:Langs, BetaFAQText2%>"></asp:Label>
                </div></div>
              </div>
            </div>
    </div>

    

<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.22.1/moment.min.js"></script>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
<script src="js/main.js"></script>
<script src="js/mdb.min.js"></script>
</body>
</html>
