using Entities.Entities;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;


namespace FrontEnd.Helpers.Implementations
{
    public class EmpleadoHelper : IEmpleadoHelper
    {
        IServiceRepository ServiceRepository;

        public EmpleadoHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public EmpleadoViewModel AddEmpleado(EmpleadoViewModel empleado)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Empleado", Convertir(empleado));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  empleadoAPI = JsonConvert.DeserializeObject<Empleado>(content);
            }

            return empleado;
        }


        Empleado Convertir(EmpleadoViewModel empleado)
        {
            return new Empleado
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }

        EmpleadoViewModel Convertir(Empleado empleado)
        {
            return new EmpleadoViewModel
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }


        public EmpleadoViewModel DeleteEmpleado(int id)
        {

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Empleado/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new EmpleadoViewModel();
        }

        public List<EmpleadoViewModel> GetEmpleados()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/empleado");
            List<Empleado> resultado = new List<Empleado>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Empleado>>(content);
            }
            List<EmpleadoViewModel> lista = new List<EmpleadoViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;



        }

        public EmpleadoViewModel GetEmpleado(int id)
        {
            EmpleadoViewModel empleado = new EmpleadoViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Empleado/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                empleado = Convertir(JsonConvert.DeserializeObject<Empleado>(content));
            }

            return empleado;
        }

        public EmpleadoViewModel UpdateEmpleado(EmpleadoViewModel empleado)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Empleado", Convertir(empleado));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  empleadoAPI = JsonConvert.DeserializeObject<Empleado>(content);
            }

            return empleado;
        }
    }
}