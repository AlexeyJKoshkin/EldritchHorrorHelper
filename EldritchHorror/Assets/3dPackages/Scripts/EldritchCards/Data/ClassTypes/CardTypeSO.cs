using Sirenix.OdinInspector;
using UnityEngine;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    //Базовый тип карты
    public abstract class CardTypeSO : BaseGameCartSO
    {
        public abstract CardType Type { get; }
        public override string UniqueID => Type.ToString();
        [PreviewField( 100,ObjectFieldAlignment.Center)]
        public Sprite BackSprite;

    }

    public enum CardType
    {
        Mythos
    }
}