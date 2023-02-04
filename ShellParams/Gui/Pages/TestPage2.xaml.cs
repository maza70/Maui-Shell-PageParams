using De.Maza.ShellParams.Gui.Base;

namespace De.Maza.ShellParams.Gui.Pages;

public partial class TestPage2 : ZSubContentPage
{
    private ComplexParameter _parameter;

	public TestPage2()
	{
		InitializeComponent();

        ZOnSubPageParameter += PageParameter;
        ZOnBackButtonPressed += BackButtonPressed;

    }
    /// <summary>
    /// Set the parameter given form the caller
    /// </summary>
    /// <param name="sender">the caller page</param>
    /// <param name="subPageParameter">the parameter</param>
    private void PageParameter(object sender,ZSubPageParameter subPageParameter)
    {
        if (subPageParameter.TryGetParameterAs<ComplexParameter>(out var complexParam))
        {
            _parameter = complexParam;
            edParameter.Text = complexParam.Text;
            edCounter.Text = complexParam.Counter.ToString();
        }
    }
    /// <summary>
    /// Action what to do when back button pressed
    /// </summary>
    public void BackButtonPressed()
    {
        if (_parameter != null)
        {
            ZCloseSubPageAsync(false, $"Back pressed: {edReturn.Text} open count:{_parameter.Counter}");
        }
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        ZCloseSubPageAsync(true, $"{edReturn.Text} open count:{_parameter.Counter}");
    }
}