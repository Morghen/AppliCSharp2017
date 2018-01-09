<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="WebAtSmartVideo.Locations" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>List des locations</h3>
    <asp:gridview id="grid" runat="server" backcolor="White" bordercolor="#E7E7FF" borderstyle="None" borderwidth="1px" 
        cellpadding="3" font-names="Calibri" font-size="Larger" gridlines="Horizontal" AutoGenerateColumns="false" OnRowCommand="grid_RowCommand">

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
            <asp:BoundField ReadOnly="True" HeaderText="Title" InsertVisible="False" DataField="FilmName" SortExpression="FilmName"/>
            <asp:BoundField ReadOnly="True" HeaderText="Date Debut" InsertVisible="False" DataField="DateDebut" SortExpression="DateDebut"/>
            <asp:BoundField ReadOnly="True" HeaderText="DateFin" InsertVisible="False" DataField="DateFin" SortExpression="DateFin"/>
            <asp:BoundField ReadOnly="True" HeaderText="Url" InsertVisible="False" DataField="Url" SortExpression="Url"/>
            <asp:ButtonField ButtonType="Button" CommandName="viewDetails" Text="Details" />
        </Columns>
    </asp:gridview>
</asp:Content>
