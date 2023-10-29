using Microsoft.EntityFrameworkCore;
using ProjetoFolha.Data.Map;
using ProjetoFolha.Models;

namespace ProjetoFolha.Data;

public class CadastroFuncionarioContext : DbContext
{
    public CadastroFuncionarioContext(DbContextOptions<CadastroFuncionarioContext> opts) : base(opts)
    {

    }

    public DbSet<CadastroFuncionarioModel> CadastroFuncionarioModel { get; set; }

    public DbSet<SetorModel> SetorModel { get; set; }

    public DbSet<RecibosDePagamentoModel> RecibosDePagamentoModel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReciboMap());

        base.OnModelCreating(modelBuilder);
    }
}
