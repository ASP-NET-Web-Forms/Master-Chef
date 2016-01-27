<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="MasterChef.Web.Recipe.Browse" %>

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
                            <div class="col-sm-3 col-lg-3 col-md-3">
                                <a href="<%#: ResolveUrl("~/Recipes/Details?Id="+Item.ID) %>" class="thumbnail thumbnail-height-recipes">
                                    <asp:Image runat="server" CssClass="img-responsive img-rounded img-home-size" ImageUrl="<%# Item.ImagePath %>"></asp:Image>
                                    <div class="text-center">
                                        <asp:Label runat="server" CssClass="lead" Text="<%#: Item.Name %>"></asp:Label>                                        
                                    </div>
                                    <a href="<%#: ResolveUrl("~/Recipe/Details?Id="+Item.ID) %>" class="btn btn-danger btn-block read-button">Read all about it!</a>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:Panel CssClass="row" runat="server" ID="DataPagingPanel">
                        <div class="col-md-3 col-xs-offset-5">
                            <asp:DataPager ID="DataPager" runat="server" PageSize="8" QueryStringField="page" PagedControlID="ListViewRecipes">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-danger" NumericButtonCssClass="btn btn-default" NextPreviousButtonCssClass="btn btn-default" />
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
