using MasterChef.Data;
using MasterChef.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterChef.Web.Controls
{
    public partial class NewestArticles : UserControl
    {
        public ListView NewestArticlesList
        {
            get;
            set;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.NewestArticlesList = ListViewNewestArticles;
            
        }

        public IQueryable<HomeNewestArticlesViewModel> ListViewNewestArticles_GetData()
        {
            var dbContext = new MasterChefDbContext();
            var data = new MasterChefData(dbContext);

            var allArticles = data.Articles.All().ToList();
            var result = allArticles
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
                .AsQueryable();

            return result;
        }
    }
}