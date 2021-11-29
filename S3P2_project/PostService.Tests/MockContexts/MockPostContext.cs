using PostService.Models;
using PostService.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostService.Tests.MockContexts
{
    class MockPostContext : IPostRepo
    {
        private List<Post> MockPosts = new List<Post>();
        public MockPostContext()
        {
            PopulatePosts();
        }

        public Post GetPostById(int id)
        {
            return MockPosts.Find(p => p.Id == id);
        }

        public IReadOnlyList<Post> GetPosts()
        {
            return MockPosts.AsReadOnly();
        }
        private void PopulatePosts()
        {
            for (int i = 0; i < 4; i++)
            {
                Post post = new Post();
                post.Id = i;
                post.Title = "Title" + i;
                post.Description = "Description" + i;
                post.Link = "Link" + i;

                MockPosts.Add(post);
            }
        }
    }
}
