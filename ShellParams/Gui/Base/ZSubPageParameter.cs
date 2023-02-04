namespace De.Maza.ShellParams.Gui.Base
{
    /// <summary>
    /// class for the parameter to transmit 
    /// </summary>
    public class ZSubPageParameter
    {
        public ZSubPageParameter(Page sender)
        {
            Sender = sender;
        }
        /// <summary>
        /// the sender (page that calls the sub page)
        /// </summary>
        public Page Sender { get; init; }

        /// <summary>
        /// the parameter for the sub page
        /// </summary>
        public object Parameter { get; init; }
        /// <inheritdoc/>>
        
        public override string ToString()
        {
            return $"sender: {Sender} Parameter:{Parameter}";
        }
        /// <summary>
        /// convert the parameter to the given type
        /// </summary>
        /// <typeparam name="T">type of the parameter</typeparam>
        /// <param name="parameter">the converted parameter</param>
        /// <returns>true=parameter converted. false= Parameter can't convert</returns>
        public bool TryGetParameterAs<T>(out T parameter)
        {
            try
            {
                if (Parameter == null)
                {
                    parameter = default(T);
                    return true;
                }

                parameter = (T)Convert.ChangeType(Parameter, typeof(T));
                return true;
            }
            catch
            {
                parameter = default(T);
                return false;
            }
        }
    }
}
