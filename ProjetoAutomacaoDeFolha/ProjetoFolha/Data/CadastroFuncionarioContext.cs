using Microsoft.EntityFrameworkCore;
using MySqlConnector;
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

    /* Método para cadastrar o usuário administrador e os setores
    public void CadastrarUsuarioESetores()
    {
        using (var connection = new MySqlConnection("server=localhost;database=folhapagamento;user=root;password=12345"))
        {
            connection.Open();

            // Cadastro do usuário administrador
            using (var command = new MySqlCommand(
                "INSERT INTO `folhapagamento`.`cadastrofuncionariomodel` " +
                "(`Cod_Fun`, `nome`, `cpf`, `cargo`, `dataAdmissao`, `email`, `senha`, `sexoSelecionado`, `salarioBruto`, `dataCadastro`, `Perfil`, `Id_ST`) " +
                "VALUES ('1', 'User Administrador', '010.010.010-10', 'Administrador', '2023-10-20', 'admin@admin.com', 'YWFh', " +
                "'Não Informado', '1320', '2023-10-20 00:00:00.000000', '1', '1')", connection))
            {
                command.ExecuteNonQuery();
            }

            // Cadastro dos setores
            string[] setores = { "Administrador", "Desenvolvimento", "Almoxerifado", "DBA" };

            foreach (var setor in setores)
            {
                using (var command = new MySqlCommand(
                    "INSERT INTO `folhapagamento`.`setormodel` (`Id_ST`, `Descricao`) " +
                    $"VALUES (NULL, '{setor}')", connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        // Se ocorrer um erro de chave duplicada, o setor já existe, e você pode lidar com isso conforme necessário
                        if (ex.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
                        {
                            Console.WriteLine($"O setor '{setor}' já está cadastrado.");
                        }
                        else
                        {
                            // Outros erros, você pode lidar conforme necessário
                            Console.WriteLine($"Erro ao cadastrar o setor '{setor}': {ex.Message}");
                        }
                    }
                }
            }
        }
    }*/

}
