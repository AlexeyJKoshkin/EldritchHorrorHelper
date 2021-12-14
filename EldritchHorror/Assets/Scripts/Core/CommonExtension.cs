#region

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

#endregion

namespace EldritchHorror
{
    public static class CommonExtension
    {
        public static T GetRandom<T>(this IList<T> list, bool remove = false)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }

            var n      = Random.Range(0, list.Count);
            var result = list[n];
            if (remove)
            {
                list.RemoveAt(n);
            }

            return result;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (action == null)
            {
                throw new NullReferenceException("Action");
            }

            foreach (T element in source) action(element);
        }

        public static T GetOrAddComponent<T>(this Component child) where T : Component
        {
            T result = child.GetComponent<T>();
            if (result == null)
            {
                return child.gameObject.AddComponent<T>();
            }

            return result;
        }

        public static T GetOrAddComponent<T>(this GameObject child) where T : Component
        {
            T result = child.GetComponent<T>();
            if (result == null)
            {
                return child.AddComponent<T>();
            }

            return result;
        }

        /// <summary>
        ///     Задает нового родителя и обнуляет позици, поворот и скейл
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent">новый родитель</param>
        public static void SetParentZero(this Transform child, Transform parent)
        {
            child.SetParent(parent);
            child.localScale       = Vector3.one;
            child.localPosition    = Vector3.zero;
            child.localEulerAngles = Vector3.zero;
        }

        /// <summary>
        ///     Задает нового родителя и обнуляет позицию
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent">новый родитель</param>
        public static void SetParentPositionZero(this Transform child, Transform parent)
        {
            child.SetParent(parent);
            child.localPosition = Vector3.zero;
        }
    }
}