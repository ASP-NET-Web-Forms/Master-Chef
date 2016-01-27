using MasterChef.Data;
using MasterChef.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Caching;
using System.IO;

namespace MasterChef.Web
{
    public partial class _Default : Page
    {
        private IMasterChefData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new MasterChefDbContext();
            this.data = new MasterChefData(dbContext);
            var allArticles = this.data.Articles.All();

            Master.FindControl("panelSiteMapPath").Visible = false;

            this.UserControlNewestArticles.NewestArticlesList.DataSource = allArticles
                .OrderByDescending(article => article.CreatedOn)
                .Take(3)
                .Select(x => new HomeNewestArticlesViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    ImagePath = x.Image.Path,
                    Comments = x.Comments.Count,
                    Likes = x.Likes.Count
                })
                .ToList();

            this.UserControlNewestArticles.NewestArticlesList.DataBind();
        }
    }
}