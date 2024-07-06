using Core.Containers.Interfaces;

namespace DataAccess.Repositories
{
    public class ContainerRepository : IContainerRepository
    {
        AppDbContext _context;
        public ContainerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Container container)
        {
            await Task.Run(() => _context.Set<Container>().Add(container));
        }

        public async Task DeleteAsync(Guid id)
        {
            Container container = new Container() { Id = id };
            await Task.Run(() => _context.Set<Container>().Remove(container));
        }

        public async Task<Container?> FindByIdAsync(Guid id)
        {
            return await _context.Set<Container>().FindAsync(id);
        }

        public async Task<IEnumerable<Container>> GetAllAsync()
        {
            IEnumerable<Container> result = await Task.Run(() => _context.Set<Container>().ToList());
            return result;
        }

        public async Task UpdateAsync(Container container)
        {
            await Task.Run(() => _context.Set<Container>().Update(container));
        }
    }
}
