using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersMVC3.Utilities
{
    public class DebugFilterProvider : IFilterProvider
    {
        private readonly List<Func<ControllerContext, object>> _conditions = new List<Func<ControllerContext, object>>();
        public void Add(Func<ControllerContext, object> condition)
        {
            _conditions.Add(condition);
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return from condition in _conditions
                   select condition(controllerContext) into filter
                   where filter != null
                   select new Filter(filter, FilterScope.Global,null);
        }
    }
}