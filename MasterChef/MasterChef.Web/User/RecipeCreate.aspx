<%@ Page Title="" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="RecipeCreate.aspx.cs"
    Inherits="MasterChef.Web.User.RecipeCreate" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Create new recipe</h4>
        <hr />
    </div>

    <cc1:GMap ID="GMap1" runat="server" enableServerEvents="true"
        Width="100%" Height="450px" enableHookMouseWheelToZoom="true" mapType="Hybrid" OnClick="OnGoogleMapClick" />
</asp:Content>
