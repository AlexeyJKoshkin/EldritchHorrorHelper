//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class EldritchCardMatcher {

    public static Entitas.IAllOfMatcher<EldritchCardEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<EldritchCardEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<EldritchCardEntity> AllOf(params Entitas.IMatcher<EldritchCardEntity>[] matchers) {
          return Entitas.Matcher<EldritchCardEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<EldritchCardEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<EldritchCardEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<EldritchCardEntity> AnyOf(params Entitas.IMatcher<EldritchCardEntity>[] matchers) {
          return Entitas.Matcher<EldritchCardEntity>.AnyOf(matchers);
    }
}
