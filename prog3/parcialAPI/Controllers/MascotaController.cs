using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using parcialAPI.Models;
using Resultados;
using Comandos.Mascotas;
using Microsoft.AspNetCore.Cors;


namespace parcialAPI.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]

    public class MascotaController : ControllerBase
    {
        private readonly prog3Context db = new prog3Context();

        // Obtenemos todas las mascotas
        [HttpGet]
        [Route("Mascotas/ObtenerMascotas")]

        public ActionResult<ResultadoAPI> getMascotas()
        {
            var resultado = new ResultadoAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.Animales.ToList();
                return resultado;
            }
            catch (Exception e)
            {
                resultado.Ok = false;
                resultado.CodigoError = 1;
                resultado.Error = "error en base de datos";
                return resultado;

            }
        }

        //Obtenemos todos los perros
        [HttpGet]
        [Route("Mascotas/ObtenerMascotas/{tipoAnimal}")]

        public ActionResult<ResultadoAPI> getbyTipo(int tipoAnimal)
        {
            var resultado = new ResultadoAPI();
            try
            {
                var mascota = db.Animales.Where(c => c.TipoAnimal == tipoAnimal);
                resultado.Ok = true;
                resultado.Return = mascota;
                return resultado;
            }
            catch (Exception e)
            {
                resultado.Ok = false;
                resultado.CodigoError = 1;
                resultado.Error = "Tipo de mascota no encontrado";
                return resultado;
            }
        }

        //Obtenemos las razas de los perros
        [HttpGet]
        [Route("Mascotas/RazaPerros")]

        public ActionResult<ResultadoAPI> getRaza(){
             var resultado = new ResultadoAPI();

            try
            {
                
                resultado.Ok = true;
                resultado.Return = db.Razas.ToList();
                return resultado;
            }
            catch (Exception e)
            {
                resultado.Ok = false;
                resultado.CodigoError = 1;
                resultado.Error = "Tipo de mascota no encontrado";
                return resultado;
            }
        }


        [HttpPost]
        [Route("Mascotas/CargarPerro")]
        public ActionResult<ResultadoAPI> postPerro([FromBody]ComandoCrearPerro comando)
        {
            var resultado = new ResultadoAPI();

            var perro = new Animale();
            perro.NombrePerro = comando.NombrePerro;
            perro.IdRaza = comando.IdRaza;
            perro.Edad = comando.Edad;
            perro.Peso = comando.Peso;
            perro.NombreYapeDueno = comando.NombreYapeDueno;
            perro.Telefono = comando.Telefono;

            db.Animales.Add(perro);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.Animales.ToList();

            return resultado;
        }
       

    }

}
