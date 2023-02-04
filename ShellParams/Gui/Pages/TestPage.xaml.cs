using De.Maza.ShellParams.Gui.Base;

namespace De.Maza.ShellParams.Gui.Pages;



public partial class TestPage : ZSubContentPage
{

    private ComplexParameter _paramForSubPage = new ComplexParameter();


    public TestPage()
	{
		InitializeComponent();
        //for parameters from the MainPage
        ZOnSubPageParameter += PageParameter;
        //On BackButton or back icon from the toolbar
        ZOnBackButtonPressed += ButtonPressed;
        //Result from the second subpage
        ZOnSubPageResult += SubPageResult; 
    }

    

    protected void PageParameter(object sender,ZSubPageParameter subPageParameter)
    {
        if (subPageParameter?.Parameter != null)
        {
            edOne.Text = subPageParameter.Parameter as string;

        }
    }
    protected void ButtonPressed()
    {
        ZCloseSubPageAsync(true, "Hello back from sub page back button");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        ZCloseSubPageAsync(true, "Hello back from sub page");
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        _paramForSubPage.Text= edTest2Param.Text;
        _paramForSubPage.Counter++;

        ZOpenSubPageAsync(nameof(TestPage2), _paramForSubPage);
    }
    private void SubPageResult(object sender, ZSubPageResult e)
    {
        if (e.TryGetResultAs<string>(out var result)) {
            edTest2Result.Text = result;
        }
    }
}