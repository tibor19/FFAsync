<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DisplayRecipe.aspx.cs" Inherits="FastFasterAsyncWebForms.DisplayRecipe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 104px;
        }
        .style2
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <h2><asp:Literal ID="RecipeName" runat="server" Text="Sorry recipe not found"/></h2>
        <span class="style2">
            Method: <asp:Label ID="lblMethod" runat="server" />
            <br />
            Execution time: <asp:Label ID="lblExecTime" runat="server" /> 
        </span>
        <div class="box">
            <div class="rightboxcontent">
                <table border="0">
                    <tr><td class="style1"><b>Price: </b></td><td>$<asp:Literal ID="RecipePrice" runat="server" Text="0"/></td></tr>
                    <tr><td class="style1"><b>Cooking Time:</b></td><td><asp:Literal ID="RecipeTime" runat="server" Text="0"/>&nbsp;minutes</td></tr>
                </table>
            </div>
            <div class="leftboximage"><asp:Image ID="RecipeImage" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="200px" Height="130px" /></div>
    </div>
    <h3>Ingredients</h3>
    <asp:ListView ID="lstRecipeIngredients" runat="server">       
        <LayoutTemplate>
            <ul style="list-style-type:none;margin:15px">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <%# Eval("Amount") %> <%# Eval("AmountType") %> <%# Eval("Name") %>
            </li>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                Sorry - no ingredients found
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
    <h3>Instructions</h3>
    <asp:ListView ID="lstRecipeInstructions" runat="server">       
        <LayoutTemplate>
            <ol>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ol>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <%#Eval("InstructionText") %>
            </li>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                Sorry - no instructions found
            </div>
        </EmptyDataTemplate>               
    </asp:ListView>
    <br /><br /><br /><br />
    <div style="color:red"><asp:Literal runat="server" ID="lblError" /></div>
</asp:Content>

