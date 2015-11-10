using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CRUD2
{
    public partial class Editpg : ContentPage
    {
        private Estudiante estudent;

        public Editpg(Estudiante estudent)
        {
            InitializeComponent();
            this.estudent = estudent;

            actualizarButton.Clicked += actualizarButton_Clicked;
            borrarButton.Clicked += borrarButton_Clicked;

            nombresEntry.Text = estudent.Nombre;
            apellidosEntry.Text = estudent.Apellido;
            gradoEntry.Text = estudent.Grado;
            fechanacimientoDatePicker.Date = estudent.Fechana;
            activoSwitch.IsToggled = estudent.Activo;
        }

        public async void borrarButton_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Confirmación", "¿Desea borrar el estudiante?", "Si", "No");
            if (!rta) return;

            using (var datos = new DateAccess())
            {
                datos.DeleteEstudiante(estudent);
            }

            await DisplayAlert("Confirmación", "Estudiante eliminado correctamente", "Aceptar");
            await Navigation.PushAsync(new Homepg());
        }

        public async void actualizarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar nombres", "Aceptar");
                nombresEntry.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(apellidosEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar apellidos", "Aceptar");
                apellidosEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(gradoEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar salario", "aceptar");
                gradoEntry.Focus();
                return;
            }

            Estudiante estu = new Estudiante
            {
                IDestudiante = this.estudent.IDestudiante,
                Activo = activoSwitch.IsToggled,
                Apellido = apellidosEntry.Text,
                Fechana = fechanacimientoDatePicker.Date,
                Nombre = nombresEntry.Text,
                Grado = gradoEntry.Text,
            };

            using (var datos = new DateAccess())
            {
                datos.UpdateEstudiante(estu);
            }

            await DisplayAlert("Confirmación", "Estudiante actualizado correctamente", "Aceptar");
            await Navigation.PushAsync(new Homepg());
        }
    }
}
