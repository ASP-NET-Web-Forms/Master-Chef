namespace MasterChef.Web.Controls
{
    using System;
    using System.Web.UI.WebControls;
    using System.Collections.Generic;
    using MasterChef.Models.Comment;
    using Models;
    using Common.Constants;

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

        public bool mustUpdate;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!mustUpdate)
            {
                return;
            }

            this.ListViewComments.DataSource = ArticleComments;
            this.ListViewComments.DataBind();
        }

        protected void ButtonCommentAdd_Command(object sender, CommandEventArgs e)
        {
            string commentContent = NewCommentTextBox.Text;
            // there is a regex control which checks for that but added this validation also.
            if (commentContent.Length < ModelConstants.CommentContentMinLength ||
                commentContent.Length > ModelConstants.CommentContentMaxLength)
            {
                return;
            }

            this.Comment(this, new CommentEventArgs(commentContent));
        }
    }
}