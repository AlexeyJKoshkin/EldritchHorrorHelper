using EldritchHorror.UI;
using Entitas;

namespace EldritchHorror.EntitasSystems
{
    abstract class EntityUpdateUIHandler<TWindow, TEntity> : IEntityUpdateHandlerUI<TEntity> where TEntity : class, IEntity where TWindow : IEldritchWindow
    {
        private readonly ICurrentWindowProvider<TWindow> _windowProvider;
        protected TWindow Window => _windowProvider.Window;

        public EntityUpdateUIHandler(ICurrentWindowProvider<TWindow> windowProvider)
        {
            _windowProvider = windowProvider;
        }

        public abstract void ClearFromEntity(TEntity entity);
      
        public abstract void UpdateEntityUI(TEntity entity, int index, IComponent component);

    }
    
    abstract class EntityUpdateUIHandlerMainWindow<TEntity> : EntityUpdateUIHandler<MainGameUIWindow, TEntity> where TEntity : class, IEntity
    {
        protected EntityUpdateUIHandlerMainWindow(ICurrentWindowProvider<MainGameUIWindow> windowProvider) : base(windowProvider)
        {
        }
    }
}