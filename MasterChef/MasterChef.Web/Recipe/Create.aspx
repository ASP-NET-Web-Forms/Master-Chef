<%@ Page Title="Create Recipe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="MasterChef.Web.Recipe.Create" %>

<%@ Register TagPrefix="uc" TagName="FileUpload" Src="~/Controls/FileUpload.ascx" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false">
            <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
        </asp:Panel>
        <h2>Create new recipe</h2>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="RecipeName" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="RecipeName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="RecipeName"
                    CssClass="text-danger" ErrorMessage="The name field is required." />
                <asp:RegularExpressionValidator runat="server" ValidationExpression=".{5,100}" ControlToValidate="RecipeName"
                    CssClass="text-danger" ErrorMessage="Recipe name must be between 5 and 100 characters."/>
                <asp:RegularExpressionValidator runat="server" ValidationExpression="([A-Za-z0-9 ])+" 
                    ControlToValidate="RecipeName" CssClass="text-danger" ErrorMessage="Invalid recipe name."/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="RecipeDescription" CssClass="col-md-2 control-label">How to prepare</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="RecipeDescription" style="resize: vertical" TextMode="multiline" Columns="30" Rows="7" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="RecipeDescription"
                    CssClass="text-danger" ErrorMessage="The description field is required." />

                <asp:RegularExpressionValidator runat="server" ValidationExpression=".{3,1000}" ControlToValidate="RecipeDescription"
                    CssClass="text-danger" ErrorMessage="Description must be between 3 and 1000 characters."/>

                <asp:RegularExpressionValidator runat="server" ValidationExpression="(([[A-Z]\w+)( \w+)*, [0-9].[1-9]])+" 
                    ControlToValidate="RecipeDescription" CssClass="text-danger" ErrorMessage="Invalid expression. Ex. [NAME1, QUANTITY][NAME2, QUANTITY]..."/>
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
                <asp:TextBox ID="RecipeIngredients" TextMode="multiline" Columns="10" Rows="4" runat="server" CssClass="form-control" placeholder="Format: [ ingredient 1 ] [ quantity ],[ ingredient 2 ] [ quantity ], ..." />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="RecipeIngredients"
                    CssClass="text-danger" ErrorMessage="The ingredients field is required." />

                <asp:RegularExpressionValidator runat="server" ValidationExpression=".{3,1000}" ControlToValidate="RecipeIngredients"
                    CssClass="text-danger" ErrorMessage="Ingredients must be between 3 and 1000 characters."/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="OnCreateRecipeButtonClick" Text="Create Recipe" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
</asp:Content>
