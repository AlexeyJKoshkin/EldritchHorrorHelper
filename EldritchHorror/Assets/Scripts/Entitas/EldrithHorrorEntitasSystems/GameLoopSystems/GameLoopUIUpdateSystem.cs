#region

using EldritchHorror.UI;
using Entitas;
using System.Collections.Generic;

#endregion

namespace EldritchHorror.EntitasSystems
{
    /* 
     * Система при загрузке опознает роль игрока (Мастер/Ведущий сыщик/Простой игрок)
     * Обработчик в зависимости от роли включает/выключает UI элементы в зависимости от привелегий роли
     * Подписывается  на все ентити события
     * Шлет в обработчик команду при обновлении/удалении сущности
     */
       
    public class GameLoopUIUpdateSystem :  ITearDownSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;

        private readonly IGroup<GameLoopEntity> _group;

        public GameLoopUIUpdateSystem(Contexts contexts)
        {
            _contexts = contexts;
        //    _group = contexts.gameLoop.GetGroup(GameLoopMatcher.MainWindowUI);
        }
        
        public void Initialize()
        {
            /*var e = _group.GetSingleEntity();
            if (e != null)
            {
                GroupOnOnEntityAdded(_group, e, 1, null);
                return;
            }
          
            _group.OnEntityAdded += GroupOnOnEntityAdded;*/
        }

        private void GroupOnOnEntityAdded(IGroup<GameLoopEntity> @group, GameLoopEntity entity, int index, IComponent component)
        {
            _group.OnEntityAdded -= GroupOnOnEntityAdded;
         
       }


      



        public void TearDown() { }




       
    }
}