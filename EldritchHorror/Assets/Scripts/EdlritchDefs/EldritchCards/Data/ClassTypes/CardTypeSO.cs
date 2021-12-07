namespace EldritchHorror.Cards
{
    //Базовый тип карты
    public abstract class CardTypeSO : BaseGameCartSO
    {
        public abstract CardType Type { get; }
        public override string UniqueID => Type.ToString();
    }

    public enum CardType
    {
        Mythos,
        Ancient
    }
}