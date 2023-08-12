using Zenject;

namespace Game.Core
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<IScoreBoard>().To<ScoreBoard>().AsSingle().NonLazy();
            // Container.Bind<ScoreManager>().AsSingle().Lazy();
        }
    }
}
