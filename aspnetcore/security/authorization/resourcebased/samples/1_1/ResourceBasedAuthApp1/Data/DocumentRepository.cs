using ResourceBasedAuthApp1.Models;
using System;

namespace ResourceBasedAuthApp1.Data
{
    public class DocumentRepository : IDocumentRepository
    {
        public Document Find(Guid documentId)
        {
            return new Document
            {
                Author = "john.doe@microsoft.com",
                Content = null,
                ID = documentId,
                Title = "Test Document"
            };
        }
    }

    public interface IDocumentRepository
    {
        Document Find(Guid documentId);
    }
}
