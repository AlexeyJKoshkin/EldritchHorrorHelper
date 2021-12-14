#region

using EldritchHorror.GameplayStateMachine;
using System;
using System.Collections.Generic;

#endregion

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
            yield return typeof(InitialEldritchMainState);
            yield return typeof(SelectionBossPrepareGameState);
            yield return typeof(SelectionGameBoxesPrepareGameState);
            yield return typeof(SelectionMythosCardPrepareGameState);
            yield return typeof(PrepareGamePhase);
            yield return typeof(EncounterGamePhase);
            yield return typeof(MythosPhase);
        }
    }
}