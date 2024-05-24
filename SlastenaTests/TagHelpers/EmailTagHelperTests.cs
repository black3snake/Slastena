using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using Slastena.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlastenaTests.TagHelpers
{
    public class EmailTagHelperTests
    {
        [Fact]
        public void Generates_Email_Link()
        {
            // Arrange
            EmailTagHelper emailTagHelper = new() { Address = "test@slastena.ru", Content = "Email" };

            var tagHelperContext = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(), string.Empty);

            var context = new Mock<TagHelperContent>();

            var tagHelperOutput = new TagHelperOutput("a", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult(context.Object));

            //Act
            emailTagHelper.Process(tagHelperContext, tagHelperOutput);

            //Assert
            Assert.Equal("Email", tagHelperOutput.Content.GetContent());
            Assert.Equal("a", tagHelperOutput.TagName);
            Assert.Equal("mailto:test@slastena.ru", tagHelperOutput.Attributes[0].Value);



        }
    }
}
