using System;
using System.Collections.Generic;

namespace EldritchHorror
{
    public class StateMachineTypesProvider
    {
        public static IEnumerable<Type> AllStateMachineType()
        {
            yield break;
        }

        public static IEnumerable<Type> AllStatesMachineType()
        {
            yield return typeof(EldritchHorror.InitialEldritchMainState);
            yield return typeof(EldritchHorror.SelectionBossPrepareGameState);
            yield return typeof(EldritchHorror.SelectionGameBoxesPrepareGameState);
            yield return typeof(EldritchHorror.SelectionMythosCardPrepareGameState);
            yield return typeof(EldritchHorror.GameplayStateMachine.MythosPhase);
        }
    }
}