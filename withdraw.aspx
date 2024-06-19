<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="withdraw.aspx.cs" Inherits="withdraw" %>

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
            <div class="row" style="padding-top: 5%;">
                <div class="col-md-3 col-sm-3"></div>
                <div class="col-md-6 col-sm-6">
                    <div class="card shadow">
                        <div class="card-header bg-gradient-card">
                            <h2 style="text-align: center">Withdraw Amount</h2>
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
                                    <asp:Label ID="lbl_amt" runat="server" Text="Withdraw Amount :"></asp:Label><br />
                                    <asp:TextBox ID="txt_amt" runat="server" onkeypress="return isNumber(event)" MaxLength="5" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <span style="color: red">Note :  </span><span>Min. ₹1 - Max. ₹10,000 at a time</span>
                            <br />
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
                                    <asp:Button ID="btn_withdraw" runat="server" CssClass="btn btn-facebook btn-block" Text="Withdraw Now" OnClick="btn_withdraw_Click" />
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

