namespace MasterChef.Web.Article
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    using MasterChef.Data;
    using Models;
    using MasterChef.Models.Article;

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
            var articles = data.Articles.All()
                .OrderByDescending(a => a.CreatedOn)
                .Select(a => new ArticleViewModel
                {
                    ID = a.ID,
                    Content = a.Content,
                    Title = a.Title,
                    CreatedOn = a.CreatedOn,
                    CreatorID = a.CreatorID,
                    Creator = a.Creator.UserName,
                    ImagePath = a.Image.Path,
                    Comments = a.Comments.Count,
                    Likes = a.Likes.Count
                })
            .ToList();
            
            this.ListViewArticles.DataSource = articles;
            this.ListViewArticles.DataBind();
        }

        protected void GetFilteredArticles(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.OrderBy.SelectedValue))
            {
                Session["OrderBy"] = this.OrderBy.SelectedValue;
            }
            if (!string.IsNullOrEmpty(this.OrderType.SelectedValue))
            {
                Session["OrderType"] = this.OrderType.SelectedValue;
            }

            //Session.Timeout = 8; // MSDN: Most Web administrators set this property to 8 minutes. :D

            var orderBy = (string)Session["OrderBy"];
            var orderType = (string)Session["OrderType"];

            var allArticles = this.data.Articles.All();

            if (orderType == "asc")
            {
                switch (orderBy)
                {
                    case "comments":
                        allArticles = allArticles.OrderBy(a => a.Comments.Count);
                        break;
                    case "username":
                        allArticles = allArticles.OrderBy(a => a.Creator.UserName);
                        break;
                    case "title":
                        allArticles = allArticles.OrderBy(a => a.Title);
                        break;
                    case "createdOn":
                        allArticles = allArticles.OrderBy(a => a.CreatedOn);
                        break;
                    case "likes":
                        allArticles = allArticles.OrderBy(a => a.Likes.Count);
                        break;
                    default:
                        throw new ArgumentException("Wrong order type");
                }
            }
            else
            {
                switch (orderBy)
                {
                    case "comments":
                        allArticles = allArticles.OrderByDescending(a => a.Comments.Count);
                        break;
                    case "username":
                        allArticles = allArticles.OrderByDescending(a => a.Creator.UserName);
                        break;
                    case "title":
                        allArticles = allArticles.OrderByDescending(a => a.Title);
                        break;
                    case "createdOn":
                        allArticles = allArticles.OrderByDescending(a => a.CreatedOn);
                        break;
                    case "likes":
                        allArticles = allArticles.OrderByDescending(a => a.Likes.Count);
                        break;
                    default:
                        throw new ArgumentException("Wrong order type");
                }
            }

            var listViewArticles = allArticles.Select(a => new ArticleViewModel
            {
                ID = a.ID,
                Content = a.Content,
                Title = a.Title,
                CreatedOn = a.CreatedOn,
                CreatorID = a.CreatorID,
                Creator = a.Creator.UserName,
                ImagePath = a.Image.Path,
                Comments = a.Comments.Count,
                Likes = a.Likes.Count
            })
            .ToList();

            this.ListViewArticles.DataSource = listViewArticles;
            this.ListViewArticles.DataBind();
        }
    }
}