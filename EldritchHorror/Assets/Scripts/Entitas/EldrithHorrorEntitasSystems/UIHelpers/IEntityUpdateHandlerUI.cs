#region

using Entitas;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public interface IEntityUpdateHandlerUI<in T> where T : class, IEntity
    {
        void ClearFromEntity(T entity, int index);
        void UpdateEntityUI(T entity, int index, IComponent component);
    }
}