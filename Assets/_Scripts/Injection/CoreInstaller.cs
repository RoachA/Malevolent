using Game.Core.Mortal;
using Zenject;

namespace Game.Core
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<MortalController>().AsSingle().NonLazy();
            // Container.Bind<ScoreManager>().AsSingle().Lazy();
        }
    }
}
