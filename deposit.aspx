<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="deposit.aspx.cs" Inherits="deposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <style>
        .bg-img {
            height: 96% !important;
        }

        .mb-4 {
            margin-bottom: 0rem !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form" runat="server" class="bg-img">
        <div class="container-fluid">
            <div class="row" style="padding-top: 5%;">
                <div class="col-md-3 col-sm-3"></div>
                <div class="col-md-6 col-sm-6">
                    <div class="card shadow">
                        <div class="card-header bg-gradient-card">
                            <h2 style="text-align: center">Add Funds</h2>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_accno" runat="server" Text="Account No :"></asp:Label><br />
                                    <asp:TextBox ID="txt_accno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_bal" runat="server" Text="Balance Amount :"></asp:Label><br />
                                    <asp:TextBox ID="txt_bal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_amt" runat="server" Text="Add Amount :"></asp:Label><br />
                                    <asp:TextBox ID="txt_amt" runat="server" MaxLength="5" onkeypress="return isNumber(event)" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_selectbank" runat="server" Text="Select Bank :"></asp:Label><br />
                                    <asp:DropDownList ID="ddl_bank" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Bank Of America" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_paywith" runat="server" Text="Pay with"></asp:Label><br />
                                </div>
                            </div>
                            <hr class="sidebar-divider my-0">
                            <div class="row">
                                <div class="col-sm">
                                    <asp:HyperLink ID="HyperLink1" href="#" runat="server"><span class="fas fa-google-pay">Google pay</span></asp:HyperLink>
                                </div>
                            </div>
                            <hr class="sidebar-divider my-0">
                            <div class="row">
                                <div class="col-sm">
                                    <asp:HyperLink ID="HyperLink2" href="" runat="server"><span class="fas fa-google-pay">UPI</span></asp:HyperLink>
                                </div>
                            </div>
                            <hr class="sidebar-divider my-0">
                            <div class="row">
                                <div class="col-sm">
                                    <asp:HyperLink ID="HyperLink3" href="" runat="server"><span class="fas fa-google-pay">Net Banking</span></asp:HyperLink>
                                </div>
                            </div>
                            <hr class="sidebar-divider my-0">
                            <div class="row">
                                <div class="col-sm">
                                    <asp:HyperLink ID="HyperLink4" href="" runat="server"><span class="fas fa-google-pay">Others</span></asp:HyperLink>
                                </div>
                            </div>
                            <hr class="sidebar-divider my-0">
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Button ID="btn_confirm" runat="server" CssClass="btn btn-facebook btn-block" Text="Confirm" OnClick="btn_confirm_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-md-3 col-sm-3"></div>
            </div>
        </div>
    </form>
</asp:Content>

