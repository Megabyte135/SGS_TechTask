using Core;
using Core.Containers.Interfaces;
using Core.Operations.Interfaces;
using DataAccess.EntityTypeConfigurations;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : DbContext, IUnitOfWork
{
    IContainerRepository _containerRepository;
    IOperationRepository _operationRepository;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Container> Containers { get; set; }
    public virtual DbSet<Operation> Operations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ContainerEntityTypeConfiguration()
            .Configure(modelBuilder.Entity<Container>());
        new OperationEntityTypeConfiguration()
            .Configure(modelBuilder.Entity<Operation>());
        new OperatorEntityTypeConfiguration()
            .Configure(modelBuilder.Entity<Operator>());

    }

    public IContainerRepository ContainerRepository()
    {
        if (_containerRepository == null)
        {
            _containerRepository = new ContainerRepository(this);
        }
        return _containerRepository;
    }

    public IOperationRepository OperationRepository()
    {
        if (_operationRepository == null)
        {
            _operationRepository = new OperationRepository(this);
        }
        return _operationRepository;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken);
    }
}
