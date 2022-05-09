using System.Collections.Generic;
using System.Linq;

namespace SignHere.Database
{
    internal static class Vault
    {
        public static int MaxHeaderLength => Bank.Max(b => b.MagicBytes.Length);

        public static IEnumerable<Extension> FindExtensions(string searchText)
        {
            return Vault.Bank.FindAll(
                        b => b.Description.ToLower().Contains(
                            searchText.ToLower()
                            )
                        ).Select(b => b.Extension).Distinct();
        }

        public static Dictionary<Category, IEnumerable<Extension>> GetDictionary(Category category)
        {
            return new Dictionary<Category, IEnumerable<Extension>>
            {
                {
                    category,
                    FindExtensions(category.ToString())
                }
            };
        }

        internal static List<Signature> Bank = new List<Signature>()
        {
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x41, 0x43, 0x53, 0x44 },
                Description = "AOL parameter|info files"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x62, 0x70, 0x6C, 0x69, 0x73, 0x74 },
                Description = "Binary property list (plist)"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x00, 0x14, 0x00, 0x00, 0x01, 0x02 },
                Description = "BIOS details in RAM"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x30, 0x37, 0x30, 0x37, 0x30 },
                Description = "cpio archive"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x7F, 0x45, 0x4C, 0x46 },
                Description = "ELF executable"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0xA1, 0xB2, 0xCD, 0x34 },
                Description = "Extended tcpdump (libpcap) capture file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x04, 0x00, 0x00, 0x00 },
                Description = "INFO2 Windows recycle bin_1"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x05, 0x00, 0x00, 0x00 },
                Description = "INFO2 Windows recycle bin_2"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0xAC, 0xED },
                Description = "Java serialization data"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x4B, 0x57, 0x41, 0x4A, 0x88, 0xF0, 0x27, 0xD1 },
                Description = "KWAJ (compressed) file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0xCD, 0x20, 0xAA, 0xAA, 0x02, 0x00, 0x00, 0x00 },
                Description = "NAV quarantined virus file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x53, 0x5A, 0x20, 0x88, 0xF0, 0x27, 0x33, 0xD1 },
                Description = "QBASIC SZDD file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x6F, 0x3C },
                Description = "SMS text (SIM)"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x53, 0x5A, 0x44, 0x44, 0x88, 0xF0, 0x27, 0x33 },
                Description = "SZDD file format"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0xA1, 0xB2, 0xC3, 0xD4 },
                Description = "tcpdump (libpcap) capture file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x34, 0xCD, 0xB2, 0xA1 },
                Description = "Tcpdump capture file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0xEF, 0xBB, 0xBF },
                Description = "UTF8 file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0xFE, 0xFF },
                Description = "UTF-16|UCS-2 file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0xFF, 0xFE, 0x00, 0x00 },
                Description = "UTF-32|UCS-4 file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x62, 0x65, 0x67, 0x69, 0x6E },
                Description = "UUencoded file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0xD4, 0xC3, 0xB2, 0xA1 },
                Description = "WinDump (winpcap) capture file"
            },
            new Signature()
            {
                Extension = Extension.None,
                MagicBytes = new byte[] { 0x37, 0xE4, 0x53, 0x96, 0xC9, 0xDB, 0xD6, 0x07 },
                Description = "zisofs compressed file"
            },
            new Signature()
            {
                Extension = Extension._123,
                MagicBytes = new byte[] { 0x00, 0x00, 0x1A, 0x00, 0x05, 0x10, 0x04 },
                Description = "Lotus 1-2-3 (v9)"
            },
            new Signature()
            {
                Extension = Extension._386,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows virtual device drivers"
            },
            new Signature()
            {
                Extension = Extension._3GP,
                MagicBytes = new byte[] { 0x00, 0x00, 0x00, 0x14, 0x66, 0x74, 0x79, 0x70 },
                Description = "3GPP multimedia files"
            },
            new Signature()
            {
                Extension = Extension._3GP,
                MagicBytes = new byte[] { 0x00, 0x00, 0x00, 0x20, 0x66, 0x74, 0x79, 0x70 },
                Description = "3GPP2 multimedia files"
            },
            new Signature()
            {
                Extension = Extension._3GP5,
                MagicBytes = new byte[] { 0x00, 0x00, 0x00, 0x18, 0x66, 0x74, 0x79, 0x70 },
                Description = "MPEG-4 video files"
            },
            new Signature()
            {
                Extension = Extension._4XM,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "4X Movie video"
            },
            new Signature()
            {
                Extension = Extension._7Z,
                MagicBytes = new byte[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C },
                Description = "7-Zip compressed file"
            },
            new Signature()
            {
                Extension = Extension.ABA,
                MagicBytes = new byte[] { 0x00, 0x01, 0x42, 0x41 },
                Description = "Palm Address Book Archive"
            },
            new Signature()
            {
                Extension = Extension.ABD,
                MagicBytes = new byte[] { 0x51, 0x57, 0x20, 0x56, 0x65, 0x72, 0x2E, 0x20 },
                Description = "ABD | QSD Quicken data file"
            },
            new Signature()
            {
                Extension = Extension.ABI,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C, 0x49, 0x4E, 0x44, 0x45, 0x58 },
                Description = "AOL address book index"
            },
            new Signature()
            {
                Extension = Extension.ABI,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C },
                Description = "AOL config files"
            },
            new Signature()
            {
                Extension = Extension.ABY,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C, 0x44, 0x42 },
                Description = "AOL address book"
            },
            new Signature()
            {
                Extension = Extension.ABY,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C },
                Description = "AOL config files"
            },
            new Signature()
            {
                Extension = Extension.AC,
                MagicBytes = new byte[] { 0x72, 0x69, 0x66, 0x66 },
                Description = "Sonic Foundry Acid Music File"
            },
            new Signature()
            {
                Extension = Extension.ACCDB,
                MagicBytes = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x53, 0x74, 0x61, 0x6E, 0x64, 0x61, 0x72, 0x64, 0x20, 0x41, 0x43, 0x45, 0x20, 0x44, 0x42 },
                Description = "Microsoft Access 2007"
            },
            new Signature()
            {
                Extension = Extension.ACM,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "MS audio compression manager driver"
            },
            new Signature()
            {
                Extension = Extension.ACS,
                MagicBytes = new byte[] { 0xC3, 0xAB, 0xCD, 0xAB },
                Description = "MS Agent Character file"
            },
            new Signature()
            {
                Extension = Extension.AC_,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "CaseWare Working Papers"
            },
            new Signature()
            {
                Extension = Extension.AD,
                MagicBytes = new byte[] { 0x52, 0x45, 0x56, 0x4E, 0x55, 0x4D, 0x3A, 0x2C },
                Description = "Antenna data file"
            },
            new Signature()
            {
                Extension = Extension.ADF,
                MagicBytes = new byte[] { 0x44, 0x4F, 0x53 },
                Description = "Amiga disk file"
            },
            new Signature()
            {
                Extension = Extension.ADP,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Access project file"
            },
            new Signature()
            {
                Extension = Extension.ADX,
                MagicBytes = new byte[] { 0x03, 0x00, 0x00, 0x00, 0x41, 0x50, 0x50, 0x52 },
                Description = "Approach index file"
            },
            new Signature()
            {
                Extension = Extension.ADX,
                MagicBytes = new byte[] { 0x80, 0x00, 0x00, 0x20, 0x03, 0x12, 0x04 },
                Description = "Dreamcast audio"
            },
            new Signature()
            {
                Extension = Extension.AIFF,
                MagicBytes = new byte[] { 0x46, 0x4F, 0x52, 0x4D, 0x00 },
                Description = "Audio Interchange File"
            },
            new Signature()
            {
                Extension = Extension.AIN,
                MagicBytes = new byte[] { 0x21, 0x12 },
                Description = "AIN Compressed Archive"
            },
            new Signature()
            {
                Extension = Extension.AMR,
                MagicBytes = new byte[] { 0x23, 0x21, 0x41, 0x4D, 0x52 },
                Description = "Adaptive Multi-Rate ACELP Codec (GSM)"
            },
            new Signature()
            {
                Extension = Extension.ANI,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "Windows animated cursor"
            },
            new Signature()
            {
                Extension = Extension.API,
                MagicBytes = new byte[] { 0x4D, 0x5A, 0x90, 0x00, 0x03, 0x00, 0x00, 0x00 },
                Description = "Acrobat plug-in"
            },
            new Signature()
            {
                Extension = Extension.APR,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Lotus|IBM Approach 97 file"
            },
            new Signature()
            {
                Extension = Extension.ARC,
                MagicBytes = new byte[] { 0x41, 0x72, 0x43, 0x01 },
                Description = "FreeArc compressed file"
            },
            new Signature()
            {
                Extension = Extension.ARC,
                MagicBytes = new byte[] { 0x1A, 0x02 },
                Description = "LH archive (old vers.|type 1)"
            },
            new Signature()
            {
                Extension = Extension.ARC,
                MagicBytes = new byte[] { 0x1A, 0x03 },
                Description = "LH archive (old vers.|type 2)"
            },
            new Signature()
            {
                Extension = Extension.ARC,
                MagicBytes = new byte[] { 0x1A, 0x04 },
                Description = "LH archive (old vers.|type 3)"
            },
            new Signature()
            {
                Extension = Extension.ARC,
                MagicBytes = new byte[] { 0x1A, 0x08 },
                Description = "LH archive (old vers.|type 4)"
            },
            new Signature()
            {
                Extension = Extension.ARC,
                MagicBytes = new byte[] { 0x1A, 0x09 },
                Description = "LH archive (old vers.|type 5)"
            },
            new Signature()
            {
                Extension = Extension.ARJ,
                MagicBytes = new byte[] { 0x60, 0xEA },
                Description = "ARJ Compressed archive file"
            },
            new Signature()
            {
                Extension = Extension.ARL,
                MagicBytes = new byte[] { 0xD4, 0x2A },
                Description = "AOL history|typed URL files"
            },
            new Signature()
            {
                Extension = Extension.ASF,
                MagicBytes = new byte[] { 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11 },
                Description = "Windows Media Audio|Video File"
            },
            new Signature()
            {
                Extension = Extension.AST,
                MagicBytes = new byte[] { 0x53, 0x43, 0x48, 0x6C },
                Description = "Underground Audio"
            },
            new Signature()
            {
                Extension = Extension.ASX,
                MagicBytes = new byte[] { 0x3C },
                Description = "Advanced Stream Redirector"
            },
            new Signature()
            {
                Extension = Extension.AU,
                MagicBytes = new byte[] { 0x64, 0x6E, 0x73, 0x2E },
                Description = "Audacity audio file"
            },
            new Signature()
            {
                Extension = Extension.AU,
                MagicBytes = new byte[] { 0x2E, 0x73, 0x6E, 0x64 },
                Description = "NeXT|Sun Microsystems audio file"
            },
            new Signature()
            {
                Extension = Extension.AUT,
                MagicBytes = new byte[] { 0xD4, 0x2A },
                Description = "AOL history|typed URL files"
            },
            new Signature()
            {
                Extension = Extension.AVI,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "Resource Interchange File Format"
            },
            new Signature()
            {
                Extension = Extension.AW,
                MagicBytes = new byte[] { 0x8A, 0x01, 0x09, 0x00, 0x00, 0x00, 0xE1, 0x08 },
                Description = "MS Answer Wizard"
            },
            new Signature()
            {
                Extension = Extension.AX,
                MagicBytes = new byte[] { 0x4D, 0x5A, 0x90, 0x00, 0x03, 0x00, 0x00, 0x00 },
                Description = "DirectShow filter"
            },
            new Signature()
            {
                Extension = Extension.AX,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Library cache file"
            },
            new Signature()
            {
                Extension = Extension.BAG,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C, 0x20, 0x46, 0x65, 0x65, 0x64 },
                Description = "AOL and AIM buddy list"
            },
            new Signature()
            {
                Extension = Extension.BAG,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C },
                Description = "AOL config files"
            },
            new Signature()
            {
                Extension = Extension.BDR,
                MagicBytes = new byte[] { 0x58, 0x54 },
                Description = "MS Publisher"
            },
            new Signature()
            {
                Extension = Extension.BIN,
                MagicBytes = new byte[] { 0x42, 0x4C, 0x49, 0x32, 0x32, 0x33, 0x51 },
                Description = "Speedtouch router firmware"
            },
            new Signature()
            {
                Extension = Extension.BMP,
                MagicBytes = new byte[] { 0x42, 0x4D },
                Description = "Bitmap image"
            },
            new Signature()
            {
                Extension = Extension.BZ2,
                MagicBytes = new byte[] { 0x42, 0x5A, 0x68 },
                Description = "bzip2 compressed archive"
            },
            new Signature()
            {
                Extension = Extension.CAB,
                MagicBytes = new byte[] { 0x49, 0x53, 0x63, 0x28 },
                Description = "Install Shield compressed file"
            },
            new Signature()
            {
                Extension = Extension.CAB,
                MagicBytes = new byte[] { 0x4D, 0x53, 0x43, 0x46 },
                Description = "Microsoft cabinet file"
            },
            new Signature()
            {
                Extension = Extension.CAL,
                MagicBytes = new byte[] { 0x73, 0x72, 0x63, 0x64, 0x6F, 0x63, 0x69, 0x64 },
                Description = "CALS raster bitmap"
            },
            new Signature()
            {
                Extension = Extension.CAL,
                MagicBytes = new byte[] { 0x53, 0x75, 0x70, 0x65, 0x72, 0x43, 0x61, 0x6C },
                Description = "SuperCalc worksheet"
            },
            new Signature()
            {
                Extension = Extension.CAL,
                MagicBytes = new byte[] { 0xB5, 0xA2, 0xB0, 0xB3, 0xB3, 0xB0, 0xA5, 0xB5 },
                Description = "Windows calendar"
            },
            new Signature()
            {
                Extension = Extension.CAP,
                MagicBytes = new byte[] { 0x58, 0x43, 0x50, 0x00 },
                Description = "Packet sniffer files"
            },
            new Signature()
            {
                Extension = Extension.CAP,
                MagicBytes = new byte[] { 0x52, 0x54, 0x53, 0x53 },
                Description = "WinNT Netmon capture file"
            },
            new Signature()
            {
                Extension = Extension.CAS,
                MagicBytes = new byte[] { 0x5F, 0x43, 0x41, 0x53, 0x45, 0x5F },
                Description = "EnCase case file"
            },
            new Signature()
            {
                Extension = Extension.CAT,
                MagicBytes = new byte[] { 0x30 },
                Description = "MS security catalog file"
            },
            new Signature()
            {
                Extension = Extension.CBD,
                MagicBytes = new byte[] { 0x43, 0x42, 0x46, 0x49, 0x4C, 0x45 },
                Description = "WordPerfect dictionary"
            },
            new Signature()
            {
                Extension = Extension.CBK,
                MagicBytes = new byte[] { 0x5F, 0x43, 0x41, 0x53, 0x45, 0x5F },
                Description = "EnCase case file"
            },
            new Signature()
            {
                Extension = Extension.CDA,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "Resource Interchange File Format"
            },
            new Signature()
            {
                Extension = Extension.CDR,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "CorelDraw document"
            },
            new Signature()
            {
                Extension = Extension.CDR,
                MagicBytes = new byte[] { 0x45, 0x4C, 0x49, 0x54, 0x45, 0x20, 0x43, 0x6F },
                Description = "Elite Plus Commander game file"
            },
            new Signature()
            {
                Extension = Extension.CDR,
                MagicBytes = new byte[] { 0x4D, 0x53, 0x5F, 0x56, 0x4F, 0x49, 0x43, 0x45 },
                Description = "Sony Compressed Voice File"
            },
            new Signature()
            {
                Extension = Extension.CFG,
                MagicBytes = new byte[] { 0x5B, 0x66, 0x6C, 0x74, 0x73, 0x69, 0x6D, 0x2E },
                Description = "Flight Simulator Aircraft Configuration"
            },
            new Signature()
            {
                Extension = Extension.CHI,
                MagicBytes = new byte[] { 0x49, 0x54, 0x53, 0x46 },
                Description = "MS Compiled HTML Help File"
            },
            new Signature()
            {
                Extension = Extension.CHM,
                MagicBytes = new byte[] { 0x49, 0x54, 0x53, 0x46 },
                Description = "MS Compiled HTML Help File"
            },
            new Signature()
            {
                Extension = Extension.CLASS,
                MagicBytes = new byte[] { 0xCA, 0xFE, 0xBA, 0xBE },
                Description = "Java bytecode"
            },
            new Signature()
            {
                Extension = Extension.CLB,
                MagicBytes = new byte[] { 0x43, 0x4F, 0x4D, 0x2B },
                Description = "COM+ Catalog"
            },
            new Signature()
            {
                Extension = Extension.CLB,
                MagicBytes = new byte[] { 0x43, 0x4D, 0x58, 0x31 },
                Description = "Corel Binary metafile"
            },
            new Signature()
            {
                Extension = Extension.CMX,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "Corel Presentation Exchange metadata"
            },
            new Signature()
            {
                Extension = Extension.CNV,
                MagicBytes = new byte[] { 0x53, 0x51, 0x4C, 0x4F, 0x43, 0x4F, 0x4E, 0x56 },
                Description = "DB2 conversion file"
            },
            new Signature()
            {
                Extension = Extension.COD,
                MagicBytes = new byte[] { 0x4E, 0x61, 0x6D, 0x65, 0x3A, 0x20 },
                Description = "Agent newsreader character map"
            },
            new Signature()
            {
                Extension = Extension.COM,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows|DOS executable file"
            },
            new Signature()
            {
                Extension = Extension.COM,
                MagicBytes = new byte[] { 0xE8 },
                Description = "Windows executable file_1"
            },
            new Signature()
            {
                Extension = Extension.COM,
                MagicBytes = new byte[] { 0xE9 },
                Description = "Windows executable file_2"
            },
            new Signature()
            {
                Extension = Extension.COM,
                MagicBytes = new byte[] { 0xEB },
                Description = "Windows executable file_3"
            },
            new Signature()
            {
                Extension = Extension.CPE,
                MagicBytes = new byte[] { 0x46, 0x41, 0x58, 0x43, 0x4F, 0x56, 0x45, 0x52 },
                Description = "MS Fax Cover Sheet"
            },
            new Signature()
            {
                Extension = Extension.CPI,
                MagicBytes = new byte[] { 0x53, 0x49, 0x45, 0x54, 0x52, 0x4F, 0x4E, 0x49 },
                Description = "Sietronics CPI XRD document"
            },
            new Signature()
            {
                Extension = Extension.CPI,
                MagicBytes = new byte[] { 0xFF, 0x46, 0x4F, 0x4E, 0x54 },
                Description = "Windows international code page"
            },
            new Signature()
            {
                Extension = Extension.CPL,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Control panel application"
            },
            new Signature()
            {
                Extension = Extension.CPL,
                MagicBytes = new byte[] { 0xDC, 0xDC },
                Description = "Corel color palette"
            },
            new Signature()
            {
                Extension = Extension.CPT,
                MagicBytes = new byte[] { 0x43, 0x50, 0x54, 0x37, 0x46, 0x49, 0x4C, 0x45 },
                Description = "Corel Photopaint file_1"
            },
            new Signature()
            {
                Extension = Extension.CPT,
                MagicBytes = new byte[] { 0x43, 0x50, 0x54, 0x46, 0x49, 0x4C, 0x45 },
                Description = "Corel Photopaint file_2"
            },
            new Signature()
            {
                Extension = Extension.CPX,
                MagicBytes = new byte[] { 0x5B, 0x57, 0x69, 0x6E, 0x64, 0x6F, 0x77, 0x73 },
                Description = "Microsoft Code Page Translation file"
            },
            new Signature()
            {
                Extension = Extension.CRU,
                MagicBytes = new byte[] { 0x43, 0x52, 0x55, 0x53, 0x48, 0x20, 0x76 },
                Description = "Crush compressed archive"
            },
            new Signature()
            {
                Extension = Extension.CRW,
                MagicBytes = new byte[] { 0x49, 0x49, 0x1A, 0x00, 0x00, 0x00, 0x48, 0x45 },
                Description = "Canon RAW file"
            },
            new Signature()
            {
                Extension = Extension.CSH,
                MagicBytes = new byte[] { 0x63, 0x75, 0x73, 0x68, 0x00, 0x00, 0x00, 0x02 },
                Description = "Photoshop Custom Shape"
            },
            new Signature()
            {
                Extension = Extension.CTF,
                MagicBytes = new byte[] { 0x43, 0x61, 0x74, 0x61, 0x6C, 0x6F, 0x67, 0x20 },
                Description = "WhereIsIt Catalog"
            },
            new Signature()
            {
                Extension = Extension.CTL,
                MagicBytes = new byte[] { 0x56, 0x45, 0x52, 0x53, 0x49, 0x4F, 0x4E, 0x20 },
                Description = "Visual Basic User-defined Control file"
            },
            new Signature()
            {
                Extension = Extension.CUIX,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "Customization files"
            },
            new Signature()
            {
                Extension = Extension.CUR,
                MagicBytes = new byte[] { 0x00, 0x00, 0x02, 0x00 },
                Description = "Windows cursor"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "Video CD MPEG movie"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0xA9, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                Description = "Access Data FTK evidence"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x73, 0x6C, 0x68, 0x21 },
                Description = "Allegro Generic Packfile (compressed)"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x73, 0x6C, 0x68, 0x2E },
                Description = "Allegro Generic Packfile (uncompressed)"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x41, 0x56, 0x47, 0x36, 0x5F, 0x49, 0x6E, 0x74 },
                Description = "AVG6 Integrity database"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x03 },
                Description = "MapInfo Native Data Format"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x45, 0x52, 0x46, 0x53, 0x53, 0x41, 0x56, 0x45 },
                Description = "EasyRecovery Saved State file"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x43, 0x6C, 0x69, 0x65, 0x6E, 0x74, 0x20, 0x55 },
                Description = "IE History file"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x49, 0x6E, 0x6E, 0x6F, 0x20, 0x53, 0x65, 0x74 },
                Description = "Inno Setup Uninstall Log"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x50, 0x4E, 0x43, 0x49, 0x55, 0x4E, 0x44, 0x4F },
                Description = "Norton Disk Doctor undo file"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x50, 0x45, 0x53, 0x54 },
                Description = "PestPatrol data|scan strings"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x1A, 0x52, 0x54, 0x53, 0x20, 0x43, 0x4F, 0x4D },
                Description = "Runtime Software disk image"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x52, 0x41, 0x5A, 0x41, 0x54, 0x44, 0x42, 0x31 },
                Description = "Shareaza (P2P) thumbnail"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x4E, 0x41, 0x56, 0x54, 0x52, 0x41, 0x46, 0x46 },
                Description = "TomTom traffic data"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x55, 0x46, 0x4F, 0x4F, 0x72, 0x62, 0x69, 0x74 },
                Description = "UFO Capture map file"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x57, 0x4D, 0x4D, 0x50 },
                Description = "Walkman MP3 file"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x43, 0x52, 0x45, 0x47 },
                Description = "Win9x registry hive"
            },
            new Signature()
            {
                Extension = Extension.DAT,
                MagicBytes = new byte[] { 0x72, 0x65, 0x67, 0x66 },
                Description = "WinNT registry file"
            },
            new Signature()
            {
                Extension = Extension.DB,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "MSWorks database file"
            },
            new Signature()
            {
                Extension = Extension.DB,
                MagicBytes = new byte[] { 0x08 },
                Description = "dBASE IV or dBFast configuration file"
            },
            new Signature()
            {
                Extension = Extension.DB,
                MagicBytes = new byte[] { 0x00, 0x06, 0x15, 0x61, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x04, 0xD2, 0x00, 0x00, 0x10, 0x00 },
                Description = "Netscape Navigator (v4) database"
            },
            new Signature()
            {
                Extension = Extension.DB,
                MagicBytes = new byte[] { 0x44, 0x42, 0x46, 0x48 },
                Description = "Palm Zire photo database"
            },
            new Signature()
            {
                Extension = Extension.DB,
                MagicBytes = new byte[] { 0x53, 0x51, 0x4C, 0x69, 0x74, 0x65, 0x20, 0x66, 0x6F, 0x72, 0x6D, 0x61, 0x74, 0x20, 0x33, 0x00 },
                Description = "SQLite database file"
            },
            new Signature()
            {
                Extension = Extension.DB,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF },
                Description = "Thumbs.db subheader"
            },
            new Signature()
            {
                Extension = Extension.DB3,
                MagicBytes = new byte[] { 0x03 },
                Description = "dBASE III file"
            },
            new Signature()
            {
                Extension = Extension.DB4,
                MagicBytes = new byte[] { 0x04 },
                Description = "dBASE IV file"
            },
            new Signature()
            {
                Extension = Extension.DBA,
                MagicBytes = new byte[] { 0x00, 0x01, 0x42, 0x44 },
                Description = "Palm DateBook Archive"
            },
            new Signature()
            {
                Extension = Extension.DBB,
                MagicBytes = new byte[] { 0x6C, 0x33, 0x33, 0x6C },
                Description = "Skype user data file"
            },
            new Signature()
            {
                Extension = Extension.DBF,
                MagicBytes = new byte[] { 0x4F, 0x50, 0x4C, 0x44, 0x61, 0x74, 0x61, 0x62 },
                Description = "Psion Series 3 Database"
            },
            new Signature()
            {
                Extension = Extension.DBX,
                MagicBytes = new byte[] { 0xCF, 0xAD, 0x12, 0xFE },
                Description = "Outlook Express e-mail folder"
            },
            new Signature()
            {
                Extension = Extension.DCI,
                MagicBytes = new byte[] { 0x3C, 0x21, 0x64, 0x6F, 0x63, 0x74, 0x79, 0x70 },
                Description = "AOL HTML mail"
            },
            new Signature()
            {
                Extension = Extension.DCX,
                MagicBytes = new byte[] { 0xB1, 0x68, 0xDE, 0x3A },
                Description = "PCX bitmap"
            },
            new Signature()
            {
                Extension = Extension.dex,
                MagicBytes = new byte[] { 0x64, 0x65, 0x78, 0x0A, 0x30, 0x30, 0x39, 0x00 },
                Description = "Dalvik (Android) executable file"
            },
            new Signature()
            {
                Extension = Extension.DIB,
                MagicBytes = new byte[] { 0x42, 0x4D },
                Description = "Bitmap image"
            },
            new Signature()
            {
                Extension = Extension.DLL,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows|DOS executable file"
            },
            new Signature()
            {
                Extension = Extension.DMG,
                MagicBytes = new byte[] { 0x78 },
                Description = "MacOS X image file"
            },
            new Signature()
            {
                Extension = Extension.DMP,
                MagicBytes = new byte[] { 0x4D, 0x44, 0x4D, 0x50, 0x93, 0xA7 },
                Description = "Windows dump file"
            },
            new Signature()
            {
                Extension = Extension.DMP,
                MagicBytes = new byte[] { 0x50, 0x41, 0x47, 0x45, 0x44, 0x55 },
                Description = "Windows memory dump"
            },
            new Signature()
            {
                Extension = Extension.DMS,
                MagicBytes = new byte[] { 0x44, 0x4D, 0x53, 0x21 },
                Description = "Amiga DiskMasher compressed archive"
            },
            new Signature()
            {
                Extension = Extension.DOC,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Microsoft Office document"
            },
            new Signature()
            {
                Extension = Extension.DOC,
                MagicBytes = new byte[] { 0x0D, 0x44, 0x4F, 0x43 },
                Description = "DeskMate Document"
            },
            new Signature()
            {
                Extension = Extension.DOC,
                MagicBytes = new byte[] { 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1, 0x00 },
                Description = "Perfect Office document"
            },
            new Signature()
            {
                Extension = Extension.DOC,
                MagicBytes = new byte[] { 0xDB, 0xA5, 0x2D, 0x00 },
                Description = "Word 2.0 file"
            },
            new Signature()
            {
                Extension = Extension.DOC,
                MagicBytes = new byte[] { 0xEC, 0xA5, 0xC1, 0x00 },
                Description = "Word document subheader"
            },
            new Signature()
            {
                Extension = Extension.DOCX,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "MS Office Open XML Format Document"
            },
            new Signature()
            {
                Extension = Extension.DOCX,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 },
                Description = "MS Office 2007 documents"
            },
            new Signature()
            {
                Extension = Extension.DOT,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Microsoft Office document"
            },
            new Signature()
            {
                Extension = Extension.DRV,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows|DOS executable file"
            },
            new Signature()
            {
                Extension = Extension.DRW,
                MagicBytes = new byte[] { 0x07 },
                Description = "Generic drawing programs"
            },
            new Signature()
            {
                Extension = Extension.DRW,
                MagicBytes = new byte[] { 0x01, 0xFF, 0x02, 0x04, 0x03, 0x02 },
                Description = "Micrografx vector graphic file"
            },
            new Signature()
            {
                Extension = Extension.DS4,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "Micrografx Designer graphic"
            },
            new Signature()
            {
                Extension = Extension.DSN,
                MagicBytes = new byte[] { 0x4D, 0x56 },
                Description = "CD Stomper Pro label file"
            },
            new Signature()
            {
                Extension = Extension.DSP,
                MagicBytes = new byte[] { 0x23, 0x20, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73 },
                Description = "MS Developer Studio project file"
            },
            new Signature()
            {
                Extension = Extension.DSS,
                MagicBytes = new byte[] { 0x02, 0x64, 0x73, 0x73 },
                Description = "Digital Speech Standard file"
            },
            new Signature()
            {
                Extension = Extension.DSW,
                MagicBytes = new byte[] { 0x64, 0x73, 0x77, 0x66, 0x69, 0x6C, 0x65 },
                Description = "MS Visual Studio workspace file"
            },
            new Signature()
            {
                Extension = Extension.DTD,
                MagicBytes = new byte[] { 0x07, 0x64, 0x74, 0x32, 0x64, 0x64, 0x74, 0x64 },
                Description = "DesignTools 2D Design file"
            },
            new Signature()
            {
                Extension = Extension.DUN,
                MagicBytes = new byte[] { 0x5B, 0x50, 0x68, 0x6F, 0x6E, 0x65, 0x5D },
                Description = "Dial-up networking file"
            },
            new Signature()
            {
                Extension = Extension.DVF,
                MagicBytes = new byte[] { 0x4D, 0x53, 0x5F, 0x56, 0x4F, 0x49, 0x43, 0x45 },
                Description = "Sony Compressed Voice File"
            },
            new Signature()
            {
                Extension = Extension.DVR,
                MagicBytes = new byte[] { 0x44, 0x56, 0x44 },
                Description = "DVR-Studio stream file"
            },
            new Signature()
            {
                Extension = Extension.DW4,
                MagicBytes = new byte[] { 0x4F, 0x7B },
                Description = "Visio|DisplayWrite 4 text file"
            },
            new Signature()
            {
                Extension = Extension.DWG,
                MagicBytes = new byte[] { 0x41, 0x43, 0x31, 0x30 },
                Description = "Generic AutoCAD drawing"
            },
            new Signature()
            {
                Extension = Extension.E01,
                MagicBytes = new byte[] { 0x45, 0x56, 0x46, 0x09, 0x0D, 0x0A, 0xFF, 0x00 },
                Description = "Expert Witness Compression Format"
            },
            new Signature()
            {
                Extension = Extension.E01,
                MagicBytes = new byte[] { 0x4C, 0x56, 0x46, 0x09, 0x0D, 0x0A, 0xFF, 0x00 },
                Description = "Logical File Evidence Format"
            },
            new Signature()
            {
                Extension = Extension.ECF,
                MagicBytes = new byte[] { 0x5B, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x61, 0x6C },
                Description = "MS Exchange configuration file"
            },
            new Signature()
            {
                Extension = Extension.EFX,
                MagicBytes = new byte[] { 0xDC, 0xFE },
                Description = "eFax file"
            },
            new Signature()
            {
                Extension = Extension.EML,
                MagicBytes = new byte[] { 0x58, 0x2D },
                Description = "Exchange e-mail"
            },
            new Signature()
            {
                Extension = Extension.EML,
                MagicBytes = new byte[] { 0x52, 0x65, 0x74, 0x75, 0x72, 0x6E, 0x2D, 0x50 },
                Description = "Generic e-mail_1"
            },
            new Signature()
            {
                Extension = Extension.EML,
                MagicBytes = new byte[] { 0x46, 0x72, 0x6F, 0x6D },
                Description = "Generic e-mail_2"
            },
            new Signature()
            {
                Extension = Extension.ENL,
                MagicBytes = new byte[] { 0x40, 0x40, 0x40, 0x20, 0x00, 0x00, 0x40, 0x40, 0x40, 0x40 },
                Description = "EndNote Library File"
            },
            new Signature()
            {
                Extension = Extension.EPS,
                MagicBytes = new byte[] { 0xC5, 0xD0, 0xD3, 0xC6 },
                Description = "Adobe encapsulated PostScript"
            },
            new Signature()
            {
                Extension = Extension.EPS,
                MagicBytes = new byte[] { 0x25, 0x21, 0x50, 0x53, 0x2D, 0x41, 0x64, 0x6F },
                Description = "Encapsulated PostScript file"
            },
            new Signature()
            {
                Extension = Extension.ETH,
                MagicBytes = new byte[] { 0x1A, 0x35, 0x01, 0x00 },
                Description = "WinPharoah capture file"
            },
            new Signature()
            {
                Extension = Extension.EVT,
                MagicBytes = new byte[] { 0x30, 0x00, 0x00, 0x00, 0x4C, 0x66, 0x4C, 0x65 },
                Description = "Windows Event Viewer file"
            },
            new Signature()
            {
                Extension = Extension.EVTX,
                MagicBytes = new byte[] { 0x45, 0x6C, 0x66, 0x46, 0x69, 0x6C, 0x65, 0x00 },
                Description = "Windows Vista event log"
            },
            new Signature()
            {
                Extension = Extension.EXE,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows|DOS executable file"
            },
            new Signature()
            {
                Extension = Extension.FDF,
                MagicBytes = new byte[] { 0x25, 0x50, 0x44, 0x46 },
                Description = "PDF file"
            },
            new Signature()
            {
                Extension = Extension.FLAC,
                MagicBytes = new byte[] { 0x66, 0x4C, 0x61, 0x43, 0x00, 0x00, 0x00, 0x22 },
                Description = "Free Lossless Audio Codec file"
            },
            new Signature()
            {
                Extension = Extension.FLI,
                MagicBytes = new byte[] { 0x00, 0x11 },
                Description = "FLIC animation"
            },
            new Signature()
            {
                Extension = Extension.FLT,
                MagicBytes = new byte[] { 0x4D, 0x5A, 0x90, 0x00, 0x03, 0x00, 0x00, 0x00 },
                Description = "Audition graphic filter"
            },
            new Signature()
            {
                Extension = Extension.FLT,
                MagicBytes = new byte[] { 0x76, 0x32, 0x30, 0x30, 0x33, 0x2E, 0x31, 0x30 },
                Description = "Qimage filter"
            },
            new Signature()
            {
                Extension = Extension.FLV,
                MagicBytes = new byte[] { 0x46, 0x4C, 0x56 },
                Description = "Flash video file"
            },
            new Signature()
            {
                Extension = Extension.FM,
                MagicBytes = new byte[] { 0x3C, 0x4D, 0x61, 0x6B, 0x65, 0x72, 0x46, 0x69 },
                Description = "Adobe FrameMaker"
            },
            new Signature()
            {
                Extension = Extension.FON,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Font file"
            },
            new Signature()
            {
                Extension = Extension.FTR,
                MagicBytes = new byte[] { 0xD2, 0x0A, 0x00, 0x00 },
                Description = "WinPharoah filter file"
            },
            new Signature()
            {
                Extension = Extension.GHO,
                MagicBytes = new byte[] { 0xFE, 0xEF },
                Description = "Symantex Ghost image file"
            },
            new Signature()
            {
                Extension = Extension.GHS,
                MagicBytes = new byte[] { 0xFE, 0xEF },
                Description = "Symantex Ghost image file"
            },
            new Signature()
            {
                Extension = Extension.GID,
                MagicBytes = new byte[] { 0x3F, 0x5F, 0x03, 0x00 },
                Description = "Windows Help file_2"
            },
            new Signature()
            {
                Extension = Extension.GID,
                MagicBytes = new byte[] { 0x4C, 0x4E, 0x02, 0x00 },
                Description = "Windows help file_3"
            },
            new Signature()
            {
                Extension = Extension.GIF,
                MagicBytes = new byte[] { 0x47, 0x49, 0x46, 0x38 },
                Description = "GIF file"
            },
            new Signature()
            {
                Extension = Extension.GPG,
                MagicBytes = new byte[] { 0x99 },
                Description = "GPG public keyring"
            },
            new Signature()
            {
                Extension = Extension.GRP,
                MagicBytes = new byte[] { 0x50, 0x4D, 0x43, 0x43 },
                Description = "Windows Program Manager group file"
            },
            new Signature()
            {
                Extension = Extension.GX2,
                MagicBytes = new byte[] { 0x47, 0x58, 0x32 },
                Description = "Show Partner graphics file"
            },
            new Signature()
            {
                Extension = Extension.GZ,
                MagicBytes = new byte[] { 0x1F, 0x8B, 0x08 },
                Description = "GZIP archive file"
            },
            new Signature()
            {
                Extension = Extension.HAP,
                MagicBytes = new byte[] { 0x91, 0x33, 0x48, 0x46 },
                Description = "Hamarsoft compressed archive"
            },
            new Signature()
            {
                Extension = Extension.HDMP,
                MagicBytes = new byte[] { 0x4D, 0x44, 0x4D, 0x50, 0x93, 0xA7 },
                Description = "Windows dump file"
            },
            new Signature()
            {
                Extension = Extension.HDR,
                MagicBytes = new byte[] { 0x49, 0x53, 0x63, 0x28 },
                Description = "Install Shield compressed file"
            },
            new Signature()
            {
                Extension = Extension.HDR,
                MagicBytes = new byte[] { 0x23, 0x3F, 0x52, 0x41, 0x44, 0x49, 0x41, 0x4E },
                Description = "Radiance High Dynamic Range image file"
            },
            new Signature()
            {
                Extension = Extension.hip,
                MagicBytes = new byte[] { 0x48, 0x69, 0x50, 0x21 },
                Description = "Houdini image file. Three-dimensional modeling and animation"
            },
            new Signature()
            {
                Extension = Extension.HLP,
                MagicBytes = new byte[] { 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF },
                Description = "Windows Help file_1"
            },
            new Signature()
            {
                Extension = Extension.HLP,
                MagicBytes = new byte[] { 0x3F, 0x5F, 0x03, 0x00 },
                Description = "Windows Help file_2"
            },
            new Signature()
            {
                Extension = Extension.HLP,
                MagicBytes = new byte[] { 0x4C, 0x4E, 0x02, 0x00 },
                Description = "Windows help file_3"
            },
            new Signature()
            {
                Extension = Extension.HQX,
                MagicBytes = new byte[] { 0x28, 0x54, 0x68, 0x69, 0x73, 0x20, 0x66, 0x69 },
                Description = "BinHex 4 Compressed Archive"
            },
            new Signature()
            {
                Extension = Extension.ICO,
                MagicBytes = new byte[] { 0x00, 0x00, 0x01, 0x00 },
                Description = "Windows icon|printer spool file"
            },
            new Signature()
            {
                Extension = Extension.IDX,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C, 0x44, 0x42 },
                Description = "AOL user configuration"
            },
            new Signature()
            {
                Extension = Extension.IDX,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C },
                Description = "AOL config files"
            },
            new Signature()
            {
                Extension = Extension.IDX,
                MagicBytes = new byte[] { 0x50, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00 },
                Description = "Quicken QuickFinder Information File"
            },
            new Signature()
            {
                Extension = Extension.IFO,
                MagicBytes = new byte[] { 0x44, 0x56, 0x44 },
                Description = "DVD info file"
            },
            new Signature()
            {
                Extension = Extension.IMG,
                MagicBytes = new byte[] { 0x50, 0x49, 0x43, 0x54, 0x00, 0x08 },
                Description = "ChromaGraph Graphics Card Bitmap"
            },
            new Signature()
            {
                Extension = Extension.IMG,
                MagicBytes = new byte[] { 0xEB, 0x3C, 0x90, 0x2A },
                Description = "GEM Raster file"
            },
            new Signature()
            {
                Extension = Extension.IMG,
                MagicBytes = new byte[] { 0x53, 0x43, 0x4D, 0x49 },
                Description = "Img Software Bitmap"
            },
            new Signature()
            {
                Extension = Extension.IND,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C, 0x49, 0x44, 0x58 },
                Description = "AOL client preferences|settings file"
            },
            new Signature()
            {
                Extension = Extension.IND,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C },
                Description = "AOL config files"
            },
            new Signature()
            {
                Extension = Extension.INFO,
                MagicBytes = new byte[] { 0xE3, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 },
                Description = "Amiga icon"
            },
            new Signature()
            {
                Extension = Extension.INFO,
                MagicBytes = new byte[] { 0x54, 0x68, 0x69, 0x73, 0x20, 0x69, 0x73, 0x20 },
                Description = "GNU Info Reader file"
            },
            new Signature()
            {
                Extension = Extension.INFO,
                MagicBytes = new byte[] { 0x7A, 0x62, 0x65, 0x78 },
                Description = "ZoomBrowser Image Index"
            },
            new Signature()
            {
                Extension = Extension.ISO,
                MagicBytes = new byte[] { 0x43, 0x44, 0x30, 0x30, 0x31 },
                Description = "ISO-9660 CD Disc Image"
            },
            new Signature()
            {
                Extension = Extension.IVR,
                MagicBytes = new byte[] { 0x2E, 0x52, 0x45, 0x43 },
                Description = "RealPlayer video file (V11+)"
            },
            new Signature()
            {
                Extension = Extension.JAR,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "Java archive_1"
            },
            new Signature()
            {
                Extension = Extension.JAR,
                MagicBytes = new byte[] { 0x5F, 0x27, 0xA8, 0x89 },
                Description = "Jar archive"
            },
            new Signature()
            {
                Extension = Extension.JAR,
                MagicBytes = new byte[] { 0x4A, 0x41, 0x52, 0x43, 0x53, 0x00 },
                Description = "JARCS compressed archive"
            },
            new Signature()
            {
                Extension = Extension.JAR,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x08, 0x00 },
                Description = "Java archive_2"
            },
            new Signature()
            {
                Extension = Extension.JFIF,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                Description = "JPEG IMAGE"
            },
            new Signature()
            {
                Extension = Extension.JFIF,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                Description = "JFIF IMAGE FILE - jpeg"
            },
            new Signature()
            {
                Extension = Extension.JG,
                MagicBytes = new byte[] { 0x4A, 0x47, 0x03, 0x0E },
                Description = "AOL ART file_1"
            },
            new Signature()
            {
                Extension = Extension.JG,
                MagicBytes = new byte[] { 0x4A, 0x47, 0x04, 0x0E },
                Description = "AOL ART file_2"
            },
            new Signature()
            {
                Extension = Extension.JNT,
                MagicBytes = new byte[] { 0x4E, 0x42, 0x2A, 0x00 },
                Description = "MS Windows journal"
            },
            new Signature()
            {
                Extension = Extension.JP2,
                MagicBytes = new byte[] { 0x00, 0x00, 0x00, 0x0C, 0x6A, 0x50, 0x20, 0x20 },
                Description = "JPEG2000 image files"
            },
            new Signature()
            {
                Extension = Extension.JPE,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                Description = "JPEG IMAGE"
            },
            new Signature()
            {
                Extension = Extension.JPE,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                Description = "JPE IMAGE FILE - jpeg"
            },
            new Signature()
            {
                Extension = Extension.JPEG,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                Description = "JPEG IMAGE"
            },
            new Signature()
            {
                Extension = Extension.JPEG,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                Description = "CANNON EOS JPEG FILE"
            },
            new Signature()
            {
                Extension = Extension.JPEG,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                Description = "SAMSUNG D500 JPEG FILE"
            },
            new Signature()
            {
                Extension = Extension.JPG,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                Description = "JPEG IMAGE"
            },
            new Signature()
            {
                Extension = Extension.JPG,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                Description = "Digital camera JPG using Exchangeable Image File Format (EXIF)"
            },
            new Signature()
            {
                Extension = Extension.JPG,
                MagicBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                Description = "Still Picture Interchange File Format (SPIFF)"
            },
            new Signature()
            {
                Extension = Extension.JTP,
                MagicBytes = new byte[] { 0x4E, 0x42, 0x2A, 0x00 },
                Description = "MS Windows journal"
            },
            new Signature()
            {
                Extension = Extension.KGB,
                MagicBytes = new byte[] { 0x4B, 0x47, 0x42, 0x5F, 0x61, 0x72, 0x63, 0x68 },
                Description = "KGB archive"
            },
            new Signature()
            {
                Extension = Extension.KOZ,
                MagicBytes = new byte[] { 0x49, 0x44, 0x33, 0x03, 0x00, 0x00, 0x00 },
                Description = "Sprint Music Store audio"
            },
            new Signature()
            {
                Extension = Extension.KWD,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "KWord document"
            },
            new Signature()
            {
                Extension = Extension.LBK,
                MagicBytes = new byte[] { 0xC8, 0x00, 0x79, 0x00 },
                Description = "Jeppesen FliteLog file"
            },
            new Signature()
            {
                Extension = Extension.LGC,
                MagicBytes = new byte[] { 0x7B, 0x0D, 0x0A, 0x6F, 0x20 },
                Description = "Windows application log"
            },
            new Signature()
            {
                Extension = Extension.LGD,
                MagicBytes = new byte[] { 0x7B, 0x0D, 0x0A, 0x6F, 0x20 },
                Description = "Windows application log"
            },
            new Signature()
            {
                Extension = Extension.LHA,
                MagicBytes = new byte[] { 0x2D, 0x6C, 0x68 },
                Description = "Compressed archive"
            },
            new Signature()
            {
                Extension = Extension.LIB,
                MagicBytes = new byte[] { 0x21, 0x3C, 0x61, 0x72, 0x63, 0x68, 0x3E, 0x0A },
                Description = "Unix archiver (ar)|MS Program Library Common Object File Format (COFF)"
            },
            new Signature()
            {
                Extension = Extension.LIT,
                MagicBytes = new byte[] { 0x49, 0x54, 0x4F, 0x4C, 0x49, 0x54, 0x4C, 0x53 },
                Description = "MS Reader eBook"
            },
            new Signature()
            {
                Extension = Extension.LNK,
                MagicBytes = new byte[] { 0x4C, 0x00, 0x00, 0x00, 0x01, 0x14, 0x02, 0x00 },
                Description = "Windows shortcut file"
            },
            new Signature()
            {
                Extension = Extension.LOG,
                MagicBytes = new byte[] { 0x2A, 0x2A, 0x2A, 0x20, 0x20, 0x49, 0x6E, 0x73 },
                Description = "Symantec Wise Installer log"
            },
            new Signature()
            {
                Extension = Extension.LWP,
                MagicBytes = new byte[] { 0x57, 0x6F, 0x72, 0x64, 0x50, 0x72, 0x6F },
                Description = "Lotus WordPro file"
            },
            new Signature()
            {
                Extension = Extension.LZH,
                MagicBytes = new byte[] { 0x2D, 0x6C, 0x68 },
                Description = "Compressed archive"
            },
            new Signature()
            {
                Extension = Extension.M4A,
                MagicBytes = new byte[] { 0x00, 0x00, 0x00, 0x20, 0x66, 0x74, 0x79, 0x70, 0x4D, 0x34, 0x41 },
                Description = "Apple audio and video files"
            },
            new Signature()
            {
                Extension = Extension.MANIFEST,
                MagicBytes = new byte[] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20, 0x76, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D },
                Description = "Windows Visual Stylesheet"
            },
            new Signature()
            {
                Extension = Extension.MAR,
                MagicBytes = new byte[] { 0x4D, 0x41, 0x72, 0x30, 0x00 },
                Description = "MAr compressed archive"
            },
            new Signature()
            {
                Extension = Extension.MAR,
                MagicBytes = new byte[] { 0x4D, 0x41, 0x52, 0x43 },
                Description = "Microsoft|MSN MARC archive"
            },
            new Signature()
            {
                Extension = Extension.MAR,
                MagicBytes = new byte[] { 0x4D, 0x41, 0x52, 0x31, 0x00 },
                Description = "Mozilla archive"
            },
            new Signature()
            {
                Extension = Extension.MDB,
                MagicBytes = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x53, 0x74, 0x61, 0x6E, 0x64, 0x61, 0x72, 0x64, 0x20, 0x4A, 0x65, 0x74, 0x20, 0x44, 0x42 },
                Description = "Microsoft Access"
            },
            new Signature()
            {
                Extension = Extension.MDF,
                MagicBytes = new byte[] { 0x01, 0x0F, 0x00, 0x00 },
                Description = "SQL Data Base"
            },
            new Signature()
            {
                Extension = Extension.MDI,
                MagicBytes = new byte[] { 0x45, 0x50 },
                Description = "MS Document Imaging file"
            },
            new Signature()
            {
                Extension = Extension.MID,
                MagicBytes = new byte[] { 0x4D, 0x54, 0x68, 0x64 },
                Description = "MIDI sound file"
            },
            new Signature()
            {
                Extension = Extension.MIDI,
                MagicBytes = new byte[] { 0x4D, 0x54, 0x68, 0x64 },
                Description = "MIDI sound file"
            },
            new Signature()
            {
                Extension = Extension.MIF,
                MagicBytes = new byte[] { 0x3C, 0x4D, 0x61, 0x6B, 0x65, 0x72, 0x46, 0x69 },
                Description = "Adobe FrameMaker"
            },
            new Signature()
            {
                Extension = Extension.MIF,
                MagicBytes = new byte[] { 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x20 },
                Description = "MapInfo Interchange Format file"
            },
            new Signature()
            {
                Extension = Extension.MKV,
                MagicBytes = new byte[] { 0x1A, 0x45, 0xDF, 0xA3, 0x93, 0x42, 0x82, 0x88 },
                Description = "Matroska stream file"
            },
            new Signature()
            {
                Extension = Extension.MLS,
                MagicBytes = new byte[] { 0x4D, 0x49, 0x4C, 0x45, 0x53 },
                Description = "Milestones project management file"
            },
            new Signature()
            {
                Extension = Extension.MLS,
                MagicBytes = new byte[] { 0x4D, 0x56, 0x32, 0x31, 0x34 },
                Description = "Milestones project management file_1"
            },
            new Signature()
            {
                Extension = Extension.MLS,
                MagicBytes = new byte[] { 0x4D, 0x56, 0x32, 0x43 },
                Description = "Milestones project management file_2"
            },
            new Signature()
            {
                Extension = Extension.MLS,
                MagicBytes = new byte[] { 0x4D, 0x4C, 0x53, 0x57 },
                Description = "Skype localization data file"
            },
            new Signature()
            {
                Extension = Extension.MMF,
                MagicBytes = new byte[] { 0x4D, 0x4D, 0x4D, 0x44, 0x00, 0x00 },
                Description = "Yamaha Synthetic music Mobile Application Format"
            },
            new Signature()
            {
                Extension = Extension.MNY,
                MagicBytes = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x4D, 0x53, 0x49, 0x53, 0x41, 0x4D, 0x20, 0x44, 0x61, 0x74, 0x61, 0x62, 0x61, 0x73, 0x65 },
                Description = "Microsoft Money file"
            },
            new Signature()
            {
                Extension = Extension.MOF,
                MagicBytes = new byte[] { 0xFF, 0xFE, 0x23, 0x00, 0x6C, 0x00, 0x69, 0x00 },
                Description = "MSinfo file"
            },
            new Signature()
            {
                Extension = Extension.MOV,
                MagicBytes = new byte[] { 0x6D, 0x6F, 0x6F, 0x76 },
                Description = "QuickTime movie_1"
            },
            new Signature()
            {
                Extension = Extension.MOV,
                MagicBytes = new byte[] { 0x66, 0x72, 0x65, 0x65 },
                Description = "QuickTime movie_2"
            },
            new Signature()
            {
                Extension = Extension.MOV,
                MagicBytes = new byte[] { 0x6D, 0x64, 0x61, 0x74 },
                Description = "QuickTime movie_3"
            },
            new Signature()
            {
                Extension = Extension.MOV,
                MagicBytes = new byte[] { 0x77, 0x69, 0x64, 0x65 },
                Description = "QuickTime movie_4"
            },
            new Signature()
            {
                Extension = Extension.MOV,
                MagicBytes = new byte[] { 0x70, 0x6E, 0x6F, 0x74 },
                Description = "QuickTime movie_5"
            },
            new Signature()
            {
                Extension = Extension.MOV,
                MagicBytes = new byte[] { 0x73, 0x6B, 0x69, 0x70 },
                Description = "QuickTime movie_6"
            },
            new Signature()
            {
                Extension = Extension.MP,
                MagicBytes = new byte[] { 0x0C, 0xED },
                Description = "Monochrome Picture TIFF bitmap"
            },
            new Signature()
            {
                Extension = Extension.MP3,
                MagicBytes = new byte[] { 0x49, 0x44, 0x33 },
                Description = "MP3 audio file"
            },
            new Signature()
            {
                Extension = Extension.MPG,
                MagicBytes = new byte[] { 0x00, 0x00, 0x01, 0xBA },
                Description = "DVD video file"
            },
            new Signature()
            {
                Extension = Extension.MPG,
                MagicBytes = new byte[] { 0x00, 0x00, 0x01, 0xB3 },
                Description = "MPEG video file"
            },
            new Signature()
            {
                Extension = Extension.MSC,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Microsoft Common Console Document"
            },
            new Signature()
            {
                Extension = Extension.MSC,
                MagicBytes = new byte[] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20, 0x76, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x22, 0x31, 0x2E, 0x30, 0x22, 0x3F, 0x3E, 0x0D, 0x0A, 0x3C, 0x4D, 0x4D, 0x43, 0x5F, 0x43, 0x6F, 0x6E, 0x73, 0x6F, 0x6C, 0x65, 0x46, 0x69, 0x6C, 0x65, 0x20, 0x43, 0x6F, 0x6E, 0x73, 0x6F, 0x6C, 0x65, 0x56, 0x65, 0x72 },
                Description = "MMC Snap-in Control file"
            },
            new Signature()
            {
                Extension = Extension.MSI,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Microsoft Installer package"
            },
            new Signature()
            {
                Extension = Extension.MSI,
                MagicBytes = new byte[] { 0x23, 0x20 },
                Description = "Cerius2 file"
            },
            new Signature()
            {
                Extension = Extension.MSV,
                MagicBytes = new byte[] { 0x4D, 0x53, 0x5F, 0x56, 0x4F, 0x49, 0x43, 0x45 },
                Description = "Sony Compressed Voice File"
            },
            new Signature()
            {
                Extension = Extension.MTW,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Minitab data file"
            },
            new Signature()
            {
                Extension = Extension.NRI,
                MagicBytes = new byte[] { 0x0E, 0x4E, 0x65, 0x72, 0x6F, 0x49, 0x53, 0x4F },
                Description = "Nero CD compilation"
            },
            new Signature()
            {
                Extension = Extension.NSF,
                MagicBytes = new byte[] { 0x1A, 0x00, 0x00, 0x04, 0x00, 0x00 },
                Description = "Lotus Notes database"
            },
            new Signature()
            {
                Extension = Extension.NSF,
                MagicBytes = new byte[] { 0x4E, 0x45, 0x53, 0x4D, 0x1A, 0x01 },
                Description = "NES Sound file"
            },
            new Signature()
            {
                Extension = Extension.NTF,
                MagicBytes = new byte[] { 0x1A, 0x00, 0x00 },
                Description = "Lotus Notes database template"
            },
            new Signature()
            {
                Extension = Extension.NTF,
                MagicBytes = new byte[] { 0x4E, 0x49, 0x54, 0x46, 0x30 },
                Description = "National Imagery Transmission Format file"
            },
            new Signature()
            {
                Extension = Extension.NTF,
                MagicBytes = new byte[] { 0x30, 0x31, 0x4F, 0x52, 0x44, 0x4E, 0x41, 0x4E },
                Description = "National Transfer Format Map"
            },
            new Signature()
            {
                Extension = Extension.NVRAM,
                MagicBytes = new byte[] { 0x4D, 0x52, 0x56, 0x4E },
                Description = "VMware BIOS state file"
            },
            new Signature()
            {
                Extension = Extension.OBJ,
                MagicBytes = new byte[] { 0x4C, 0x01 },
                Description = "MS COFF relocatable object code"
            },
            new Signature()
            {
                Extension = Extension.OBJ,
                MagicBytes = new byte[] { 0x80 },
                Description = "Relocatable object code"
            },
            new Signature()
            {
                Extension = Extension.OCX,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "ActiveX|OLE Custom Control"
            },
            new Signature()
            {
                Extension = Extension.ODP,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "OpenDocument template"
            },
            new Signature()
            {
                Extension = Extension.ODT,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "OpenDocument template"
            },
            new Signature()
            {
                Extension = Extension.OGA,
                MagicBytes = new byte[] { 0x4F, 0x67, 0x67, 0x53, 0x00, 0x02, 0x00, 0x00 },
                Description = "Ogg Vorbis Codec compressed file"
            },
            new Signature()
            {
                Extension = Extension.OGG,
                MagicBytes = new byte[] { 0x4F, 0x67, 0x67, 0x53, 0x00, 0x02, 0x00, 0x00 },
                Description = "Ogg Vorbis Codec compressed file"
            },
            new Signature()
            {
                Extension = Extension.OGV,
                MagicBytes = new byte[] { 0x4F, 0x67, 0x67, 0x53, 0x00, 0x02, 0x00, 0x00 },
                Description = "Ogg Vorbis Codec compressed file"
            },
            new Signature()
            {
                Extension = Extension.OGX,
                MagicBytes = new byte[] { 0x4F, 0x67, 0x67, 0x53, 0x00, 0x02, 0x00, 0x00 },
                Description = "Ogg Vorbis Codec compressed file"
            },
            new Signature()
            {
                Extension = Extension.OLB,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "OLE object library"
            },
            new Signature()
            {
                Extension = Extension.ONE,
                MagicBytes = new byte[] { 0xE4, 0x52, 0x5C, 0x7B, 0x8C, 0xD8, 0xA7, 0x4D },
                Description = "MS OneNote note"
            },
            new Signature()
            {
                Extension = Extension.OPT,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Developer Studio File Options file"
            },
            new Signature()
            {
                Extension = Extension.OPT,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x20 },
                Description = "Developer Studio subheader"
            },
            new Signature()
            {
                Extension = Extension.ORG,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C, 0x56, 0x4D, 0x31, 0x30, 0x30 },
                Description = "AOL personal file cabinet"
            },
            new Signature()
            {
                Extension = Extension.OTT,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "OpenDocument template"
            },
            new Signature()
            {
                Extension = Extension.P10,
                MagicBytes = new byte[] { 0x64, 0x00, 0x00, 0x00 },
                Description = "Intel PROset|Wireless Profile"
            },
            new Signature()
            {
                Extension = Extension.PAK,
                MagicBytes = new byte[] { 0x1A, 0x0B },
                Description = "PAK Compressed archive file"
            },
            new Signature()
            {
                Extension = Extension.PAK,
                MagicBytes = new byte[] { 0x50, 0x41, 0x43, 0x4B },
                Description = "Quake archive file"
            },
            new Signature()
            {
                Extension = Extension.PAT,
                MagicBytes = new byte[] { 0x47, 0x50, 0x41, 0x54 },
                Description = "GIMP pattern file"
            },
            new Signature()
            {
                Extension = Extension.PAX,
                MagicBytes = new byte[] { 0x50, 0x41, 0x58 },
                Description = "PAX password protected bitmap"
            },
            new Signature()
            {
                Extension = Extension.PCH,
                MagicBytes = new byte[] { 0x56, 0x43, 0x50, 0x43, 0x48, 0x30 },
                Description = "Visual C PreCompiled header"
            },
            new Signature()
            {
                Extension = Extension.PCX,
                MagicBytes = new byte[] { 0x0A, 0x02, 0x01, 0x01 },
                Description = "ZSOFT Paintbrush file_1"
            },
            new Signature()
            {
                Extension = Extension.PCX,
                MagicBytes = new byte[] { 0x0A, 0x03, 0x01, 0x01 },
                Description = "ZSOFT Paintbrush file_2"
            },
            new Signature()
            {
                Extension = Extension.PCX,
                MagicBytes = new byte[] { 0x0A, 0x05, 0x01, 0x01 },
                Description = "ZSOFT Paintbrush file_3"
            },
            new Signature()
            {
                Extension = Extension.PDB,
                MagicBytes = new byte[] { 0xAC, 0xED, 0x00, 0x05, 0x73, 0x72, 0x00, 0x12 },
                Description = "BGBlitz position database file"
            },
            new Signature()
            {
                Extension = Extension.PDB,
                MagicBytes = new byte[] { 0x4D, 0x2D, 0x57, 0x20, 0x50, 0x6F, 0x63, 0x6B },
                Description = "Merriam-Webster Pocket Dictionary"
            },
            new Signature()
            {
                Extension = Extension.PDB,
                MagicBytes = new byte[] { 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x20, 0x43, 0x2F, 0x43, 0x2B, 0x2B, 0x20 },
                Description = "MS C++ debugging symbols file"
            },
            new Signature()
            {
                Extension = Extension.PDB,
                MagicBytes = new byte[] { 0x73, 0x6D, 0x5F },
                Description = "PalmOS SuperMemo"
            },
            new Signature()
            {
                Extension = Extension.PDB,
                MagicBytes = new byte[] { 0x73, 0x7A, 0x65, 0x7A },
                Description = "PowerBASIC Debugger Symbols"
            },
            new Signature()
            {
                Extension = Extension.PDF,
                MagicBytes = new byte[] { 0x25, 0x50, 0x44, 0x46 },
                Description = "PDF file"
            },
            new Signature()
            {
                Extension = Extension.PF,
                MagicBytes = new byte[] { 0x11, 0x00, 0x00, 0x00, 0x53, 0x43, 0x43, 0x41 },
                Description = "Windows prefetch file"
            },
            new Signature()
            {
                Extension = Extension.PFC,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C },
                Description = "AOL config files"
            },
            new Signature()
            {
                Extension = Extension.PFC,
                MagicBytes = new byte[] { 0x41, 0x4F, 0x4C, 0x56, 0x4D, 0x31, 0x30, 0x30 },
                Description = "AOL personal file cabinet"
            },
            new Signature()
            {
                Extension = Extension.PGD,
                MagicBytes = new byte[] { 0x50, 0x47, 0x50, 0x64, 0x4D, 0x41, 0x49, 0x4E },
                Description = "PGP disk image"
            },
            new Signature()
            {
                Extension = Extension.PGM,
                MagicBytes = new byte[] { 0x50, 0x35, 0x0A },
                Description = "Portable Graymap Graphic"
            },
            new Signature()
            {
                Extension = Extension.PIF,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows|DOS executable file"
            },
            new Signature()
            {
                Extension = Extension.PKR,
                MagicBytes = new byte[] { 0x99, 0x01 },
                Description = "PGP public keyring"
            },
            new Signature()
            {
                Extension = Extension.PNG,
                MagicBytes = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
                Description = "PNG image"
            },
            new Signature()
            {
                Extension = Extension.PPS,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Microsoft Office document"
            },
            new Signature()
            {
                Extension = Extension.PPT,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Microsoft Office document"
            },
            new Signature()
            {
                Extension = Extension.PPT,
                MagicBytes = new byte[] { 0x00, 0x6E, 0x1E, 0xF0 },
                Description = "PowerPoint presentation subheader_1"
            },
            new Signature()
            {
                Extension = Extension.PPT,
                MagicBytes = new byte[] { 0x0F, 0x00, 0xE8, 0x03 },
                Description = "PowerPoint presentation subheader_2"
            },
            new Signature()
            {
                Extension = Extension.PPT,
                MagicBytes = new byte[] { 0xA0, 0x46, 0x1D, 0xF0 },
                Description = "PowerPoint presentation subheader_3"
            },
            new Signature()
            {
                Extension = Extension.PPT,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00 },
                Description = "PowerPoint presentation subheader_4"
            },
            new Signature()
            {
                Extension = Extension.PPT,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x1C, 0x00, 0x00, 0x00 },
                Description = "PowerPoint presentation subheader_5"
            },
            new Signature()
            {
                Extension = Extension.PPT,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x43, 0x00, 0x00, 0x00 },
                Description = "PowerPoint presentation subheader_6"
            },
            new Signature()
            {
                Extension = Extension.PPTX,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "MS Office Open XML Format Document"
            },
            new Signature()
            {
                Extension = Extension.PPTX,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 },
                Description = "MS Office 2007 documents"
            },
            new Signature()
            {
                Extension = Extension.PPZ,
                MagicBytes = new byte[] { 0x4D, 0x53, 0x43, 0x46 },
                Description = "Powerpoint Packaged Presentation"
            },
            new Signature()
            {
                Extension = Extension.PRC,
                MagicBytes = new byte[] { 0x42, 0x4F, 0x4F, 0x4B, 0x4D, 0x4F, 0x42, 0x49 },
                Description = "Palmpilot resource file"
            },
            new Signature()
            {
                Extension = Extension.PRC,
                MagicBytes = new byte[] { 0x74, 0x42, 0x4D, 0x50, 0x4B, 0x6E, 0x57, 0x72 },
                Description = "PathWay Map file"
            },
            new Signature()
            {
                Extension = Extension.PSD,
                MagicBytes = new byte[] { 0x38, 0x42, 0x50, 0x53 },
                Description = "Photoshop image"
            },
            new Signature()
            {
                Extension = Extension.PSP,
                MagicBytes = new byte[] { 0x7E, 0x42, 0x4B, 0x00 },
                Description = "Corel Paint Shop Pro image"
            },
            new Signature()
            {
                Extension = Extension.PUB,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "MS Publisher file"
            },
            new Signature()
            {
                Extension = Extension.PWI,
                MagicBytes = new byte[] { 0x7B, 0x5C, 0x70, 0x77, 0x69 },
                Description = "MS WinMobile personal note"
            },
            new Signature()
            {
                Extension = Extension.PWL,
                MagicBytes = new byte[] { 0xB0, 0x4D, 0x46, 0x43 },
                Description = "Win95 password file"
            },
            new Signature()
            {
                Extension = Extension.PWL,
                MagicBytes = new byte[] { 0xE3, 0x82, 0x85, 0x96 },
                Description = "Win98 password file"
            },
            new Signature()
            {
                Extension = Extension.QBB,
                MagicBytes = new byte[] { 0x45, 0x86, 0x00, 0x00, 0x06, 0x00 },
                Description = "QuickBooks backup"
            },
            new Signature()
            {
                Extension = Extension.QCP,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "Resource Interchange File Format"
            },
            new Signature()
            {
                Extension = Extension.QDF,
                MagicBytes = new byte[] { 0xAC, 0x9E, 0xBD, 0x8F, 0x00, 0x00 },
                Description = "QDF Quicken data"
            },
            new Signature()
            {
                Extension = Extension.QEL,
                MagicBytes = new byte[] { 0x51, 0x45, 0x4C, 0x20 },
                Description = "QDL Quicken data"
            },
            new Signature()
            {
                Extension = Extension.QEMU,
                MagicBytes = new byte[] { 0x51, 0x46, 0x49 },
                Description = "Qcow Disk Image"
            },
            new Signature()
            {
                Extension = Extension.QPH,
                MagicBytes = new byte[] { 0x03, 0x00, 0x00, 0x00 },
                Description = "Quicken price history"
            },
            new Signature()
            {
                Extension = Extension.QSD,
                MagicBytes = new byte[] { 0x51, 0x57, 0x20, 0x56, 0x65, 0x72, 0x2E, 0x20 },
                Description = "ABD | QSD Quicken data file"
            },
            new Signature()
            {
                Extension = Extension.QTS,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows|DOS executable file"
            },
            new Signature()
            {
                Extension = Extension.QTX,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows|DOS executable file"
            },
            new Signature()
            {
                Extension = Extension.QXD,
                MagicBytes = new byte[] { 0x00, 0x00, 0x49, 0x49, 0x58, 0x50, 0x52 },
                Description = "Quark Express (Intel)"
            },
            new Signature()
            {
                Extension = Extension.QXD,
                MagicBytes = new byte[] { 0x00, 0x00, 0x4D, 0x4D, 0x58, 0x50, 0x52 },
                Description = "Quark Express (Motorola)"
            },
            new Signature()
            {
                Extension = Extension.RA,
                MagicBytes = new byte[] { 0x2E, 0x52, 0x4D, 0x46, 0x00, 0x00, 0x00, 0x12 },
                Description = "RealAudio file"
            },
            new Signature()
            {
                Extension = Extension.RA,
                MagicBytes = new byte[] { 0x2E, 0x72, 0x61, 0xFD, 0x00 },
                Description = "RealAudio streaming media"
            },
            new Signature()
            {
                Extension = Extension.RAM,
                MagicBytes = new byte[] { 0x72, 0x74, 0x73, 0x70, 0x3A, 0x2F, 0x2F },
                Description = "RealMedia metafile"
            },
            new Signature()
            {
                Extension = Extension.RAR,
                MagicBytes = new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00 },
                Description = "WinRAR compressed archive"
            },
            new Signature()
            {
                Extension = Extension.REG,
                MagicBytes = new byte[] { 0xFF, 0xFE },
                Description = "Windows Registry file"
            },
            new Signature()
            {
                Extension = Extension.REG,
                MagicBytes = new byte[] { 0x52, 0x45, 0x47, 0x45, 0x44, 0x49, 0x54 },
                Description = "WinNT Registry|Registry Undo files"
            },
            new Signature()
            {
                Extension = Extension.RGB,
                MagicBytes = new byte[] { 0x01, 0xDA, 0x01, 0x01, 0x00, 0x03 },
                Description = "Silicon Graphics RGB Bitmap"
            },
            new Signature()
            {
                Extension = Extension.RM,
                MagicBytes = new byte[] { 0x2E, 0x52, 0x4D, 0x46 },
                Description = "RealMedia streaming media"
            },
            new Signature()
            {
                Extension = Extension.RMI,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "Resource Interchange File Format"
            },
            new Signature()
            {
                Extension = Extension.RMVB,
                MagicBytes = new byte[] { 0x2E, 0x52, 0x4D, 0x46 },
                Description = "RealMedia streaming media"
            },
            new Signature()
            {
                Extension = Extension.RPM,
                MagicBytes = new byte[] { 0xED, 0xAB, 0xEE, 0xDB },
                Description = "RedHat Package Manager"
            },
            new Signature()
            {
                Extension = Extension.RTD,
                MagicBytes = new byte[] { 0x43, 0x23, 0x2B, 0x44, 0xA4, 0x43, 0x4D, 0xA5 },
                Description = "RagTime document"
            },
            new Signature()
            {
                Extension = Extension.RTF,
                MagicBytes = new byte[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 },
                Description = "RTF file"
            },
            new Signature()
            {
                Extension = Extension.RVT,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Revit Project file"
            },
            new Signature()
            {
                Extension = Extension.SAM,
                MagicBytes = new byte[] { 0x5B, 0x56, 0x45, 0x52, 0x5D },
                Description = "Lotus AMI Pro document_1"
            },
            new Signature()
            {
                Extension = Extension.SAM,
                MagicBytes = new byte[] { 0x5B, 0x76, 0x65, 0x72, 0x5D },
                Description = "Lotus AMI Pro document_2"
            },
            new Signature()
            {
                Extension = Extension.SAV,
                MagicBytes = new byte[] { 0x24, 0x46, 0x4C, 0x32, 0x40, 0x28, 0x23, 0x29 },
                Description = "SPSS Data file"
            },
            new Signature()
            {
                Extension = Extension.SCR,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Screen saver"
            },
            new Signature()
            {
                Extension = Extension.SDR,
                MagicBytes = new byte[] { 0x53, 0x4D, 0x41, 0x52, 0x54, 0x44, 0x52, 0x57 },
                Description = "SmartDraw Drawing file"
            },
            new Signature()
            {
                Extension = Extension.SH3,
                MagicBytes = new byte[] { 0x48, 0x48, 0x47, 0x42, 0x31 },
                Description = "Harvard Graphics presentation file"
            },
            new Signature()
            {
                Extension = Extension.SHD,
                MagicBytes = new byte[] { 0x68, 0x49, 0x00, 0x00 },
                Description = "Win Server 2003 printer spool file"
            },
            new Signature()
            {
                Extension = Extension.SHD,
                MagicBytes = new byte[] { 0x4B, 0x49, 0x00, 0x00 },
                Description = "Win9x printer spool file"
            },
            new Signature()
            {
                Extension = Extension.SHD,
                MagicBytes = new byte[] { 0x67, 0x49, 0x00, 0x00 },
                Description = "Win2000|XP printer spool file"
            },
            new Signature()
            {
                Extension = Extension.SHD,
                MagicBytes = new byte[] { 0x66, 0x49, 0x00, 0x00 },
                Description = "WinNT printer spool file"
            },
            new Signature()
            {
                Extension = Extension.SHW,
                MagicBytes = new byte[] { 0x53, 0x48, 0x4F, 0x57 },
                Description = "Harvard Graphics presentation"
            },
            new Signature()
            {
                Extension = Extension.SIT,
                MagicBytes = new byte[] { 0x53, 0x49, 0x54, 0x21, 0x00 },
                Description = "StuffIt archive"
            },
            new Signature()
            {
                Extension = Extension.SIT,
                MagicBytes = new byte[] { 0x53, 0x74, 0x75, 0x66, 0x66, 0x49, 0x74, 0x20 },
                Description = "StuffIt compressed archive"
            },
            new Signature()
            {
                Extension = Extension.SKF,
                MagicBytes = new byte[] { 0x07, 0x53, 0x4B, 0x46 },
                Description = "SkinCrafter skin"
            },
            new Signature()
            {
                Extension = Extension.SKR,
                MagicBytes = new byte[] { 0x95, 0x00 },
                Description = "PGP secret keyring_1"
            },
            new Signature()
            {
                Extension = Extension.SKR,
                MagicBytes = new byte[] { 0x95, 0x01 },
                Description = "PGP secret keyring_2"
            },
            new Signature()
            {
                Extension = Extension.SLE,
                MagicBytes = new byte[] { 0x41, 0x43, 0x76 },
                Description = "Steganos virtual secure drive"
            },
            new Signature()
            {
                Extension = Extension.SLE,
                MagicBytes = new byte[] { 0x3A, 0x56, 0x45, 0x52, 0x53, 0x49, 0x4F, 0x4E },
                Description = "Surfplan kite project file"
            },
            new Signature()
            {
                Extension = Extension.SLN,
                MagicBytes = new byte[] { 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x20, 0x56, 0x69, 0x73, 0x75, 0x61, 0x6C },
                Description = "Visual Studio .NET file"
            },
            new Signature()
            {
                Extension = Extension.SNM,
                MagicBytes = new byte[] { 0x00, 0x1E, 0x84, 0x90, 0x00, 0x00, 0x00, 0x00 },
                Description = "Netscape Communicator (v4) mail folder"
            },
            new Signature()
            {
                Extension = Extension.SNP,
                MagicBytes = new byte[] { 0x4D, 0x53, 0x43, 0x46 },
                Description = "MS Access Snapshot Viewer file"
            },
            new Signature()
            {
                Extension = Extension.SOU,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Visual Studio Solution User Options file"
            },
            new Signature()
            {
                Extension = Extension.SPL,
                MagicBytes = new byte[] { 0x00, 0x00, 0x01, 0x00 },
                Description = "Windows icon|printer spool file"
            },
            new Signature()
            {
                Extension = Extension.SPO,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "SPSS output file"
            },
            new Signature()
            {
                Extension = Extension.SUD,
                MagicBytes = new byte[] { 0x52, 0x45, 0x47, 0x45, 0x44, 0x49, 0x54 },
                Description = "WinNT Registry|Registry Undo files"
            },
            new Signature()
            {
                Extension = Extension.SUO,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x04 },
                Description = "Visual Studio Solution subheader"
            },
            new Signature()
            {
                Extension = Extension.SWF,
                MagicBytes = new byte[] { 0x43, 0x57, 0x53 },
                Description = "Shockwave Flash file"
            },
            new Signature()
            {
                Extension = Extension.SWF,
                MagicBytes = new byte[] { 0x46, 0x57, 0x53 },
                Description = "Shockwave Flash player"
            },
            new Signature()
            {
                Extension = Extension.SXC,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "StarOffice spreadsheet"
            },
            new Signature()
            {
                Extension = Extension.SXD,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "OpenOffice documents"
            },
            new Signature()
            {
                Extension = Extension.SXI,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "OpenOffice documents"
            },
            new Signature()
            {
                Extension = Extension.SXW,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "OpenOffice documents"
            },
            new Signature()
            {
                Extension = Extension.SYS,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows|DOS executable file"
            },
            new Signature()
            {
                Extension = Extension.SYS,
                MagicBytes = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF },
                Description = "DOS system driver"
            },
            new Signature()
            {
                Extension = Extension.SYS,
                MagicBytes = new byte[] { 0xFF, 0x4B, 0x45, 0x59, 0x42, 0x20, 0x20, 0x20 },
                Description = "Keyboard driver file"
            },
            new Signature()
            {
                Extension = Extension.SYS,
                MagicBytes = new byte[] { 0xE8 },
                Description = "Windows executable file_1"
            },
            new Signature()
            {
                Extension = Extension.SYS,
                MagicBytes = new byte[] { 0xE9 },
                Description = "Windows executable file_2"
            },
            new Signature()
            {
                Extension = Extension.SYS,
                MagicBytes = new byte[] { 0xEB },
                Description = "Windows executable file_3"
            },
            new Signature()
            {
                Extension = Extension.SYS,
                MagicBytes = new byte[] { 0xFF },
                Description = "Windows executable"
            },
            new Signature()
            {
                Extension = Extension.SYW,
                MagicBytes = new byte[] { 0x41, 0x4D, 0x59, 0x4F },
                Description = "Harvard Graphics symbol graphic"
            },
            new Signature()
            {
                Extension = Extension.TAR,
                MagicBytes = new byte[] { 0x75, 0x73, 0x74, 0x61, 0x72 },
                Description = "Tape Archive"
            },
            new Signature()
            {
                Extension = Extension.TAR_BZ2,
                MagicBytes = new byte[] { 0x42, 0x5A, 0x68 },
                Description = "bzip2 compressed archive"
            },
            new Signature()
            {
                Extension = Extension.TAR_Z,
                MagicBytes = new byte[] { 0x1F, 0x9D, 0x90 },
                Description = "Compressed tape archive_1"
            },
            new Signature()
            {
                Extension = Extension.TAR_Z,
                MagicBytes = new byte[] { 0x1F, 0xA0 },
                Description = "Compressed tape archive_2"
            },
            new Signature()
            {
                Extension = Extension.TB2,
                MagicBytes = new byte[] { 0x42, 0x5A, 0x68 },
                Description = "bzip2 compressed archive"
            },
            new Signature()
            {
                Extension = Extension.TBZ2,
                MagicBytes = new byte[] { 0x42, 0x5A, 0x68 },
                Description = "bzip2 compressed archive"
            },
            new Signature()
            {
                Extension = Extension.TIB,
                MagicBytes = new byte[] { 0xB4, 0x6E, 0x68, 0x44 },
                Description = "Acronis True Image"
            },
            new Signature()
            {
                Extension = Extension.TIF,
                MagicBytes = new byte[] { 0x49, 0x20, 0x49 },
                Description = "TIFF file_1"
            },
            new Signature()
            {
                Extension = Extension.TIF,
                MagicBytes = new byte[] { 0x49, 0x49, 0x2A, 0x00 },
                Description = "TIFF file_2"
            },
            new Signature()
            {
                Extension = Extension.TIF,
                MagicBytes = new byte[] { 0x4D, 0x4D, 0x00, 0x2A },
                Description = "TIFF file_3"
            },
            new Signature()
            {
                Extension = Extension.TIF,
                MagicBytes = new byte[] { 0x4D, 0x4D, 0x00, 0x2B },
                Description = "TIFF file_4"
            },
            new Signature()
            {
                Extension = Extension.TIFF,
                MagicBytes = new byte[] { 0x49, 0x20, 0x49 },
                Description = "TIFF file_1"
            },
            new Signature()
            {
                Extension = Extension.TIFF,
                MagicBytes = new byte[] { 0x49, 0x49, 0x2A, 0x00 },
                Description = "TIFF file_2"
            },
            new Signature()
            {
                Extension = Extension.TIFF,
                MagicBytes = new byte[] { 0x4D, 0x4D, 0x00, 0x2A },
                Description = "TIFF file_3"
            },
            new Signature()
            {
                Extension = Extension.TIFF,
                MagicBytes = new byte[] { 0x4D, 0x4D, 0x00, 0x2B },
                Description = "TIFF file_4"
            },
            new Signature()
            {
                Extension = Extension.TLB,
                MagicBytes = new byte[] { 0x4D, 0x53, 0x46, 0x54, 0x02, 0x00, 0x01, 0x00 },
                Description = "OLE|SPSS|Visual C++ library file"
            },
            new Signature()
            {
                Extension = Extension.TR1,
                MagicBytes = new byte[] { 0x01, 0x10 },
                Description = "Novell LANalyzer capture file"
            },
            new Signature()
            {
                Extension = Extension.UCE,
                MagicBytes = new byte[] { 0x55, 0x43, 0x45, 0x58 },
                Description = "Unicode extensions"
            },
            new Signature()
            {
                Extension = Extension.UFA,
                MagicBytes = new byte[] { 0x55, 0x46, 0x41, 0xC6, 0xD2, 0xC1 },
                Description = "UFA compressed archive"
            },
            new Signature()
            {
                Extension = Extension.VBX,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "VisualBASIC application"
            },
            new Signature()
            {
                Extension = Extension.VCD,
                MagicBytes = new byte[] { 0x45, 0x4E, 0x54, 0x52, 0x59, 0x56, 0x43, 0x44 },
                Description = "VideoVCD|VCDImager file"
            },
            new Signature()
            {
                Extension = Extension.VCF,
                MagicBytes = new byte[] { 0x42, 0x45, 0x47, 0x49, 0x4E, 0x3A, 0x56, 0x43 },
                Description = "vCard"
            },
            new Signature()
            {
                Extension = Extension.VCW,
                MagicBytes = new byte[] { 0x5B, 0x4D, 0x53, 0x56, 0x43 },
                Description = "Visual C++ Workbench Info File"
            },
            new Signature()
            {
                Extension = Extension.VHD,
                MagicBytes = new byte[] { 0x63, 0x6F, 0x6E, 0x65, 0x63, 0x74, 0x69, 0x78 },
                Description = "Virtual PC HD image"
            },
            new Signature()
            {
                Extension = Extension.VMDK,
                MagicBytes = new byte[] { 0x43, 0x4F, 0x57, 0x44 },
                Description = "VMware 3 Virtual Disk"
            },
            new Signature()
            {
                Extension = Extension.VMDK,
                MagicBytes = new byte[] { 0x23, 0x20, 0x44, 0x69, 0x73, 0x6B, 0x20, 0x44 },
                Description = "VMware 4 Virtual Disk description"
            },
            new Signature()
            {
                Extension = Extension.VMDK,
                MagicBytes = new byte[] { 0x4B, 0x44, 0x4D },
                Description = "VMware 4 Virtual Disk"
            },
            new Signature()
            {
                Extension = Extension.VOB,
                MagicBytes = new byte[] { 0x00, 0x00, 0x01, 0xBA },
                Description = "DVD video file"
            },
            new Signature()
            {
                Extension = Extension.VSD,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Visio file"
            },
            new Signature()
            {
                Extension = Extension.VXD,
                MagicBytes = new byte[] { 0x4D, 0x5A },
                Description = "Windows virtual device drivers"
            },
            new Signature()
            {
                Extension = Extension.WAB,
                MagicBytes = new byte[] { 0x9C, 0xCB, 0xCB, 0x8D, 0x13, 0x75, 0xD2, 0x11 },
                Description = "Outlook address file"
            },
            new Signature()
            {
                Extension = Extension.WAB,
                MagicBytes = new byte[] { 0x81, 0x32, 0x84, 0xC1, 0x85, 0x05, 0xD0, 0x11 },
                Description = "Outlook Express address book (Win95)"
            },
            new Signature()
            {
                Extension = Extension.WAV,
                MagicBytes = new byte[] { 0x52, 0x49, 0x46, 0x46 },
                Description = "Resource Interchange File Format"
            },
            new Signature()
            {
                Extension = Extension.WB2,
                MagicBytes = new byte[] { 0x00, 0x00, 0x02, 0x00 },
                Description = "QuattroPro spreadsheet"
            },
            new Signature()
            {
                Extension = Extension.WB3,
                MagicBytes = new byte[] { 0x3E, 0x00, 0x03, 0x00, 0xFE, 0xFF, 0x09, 0x00, 0x06 },
                Description = "Quatro Pro for Windows 7.0"
            },
            new Signature()
            {
                Extension = Extension.WIZ,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Microsoft Office document"
            },
            new Signature()
            {
                Extension = Extension.WK1,
                MagicBytes = new byte[] { 0x00, 0x00, 0x02, 0x00, 0x06, 0x04, 0x06, 0x00 },
                Description = "Lotus 1-2-3 (v1)"
            },
            new Signature()
            {
                Extension = Extension.WK3,
                MagicBytes = new byte[] { 0x00, 0x00, 0x1A, 0x00, 0x00, 0x10, 0x04, 0x00 },
                Description = "Lotus 1-2-3 (v3)"
            },
            new Signature()
            {
                Extension = Extension.WK4,
                MagicBytes = new byte[] { 0x00, 0x00, 0x1A, 0x00, 0x02, 0x10, 0x04, 0x00 },
                Description = "Lotus 1-2-3 (v4|v5)"
            },
            new Signature()
            {
                Extension = Extension.WK5,
                MagicBytes = new byte[] { 0x00, 0x00, 0x1A, 0x00, 0x02, 0x10, 0x04, 0x00 },
                Description = "Lotus 1-2-3 (v4|v5)"
            },
            new Signature()
            {
                Extension = Extension.WKS,
                MagicBytes = new byte[] { 0x0E, 0x57, 0x4B, 0x53 },
                Description = "DeskMate Worksheet"
            },
            new Signature()
            {
                Extension = Extension.WKS,
                MagicBytes = new byte[] { 0xFF, 0x00, 0x02, 0x00, 0x04, 0x04, 0x05, 0x54 },
                Description = "Works for Windows spreadsheet"
            },
            new Signature()
            {
                Extension = Extension.WMA,
                MagicBytes = new byte[] { 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11 },
                Description = "Windows Media Audio|Video File"
            },
            new Signature()
            {
                Extension = Extension.WMF,
                MagicBytes = new byte[] { 0xD7, 0xCD, 0xC6, 0x9A },
                Description = "Windows graphics metafile"
            },
            new Signature()
            {
                Extension = Extension.WMV,
                MagicBytes = new byte[] { 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11 },
                Description = "Windows Media Audio|Video File"
            },
            new Signature()
            {
                Extension = Extension.WMZ,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "Windows Media compressed skin file"
            },
            new Signature()
            {
                Extension = Extension.WP,
                MagicBytes = new byte[] { 0xFF, 0x57, 0x50, 0x43 },
                Description = "WordPerfect text and graphics"
            },
            new Signature()
            {
                Extension = Extension.WP5,
                MagicBytes = new byte[] { 0xFF, 0x57, 0x50, 0x43 },
                Description = "WordPerfect text and graphics"
            },
            new Signature()
            {
                Extension = Extension.WP6,
                MagicBytes = new byte[] { 0xFF, 0x57, 0x50, 0x43 },
                Description = "WordPerfect text and graphics"
            },
            new Signature()
            {
                Extension = Extension.WPD,
                MagicBytes = new byte[] { 0xFF, 0x57, 0x50, 0x43 },
                Description = "WordPerfect text and graphics"
            },
            new Signature()
            {
                Extension = Extension.WPF,
                MagicBytes = new byte[] { 0x81, 0xCD, 0xAB },
                Description = "WordPerfect text"
            },
            new Signature()
            {
                Extension = Extension.WPG,
                MagicBytes = new byte[] { 0xFF, 0x57, 0x50, 0x43 },
                Description = "WordPerfect text and graphics"
            },
            new Signature()
            {
                Extension = Extension.WPL,
                MagicBytes = new byte[] { 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x20, 0x57, 0x69, 0x6E, 0x64, 0x6F, 0x77, 0x73, 0x20, 0x4D, 0x65, 0x64, 0x69, 0x61, 0x20, 0x50, 0x6C, 0x61, 0x79, 0x65, 0x72, 0x20, 0x2D, 0x2D, 0x20 },
                Description = "Windows Media Player playlist"
            },
            new Signature()
            {
                Extension = Extension.WPP,
                MagicBytes = new byte[] { 0xFF, 0x57, 0x50, 0x43 },
                Description = "WordPerfect text and graphics"
            },
            new Signature()
            {
                Extension = Extension.WPS,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "MSWorks text document"
            },
            new Signature()
            {
                Extension = Extension.WRI,
                MagicBytes = new byte[] { 0x31, 0xBE },
                Description = "MS Write file_1"
            },
            new Signature()
            {
                Extension = Extension.WRI,
                MagicBytes = new byte[] { 0x32, 0xBE },
                Description = "MS Write file_2"
            },
            new Signature()
            {
                Extension = Extension.WRI,
                MagicBytes = new byte[] { 0xBE, 0x00, 0x00, 0x00, 0xAB },
                Description = "MS Write file_3"
            },
            new Signature()
            {
                Extension = Extension.WS,
                MagicBytes = new byte[] { 0x1D, 0x7D },
                Description = "WordStar Version 5.0|6.0 document"
            },
            new Signature()
            {
                Extension = Extension.WS2,
                MagicBytes = new byte[] { 0x57, 0x53, 0x32, 0x30, 0x30, 0x30 },
                Description = "WordStar for Windows file"
            },
            new Signature()
            {
                Extension = Extension.XDR,
                MagicBytes = new byte[] { 0x3C },
                Description = "BizTalk XML-Data Reduced Schema"
            },
            new Signature()
            {
                Extension = Extension.XLA,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Microsoft Office document"
            },
            new Signature()
            {
                Extension = Extension.XLS,
                MagicBytes = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                Description = "Microsoft Office document"
            },
            new Signature()
            {
                Extension = Extension.XLS,
                MagicBytes = new byte[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 },
                Description = "Excel spreadsheet subheader_1"
            },
            new Signature()
            {
                Extension = Extension.XLS,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x10 },
                Description = "Excel spreadsheet subheader_2"
            },
            new Signature()
            {
                Extension = Extension.XLS,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x1F },
                Description = "Excel spreadsheet subheader_3"
            },
            new Signature()
            {
                Extension = Extension.XLS,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x22 },
                Description = "Excel spreadsheet subheader_4"
            },
            new Signature()
            {
                Extension = Extension.XLS,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x23 },
                Description = "Excel spreadsheet subheader_5"
            },
            new Signature()
            {
                Extension = Extension.XLS,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x28 },
                Description = "Excel spreadsheet subheader_6"
            },
            new Signature()
            {
                Extension = Extension.XLS,
                MagicBytes = new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x29 },
                Description = "Excel spreadsheet subheader_7"
            },
            new Signature()
            {
                Extension = Extension.XLSX,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "MS Office Open XML Format Document"
            },
            new Signature()
            {
                Extension = Extension.XLSX,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 },
                Description = "MS Office 2007 documents"
            },
            new Signature()
            {
                Extension = Extension.XML,
                MagicBytes = new byte[] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20, 0x76, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x22, 0x31, 0x2E, 0x30, 0x22, 0x3F, 0x3E },
                Description = "User Interface Language"
            },
            new Signature()
            {
                Extension = Extension.XPI,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "Mozilla Browser Archive"
            },
            new Signature()
            {
                Extension = Extension.XPS,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "XML paper specification file"
            },
            new Signature()
            {
                Extension = Extension.XPT,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "eXact Packager Models"
            },
            new Signature()
            {
                Extension = Extension.XPT,
                MagicBytes = new byte[] { 0x58, 0x50, 0x43, 0x4F, 0x4D, 0x0A, 0x54, 0x79 },
                Description = "XPCOM libraries"
            },
            new Signature()
            {
                Extension = Extension.ZAP,
                MagicBytes = new byte[] { 0x4D, 0x5A, 0x90, 0x00, 0x03, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0xFF, 0xFF },
                Description = "ZoneAlam data file"
            },
            new Signature()
            {
                Extension = Extension.ZIP,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                Description = "PKZIP archive_1"
            },
            new Signature()
            {
                Extension = Extension.ZIP,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x4C, 0x49, 0x54, 0x45 },
                Description = "PKLITE archive"
            },
            new Signature()
            {
                Extension = Extension.ZIP,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x53, 0x70, 0x58 },
                Description = "PKSFX self-extracting archive"
            },
            new Signature()
            {
                Extension = Extension.ZIP,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x05, 0x06 },
                Description = "PKZIP archive_2"
            },
            new Signature()
            {
                Extension = Extension.ZIP,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x07, 0x08 },
                Description = "PKZIP archive_3"
            },
            new Signature()
            {
                Extension = Extension.ZIP,
                MagicBytes = new byte[] { 0x57, 0x69, 0x6E, 0x5A, 0x69, 0x70 },
                Description = "WinZip compressed archive"
            },
            new Signature()
            {
                Extension = Extension.ZIP,
                MagicBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x01, 0x00 },
                Description = "ZLock Pro encrypted ZIP"
            },
            new Signature()
            {
                Extension = Extension.ZOO,
                MagicBytes = new byte[] { 0x5A, 0x4F, 0x4F, 0x20 },
                Description = "ZOO compressed archive"
            }
        };
    }
}