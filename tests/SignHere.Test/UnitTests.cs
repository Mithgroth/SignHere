using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using SignHere.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        // Extension

        public static IEnumerable<object[]> IsStreamExtensionData =>
            new List<object[]>
            {
                new object[]
                {
                    new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0xB7, }),
                    new List<Extension> {Extension.JPEG },
                    true
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0xB7, }),
                    new List<Extension> {Extension.REG },
                    false
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0xB7, }),
                    new List<Extension> { Extension.JPEG, Extension.ABI, Extension.ZAP },
                    true
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0xB7, }),
                    new List<Extension> { Extension.REG, Extension.ABI, Extension.ZAP },
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsStreamExtensionData))]
        public void Is_Stream_Extension_Should_Return_Expected(Stream stream, IEnumerable<Extension> checking, bool expected)
        {
            // Act
            bool actual;
            if (checking.As<List<Extension>>().Count == 1)
            {
                actual = stream.Is(checking.As<List<Extension>>().First());
            }
            else
            {
                actual = stream.Is(checking);
            }

            // Assert
            actual.Should().Be(expected);
        }

        // Category

        public static IEnumerable<object[]> IsStreamCategoryData =>
            new List<object[]>
            {
                new object[]
                {
                    new MemoryStream(new byte[] { 0x00, 0x00, 0x01, 0xBA }),
                    new List<Category>() { Category.Video },
                    true
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0x9C, 0xCB, 0xCB, 0x8D, 0x13, 0x75, 0xD2, 0x11 }),
                    new List<Category>() { Category.Image },
                    false
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0x00, 0x00, 0x01, 0xBA }),
                    new List<Category>() { Category.Video, Category.Image },
                    true
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0x9C, 0xCB, 0xCB, 0x8D, 0x13, 0x75, 0xD2, 0x11 }),
                    new List<Category>() { Category.Video, Category.Audio },
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsStreamCategoryData))]
        public void Is_Stream_Category_Should_Return_Expected(Stream stream, IEnumerable<Category> checking, bool expected)
        {
            bool actual;
            if (checking.As<List<Category>>().Count == 1)
            {
                actual = stream.Is(checking.As<List<Category>>().First());
            }
            else
            {
                actual = stream.Is(checking);
            }

            // Assert
            actual.Should().Be(expected);
        }

        // String

        public static IEnumerable<object[]> IsStreamFromStringData =>
            new List<object[]>
            {
                new object[]
                {
                    new MemoryStream(new byte[] { 0xE3, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 }),
                    new List<string>() { "Amiga" },
                    true
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0x5F, 0x27, 0xA8, 0x89 }),
                    new List<string>() {  "Trains" },
                    false
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0xE3, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 }),
                    new List<string>() { "Amiga", "Image" },
                    true
                },
                new object[]
                {
                    new MemoryStream(new byte[] { 0x5F, 0x27, 0xA8, 0x89 }),
                    new List<string>() { "Brains", "Mushrooms" },
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsStreamFromStringData))]
        public void Is_Stream_FromString_Should_Return_Expected(Stream stream, IEnumerable<string> checking, bool expected)
        {
            // Act
            bool actual;
            if (checking.As<List<string>>().Count == 1)
            {
                actual = stream.Is(checking.As<List<string>>().First());
            }
            else
            {
                actual = stream.Is(checking);
            }

            // Assert
            actual.Should().Be(expected);
        }

        #endregion

        #region Is(IFormFile)
        private static FormFile GetFormFile()
        {
            var stream = new MemoryStream(File.ReadAllBytes("nevergonnagiveyouup.jpeg"));
            var formFile = new FormFile(stream, 0, stream.Length, "test", "nevergonnagiveyouup");

            return formFile;
        }

        public static IEnumerable<object[]> IsIFormFileExtensionData =>
            new List<object[]>
            {
                new object[]
                {
                    GetFormFile(),
                    new List<Extension>() { Extension.JFIF },
                    true
                },
                new object[]
                {
                    GetFormFile(),
                    new List<Extension>() { Extension.ZIP },
                    false
                },
                new object[]
                {
                    GetFormFile(),
                    new List<Extension>() { Extension.JFIF, Extension.ABA, Extension.KGB },
                    true
                },
                new object[]
                {
                    GetFormFile(),
                    new List<Extension>() { Extension.ZIP, Extension.CSH, Extension.hip, Extension.P10 },
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsIFormFileExtensionData))]
        public void Is_IFormFile_Extension_Should_Return_Expected(IFormFile formFile, IEnumerable<Extension> checking, bool expected)
        {
            // Act
            bool actual;
            if (checking.As<List<Extension>>().Count == 1)
            {
                actual = formFile.Is(checking.As<List<Extension>>().First());
            }
            else
            {
                actual = formFile.Is(checking);
            }

            // Assert
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> IsIFormFileCategoryData =>
            new List<object[]>
            {
                new object[]
                {
                    GetFormFile(),
                    new List<Category>() { Category.Image },
                    true
                },
                new object[]
                {
                    GetFormFile(),
                    new List<Category>() { Category.Audio },
                    false
                },
                new object[]
                {
                    GetFormFile(),
                    new List<Category>() { Category.Image, Category.Multimedia, Category.Audio },
                    true
                },
                new object[]
                {
                    GetFormFile(),
                    new List<Category>() { Category.Audio, Category.Video },
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsIFormFileCategoryData))]
        public void Is_IFormFile_Category_Should_Return_Expected(IFormFile formFile, IEnumerable<Category> checking, bool expected)
        {
            // Act
            bool actual;
            if (checking.As<List<Category>>().Count == 1)
            {
                actual = formFile.Is(checking.As<List<Category>>().First());
            }
            else
            {
                actual = formFile.Is(checking);
            }

            // Assert
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> IsIFormFileFromStringData =>
            new List<object[]>
            {
                new object[]
                {
                    GetFormFile(),
                    new List<string>() { "iMaGe" },
                    true
                },
                new object[]
                {
                    GetFormFile(),
                    new List<string>() { "Archive" },
                    false
                },
                 new object[]
                {
                    GetFormFile(),
                    new List<string>() { "image", "assembly", "doctor" },
                    true
                },
                new object[]
                {
                    GetFormFile(),
                    new List<string>() { "Elephants", "unicORns", "yalTa" },
                    false
                },
            };

        [Theory]
        [MemberData(nameof(IsIFormFileFromStringData))]
        public void Is_IFormFile_FromString_Should_Return_Expected(IFormFile formFile, IEnumerable<string> checking, bool expected)
        {
            // Act
            bool actual;
            if (checking.As<List<string>>().Count == 1)
            {
                actual = formFile.Is(checking.As<List<string>>().First());
            }
            else
            {
                actual = formFile.Is(checking);
            }

            // Assert
            actual.Should().Be(expected);
        }

        #endregion
    }
}