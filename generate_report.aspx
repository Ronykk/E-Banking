<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="generate_report.aspx.cs" Inherits="generate_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Datatable/datatables.min.css" rel="stylesheet" />
    <script src="Datatable/datatables.min.js"></script>
    <style>
        #grd_data {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <form runat="server">
               <div class="container-fluid">
                    <div class="card shadow">
                        <div class="card-header bg-gradient-card">
                            <h2>Generate Report</h2>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-7">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Label ID="lbl_accno" runat="server" Text="Account No:"></asp:Label><br />
                                            <asp:TextBox ID="txt_accno" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="lbl_acctype" runat="server" Text="Account Type:"></asp:Label><br />
                                            <asp:TextBox ID="txt_acctype" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Label ID="lbl_from_date" runat="server" Text="Select Date From:"></asp:Label><br />
                                            <asp:TextBox ID="txt_from_date" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>

                                            <%--<input id="txt_from_date" type="text" placeholder="dd/mm/yyyy" class="form-control datetimepicker-input" readonly="readonly" />--%>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="lbl_to_date" runat="server" Text="Select Date To:"></asp:Label><br />
                                            <asp:TextBox ID="txt_to_date" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <span style="color: black;">Select Report Type :</span>
                                    <br />
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:RadioButton ID="rd_full_type" Text="&nbsp; Full Report" runat="server" GroupName="ReportType" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:RadioButton ID="rd_cred_type" Text="&nbsp; Credited" runat="server" GroupName="ReportType" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:RadioButton ID="rd_deb_type" Text="&nbsp; Debited" runat="server" GroupName="ReportType" />
                                        </div>
                                    </div>
                                    <br />
                                    <span style="color: red">Note :  </span>
                                    <ul style="color: black;">
                                        <li>This information will be securely saved as per E-Banking Terms of Services and Privacy Policy</li>
                                        <li>The Transaction History Report provides comprehensive transaction history details, including all ownership transfers, such as quit claims and market sales, plus any mortgages.</li>
                                        <li>Transaction history shows earning details, including the origin of the earning from the product sold earning dates, status, and estimated payment month.</li>
                                        <li>If the account is temporarily blocked, then you will need to unblock the account to initiate further process.</li>
                                    </ul>
                                    <br />
                                    <br />

                                </div>
                                <div class="col-md-5">
                                    <img src="img/pngtree-stock-market.png" class="img-fluid img-thumbnail" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Button ID="btn_gen_rep" runat="server" CssClass="btn btn-facebook btn-block" Text="Generate Report" OnClick="btn_gen_rep_Click" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Button ID="btn_history" runat="server" CssClass="btn btn-facebook btn-block" Text="Transaction History" OnClick="btn_history_Click" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Button ID="btn_clear" runat="server" CssClass="btn btn-facebook btn-block" Text="Clear" OnClick="btn_clear_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                            <div class="row">
                                <asp:GridView ID="grd_data" runat="server" CssClass="table" AutoGenerateColumns="false" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Transaction Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_transactionid" runat="server" Text='<%# Eval("Transaction Number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_transactionamt" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transaction Details">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_transactionreason" runat="server" Text='<%# Eval("Transaction Details") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transaction Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_transactiondate" runat="server" Text='<%# Eval("Transaction Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        createDataTable();
        function createDataTable() {
            $('#<%= grd_data.ClientID %>').DataTable();
        }
    </script>
</asp:Content>

