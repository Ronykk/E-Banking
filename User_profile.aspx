<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="User_profile.aspx.cs" Inherits="User_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-fluid">
            <div class="card shadow">
                <div class="card-header bg-gradient-card">
                    <h2>User Profile</h2>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-10">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="lbl_accno" runat="server" Text="Account No:"></asp:Label><br />
                                    <asp:TextBox ID="txt_accno" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="lbl_fstname" runat="server" Text="First Name:"></asp:Label><br />
                                    <asp:TextBox ID="txt_fstname" CssClass="form-control" runat="server" AutoCompleteType="Disabled" MaxLength="50" onkeypress="return alphanum(event);" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="lbl_lstname" runat="server" Text="Last Name:"></asp:Label><br />
                                    <asp:TextBox ID="txt_lstname" CssClass="form-control" runat="server" AutoCompleteType="Disabled" MaxLength="50" onkeypress="return alphanum(event);" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="lbl_email" runat="server" Text="Email:"></asp:Label><br />
                                    <asp:TextBox ID="txt_email" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="lbl_mobile" runat="server" Text="Mobile No:"></asp:Label><br />
                                    <asp:TextBox ID="txt_mobile" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="lbl_acctype" runat="server" Text="Account Type:"></asp:Label><br />
                                    <asp:DropDownList ID="ddl_acctype" runat="server" CssClass="form-control" Enabled="false">
                                        <asp:ListItem Text="--SELECT--" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Current" Value="Current"></asp:ListItem>
                                        <asp:ListItem Text="Saving" Value="Saving"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2" style="text-align: center; padding: 4px;">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Image runat="server" ID="Image1" ImageUrl="img/profile_img_main.png" title=" " class="img-fluid img-thumbnail" Style="border: solid #cdb1b1 2px; border-radius: 32px;" />
                                    <br />
                                    <br />
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="" onchange="ShowImagePreview(this);" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-sm-3"></div>
                        <div class="col-sm-2">
                            <asp:Button ID="btn_modify" runat="server" CssClass="btn btn-facebook btn-block" Text="Modify" OnClick="btn_modify_Click" />
                        </div>
                        <div class="col-sm-2">
                            <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-facebook btn-block" Text="Save" OnClick="btn_Save_Click" />
                        </div>
                        <div class="col-sm-2">
                            <asp:Button ID="btn_clear" runat="server" CssClass="btn btn-facebook btn-block" Text="Clear" OnClick="btn_clear_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>

    <script>
        function ShowImagePreview(input) {        // to show image before saving
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                document.getElementById('lbl_photo').innerHTML = 'Photo Uploaded';
                document.getElementById('lbl_photo').style.color = 'green';
                document.getElementById('FileUpload1').files = input.files;
            }
        }
    </script>
</asp:Content>

