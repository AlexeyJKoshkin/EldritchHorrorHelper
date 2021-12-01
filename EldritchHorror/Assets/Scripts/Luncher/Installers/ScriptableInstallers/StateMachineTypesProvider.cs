using System;
using System.Collections.Generic;

namespace EldritchHorror
{
    public class StateMachineTypesProvider
    {
        public static IEnumerable<Type> AllStateMachineType()
        {
            yield return typeof(GameLoopStateMachine);
            yield return typeof(PrepareGameStateMachine);
        }

        public static IEnumerable<Type> AllStatesMachineType()
        {
            yield return typeof(SelectionBossPrepareGameState);
            yield return typeof(SelectionGameBoxesPrepareGameState);
            yield return typeof(SelectionMythosCardPrepareGameState);
            yield return typeof(PrepareGameCycleMachineStateMachineState);
        }
    }
}