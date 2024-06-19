<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>E-Banking - Register</title>

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
            background-image: url("img/bg_register.jpg");
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
</head>
<body class="bg-color">
    <form id="form1" runat="server">
        <div class="bg-loader">
            <img src="img/bg_loop.gif" id="pre_loader" />
        </div>
        <div class="container">
            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-5 d-none d-lg-block bg-img"></div>
                        <div class="col-lg-7">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Create an Account!</h1>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txt_firstName" runat="server" class="form-control form-control-user" onkeypress="return alphanum(event);" AutoCompleteType="Disabled" MaxLength="50" placeholder="First Name"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txt_LastName" runat="server" class="form-control form-control-user" AutoCompleteType="Disabled" MaxLength="50" onkeypress="return alphanum(event);" placeholder="Last Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txt_Email" runat="server" class="form-control form-control-user" placeholder="Email Address" onchange="validateEmail(this);" AutoCompleteType="Disabled" MaxLength="50" TextMode="Email"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txt_mobile" runat="server" class="form-control form-control-user" placeholder="Mobile No" onkeypress="return isNumber(event)" AutoCompleteType="Disabled" MaxLength="10" TextMode="Phone"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txt_Password" runat="server" class="form-control form-control-user" placeholder="Password" AutoCompleteType="Disabled" MaxLength="45" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txt_ConfirmPassword" runat="server" class="form-control form-control-user" placeholder="Repeat Password" MaxLength="45" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <asp:Button ID="btn_register" runat="server" Text="Register Account" OnClick="btn_register_Click" class="btn btn-primary btn-user btn-block" />
                                <hr />
                                <a href="#" class="btn btn-google btn-user btn-block">
                                    <i class="fab fa-google fa-fw"></i>Register with Google
                                </a>
                                <a href="#" class="btn btn-facebook btn-user btn-block">
                                    <i class="fab fa-facebook-f fa-fw"></i>Register with Facebook
                                </a>
                                <hr />
                                <div class="text-center">
                                    <a class="small" href="Forget_Password.aspx">Forgot Password?</a>
                                </div>
                                <div class="text-center">
                                    <a class="small" href="login.aspx">Already have an account? Login!</a>
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

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>

    <script>
        function alphanum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z]+$/);
            return pattern.test(value);
        }

        function isNumber(evt) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[0-9]+$/);
            return pattern.test(value);
        }

        function validateEmail(emailField) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (reg.test(emailField.value) == false) {
                emailField.value = "";
                $.notify("Please Enter a Valid Email ID.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                return false;
            }

            return true;
        }
    </script>


</body>
</html>
