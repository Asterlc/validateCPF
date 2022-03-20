using cpfSupera.Models;
using cpfSupera.Database;
using Microsoft.EntityFrameworkCore;


namespace cpfSupera.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly CPFContext _context;

        public DocumentRepository(CPFContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<cpfModel>> SearchDocuments()
        {
            return await _context.cpfModel.ToListAsync();
        }
        public async Task<cpfModel> SearchDocumentById(int id)
        {
            return await _context.cpfModel.Where(element => element.Id == id).FirstOrDefaultAsync();
        }
        public void AddDocument(cpfModel document)
        {
            _context.Add(document);
        }
        public void UpdateDocument(cpfModel document)
        {
            _context.Update(document);
        }
        public void DeleteDocument(cpfModel document)
        {
            _context.Remove(document);
        }
        public async Task<bool> saveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}