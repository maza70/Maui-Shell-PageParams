namespace De.Maza.ShellParams.Gui.Base
{

    /// <summary>
    /// Base class for a sub page 
    /// </summary>
    [QueryProperty(nameof(ZSubPageParameter), nameof(ZSubPageParameter))]
    public class ZSubContentPage : ZMainContentPage
    {
        public delegate void BackButtonPressedHandler();
        private ZSubPageParameter _pageParameterInput;
        
        /// <summary>
        /// Parameter that the caller give
        /// </summary>
        public ZSubPageParameter ZSubPageParameter
        {
            get => _pageParameterInput;
            set
            {
                _pageParameterInput = value;
                ZOnSubPageParameter.Invoke(this,value);
            }
        }
        /// <summary>
        /// Event for the parameter from the caller
        /// </summary>
        public event EventHandler<ZSubPageParameter> ZOnSubPageParameter;
        /// <summary>
        /// Event when the back button or the back icon in the header pressed
        /// </summary>
        public event BackButtonPressedHandler ZOnBackButtonPressed;

        public ZSubContentPage()
        {
            var backButtonBehavior = new BackButtonBehavior()
            {
                BindingContext = this,
                Command = new Command(execute: ZBackButtonPressed, canExecute: () => { return true; })
            };
            Shell.SetBackButtonBehavior(this, backButtonBehavior);
        }

        private void ZBackButtonPressed()
        {
            if (ZOnBackButtonPressed != null)
            {
                ZOnBackButtonPressed.Invoke();
            }
            else
            {
                ZCloseSubPageAsync(false);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (ZOnBackButtonPressed != null) { 
                ZOnBackButtonPressed.Invoke();
                return true;
            } else
            {
                return base.OnBackButtonPressed();
            }
        }
        /// <summary>
        /// Close the sub page and go back to the parent page
        /// </summary>
        /// <param name="result">the result of this page</param>
        /// <param name="resultParameter">the result parameter of this page</param>
        protected async void ZCloseSubPageAsync(bool result, object resultParameter = null)
        {
            var pageResult = new ZSubPageResult(this)
            {
                Result = result,
                ResultObject = resultParameter
            };
            var parameters = new Dictionary<string, object>()
            {
                [nameof(ZSubPageResult)] = pageResult
            };
            await Shell.Current.GoToAsync("..", parameters);
        }


        
    }
}
