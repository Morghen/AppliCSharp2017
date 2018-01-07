<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebAtSmartVideo.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Nous contacter</h3>
    <address>
        Rue Peetermans 80<br />
        4100 Seraing<br />
        <abbr title="Phone">Tel:</abbr>
        04 330 75 00
    </address>

    <address>
        <strong>Antoine Brajkovic :</strong>   <a href="mailto:antoine.brajkovic@student.hepl.be">antoine.brajkovic@student.hepl.be</a><br />
        <strong>Rémy Mauhin :</strong> <a href="mailto:remy.mauhin@student.hepl.be">remy.mauhin@student.hepl.be</a>
    </address>
</asp:Content>
