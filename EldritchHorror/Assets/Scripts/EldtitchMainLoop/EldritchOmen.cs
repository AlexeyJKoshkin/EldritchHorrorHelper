using EdlritchDefs.GamePlayDefs;
using Entitas;

namespace EldritchHorror
{
    public interface IEldritchOmen
    {
        OmenType CurrentType { get; }
        int Position { get; }

        void MoveNext();
        void MoveBack();
        void SetTo(int index);
    }
    
    public class EldritchOmen :IEldritchOmen
    {
        private readonly GameLoopContext _context;
        private GameLoopEntity OmenEntity => _context.masterEntityEntity;

        public EldritchOmen(IContext<GameLoopEntity>  context)
        {
            _context = context as GameLoopContext;
        }

        public OmenType CurrentType => OmenEntity.omenState.Omen;
        public int Position => OmenEntity.omenState.CurrentState;
        public void MoveNext()
        {
            int current = OmenEntity.omenState.GetNext();
            OmenEntity.ReplaceOmenState(current);
        }

        public void MoveBack()
        {
            int current = OmenEntity.omenState.GetPreviousNext();
            OmenEntity.ReplaceOmenState(current);
        }

        public void SetTo(int index)
        {
            OmenEntity.ReplaceOmenState(index);
        }
    }
}