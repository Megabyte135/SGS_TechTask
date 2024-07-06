using Core;
using Core.Operations;
using Core.Operations.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccess.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        AppDbContext _context;
        public OperationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Operation operation)
        {
            await Task.Run(() => _context.Set<Operation>().Add(operation));
        }

        public async Task DeleteAsync(Guid id)
        {
            Operation container = new Operation() { Id = id };
            await Task.Run(() => _context.Set<Operation>().Remove(container));
        }

        public async Task<Operation?> FindByIdAsync(Guid id)
        {
            return await _context.Set<Operation>().FindAsync(id);
        }

        public async Task<IEnumerable<Operation>> GetAllAsync()
        {
            IEnumerable<Operation> result = await Task.Run(() => _context.Set<Operation>()
                .Include(u => u.Operator)
                .ToList()
                );
            return result;
        }

        public async Task<IEnumerable<Operation>> GetAllByContainerId(Guid id)
        {
            IEnumerable<Operation> result = await Task.Run(() => _context.Set<Operation>()
                .Where(u => u.ContainerId == id)
                .Include(u => u.Operator)
                .ToList()
                );
            return result;
        }

        public async Task UpdateAsync(Operation operation)
        {
            await Task.Run(() => _context.Set<Operation>().Update(operation));
        }
    }
}
