<%@ Page Title="Forbidden!" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="403.aspx.cs" Inherits="MasterChef.Web.Error._403" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mini-tron">
        <div class="row container">
            <h1 class="row col-sm-offset-1">Ruuuuunn!</h1>
            <h2 class="row col-sm-offset-3">Forbidden!</h2>
            <h3 class="row text-center" style="color: red">403</h3>
        </div>
        <div class="row container">
            <div class="text-center">
                <br />
                <br />
                <asp:Image runat="server" ID="ErrorImage" AlternateText="403 Error page not found GIF" />
            </div>
        </div>
    </div>
</asp:Content>
