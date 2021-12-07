using System;
using System.Collections.Generic;

namespace EldritchHorror
{
    public class StateMachineTypesProvider
    {
        public static IEnumerable<Type> AllStateMachineType()
        {
            yield return typeof(EldritchHorror.GameLoopStateMachine);
            yield return typeof(EldritchHorror.PrepareGameStateMachine);
        }

        public static IEnumerable<Type> AllStatesMachineType()
        {
            yield return typeof(EldritchHorror.InitialEldritchMainState);
            yield return typeof(EldritchHorror.PrepareGameCycleMachineStateMachineState);
            yield return typeof(EldritchHorror.SelectionBossPrepareGameState);
            yield return typeof(EldritchHorror.SelectionGameBoxesPrepareGameState);
            yield return typeof(EldritchHorror.SelectionMythosCardPrepareGameState);
            yield return typeof(EldritchHorror.GameplayStateMachine.MythosPhase);
            yield return typeof(EldritchHorror.Core.AbstractStateMachineState);
        }
    }
}