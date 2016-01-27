<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Likes.ascx.cs" Inherits="MasterChef.Web.Controls.Likes" %>

<asp:UpdatePanel runat="server" ID="ControlWrapper">
    <ContentTemplate>
        <div class="text-center">
            <div class="row">
                <asp:Label runat="server" ID="LabelValue" CssClass="odometer" />
            </div>
            <div class="row">
                <asp:LinkButton runat="server" ID="ButtonLike" CssClass="btn btn-success glyphicon glyphicon-thumbs-up" CommandName="Like" OnCommand="ButtonLike_Command" Text=" Like" />
                <asp:LinkButton runat="server" ID="ButtonDislike" CssClass="btn btn-default glyphicon glyphicon-thumbs-down" CommandName="Dislike" OnCommand="ButtonLike_Command" Text=" Dislike" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
