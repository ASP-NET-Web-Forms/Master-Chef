<%@ Page Title="Browse Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="MasterChef.Web.Article.Browse" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelArticle" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" CssClass="panel panel-default" ID="FilterContainer">
                <div class="panel-heading">
                    <h3 class="text-center">Filters</h3>
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
                            <div class="col-lg-offset-2 col-lg-8 truncate well well-sm">
                                <div class="caption">
                                    <h4 class="text-center">
                                        <a href="<%#: ResolveUrl("~/Article/Details?Id="+Item.ID) %>">
                                            <%#: Item.Title %>
                                        </a>
                                    </h4>
                                </div>
                                <div>
                                    <div class="row">
                                        <a href="<%#: ResolveUrl("~/Article/Details?Id="+Item.ID) %>">
                                            <asp:Image runat="server" CssClass="article-image" ImageUrl="<%#: Item.ImagePath %>" /></a>
                                        <div class="article-content"><%#: Item.Content.Length > 1000 ? Item.Content.Substring(0, 1000) + "  . . ." : Item.Content %> </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <p class="truncate additional-beer-info">
                                                <big class="text-success"><b>Creator: <a href="<%#: ResolveUrl("~/User/Details?Id="+Item.CreatorID) %>"><%#: Item.Creator %></a></b></big>
                                            </p>
                                        </div>
                                        <div class="col-md-6 text-right">
                                            <p class="truncate additional-beer-info">
                                                <big><b class="text-success"><%#: Item.Likes %> Likes</b></big>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <p class="truncate additional-beer-info">
                                                <big class="text-success"><b>Created On: <%#: Item.CreatedOn %></b> </big>
                                            </p>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="additional-beer-info">
                                                <p class="truncate text-right">
                                                    <big><b class="text-success"><%#: Item.Comments %> Comments</b></big>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <a href="<%#: ResolveUrl("~/Article/Details?Id="+Item.ID) %>" class="btn btn-primary btn-block">Read all about it!</a>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:Panel CssClass="row" runat="server" ID="DataPagingPanel">
                        <div class="col-md-offset-3 col-md-6 col-md-offset-3">
                            <asp:DataPager ID="DataPager" runat="server" PageSize="8" QueryStringField="page" PagedControlID="ListViewArticles">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NumericButtonCssClass="btn btn-info" NextPreviousButtonCssClass="btn btn-info" />
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
