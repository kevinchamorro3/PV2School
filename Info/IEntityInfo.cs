using Modelo;
using System.Collections.Generic;

namespace Info
{
    public interface IEntityInfo
    {
        public string Publicar(IDBEntity entidad);

        public string Publicar(IEnumerable<IDBEntity> lista);
    }
}
