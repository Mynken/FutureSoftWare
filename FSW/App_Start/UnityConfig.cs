using FSW.Data.Abstract;
using FSW.Data.Context;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FSW
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IAskQestionRepository, EFAskQuestionRepository>();
            container.RegisterType<IOrderSiteRepository, EFOrderSiteRepository>();
            container.RegisterType<IFeedbackRepository, EFFeedbackRepository>();
            container.RegisterType<IGalleryRepository, EFGalleryRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}