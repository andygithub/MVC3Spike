using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(DataAnnotationsMVC3.App_Start.RegisterClientValidationExtensions), "Start", callAfterGlobalAppStart: true)]
 
namespace DataAnnotationsMVC3.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}