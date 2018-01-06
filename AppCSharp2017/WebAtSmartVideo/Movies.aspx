<%@ Page Title="Movies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="WebAtSmartVideo.Movies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Movie list</h3>
    <!-- Ici charger la liste de tous les films -->
    <asp:gridview id="grid" runat="server" backcolor="White" bordercolor="#E7E7FF" AutoGenerateColumns="true"
    
    borderstyle="None" borderwidth="1px" cellpadding="3" font-names="Calibri" font-size="Larger"

    gridlines="Horizontal">

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

    <asp:Button ID="buttonPrec" runat="server" Text="Précédent" OnClick="buttonPrec_Click"/>
    <asp:Button ID="buttonNext" runat="server" Text="Suivant" OnClick="buttonNext_Click"/>
</asp:Content>
