using Entitas;

namespace EldritchHorror.EntitasSystems
{
    public interface IEntityUpdateHandlerUI<in T>  where T : class, IEntity
    {
        void ClearFromEntity(T entity);
        void UpdateEntityUI(T entity, int index, IComponent component);
    }
}