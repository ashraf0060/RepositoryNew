<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VOCAPlus.aspx.vb" Inherits="VOCAPlus.VOCAPlus" %>


<html lang="en">
<head>
    <title>VOCA+ - Home</title>
    	  <style type="text/css">
 .Live-Chat
{
     color :#ff0000;
     font-size:30px;
     font-family:'Calibri';
     padding:10px 20px;
     display:inline-block;
     margin:10px;
     text-decoration:none;
     	   }
	   .Blink-me{
		   animation-name: blinker;
           text-align:right;
           direction:rtl;
		   animation-duration:2s;
		   animation-timing-function:linear;
		   animation-iteration-count:infinite;
	   }
	   @keyframes blinker
	   {
		   0%{opacity: 1.0}
		   50%{opacity: 0.0}
		   100%{opacity: 1.0}
	   }
	  </style>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

<%--    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">--%>

    <link rel="stylesheet" href="css/animate.css">

    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/owl.theme.default.min.css">
    <link rel="stylesheet" href="css/magnific-popup.css">

    <link rel="stylesheet" href="css/flaticon.css">
    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <form id="form1" runat="server">

						
    </form>

    <div class="wrap">
        <div class="container">
            <div class="row justify-content-between">
                <div class="col">
                    <p class="mb-0 phone"><span class="fa fa-phone"></span> <a href="">+2 010-288-33-428 </a></p>
                </div>
                <div class="col d-flex justify-content-end">
                    <div class="social-media">
                        <p class="mb-0 d-flex">
                            <a href="" class="d-flex align-items-center justify-content-center"><span class="fa fa-facebook"><i class="sr-only">Facebook</i></span></a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <nav class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-dark ftco-navbar-light" id="ftco-navbar">
        <div class="container">
            <a class="navbar-brand" href="">VOCA<span>+</span></a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#ftco-nav" aria-controls="ftco-nav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="fa fa-bars"></span> Menu
            </button>
            <div class="collapse navbar-collapse" id="ftco-nav">
                <ul class="navbar-nav m-auto">
                    <li class="nav-item active"><a href="VOCAPlus.aspx" class="nav-link">Home</a></li>
                    <li class="nav-item"><a href="about.html" class="nav-link">About</a></li>
                    <li class="nav-item"><a href="CustomSearch.aspx" class="nav-link">Custom Search</a></li>
                    <li class="nav-item"><a href="History.html" class="nav-link">History</a></li>
                    <li class="nav-item"><a href="Stories.html" class="nav-link">Stories</a></li>
                    <li class="nav-item"><a href="ContactUS.aspx" class="nav-link">Contact US</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- END nav -->

            <div style="direction:ltr;color:red;align-content:center;width:80%;margin-left:25%;margin-right:10%">
            <h1> <a href="CustomSearch.aspx" class="Live-Chat" ><span class="Blink-me">كل عام وحضراتكم بخير</a></h1> 
   
        </div>
    <div class="hero-wrap">
        <div class="home-slider owl-carousel">
            <div class="slider-item" style="background-image:url(images/1.jpg);">
                <div class="overlay"></div>
                <div class="container">
                    <div class="row no-gutters slider-text align-items-center justify-content-center">
                        <div class="col-md-10 ftco-animate">
                        </div>
                    </div>
                </div>
            </div>

            <div class="slider-item" style="background-image:url(images/2.jpg);">
                <div class="overlay"></div>
                <div class="container">
                    <div class="row no-gutters slider-text align-items-center justify-content-center">
                        <div class="col-md-10 ftco-animate">
                        </div>
                    </div>
                </div>
            </div>

            <div class="slider-item" style="background-image:url(images/3.jpg);">
                <div class="overlay"></div>
                <div class="container">
                    <div class="row no-gutters slider-text align-items-center justify-content-center">
                        <div class="col-md-10 ftco-animate">
                        </div>
                    </div>
                </div>
            </div>

                        <div class="slider-item" style="background-image:url(images/VocaA.jpg);">
                <div class="overlay"></div>
                <div class="container">
                    <div class="row no-gutters slider-text align-items-center justify-content-center">
                        <div class="col-md-10 ftco-animate">
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <br />

    <section class="intro py-5 bg-light">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <div class="intro-box w-100 d-flex">
                        <div class="icon d-flex align-items-center justify-content-center">
                            <span class="fa fa-phone"></span>
                        </div>
                        <div class="text pl-3">
                            <h4 class="mb-0">Call us: +2 010-288-33-428</h4>
                            <span> Egypt - Cairo</span>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="intro-box w-100 d-flex">
                        <div class="icon d-flex align-items-center justify-content-center">
                            <span class="fa fa-clock-o"></span>
                        </div>
                        <div class="text pl-3">
                            <h4 class="mb-0">Opening Hours</h4>
                            <span>Sunday - Thursday 08:00 AM - 05:00 PM </span>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>
    </section>

    <footer class="footer">
        <div class="container-fluid px-lg-5">
            <div class="row">
                <div class="col-md-9 py-5">
                    <div class="row">
                        <div class="col-md-4 mb-md-0 mb-4">
                            <h2 class="footer-heading">About us</h2>
                            <p>We will Not Lose a Single Customer Because We Didn’t Care.</p>
                            <ul class="ftco-footer-social p-0">

                                <li class="ftco-animate"><a href="" data-toggle="tooltip" data-placement="top" title="Facebook"><span class="fa fa-facebook"></span></a></li>

                            </ul>
                        </div>
                                                <div style="margin-left:35%">
                            <div class="bio mr-5">
                                <img src="images/voca256.ico" alt="Image placeholder" class="img-fluid mb-4">
                            </div>
                        </div>
                    </div>
                    <div class="row mt-md-5">
                        <div class="col-md-12">
                            <p class="copyright">
                                <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                                Copyright &copy;
                                <script>document.write(new Date().getFullYear());</script> Ashraf Farag
                                <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>



    <!-- loader -->
    <div id="ftco-loader" class="show fullscreen"><svg class="circular" width="48px" height="48px"><circle class="path-bg" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke="#eeeeee" /><circle class="path" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke-miterlimit="10" stroke="#F96D00" /></svg></div>


    <script src="js/jquery.min.js"></script>
    <script src="js/jquery-migrate-3.0.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.easing.1.3.js"></script>
    <script src="js/jquery.waypoints.min.js"></script>
    <script src="js/jquery.stellar.min.js"></script>
    <script src="js/jquery.animateNumber.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/jquery.magnific-popup.min.js"></script>
    <script src="js/scrollax.min.js"></script>
    <script src=""></script>
    <%--<script src="js/google-map.js"></script>--%>
    <script src="js/main.js"></script>



</body>
</html>
