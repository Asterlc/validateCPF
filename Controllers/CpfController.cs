using Microsoft.AspNetCore.Mvc;
using cpfSupera.Models;
using cpfSupera.Repository;

namespace cpfSupera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CpfController : ControllerBase
    {
        private readonly IDocumentRepository _repository;
        public CpfController(IDocumentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var documents = await _repository.SearchDocuments();
            return documents.Any()
                ? Ok(documents)
                : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var document = await _repository.SearchDocumentById(id);
            return document != null
                ? Ok(document)
                : NotFound("Documento não encontrado.");
        }
        [HttpPost]
        public async Task<IActionResult> Post(cpfModel document)
        {
            try
            {
                var validator = CPFUtils.IsCpf(document.Document);
                if (validator == false)
                {
                    return BadRequest(false);
                }

                _repository.AddDocument(document);
                return await _repository.saveChangesAsync()
                ? Ok("Documento adicionado com sucesso")
                : BadRequest("Erro ao salvar documento");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, cpfModel document)
        {
            try
            {
                var data = await _repository.SearchDocumentById(id);
                if (data == null) return NotFound("Não encontrado");
                var validator = CPFUtils.IsCpf(document.Document); //Valida baseado no documento recebido(body)
                if (validator == false)
                {
                    return BadRequest(false);
                }
                data.Name = document.Name ?? data.Name;
                data.Register = document.Register != new DateTime()
                    ? document.Register
                    : data.Register;

                _repository.UpdateDocument(data);
                return await _repository.saveChangesAsync()
                ? Ok("Documento atualizado")
                : BadRequest("Erro para atualizar documento");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _repository.SearchDocumentById(id);
            if (data == null) return NotFound("Não encontrado");
            _repository.DeleteDocument(data);
            return await _repository.saveChangesAsync()
            ? Ok("Usuário deletado")
            : BadRequest("Erro para deletar usuário");
        }
    }
}