using EldritchHorror.Cards;
using EldritchHorror.Entitas.Components;

public static class ContextExtension
{
    public static MythosCardEntity CreateMythosCard(this MythosCardContext context, MythosCardDataDefinition def)
    {
        var e = context.CreateEntity();
        e.AddMythosDef(def);
        e.AddMythosState(MythosStateCardType.Lock);
        return e;
    }
}