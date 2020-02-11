using System;
using Xunit;

namespace xUnitTestProject
{
    public class DocumentProcessingTest
    {
        [Fact]
        public void WellFormedDocumentTest()
        {
            string file1 = "<html> {This is a well formed Test} </html>";
            Assert.True(DocumentProcessing.IsBalanced(file1), "Test failed. This well formed document should returned true.");
        }

        [Fact]
        public void NotWellFormedDocumentTest()
        {
            string file1 = "<html This is not well formed Test} </html>";
            Assert.False(DocumentProcessing.IsBalanced(file1), "Test failed. This not well formed document should returns false");
        }

        [Fact]
        public void WellFormedDocumentTest2()
        {
            string file1 = "<html<This is well formed Test>> { Test, [a, b, c], list } </html>";
            Assert.True(DocumentProcessing.IsBalanced(file1), "Test failed. This well formed document should returned true.");
        }

        [Fact]
        public void NotWellFormedDocumentTest2()
        {
            string file1 = ">>Not good<<";
            Assert.False(DocumentProcessing.IsBalanced(file1), "Test failed. This not well formed document should returns false");
        }

    }
}
