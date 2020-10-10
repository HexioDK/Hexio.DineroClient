using Autofac;
using Hexio.DineroClient.Auth;
using Hexio.DineroClient.Authorization;

namespace Hexio.DineroClient.Module
{
    public class DineroModule : Autofac.Module
    {
        private readonly DineroApiSettings _dineroApiSettings;
        private readonly VismaConnectSettings _vismaConnectSettings;

        public DineroModule(DineroApiSettings dineroApiSettings, VismaConnectSettings vismaConnectSettings)
        {
            _dineroApiSettings = dineroApiSettings;
            _vismaConnectSettings = vismaConnectSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => _dineroApiSettings);
            builder.Register(x => _vismaConnectSettings);
            
            if (_dineroApiSettings.GetType() == typeof(SingleDineroAccountApiSettings))
            {
                builder.Register(x => (SingleDineroAccountApiSettings) _dineroApiSettings);
            }
            
            builder.Register(x => DineroAuthClientFactory.Execute(_dineroApiSettings)).InstancePerLifetimeScope().AsImplementedInterfaces();
            builder.Register(x => DineroClientFactory.Execute(_dineroApiSettings)).InstancePerLifetimeScope().AsImplementedInterfaces();
            
            builder.RegisterType<GetAuthorizeInfo>().AsImplementedInterfaces();
            builder.RegisterType<GetEndpoints>().AsImplementedInterfaces();
            builder.RegisterType<RequestAuthorizationToken>().AsImplementedInterfaces();
        }
    }
}
