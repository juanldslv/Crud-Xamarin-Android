using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;

using System.Linq;
using System.IO;
using CRUD2;

namespace CRUD2
{
    public class DateAccess:IDisposable
    {
        private SQLiteConnection connec;

        public DateAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connec = new SQLiteConnection(config.Plataforma, Path.Combine(config.DirecotrioDB, "Estudiante.db3"));
            connec.CreateTable<Estudiante>();
        }

        public void InsertEstudiante(Estudiante estudiante)
        {
            connec.Insert(estudiante);
        }

        public void UpdateEstudiante(Estudiante estudiante)
        {

            connec.Update(estudiante);

        }
        public void DeleteEstudiante(Estudiante estudiante)

        {

            connec.Delete(estudiante);
        }
        public Estudiante GetEstudent(int IDestudiante)
        {
            return connec.Table<Estudiante>().FirstOrDefault(c => c.IDestudiante == IDestudiante);
        }
        public List<Estudiante> GetEstudents()
        {
            return connec.Table<Estudiante>().OrderBy(c => c.Apellido).ToList();
        }
        public void Dispose()

        {
            connec.Dispose();
        }
    }
}
