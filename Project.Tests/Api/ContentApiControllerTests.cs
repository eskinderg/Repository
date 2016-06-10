using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project.Api;
using Project.Model;
using Project.Model.Models;
using Project.Services;

namespace Project.Tests
{
    
    [TestClass]
    public class ContentApiControllerTests
    {
        [TestMethod]
        public void ContentController()
        {

            var mockContentService= new Mock<IContentService>();
            var mockCategoryService = new Mock<ICategoryService>();

            IEnumerable<Content> contents = new List<Content>()
            {
                new Content
                {
                    Id = 1,
                    FolderId = 1,
                    Folder = new Folder
                    {
                        Id = 1,
                        Children = null,
                        Name = "Root",
                        Parent = null,
                        ParentId = null
                    },
                    Html = "HTML",
                    Summary = "My Summary",
                    Title = "My Title",
                    XmlConfigId = 56475
                }
            };
            

            mockContentService.Setup(x => x.GetContent(It.IsAny<int>())).Returns(contents.FirstOrDefault());

            mockCategoryService.Setup(x => x.GetAllCategories()).Returns(new List<Category>());


            var contentApiController = new ContentApiController(mockContentService.Object,mockCategoryService.Object);

            var result = contentApiController.GetContent(1);
            
            Assert.AreEqual(result.Id,1);
            Assert.AreEqual(contentApiController.ModelState.IsValid,true);

        }
    }
}
