namespace DEINT_Ej6_Conversor_de_unidades.MVVM.Views;

public partial class UnitsConverterView : ContentPage
{
	public UnitsConverterView()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {

		Grid grid = sender as Grid;

		Label label = grid.Children[1] as Label;


        Navigation.PushAsync(new CalculatorView(label.Text));

    }
}