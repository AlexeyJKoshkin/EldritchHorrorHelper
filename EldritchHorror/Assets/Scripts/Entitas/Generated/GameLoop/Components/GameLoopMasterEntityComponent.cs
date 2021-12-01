//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameLoopContext {

    public GameLoopEntity masterEntityEntity { get { return GetGroup(GameLoopMatcher.MasterEntity).GetSingleEntity(); } }

    public bool isMasterEntity {
        get { return masterEntityEntity != null; }
        set {
            var entity = masterEntityEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isMasterEntity = true;
                } else {
                    entity.Destroy();
                }
            }
        }
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

    static readonly EldritchHorror.Entitas.Components.MasterEntityComponent masterEntityComponent = new EldritchHorror.Entitas.Components.MasterEntityComponent();

    public bool isMasterEntity {
        get { return HasComponent(GameLoopComponentsLookup.MasterEntity); }
        set {
            if (value != isMasterEntity) {
                var index = GameLoopComponentsLookup.MasterEntity;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : masterEntityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameLoopEntity> _matcherMasterEntity;

    public static Entitas.IMatcher<GameLoopEntity> MasterEntity {
        get {
            if (_matcherMasterEntity == null) {
                var matcher = (Entitas.Matcher<GameLoopEntity>)Entitas.Matcher<GameLoopEntity>.AllOf(GameLoopComponentsLookup.MasterEntity);
                matcher.componentNames = GameLoopComponentsLookup.componentNames;
                _matcherMasterEntity = matcher;
            }

            return _matcherMasterEntity;
        }
    }
}
