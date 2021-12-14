#region

using EldritchHorror.Data.Provider;
using GameKit;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace EldritchHorror.Cards
{
    public abstract class BaseGameCartSO : ScriptableObject, IDataObject
    {
       
        public virtual string UniqueID => name;
    }
}