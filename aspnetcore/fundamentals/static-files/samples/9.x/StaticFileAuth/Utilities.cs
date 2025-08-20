namespace StaticFilesAuth;

public static class Utilities
{
    public static Dictionary<string, List<byte[]>> AllowedFileSignatures = new()
    {
        {
            ".jpeg", new List<byte[]>
            {
                new byte[] {0xFF, 0xD8, 0xFF, 0xE0},
                new byte[] {0xFF, 0xD8, 0xFF, 0xE2},
                new byte[] {0xFF, 0xD8, 0xFF, 0xE3}
            }
        },
        {
            ".png", new List<byte[]>
            {
                new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A}
            }
        }
    };
    
    public static bool IsFileValid(IFormFile file)
    {
        using var reader = new BinaryReader(file.OpenReadStream());
    
        var signatures = AllowedFileSignatures
            .Values
            .SelectMany(x => x)
            .ToList();
        
        var headerBytes = reader.ReadBytes(AllowedFileSignatures
            .Max(m => m.Value.Max(n => n.Length)));

        return signatures
            .Any(signature => headerBytes
                .Take(signature.Length)
                .SequenceEqual(signature));
    }
}
