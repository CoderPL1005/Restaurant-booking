using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Common
{
    public static class ObjectMapper
    {
        public static TTarget MapTo<TTarget>(object source) where TTarget : new()
        {
            TTarget target = new TTarget();

            try
            {
                var sourceProps = source.GetType().GetProperties();
                var targetProps = typeof(TTarget).GetProperties();

                foreach (var sp in sourceProps)
                {
                    var tProp = targetProps.FirstOrDefault(x => x.Name == sp.Name && x.PropertyType == sp.PropertyType);
                    if (tProp != null && tProp.CanWrite) tProp.SetValue(target, sp.GetValue(source));

                }

                return target;
            }
            catch (Exception ex)
            {
                return target;
                throw;
            }


        }
    }
}
