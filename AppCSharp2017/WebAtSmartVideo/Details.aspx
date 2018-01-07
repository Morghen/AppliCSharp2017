<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebAtSmartVideo.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label runat="server" ID="filmName"></asp:Label>
    </div>
    <div>
        <asp:Label runat="server" ID="FilmDetails"></asp:Label>
    </div>
    <div>
        <p>Video !</p>
    </div>
    <div>
        <asp:Button runat="server" ID="rentButton" OnClick="rentButton_OnClick"/>
    </div>
    
    

</asp:Content>
