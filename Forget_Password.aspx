<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forget_Password.aspx.cs" Inherits="Forget_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>E_Banking - Forgot Password</title>

    <style>
        #loader {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-top: 40px;
        }

        .bg-img {
            background-image: url("img/bg_password.png");
        }

        .bg-color {
            background-color: #97aff5;
        }

        .bg-loader {
            height: 100vh;
            width: 100vw;
            display: flex;
            justify-content: center;
            align-items: center;
            z-index: 9999999;
            background-color: white;
            position: fixed;
        }
    </style>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
    <%-- Jquery --%>
    <script src="vendor/jquery/jquery.min.js"></script>
    <!-- Notify -->
    <link href="notify-master/css/notify.css" rel="stylesheet" />
    <script src="notify-master/js/notify.js"></script>

</head>
<body class="bg-color">
    <form id="form1" runat="server">
        <div class="bg-loader">
            <img src="img/bg_loop.gif" id="pre_loader" />
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                                            <h1 class="h4 text-gray-900 mb-2">Forgot Your Password?</h1>
                                            <p class="mb-4">
                                                We get it, stuff happens. Just enter your email address below
                                            and we'll send you a link to reset your password!
                                            </p>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txt_Email" runat="server" class="form-control form-control-user" placeholder="Enter Email Address..." AutoCompleteType="Disabled" MaxLength="50" TextMode="Email"></asp:TextBox>
                                        </div>
                                        <asp:Button ID="btn_reset" runat="server" Text="Reset Password" class="btn btn-primary btn-user btn-block" OnClick="btn_reset_Click" />
                                        <hr />
                                        <div class="text-center">
                                            <a class="small" href="Registration.aspx">Create an Account!</a>
                                        </div>
                                        <div class="text-center">
                                            <a class="small" href="login.aspx">Already have an account? Login!</a>
                                        </div>

                                        <div id="loader" runat="server">
                                            <img id="load" src="img/dropinring.gif" />
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
</body>
</html>
