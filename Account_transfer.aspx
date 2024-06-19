<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="Account_transfer.aspx.cs" Inherits="transaction_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            <div class="row" style="padding-top: 3%;">
                <div class="col-md-3 col-sm-3"></div>
                <div class="col-md-6 col-sm-6">
                    <div class="card shadow">
                        <div class="card-header bg-gradient-card">
                            <h2 style="text-align: center">Bank Transfer</h2>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_accno" runat="server" Text="Your Account No :"></asp:Label><br />
                                    <asp:TextBox ID="txt_accno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <span style="color: black;">Enter Recipient Details :</span>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_recipent_acc" runat="server" Text="Receipent Account No :"></asp:Label><br />
                                    <asp:TextBox ID="txt_recipent_acc" runat="server" CssClass="form-control" onkeypress="return isNumber(event)" MaxLength="14" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_conf_recipent_acc" runat="server" Text="Confirm Account No :"></asp:Label><br />
                                    <asp:TextBox ID="txt_conf_recipent_acc" runat="server" onkeypress="return isNumber(event)" CssClass="form-control" MaxLength="14" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_recipent_name" runat="server" Text="Receipent Name"></asp:Label><br />
                                    <asp:TextBox ID="txt_recipent_name" runat="server" onkeypress="return alphanum(event);" CssClass="form-control" MaxLength="15" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbl_amt" runat="server" Text="Amount :"></asp:Label><br />
                                    <asp:TextBox ID="txt_amt" runat="server" MaxLength="5" onkeypress="return isNumber(event)" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <span style="color: red">Note :  </span><span>This information will be securely saved as per E-Banking Terms of Services and Privacy Policy.</span>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Button ID="btn_transfer" runat="server" CssClass="btn btn-facebook btn-block" Text="Confirm" OnClick="btn_transfer_Click" />
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

