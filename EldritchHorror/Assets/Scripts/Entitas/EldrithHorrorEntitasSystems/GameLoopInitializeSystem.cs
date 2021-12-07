using EldritchHorror.Cards;
using EldritchHorror.Entitas.Components;
using EldritchHorror.UI;
using Entitas;
using System.Collections.Generic;
using System.Linq;

namespace EldritchHorror.EntitasSystems
{
    /// <summary>
    ///     Инициализация игрового состояния.
    ///     запускается после того как MainLoop стал IsReady
    /// </summary>
    public class GameLoopInitializeSystem : ReactiveSystem<MainLoopEntity>
    {
        private readonly Contexts _contexts;
        private readonly IMythosCardEntityGenerator _mythosCardEntityGenerator;

        public GameLoopInitializeSystem(Contexts contexts,IMythosCardEntityGenerator mythosCardEntityGenerator) : base(contexts.mainLoop)
        {
            _contexts = contexts;
            _mythosCardEntityGenerator = mythosCardEntityGenerator;
        }


        protected override ICollector<MainLoopEntity> GetTrigger(IContext<MainLoopEntity> context)
        {
            return context.CreateCollector(MainLoopMatcher.AllOf(MainLoopMatcher.UserProfile, MainLoopMatcher.IsReady));
        }

        protected override bool Filter(MainLoopEntity entity)
        {
            return true;
        }

        protected override void Execute(List<MainLoopEntity> entities)
        {
            var profile = entities.SingleEntity().userProfile;
            var mythosCardDef = _mythosCardEntityGenerator.GenerateBySave(profile); // cгeненерировали entity -карты мифов для игры
            GenerateEntities(mythosCardDef);
        }

        private void GenerateEntities(List<MythosCardDataDefinition> mythosCardGameDefinitions)
        {
            CreateMainLoopEntity();
            CreateMythosEntity(mythosCardGameDefinitions);
        }

        private void CreateMythosEntity(List<MythosCardDataDefinition> mythosCardGameDefinitions)
        {
            Queue<MythosCardEntity> queue = new Queue<MythosCardEntity>();
            //из даннных карты мифа создали entity и впихнули его в очередь
            mythosCardGameDefinitions.Select(_contexts.mythosCard.CreateMythosCard).ForEach(queue.Enqueue);

            _contexts.gameLoop.masterEntityEntity.ReplaceInGameMythosCards( new List<MythosCardEntity>(), queue);
        }

        private void CreateMainLoopEntity()
        {
            var master = _contexts.gameLoop.CreateEntity();
            master.isMasterEntity = true;
            master.AddOmenState(0);
            master.AddTurnCounter(0);
        }
    }

    public static class MythosCardContextExtension
    {
        public static MythosCardEntity CreateMythosCard(this  MythosCardContext context,MythosCardDataDefinition arg)
        {
            if (context == null) return null;
            var e = context.CreateEntity();
            e.AddMythosDef(arg);
            e.AddMythosState(MythosStateCardType.Lock);
            return e;
        }
        
    }
}