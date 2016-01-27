<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="MasterChef.Web.Account.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center">Edit profile:</h3>
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <asp:DetailsView runat="server" ID="details"
                AutoGenerateEditButton="false"
                DefaultMode="ReadOnly"
                EnableViewState="false"
                GridLines="None"
                CssClass="table"
                BorderStyle="None"
                BorderColor="Transparent"
                ItemType="MasterChef.Models.AppUser.AppUser"
                AutoGenerateRows="false"
                DataKeyNames="Id">

                <Fields>
                    <%-- First Name --%>
                    <asp:TemplateField HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0" HeaderStyle-VerticalAlign="Middle">
                        <HeaderTemplate>
                            <label class="control-label">
                                First Name:
                            </label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox runat="server"
                                ID="tbFirstName"
                                CssClass="form-control"
                                Text="<%#: Item.FirstName %>" Placeholder="First name"/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%-- Last Name --%>
                    <asp:TemplateField HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0" HeaderStyle-VerticalAlign="Middle">
                        <HeaderTemplate>
                            <label class="control-label">
                                Last Name:
                            </label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox runat="server"
                                ID="tbLastName"
                                CssClass="form-control"
                                Text="<%#: Item.LastName %>" Placeholder="Last name" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%-- Email --%>
                    <asp:TemplateField HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0" HeaderStyle-VerticalAlign="Middle">
                        <HeaderTemplate>
                            <label class="control-label">
                                Email:
                            </label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox runat="server"
                                ID="tbEmail"
                                CssClass="form-control"
                                Type="Email"
                                Text="<%#: Item.Email %>" Placeholder="Email" />
                        </ItemTemplate>
                    </asp:TemplateField>
                                        
                    <%-- Image --%>
                    <asp:TemplateField HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0" HeaderStyle-VerticalAlign="Middle">
                        <HeaderTemplate>
                            <label class="control-label">
                                Avatar:
                            </label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox runat="server"
                                ID="tbAvatar"
                                CssClass="form-control"
                                Text="<%#: Item.Image.Path %>" Placeholder="Url..." />
                            <asp:FileUpload ID="fileAvatar" accept=".png, .jpg, .jpeg, .gif" runat="server" AllowMultiple="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>

            <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false">
                <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
            </asp:Panel>

            <asp:Panel ID="editBtns" runat="server">
                <asp:Button Text="Update" runat="server" CssClass="btn btn-primary" OnClick="UpdateUser_Click" />
                <asp:LinkButton PostBackUrl="~/Account/Manage.aspx" Text="Cancel" runat="server" CssClass="btn btn-default" />
            </asp:Panel>

            <br />
            <br />
            <asp:Panel ID="panel" Visible="false" runat="server">
                <div class="alert alert-dismissible alert-danger">
                    <button type="button" class="close" data-dismiss="alert">X</button>
                    <p runat="server" id="errorText"></p>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

