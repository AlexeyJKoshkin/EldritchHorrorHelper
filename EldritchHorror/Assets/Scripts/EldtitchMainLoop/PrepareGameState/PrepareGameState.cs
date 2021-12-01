using EldritchHorror.Core;
using System.Threading.Tasks;
using UnityEngine;

namespace EldritchHorror
{
    public abstract class PrepareGameState : AbstractStateMachineState, IPrepareGameMachineState
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
            this.AddNewTransition(CheckBack).To<SelectionGameBoxesPrepareGameState>().Bind(this);
            this.AddNewTransition(CheckNext).To<SelectionMythosCardPrepareGameState>().Bind(this);
        }

        public override int Order => 10;
    }

    public class SelectionGameBoxesPrepareGameState : PrepareGameState
    {
        private SelectionGameBoxesPrepareGameState()
        {
            this.AddNewTransition(CheckBack).Bind(this);
            this.AddNewTransition(CheckNext).To<SelectionBossPrepareGameState>().Bind(this);
        }

        public override int Order => 1;
    }

    public class SelectionMythosCardPrepareGameState : PrepareGameState
    {
        private SelectionMythosCardPrepareGameState()
        {
            this.AddNewTransition(CheckBack).To<SelectionBossPrepareGameState>().Bind(this);

            this.AddNewTransition(CheckNext).Bind(this);
        }

        public override int Order => 20;
    }
}