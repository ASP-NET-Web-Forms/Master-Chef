<%@ Page Title="Browse Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="MasterChef.Web.Article.Browse" %>

<%@ Register TagPrefix="uc" TagName="Gridd" Src="~/Controls/Grid.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelArticle" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" CssClass="panel panel-warning" ID="FilterContainer">
                <div class="panel-heading">
                    <h3 class="panel-title">Filters</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="OrderType" class="control-label col-md-3">Order type:</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="OrderType"
                                        AutoPostBack="true"
                                        OnSelectedIndexChanged="GetFilteredArticles"
                                        CssClass="form-control" runat="server">
                                        <asp:ListItem Selected="True" Value="desc"> Descending </asp:ListItem>
                                        <asp:ListItem Value="asc"> Ascending </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="OrderType" class="control-label col-md-3">Order by:</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="OrderBy"
                                        AutoPostBack="true"
                                        OnSelectedIndexChanged="GetFilteredArticles"
                                        CssClass="form-control" runat="server">
                                        <asp:ListItem Selected="True" Value="createdOn"> Date </asp:ListItem>
                                        <asp:ListItem Value="likes"> Likes </asp:ListItem>
                                        <asp:ListItem Value="title"> Title </asp:ListItem>
                                        <asp:ListItem Value="username"> Creator </asp:ListItem>
                                        <asp:ListItem Value="comments"> Comments </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="row">
                <div class="col-md-12">
                    <asp:ListView ID="ListViewArticles" runat="server" ItemType="MasterChef.Web.Models.ArticleViewModel">
                        <ItemTemplate>
                            <div class="col-lg-12">
                                <div class="thumbnail">
                                    <a href="<%#: ResolveUrl("~/Article/Details?Id="+Item.ID) %>" title="<%#: Item.Title %>">
                                        <div class="ratio-events img-rounded" style="background-image: url('<%#: Item.ImagePath!=null? Page.ResolveUrl(Item.ImagePath): "/Images/default.png" %>')"></div>
                                    </a>
                                    <div class="caption">
                                        <h4 class="truncate well well-sm text-center">
                                            <a href="<%#: ResolveUrl("~/Article/Details?Id="+Item.ID) %>">
                                                <%#: Item.Title %>
                                            </a>
                                        </h4>
                                    </div>
                                    <div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <p class="truncate additional-beer-info">
                                                    Creator: <big><a class="text-success" href="<%#: ResolveUrl("~/User/Details?Id="+Item.CreatorID) %>"><%#: Item.Creator %></a> </big>
                                                </p>
                                            </div>
                                            <div class="col-md-6 text-right">
                                                <p class="truncate additional-beer-info">
                                                    <big><strong class="text-success"><%#: Item.Likes %> Likes</strong></big>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <p class="truncate additional-beer-info">
                                                    Created On: <big><strong class="text-success"><%#: Item.CreatedOn %></strong> </big>
                                                </p>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="additional-beer-info">
                                                    <p class="truncate text-right">
                                                        <big><strong class="text-success"><%#: Item.Comments %> Comments</strong></big>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <a href="<%#: ResolveUrl("~/Article/Details?Id="+Item.ID) %>" class="btn btn-primary btn-block">Read all about it!</a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <%--<uc:Gridd runat="server" ID="UserControlArticleGrid"/>--%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
