#region

using EldritchHorror.EntitasSystems;
using EldritchHorror.UI;
using EldritchHorror.UserProfile;
using Entitas;

#endregion

namespace EldritchHorror
{
    public interface IEldritchHorrorSceneLauncher : IEldritchHorrorEntitasRuntimeSystemBuilder
    {
        void ActivateScene();
    }

    public class EldritchHorrorSceneLauncher : IEldritchHorrorSceneLauncher
    {
        private readonly IEldritchHorrorEntitasRuntimeSystemBuilder _builder;
        private readonly IUserSaveProfileStorage _userSaveProfileStorage;
        private readonly ITurnPhaseSwitcherSystem _turnPhaseSwitcherSystem;
        private readonly GameLoopContext _gameLoopContext;
        private readonly MainLoopContext _mainLoopContext;
        private readonly IEldritchWindowUIProvider _provider;
        private readonly IEldritchWindowUIStorage _uiStorage;

        public EldritchHorrorSceneLauncher(IEldritchHorrorEntitasRuntimeSystemBuilder builder,
                                           IUserSaveProfileStorage userSaveProfileStorage, 
                                           IEldritchWindowUIProvider provider,
                                           IEldritchWindowUIStorage uiStorage,
                                           GameLoopContext gameLoopContext, MainLoopContext mainLoopContext)
        {
            _builder         = builder;
            _userSaveProfileStorage = userSaveProfileStorage;
            _provider        = provider;
            _uiStorage = uiStorage;
            _gameLoopContext = gameLoopContext;
            _mainLoopContext = mainLoopContext;
        }

        public Feature BuildUpdate()
        {
            return _builder.BuildUpdate();
        }

        public void ActivateScene()
        {
            // обеспечили доступность UI
            ((EldritchWindowUIProvider) _provider).Storage = _uiStorage; 
            /*//временно устанавливаем окно тут. когда добавиться меню, то будет включать его
            _gameLoopContext.masterEntityEntity.ReplaceMainWindowUI(_provider.GetWindow<MainGameUIWindow>());
            _gameLoopContext.masterEntityEntity.ReplaceTurnCounter(0);
            _turnPhaseSwitcherSystem.NewTurn();*/
        }
    }

    public interface IEldritchHorrorEntitasRuntimeSystemBuilder
    {
        Feature BuildUpdate();
    }

    public class EldritchHorrorEntitasRuntimeSystemBuilder : IEldritchHorrorEntitasRuntimeSystemBuilder
    {
        private readonly ISystem[] _systems;

        public EldritchHorrorEntitasRuntimeSystemBuilder(ISystem[] systems)
        {
            _systems = systems;
        }

        public Feature BuildUpdate()
        {
            var result = new Feature("CoreSystems");
            foreach (var system in _systems) result.Add(system);
            result.Initialize();
            return result;
        }
    }
}