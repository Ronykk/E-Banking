<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="UserDashboard.aspx.cs" Inherits="UserDashford" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="container-fluid">
            <h1 class="text-gray-800">Your Dashboard</h1>
            <div class="card shadow">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4 col-md-4">
                            <div class="card border-left-success shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col-sm-7">
                                            <asp:Label ID="lbl_credited" runat="server" Text="Recently Credited :" Style="font-size: 17px" CssClass="text-xs font-weight-bold text-primary text-uppercase"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lbl_cred" runat="server" Text="200$" Style="font-size: 16px; color: black;" CssClass="text-xs font-weight-bold text-uppercase"></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <i class="fas fa-calendar fa-2x text-gray-300"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4">
                            <div class="card border-left-danger shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col-sm-7">
                                            <asp:Label ID="lbl_debited" runat="server" Text="Recently Debited :" Style="font-size: 17px" CssClass="text-xs font-weight-bold text-primary text-uppercase"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lbl_debit" runat="server" Text="100$" Style="font-size: 16px; color: black;" CssClass="text-xs font-weight-bold text-uppercase"></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <i class="fas fa-calendar fa-2x text-gray-300"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4">
                            <div class="card border-left-primary shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col-sm-7">
                                            <asp:Label ID="lbl_tot_balance" runat="server" Text="Total Balance :" Style="font-size: 19px" CssClass="text-xs font-weight-bold text-primary text-uppercase"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lbl_balance" runat="server" Text="500$" Style="font-size: 16px; color: black" CssClass="text-xs font-weight-bold text-uppercase"></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <i class="fas fa-calendar fa-2x text-gray-300"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6">
                                    <h4 class="text-gray-800">Deposit :</h4>
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <asp:TextBox ID="txt_deposit" runat="server" class="form-control form-control-user" onkeypress="return isNumber(event)" placeholder="Enter Amount" AutoCompleteType="Disabled" MaxLength="5"></asp:TextBox>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <asp:Button ID="btn_dep" runat="server" CssClass="btn btn-facebook btn-block" Text="Deposit" OnClick="btn_dep_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <h4 class="text-gray-800">Withdraw :</h4>
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <asp:TextBox ID="txt_withdraw" runat="server" class="form-control form-control-user" onkeypress="return isNumber(event)" placeholder="Enter Amount" AutoCompleteType="Disabled" MaxLength="5"></asp:TextBox>
                                            </div>
                                            <br />
                                            <div class="row"></div>
                                            <asp:Button ID="btn_withd" runat="server" CssClass="btn btn-facebook btn-block" Text="Withdraw" OnClick="btn_withd_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <img src="img/yearly_spend.png" class="img-fluid img-thumbnail" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

