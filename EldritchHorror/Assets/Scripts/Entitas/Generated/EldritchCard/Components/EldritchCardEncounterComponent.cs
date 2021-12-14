//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EldritchCardEntity {

    public EldritchHorror.Entitas.Components.EncounterComponent encounter { get { return (EldritchHorror.Entitas.Components.EncounterComponent)GetComponent(EldritchCardComponentsLookup.Encounter); } }
    public bool hasEncounter { get { return HasComponent(EldritchCardComponentsLookup.Encounter); } }

    public void AddEncounter(EldritchHorror.Cards.EncounterCardDefinition newCardDefinition) {
        var index = EldritchCardComponentsLookup.Encounter;
        var component = (EldritchHorror.Entitas.Components.EncounterComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.EncounterComponent));
        component.CardDefinition = newCardDefinition;
        AddComponent(index, component);
    }

    public void ReplaceEncounter(EldritchHorror.Cards.EncounterCardDefinition newCardDefinition) {
        var index = EldritchCardComponentsLookup.Encounter;
        var component = (EldritchHorror.Entitas.Components.EncounterComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.EncounterComponent));
        component.CardDefinition = newCardDefinition;
        ReplaceComponent(index, component);
    }

    public void RemoveEncounter() {
        RemoveComponent(EldritchCardComponentsLookup.Encounter);
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
public sealed partial class EldritchCardMatcher {

    static Entitas.IMatcher<EldritchCardEntity> _matcherEncounter;

    public static Entitas.IMatcher<EldritchCardEntity> Encounter {
        get {
            if (_matcherEncounter == null) {
                var matcher = (Entitas.Matcher<EldritchCardEntity>)Entitas.Matcher<EldritchCardEntity>.AllOf(EldritchCardComponentsLookup.Encounter);
                matcher.componentNames = EldritchCardComponentsLookup.componentNames;
                _matcherEncounter = matcher;
            }

            return _matcherEncounter;
        }
    }
}
