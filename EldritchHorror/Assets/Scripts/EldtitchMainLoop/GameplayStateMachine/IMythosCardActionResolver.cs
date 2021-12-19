#region

using EldritchHorror.EntitasSystems;
using EldritchHorror.UI;
using Entitas;
using System.Collections.Generic;

#endregion

namespace EldritchHorror.GameplayStateMachine
{
    public interface IMythosCardActionResolver
    {
        void Handle(EldritchCardEntity current);
    }

    public class MythosCardActionResolver : ReactiveSystem<EldritchCardEntity>
    {
        public MythosCardActionResolver(ICollector<EldritchCardEntity> collector) : base(collector)
        {
        }

        protected override ICollector<EldritchCardEntity> GetTrigger(IContext<EldritchCardEntity> context)
        {
            return context.CreateCollector(Matcher<EldritchCardEntity>.AllOf(EldritchCardMatcher.Mythos, EldritchCardMatcher.IsActiveMythos));
        }

        protected override bool Filter(EldritchCardEntity entity)
        {
            return true;
        }

        protected override void Execute(List<EldritchCardEntity> entities)
        {
            var e = entities.SingleEntity();

            //   e.isActiveRumor = e.mythosDef.MythosType
        }
    }
}