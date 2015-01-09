using strange.extensions.injector.api;
using strange.extensions.injector.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace strange.framework.api
{
    public class ScopedBinding : IScopedBinding
    {
        private Dictionary<Type, object> values;

        public ScopedBinding(params object[] values)
        {
            this.values = new Dictionary<Type, object>();
            foreach (var value in values)
            {
                Register(value);
            }
        }



        public void Register(object val)
        {
            Type bindType = val.GetType();
            if (values.ContainsKey(bindType))
            {
                throw new InjectionException("Instance of type " + bindType.ToString() + " is aleady bound", InjectionExceptionType.ILLEGAL_BINDING_VALUE);
            }

            values[bindType] = val;
        }

        public void End(IInjectionBinder binder)
        {
            foreach (var binding in values)
            {
                binder.Unbind(binding.Key);
            }
            values.Clear();
        }



        public void Start(IInjectionBinder binder)
        {

            foreach (var binding in values)
            {
                binder.Bind(binding.Key).ToValue(binding.Value);
            }

        }

    }
}
