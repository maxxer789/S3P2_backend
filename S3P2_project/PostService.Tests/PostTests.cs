using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostService.Context;
using PostService.Logic;
using PostService.Models;
using PostService.Models.ViewModels;
using PostService.Repositories;
using PostService.Profiles;
using PostService.Tests.MockContexts;

namespace PostService.Tests
{
    [TestClass]
    public class PostTests
    {
        private readonly PostLogic _logic;
        private readonly IMapper _mapper;
        public PostTests()
        {   
            IPostRepo IPostRepo = new MockPostContext();
            _logic = new PostLogic(IPostRepo, _mapper);
        }


        [TestMethod]
        public void PostById_ValidId()
        {
            int id = 2;


            PostViewModel post = _logic.GetPostById(id);


            Assert.AreEqual(id, post.Id);
        }
        [TestMethod]
        public void PostById_InvalidId()
        {
            int id = 9;


            PostViewModel post = _logic.GetPostById(id);


            Assert.IsNull(post);
        }
    }
}
