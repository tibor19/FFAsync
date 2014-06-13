<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUS.aspx.cs" Inherits="FastFasterAsyncWebForms.ContactUS" %>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <h2>Tell us what you think</h2>
<div class="bigbox">
    <h3>Email:</h3>
    <asp:TextBox runat="server" ID="txtEmail" width="300px">someone@somewhere.com</asp:TextBox>
    <h3>What we should know:</h3>
    <asp:TextBox runat="server" ID="txtMessage" Width="300px" Height="150px" TextMode="MultiLine">Hello World</asp:TextBox>
    <br /><br />
    <asp:Button runat="server" ID="btnSubmit" Text="Send" />
</div>
</asp:Content>