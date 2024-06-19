<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="PIN_Authentication.aspx.cs" Inherits="PIN_Authentication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form" runat="server">
        <div class="container-fluid">
            <div class="row" style="margin-top: 8%;">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="card shadow">
                        <div class="card-header bg-gradient-card">
                            <h2 style="text-align: center">E-Banking</h2>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md">
                                    <asp:Label ID="lbl_accno" runat="server" Text="Account No :"></asp:Label><br />
                                    <asp:TextBox ID="txt_accno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <span style="color: black;">ENTER 4-DIGIT ACCOUNT PIN</span>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md">
                                    <asp:Label ID="lbl_newpin" runat="server" Text="Enter Account PIN :"></asp:Label><br />
                                    <asp:TextBox ID="txt_newpin" runat="server" MaxLength="4" TextMode="Password" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <span style="color: red">Account Pin will keep your account secure from
                                unauthorized access. Do not share this PIN with anyone.</span>
                            <br />
                            <br />
                            <div style="text-align: center;">
                                <a class="small" href="generate_pin.aspx">Forgot PIN?</a>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md">
                                    <asp:Button ID="chk_pin" runat="server" CssClass="btn btn-facebook btn-block" Text="Confirm" OnClick="chk_pin_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

