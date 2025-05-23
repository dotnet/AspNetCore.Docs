/*
    This sample allows to compare "big files" byte by byte which FileManagerSample emits.
    Look at FileManagerSample to understand how working with "big files" can be done in aspnetcore.
*/

string targetFilePath = @"D:\code\AspNetCore.Docs\aspnetcore\mvc\models\file-uploads\samples\9.x\FileManagerSample\file-upload.dat";
// string originalFilePath = @"D:\.other\big-files\bigfile.dat";
string originalFilePath = @"D:\.other\big-files\bigfile.dat";

try
{
    if (!File.Exists(targetFilePath))
    {
        Console.WriteLine($"Error: File '{targetFilePath}' does not exist.");
        return;
    }
    if (!File.Exists(originalFilePath))
    {
        Console.WriteLine($"Error: File '{originalFilePath}' does not exist.");
        return;
    }

    using var file1Stream = File.OpenRead(targetFilePath);
    using var file2Stream = File.OpenRead(originalFilePath);

    if (file1Stream.Length != file2Stream.Length)
    {
        Console.WriteLine("Files are different: Their sizes do not match.");
        return;
    }

    const int bufferSize = 8192; // 8 KB buffer
    byte[] buffer1 = new byte[bufferSize];
    byte[] buffer2 = new byte[bufferSize];

    int bytesRead1, bytesRead2;
    long position = 0;
    int chunksProcessed = 0;

    while ((bytesRead1 = file1Stream.Read(buffer1, 0, bufferSize)) > 0 &&
           (bytesRead2 = file2Stream.Read(buffer2, 0, bufferSize)) > 0)
    {
        for (int i = 0; i < bytesRead1; i++)
        {
            if (buffer1[i] != buffer2[i])
            {
                Console.WriteLine($"Files are different: Mismatch at byte position {position + i}");
                return;
            }
        }

        position += bytesRead1;
        Console.WriteLine($"Validated {++chunksProcessed}th {bufferSize} bytes");
    }

    Console.WriteLine("----");
    Console.WriteLine("Files are identical.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
