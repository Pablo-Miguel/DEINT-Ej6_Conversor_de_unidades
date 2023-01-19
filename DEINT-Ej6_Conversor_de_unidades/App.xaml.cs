using DEINT_Ej6_Conversor_de_unidades.MVVM.Views;

namespace DEINT_Ej6_Conversor_de_unidades;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new UnitsConverterView());
	}
}
