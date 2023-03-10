//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameLoopEntity {

    public EldritchHorror.Entitas.Components.OtherWorldCardDeckComponent otherWorldCardDeck { get { return (EldritchHorror.Entitas.Components.OtherWorldCardDeckComponent)GetComponent(GameLoopComponentsLookup.OtherWorldCardDeck); } }
    public bool hasOtherWorldCardDeck { get { return HasComponent(GameLoopComponentsLookup.OtherWorldCardDeck); } }

    public void AddOtherWorldCardDeck(System.Collections.Generic.Queue<EldritchCardEntity> newCardOrder) {
        var index = GameLoopComponentsLookup.OtherWorldCardDeck;
        var component = (EldritchHorror.Entitas.Components.OtherWorldCardDeckComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.OtherWorldCardDeckComponent));
        component.CardOrder = newCardOrder;
        AddComponent(index, component);
    }

    public void ReplaceOtherWorldCardDeck(System.Collections.Generic.Queue<EldritchCardEntity> newCardOrder) {
        var index = GameLoopComponentsLookup.OtherWorldCardDeck;
        var component = (EldritchHorror.Entitas.Components.OtherWorldCardDeckComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.OtherWorldCardDeckComponent));
        component.CardOrder = newCardOrder;
        ReplaceComponent(index, component);
    }

    public void RemoveOtherWorldCardDeck() {
        RemoveComponent(GameLoopComponentsLookup.OtherWorldCardDeck);
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

    static Entitas.IMatcher<GameLoopEntity> _matcherOtherWorldCardDeck;

    public static Entitas.IMatcher<GameLoopEntity> OtherWorldCardDeck {
        get {
            if (_matcherOtherWorldCardDeck == null) {
                var matcher = (Entitas.Matcher<GameLoopEntity>)Entitas.Matcher<GameLoopEntity>.AllOf(GameLoopComponentsLookup.OtherWorldCardDeck);
                matcher.componentNames = GameLoopComponentsLookup.componentNames;
                _matcherOtherWorldCardDeck = matcher;
            }

            return _matcherOtherWorldCardDeck;
        }
    }
}
