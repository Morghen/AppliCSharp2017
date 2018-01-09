<%@ Page Title="Movies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="WebAtSmartVideo.Movies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Movie list</h3>
    <asp:TextBox runat="server" ID="numberList" Text="15" TextMode="Number"/>

    <asp:Button ID="buttonPrec" runat="server" Text="Précédent" OnClick="buttonPrec_Click"/>
    <asp:Button ID="buttonNext" runat="server" Text="Suivant" OnClick="buttonNext_Click"/>
    <asp:gridview id="grid" runat="server" backcolor="White" bordercolor="#E7E7FF" borderstyle="None" borderwidth="1px" 
        cellpadding="3" font-names="Calibri" font-size="Larger" gridlines="Horizontal" AutoGenerateColumns="False" OnRowCommand="grid_RowCommand">

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
        <asp:BoundField ReadOnly="True" HeaderText="Title" InsertVisible="False" DataField="Title" SortExpression="Title"/>
        <asp:BoundField ReadOnly="True" HeaderText="Original Title" InsertVisible="False" DataField="OriginalTitle" SortExpression="OriginalTitle"/>
        <asp:BoundField ReadOnly="True" HeaderText="Runtime" InsertVisible="False" DataField="Runtime" SortExpression="Runtime"/>
        <asp:ButtonField ButtonType="Button" CommandName="viewDetails" Text="Details" />
    </Columns>
    </asp:gridview>

    </asp:Content>
