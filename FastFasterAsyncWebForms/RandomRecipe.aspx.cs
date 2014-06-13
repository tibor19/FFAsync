using System;

namespace FastFasterAsyncWebForms
{
    public partial class RandomRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rand = new Random(System.DateTime.Now.Millisecond);
            int recipeID = rand.Next(1, 9);

            Response.Redirect("DisplayRecipe.aspx?ID=" + recipeID);
        }
    }
}