<%@ Page Language="C#" AutoEventWireup="true" Title="Create Article" MasterPageFile="~/Site.Master" CodeBehind="ArticleCreate.aspx.cs" Inherits="MasterChef.Web.Admin.ArticleCreate" %>

<%@ Register TagPrefix="uc" TagName="FileUpload" Src="~/Controls/FileUpload.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center alert alert-dismissable alert-info">Post an Article:</h3>
    <fieldset class="form-horizontal">
        <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false">
            <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
        </asp:Panel>
        <div class="form-group">
            <label for="ImageUpload" class="col-lg-2 control-label">Image:</label>
            <div class="col-lg-10">
                <uc:FileUpload ID="FileUploadControl" IsRequired="true" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label for="title" class="col-lg-2 control-label">Title:</label>
            <div class="col-lg-10">
                <input type="text" runat="server" class="form-control" id="title" placeholder="Title">
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldTitle" ControlToValidate="title" CssClass="label label-danger pull-right" ErrorMessage="Title is required!" Display="Dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="Content" class="col-lg-2 control-label">Content:</label>
            <div class="col-lg-10">
                <textarea class="form-control" rows="3" id="content" runat="server" placeholder="Provide content for the article."></textarea>
            </div>
            <asp:RequiredFieldValidator ID="Requiredfieldcontent" ControlToValidate="Content" CssClass="label label-danger pull-right" ErrorMessage="Content is required!" Display="dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <a id="backButton" href="~/User/Events" runat="server" class="btn btn-danger">Cancel</a>
                <asp:Button ID="Submit" CssClass="btn btn-primary" runat="server" OnClick="Submit_Click" Text="Submit"></asp:Button>
            </div>
        </div>
    </fieldset>
</asp:Content>

