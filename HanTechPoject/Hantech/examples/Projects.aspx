<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Projects.aspx.vb" Inherits="Hantech.Projects" %>

   
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HANTECH SYSTEM</title>
    <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png"/>
  <link rel="icon" type="image/png" href="../assets/img/png logo.ico"/>
  <!--     Fonts and icons     -->
  <link href="https://fonts.googleapis.com/css?family=Poppins:200,300,400,600,700,800" rel="stylesheet" />
  <link href="https://use.fontawesome.com/releases/v5.0.6/css/all.css" rel="stylesheet"/>
  <!-- Nucleo Icons -->
  <link href="../assets/css/nucleo-icons.css" rel="stylesheet" />
  <!-- CSS Files -->
  <link href="../assets/css/black-dashboard.css?v=1.0.0" rel="stylesheet" />

  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="../assets/demo/demo.css" rel="stylesheet" />
</head>
<body>
    <form id="form2" runat="server">
        <div class="wrapper">
    <div class="sidebar">
      <!--
        Tip 1: You can change the color of the sidebar using: data-color="blue | green | orange | red"
    -->
      <div class="sidebar-wrapper">
        <div class="logo">
          <a href="javascript:void(0)" class="simple-text logo-mini">
            
          </a>
          <a href="javascript:void(0)" class="simple-text logo-normal">
            HANTECHNOLOGY
          </a>
        </div>
        <ul class="nav">
            <li>
            <a href="./Dashboard.aspx">
              <i class="tim-icons icon-chart-pie-36"></i>
              <p>Dashboard</p>
            </a>
                </li>
          <li>
            <a href="./ProjectOrder.aspx">
              <i class="tim-icons"><image src="../assets/img/ProjectOrder.png"></image></i>
              <p>ProjectOrder</p>
            </a>
                  
          </li>
              <li class="active ">
            <a href="./Projects.aspx">
              <i class=""><image src="../assets/img/Projects.png"></image></i>
              <p>Projects</p>
            </a>
          </li>
             
          <li>
            <a href="./Employee.aspx">
               <i class="tim-icons icon-single-02"></i>
              <p>Employee</p>
            </a>
          </li>
          <li>
            <a href="./ProjectLoan.aspx">
              <i class=""><image src="../assets/img/cash_in_hand_50px.png"></image></i>
              <p>Project Loans</p>
            </a>
          </li>
          <li>
            <a href="./AboutUs.aspx">
              <i class=""><image src="../assets/img/about_50px.png"></image></i>
              <p>About US</p>
            </a>
          </li>
          <li>
            <a href="./Our Team.aspx">
              <i class=""><image src="../assets/img/teamwork_filled_50px.png"></image></i>
              <p>Our Team</p>
            </a>
          </li>
          <li>
            <a href="./Login Page.aspx">
              <i class="tim-icons icon-spaceship"></i>
              <p>Log Out</p>
            </a>
          </li>
        </ul>
      </div>
    </div>
    <div class="main-panel">
      <!-- Navbar -->
      <nav class="navbar navbar-expand-lg navbar-absolute navbar-transparent">
        <div class="container-fluid">
          <div class="navbar-wrapper">
            <div class="navbar-toggle d-inline">
              <button type="button" class="navbar-toggler">
                <span class="navbar-toggler-bar bar1"></span>
                <span class="navbar-toggler-bar bar2"></span>
                <span class="navbar-toggler-bar bar3"></span>
              </button>
            </div>
            <a class="navbar-brand" href="javascript:void(0)">Dashboard</a>
          </div>
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navigation" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-bar navbar-kebab"></span>
            <span class="navbar-toggler-bar navbar-kebab"></span>
            <span class="navbar-toggler-bar navbar-kebab"></span>
          </button>
          <div class="collapse navbar-collapse" id="navigation">
            <ul class="navbar-nav ml-auto">
              <li class="search-bar input-group">
                  <%--=================================Search====================================--%>
                  <asp:TextBox ID="TxtSearch"  ForeColor="Black" runat="server" CssClass="form-control bg-white"  AutoPostBack="True" ></asp:TextBox>
                <button class="btn btn-link" id="search-button" data-toggle="modal" data-target="#searchModal"><i class="tim-icons icon-zoom-split" ></i>
                  <span class="d-lg-none d-md-block">Search</span>
                </button>
              </li>
              <li class="dropdown nav-item">
                <a href="javascript:void(0)" class="dropdown-toggle nav-link" data-toggle="dropdown">
                  <div class="notification d-none d-lg-block d-xl-block"></div>
                  <i class="tim-icons icon-sound-wave"></i>
                  <p class="d-lg-none">
                    Notifications
                  </p>
                </a>
                <ul class="dropdown-menu dropdown-menu-right dropdown-navbar">
                  <li class="nav-link"><a href="#" class="nav-item dropdown-item">ProjectOrder</a></li>
                  <li class="nav-link"><a href="javascript:void(0)" class="nav-item dropdown-item">ProjectsOrder</a></li>
                  <li class="nav-link"><a href="javascript:void(0)" class="nav-item dropdown-item">Categories</a></li>
                  <li class="nav-link"><a href="javascript:void(0)" class="nav-item dropdown-item">Tools</a></li>
                  <li class="nav-link"><a href="javascript:void(0)" class="nav-item dropdown-item">Project Loans</a></li>
                </ul>
              </li>
              <li class="dropdown nav-item">
                <a href="#" class="dropdown-toggle nav-link" data-toggle="dropdown">
                  <div class="photo">
                    <img src="../assets/img/anime3.png" alt="Profile Photo">
                  </div>
                  <b class="caret d-none d-lg-block d-xl-block"></b>
                  <p class="d-lg-none">
                    Log out
                  </p>
                </a>
                <ul class="dropdown-menu dropdown-navbar">
                  <li class="nav-link"><a href="javascript:void(0)" class="nav-item dropdown-item">Profile</a></li>
                  <li class="nav-link"><a href="javascript:void(0)" class="nav-item dropdown-item">Settings</a></li>
                  <li class="dropdown-divider"></li>
                  <li class="nav-link"><a href="javascript:void(0)" class="nav-item dropdown-item">Log out</a></li>
                </ul>
              </li>
              <li class="separator d-lg-none"></li>
            </ul>
          </div>
        </div>
      </nav>

      <!-- End Navbar -->
        <%--------------------------Projects---------------------------------------%>
      <div class="content">
        <div class="row">
          <div class="col-12">
            <div class="card card-chart">
              <div class="card-header ">
                <div class="row">
                  <div class="col-sm-6 text-left">
                    <h5 class="card-category">HanTech</h5>
                    <h2 class="card-title">Projects</h2>
                    </div>
                    <div class="row">
                       <div class="col-sm-6">
                                  Enter You PID
                            <asp:DropDownList ID="DblPID"  runat="server" CssClass="form-control mb-2 bg-white" ForeColor="Black">
                                <asp:ListItem>Select PID</asp:ListItem>
                                  </asp:DropDownList>
                          </div>
                            <div class="col-sm-6">  
                                 Enter You ProjectName 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Emty ProjectName..." ControlToValidate="TxtProjectName" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="TxtProjectName" Placeholder="Enter You ProjectName "  forecolor="Black" runat="server" CssClass="form-control mb-2 bg-white  " ></asp:TextBox>
                          </div>  
              
                            <div class="col-md-6">                
                            Select Your CategoryName
                                <asp:DropDownList ID="DbCategoryName"  runat="server" CssClass="form-control mb-2 bg-white" ForeColor="Black" AutoPostBack="True">
                              <asp:ListItem Value="Select Category"></asp:ListItem>
                              <asp:ListItem Value="Web-Development"></asp:ListItem>
                              <asp:ListItem Value="Software-Development"></asp:ListItem>
                              <asp:ListItem Value="Mobile Application"></asp:ListItem>
                              <asp:ListItem Value="Desktop Application"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                               <div class="col-md-6">                
                            Select Your CategoryType
                                   <asp:DropDownList ID="DbCategoryType"  runat="server" CssClass="form-control mb-2 bg-white" ForeColor="Black">
                              <asp:ListItem>Select CategoryType</asp:ListItem>
                         </asp:DropDownList>
                        </div>
                      <div class="col-sm-6">
                            Select Your Tools
                             <asp:DropDownList ID="DbToolName"  runat="server" CssClass="form-control mb-2 bg-white" ForeColor="Black">
                                 <asp:ListItem>Select Tools</asp:ListItem>
                                 <asp:ListItem>Visual Basic SQL</asp:ListItem>
                                 <asp:ListItem>Visual Code</asp:ListItem>
                                 <asp:ListItem>PHP MySQL</asp:ListItem>
                                 <asp:ListItem>Java MySQL</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                          <div class="col-sm-6">
                            Enter Your Amount
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Emty Amount..." ControlToValidate="TxtAmount" ForeColor="Red"></asp:RequiredFieldValidator>
                          <asp:TextBox ID="TxtAmount" Placeholder="Enter You Amount"  forecolor="Black" runat="server" CssClass="form-control mb-2 bg-white  " AutoPostBack="True" TabIndex="1" ></asp:TextBox>
                          </div>  
                         <div class="col-sm-6">
                            Enter Your Paid
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Emty Paid..." ControlToValidate="TxtPaid" ForeColor="Red"></asp:RequiredFieldValidator>
                          <asp:TextBox ID="TxtPaid" Placeholder="Enter You Paid"  forecolor="Black" runat="server" CssClass="form-control mb-2 bg-white " AutoPostBack="True" TabIndex="2" ></asp:TextBox>
                          </div> 
                         <div class="col-sm-6">
                            Enter Your Blance
                          <asp:TextBox ID="TxtBlance" Placeholder="Enter You Blance"  forecolor="Black" runat="server" CssClass="form-control mb-2 bg-white " AutoPostBack="True" TabIndex="3" ReadOnly="True" ></asp:TextBox>
                          </div>  
                           <div class="col-sm-6">
                            Enter Your StartDate
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Select StartDate..." ControlToValidate="TxtStartDate" ForeColor="Red"></asp:RequiredFieldValidator>
                          <asp:TextBox ID="TxtStartDate" Placeholder="Enter You StartDate"  forecolor="Black" runat="server" CssClass="form-control mb-2 bg-white " TextMode="Date" TabIndex="3" ></asp:TextBox>
                          </div> 
                        <div class="col-sm-6">
                            Enter Your EndDate
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Select EndDate..." ControlToValidate="TxtEndDate" ForeColor="Red"></asp:RequiredFieldValidator>
                          <asp:TextBox ID="TxtEndDate" Placeholder="Enter You EndDate"  forecolor="Black" runat="server" CssClass="form-control mb-2 bg-white  " TextMode="Date"  ></asp:TextBox>
                          </div> 
                        <div class="col-sm-12">
                            Enter Your Date
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select DateOF Day..." ControlToValidate="TxtDate" ForeColor="Red"></asp:RequiredFieldValidator>
                          <asp:TextBox ID="TxtDate" Placeholder="Enter You Date"  forecolor="Black" runat="server" CssClass="form-control mb-2 bg-white  " TextMode="Date"  ></asp:TextBox>
                           </div> 
                        <div class="col-md-3 mt-2">
                            <asp:Button ID="BtnAdd" CssClass="btn btn-primary form-control" runat="server" Text="Add" TabIndex="4" />
                        </div>
                         <div class="col-md-3 mt-2">
                            <asp:Button ID="BtnEdit" CssClass="btn btn-primary form-control" runat="server" Text="Edit" />
                        </div>
                         <div class="col-md-3 mt-2">
                            <asp:Button ID="BtnDelete" CssClass="btn btn-primary form-control" runat="server" Text="Delete" />
                        </div>
                     <div class="col-md-3 mt-2">
                            <asp:Button ID="BtnClear" CssClass="btn btn-primary form-control" runat="server" Text="Clear" />
                        </div>
                    </div>
                    </div>
                          </div>  
              </div>
            </div>
                   <asp:GridView ID="GridViewProjects" runat="server" CellPadding="4" ForeColor="#333333" Width="1220px" AutoGenerateSelectButton="True" ShowHeaderWhenEmpty="True">
                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                  <EditRowStyle BackColor="#999999" />
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                  <SortedAscendingCellStyle BackColor="#E9E7E2" />
                  <SortedAscendingHeaderStyle BackColor="#506C8C" />
                  <SortedDescendingCellStyle BackColor="#FFFDF8" />
                  <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
              </asp:GridView>
          </div>
        </div>
                    
               <%--    <%==================================Footer===========================================%>--%>
                      <footer class="footer">
        <div class="container-fluid">
          <ul class="nav">
            <li class="nav-item">
              <a href="javascript:void(0)" class="nav-link">
                HANTECHNOLOGY 
              </a>
            </li>
            <li class="nav-item">
              <a href="javascript:void(0)" class="nav-link">
                About Us
              </a>
            </li>
            <li class="nav-item">
              <a href="javascript:void(0)" class="nav-link">
                Blog
              </a>
            </li>
          </ul>
          <div class="copyright">
            ©
            <script>
                document.write(new Date().getFullYear())
            </script>2018 made with <i class="tim-icons icon-heart-2"></i> by
            <a href="javascript:void(0)" target="_blank">HANTECH</a> for a better web.
          </div>
        </div>
      </footer>
    </div>

  <div class="fixed-plugin">
    <div class="dropdown show-dropdown">
      <a href="#" data-toggle="dropdown">
        <i class="fa fa-cog fa-2x"> </i>
      </a>
      <ul class="dropdown-menu">
        <li class="header-title"> Sidebar Background</li>
        <li class="adjustments-line">
          <a href="javascript:void(0)" class="switch-trigger background-color">
            <div class="badge-colors text-center">
              <span class="badge filter badge-primary active" data-color="primary"></span>
              <span class="badge filter badge-info" data-color="blue"></span>
              <span class="badge filter badge-success" data-color="green"></span>
            </div>
            <div class="clearfix"></div>
          </a>
        </li>
        <li class="adjustments-line text-center color-change">
          <span class="color-label">LIGHT MODE</span>
          <span class="badge light-badge mr-2"></span>
          <span class="badge dark-badge ml-2"></span>
          <span class="color-label">DARK MODE</span>
        </li>
        <li class="button-container">
          <a href="https://www.creative-tim.com/product/black-dashboard" target="_blank" class="btn btn-primary btn-block btn-round">Download Now</a>
          <a href="https://demos.creative-tim.com/black-dashboard/docs/1.0/getting-started/introduction.html" target="_blank" class="btn btn-default btn-block btn-round">
            Documentation
          </a>
        </li>
        <li class="header-title">Thank you for 95 shares!</li>
        <li class="button-container text-center">
          <button id="twitter" class="btn btn-round btn-info"><i class="fab fa-twitter"></i> &middot; 45</button>
          <button id="facebook" class="btn btn-round btn-info"><i class="fab fa-facebook-f"></i> &middot; 50</button>
     
          <a class="github-button" href="https://github.com/creativetimofficial/black-dashboard" data-icon="octicon-star" data-size="large" data-show-count="true" aria-label="Star ntkme/github-buttons on GitHub">Star</a>
        </li>
      </ul>
    </div>
  </div>
  <!--   Core JS Files   -->
  <script src="../assets/js/core/jquery.min.js"></script>
  <script src="../assets/js/core/popper.min.js"></script>
  <script src="../assets/js/core/bootstrap.min.js"></script>
  <script src="../assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>
  <!--  Google Maps Plugin    -->
  <!-- Place this tag in your head or just before your close body tag. -->
  <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
  <!-- Chart JS -->
  <script src="../assets/js/plugins/chartjs.min.js"></script>
  <!--  Notifications Plugin    -->
  <script src="../assets/js/plugins/bootstrap-notify.js"></script>
  <!-- Control Center for Black Dashboard: parallax effects, scripts for the example pages etc -->
  <script src="../assets/js/black-dashboard.min.js?v=1.0.0"></script><!-- Black Dashboard DEMO methods, don't include it in your project! -->
  <script src="../assets/demo/demo.js"></script>
  <script>
      $(document).ready(function () {
          $().ready(function () {
              $sidebar = $('.sidebar');
              $navbar = $('.navbar');
              $main_panel = $('.main-panel');

              $full_page = $('.full-page');

              $sidebar_responsive = $('body > .navbar-collapse');
              sidebar_mini_active = true;
              white_color = false;

              window_width = $(window).width();

              fixed_plugin_open = $('.sidebar .sidebar-wrapper .nav li.active a p').html();



              $('.fixed-plugin a').click(function (event) {
                  if ($(this).hasClass('switch-trigger')) {
                      if (event.stopPropagation) {
                          event.stopPropagation();
                      } else if (window.event) {
                          window.event.cancelBubble = true;
                      }
                  }
              });

              $('.fixed-plugin .background-color span').click(function () {
                  $(this).siblings().removeClass('active');
                  $(this).addClass('active');

                  var new_color = $(this).data('color');

                  if ($sidebar.length != 0) {
                      $sidebar.attr('data', new_color);
                  }

                  if ($main_panel.length != 0) {
                      $main_panel.attr('data', new_color);
                  }

                  if ($full_page.length != 0) {
                      $full_page.attr('filter-color', new_color);
                  }

                  if ($sidebar_responsive.length != 0) {
                      $sidebar_responsive.attr('data', new_color);
                  }
              });

              $('.switch-sidebar-mini input').on("switchChange.bootstrapSwitch", function () {
                  var $btn = $(this);

                  if (sidebar_mini_active == true) {
                      $('body').removeClass('sidebar-mini');
                      sidebar_mini_active = false;
                      blackDashboard.showSidebarMessage('Sidebar mini deactivated...');
                  } else {
                      $('body').addClass('sidebar-mini');
                      sidebar_mini_active = true;
                      blackDashboard.showSidebarMessage('Sidebar mini activated...');
                  }

                  // we simulate the window Resize so the charts will get updated in realtime.
                  var simulateWindowResize = setInterval(function () {
                      window.dispatchEvent(new Event('resize'));
                  }, 180);

                  // we stop the simulation of Window Resize after the animations are completed
                  setTimeout(function () {
                      clearInterval(simulateWindowResize);
                  }, 1000);
              });

              $('.switch-change-color input').on("switchChange.bootstrapSwitch", function () {
                  var $btn = $(this);

                  if (white_color == true) {

                      $('body').addClass('change-background');
                      setTimeout(function () {
                          $('body').removeClass('change-background');
                          $('body').removeClass('white-content');
                      }, 900);
                      white_color = false;
                  } else {

                      $('body').addClass('change-background');
                      setTimeout(function () {
                          $('body').removeClass('change-background');
                          $('body').addClass('white-content');
                      }, 900);

                      white_color = true;
                  }


              });

              $('.light-badge').click(function () {
                  $('body').addClass('white-content');
              });

              $('.dark-badge').click(function () {
                  $('body').removeClass('white-content');
              });
          });
      });
  </script>
  <script src="https://cdn.trackjs.com/agent/v3/latest/t.js"></script>
  <script>
      window.TrackJS &&
        TrackJS.install({
            token: "ee6fab19c5a04ac1a32a645abde4613a",
            application: "black-dashboard-free"
        });
  </script>
    </form>
</body>
</html>


