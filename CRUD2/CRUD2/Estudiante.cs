using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD2
{
   
        public class Estudiante
        {
            [PrimaryKey, AutoIncrement]
            public int IDestudiante { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime Fechana { get; set; }
            public string Grado { get; set; }
            public bool Activo { get; set; }

            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3} {4}", IDestudiante, Nombre,
                    Apellido, Fechana, Grado, Activo);
            }

        }
    }

