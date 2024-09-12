﻿using Integrador_Com_CRM.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Data.Map
{
    internal class RelacaoBoletoCRMMap : IEntityTypeConfiguration<RelacaoBoletoCRMModel>
    {
        public void Configure(EntityTypeBuilder<RelacaoBoletoCRMModel> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id_Documento).IsRequired();
            builder.Property(x => x.Numero_Documento).IsRequired();
            builder.Property(x => x.Id_Entidade).IsRequired();
            builder.Property(x => x.Nome_Entidade).IsRequired();
            builder.Property(x => x.Celular_Entidade).IsRequired();
            builder.Property(x => x.Email_Entidade).IsRequired();
            builder.Property(x => x.CNPJ_CPF).IsRequired();
            builder.Property(x => x.Situacao).IsRequired();
            builder.Property(x => x.Data_Vencimento).IsRequired();
            builder.Property(x => x.Cod_Oportunidade).IsRequired();
            builder.Property(x => x.Quitado).IsRequired();

        }
    }
}
