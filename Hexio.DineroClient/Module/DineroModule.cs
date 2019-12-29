using Autofac;
using Hexio.DineroClient.Auth;

namespace Hexio.DineroClient.Module
{
    public class DineroModule : Autofac.Module
    {
        private readonly DineroApiSettings _dineroApiSettings;

        public DineroModule(DineroApiSettings dineroApiSettings)
        {
            _dineroApiSettings = dineroApiSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => _dineroApiSettings);

            if (_dineroApiSettings.GetType() == typeof(SingleDineroAccountApiSettings))
            {
                builder.Register(x => (SingleDineroAccountApiSettings) _dineroApiSettings);
            }
            
            builder.Register(x => DineroAuthClientFactory.Execute(_dineroApiSettings)).SingleInstance().AsImplementedInterfaces();
            builder.Register(x => DineroClientFactory.Execute(_dineroApiSettings)).SingleInstance().AsImplementedInterfaces();
        }
    }
}