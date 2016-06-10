using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project.Areas.Admin.Controllers;
using Project.Model.Models;
using Project.Services;

namespace Project.Tests
{

    [TestClass]
    public class AdminHomeControllerTests
    {
        [TestMethod]
        public void AdminHomeController()
        {

            var mockContentService = new Mock<IContentService>();

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


            mockContentService.Setup(x => x.GetAllContents()).Returns(contents);
            mockContentService.Setup(x => x.GetContent(It.IsAny<int>())).Returns(contents.FirstOrDefault());
            
            var adminHomeController = new HomeController(mockContentService.Object);

            var result = adminHomeController.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(adminHomeController.ModelState.IsValid, true);
            Assert.AreEqual(result.ViewName, "Index");
            

        }
    }
}
