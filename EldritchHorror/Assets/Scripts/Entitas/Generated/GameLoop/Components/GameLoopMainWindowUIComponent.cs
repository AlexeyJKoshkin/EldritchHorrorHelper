//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameLoopContext {

    public GameLoopEntity mainWindowUIEntity { get { return GetGroup(GameLoopMatcher.MainWindowUI).GetSingleEntity(); } }
    public EldritchHorror.Entitas.Components.MainWindowUIComponent mainWindowUI { get { return mainWindowUIEntity.mainWindowUI; } }
    public bool hasMainWindowUI { get { return mainWindowUIEntity != null; } }

    public GameLoopEntity SetMainWindowUI(EldritchHorror.UI.MainGameUIWindow newWindow) {
        if (hasMainWindowUI) {
            throw new Entitas.EntitasException("Could not set MainWindowUI!\n" + this + " already has an entity with EldritchHorror.Entitas.Components.MainWindowUIComponent!",
                "You should check if the context already has a mainWindowUIEntity before setting it or use context.ReplaceMainWindowUI().");
        }
        var entity = CreateEntity();
        entity.AddMainWindowUI(newWindow);
        return entity;
    }

    public void ReplaceMainWindowUI(EldritchHorror.UI.MainGameUIWindow newWindow) {
        var entity = mainWindowUIEntity;
        if (entity == null) {
            entity = SetMainWindowUI(newWindow);
        } else {
            entity.ReplaceMainWindowUI(newWindow);
        }
    }

    public void RemoveMainWindowUI() {
        mainWindowUIEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameLoopEntity {

    public EldritchHorror.Entitas.Components.MainWindowUIComponent mainWindowUI { get { return (EldritchHorror.Entitas.Components.MainWindowUIComponent)GetComponent(GameLoopComponentsLookup.MainWindowUI); } }
    public bool hasMainWindowUI { get { return HasComponent(GameLoopComponentsLookup.MainWindowUI); } }

    public void AddMainWindowUI(EldritchHorror.UI.MainGameUIWindow newWindow) {
        var index = GameLoopComponentsLookup.MainWindowUI;
        var component = (EldritchHorror.Entitas.Components.MainWindowUIComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.MainWindowUIComponent));
        component.Window = newWindow;
        AddComponent(index, component);
    }

    public void ReplaceMainWindowUI(EldritchHorror.UI.MainGameUIWindow newWindow) {
        var index = GameLoopComponentsLookup.MainWindowUI;
        var component = (EldritchHorror.Entitas.Components.MainWindowUIComponent)CreateComponent(index, typeof(EldritchHorror.Entitas.Components.MainWindowUIComponent));
        component.Window = newWindow;
        ReplaceComponent(index, component);
    }

    public void RemoveMainWindowUI() {
        RemoveComponent(GameLoopComponentsLookup.MainWindowUI);
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

    static Entitas.IMatcher<GameLoopEntity> _matcherMainWindowUI;

    public static Entitas.IMatcher<GameLoopEntity> MainWindowUI {
        get {
            if (_matcherMainWindowUI == null) {
                var matcher = (Entitas.Matcher<GameLoopEntity>)Entitas.Matcher<GameLoopEntity>.AllOf(GameLoopComponentsLookup.MainWindowUI);
                matcher.componentNames = GameLoopComponentsLookup.componentNames;
                _matcherMainWindowUI = matcher;
            }

            return _matcherMainWindowUI;
        }
    }
}