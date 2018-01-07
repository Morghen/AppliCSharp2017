<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebAtSmartVideo.Search" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Rechercher un film</h3>
    <div>
        <label id="searchLabel" runat="server">Entrez un titre ou un acteur : </label>
        <asp:TextBox ID="searchBox" runat="server">Rechercher...</asp:TextBox>
        <asp:DropDownList ID="dropMenu" runat="server">
            <asp:ListItem Text="Acteur"></asp:ListItem>
            <asp:ListItem Text="Films"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="searchButton" runat="server" Text="Rechercher" OnClick="searchButton_Click"/>
    </div>
    <div>
        <asp:GridView ID="gridSearch" runat="server" backcolor="White" bordercolor="#E7E7FF" borderstyle="None" borderwidth="1px" 
        cellpadding="3" font-names="Calibri" font-size="Larger" gridlines="Horizontal" AutoGenerateColumns="False">

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
        <Columns>
            <asp:BoundField ReadOnly="True" HeaderText="id" InsertVisible="False" DataField="id" SortExpression="id"/>
            <asp:BoundField ReadOnly="True" HeaderText="Title" InsertVisible="False" DataField="Title" SortExpression="Title"/>
            <asp:BoundField ReadOnly="True" HeaderText="Original Title" InsertVisible="False" DataField="OriginalTitle" SortExpression="OriginalTitle"/>
            <asp:BoundField ReadOnly="True" HeaderText="Runtime" InsertVisible="False" DataField="Runtime" SortExpression="Runtime"/>
            <asp:BoundField ReadOnly="True" HeaderText="Url" InsertVisible="False" DataField="Url" SortExpression="Url"/>
            <asp:BoundField ReadOnly="True" HeaderText="Poster Path" InsertVisible="False" DataField="FullPosterPath" SortExpression="FullPosterPath"/>
        
        </Columns>

        </asp:GridView>
    </div>
    
</asp:Content>
