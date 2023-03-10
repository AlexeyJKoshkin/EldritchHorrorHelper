//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameLoopEntity {

    public EldritchHorror.Entitas.Components.AmericaCardDeckComponent americaCardDeck { get { return (EldritchHorror.Entitas.Components.AmericaCardDeckComponent)GetComponent(GameLoopComponentsLookup.AmericaCardDeck); } }
    public bool hasAmericaCardDeck { get { return HasComponent(GameLoopComponentsLookup.AmericaCardDeck); } }

    public void AddAmericaCardDeck(System.Collections.Generic.Queue<EldritchCardEntity> newCardOrder) {
        var index = GameLoopComponentsLookup.AmericaCardDeck;
        var component = (EldritchHorror.Entitas.Components.AmericaCardDeckComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.AmericaCardDeckComponent));
        component.CardOrder = newCardOrder;
        AddComponent(index, component);
    }

    public void ReplaceAmericaCardDeck(System.Collections.Generic.Queue<EldritchCardEntity> newCardOrder) {
        var index = GameLoopComponentsLookup.AmericaCardDeck;
        var component = (EldritchHorror.Entitas.Components.AmericaCardDeckComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.AmericaCardDeckComponent));
        component.CardOrder = newCardOrder;
        ReplaceComponent(index, component);
    }

    public void RemoveAmericaCardDeck() {
        RemoveComponent(GameLoopComponentsLookup.AmericaCardDeck);
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

    static Entitas.IMatcher<GameLoopEntity> _matcherAmericaCardDeck;

    public static Entitas.IMatcher<GameLoopEntity> AmericaCardDeck {
        get {
            if (_matcherAmericaCardDeck == null) {
                var matcher = (Entitas.Matcher<GameLoopEntity>)Entitas.Matcher<GameLoopEntity>.AllOf(GameLoopComponentsLookup.AmericaCardDeck);
                matcher.componentNames = GameLoopComponentsLookup.componentNames;
                _matcherAmericaCardDeck = matcher;
            }

            return _matcherAmericaCardDeck;
        }
    }
}
