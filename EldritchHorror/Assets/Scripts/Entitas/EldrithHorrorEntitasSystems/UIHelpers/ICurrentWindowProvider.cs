namespace EldritchHorror.EntitasSystems
{
    interface ICurrentWindowProvider<TWindow>
    {
        TWindow Window { get; }
    }
}