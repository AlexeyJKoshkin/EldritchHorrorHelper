//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EldritchCardEntity {

    public EldritchHorror.Entitas.Components.FrontSpriteComponent FrontSprite { get { return (EldritchHorror.Entitas.Components.FrontSpriteComponent)GetComponent(EldritchCardComponentsLookup.FontSprite); } }
    public bool hasFontSprite { get { return HasComponent(EldritchCardComponentsLookup.FontSprite); } }

    public void AddFrontSprite(UnityEngine.Sprite newSprite) {
        var index = EldritchCardComponentsLookup.FontSprite;
        var component = (EldritchHorror.Entitas.Components.FrontSpriteComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.FrontSpriteComponent));
        component.Sprite = newSprite;
        AddComponent(index, component);
    }

    public void ReplaceFontSprite(UnityEngine.Sprite newSprite) {
        var index = EldritchCardComponentsLookup.FontSprite;
        var component = (EldritchHorror.Entitas.Components.FrontSpriteComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.FrontSpriteComponent));
        component.Sprite = newSprite;
        ReplaceComponent(index, component);
    }

    public void RemoveFontSprite() {
        RemoveComponent(EldritchCardComponentsLookup.FontSprite);
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

    static Entitas.IMatcher<EldritchCardEntity> _matcherFontSprite;

    public static Entitas.IMatcher<EldritchCardEntity> FontSprite {
        get {
            if (_matcherFontSprite == null) {
                var matcher = (Entitas.Matcher<EldritchCardEntity>)Entitas.Matcher<EldritchCardEntity>.AllOf(EldritchCardComponentsLookup.FontSprite);
                matcher.componentNames = EldritchCardComponentsLookup.componentNames;
                _matcherFontSprite = matcher;
            }

            return _matcherFontSprite;
        }
    }
}