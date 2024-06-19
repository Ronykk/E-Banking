<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="transaction_history.aspx.cs" Inherits="transaction_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Datatable/datatables.min.css" rel="stylesheet" />
    <script src="Datatable/datatables.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card shadow">
                <div class="card-header bg-gradient-card">
                    <h2>Transaction History</h2>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="lbl_accno" runat="server" Text="Account No:"></asp:Label><br />
                            <asp:TextBox ID="txt_accno" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_totalbal" runat="server" Text="Total Balance"></asp:Label><br />
                            <asp:TextBox ID="txt_bal" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_acctype" runat="server" Text="Account Type:"></asp:Label><br />
                            <asp:TextBox ID="txt_acctype" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="container-fluid" style="overflow-x: auto;">
                        <asp:GridView ID="grd_data" runat="server" CssClass="table" AutoGenerateColumns="false" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Transaction Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_transactionid" runat="server" Text='<%# Eval("transaction_id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_transactionamt" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_transactionreason" runat="server" Text='<%# Eval("Reason") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_transactiondate" runat="server" Text='<%# Eval("EntryDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        createDataTable();
        function createDataTable() {
            $('#<%= grd_data.ClientID %>').DataTable();
        }
    </script>
</asp:Content>

