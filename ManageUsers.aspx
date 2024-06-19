<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Datatable/datatables.min.css" rel="stylesheet" />
    <script src="Datatable/datatables.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card shadow">
                <div class="card-header bg-gradient-card">
                    <h2>Admin Portal - Manage Users</h2>
                </div>
                <div class="card-body">
                    <div class="row">
                        <span style="color: red">Note :  </span>
                        <br />
                        <ul style="color: black;">
                            <li>E-Banking users can be Remove or Recover from this form.</li>
                            <li>After Removing users can not login their E-Banking portal.</li>
                        </ul>
                    </div>
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
                                <asp:TemplateField HeaderText="User Mobile No">
                                    <ItemTemplate>
                                        <asp:Label ID="User_Mobile" runat="server" Text='<%# Eval("User_Mobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Status">
                                    <ItemTemplate>
                                        <asp:Label ID="DelFlag" runat="server" Text='<%# Eval("DelFlag") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Block/UnBlock">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btn_test" CommandName="select" CssClass="btn btn-danger btn-block" OnClick="btn_test_Click" Text="Block" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:ButtonField ButtonType="Button" CommandName="btn_block" Text="Block User"/>--%>
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

