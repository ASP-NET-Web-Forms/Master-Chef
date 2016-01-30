<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewestArticles.ascx.cs" Inherits="MasterChef.Web.Controls.NewestArticles" %>
<%@ OutputCache Duration="200" VaryByParam="None" %>
<div class="row">
    <asp:ListView ID="ListViewNewestArticles" runat="server" ItemType="MasterChef.Web.Models.HomeNewestArticlesViewModel"
        SelectMethod="ListViewNewestArticles_GetData">
        <ItemTemplate>
            <div class="col-sm-4 col-lg-4 col-md-4">
                <a href="<%#: ResolveUrl("~/Article/Details?Id="+Item.ID) %>" class="thumbnail thumbnail-height">
                    <asp:Image runat="server" CssClass="img-responsive img-rounded img-home-size" ImageUrl="<%# Item.ImagePath %>"></asp:Image>
                    <div class="text-center">
                        <span class="label label-primary home-tag">
                            <%#: "Comments: " + Item.Comments%>
                        </span>
                        <span class="label label-success home-tag">
                            <%#: "Likes: " + Item.Likes %>
                        </span>
                    </div>
                    <div class="text-center">
                        <asp:Label runat="server" CssClass="lead" Text="<%#: Item.Title %>"></asp:Label>
                    </div>
                </a>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
