<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Grid.ascx.cs" Inherits="MasterChef.Web.Controls.Grid" %>

<asp:Panel CssClass="row" runat="server" Visible="false" ID="DataPagingPanel">
    <div class="col-md-offset-3 col-md-6 col-md-offset-3">
        <asp:DataPager ID="DataPager" runat="server" PageSize="9" QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NumericButtonCssClass="btn btn-info" NextPreviousButtonCssClass="btn btn-info" />
                <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Panel>
<%-- MUST ADD PagedControlID on DataPager !!! --%>