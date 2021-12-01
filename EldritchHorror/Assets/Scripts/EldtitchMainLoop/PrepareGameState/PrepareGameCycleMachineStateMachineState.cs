using EldritchHorror.Core;

namespace EldritchHorror
{
    public class PrepareGameCycleMachineStateMachineState : MainLoopState
    {
        private readonly IPrepareGameStateMachine _prepareGameStateMachine;

        private PrepareGameCycleMachineStateMachineState(IPrepareGameStateMachine prepareGameStateMachine)
        {
            _prepareGameStateMachine = prepareGameStateMachine;
            this.AddNewTransition(() => _prepareGameStateMachine.IsWorking).Bind(this);
        }

        public override int Order => 1;

        public override void Enter()
        {
            base.Enter();
            _prepareGameStateMachine.Start();
            //Выбор Дополнений
            //Выбор количества игроков
            //Выбор древнего
            //Настройка карт мифов
            //Выбор персонажей
        }
    }
}