using EldritchHorror.Data.Provider;
using UnityEngine;

namespace EldritchHorror.Cards
{
    public abstract class BaseGameCartSO : ScriptableObject, IDataObject
    {
        [HideInInspector] public Sprite FrontSprite;
        public virtual string UniqueID => name;
    }
}