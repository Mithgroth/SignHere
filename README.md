# SignHere

[![build](https://github.com/Mithgroth/SignHere/actions/workflows/build.yml/badge.svg)](https://github.com/Mithgroth/SignHere/actions/workflows/build.yml) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE) [![NuGet Badge](https://buildstats.info/nuget/SignHere?includePreReleases=true)](https://www.nuget.org/packages/SignHere/)

An implementation of file signature validation as documented in [ASP.NET Core file upload document](https://docs.microsoft.com/en-gb/aspnet/core/mvc/models/file-uploads?view=aspnetcore-6.0#file-signature-validation). This library can validate signatures of 518 different file types, all taken from https://filesignatures.net/, as the document suggests.

## Usage
There are two main ways to use this library:
1. `SignHere.FindSignature()` method

    ```csharp
    var stream = new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0xB7, }); // "CANNON EOS JPEG FILE"
    var signature = SignHere.FindSignature(stream);

    // Comes out as:
    // signature.Extension = Extension.JPEG,
    // signature.MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
    // signature.Description = "CANNON EOS JPEG FILE"
    ```

1. `.Is()` extension method
   - `stream.Is()` extension: Works with any `Stream` object. Expects the stream content to be a `byte[]`. There are three different overloads to go with, all of them also have `IEnumerable` variants too:
     - `stream.Is(Extension)`: Checks by `Extension` enum.
        ```csharp
        var stream = new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0xB7, })
        var isJPEG = stream.Is(Extension.JPEG); // true
        ```
     - `stream.Is(Category)`: Checks by `Category`. A `Category` is a predefined constant string which is checked against `Signature.Description`.
        ```csharp
        var stream = new MemoryStream(new byte[] { 0x9C, 0xCB, 0xCB, 0x8D, 0x13, 0x75, 0xD2, 0x11 })
        var whitelistedCategoryies = new List<Category>() { Category.Video, Category.Audio };
        var isVideoOrAudio = stream.Is(whitelistedCategoryies); // false
        ```
     - `stream.Is(string)`: Checks by `string`. Matches if `Signature.Description` contains it.
        ```csharp
        var stream = new MemoryStream(new byte[] { 0xE3, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 })
        var isAmigaFile = stream.Is("Amiga"); // true
        ```
    There are also `Is()` overloads that works with `IFormFile` and take `Extension`(s), `Category`(s) or `string`(s) as parameters.

## Notes
- Files with no extension are represented as `Extension.None`.
- Extensions starting with a number are escaped with an underscore _ in `Extension` enum, since an enum member cannot start with a number. (_eg. Extension 3GP is represented as `Extension._3GP`_)
- `Category` relies on definition field in [filesignatures.net](https://filesignatures.net/) ([example, JPEG extension](https://filesignatures.net/index.php?search=JPEG&mode=EXT)). Until all extensions are processed and categorised manually, validating with this type might be deceiving. `Category.Video` will only filter the extensions with the word "video" in their descriptions.

## TODO
- Performance improvements
- Include other file signature databases
- Support for `File` type if requested
- Manual assigning of `Category`s
- More tests
- Better icon
