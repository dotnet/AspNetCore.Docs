using System.Text;
using Fido2NetLib;
using Microsoft.EntityFrameworkCore;
using OpeniddictServer.Data;

namespace Fido2Identity;

public class Fido2Store
{
    private readonly ApplicationDbContext _applicationDbContext;

    public Fido2Store(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<ICollection<FidoStoredCredential>> GetCredentialsByUserNameAsync(string username)
    {
        return await _applicationDbContext.FidoStoredCredential.Where(c => c.UserName == username).ToListAsync();
    }

    public async Task RemoveCredentialsByUserNameAsync(string username)
    {
        var items = await _applicationDbContext.FidoStoredCredential.Where(c => c.UserName == username).ToListAsync();
        if (items != null)
        {
            foreach (var fido2Key in items)
            {
                _applicationDbContext.FidoStoredCredential.Remove(fido2Key);
            };

            await _applicationDbContext.SaveChangesAsync();
        }
    }

    public async Task<FidoStoredCredential?> GetCredentialByIdAsync(byte[] id)
    {
        var credentialIdString = Base64Url.Encode(id);
        //byte[] credentialIdStringByte = Base64Url.Decode(credentialIdString);

        var cred = await _applicationDbContext.FidoStoredCredential
            .Where(c => c.DescriptorJson != null && c.DescriptorJson.Contains(credentialIdString))
            .FirstOrDefaultAsync();

        return cred;
    }

    public Task<ICollection<FidoStoredCredential>> GetCredentialsByUserHandleAsync(byte[] userHandle)
    {
        return Task.FromResult<ICollection<FidoStoredCredential>>(
            _applicationDbContext
                .FidoStoredCredential.Where(c => c.UserHandle != null && c.UserHandle.SequenceEqual(userHandle))
                .ToList());
    }

    public async Task UpdateCounterAsync(byte[] credentialId, uint counter)
    {
        var credentialIdString = Base64Url.Encode(credentialId);
        //byte[] credentialIdStringByte = Base64Url.Decode(credentialIdString);

        var cred = await _applicationDbContext.FidoStoredCredential
            .Where(c => c.DescriptorJson != null && c.DescriptorJson.Contains(credentialIdString)).FirstOrDefaultAsync();

        if (cred != null)
        {
            cred.SignatureCounter = counter;
            await _applicationDbContext.SaveChangesAsync();
        }
    }

    public async Task AddCredentialToUserAsync(Fido2User user, FidoStoredCredential credential)
    {
        credential.UserId = user.Id;
        _applicationDbContext.FidoStoredCredential.Add(credential);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<ICollection<Fido2User>> GetUsersByCredentialIdAsync(byte[] credentialId)
    {
        var credentialIdString = Base64Url.Encode(credentialId);
        //byte[] credentialIdStringByte = Base64Url.Decode(credentialIdString);

        var cred = await _applicationDbContext.FidoStoredCredential
            .Where(c => c.DescriptorJson != null && c.DescriptorJson.Contains(credentialIdString)).FirstOrDefaultAsync();

        if (cred == null || cred.UserId == null)
        {
            return new List<Fido2User>();
        }

        return await _applicationDbContext.Users
                .Where(u => Encoding.UTF8.GetBytes(u.UserName)
                .SequenceEqual(cred.UserId))
                .Select(u => new Fido2User
                {
                    DisplayName = u.UserName,
                    Name = u.UserName,
                    Id = Encoding.UTF8.GetBytes(u.UserName) // byte representation of userID is required
                }).ToListAsync();
    }
}

public static class Fido2Extenstions
{
    public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> enumerable) where T : class
    {
        return enumerable.Where(e => e != null).Select(e => e!);
    }
}