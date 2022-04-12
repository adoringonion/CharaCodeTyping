using CharaCodeTyping.Scripts.Controller;
using CharaCodeTyping.Scripts.Service;
using CharaCodeTyping.Scripts.Sound;
using CharaCodeTyping.Scripts.View;
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
            builder.RegisterComponentInHierarchy<InputSoundPlayer>();
            builder.RegisterComponentInHierarchy<KeyInputReceiver>();
            builder.Register<Timer>(Lifetime.Singleton);
            builder.Register<ScoreManager>(Lifetime.Singleton);
            
            
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<Timer>();
                entryPoints.Add<InputSoundPresenter>();
            });
        }
    }
}