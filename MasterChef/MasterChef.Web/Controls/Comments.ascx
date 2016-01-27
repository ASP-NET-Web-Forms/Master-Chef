<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="MasterChef.Web.Controls.Comments" %>

<asp:UpdatePanel runat="server" ID="ControlWrapper">
    <ContentTemplate>
        <asp:ListView ID="ListViewComments" runat="server" ItemType="MasterChef.Web.Models.CommentViewModel">
            <ItemTemplate>
                <div class="col-lg-offset-2 col-lg-8 panel">
                    <div class="caption">
                        <h5 class="text-center">
                            <a href="<%#: ResolveUrl("~/User/Profile?Id="+Item.CreatorID) %>">
                                <%#: Item.Creator %>
                            </a>
                        </h5>
                    </div>
                    <div class="row well">
                        <%#: Item.Content %>
                    </div>
                    <div class="row text-right">
                        <big class="text-success"><b>Created On: <%#: Item.CreatedOn %></b></big>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="col-md-12 text-center">
            <div class="form-group col-md-offset-1 col-md-10 text-center">
                <asp:Label runat="server" AssociatedControlID="NewCommentTextBox" CssClass="col-md-2 control-label">Add Comment:</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="NewCommentTextBox" Style="resize: vertical" BackColor="Silver" TextMode="multiline" Columns="2" Rows="3" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="text-center col-md-12">
                <asp:Button runat="server" ID="ButtonPostComment" CssClass="btn btn-success glyphicon glyphicon-plus" OnCommand="ButtonCommentAdd_Command" Text="Post Comment" />
            </div>
        </div>
        <asp:Panel runat="server" ID="DataPagingPanel" CssClass="col-md-12">
            <div class="text-center">
                <br />
                <asp:DataPager ID="DataPager" runat="server" PageSize="8" QueryStringField="page" PagedControlID="ListViewComments">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                        <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-primary" NumericButtonCssClass="btn btn-default" NextPreviousButtonCssClass="btn btn-default" />
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
