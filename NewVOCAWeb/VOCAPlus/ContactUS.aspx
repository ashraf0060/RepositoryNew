<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ContactUS.aspx.vb" Inherits="VOCAPlus.ContactUS" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <title>VOCA+ - Contact tUs</title>
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
                    <li class="nav-item"><a href="VOCAPlus.aspx" class="nav-link">Home</a></li>
                    <li class="nav-item"><a href="about.html" class="nav-link">About</a></li>
                    <li class="nav-item"><a href="CustomSearch.aspx" class="nav-link">Custom Search</a></li>
                    <li class="nav-item"><a href="History.html" class="nav-link">History</a></li>
                    <li class="nav-item"><a href="Stories.html" class="nav-link">Stories</a></li>
                    <li class="nav-item active"><a href="ContactUS.aspx" class="nav-link">Contact US</a></li>
                  </ul>
              </div>
          </div>
      </nav>
    <!-- END nav -->
            <section style="width:94%;margin:3%;" >
    	<div >
    		<div class="row justify-content-center">
					<div class="col-md-12">
						<div class="wrapper">
							<div class="row no-gutters">
								<div class="col-lg-8 col-md-7 order-md-last d-flex align-items-stretch">
									<div class="contact-wrap w-100 p-md-5 p-4">
										<h3 class="mb-4">Get in touch</h3>
										<div id="form-message-warning" class="mb-4"></div> 
        <form id="form1" runat="server">
             <div style="width:85%;margin-left:5%;margin-right:5%">
                <table cellpadding="2" class="style1">
                        <tr>
                            <td style="width: 40%; text-align: right;">
                                    <asp:Label runat="server" Text="From :" ForeColor="Black"></asp:Label>
                            </td>
                            <td>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="172px" Font-Size="Medium"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="@egyptpost.org" ForeColor="#000099" Font-Size="Medium"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40%; text-align: right;">   
                                    <asp:Label runat="server" Text="Subject :" ForeColor="Black"></asp:Label>
                            </td>
                            <td>              
                                    <asp:TextBox ID="TextBox3" runat="server" Width="343px"></asp:TextBox>
                            </td>
                        </tr>
                                         <tr>
                            <td style="width: 40%; text-align: right;">   
                                    <asp:Label runat="server" Text="Message :" ForeColor="Black"></asp:Label>
                            </td>
                            <td>              
                                    <asp:TextBox ID="TextBox4" runat="server" Height="198px" TextMode="MultiLine" Width="543px"></asp:TextBox>
                            </td>
                        </tr>
                           </table>
                    <br />
                 <div style="margin-left:80%;margin-right:10%;width:10%">
                     <br />
                     <asp:Button ID="Button1" runat="server" Text="Send" /> 
                 </div>
                 <div style="margin-left:60%;margin-right:10%;width:30%">
                     <br />      <asp:Label ID="Label1" runat="server"></asp:Label>

                 </div>

             </div> 
    </form>
									</div>
								</div>
								<div class="col-lg-4 col-md-5 d-flex align-items-stretch">
									<div class="info-wrap bg-primary w-100 p-md-5 p-4">
										<h3>Let's get in touch</h3>
										<p class="mb-4">We're open for any suggestion or just to have a chat</p>
					        	<div class="dbox w-100 d-flex align-items-start">
					        		<div class="icon d-flex align-items-center justify-content-center">
					        			<span class="fa fa-map-marker"></span>
					        		</div>
					        		<div class="text pl-3">
						            <p>Address: Sabeel Bulding, First Floor, Shubra, Cairo, Egypt</p>
						          </div>
					          </div>
					        	<div class="dbox w-100 d-flex align-items-center">
					        		<div class="icon d-flex align-items-center justify-content-center">
					        			<span class="fa fa-phone"></span>
					        		</div>
					        		<div class="text pl-3">
						            <p><span>Phone:</span> <a href="">+2 010-288-33-428</a></p>
						          </div>
					          </div>
					        	<div class="dbox w-100 d-flex align-items-center">
					        		<div class="icon d-flex align-items-center justify-content-center">
					        			<span class="fa fa-paper-plane"></span>
					        		</div>
					        		<div class="text pl-3">
                                    <p><span>Email:</span> <a href="">voca-support@egyptpost.org</a></p>
						          </div>
					          </div>
					        	<div class="dbox w-100 d-flex align-items-center">
					        		<div class="icon d-flex align-items-center justify-content-center">
					        			<span class="fa fa-globe"></span>
					        		</div>
					        		<div class="text pl-3">
						            <p><span>Website:</span> <a href="//10.10.26.4:8000/VOCAPlus.aspx">//10.10.26.4:8000/VOCAPlus.aspx</a></p>
						          </div>
					          </div>
				          </div>
								</div>
							</div>
						</div>
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
  <div id="ftco-loader" class="show fullscreen"><svg class="circular" width="48px" height="48px"><circle class="path-bg" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke="#eeeeee"/><circle class="path" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke-miterlimit="10" stroke="#F96D00"/></svg></div>


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
