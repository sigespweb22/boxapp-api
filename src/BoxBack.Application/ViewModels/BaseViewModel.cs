using System.ComponentModel;
using System.Linq;

namespace BoxBack.Application.ViewModels
{
    public abstract class BaseViewModel
    {
        protected BaseViewModel()
        {
            // apply any DefaultValueAttribute settings to their properties
            var propertyInfos = this.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), true);
                if (attributes.Any())
                {
                    var attribute = (DefaultValueAttribute) attributes[0];
                    propertyInfo.SetValue(this, attribute.Value.ToString(), null);
                }
            }
        }
    }
}