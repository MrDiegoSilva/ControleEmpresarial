using ControleEmpresarial.Estoque.Data.Context;
using ControleEmpresarial.Estoque.Data.Interfaces;

namespace ControleEmpresarial.Estoque.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private EstoqueContext _context;

        public UnitOfWork(EstoqueContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
            _context = null;
        }
    }
}