using MasterChef.Data;
using MasterChef.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterChef.Web.Recipe
{
    public partial class Browse : System.Web.UI.Page
    {
        private IMasterChefData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new MasterChefDbContext();
            data = new MasterChefData(dbContext);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            var articles = data.Recipes.All()
                .OrderByDescending(r => r.CreatedOn)
                .Select(recipe => new RecipeViewModel
                {
                    ID = recipe.ID,
                    Description = recipe.Description,
                    Name = recipe.Name,
                    CreatedOn = recipe.CreatedOn,
                    CreatorID = recipe.CreatorID,
                    Creator = recipe.Creator.UserName,
                    ImagePath = recipe.Image.Path,
                    isCold = recipe.isCold,
                    isHot = recipe.isHot,
                    isSweet = recipe.isSweet,
                    isVegitarian = recipe.isVegitarian,
                    Likes = recipe.Likes.Count
                })
            .ToList();

            this.ListViewRecipes.DataSource = articles;
            this.ListViewRecipes.DataBind();
        }

        protected void GetFilteredRecipes(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.OrderBy.SelectedValue))
            {
                Session["OrderBy"] = this.OrderBy.SelectedValue;
            }
            if (!string.IsNullOrEmpty(this.OrderType.SelectedValue))
            {
                Session["OrderType"] = this.OrderType.SelectedValue;
            }

            var orderBy = (string)Session["OrderBy"];
            var orderType = (string)Session["OrderType"];

            var allRecipes = this.data.Recipes.All();

            if (orderType == "asc")
            {
                switch (orderBy)
                {
                    case "username":
                        allRecipes = allRecipes.OrderBy(a => a.Creator.UserName);
                        break;
                    case "name":
                        allRecipes = allRecipes.OrderBy(a => a.Name);
                        break;
                    case "createdOn":
                        allRecipes = allRecipes.OrderBy(a => a.CreatedOn);
                        break;
                    case "likes":
                        allRecipes = allRecipes.OrderBy(a => a.Likes.Count);
                        break;
                    default:
                        throw new ArgumentException("Wrong order type");
                }
            }
            else
            {
                switch (orderBy)
                {
                    case "username":
                        allRecipes = allRecipes.OrderByDescending(a => a.Creator.UserName);
                        break;
                    case "title":
                        allRecipes = allRecipes.OrderByDescending(a => a.Name);
                        break;
                    case "createdOn":
                        allRecipes = allRecipes.OrderByDescending(a => a.CreatedOn);
                        break;
                    case "likes":
                        allRecipes = allRecipes.OrderByDescending(a => a.Likes.Count);
                        break;
                    default:
                        throw new ArgumentException("Wrong order type");
                }
            }

            var listViewRecipes = allRecipes.Select(recipe => new RecipeViewModel
            {
                ID = recipe.ID,
                Description = recipe.Description,
                Name = recipe.Name,
                CreatedOn = recipe.CreatedOn,
                CreatorID = recipe.CreatorID,
                Creator = recipe.Creator.UserName,
                ImagePath = recipe.Image.Path,
                isCold = recipe.isCold,
                isHot = recipe.isHot,
                isSweet = recipe.isSweet,
                isVegitarian = recipe.isVegitarian,
                Likes = recipe.Likes.Count
            })
            .ToList();

            this.ListViewRecipes.DataSource = listViewRecipes;
            this.ListViewRecipes.DataBind();
        }
    }
}