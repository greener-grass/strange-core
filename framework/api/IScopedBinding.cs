using strange.extensions.injector.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace strange.framework.api
{
    public interface IScopedBinding
    {
        void Start(IInjectionBinder binder);
        void End(IInjectionBinder binder);

    }
}
