using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUD2
{
   public class Estudiantecll:ViewCell
    {
        public Estudiantecll()
        { 
            var IDestudiantelabel = new Label
            {
            TextColor = Color.White,
            Font = Font.SystemFontOfSize(NamedSize.Medium),
            HorizontalOptions = LayoutOptions.Start
            };

            IDestudiantelabel.SetBinding(Label.TextProperty, new Binding("IDEstudiante"));

            var Nombreslabel = new Label
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Medium)

            };
            Nombreslabel.SetBinding(Label.TextProperty, new Binding("Nombres"));
            var ApellidosLabel = new Label
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            ApellidosLabel.SetBinding(Label.TextProperty, new Binding("Apellidos"));

            var GradoLabel = new Label
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Small),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            GradoLabel.SetBinding(Label.TextProperty, new Binding("Grado"));

            var FechaNaciLabel = new Label
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Small),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            FechaNaciLabel.SetBinding(Label.TextProperty, new Binding("FechaNacimiento"));
            var ActivoSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                IsEnabled = false
            };
            ActivoSwitch.SetBinding(Switch.IsToggledProperty, new Binding("Activo"));

            var panel1 = new StackLayout
            {
                Children = { IDestudiantelabel, Nombreslabel, ApellidosLabel },
                Orientation = StackOrientation.Horizontal
            };

            var panel2 = new StackLayout
            {
                Children = { GradoLabel, FechaNaciLabel, ActivoSwitch },
                Orientation = StackOrientation.Horizontal
            };

            View = new StackLayout
            {
                Children = { panel1, panel2 },
                Orientation = StackOrientation.Vertical,
                Spacing = Height + Height
            };
        }
    }
}
