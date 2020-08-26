using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Data.Services
{
    interface IUniversidadData <T>
    {
        IEnumerable<T> ObtenerTodos();
        T Obtener(int id);
        void Agregar(T restaurant);
        void Actualizar(T restaurant);
        void Remover(int id);
    }
}
