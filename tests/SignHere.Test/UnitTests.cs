using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using SignHere.Database;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SignHere.Test
{
    public class UnitTests
    {
        #region FindSignature

        public static IEnumerable<object[]> FindSignatureData =>
            new List<object[]>
            {
                new object[]
                {
                    new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0xB7, }),
                    new Signature()
                    {
                        Extension = Extension.JPEG,
                        MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                        Description = "CANNON EOS JPEG FILE"
                    }
                },
            };

        [Theory]
        [MemberData(nameof(FindSignatureData))]
        public void FindSignature_Should_Return_Signature(Stream stream, Signature expected)
        {
            // Act
            var actual = SignHere.FindSignature(stream);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void FindSignature_With_Null_Stream_Should_Throw_ArgumentNullException()
        {
            Action act = () => SignHere.FindSignature(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        #endregion

        #region Is(Stream)

        public static IEnumerable<object[]> IsStreamExtensionData =>
            new List<object[]>
            {
                new object[]
                {
                    new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0xB7, }),
                    Extension.JPEG,
                    true
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0xB7, }),
                    Extension.REG,
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsStreamExtensionData))]
        public void Is_Stream_Extension_Should_Return_Expected(Stream stream, Extension checking, bool expected)
        {
            // Act
            var actual = stream.Is(checking);

            // Assert
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> IsStreamCategoryData =>
            new List<object[]>
            {
                new object[]
                {
                    new MemoryStream(new byte[] { 0x00, 0x00, 0x01, 0xBA }),
                    Category.Video,
                    true
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0x9C, 0xCB, 0xCB, 0x8D, 0x13, 0x75, 0xD2, 0x11 }),
                    Category.Image,
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsStreamCategoryData))]
        public void Is_Stream_Category_Should_Return_Expected(Stream stream, Category checking, bool expected)
        {
            // Act
            var actual = stream.Is(checking);

            // Assert
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> IsStreamFromStringData =>
            new List<object[]>
            {
                new object[]
                {
                    new MemoryStream(new byte[] { 0xE3, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 }),
                    "Amiga",
                    true
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0x5F, 0x27, 0xA8, 0x89 }),
                    "Trains",
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsStreamFromStringData))]
        public void Is_Stream_FromString_Should_Return_Expected(Stream stream, string checking, bool expected)
        {
            // Act
            var actual = stream.Is(checking);

            // Assert
            actual.Should().Be(expected);
        }

        #endregion

        #region Is(IFormFile)
        private static FormFile GetFormFile()
        {
            var stream = new MemoryStream(File.ReadAllBytes(".\\nevergonnagiveyouup.jpeg"));
            var formFile = new FormFile(stream, 0, stream.Length, "test", "nevergonnagiveyouup");

            return formFile;
        }

        public static IEnumerable<object[]> IsIFormFileExtensionData =>
            new List<object[]>
            {
                new object[]
                {
                    GetFormFile(),
                    Extension.JFIF,
                    true
                },
                new object[]
                {
                    GetFormFile(),
                    Extension.ZIP,
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsIFormFileExtensionData))]
        public void Is_IFormFile_Extension_Should_Return_Expected(IFormFile formFile, Extension checking, bool expected)
        {
            // Act
            var actual = formFile.Is(checking);

            // Assert
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> IsIFormFileCategoryData =>
            new List<object[]>
            {
                new object[]
                {
                    GetFormFile(),
                    Category.Image,
                    true
                },
                new object[]
                {
                    GetFormFile(),
                    Category.Audio,
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsIFormFileCategoryData))]
        public void Is_IFormFile_Category_Should_Return_Expected(IFormFile formFile, Category checking, bool expected)
        {
            // Act
            var actual = formFile.Is(checking);

            // Assert
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> IsIFormFileFromStringData =>
            new List<object[]>
            {
                new object[]
                {
                    GetFormFile(),
                    "iMaGe",
                    true
                },
                new object[]
                {
                    GetFormFile(),
                    "Archive",
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsIFormFileFromStringData))]
        public void Is_IFormFile_FromString_Should_Return_Expected(IFormFile formFile, string checking, bool expected)
        {
            // Act
            var actual = formFile.Is(checking);

            // Assert
            actual.Should().Be(expected);
        }

        #endregion
    }
}