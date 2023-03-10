#region

using GameKit.Editor;
using System;
using System.Collections.Generic;
using UnityEngine;

#endregion

namespace EldritchHorror
{
    public class SingletonSettings<T> : ScriptableObject where T : SingletonSettings<T>
    {
        public const string ROOT_FOLDER_NAME = "EldritchHorrorProjectSettings";
        private static Dictionary<Type, string> _folderNames = new Dictionary<Type, string>();

        private static T _instance;
        public static T Instance
        {
            get
            {
                _instance = EditorUtils.FindAsset<T>();
                if (_instance == null)
                {
                    _instance = CreateSettings<T>();
                }

                return _instance;
            }
        }

        private static TSingletonSettings CreateSettings<TSingletonSettings>() where TSingletonSettings : SingletonSettings<TSingletonSettings>
        {
            var rootpath = "Assets/" + ROOT_FOLDER_NAME + "/";
            EditorUtils.CreateAssetFolder(rootpath);

            string folderName = "";
            Type   type       = typeof(T);
            string path       = null;
            if (_folderNames.TryGetValue(type, out folderName))
            {
                string folderPath = rootpath + folderName;
                EditorUtils.CreateAssetFolder(folderPath);
                path = folderPath + type.Name + ".asset";
            }
            else
            {
                path = rootpath + type.Name + ".asset";
            }

            return EditorUtils.CreateAsset<TSingletonSettings>(path);
        }
    }
}