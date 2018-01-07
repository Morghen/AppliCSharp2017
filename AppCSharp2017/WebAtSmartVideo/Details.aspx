<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebAtSmartVideo.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label runat="server" ID="filmName"></asp:Label>
    </div>
    <div style="height: 146px">
        <asp:Label runat="server" ID="FilmDetails"></asp:Label>
    </div>
    <div>
        <p>Video !</p>
    </div>
    <div>
        <asp:Button runat="server" ID="rentButton"  Text="Louez le Film" OnClick="rentButton_OnClick"/>
        <asp:Label runat="server" ID="erreurRent"></asp:Label>
    </div>
    
    

</asp:Content>
