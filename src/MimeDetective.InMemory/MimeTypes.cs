using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace MimeDetective.InMemory
{
    public static class MimeTypes
    {
        static MimeTypes()
        {
            AllTypes = new List<FileType> 
            { 
                PDF, WORD, EXCEL, JPEG, ZIP, RAR, RTF, PNG, PPT, GIF, DLL_EXE, MSDOC,
                BMP, DLL_EXE, /*ZIP_7z,*/ ZIP_7z_2, GZ_TGZ, TAR_ZH, TAR_ZV, OGG, ICO, XML, MIDI, FLV, WAVE, DWG, DEB, PST, PSD,
                AES, SKR, SKR_2, PKR, EML_FROM, ELF, TXT_UTF8, TXT_UTF16_BE, TXT_UTF16_LE, TXT_UTF32_BE, TXT_UTF32_LE, TIFF, BZ2,
                PYC_1_5, PYC_1_6, PYC_2_0, PYC_2_1, PYC_2_2, PYC_2_3_A0_1, PYC_2_3_A0_2, PYC_2_3_A0_3, PYC_2_4_A0, PYC_2_4_A3, PYC_2_4_B1,
                PYC_2_5_A0_1, PYC_2_5_A0_2, PYC_2_5_A0_3, PYC_2_5_A0_4, PYC_2_5_B3_1, PYC_2_5_B3_2, PYC_2_5_C1, PYC_2_5_C2, PYC_2_6_A0,
                PYC_2_6_A1, PYC_2_7_A0_1, PYC_2_7_A0_2, PYC_2_7_A0_3, PYC_2_7_A0_4, PYC_2_7_A0_5, PYC_3_0_1, PYC_3_0_2, PYC_3_0_3, PYC_3_0_4,
                PYC_3_0_5, PYC_3_0_6, PYC_3_0_7, PYC_3_0_7, PYC_3_0_8, PYC_3_0_9, PYC_3_0_10, PYC_3_0_11, PYC_3_0_12, PYC_3_0_13, PYC_3_0_A4,
                PYC_3_0_A5, PYC_3_1_A0_1, PYC_3_1_A0_2, PYC_3_2_A0, PYC_3_2_A1, PYC_3_2_A2, PYC_3_3_A0_1, PYC_3_3_A0_2, PYC_3_3_A1, PYC_3_3_A4,
                PYC_3_4_A1_1, PYC_3_4_A1_2, PYC_3_4_A1_3, PYC_3_4_A1_4, PYC_3_4_A4_1, PYC_3_4_A4_2, PYC_3_4_RC2, PYC_3_5_A0, PYC_3_5_B1,
                PYC_3_5_B2_1, PYC_3_5_B2_2, PYC_3_5_2, PYC_3_6_A0_1, PYC_3_6_A0_2, PYC_3_6_A1_1, PYC_3_6_A1_2, PYC_3_6_A1_3, PYC_3_6_A1_4,
                PYC_3_6_B1_1, PYC_3_6_B1_2, PYC_3_6_B1_3, PYC_3_6_B2, PYC_3_6_RC2, PYC_3_7_A1, PYC_3_7_A2, PYC_3_7_A4, PYC_3_7_B1, PYC_3_7_B5,
                MKVAS3D_WEBM, ISO_1, ISO_2, ISO_3, MPEGTS, VMDK, NVRAM, PCAP_1, PCAP_2, PCAPNG, SQLITEDB, TTF
            };
        }

        public static List<FileType> AllTypes { get; }

        #region Constants

        #region Temp

        // office and documents
        public static readonly FileType WORD = new FileType(new byte?[] { 0xEC, 0xA5, 0xC1, 0x00 }, 512, "doc", "application/msword");
        public static readonly FileType EXCEL = new FileType(new byte?[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 }, 512, "xls", "application/excel");
        public static readonly FileType PPT = new FileType(new byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, null, 0x00, 0x00, 0x00 }, 512, "ppt", "application/mspowerpoint");

        //ms office and openoffice docs (they're zip files: rename and enjoy!)
        //don't add them to the list, as they will be 'subtypes' of the ZIP type
        public static readonly FileType WORDX = new FileType(new byte?[0], 512, "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        public static readonly FileType EXCELX = new FileType(new byte?[0], 512, "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        public static readonly FileType PPTX = new FileType(new byte?[0], 512, "pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");
        public static readonly FileType VSDX = new FileType(new byte?[0], 512, "vsdx", "application/vnd-ms-visio.drawing");
        public static readonly FileType ODT = new FileType(new byte?[0], 512, "odt", "application/vnd.oasis.opendocument.text");
        public static readonly FileType ODS = new FileType(new byte?[0], 512, "ods", "application/vnd.oasis.opendocument.spreadsheet");

        // common documents
        public static readonly FileType RTF = new FileType(new byte?[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 }, "rtf", "application/rtf");
        public static readonly FileType PDF = new FileType(new byte?[] { 0x25, 0x50, 0x44, 0x46 }, "pdf", "application/pdf");
        public static readonly FileType MSDOC = new FileType(new byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }, "", "application/octet-stream");

        //application/xml text/xml
        public static readonly FileType XML = new FileType(new byte?[] { 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x22, 0x31, 0x2E, 0x30, 0x22, 0x3F, 0x3E }, "xml,xul", "text/xml");

        //text files
        public static readonly FileType TXT = new FileType(new byte?[0], "txt", "text/plain");
        public static readonly FileType TXT_UTF8 = new FileType(new byte?[] { 0xEF, 0xBB, 0xBF }, "txt", "text/plain");
        public static readonly FileType TXT_UTF16_BE = new FileType(new byte?[] { 0xFE, 0xFF }, "txt", "text/plain");
        public static readonly FileType TXT_UTF16_LE = new FileType(new byte?[] { 0xFF, 0xFE }, "txt", "text/plain");
        public static readonly FileType TXT_UTF32_BE = new FileType(new byte?[] { 0x00, 0x00, 0xFE, 0xFF }, "txt", "text/plain");
        public static readonly FileType TXT_UTF32_LE = new FileType(new byte?[] { 0xFF, 0xFE, 0x00, 0x00 }, "txt", "text/plain");

        //images
        public static readonly FileType JPEG = new FileType(new byte?[] { 0xFF, 0xD8, 0xFF }, "jpg", "image/jpeg");
        public static readonly FileType PNG = new FileType(new byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "png", "image/png");
        public static readonly FileType GIF = new FileType(new byte?[] { 0x47, 0x49, 0x46, 0x38, null, 0x61 }, "gif", "image/gif");
        public static readonly FileType BMP = new FileType(new byte?[] { 66, 77 }, "bmp", "image/bmp");
        public static readonly FileType ICO = new FileType(new byte?[] { 0, 0, 1, 0 }, "ico", "image/x-icon");
        public static readonly FileType TIFF = new FileType(new byte?[] { 0x49, 0x49, 0x2A, 0x00 }, "tif", "image/tiff");

        //archives
        public static readonly FileType GZ_TGZ = new FileType(new byte?[] { 0x1F, 0x8B, 0x08 }, "gz, tgz", "application/x-gz");

        //public static readonly FileType ZIP_7z = new FileType(new byte?[] { 66, 77 }, "7z", "application/x-7z-compressed");
        public static readonly FileType ZIP_7z_2 = new FileType(new byte?[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C }, "7z", "application/x-7z-compressed");

        public static readonly FileType ZIP = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "zip", "application/x-compressed");
        public static readonly FileType RAR = new FileType(new byte?[] { 0x52, 0x61, 0x72, 0x21 }, "rar", "application/x-rar-compressed");
        public static readonly FileType DLL_EXE = new FileType(new byte?[] { 0x4D, 0x5A }, "dll, exe", "application/octet-stream");

        //Compressed tape archive file using standard (Lempel-Ziv-Welch) compression
        public static readonly FileType TAR_ZV = new FileType(new byte?[] { 0x1F, 0x9D }, "tar.z", "application/x-tar");

        //Compressed tape archive file using LZH (Lempel-Ziv-Huffman) compression
        public static readonly FileType TAR_ZH = new FileType(new byte?[] { 0x1F, 0xA0 }, "tar.z", "application/x-tar");

        //bzip2 compressed archive
        public static readonly FileType BZ2 = new FileType(new byte?[] { 0x42, 0x5A, 0x68 }, "bz2,tar,bz2,tbz2,tb2", "application/x-bzip2");

        // NuGet package
        public static readonly FileType NUPKG = new FileType(new byte?[0], "nupkg", "application/x-compressed");

        // Epub
        public static readonly FileType EPUB = new FileType(new byte?[0], "epub", "application/epub+zip");

        // media
        public static readonly FileType OGG = new FileType(new byte?[] { 0x4f, 0x67, 0x67, 0x53 }, "oga,ogg,ogv,ogx", "application/ogg");

        //MID, MIDI     Musical Instrument Digital Interface (MIDI) sound file
        public static readonly FileType MIDI = new FileType(new byte?[] { 0x4D, 0x54, 0x68, 0x64 }, "midi,mid", "audio/midi");

        //FLV       Flash video file
        public static readonly FileType FLV = new FileType(new byte?[] { 0x46, 0x4C, 0x56, 0x01 }, "flv", "application/unknown");

        //WAV       Resource Interchange File Format -- Audio for Windows file, where xx xx xx xx is the file size (little endian), audio/wav audio/x-wav
        public static readonly FileType WAVE = new FileType(new byte?[] { 0x52, 0x49, 0x46, 0x46, null, null, null, null,
                                                            0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20 }, "wav", "audio/wav");

        public static readonly FileType PST = new FileType(new byte?[] { 0x21, 0x42, 0x44, 0x4E }, "pst", "application/octet-stream");

        //MPEG Transport Stream (MPEG-2 Part 1)
        public static readonly FileType MPEGTS = new FileType(
            new byte?[]
            {
                0x47, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, 0x47
            }, "ts,tsv,tsa", "video/mp2t");

        //MKV,MKA,MKS,MK3D,WEBM
        public static readonly FileType MKVAS3D_WEBM = new FileType(new byte?[] { 0x1a, 0x45, 0xdf, 0xa3 }, "mkv,mka,mks,mk3d,webm", "video/x-matroska");

        //Generic AutoCAD drawing image/vnd.dwg  image/x-dwg application/acad
        public static readonly FileType DWG = new FileType(new byte?[] { 0x41, 0x43, 0x31, 0x30 }, "dwg", "application/acad");

        //Photoshop image file
        public static readonly FileType PSD = new FileType(new byte?[] { 0x38, 0x42, 0x50, 0x53 }, "psd", "application/octet-stream");

        //deb  linux deb file
        public static readonly FileType DEB = new FileType(new byte?[] { 0x21, 0x3C, 0x61, 0x72, 0x63, 0x68, 0x3E }, "deb", "application/vnd.debian.binary-package");

        //AES Crypt file format. (The fourth byte is the version number.)
        public static readonly FileType AES = new FileType(new byte?[] { 0x41, 0x45, 0x53 }, "aes", "application/octet-stream");

        //SKR       PGP secret keyring file
        public static readonly FileType SKR = new FileType(new byte?[] { 0x95, 0x00 }, "skr", "application/octet-stream");

        //SKR       PGP secret keyring file
        public static readonly FileType SKR_2 = new FileType(new byte?[] { 0x95, 0x01 }, "skr", "application/octet-stream");

        //PKR       PGP public keyring file
        public static readonly FileType PKR = new FileType(new byte?[] { 0x99, 0x01 }, "pkr", "application/octet-stream");

        /*
         * 46 72 6F 6D 20 20 20 or      From
        46 72 6F 6D 20 3F 3F 3F or      From ???
        46 72 6F 6D 3A 20       From:
        EML     A commmon file extension for e-mail files. Signatures shown here
        are for Netscape, Eudora, and a generic signature, respectively.
        EML is also used by Outlook Express and QuickMail.
         */
        public static readonly FileType EML_FROM = new FileType(new byte?[] { 0x46, 0x72, 0x6F, 0x6D }, "eml", "message/rfc822");


        //EVTX      Windows Vista event log file
        public static readonly FileType ELF = new FileType(new byte?[] { 0x45, 0x6C, 0x66, 0x46, 0x69, 0x6C, 0x65, 0x00 }, "elf", "text/plain");

        //ISO
        public static readonly FileType ISO_1 = new FileType(new byte?[] { 0x43, 0x44, 0x30, 0x30, 0x31 }, 32769, "iso,img,cdr,dvdr", "application/x-iso-image");
        public static readonly FileType ISO_2 = new FileType(new byte?[] { 0x43, 0x44, 0x30, 0x30, 0x31 }, 34817, "iso,img,cdr,dvdr", "application/x-iso-image");
        public static readonly FileType ISO_3 = new FileType(new byte?[] { 0x43, 0x44, 0x30, 0x30, 0x31 }, 36865, "iso,img,cdr,dvdr", "application/x-iso-image");

        //VMDK
        public static readonly FileType VMDK = new FileType(new byte?[] { 0x4b, 0x44, 0x4d, 0x56, 0x01 }, "vmdk", "application/octet-stream");

        //NVRAM
        public static readonly FileType NVRAM = new FileType(new byte?[] { 0x4d, 0x52, 0x56, 0x4e, 0x01 }, "nvram", "application/octet-stream");

        //PCAP Libpcap File Format
        public static readonly FileType PCAP_1 = new FileType(new byte?[] { 0xa1, 0xb2, 0xc3, 0xd4 }, "pcap", "application/vnd.tcpdump.pcap");
        public static readonly FileType PCAP_2 = new FileType(new byte?[] { 0xd4, 0xc3, 0xb2, 0xa1 }, "pcap", "application/vnd.tcpdump.pcap");

        //PCAPNG PCAP Next Generation Dump File Format
        public static readonly FileType PCAPNG = new FileType(new byte?[] { 0x0a, 0x0d, 0x0d, 0x0a }, "pcapng", "application/octet-stream");

        //SQLite Database
        public static readonly FileType SQLITEDB =
            new FileType(
                new byte?[]
                {
                    0x53, 0x51, 0x4c, 0x69, 0x74, 0x65, 0x20, 0x66, 0x6f, 0x72, 0x6d, 0x61, 0x74, 0x20, 0x33, 0x00
                }, "db,sqlitedb,sqlite", "application/x-sqlite3");

        //TTF Font
        public static readonly FileType TTF = new FileType(new byte?[] { 0x00, 0x01, 0x00, 0x00, 0x00 }, "ttf,ttc", "application/x-font-ttf");

        #endregion
        #region Python

        // Python 1
        public static readonly FileType PYC_1_5 = new FileType(new byte?[] { 0x99, 0x4e }, "pyc", "application/octet-stream", "Python 1.5/1.5.1/1.5.2");
        public static readonly FileType PYC_1_6 = new FileType(new byte?[] { 0x4c, 0xc4 }, "pyc", "application/octet-stream", "Python 1.6");

        // Python 2
        public static readonly FileType PYC_2_0 = new FileType(new byte?[] { 0x87, 0xc6 }, "pyc", "application/octet-stream", "Python 2.0/2.0.1");
        public static readonly FileType PYC_2_1 = new FileType(new byte?[] { 0x2a, 0xeb }, "pyc", "application/octet-stream", "Python 2.1/2.1.1/2.1.2");
        public static readonly FileType PYC_2_2 = new FileType(new byte?[] { 0x2d, 0xed }, "pyc", "application/octet-stream", "Python 2.2");
        public static readonly FileType PYC_2_3_A0_1 = new FileType(new byte?[] { 0x3b, 0xf2 }, "pyc", "application/octet-stream", "Python 2.3a0");
        public static readonly FileType PYC_2_3_A0_2 = new FileType(new byte?[] { 0x45, 0xf2 }, "pyc", "application/octet-stream", "Python 2.3a0");
        public static readonly FileType PYC_2_3_A0_3 = new FileType(new byte?[] { 0x3b, 0xf2 }, "pyc", "application/octet-stream", "Python 2.3a0");
        public static readonly FileType PYC_2_4_A0 = new FileType(new byte?[] { 0x59, 0xf2 }, "pyc", "application/octet-stream", "Python 2.4a0");
        public static readonly FileType PYC_2_4_A3 = new FileType(new byte?[] { 0x63, 0xf2 }, "pyc", "application/octet-stream", "Python 2.4a3");
        public static readonly FileType PYC_2_4_B1 = new FileType(new byte?[] { 0x6d, 0xf2 }, "pyc", "application/octet-stream", "Python 2.4b1");
        public static readonly FileType PYC_2_5_A0_1 = new FileType(new byte?[] { 0x77, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5a0");
        public static readonly FileType PYC_2_5_A0_2 = new FileType(new byte?[] { 0x81, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5a0");
        public static readonly FileType PYC_2_5_A0_3 = new FileType(new byte?[] { 0x8b, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5a0");
        public static readonly FileType PYC_2_5_A0_4 = new FileType(new byte?[] { 0x8c, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5a0");
        public static readonly FileType PYC_2_5_B3_1 = new FileType(new byte?[] { 0x95, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5b3");
        public static readonly FileType PYC_2_5_B3_2 = new FileType(new byte?[] { 0x9f, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5b3");
        public static readonly FileType PYC_2_5_C1 = new FileType(new byte?[] { 0xa9, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5c1");
        public static readonly FileType PYC_2_5_C2 = new FileType(new byte?[] { 0xb3, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5c2");
        public static readonly FileType PYC_2_6_A0 = new FileType(new byte?[] { 0xc7, 0xf2 }, "pyc", "application/octet-stream", "Python 2.6a0");
        public static readonly FileType PYC_2_6_A1 = new FileType(new byte?[] { 0xd1, 0xf2 }, "pyc", "application/octet-stream", "Python 2.6a1");
        public static readonly FileType PYC_2_7_A0_1 = new FileType(new byte?[] { 0xdb, 0xf2 }, "pyc", "application/octet-stream", "Python 2.7a0");
        public static readonly FileType PYC_2_7_A0_2 = new FileType(new byte?[] { 0xe5, 0xf2 }, "pyc", "application/octet-stream", "Python 2.7a0");
        public static readonly FileType PYC_2_7_A0_3 = new FileType(new byte?[] { 0xef, 0xf2 }, "pyc", "application/octet-stream", "Python 2.7a0");
        public static readonly FileType PYC_2_7_A0_4 = new FileType(new byte?[] { 0xf9, 0xf2 }, "pyc", "application/octet-stream", "Python 2.7a0");
        public static readonly FileType PYC_2_7_A0_5 = new FileType(new byte?[] { 0x03, 0xf3 }, "pyc", "application/octet-stream", "Python 2.7a0");

        // Python 3
        public static readonly FileType PYC_3_0_1 = new FileType(new byte?[] { 0xb8, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_2 = new FileType(new byte?[] { 0xc2, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_3 = new FileType(new byte?[] { 0xcc, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_4 = new FileType(new byte?[] { 0xd6, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_5 = new FileType(new byte?[] { 0xe0, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_6 = new FileType(new byte?[] { 0xea, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_7 = new FileType(new byte?[] { 0xf4, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_8 = new FileType(new byte?[] { 0xf5, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_9 = new FileType(new byte?[] { 0xff, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_10 = new FileType(new byte?[] { 0x09, 0x0c }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_11 = new FileType(new byte?[] { 0x13, 0x0c }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_12 = new FileType(new byte?[] { 0x1d, 0x0c }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_13 = new FileType(new byte?[] { 0x1f, 0x0c }, "pyc", "application/octet-stream", "Python 3.0");
        public static readonly FileType PYC_3_0_A4 = new FileType(new byte?[] { 0x27, 0x0c }, "pyc", "application/octet-stream", "Python 3.0a4");
        public static readonly FileType PYC_3_0_A5 = new FileType(new byte?[] { 0x3b, 0x0c }, "pyc", "application/octet-stream", "Python 3.0a5");

        // Python 3.1
        public static readonly FileType PYC_3_1_A0_1 = new FileType(new byte?[] { 0x45, 0x0c }, "pyc", "application/octet-stream", "Python 3.1a0");
        public static readonly FileType PYC_3_1_A0_2 = new FileType(new byte?[] { 0x4f, 0x0c }, "pyc", "application/octet-stream", "Python 3.1a0");

        // Python 3.2
        public static readonly FileType PYC_3_2_A0 = new FileType(new byte?[] { 0x58, 0x0c }, "pyc", "application/octet-stream", "Python 3.2a0");
        public static readonly FileType PYC_3_2_A1 = new FileType(new byte?[] { 0x62, 0x0c }, "pyc", "application/octet-stream", "Python 3.2a1");
        public static readonly FileType PYC_3_2_A2 = new FileType(new byte?[] { 0x6c, 0x0c }, "pyc", "application/octet-stream", "Python 3.2a2");

        // Python 3.3
        public static readonly FileType PYC_3_3_A0_1 = new FileType(new byte?[] { 0x76, 0x0c }, "pyc", "application/octet-stream", "Python 3.3a0");
        public static readonly FileType PYC_3_3_A0_2 = new FileType(new byte?[] { 0x80, 0x0c }, "pyc", "application/octet-stream", "Python 3.3a0");
        public static readonly FileType PYC_3_3_A1 = new FileType(new byte?[] { 0x94, 0x0c }, "pyc", "application/octet-stream", "Python 3.3a1");
        public static readonly FileType PYC_3_3_A4 = new FileType(new byte?[] { 0x9e, 0x0c }, "pyc", "application/octet-stream", "Python 3.3a4");

        // Python 3.4
        public static readonly FileType PYC_3_4_A1_1 = new FileType(new byte?[] { 0xb2, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a1");
        public static readonly FileType PYC_3_4_A1_2 = new FileType(new byte?[] { 0xbc, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a1");
        public static readonly FileType PYC_3_4_A1_3 = new FileType(new byte?[] { 0xc6, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a1");
        public static readonly FileType PYC_3_4_A1_4 = new FileType(new byte?[] { 0xd0, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a1");
        public static readonly FileType PYC_3_4_A4_1 = new FileType(new byte?[] { 0xda, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a4");
        public static readonly FileType PYC_3_4_A4_2 = new FileType(new byte?[] { 0xe4, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a4");
        public static readonly FileType PYC_3_4_RC2 = new FileType(new byte?[] { 0xee, 0x0c }, "pyc", "application/octet-stream", "Python 3.4rc2");

        // Python 3.5
        public static readonly FileType PYC_3_5_A0 = new FileType(new byte?[] { 0xf8, 0x0c }, "pyc", "application/octet-stream", "Python 3.5a0");
        public static readonly FileType PYC_3_5_B1 = new FileType(new byte?[] { 0x20, 0xd0 }, "pyc", "application/octet-stream", "Python 3.5b1");
        public static readonly FileType PYC_3_5_B2_1 = new FileType(new byte?[] { 0xc0, 0xd0 }, "pyc", "application/octet-stream", "Python 3.5b2");
        public static readonly FileType PYC_3_5_B2_2 = new FileType(new byte?[] { 0x16, 0x0d }, "pyc", "application/octet-stream", "Python 3.5b2");
        public static readonly FileType PYC_3_5_2 = new FileType(new byte?[] { 0x17, 0x0d }, "pyc", "application/octet-stream", "Python 3.5.2");

        // Python 3.6
        public static readonly FileType PYC_3_6_A0_1 = new FileType(new byte?[] { 0x20, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a0");
        public static readonly FileType PYC_3_6_A0_2 = new FileType(new byte?[] { 0x21, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a0");
        public static readonly FileType PYC_3_6_A1_1 = new FileType(new byte?[] { 0x2a, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a1");
        public static readonly FileType PYC_3_6_A1_2 = new FileType(new byte?[] { 0x2b, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a1");
        public static readonly FileType PYC_3_6_A1_3 = new FileType(new byte?[] { 0x2c, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a1");
        public static readonly FileType PYC_3_6_A1_4 = new FileType(new byte?[] { 0x2d, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a1");
        public static readonly FileType PYC_3_6_B1_1 = new FileType(new byte?[] { 0x2f, 0x0d }, "pyc", "application/octet-stream", "Python 3.6b1");
        public static readonly FileType PYC_3_6_B1_2 = new FileType(new byte?[] { 0x30, 0x0d }, "pyc", "application/octet-stream", "Python 3.6b1");
        public static readonly FileType PYC_3_6_B1_3 = new FileType(new byte?[] { 0x31, 0x0d }, "pyc", "application/octet-stream", "Python 3.6b1");
        public static readonly FileType PYC_3_6_B2 = new FileType(new byte?[] { 0x32, 0x0d }, "pyc", "application/octet-stream", "Python 3.6b2");
        public static readonly FileType PYC_3_6_RC2 = new FileType(new byte?[] { 0x33, 0x0d }, "pyc", "application/octet-stream", "Python 3.6rc2");

        // Python 3.7
        public static readonly FileType PYC_3_7_A1 = new FileType(new byte?[] { 0x3e, 0x0d }, "pyc", "application/octet-stream", "Python 3.7a1");
        public static readonly FileType PYC_3_7_A2 = new FileType(new byte?[] { 0x3f, 0x0d }, "pyc", "application/octet-stream", "Python 3.7a2");
        public static readonly FileType PYC_3_7_A4 = new FileType(new byte?[] { 0x40, 0x0d }, "pyc", "application/octet-stream", "Python 3.7a4");
        public static readonly FileType PYC_3_7_B1 = new FileType(new byte?[] { 0x41, 0x0d }, "pyc", "application/octet-stream", "Python 3.7b1");
        public static readonly FileType PYC_3_7_B5 = new FileType(new byte?[] { 0x42, 0x0d }, "pyc", "application/octet-stream", "Python 3.7b5");

        // System.Net.IPAddress.NetworkToHostOrder(3394).ToString("x").Substring(0, 4)

        #endregion

        #endregion
    }
}
