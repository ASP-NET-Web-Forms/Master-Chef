<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyRecipes.aspx.cs" Inherits="MasterChef.Web.User.MyRecipes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelRecipe" runat="server">
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
                                        OnSelectedIndexChanged="GetFilteredRecipes"
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
                                        OnSelectedIndexChanged="GetFilteredRecipes"
                                        CssClass="form-control" runat="server">
                                        <asp:ListItem Selected="True" Value="createdOn"> Date </asp:ListItem>
                                        <asp:ListItem Value="likes"> Likes </asp:ListItem>
                                        <asp:ListItem Value="name"> Name </asp:ListItem>
                                        <asp:ListItem Value="username"> Creator </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="row">
                <div class="col-md-12">
                    <asp:ListView ID="ListViewRecipes" runat="server" ItemType="MasterChef.Web.Models.RecipeViewModel">
                        <ItemTemplate>
                            <div class="col-lg-offset-2 col-lg-8 truncate well well-sm">
                                <div class="caption">
                                    <h4 class="text-center">
                                        <a href="<%#: ResolveUrl("~/Recipe/Details?Id="+Item.ID) %>">
                                            <%#: Item.Name %>
                                        </a>
                                    </h4>
                                </div>
                                <div>
                                    <div class="row">
                                        <a href="<%#: ResolveUrl("~/Recipe/Details?Id="+Item.ID) %>">
                                            <asp:Image runat="server" CssClass="my-recipe-image" ImageUrl="<%#: Item.ImagePath %>" /></a>
                                        <div class="article-content"><%#: Item.Description.Length > 1000 ? Item.Description.Substring(0, 1000) + "  . . ." : Item.Description %> </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <p class="truncate ">
                                                <big><b class="text-success"><%#: Item.Likes %> Likes</b></big>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <p class="truncate ">
                                                <big class="text-success"><b>Created On: <%#: Item.CreatedOn %></b> </big>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <a href="<%#: ResolveUrl("~/Recipe/Details?Id="+Item.ID) %>" class="btn btn-warning btn-block">Read all about it!</a>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:Panel CssClass="row" runat="server" ID="DataPagingPanel">
                        <div class="col-md-3 col-xs-offset-5">
                            <asp:DataPager ID="DataPager" runat="server" PageSize="8" QueryStringField="page" PagedControlID="ListViewRecipes">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NumericButtonCssClass="btn btn-default" NextPreviousButtonCssClass="btn btn-default" />
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>