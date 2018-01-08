<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stat.aspx.cs" Inherits="WebAtSmartVideo.Stat" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Statistiques</h3>
    <div>
        <label id="searchLabel" runat="server">Statistiques de : </label>
        <asp:DropDownList ID="dropMenu" runat="server">
            <asp:ListItem Text="Today"></asp:ListItem>
            <asp:ListItem Text="Hier"></asp:ListItem>
            <asp:ListItem Text="Tous"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="searchButton" runat="server" Text="obtenir" OnClick="searchButton_Click"/>
    </div>
    <asp:gridview id="grid" runat="server" backcolor="White" bordercolor="#E7E7FF" borderstyle="None" borderwidth="1px" 
        cellpadding="3" font-names="Calibri" font-size="Larger" gridlines="Horizontal" AutoGenerateColumns="true" >

    <AlternatingRowStyle BackColor="#F7F7F7" />

    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />

    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />

    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />

    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />

    <SortedAscendingCellStyle BackColor="#F4F4FD" />

    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />

    <SortedDescendingCellStyle BackColor="#D8D8F0" />

    <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:gridview>
</asp:Content>