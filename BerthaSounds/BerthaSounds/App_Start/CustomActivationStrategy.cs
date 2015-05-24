using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Ninject.Activation.Strategies;

namespace BerthaSounds.App_Start
{
    /// <summary>
    /// Custom Strategy allows us to see activation in Debug mode
    /// </summary>
    public class CustomActivationStrategy : ActivationStrategy
    {
        public override void Activate(Ninject.Activation.IContext context, Ninject.Activation.InstanceReference reference)
        {
#if (DEBUG)
            Debug.WriteLine("Ninject Activate: " + reference.Instance.GetType());
#endif

            base.Activate(context, reference);
        }

        public override void Deactivate(Ninject.Activation.IContext context, Ninject.Activation.InstanceReference reference)
        {

#if (DEBUG)
            Debug.WriteLine("Ninject Deactivate: " + reference.Instance.GetType());
#endif


            base.Deactivate(context, reference);
        }
    }
}