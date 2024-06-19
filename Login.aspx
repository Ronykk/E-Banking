<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>E-Banking - Login</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
    <%-- Jquery --%>
    <script src="vendor/jquery/jquery.min.js"></script>
    <!-- Notify -->
    <link href="notify-master/css/notify.css" rel="stylesheet" />
    <script src="notify-master/js/notify.js"></script>

    <style>
        .bg-img {
            background-image: url("img/BGLoginPage.jpg");
        }

        .bg-color {
            background-color: #97aff5;
        }

        .bg-loader {
           height:100vh;
           width:100vw;
           display:flex;
           justify-content:center;
           align-items:center;
           z-index:9999999;
           background-color:white;
           position:fixed;
        }
    </style>
</head>
<body class="bg-color">
    <form id="form1" runat="server">
        <div class="bg-loader">
            <img src="img/bg_loop.gif" id="pre_loader"/>
        </div>
        <div class="container">

            <!-- Outer Row -->
            <div class="row justify-content-center">

                <div class="col-xl-10 col-lg-12 col-md-9">

                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <div class="col-lg-6 d-none d-lg-block bg-img"></div>
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txt_userid" runat="server" class="form-control form-control-user" placeholder="User Id" AutoCompleteType="Disabled" MaxLength="20"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txt_Password" runat="server" class="form-control form-control-user" placeholder="Password" AutoCompleteType="Disabled" TextMode="Password" MaxLength="30"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <div class="custom-control custom-checkbox small">
                                                <input type="checkbox" class="custom-control-input" id="customCheck" />
                                                <label class="custom-control-label" for="customCheck">
                                                    Remember
                                                    Me</label>
                                            </div>
                                        </div>
                                        <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" class="btn btn-primary btn-user btn-block" />
                                        <hr />
                                        <a href="#" class="btn btn-google btn-user btn-block">
                                            <i class="fab fa-google fa-fw"></i>&nbsp Login with Google
                                            
                                            <%--<asp:Button ID="btn_google" runat="server" Text="Login with Google" class="fab fa-google fa-fw btn btn-user btn-block" />--%>
                                        </a>
                                        <a href="#" class="btn btn-facebook btn-user btn-block">
                                            <i class="fab fa-facebook-f fa-fw"></i>Login with Facebook
                                        </a>
                                        <hr />
                                        <div class="text-center">
                                            <a class="small" href="Forget_Password.aspx">Forgot Password?</a>
                                        </div>
                                        <div class="text-center">
                                            <a class="small" href="Registration.aspx">Create an Account!</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        $("body").hover(function () {
            $('div').each(function () {
                if ($(this).css('z-index') == '999999') {
                    $(this).hide();
                }
            })
        });
    </script>

    <script>
        setTimeout(function () {
            $(".bg-loader").show();
            $('div').each(function () {
                if ($(this).css('z-index') == '999999') {
                    $(this).hide();
                }
            })
            $(".bg-loader").hide();

        }, 750)
    </script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>

</body>
</html>
