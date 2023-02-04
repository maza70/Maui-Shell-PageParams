using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.Maza.ShellParams.Gui.Base
{
    public class ZSubPageResult
    {

        public ZSubPageResult(Page sender)
        {
            Sender = sender;

        }
        public Page Sender { get; init; }

        public object ResultObject { get; init; }
        public bool Result { get; init; }

        public bool TryGetResultAs<T>(out T result )
        {
            try
            {
                if (ResultObject == null)
                {
                    result = default(T);
                    return true;
                }

                result = (T)Convert.ChangeType(ResultObject, typeof(T));
                return true;
            } catch
            {
                result = default(T);
                return false;
            }
        }
        public override string ToString()
        {
            return $"sender: {Sender} result: {Result} ResultObject:{ResultObject}";
        }
    }
}
