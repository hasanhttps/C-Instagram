using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.namespaces.PostNamespace {
    public class Post {

        // Private Fields

        private readonly Guid _id;
        private readonly DateTime _creationDate;
        private string _content;
        private int _likeCount;
        private int _viewCount;

        // Properties

        public Guid Id { get { return _id; } }
        public DateTime CreationDate { get { return _creationDate; } }
        public string Content { get { return _content; } set { _content = value; } }
        public int LikeCount { get { return _likeCount; } set { _likeCount = value; } }
        public int ViewCount { get { return _viewCount; } set { _viewCount = value; } }

        // Constructors

        public Post() { 
            _id = Guid.NewGuid();
            _creationDate = DateTime.Now;
        }
        public Post(string content, int likeCount, int viewCount)
            : this() {
            Content = content;
            LikeCount = likeCount;
            ViewCount = viewCount;
        }

        // Functions

        public override string ToString() {
            string post = $"Post Id : {Id}\nPost Date : {CreationDate}\nPost Content : \n{Content}\nLike Count : {LikeCount}, View Count : {ViewCount}\n\n";
            return post;
        }
    }
}
