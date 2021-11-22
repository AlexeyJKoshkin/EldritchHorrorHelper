using EldritchHorror.Data.Provider;
using UnityEngine;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    public abstract class BaseGameCartSO : ScriptableObject,IDataObject
    {
        public virtual string UniqueID => name;
    }
}