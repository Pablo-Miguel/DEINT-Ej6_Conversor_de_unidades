using System.Collections.ObjectModel;
using UnitsNet;
using UnitsNet.Units;

namespace DEINT_Ej6_Conversor_de_unidades.MVVM.Views;

public partial class CalculatorView : ContentPage
{
	private ObservableCollection<string> FromMedidas { get; set; }
	private ObservableCollection<string> ToMedidas { get; set; }
	private string Text { get; set; }

	public CalculatorView(string text)
	{
		InitializeComponent();

		this.Text = text;

        txtTitle.Text = text;

        translate();

		FromMedidas = cargarMedidas();
		ToMedidas = cargarMedidas();

		fromPicker.ItemsSource = FromMedidas.ToList<string>();
        fromPicker.SelectedIndex = 0;

        toPicker.ItemsSource = ToMedidas.ToList<string>();
        toPicker.SelectedIndex = 1;

        if (!txtOperation.Text.ToString().Equals(""))
        {
            txtRespuesta.Text = UnitConverter.ConvertByName(Double.Parse(txtOperation.Text.ToString()), Text, fromPicker.SelectedItem.ToString(), toPicker.SelectedItem.ToString()).ToString();
        }

    }

	private void translate() {
        switch (Text)
        {
            case "INFORMACION":
                Text = "Information";
                break;
            case "VOLUMEN":
                Text = "Volume";
                break;
            case "ALTURA":
                Text = "Length";
                break;
            case "MASA":
                Text = "Mass";
                break;
            case "TEMPERATURA":
                Text = "Temperature";
                break;
            case "ENERGIA":
                Text = "Energy";
                break;
            case "AREA":
                Text = "Area";
                break;
            case "VELOCIDAD":
                Text = "Speed";
                break;
            case "DURACION":
                Text = "Duration";
                break;
        }
    }

	private ObservableCollection<string> cargarMedidas() {

		var types = Quantity.Infos
			.FirstOrDefault(x => x.Name == Text)
			.UnitInfos
			.Select(u => u.Name)
			.ToList();

		return new ObservableCollection<string>(types);
	}

    private void txtOperation_TextChanged(object sender, TextChangedEventArgs e)
    {
        try {
            if (!txtOperation.Text.ToString().Equals(""))
            {
                txtRespuesta.Text = UnitConverter.ConvertByName(Double.Parse(txtOperation.Text.ToString()), Text, fromPicker.SelectedItem.ToString(), toPicker.SelectedItem.ToString()).ToString();
            }
        } catch(FormatException) {
            txtRespuesta.Text = "Syntax Error";
        }
		
    }

    
}