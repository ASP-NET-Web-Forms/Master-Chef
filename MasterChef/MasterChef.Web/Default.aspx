<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MasterChef.Web._Default" %>
<%@ OutputCache Duration="200" VaryByParam="*" %>
<%@ Register TagPrefix="uc" TagName="NewestArticles" Src="~/Controls/NewestArticles.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row">
        <div class="col-md-12 jumbotron">
            <div class="col-md-5">
                <h1>Master Chef</h1>
                <p class="lead">The Taste is everything...</p>
            </div>
            <div class="col-md-7">
                <asp:Image runat="server" CssClass="img-responsive img-rounded" ImageUrl="~/Uploaded_Files/home-banner.png"></asp:Image>
            </div>
        </div>
    </div>

    <div class="panel panel-success">
        <div class="panel-heading">
            <h3 class="panel-title text-center">Latest articles</h3>
        </div>
        <div class="panel-body">
            <uc:NewestArticles runat="server" ID="UserControlNewestArticles" />
        </div>
    </div>

</asp:Content>
