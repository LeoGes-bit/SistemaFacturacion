using SistemaFacturacion.Web.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
//using SistemaFacturacion.Features.Maestro.Catalogos.Queries.GetById;
using SistemaFacturacion.Web.Areas.Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaFacturacion.Features.Maestro.Catalogos.Queries.GetById;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Commands.Create;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetAllCached;
using Microsoft.AspNetCore.Http;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetById;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Commands.Update;

namespace SistemaFacturacion.Web.Areas.Facturacion.Controllers
{
    [Area("Facturacion")]
    [Authorize]//Sirve para dar permiso cuando esta logeado
    public class PersonaController : BaseController<PersonaController>
    {


        public async Task<IActionResult> Index(int tipoPantalla = 0)
        {
            var entidadViewModel = new PersonaViewModel();
         

            
            entidadViewModel.TipoPantalla = tipoPantalla;

            return View(entidadViewModel);// dirije a la carpeta Views
        }


        public async Task<IActionResult> LoadAll([FromBody] PersonaFiltroViewModel filtro)
        {
            if (filtro == null)

                return Json(new { data = new List<PersonaResponseViewModel>() });

            var response = await _mediator.Send(new GetDatosPersonasQuery() { Identificaion =filtro.Identificacion , Nombres = filtro.Nombres , Apellidos = filtro.Apellidos});
            if (response.Succeeded)
            { 

                var viewModel = _mapper.Map<List<PersonaResponseViewModel>>(response.Data);
               
                return Json(new { data = viewModel });
            }

            return Json(new { data = new List<PersonaResponseViewModel>() }); ;

        }
        public async Task<IActionResult> OnGetCreate(int id = 0, int vienede = 0)
        {

            try
            {
                var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 1, Ninguno = true });
                var tipoIdentificacion = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2, Ninguno = true });
                var tipoPersona = new SelectList(catalogo.Data, "Secuencia", "Nombre");


                if (id == 0)
                {
                    List<SelectListItem> items = new List<SelectListItem>();
                    var entidadViewModel = new PersonaViewModel();
                    entidadViewModel.TipoIdentifiacionList = tipoIdentificacion;
                    entidadViewModel.TipoClienteList = tipoPersona;
                    entidadViewModel.Vienede = vienede;
                   
                    return PartialView("_CreateOrEdit", entidadViewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("OnGetCreateOrEdit", ex);
                _notify.Error("Error al crear la Persona");
            }

            return null;

        }

        public async Task<IActionResult> IngresarPersona(int vienede = 0)
        {

            var entidadViewModel = new PersonaViewModel();
            entidadViewModel.Vienede = vienede;
           
            return View("_IngresoPersonas", entidadViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> OnPostCreateOrEdit(int? id, PersonaViewModel entidad , int vienede, string nombres , string idenficacion, string apellidos)
        {
            try
            {
              
                if (ModelState.IsValid)
                {
                    

                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreatePersonaCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);

                        if (result.Succeeded)
                        {

                            id = result.Data;


                            _notify.Success($"Persona con ID {result.Data} Creado.");

                        }
                        else _notify.Error(result.Message);
                    }
                    else 
                    {
                        var updateEntidadCommand = _mapper.Map<UpdatePersonaCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Persona con ID {result.Data} Actualizado.");
                       

                    }
                    if (vienede != 0)
                    {
                        var response = await _mediator.Send(new GetAllPersonasQuery() { Nombres = nombres, Apellidos= apellidos, Identificaion=idenficacion});
                        if (response.Succeeded)
                        {
 
                            var viewModel = _mapper.Map<List<GetAllPersonasQuery>>(response.Data);
                            
                            //var html1 = await _viewRenderer.RenderViewToStringAsync("Index", viewModel);
                           // return new JsonResult(new { isValid = true, html = html1 });
                            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("Index", viewModel) });


                        }

                    }
                    else
                    {

                        var entidadViewModel = new PersonaViewModel();
                        entidadViewModel.Vienede = vienede;

                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("Index", entidadViewModel) });

                    }

                }
            
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "Ingrese todos los datos Obligatorios" });

                }

                return new JsonResult(new { isValid = true, Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar el Persona");
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int tipoPantalla = 0)
        {
            try
            {
                var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 1, Ninguno = true });
                var tipoIdentificacion = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2, Ninguno = true });
                var tipoPersona = new SelectList(catalogo.Data, "Secuencia", "Nombre");


                if (id == 0)
                {
                    List<SelectListItem> items = new List<SelectListItem>();
                    var entidadViewModel = new PersonaViewModel();
                    entidadViewModel.TipoIdentifiacionList = tipoIdentificacion;
                    entidadViewModel.TipoClienteList = tipoPersona;
                  
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetPersonasByIdQuery() { Id = id });
                    if (response.Succeeded)
                    { 
                        var entidadViewModel= _mapper.Map<PersonaViewModel>(response.Data);
                        entidadViewModel.TipoIdentifiacionList = tipoIdentificacion;
                        entidadViewModel.TipoClienteList = tipoPersona;
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }
                       
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("OnGetCreateOrEdit", ex);
                _notify.Error("Error al crear la Persona");
            }

            return null;

        }

      
    }
}
