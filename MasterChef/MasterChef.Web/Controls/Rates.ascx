<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Rates.ascx.cs" Inherits="MasterChef.Web.Controls.Rates" %>

<asp:UpdatePanel runat="server" ID="RatesControlWrapper">
    <ContentTemplate>
        <div class="text-center">
            <div class="row">
                <p>
                    <asp:PlaceHolder ID="StarHolder5" runat="server" Visible="false">
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="StarHolder4" runat="server" Visible="false">
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="StarHolder3" runat="server" Visible="false">
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="StarHolder2" runat="server" Visible="false">
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="StarHolder1" runat="server" Visible="false">
                        <span class="glyphicon glyphicon-star rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="StarHolder0" runat="server" Visible="true">
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                        <span class="glyphicon glyphicon-star-empty rate-star"></span>
                    </asp:PlaceHolder>
                </p>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:TextBox runat="server" ID="RatingsCountTextBox" CssClass="text-center" Enabled="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <big><b><asp:TextBox Enabled="false" runat="server" ID="UserGaveRatingTextBox" CssClass="text-center" Text="Recipe Rated!" Visible="false" /></b></big>
                    <asp:DropDownList ID="GiveRatingDropDown"
                        CssClass="text-center" Font-Size="Large" runat="server">
                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                        <asp:ListItem Selected="True" Value="0"> 0 </asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="text-center col-md-12">
                    <asp:Button runat="server" ID="ButtonPostRating" CssClass="btn btn-danger glyphicon glyphicon-plus" OnCommand="ButtonRatingAdd_Command" Text="Give Rating" />
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
