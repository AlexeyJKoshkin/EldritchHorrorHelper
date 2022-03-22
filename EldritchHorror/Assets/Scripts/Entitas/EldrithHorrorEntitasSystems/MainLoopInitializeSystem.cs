using Entitas;
using UnityEngine;

namespace EldritchHorror.EntitasSystems
{
    /// <summary>
    ///     Инициализация главного игрового цикла
    ///     содержит список стейтов основного цикла игры (Загрузка профиля, Показ Меню, запуск игрового цикла и т.д)
    /// </summary>
    public class MainLoopInitializeSystem : CycleStateSwitcher<MainLoopEntity, IGameLoopState>, IInitializeSystem
    {
        private readonly IContext<MainLoopEntity> _mainLoop;

        public MainLoopInitializeSystem(IContext<MainLoopEntity> context, IGameLoopState[] phases) : base(context, phases)
        {
            _mainLoop = context;
        }

        public void Initialize()
        {
            StateBox.Reset();
            HandleNextPhase(StateBox.GetNext(), _mainLoop.CreateEntity());
        }

        protected override bool Filter(MainLoopEntity entity)
        {
            return entity.isIsReady;
        }

        protected override IMatcher<MainLoopEntity> ReadyStateMatcher => Matcher<MainLoopEntity>.AllOf(MainLoopComponentsLookup.IsReady, MainLoopComponentsLookup.MainLoopState);

        protected override void HandleNextPhase(IGameLoopState nextState, MainLoopEntity entity)
        {
            if (nextState == null)
            {
                Debug.LogError("End Game");
            }
            else
            {
                entity.isIsReady = false;
                entity.ReplaceMainLoopState(nextState);
            }
        }
    }
}