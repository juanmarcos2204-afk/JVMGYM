using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Dtos.Duracion_Membresia;
using JVMGYM.Servicio.DTOs.Paginación;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Servicio.Interfaces
{
    public interface IDuracionMembresiaServicio
    {
        void Agregar(DuracionMembresiaCreateDto duracionMembresiaCreateDto);
        void Eliminar(int id);
        List<DuracionMembresiaListDto> ObtenerDatosCombo();
        List<DuracionMembresiaListDto> ObtenerTodos();
        ResultadoPaginacionDto<DuracionMembresiaListDto> ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);

    }
}
