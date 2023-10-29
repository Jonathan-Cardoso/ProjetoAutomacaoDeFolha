﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFolha.Models;

namespace ProjetoFolha.Data.Map
{
    public class ReciboMap : IEntityTypeConfiguration<RecibosDePagamentoModel>
    {
        public void Configure(EntityTypeBuilder<RecibosDePagamentoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CadastroFuncionario);
        }
    }
}
