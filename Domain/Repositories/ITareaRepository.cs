using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITareaRepository
    {
        public List<TaakTarea> GetTareaByTipoTareaId(int tipoTareaId);

        public List<TaakTarea> GetTareaById(int tareaId);

        bool AddTarea(TaakTarea tarea);
    }
}
