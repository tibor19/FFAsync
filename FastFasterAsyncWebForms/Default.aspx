<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Default.aspx.cs" Inherits="FastFasterAsyncWebForms.Default" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <div class="box">
        <div class="leftboxcontent">
            <h2><a href="RecipeSearch.aspx">Search for recipes</a></h2>
            Search our database for your favorite recipes.&nbsp; We have recipes for every 
            occasion and taste.
        </div>
        <div class="rightboximage"><img src="Images/food/egg-clip.jpg" width="200px" height="130px" alt="Recipe search"/></div>
    </div>
    <div class="box">
        <div class="rightboxcontent">
            <h2><a href="RandomRecipe.aspx">I feel lucky</a></h2>
            If you are completely out of ideas, we will come up with a recipe idea for you.</div>
            <div class="leftboximage"><img src="Images/food/waffles-clip.jpg" width="200px" height="130px" alt="Random recipe"/></div>
    </div>
    <div class="box">
        <div class="leftboxcontent">
            <h2><a href="WeeklyMenu.aspx">Weekly Menu</a></h2>
            Tired of deciding what to eat for dinner? Get some ideas from our weekly menu.</div>
            <div class="rightboximage"><img src="Images/food/pizza-clip.jpg" width="200px" height="130px" alt="Weekly menu"/></div>
    </div>
    <div class="box">
        <div class="rightboxcontent">
            <h2><a href="TopRecipes.aspx">Top Recipes</a></h2>
            See what recipes other users tagged as their favorites</div>
            <div class="leftboximage"><img src="Images/food/icecream-clip.jpg" width="200px" height="130px" alt="Top Recipes"/></div>
    </div>
</asp:Content>

