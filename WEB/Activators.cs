using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB
{
    public sealed class DelegatingControllerActivator : IControllerActivator
    {
        private readonly Func<ControllerContext, object> _controllerCreator;
        private readonly Action<ControllerContext, object> _controllerReleaser;

        public DelegatingControllerActivator(Func<ControllerContext, object> controllerCreator,
            Action<ControllerContext, object> controllerReleaser = null)
        {
            _controllerCreator = controllerCreator ??
                throw new ArgumentNullException(nameof(controllerCreator));
            _controllerReleaser = controllerReleaser ?? ((_, __) => { });
        }

        public object Create(ControllerContext context) => _controllerCreator(context);
        public void Release(ControllerContext context, object controller) =>
            _controllerReleaser(context, controller);
    }

    public sealed class DelegatingViewComponentActivator : IViewComponentActivator
    {
        private readonly Func<Type, object> _viewComponentCreator;
        private readonly Action<object> _viewComponentReleaser;

        public DelegatingViewComponentActivator(Func<Type, object> viewComponentCreator,
            Action<object> viewComponentReleaser = null)
        {
            _viewComponentCreator = viewComponentCreator ??
                throw new ArgumentNullException(nameof(viewComponentCreator));
            _viewComponentReleaser = viewComponentReleaser ?? (_ => { });
        }

        public object Create(ViewComponentContext context) =>
            _viewComponentCreator(context.ViewComponentDescriptor.TypeInfo.AsType());

        public void Release(ViewComponentContext context, object viewComponent) =>
            _viewComponentReleaser(viewComponent);
    }
}
