//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EldritchCardEntity {

    public EldritchHorror.Entitas.Components.MythosComponent mythos { get { return (EldritchHorror.Entitas.Components.MythosComponent)GetComponent(EldritchCardComponentsLookup.Mythos); } }
    public bool hasMythos { get { return HasComponent(EldritchCardComponentsLookup.Mythos); } }

    public void AddMythos(EldritchHorror.Cards.MythosCardDataDefinition newDef) {
        var index = EldritchCardComponentsLookup.Mythos;
        var component = (EldritchHorror.Entitas.Components.MythosComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.MythosComponent));
        component.Def = newDef;
        AddComponent(index, component);
    }

    public void ReplaceMythos(EldritchHorror.Cards.MythosCardDataDefinition newDef) {
        var index = EldritchCardComponentsLookup.Mythos;
        var component = (EldritchHorror.Entitas.Components.MythosComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.MythosComponent));
        component.Def = newDef;
        ReplaceComponent(index, component);
    }

    public void RemoveMythos() {
        RemoveComponent(EldritchCardComponentsLookup.Mythos);
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

    static Entitas.IMatcher<EldritchCardEntity> _matcherMythos;

    public static Entitas.IMatcher<EldritchCardEntity> Mythos {
        get {
            if (_matcherMythos == null) {
                var matcher = (Entitas.Matcher<EldritchCardEntity>)Entitas.Matcher<EldritchCardEntity>.AllOf(EldritchCardComponentsLookup.Mythos);
                matcher.componentNames = EldritchCardComponentsLookup.componentNames;
                _matcherMythos = matcher;
            }

            return _matcherMythos;
        }
    }
}
