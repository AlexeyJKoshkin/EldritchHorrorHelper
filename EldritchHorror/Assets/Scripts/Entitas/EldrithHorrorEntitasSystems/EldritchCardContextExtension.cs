using EldritchHorror.Cards;
using EldritchHorror.Entitas.Components;
using UnityEngine;

namespace EldritchHorror.EntitasSystems
{
    public static class EldritchCardContextExtension
    {
        public static EldritchCardEntity CreateMythosCard(this EldritchCardContext context, MythosCardDataDefinition arg)
        {
            var e = context.CreateCard(arg.MythosCardType.Back, arg.FrontSprite);
            e.AddMythos(arg);
            e.AddMythosState(MythosStateCardType.Lock);
            return e;
        }

        public static EldritchCardEntity CreateEncounter(this EldritchCardContext context, EncounterCardDefinition definition)
        {
            var e = context.CreateCard(definition.EncounterType.Back, definition.FrontSprite);
            e.AddEncounter(definition);
            return e;
        }

        private static EldritchCardEntity CreateCard(this EldritchCardContext context, Sprite back, Sprite front)
        {
            var e = context.CreateEntity();
            e.AddBackSprite(back);
            e.AddFrontSprite(front);
            return e;
        }
    }
}