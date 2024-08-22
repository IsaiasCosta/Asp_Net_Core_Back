using Asp_Net_Core_Back.Data;
using Asp_Net_Core_Back.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_Back.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext _context;
        public AtividadeController(DataContext context)
        {

            _context = context;
        }
        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return _context.Atividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return _context.Atividades.FirstOrDefault(ati => ati.Id == id);
        }

        [HttpPost]
        public IEnumerable<Atividade> Post(Atividade atividade)
        {
            _context.Atividades.Add(atividade);

            return _context.SaveChanges() > 0
                ? _context.Atividades
                : throw new Exception("N�o foi possivel adicioanr atividade !!!");
        }
        [HttpPut("{id}")]
        public Atividade Put(int id, Atividade atividade)
        {
            var notification = atividade.Id != id
             ? "N�o � possivel atualizar atividades erradas !!! "
             : "Atividade Atualizada com sucesso";

            _context.Update(atividade);

            if (_context.SaveChanges() > 0)
                return _context.Atividades.FirstOrDefault(ativ => ativ.Id == id);
            else return new Atividade();

        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var atividade = _context.Atividades.FirstOrDefault(ativ => ativ.Id == id);
            if (atividade == null)
                throw new Exception("N�o � possivel deletar atividade que n�o existe !!!");
            _context.Remove(atividade);

            return _context.SaveChanges() > 0;

        }
    }
}
