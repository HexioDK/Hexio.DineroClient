using Autofac;

namespace Hexio.DineroClient
{
    public class DineroModule : Module
    {
        private readonly DineroApiSettings _dineroApiSettings;

        public DineroModule(DineroApiSettings dineroApiSettings)
        {
            _dineroApiSettings = dineroApiSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => DineroAuthClientFactory.Execute(_dineroApiSettings));
            builder.Register(x => DineroClientFactory.Execute(_dineroApiSettings));
        }
    }
}