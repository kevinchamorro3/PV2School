using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public abstract class EntityInfo
    {
        public static string Publicar(IDBEntity entity)
        {
            return "";
        }

        public static string Publicar(IEnumerable<IDBEntity> entity)
        {
            return "";
        }
    }
}
