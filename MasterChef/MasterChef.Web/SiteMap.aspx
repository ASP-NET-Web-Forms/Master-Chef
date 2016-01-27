<%@ Page Title="SiteMap" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SiteMap.aspx.cs" Inherits="MasterChef.Web.SiteMap" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Master Chef Sitemap</h1>
	<hr />
	<asp:TreeView ShowLines="true" ExpandDepth="1" ID="TreeViewSitePages" runat="server"
		DataSourceID="SiteMapDataSource" OnTreeNodeDataBound="TreeViewSitePages_TreeNodeDataBound" SkipLinkText="">
	</asp:TreeView>
	<asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" />
</asp:Content>
