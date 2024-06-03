using Application.Responses.Tarea;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITareaService
    {
        public List<TareaResponse> GetTareaByTipoTareaId(int tipoTareaId);

        public List<TareaResponse> GetTareaById(int tareaId);

        bool AddTareaEnrolamiento(int tipoEnrolamientoId, int usuarioId);
    }
}
