using CharaCodeTyping.Scripts.Controller;
using CharaCodeTyping.Scripts.Service;
using CharaCodeTyping.Scripts.Sound;
using VContainer;
using VContainer.Unity;

namespace CharaCodeTyping.Scripts.DIContainer
{
    public class GameLifetimeScope : LifetimeScope

    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameStateManager>(Lifetime.Singleton);
            builder.Register<Question>(Lifetime.Singleton);
            builder.Register<InputSoundPlayer>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<KeyInputReceiver>();
            
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<Timer>();
                entryPoints.Add<InputSoundPresenter>();
            });
        }
    }
}