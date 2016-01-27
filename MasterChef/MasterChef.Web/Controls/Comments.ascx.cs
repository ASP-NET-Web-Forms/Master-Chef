namespace MasterChef.Web.Controls
{
    using System;
    using System.Web.UI.WebControls;
    using System.Collections.Generic;
    using MasterChef.Models.Comment;
    using Models;
    public class CommentEventArgs : EventArgs
    {
        public CommentEventArgs(string commentContent)
        {
            this.CommentContent = commentContent;
        }

        public string CommentContent { get; set; }
    }

    public partial class Comments : System.Web.UI.UserControl
    {
        public delegate void CommentEventHandler(object sender, CommentEventArgs e);

        public event CommentEventHandler Comment;

        public List<CommentViewModel> ArticleComments;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.ListViewComments.DataSource = ArticleComments;
            this.ListViewComments.DataBind();
        }

        protected void ButtonCommentAdd_Command(object sender, CommandEventArgs e)
        {
            string commentContent = NewCommentTextBox.Text;
            this.Comment(this, new CommentEventArgs(commentContent));
        }
    }
}