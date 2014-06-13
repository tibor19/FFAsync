using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FastFasterAsyncWebForms
{
    public partial class DisplayRecipe : System.Web.UI.Page
    {
        Stopwatch _stopWatch;
        protected void Page_Load(object sender, EventArgs e)
        {
            _stopWatch = Stopwatch.StartNew();
            lblError.Text = string.Empty;

            int recipeId = 0;
            if (Int32.TryParse(Request.QueryString["ID"], out recipeId) && recipeId != 0)
            {
                lblMethod.Text = "sync";
                GetDetails(recipeId);
                GetIngredients(recipeId);
                GetInstructions(recipeId);
            }
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            _stopWatch.Stop();
            lblExecTime.Text = string.Format("{0} seconds", (_stopWatch.ElapsedMilliseconds / 1000d));
            base.OnPreRenderComplete(e);
        }

        private void GetDetails(int recipeId)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecipesDBConnectionString"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetRecipeDetails", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RecipeID", recipeId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    RecipeName.Text = reader.GetString(0);
                    RecipeImage.ImageUrl = @"Images/food/" + reader.GetString(1) + ".jpg";
                    RecipePrice.Text = reader.GetDecimal(2).ToString();
                    RecipeTime.Text = reader.GetInt32(3).ToString();
                }
            }
            conn.Close();
        }

        private void GetIngredients(int recipeId)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecipesDBConnectionString"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetIngredientsForRecipe", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RecipeID", recipeId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                lstRecipeIngredients.DataSource = reader;
                lstRecipeIngredients.DataBind();
            }
            conn.Close();
        }

        private void GetInstructions(int recipeId)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecipesDBConnectionString"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetInstructionsForRecipe", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RecipeID", recipeId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                lstRecipeInstructions.DataSource = reader;
                lstRecipeInstructions.DataBind();
            }
            conn.Close();
        }
    }
}