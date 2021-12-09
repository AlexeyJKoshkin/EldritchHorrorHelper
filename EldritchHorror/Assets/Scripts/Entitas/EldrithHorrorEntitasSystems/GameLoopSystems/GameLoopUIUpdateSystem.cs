using EldritchHorror.UI;
using Entitas;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EldritchHorror.EntitasSystems
{


    public abstract class AbstractUIUpdateSystem<TWindow,T> : ReactiveSystem<T> ,ICurrentWindowProvider<TWindow> where T : class, IEntity where TWindow : IEldritchWindow
    {
        TWindow ICurrentWindowProvider<TWindow>.Window => GetWindow();
        protected abstract TWindow GetWindow();

        protected readonly List<IUpdateUiReactionAdapter> UIHandler = new List<IUpdateUiReactionAdapter>();

        protected AbstractUIUpdateSystem(IContext<T> context) : base(context)
        {
            
        }
        
         protected  struct Builder<TE> where TE : class, IEntity
        {
            private List<IUpdateUiReactionAdapter> list;
            private UpdateUIReactionAdapter<TE> _adapter;
            private IGroup<TE> _group;
            private IContext<TE> _context;

            public Builder(Contexts contexts,  AbstractUIUpdateSystem<TWindow,T> gameLoopUiUpdateSystem)
            {
                list = gameLoopUiUpdateSystem.UIHandler;
                _context                = contexts.allContexts.FirstOrDefault(o => o is IContext<TE>) as IContext<TE>;
                _adapter                = null;
                _group                  = null;
            }

            public Builder<TE> CreateHandler([NotNull]IEntityUpdateHandlerUI<TE> handler)
            {
                _adapter = new UpdateUIReactionAdapter<TE>(_group, handler);
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
                _context                = null;
                _group                  = null;
                _adapter                = null;
            }
        }
    }

    public class GameLoopUIUpdateSystem : AbstractUIUpdateSystem<MainGameUIWindow,GameLoopEntity>
    {
        private readonly Contexts _contexts;

        protected override MainGameUIWindow GetWindow()
        {
            return _contexts.gameLoop.mainWindowUI.Window;
        }

        public GameLoopUIUpdateSystem(Contexts contexts) : base(contexts.gameLoop)
        {
            _contexts = contexts;
          
        }

        private void CreateAdapters()
        {
            OnEntityChange<MythosCardEntity>()
                .FromGroup(Matcher<MythosCardEntity>.AllOf(MythosCardMatcher.MythosDef, MythosCardMatcher.IsActiveMythos))
                .CreateHandler(new CurrentMythosEntityUpdateUIHandler(this)).Bind();


            OnEntityChange<GameLoopEntity>()
                .FromGroup(GameLoopMatcher.OmenState)
                .CreateHandler(new OmenEntityUpdateUIHandler(this)).Bind();
        }

        protected override ICollector<GameLoopEntity> GetTrigger(IContext<GameLoopEntity> context)
        {
            return context.CreateCollector(Matcher<GameLoopEntity>.AllOf(GameLoopMatcher.MainWindowUI));
        }

        protected override bool Filter(GameLoopEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameLoopEntity> entities)
        {
            var e = entities.SingleEntity();
            if (e.hasMainWindowUI)
            {
                PrepareWindow();
                SubscribeEvents();
            }
            else
            {
                UnSubscribeEvents();
            }
        }

        private void PrepareWindow()
        {
        }

        private void UnSubscribeEvents()
        {
            UIHandler.ForEach(e => e.StopListening());
        }


        private void SubscribeEvents()
        {
            CreateAdapters();
            UIHandler.ForEach(e => e.StartListening());
        }

        private Builder<T> OnEntityChange<T>() where T : class, IEntity
        {
            return new Builder<T>(_contexts, this);
        }
    }
}