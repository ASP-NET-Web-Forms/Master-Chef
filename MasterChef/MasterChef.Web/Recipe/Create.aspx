<%@ Page Title="Create Recipe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="MasterChef.Web.Recipe.Create" %>

<%@ Register TagPrefix="uc" TagName="FileUpload" Src="~/Controls/FileUpload.ascx" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false">
            <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
        </asp:Panel>
        <h2>Create new recipe</h2>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="RecipeName" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="RecipeName" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="RecipeDescription" CssClass="col-md-2 control-label">How to prepare</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="RecipeDescription" TextMode="multiline" Columns="30" Rows="7" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-2 control-label">Tags</label>
            <div class="col-lg-10">
                <div>
                    <asp:RadioButton ID="isHot" runat="server" GroupName="Temperature" OnCheckedChanged="isHot_CheckedChanged" />
                    Hot
                </div>
                <div>
                    <asp:RadioButton ID="isCold" runat="server" GroupName="Temperature" OnCheckedChanged="isCold_CheckedChanged" />
                    Cold
                </div>
                <div>
                    <asp:RadioButton ID="isSweet" runat="server" OnCheckedChanged="isSweet_CheckedChanged" />
                    Sweet
                </div>
                <div>
                    <asp:RadioButton ID="isVegetarian" runat="server" OnCheckedChanged="isVegetarian_CheckedChanged" />
                    Vegetarian
                </div>
            </div>
        </div>
        <div class="form-group">
            <label for="ImageUpload" class="col-md-2 control-label">Image:</label>
            <div class="col-md-10">
                <uc:FileUpload ID="FileUploadControl" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2 control-label">Location:</label>
            <div class="col-md-10">
                <cc1:GMap ID="GMap1" runat="server" enableServerEvents="true" Width="100%" Height="350px" enableHookMouseWheelToZoom="true" mapType="Hybrid" OnClick="OnGoogleMapClick" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="RecipeIngredients" CssClass="col-md-2 control-label">Ingredients</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="RecipeIngredients" TextMode="multiline" Columns="10" Rows="4" runat="server" CssClass="form-control" placeholder="Format: [ ingredient 1 ] [ quantity ],[ ingredient 2 ] [ quantity ], ..."/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="OnCreateRecipeButtonClick" Text="Create Recipe" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
</asp:Content>
