<%@ Page Title="Recipe Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="MasterChef.Web.Recipe.Details" %>

<%@ Register Src="~/Controls/Likes.ascx" TagPrefix="uc" TagName="LikeControl" %>
<%@ Register Src="~/Controls/Rates.ascx" TagPrefix="uc" TagName="RateControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" CssClass="row panel panel-danger" ID="ArticleInfoPanel">
        <div class="col-lg-offset-2 col-lg-8">
            <div class="caption">
                <br />
                <h3 class="text-center">
                    <strong runat="server" id="ArticleTitle" />
                </h3>
            </div>
            <div>
                <div class="row well">
                    <div class="col-md-4">
                        <asp:Image runat="server" ID="ArticleImage" class="article-details-image-ratio img-rounded img-responsive" />
                        <asp:Label runat="server" Visible="false" ID="isHotDish" class="label label-danger tag-recipe"> Hot </asp:Label>
                        <asp:Label runat="server" Visible="false" ID="isColdDish" class="label label-primary tag-recipe"> Cold </asp:Label>
                        <asp:Label runat="server" Visible="false" ID="isSweetDish" class="label label-info tag-recipe"> Sweet </asp:Label>
                        <asp:Label runat="server" Visible="false" ID="isVegetarianDish" class="label label-success tag-recipe"> Vegetarian </asp:Label>
                    </div>
                    <div class="col-md-8">
                        <h4>How to prepare:</h4>
                        <div class="lead article-details-content truncate" runat="server" id="ArticleContent" />
                    </div>
                </div>
                <div class="row well">
                    <div class="col-md-12">
                        <h4>Ingredients:</h4>
                        <asp:Repeater ID="IngredientsList" runat="server" ItemType="MasterChef.Models.Ingredient.Ingredient">
                            <ItemTemplate>
                                <%# Item.Name + " " + Item.Quantity + " " + Item.Measurement %>
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <p class="truncate">
                            <big class="text-success"><b>Creator: <a runat="server" id="ArticleCreatorLink"><span runat="server" id="ArticleCreatorName"/></a></b></big>
                        </p>
                    </div>
                    <div class="col-md-6 text-right">
                        <p class="truncate">
                            <big><b class="text-success" runat="server" id="ArticleCreatedOn"/></big>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4><b>Like</b></h4>
        </div>
        <div class="panel-body">
            <uc:LikeControl runat="server" ID="LikeControl" OnLike="LikeControl_Like" />
        </div>
    </div>
    <div class="panel panel-danger">
        <div class="panel-heading text-center">
            <h4><b>Rate</b></h4>
        </div>
        <div class="panel-body">
            <uc:RateControl runat="server" ID="RateControl" OnRate="RateControl_Rate" />
        </div>
    </div>
</asp:Content>
