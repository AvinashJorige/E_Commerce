using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel.Interfaces;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> : IActionCore<TEntity>
    {
        // Left empty Intentionaly...
    }
}
