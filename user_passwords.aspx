<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="user_passwords.aspx.cs" Inherits="user_passwords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Datatable/datatables.min.css" rel="stylesheet" />
    <script src="Datatable/datatables.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card shadow">
                <div class="card-header bg-gradient-card">
                    <h2>User Details</h2>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="lbl_usraccno" runat="server" Text="Account No:"></asp:Label><br />
                            <asp:TextBox ID="txt_usraccno" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_usrid" runat="server" Text="User Id"></asp:Label><br />
                            <asp:TextBox ID="txt_usrid" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_usrpass" runat="server" Text="Password"></asp:Label><br />
                            <asp:TextBox ID="txt_usrpasss" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="container-fluid" style="overflow-x: auto;">
                        <asp:GridView ID="grd_data" runat="server" CssClass="table" AutoGenerateColumns="false" Width="100%" Height="70%">
                            <Columns>
                                <asp:TemplateField HeaderText="User Id">
                                    <ItemTemplate>
                                        <asp:Label ID="User_Id" runat="server" Text='<%# Eval("User_Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Name">
                                    <ItemTemplate>
                                        <asp:Label ID="User_Name" runat="server" Text='<%# Eval("User_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Email">
                                    <ItemTemplate>
                                        <asp:Label ID="User_Email" runat="server" Text='<%# Eval("User_Email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Mobile">
                                    <ItemTemplate>
                                        <asp:Label ID="User_Mobile" runat="server" Text='<%# Eval("User_Mobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Details">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btn_view_pass" CommandName="select" CssClass="btn btn-primary btn-block" OnClick="btn_view_pass_Click" Text="View Password" />
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

