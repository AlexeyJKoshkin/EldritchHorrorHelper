#region

using EldritchHorror.Core;
using System.Threading.Tasks;
using UnityEngine;

#endregion

namespace EldritchHorror
{
    public abstract class PrepareGameState : AbstractStateMachineState<MainLoopEntity>, IPrepareGameMachineState
    {
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
        private SelectionBossPrepareGameState() { }

        public override int Order => 10;
    }

    public class SelectionGameBoxesPrepareGameState : PrepareGameState
    {
        private SelectionGameBoxesPrepareGameState() { }

        public override int Order => 1;
    }

    public class SelectionMythosCardPrepareGameState : PrepareGameState
    {
        private SelectionMythosCardPrepareGameState() { }

        public override int Order => 20;
    }
}