using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;

namespace FastFasterAsyncWebForms
{
    public partial class DisplayRecipe : System.Web.UI.Page
    {
        Stopwatch _stopWatch;
        protected async void Page_Load(object sender, EventArgs e)
        {
            _stopWatch = Stopwatch.StartNew();
            lblError.Text = string.Empty;

            var recipeId = 0;
            if (Int32.TryParse(Request.QueryString["ID"], out recipeId) && recipeId != 0)
            {
                lblMethod.Text = "PageAsyncTask with proper Cancellation";
                // The cancellationToken is cancelled when the AsyncTimeout is reached
                Page.RegisterAsyncTask(new PageAsyncTask(cancellationToken => GetDetailsAsync(recipeId, cancellationToken)));
                Page.RegisterAsyncTask(new PageAsyncTask(cancellationToken => GetIngredientsAsync(recipeId, cancellationToken)));
                Page.RegisterAsyncTask(new PageAsyncTask(cancellationToken => GetInstructionsAsync(recipeId, cancellationToken)));
            }
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            _stopWatch.Stop();
            lblExecTime.Text = string.Format("{0} seconds", (_stopWatch.ElapsedMilliseconds / 1000d));
            base.OnPreRenderComplete(e);
        }

        private async Task GetDetailsAsync(int recipeId, CancellationToken cancellationToken)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecipesDBConnectionString"].ConnectionString);
            conn.Open();

            var cmd = new SqlCommand("GetRecipeDetails", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RecipeID", recipeId);

            using (var reader = await cmd.ExecuteReaderAsync(cancellationToken))
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

        private async Task GetIngredientsAsync(int recipeId, CancellationToken cancellationToken)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecipesDBConnectionString"].ConnectionString);
            conn.Open();

            var cmd = new SqlCommand("GetIngredientsForRecipe", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RecipeID", recipeId);

            using (var reader = await cmd.ExecuteReaderAsync(cancellationToken))
            {
                lstRecipeIngredients.DataSource = reader;
                lstRecipeIngredients.DataBind();
            }
            conn.Close();
        }

        private async Task GetInstructionsAsync(int recipeId, CancellationToken cancellationToken)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecipesDBConnectionString"].ConnectionString);
            conn.Open();

            var cmd = new SqlCommand("GetInstructionsForRecipe", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RecipeID", recipeId);

            using (var reader = await cmd.ExecuteReaderAsync(cancellationToken))
            {
                lstRecipeInstructions.DataSource = reader;
                lstRecipeInstructions.DataBind();
            }
            conn.Close();
        }
    }
}