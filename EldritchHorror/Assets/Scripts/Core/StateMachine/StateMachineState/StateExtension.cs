using System;

namespace EldritchHorror.Core
{
    public static class StateExtension
    {
        public static void Bind(this IStateTransition traMachineState, AbstractStateMachineState state)
        {
            state.AddTransaction(traMachineState);
        }

        public static IStateTransition To<T>(this StateTransaction transaction) where T : class, IStateMachineState
        {
            transaction.Type = typeof(T);
            return transaction;
        }

        public static StateTransaction AddNewTransition(this AbstractStateMachineState machineState, Func<bool> func)
        {
            var transition = new StateTransaction {Checker = func};
            return transition;
        }

        public static StateTransaction AddNewTransition(this AbstractStateMachineState machineState)
        {
            var transition = new StateTransaction {Checker = StateTransaction.AlwaysTrue};
            return transition;
        }
    }
}