using De.Maza.ShellParams.Gui.Base;
using De.Maza.ShellParams.Gui.Pages;

namespace De.Maza.ShellParams;


public partial class MainPage : ZMainContentPage
{


    public MainPage()
	{
		InitializeComponent();
        ZOnSubPageResult += MainPage_ZOnSubPageResult;
	}

    private void MainPage_ZOnSubPageResult(object sender, ZSubPageResult e)
    {
     
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
        ZOpenSubPageAsync(nameof(TestPage), "hello from Mainpage");
    }
}

