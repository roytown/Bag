﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class MappingBase<TEntity> : EntityTypeConfiguration<TEntity>, IMapping
        where TEntity : class,IEntity
    {
        public MappingBase()
        {
            this.Map(m => m.ToTable(typeof(TEntity).Name));
        }

        public void RegistTo(ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(this);
        }
    }
}
