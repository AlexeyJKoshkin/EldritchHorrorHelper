namespace EldritchHorror.EntitasSystems
{
    public interface ICurrentWindowProvider<TWindow>
    {
        TWindow Window { get; }
    }
}