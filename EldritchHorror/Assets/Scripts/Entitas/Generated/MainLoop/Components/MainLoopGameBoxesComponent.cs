//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MainLoopEntity {

    public EldritchHorror.Entitas.Components.GameBoxesComponent gameBoxes { get { return (EldritchHorror.Entitas.Components.GameBoxesComponent)GetComponent(MainLoopComponentsLookup.GameBoxes); } }
    public bool hasGameBoxes { get { return HasComponent(MainLoopComponentsLookup.GameBoxes); } }

    public void AddGameBoxes(System.Collections.Generic.List<EldritchHorror.Cards.GameBoxDef> newGameBoxes) {
        var index = MainLoopComponentsLookup.GameBoxes;
        var component = (EldritchHorror.Entitas.Components.GameBoxesComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.GameBoxesComponent));
        component.GameBoxes = newGameBoxes;
        AddComponent(index, component);
    }

    public void ReplaceGameBoxes(System.Collections.Generic.List<EldritchHorror.Cards.GameBoxDef> newGameBoxes) {
        var index = MainLoopComponentsLookup.GameBoxes;
        var component = (EldritchHorror.Entitas.Components.GameBoxesComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.GameBoxesComponent));
        component.GameBoxes = newGameBoxes;
        ReplaceComponent(index, component);
    }

    public void RemoveGameBoxes() {
        RemoveComponent(MainLoopComponentsLookup.GameBoxes);
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
public sealed partial class MainLoopMatcher {

    static Entitas.IMatcher<MainLoopEntity> _matcherGameBoxes;

    public static Entitas.IMatcher<MainLoopEntity> GameBoxes {
        get {
            if (_matcherGameBoxes == null) {
                var matcher = (Entitas.Matcher<MainLoopEntity>)Entitas.Matcher<MainLoopEntity>.AllOf(MainLoopComponentsLookup.GameBoxes);
                matcher.componentNames = MainLoopComponentsLookup.componentNames;
                _matcherGameBoxes = matcher;
            }

            return _matcherGameBoxes;
        }
    }
}
