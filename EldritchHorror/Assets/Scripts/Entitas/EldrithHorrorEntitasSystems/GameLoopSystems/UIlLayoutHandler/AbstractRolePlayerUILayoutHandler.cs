using EldritchHorror.UI;
using Entitas;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EldritchHorror.EntitasSystems
{
    public abstract class AbstractRolePlayerUILayoutHandler : IEnumerable<IUpdateUiReactionAdapter>
    {
        protected MainGameUIWindow Window => _contexts.gameLoop.mainWindowUI.Window;
        
        private readonly List<IUpdateUiReactionAdapter> _uiHandler = new List<IUpdateUiReactionAdapter>();
        private readonly Contexts _contexts;

        protected AbstractRolePlayerUILayoutHandler(Contexts context)
        {
            _contexts = context;
            CreateAdapters();
        }
        
        void CreateAdapters()
        {
            OnEntityChange<EldritchCardEntity>()
                .FromGroup(Matcher<EldritchCardEntity>.AllOf(EldritchCardMatcher.Mythos, EldritchCardMatcher.IsActiveMythos))
                .CreateHandler(UpdateCurrentMythos, RemoveCurrentMythosHandler).Bind();
            
            OnEntityChange<EldritchCardEntity>()
                .FromGroup(Matcher<EldritchCardEntity>.AllOf(EldritchCardMatcher.Mythos, EldritchCardMatcher.InProcessType))
                .CreateHandler(OnAddProcessCard, RemoveProcessCard).Bind();
          
           
            OnEntityChange<GameLoopEntity>()
                .FromGroup(Matcher<GameLoopEntity>.AnyOf(GameLoopMatcher.AmericaCardDeck, 
                                                         GameLoopMatcher.EuropeCardDeck, 
                                                         GameLoopMatcher.AsiaAustraliaCardDeck,
                                                         GameLoopMatcher.GeneralCardDeck,
                                                         GameLoopMatcher.OtherWorldCardDeck))
                .CreateHandler(UpdateEncounterCard, null).Bind();
            
            
            //обновляем задник карт и знамение
            OnEntityChange<GameLoopEntity>()
                .FromGroup(Matcher<GameLoopEntity>.AnyOf(GameLoopMatcher.InGameMythosDeck, GameLoopMatcher.OmenState, GameLoopMatcher.TurnCounter))
                .CreateHandler(UpdateGeneralGameStateUI, null).Bind();
        }

        protected virtual void UpdateCurrentMythos(EldritchCardEntity entity, int index, IComponent component) { }
        protected virtual void RemoveCurrentMythosHandler(EldritchCardEntity entity, int index) { }
        protected virtual void RemoveProcessCard(EldritchCardEntity entity, int index) { }
        protected virtual void OnAddProcessCard(EldritchCardEntity entity, int index, IComponent component) { }
        protected virtual void UpdateGeneralGameStateUI(GameLoopEntity entity, int index, IComponent component) { }
        public virtual void ExitMythosPhase(GameLoopEntity stateEntity) { }
        public virtual void EnterMythosPhase(GameLoopEntity stateEntity) { }
        public virtual void EnterEncounterPhase(GameLoopEntity stateEntity) { }

        public virtual void ExitEncounterPhase(GameLoopEntity stateEntity) { }
        protected virtual void UpdateEncounterCard(GameLoopEntity entity, int index, IComponent component) { }

        private Builder<T> OnEntityChange<T>() where T : class, IEntity
        {
            return new Builder<T>(_contexts, this);
        }

        protected struct Builder<TE> where TE : class, IEntity
        {
            private List<IUpdateUiReactionAdapter> list;
            private UpdateUIReactionAdapter<TE> _adapter;
            private IGroup<TE> _group;
            private IContext<TE> _context;

            public Builder(Contexts contexts, AbstractRolePlayerUILayoutHandler gameLoopUiUpdateSystem)
            {
                list     = gameLoopUiUpdateSystem._uiHandler;
                _context = contexts.allContexts.FirstOrDefault(o => o is IContext<TE>) as IContext<TE>;
                _adapter = null;
                _group   = null;
            }

            public Builder<TE> CreateHandler([NotNull] IEntityUpdateHandlerUI<TE> handler)
            {
                _adapter = new UpdateUIReactionAdapter<TE>(_group, handler);
                return this;
            }

            public Builder<TE> CreateHandler(OnUpdateEntityUIHandler<TE> updateCurrentMythosView, OnRemoveEntityUIHandler<TE> clearMythosView)
            {
                _adapter = new UpdateUIReactionAdapter<TE>(_group, updateCurrentMythosView, clearMythosView);
                return this;
            }

            public Builder<TE> FromGroup(IMatcher<TE> matcher)
            {
                _group = _context.GetGroup(matcher);
                return this;
            }

            public void Bind()
            {
                list.Add(_adapter);
                _context = null;
                _group   = null;
                _adapter = null;
            }
        }
        

        public IEnumerator<IUpdateUiReactionAdapter> GetEnumerator()
        {
            return _uiHandler.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}