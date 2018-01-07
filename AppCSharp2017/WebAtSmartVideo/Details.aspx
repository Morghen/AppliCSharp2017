<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebAtSmartVideo.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        
        <div>
            <asp:Label runat="server" ID="FilmDetails"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="id"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="filmName"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="runtime"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="posterPath"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="trailerPath"></asp:Label>
        </div>
        
        <div>
            <p>Video !</p>
        </div>
    </div>
    <div>
        <asp:Image runat="server" ID="image" Height="220px" Width="110px"/>
    </div>
    <div>
        
        <asp:Button runat="server" ID="rentButton"  Text="Louez le Film" OnClick="rentButton_OnClick"/>
        <asp:Label runat="server" ID="erreurRent"></asp:Label>
    </div>
    
    

</asp:Content>
