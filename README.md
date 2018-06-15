# MIME Detective In-Memory

Based on [https://github.com/Muraad/Mime-Detective](https://github.com/Muraad/Mime-Detective)

## Motivation
The main purpose of the library is to detect the real file type and to avoid uploading of the executable files. Unfortunately, the original library does exactly what it should prevent to do! It saves the file to the file system and then examines it. This approach is unacceptable because of security reasons and performance issues.

## How it works
The library contains a set of file signatures. Most of the files types have the same bytes on some predefined offset. They can be identified by this signature.  

## Special cases
Some file types are just renamed ZIP archives. To identify them the library uses names and content of the ZIP archive entries.

## ZIP bomb protection
There is a type of attack called _ZIP Bomb_. An attacker creates a huge file full of the same data sequences (e.g. 0xFF) that can be compressed to a few KB. When such file is being decompressed on the server it occupies all RAM and crushes the process.  
The library is protected from this type of attacks. It checks the size of the ZIP archive entries and does **not** decompress large archives.

## Usage
The library declares an extension method `DetectMimeType` for a byte array. This method returns an object of type `FileType`. In this object you can find the actual  MIME-type and extension of the file.