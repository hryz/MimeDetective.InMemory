using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MimeDetective.InMemory.Tests
{
    [TestClass]
    public class Tests
    {
        private static readonly Random R = new Random();

        [TestMethod]
        [DynamicData(nameof(TestDataSet))]
        public void CanDetectMime(FileType file)
        {
            //Arrange
            var garbage = new byte[file.HeaderOffset];
            R.NextBytes(garbage);

            var bytes = garbage.Concat(file.Header.Select(x => x ?? 0)).ToArray();

            //Act
            var mime = bytes.DetectMimeType();

            //Assert
            Assert.AreEqual(mime, file);
        }

        private static IEnumerable<object[]> TestDataSet =>
            MimeTypes.AllTypes
                .Where(x => x.Header.Length > 0)
                .OrderByDescending(x => x.Header.LongLength)
                .Select(x => new object[] { x });
    }
}

