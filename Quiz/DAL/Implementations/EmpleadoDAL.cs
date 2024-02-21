using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EmpleadoDALImpl : DALGenericoImpl<Empleado>, IEmpleadoDAL
    {
        QuizContext _context;

        public EmpleadoDALImpl(QuizContext context) : base(context)
        {
            _context = context;
        }



        public IEnumerable<Empleado> GetAll()
        {
            List<sp_GetAllEmpleados_Result> results;

            string sql = "[dbo].[sp_GetAllEmpleados_Result]";

            results = _context.Sp_GetAllEmpleados_Results
                        .FromSqlRaw(sql)
                        .ToList();

            List<Empleado> categories = new List<Empleado>();

            foreach (var item in results)
            {
                categories.Add(
                    new Empleado
                    {
                        EmpleadoId = item.EmpleadoId,
                        Nombre = item.Nombre,
                        Salario = item.Salario
                    }
                    );
            }



            return categories;
        }


        public bool Add(Empleado entity)
        {
            try
            {

                string sql = "exec [dbo].[sp_AddEmpleado] @Nombre, @Salario";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName= "@Nombre",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Nombre
                    },
                    new SqlParameter()
                    {
                        ParameterName= "@Salario",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Salario
                    }

                };


                _Context.Database.ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}