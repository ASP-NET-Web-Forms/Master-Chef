<%@ Page Title="Article Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="MasterChef.Web.Article.Details" %>

<%@ Register Src="~/Controls/Likes.ascx" TagPrefix="uc" TagName="LikeControl" %>
<%@ Register Src="~/Controls/Comments.ascx" TagPrefix="uc" TagName="CommentsControl" %>

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
                    <asp:Image runat="server" ID="ArticleImage" class="article-details-image-ratio img-rounded img-responsive" />
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
    <asp:Panel runat="server" ID="LikeCommentPanel" CssClass="row">
        <div class="panel panel-success">
            <div class="panel-heading text-center">
                <h4><b>Like</b></h4>
            </div>
            <div class="panel-body">
                <uc:LikeControl runat="server" ID="LikeControl" OnLike="LikeControl_Like" />
            </div>
        </div>
        <div class="panel panel-warning">
            <div class="panel-heading text-center">
                <h4><b>Comment</b></h4>
            </div>
            <div class="panel-body">
                <uc:CommentsControl runat="server" ID="CommentControl" OnComment="CommentControl_Comment" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
