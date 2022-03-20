using cpfSupera.Models;

namespace cpfSupera.Repository
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<cpfModel>> SearchDocuments();
        Task<cpfModel> SearchDocumentById(int id);
        void AddDocument(cpfModel document);
        void UpdateDocument(cpfModel document);
        void DeleteDocument(cpfModel document);
        Task<bool> saveChangesAsync();
    }
}