using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI
{
    public class ParameterActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                var actionDescriptor = filterContext.ActionDescriptor as ActionDescriptor;
                if (actionDescriptor != null)
                {
                    var parameterDescriptors = actionDescriptor.GetParameters();
                    foreach (var parameterDescriptor in parameterDescriptors)
                    {
                        var validationAttributes = parameterDescriptor.GetCustomAttributes(typeof(ValidationAttribute), true);
                        foreach (ValidationAttribute validationAttribute in validationAttributes)
                        {
                            if (validationAttribute != null)
                            {
                                var isValid = validationAttribute.IsValid(filterContext.ActionParameters[parameterDescriptor.ParameterName]);
                                if (!isValid)
                                {
                                    var key = parameterDescriptor.ParameterName;
                                    var errorMessage = validationAttribute.FormatErrorMessage(key);
                                    var displayAttributes = parameterDescriptor.GetCustomAttributes(typeof(DisplayAttribute), true);
                                    if (displayAttributes != null && displayAttributes.Length > 0)
                                    {
                                        var displayAttribute = displayAttributes[0] as DisplayAttribute;
                                        if (displayAttribute != null && !string.IsNullOrEmpty(displayAttribute.Name))
                                        {
                                            errorMessage = validationAttribute.FormatErrorMessage(displayAttribute.Name);
                                        }
                                    }

                                    controller.ModelState.AddModelError(key, errorMessage);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}