using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD2;

using Xamarin.Forms;

namespace CRUD2
{
    public partial class Homepg : ContentPage
    {
        public Homepg()
        {
            InitializeComponent();
            nuevoButton.Clicked += nuevoButton_Clicked;

            datosListView.ItemSelected += datosListView_ItemSelected;

            datosListView.ItemTemplate = new DataTemplate(typeof(Estudiantecll));

            using (var datos = new DateAccess())
            {
                datosListView.ItemsSource = datos.GetEstudents();
            }

        }
        void datosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new Editpg((Estudiante)e.SelectedItem));
        }
        public async void nuevoButton_Clicked(object sender, EventArgs e)
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
                await DisplayAlert("Error", "Debe ingresar Grado", "aceptar");
                gradoEntry.Focus();
                return;
            }

            Estudiante estudent = new Estudiante
            {
                Activo = activoSwitch.IsToggled,
                Apellido = apellidosEntry.Text,
                Fechana = fechanacimientoDatePicker.Date,
                Nombre = nombresEntry.Text,
                Grado = gradoEntry.Text,
            };

            using (var datos = new DateAccess())
            {
                datos.InsertEstudiante(estudent);
                datosListView.ItemsSource = datos.GetEstudents();
            }

            apellidosEntry.Text = String.Empty;
            fechanacimientoDatePicker.Date = DateTime.Now;
            nombresEntry.Text = String.Empty;
            nombresEntry.Text = String.Empty;
            await DisplayAlert("Mensaje", "estudiante creado correctamente", "Aceptar");
        }
    }
}
