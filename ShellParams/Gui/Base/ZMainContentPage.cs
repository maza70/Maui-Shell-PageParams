using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.Maza.ShellParams.Gui.Base
{

    /// <summary>
    /// Base Class for the main page (Page without back button)
    /// </summary>
    [QueryProperty(nameof(ZSubPageResult), nameof(ZSubPageResult))]
    public class ZMainContentPage:ContentPage
    {

     
        private ZSubPageResult _subPageResult;

        /// <summary>
        /// The event raised on close the sub page 
        /// </summary>
        public event EventHandler<ZSubPageResult> ZOnSubPageResult;

        /// <summary>
        /// The property to store the result of the caled sub page
        /// </summary>
        public ZSubPageResult ZSubPageResult
        {
            get => _subPageResult;
            set
            {
                _subPageResult = value;
                ZOnSubPageResult?.Invoke(this, value);
            }
        }

        public ZMainContentPage()
        {
        
        }
              
        /// <summary>
        /// Open a sub page
        /// </summary>
        /// <param name="route">the route to the sub page</param>
        /// <param name="parameter">optional a parameter object</param>
        public async void ZOpenSubPageAsync(string route, object parameter= null)
        {
            var subPageParameter = new ZSubPageParameter(this)
            {
                Parameter = parameter
            };

            var parameters = new Dictionary<string, object>()
            {
                [nameof(ZSubPageParameter)] = subPageParameter
            };
            await Shell.Current.GoToAsync(route, parameters);

        }
    }
}
