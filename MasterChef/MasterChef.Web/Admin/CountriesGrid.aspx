﻿<%@ Page Title="CountriesGrid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountriesGrid.aspx.cs" Inherits="MasterChef.Web.Admin.CountriesGrid" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<asp:UpdatePanel ID="UpdataPanel" runat="server">
		<ContentTemplate>
			<h3 class="text-center alert alert-dismissable alert-info" id="headerInfo" runat="server">Countries Grid</h3>
			<div class="row">
				<div class="col-md-12">
					<asp:GridView CssClass="table table-striped table-hover table-bordered table-responsive"
						ID="gridView" runat="server" DataSourceID="EntityDataSourceProvider"
						AllowPaging="True" AllowSorting="True"
						AutoGenerateColumns="false"
						AutoGenerateDeleteButton="true"
						AutoGenerateEditButton="true">
						<Columns>
							<asp:BoundField DataField="ID" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
							<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
						</Columns>
					</asp:GridView>
					<ef:EntityDataSource runat="server" ID="EntityDataSourceProvider"
						OnContextCreating="dataSource_ContextCreating"
						EntitySetName="Countries"
						EnableDelete="true" EnableInsert="true" EnableUpdate="true">
					</ef:EntityDataSource>
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
