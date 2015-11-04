using Gada.Domain;
using Gada.Skills.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gada.Skills
{
    public interface ISkillsContext : IDisposable
    {
        IRepository<Skill> SkillRepository { get; }

        IRepository<SkillCategory> SkillCategoryRepository { get; }

        Database Db { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbEntityEntry Entry(object entry);

        void Save();
    }
}
