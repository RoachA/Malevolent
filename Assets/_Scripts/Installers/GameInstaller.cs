using UnityEngine;
using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
           // Container.BindInterfacesTo<GameInitializer>().AsSingle();
            Container.BindInstance(this).WhenInjectedInto<SceneContext>();
            Container.Bind<MortalsContainer>().FromComponentInNewPrefab(new GameObject()).AsSingle();

            ///SIGNALS
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<UserJoinedSignal>();
        }
    }
    
    /*public class GameInitializer : IInitializable
    {
        public void Initialize()
        {
        }
    }*/
    
    public class UserJoinedSignal
    {
        public string Username;

        public UserJoinedSignal(string msg)
        {
            Username = msg;
        }
    }
}
