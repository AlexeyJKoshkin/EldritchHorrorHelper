using UnityEngine;

namespace EldritchHorror.Data.Provider
{
    [CreateAssetMenu]
    public class EldritchHorrorScriptableProviderStorage : SOHolderProvider<DataBox>
    {
        public bool CreateNewIfMissed;
    }
}