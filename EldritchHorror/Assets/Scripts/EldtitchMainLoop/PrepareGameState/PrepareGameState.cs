using EldritchHorror.Core;
using System.Threading.Tasks;
using UnityEngine;

namespace EldritchHorror
{
    public abstract class PrepareGameState : AbstractStateMachineState<MainLoopEntity>, IPrepareGameMachineState
    {
        public override void Exit()
        {
            Debug.LogError($"Exit {GetType().Name}");
        }

        public override async void Enter()
        {
            Debug.LogError($"Enter {GetType().Name}");
            await Task.Delay(2000);
        }

        protected virtual bool CheckBack()
        {
            return false;
        }

        protected virtual bool CheckNext()
        {
            return false;
        }
    }

    public class SelectionBossPrepareGameState : PrepareGameState
    {
        private SelectionBossPrepareGameState()
        {
           
        }

        public override int Order => 10;
    }

    public class SelectionGameBoxesPrepareGameState : PrepareGameState
    {
        private SelectionGameBoxesPrepareGameState()
        {
          
        }

        public override int Order => 1;
    }

    public class SelectionMythosCardPrepareGameState : PrepareGameState
    {
        private SelectionMythosCardPrepareGameState()
        {
           
        }

        public override int Order => 20;
    }
}