//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameLoopEntity {

    public EldritchHorror.Entitas.Components.OmenStateComponent omenState { get { return (EldritchHorror.Entitas.Components.OmenStateComponent)GetComponent(GameLoopComponentsLookup.OmenState); } }
    public bool hasOmenState { get { return HasComponent(GameLoopComponentsLookup.OmenState); } }

    public void AddOmenState(int newCurrentState) {
        var index = GameLoopComponentsLookup.OmenState;
        var component = (EldritchHorror.Entitas.Components.OmenStateComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.OmenStateComponent));
        component.CurrentState = newCurrentState;
        AddComponent(index, component);
    }

    public void ReplaceOmenState(int newCurrentState) {
        var index = GameLoopComponentsLookup.OmenState;
        var component = (EldritchHorror.Entitas.Components.OmenStateComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.OmenStateComponent));
        component.CurrentState = newCurrentState;
        ReplaceComponent(index, component);
    }

    public void RemoveOmenState() {
        RemoveComponent(GameLoopComponentsLookup.OmenState);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameLoopMatcher {

    static Entitas.IMatcher<GameLoopEntity> _matcherOmenState;

    public static Entitas.IMatcher<GameLoopEntity> OmenState {
        get {
            if (_matcherOmenState == null) {
                var matcher = (Entitas.Matcher<GameLoopEntity>)Entitas.Matcher<GameLoopEntity>.AllOf(GameLoopComponentsLookup.OmenState);
                matcher.componentNames = GameLoopComponentsLookup.componentNames;
                _matcherOmenState = matcher;
            }

            return _matcherOmenState;
        }
    }
}