//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameLoopEntity {

    public EldritchHorror.Entitas.Components.AsiaAustraliaCardDeckComponent asiaAustraliaCardDeck { get { return (EldritchHorror.Entitas.Components.AsiaAustraliaCardDeckComponent)GetComponent(GameLoopComponentsLookup.AsiaAustraliaCardDeck); } }
    public bool hasAsiaAustraliaCardDeck { get { return HasComponent(GameLoopComponentsLookup.AsiaAustraliaCardDeck); } }

    public void AddAsiaAustraliaCardDeck(System.Collections.Generic.Queue<EldritchCardEntity> newCardOrder) {
        var index = GameLoopComponentsLookup.AsiaAustraliaCardDeck;
        var component = (EldritchHorror.Entitas.Components.AsiaAustraliaCardDeckComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.AsiaAustraliaCardDeckComponent));
        component.CardOrder = newCardOrder;
        AddComponent(index, component);
    }

    public void ReplaceAsiaAustraliaCardDeck(System.Collections.Generic.Queue<EldritchCardEntity> newCardOrder) {
        var index = GameLoopComponentsLookup.AsiaAustraliaCardDeck;
        var component = (EldritchHorror.Entitas.Components.AsiaAustraliaCardDeckComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.AsiaAustraliaCardDeckComponent));
        component.CardOrder = newCardOrder;
        ReplaceComponent(index, component);
    }

    public void RemoveAsiaAustraliaCardDeck() {
        RemoveComponent(GameLoopComponentsLookup.AsiaAustraliaCardDeck);
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

    static Entitas.IMatcher<GameLoopEntity> _matcherAsiaAustraliaCardDeck;

    public static Entitas.IMatcher<GameLoopEntity> AsiaAustraliaCardDeck {
        get {
            if (_matcherAsiaAustraliaCardDeck == null) {
                var matcher = (Entitas.Matcher<GameLoopEntity>)Entitas.Matcher<GameLoopEntity>.AllOf(GameLoopComponentsLookup.AsiaAustraliaCardDeck);
                matcher.componentNames = GameLoopComponentsLookup.componentNames;
                _matcherAsiaAustraliaCardDeck = matcher;
            }

            return _matcherAsiaAustraliaCardDeck;
        }
    }
}
