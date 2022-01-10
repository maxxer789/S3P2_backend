using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostService.Logic;
using PostService.Models;
using PostService.Models.ViewModels;
using PostService.Repositories;
using Service.Tests.MockContexts;

namespace Service.Tests
{
    [TestClass]
    public class PostTests
    {
        private readonly PostLogic _logic;
        private readonly IMapper _mapper;
        public PostTests()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
            });

            _mapper = new Mapper(config);

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
