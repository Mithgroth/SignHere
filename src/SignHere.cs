using Microsoft.AspNetCore.Http;
using SignHere.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SignHere
{
    public static class SignHere
    {
        /// <summary>
        /// <para>Checks the <paramref name="stream"/>'s header bytes, returns a matched <see cref="Signature" />.</para>
        /// Maximum possible header is 50 bytes long, for better results pass at least 50 bytes.
        /// </summary>
        /// <param name="stream"> Any kind of stream to be checked for its content. </param>
        /// <returns> A <see cref="Signature" /> object with <seealso cref="Extension" />, MagicBytes and Description. </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="stream"/> is null. </exception>
        public static Signature FindSignature(Stream stream)
        {
            stream.Validate();

            return Find(stream);
        }

        /// <summary>
        /// Checks the <paramref name="stream"/>'s header bytes if it matches the given <see cref="Extension" />. <br/>
        /// Maximum possible header is 50 bytes long, for better results pass at least 50 bytes.
        /// </summary>
        /// <param name="stream">Any type of stream to be checked for its content. </param>
        /// <param name="extension"><see cref="Extension" /> name to be checked for. </param>
        /// <returns> True if the <paramref name="stream"/>'s extension matches with <paramref name="extension" /> </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="stream"/> is null or empty. </exception>
        /// /// <exception cref="InvalidOperationException"> Thrown when <paramref name="stream"/> cannot be read. </exception>
        public static bool Is(this Stream stream, Extension extension)
        {
            stream.Validate();

            var findResult = Find(stream);
            return findResult?.Extension == extension;
        }

        /// <summary>
        /// Checks the <paramref name="stream"/>'s header bytes if its <see cref="Signature"/>.Description matches the given <see cref="Category" />. <br/>
        /// Maximum possible header is 50 bytes long, for better results pass at least 50 bytes.
        /// </summary>
        /// <param name="stream">Any type of stream to be checked for its content. </param>
        /// <param name="category">A predefined constant to be looked in a <seealso cref="Signature" />'s description text. </param>
        /// <returns> True if the <paramref name="stream"/>'s extension matches with <paramref name="extension" /> </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="stream"/> is null or empty. </exception>
        /// /// <exception cref="InvalidOperationException"> Thrown when <paramref name="stream"/> cannot be read. </exception>
        public static bool Is(this Stream stream, Category category)
        {
            stream.Validate();

            var findResult = Find(stream);
            if (findResult == default)
            {
                return false;
            }

            var dictionary = Vault.GetDictionary(category);
            dictionary.TryGetValue(category, out IEnumerable<Extension> extensionList);

            return extensionList.Any(x => x == findResult.Extension);
        }

        /// <summary>
        /// Checks the <paramref name="stream"/>'s header bytes if its <see cref="Signature"/>.Description matches the given <paramref name="searchText"/>. <br/>
        /// Maximum possible header is 50 bytes long, for better results pass at least 50 bytes.
        /// </summary>
        /// <param name="stream">Any type of stream to be checked for its content. </param>
        /// <param name="searchText">Text to be looked in a <seealso cref="Signature" />'s description text.</param>
        /// <returns> True if the <paramref name="stream"/>'s extension matches with <paramref name="extension" /> </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="stream"/> is null or empty. </exception>
        /// /// <exception cref="InvalidOperationException"> Thrown when <paramref name="stream"/> cannot be read. </exception>
        public static bool Is(this Stream stream, string searchText)
        {
            stream.Validate();

            var findResult = Find(stream);
            if (findResult == default)
            {
                return false;
            }

            var extensionList = Vault.FindExtensions(searchText);

            return extensionList.Any(x => x == findResult.Extension);
        }

        /// <summary>
        /// Converts the <paramref name="formFile"/> to a <see cref="MemoryStream"/> and checks its header bytes if it matches the given <see cref="Extension" />. <br/>
        /// Maximum possible header is 50 bytes long, for better results pass at least 50 bytes.
        /// </summary>
        /// <param name="formFile">Uploaded file to be checked for its content. </param>
        /// <param name="extension"><see cref="Extension" /> name to be checked for. </param>
        /// <returns> True if the <paramref name="formFile"/>'s extension matches with <paramref name="extension" /> </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="formFile"/> is null or empty. </exception>
        public static bool Is(this IFormFile formFile, Extension extension)
        {
            formFile.Validate();

            var stream = new MemoryStream();
            formFile.CopyTo(stream);
            var byteArray = stream.ToArray();

            byteArray.Validate();

            var findResult = Find(byteArray);
            return findResult?.Extension == extension;
        }

        /// <summary>
        /// <para>Converts the <paramref name="formFile"/> to a <see cref="MemoryStream"/> and checks its header bytes if its <see cref="Signature"/>.Description matches the given <see cref="Category" />. <br/>
        /// Maximum possible header is 50 bytes long, for better results pass at least 50 bytes.
        /// </summary>
        /// <param name="formFile">Uploaded file to be checked for its content. </param>
        /// <param name="category">A predefined constant to be looked in a <seealso cref="Signature" />'s description text. </param>
        /// <returns> True if the <paramref name="formFile"/>'s extension matches with <paramref name="extension" /> </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="formFile"/> is null or empty. </exception>
        public static bool Is(this IFormFile formFile, Category category)
        {
            formFile.Validate();

            var stream = new MemoryStream();
            formFile.CopyTo(stream);
            var byteArray = stream.ToArray();
            byteArray.Validate();

            var findResult = Find(byteArray);
            var dictionary = Vault.GetDictionary(category);
            dictionary.TryGetValue(category, out IEnumerable<Extension> extensionList);

            return extensionList.Any(x => x == findResult?.Extension);
        }

        /// <summary>
        /// <para>Converts the <paramref name="formFile"/> to a <see cref="MemoryStream"/> and checks its header bytes if its <see cref="Signature"/>.Description matches the given <paramref name="searchText"/>. <br/>
        /// Maximum possible header is 50 bytes long, for better results pass at least 50 bytes.
        /// </summary>
        /// <param name="formFile">Uploaded file to be checked for its content. </param>
        /// <param name="searchText">Text to be looked in a <seealso cref="Signature" />'s description text.</param>
        /// <returns> True if the <paramref name="formFile"/>'s extension matches with <paramref name="extension" /> </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="formFile"/> is null or empty. </exception>
        public static bool Is(this IFormFile formFile, string searchText)
        {
            formFile.Validate();

            var stream = new MemoryStream();
            formFile.CopyTo(stream);
            var byteArray = stream.ToArray();
            byteArray.Validate();

            var findResult = Find(byteArray);
            var extensionList = Vault.FindExtensions(searchText);

            return extensionList.Any(x => x == findResult?.Extension);
        }

        private static void Validate(this Stream stream)
        {
            if (stream?.Length == 0)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (stream?.CanRead == false)
            {
                throw new InvalidOperationException(nameof(stream));
            }
        }

        private static void Validate(this IFormFile formFile)
        {
            if (formFile?.Length == 0)
            {
                throw new ArgumentNullException(nameof(formFile));
            }
        }

        private static void Validate(this byte[] byteArray)
        {
            if (byteArray?.Length == 0)
            {
                throw new ArgumentNullException(nameof(byteArray));
            }
        }

        private static Signature Find(Stream stream)
        {
            using (var reader = new BinaryReader(stream))
            {
                var headerBytes = reader.ReadBytes(Vault.MaxHeaderLength);
                return Vault.Bank.Find(s => headerBytes.Take(s.MagicBytes.Length)
                                                       .SequenceEqual(s.MagicBytes));
            }
        }

        private static Signature Find(byte[] byteArray)
        {
            return Vault.Bank.Find(s => byteArray.Take(s.MagicBytes.Length)
                                                 .SequenceEqual(s.MagicBytes));
        }
    }
}