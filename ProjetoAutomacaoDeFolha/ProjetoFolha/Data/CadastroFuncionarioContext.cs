using Microsoft.EntityFrameworkCore;
using ProjetoFolha.Models;

namespace ProjetoFolha.Data;

public class CadastroFuncionarioContext : DbContext
{
    public CadastroFuncionarioContext(DbContextOptions<CadastroFuncionarioContext> opts) : base(opts)
    {

    }

    public DbSet<CadastroFuncionarioModel> CadastroFuncionarioModel { get; set; }

    public DbSet<SetorModel> SetorModel { get; set; }

}
