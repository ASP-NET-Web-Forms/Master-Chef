<%@ Page Title="Article Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="MasterChef.Web.Article.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" CssClass="row panel panel-danger" ID="ArticleInfoPanel">
        <div class="col-lg-offset-2 col-lg-8">
            <div class="caption">
                <h4 class="text-center">
                    <strong runat="server" id="ArticleTitle" />
                </h4>
            </div>
            <div>
                <div class="row">
                    <asp:Image runat="server" id="ArticleImage" class="article-details-image-ratio img-rounded" />
                    <div class="lead article-details-content truncate well well-lg" runat="server" id="ArticleContent" />
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
    <%--<asp:UpdatePanel ID="ArticleUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <asp:Panel CssClass="row" runat="server" ID="DataPagingPanel">
                        <div class="col-md-3 col-xs-offset-5">
                            <asp:DataPager ID="DataPager" runat="server" PageSize="8" QueryStringField="page" PagedControlID="ListViewArticles">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-primary" NumericButtonCssClass="btn btn-default" NextPreviousButtonCssClass="btn btn-default" />
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
