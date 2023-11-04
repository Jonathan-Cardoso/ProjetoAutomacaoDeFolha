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
        modelBuilder.Entity<RecibosDePagamentoModel>()
            .HasOne(f => f.CadastroFuncionarioModel)
            .WithMany(f => f.Recibos)
            .HasForeignKey(f => f.Cod_Fun)
            .IsRequired();

        modelBuilder.Entity<CadastroFuncionarioModel>()
            .HasMany(f => f.Recibos)
            .WithOne(f => f.CadastroFuncionarioModel)
            .IsRequired();

        modelBuilder.Entity<SetorModel>()
            .HasMany(f => f.CadastroFuncionarioModel)
            .WithOne(f => f.SetorModel)
            .IsRequired();


        base.OnModelCreating(modelBuilder);
    }


    /*public IQueryable<InformacoesCompletasModel> BuscarInformacoesCompletas()
    {
        var query = from funcionario in CadastroFuncionarioModel
                    join recibo in RecibosDePagamentoModel on funcionario.Id equals recibo.CadastroFuncionarioId
                    join setor in SetorModel on funcionario.SetorId equals setor.Id
                    select new InformacoesCompletasModel
                    {
                        FuncionarioId = funcionario.Id,
                        FuncionarioNome = funcionario.nome,
                        FuncionarioCpf = funcionario.cpf,
                        SetorDescricao = setor.Descricao,
                        SalarioBruto = recibo.SalarioBruto,
                        HorasExtras = recibo.HorasExtras,
                        DescontoINSS = recibo.DescontoINSS,
                        DescontoIR = recibo.DescontoIR,
                        TotalVencimentos = recibo.TotalVencimentos,
                        TotalDescontos = recibo.TotalDescontos,
                        SalarioLiquido = recibo.SalarioLiquido
                    };

        return query;
    }*/
}
