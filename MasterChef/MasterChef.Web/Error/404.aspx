<%@ Page Title="Not Found!" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="MasterChef.Web.Error._404" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mini-tron">
        <div class="row container">
            <h1 class="row col-sm-offset-1">Whooops!</h1>
            <h2 class="row col-sm-offset-3">Not Found!</h2>
            <h3 class="row text-center" style="color: red">404</h3>
        </div>
        <div class="row container">
            <div class="text-center">
                <br />
                <br />
                <asp:Image runat="server" ID="ErrorImage" AlternateText="404 Error page not found GIF" />
            </div>
        </div>
    </div>
</asp:Content>
