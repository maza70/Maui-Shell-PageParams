using De.Maza.ShellParams.Gui.Pages;

namespace De.Maza.ShellParams;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));
        Routing.RegisterRoute($"{nameof(TestPage)}/{nameof(TestPage2)}", typeof(TestPage2));

    }
}
