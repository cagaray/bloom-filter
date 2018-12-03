using System.Threading.Tasks;
using Xunit;
using Moq;
using BloomFilter.Utilities;

namespace BloomFilter.UnitTests
{
    public class SpellCheckerTests
    {
        [Fact]
        public async Task LoadDataFromPath_CorrectPathAndNonEmptyFile_NonEmptyDictionary()
        {
            var reader = new Mock<IReaderFromFileSystem>();
            reader.Setup(r => r.GetContentsFromFileAsync()).Returns(Task.FromResult<string>("foo\nbar\ntest"));
            var dictionary = new Mock<IDict<string>>();
            dictionary.Setup(d => d.IsEmpty()).Returns(false);
            dictionary.Setup(d => d.AddItem(It.IsAny<string>()));
            SpellChecker checker = new SpellChecker(reader.Object, dictionary.Object);

            await checker.LoadDataFromPath();

            Assert.False(checker.IsEmptyDictionary());
            reader.Verify(r => r.GetContentsFromFileAsync(), Times.Once());
            dictionary.Verify(d => d.AddItem(It.IsAny<string>()), Times.Exactly(3));
        }

        [Fact]
        public async Task LoadDataFromPath_CorrectPathAndEmptyFile_EmptyDictionary()
        {
            var reader = new Mock<IReaderFromFileSystem>();
            reader.Setup(r => r.GetContentsFromFileAsync()).Returns(Task.FromResult<string>(""));
            var dictionary = new Mock<IDict<string>>();
            dictionary.Setup(d => d.IsEmpty()).Returns(true);
            dictionary.Setup(d => d.AddItem(It.IsAny<string>()));
            SpellChecker checker = new SpellChecker(reader.Object, dictionary.Object);

            await checker.LoadDataFromPath();

            Assert.True(checker.IsEmptyDictionary());
            reader.Verify(r => r.GetContentsFromFileAsync(), Times.Once());
            dictionary.Verify(d => d.AddItem(It.IsAny<string>()), Times.Exactly(0));
        }

        [Fact]
        public async Task CheckWordInDictionary_WordExists_ReturnTrue()
        {
            var reader = new Mock<IReaderFromFileSystem>();
            reader.Setup(r => r.GetContentsFromFileAsync()).Returns(Task.FromResult<string>("foo\nbar\ntest"));
            var dictionary = new Mock<IDict<string>>();
            dictionary.Setup(d => d.IsEmpty()).Returns(false);
            dictionary.Setup(d => d.AddItem(It.IsAny<string>()));
            dictionary.Setup(d => d.CheckItem(It.IsAny<string>())).Returns(true);
            SpellChecker checker = new SpellChecker(reader.Object, dictionary.Object);
            await checker.LoadDataFromPath();

            bool found = checker.CheckWordInDictionary("foo");

            Assert.True(found);
        }

        [Fact]
        public async Task CheckWordInDictionary_WordNotExists_ReturnFalse()
        {
            var reader = new Mock<IReaderFromFileSystem>();
            reader.Setup(r => r.GetContentsFromFileAsync()).Returns(Task.FromResult<string>("foo\nbar\ntest"));
            var dictionary = new Mock<IDict<string>>();
            dictionary.Setup(d => d.IsEmpty()).Returns(false);
            dictionary.Setup(d => d.AddItem(It.IsAny<string>()));
            dictionary.Setup(d => d.CheckItem(It.IsAny<string>())).Returns(false);
            SpellChecker checker = new SpellChecker(reader.Object, dictionary.Object);
            await checker.LoadDataFromPath();

            bool found = checker.CheckWordInDictionary("another");

            Assert.False(found);
        }
    }
}
