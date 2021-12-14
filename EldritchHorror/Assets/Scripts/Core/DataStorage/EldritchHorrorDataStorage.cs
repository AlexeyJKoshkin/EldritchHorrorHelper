#region

using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using GameKit.Editor;
using UnityEditor;

#endif

#endregion

namespace EldritchHorror.Data.Provider
{
    [CreateAssetMenu]
    public class EldritchHorrorDataStorage : SOHolderProvider<DataBox>
    {
        public bool CreateNewIfMissed;
#if UNITY_EDITOR


        [Button]
        private void Generate()
        {
            var                possibleTypes    = ReflectionHelper.GetAllTypesInSolution<DataBox>();
            SerializedObject   serializedObject = new SerializedObject(this);
            SerializedProperty listProperty     = serializedObject.FindProperty("_items");
            foreach (var type in possibleTypes)
            {
                if (Collection.Any(o => o.GetType() == type))
                {
                    continue;
                }

                var asset = EditorUtils.FindAsset(type, Path);
                if (asset == null)
                {
                    string path = Path + $"/{type.Name}.asset";
                    asset = EditorUtils.LoadAsset(type, path, true, true);
                }

                listProperty.InsertArrayElementAtIndex(0);
                listProperty.GetArrayElementAtIndex(0).objectReferenceValue = asset;
            }

            EditorUtility.SetDirty(this);
        }
#endif
    }
}