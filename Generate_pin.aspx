<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="Generate_pin.aspx.cs" Inherits="Generate_pin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        ul {
            color: black;
        }

        #pre_loader {
            position: relative;
            z-index: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card shadow">
                <div class="card-header bg-gradient-card">
                    <h2>Generate PIN</h2>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lbl_accno" runat="server" Text="Account No :"></asp:Label><br />
                            <asp:TextBox ID="txt_accno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="lbl_acctype" runat="server" Text="Account Type :"></asp:Label><br />
                            <asp:TextBox ID="txt_acctype" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <span style="color: red; margin-left: 30px; font-size: 18px; font-weight: bold">Note:</span>
                    <ul>
                        <li>PIN can be generated for active accounts only</li>
                        <li>If the account is temporarily blocked, then you will need to unblock the account to initiate regeneration of PIN</li>
                        <li>PIN cannot be regenerated for accounts that are permanently blocked</li>
                        <li>Your pin gets locked if you enter the wrong account details 3 times in a row Please use the option Request for Physical PIN</li>
                    </ul>
                    <br />
                    <div class="row">
                        <%--<img src="img/dropinring.gif" id="pre_loader1" />--%>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lbl_newpin" runat="server" Text="Enter New PIN :"></asp:Label><br />
                            <asp:TextBox ID="txt_newpin" runat="server" MaxLength="4" TextMode="Password" onkeypress="return isNumber(event)" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lbl_confpin" runat="server" Text="Re-Enter New PIN :"></asp:Label><br />
                            <asp:TextBox ID="txt_confpin" runat="server" MaxLength="4" TextMode="Password" onkeypress="return isNumber(event)" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Button ID="btn_genpin" runat="server" CssClass="btn btn-facebook btn-block" Text="Generate PIN" OnClick="btn_genpin_Click" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Button ID="btn_updatepin" runat="server" CssClass="btn btn-facebook btn-block" Text="Resend PIN" OnClick="btn_updatepin_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        $(document).ready(function () {
            //$("#pre_loader").hide();
        });

        $("#btn_genpin").on('click', function () {
            //$("#pre_loader").show();
        })
    </script>
</asp:Content>

