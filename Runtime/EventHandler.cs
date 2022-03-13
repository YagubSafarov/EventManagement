namespace EventManagement
{
    using UnityEngine;
    using System.Collections.Generic;
    using System;
    using System.Linq;


    public class EventHandler
    {
        private static Dictionary<string, List<object>> m_simpleEventMap = new Dictionary<string, List<object>>();
        private static Dictionary<string, Dictionary<GameObject, List<object>>> m_objectEventMap = new Dictionary<string, Dictionary<GameObject, List<object>>>();

        private delegate void IterateSimpleEventMapCallback(object actionObject);
        private delegate void IterateObjectEventMapCallback(GameObject go, object actionObject);

        public static void RegisterEvent(GameObject go, string eventName, Action action) => AddToObjectEventMap(go, eventName, action);
        public static void RegisterEvent<T1>(GameObject go, string eventName, Action<T1> action) => AddToObjectEventMap(go, eventName, action);
        public static void RegisterEvent<T1, T2>(GameObject go, string eventName, Action<T1, T2> action) => AddToObjectEventMap(go, eventName, action);
        public static void RegisterEvent<T1, T2, T3>(GameObject go, string eventName, Action<T1, T2, T3> action) => AddToObjectEventMap(go, eventName, action);
        public static void RegisterEvent<T1, T2, T3, T4>(GameObject go, string eventName, Action<T1, T2, T3, T4> action) => AddToObjectEventMap(go, eventName, action);
        public static void RegisterEvent<T1, T2, T3, T4, T5>(GameObject go, string eventName, Action<T1, T2, T3, T4, T5> action) => AddToObjectEventMap(go, eventName, action);
        public static void RegisterEvent<T1, T2, T3, T4, T5, T6>(GameObject go, string eventName, Action<T1, T2, T3, T4, T5, T6> action) => AddToObjectEventMap(go, eventName, action);

        public static void RegisterEvent(string eventName, Action action) => AddToSimpleEventMap(eventName, action);
        public static void RegisterEvent<T1>(string eventName, Action<T1> action) => AddToSimpleEventMap(eventName, action);
        public static void RegisterEvent<T1, T2>(string eventName, Action<T1, T2> action) => AddToSimpleEventMap(eventName, action);
        public static void RegisterEvent<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) => AddToSimpleEventMap(eventName, action);
        public static void RegisterEvent<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) => AddToSimpleEventMap(eventName, action);
        public static void RegisterEvent<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) => AddToSimpleEventMap(eventName, action);
        public static void RegisterEvent<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) => AddToSimpleEventMap(eventName, action);


        public static void UnregisterEvent(GameObject go, string eventName, Action action) => RemoveFromObjectEventMap(go, eventName, action);
        public static void UnregisterEvent<T1>(GameObject go, string eventName, Action<T1> action) => RemoveFromObjectEventMap(go, eventName, action);
        public static void UnregisterEvent<T1, T2>(GameObject go, string eventName, Action<T1, T2> action) => RemoveFromObjectEventMap(go, eventName, action);
        public static void UnregisterEvent<T1, T2, T3>(GameObject go, string eventName, Action<T1, T2, T3> action) => RemoveFromObjectEventMap(go, eventName, action);
        public static void UnregisterEvent<T1, T2, T3, T4>(GameObject go, string eventName, Action<T1, T2, T3, T4> action) => RemoveFromObjectEventMap(go, eventName, action);
        public static void UnregisterEvent<T1, T2, T3, T4, T5>(GameObject go, string eventName, Action<T1, T2, T3, T4, T5> action) => RemoveFromObjectEventMap(go, eventName, action);
        public static void UnregisterEvent<T1, T2, T3, T4, T5, T6>(GameObject go, string eventName, Action<T1, T2, T3, T4, T5, T6> action) => RemoveFromObjectEventMap(go, eventName, action);

        public static void UnregisterEvent(string eventName, Action action) => RemoveFromSimpleEventMap(eventName, action);
        public static void UnregisterEvent<T1>(string eventName, Action<T1> action) => RemoveFromSimpleEventMap(eventName, action);
        public static void UnregisterEvent<T1, T2>(string eventName, Action<T1, T2> action) => RemoveFromSimpleEventMap(eventName, action);
        public static void UnregisterEvent<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) => RemoveFromSimpleEventMap(eventName, action);
        public static void UnregisterEvent<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) => RemoveFromSimpleEventMap(eventName, action);
        public static void UnregisterEvent<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) => RemoveFromSimpleEventMap(eventName, action);
        public static void UnregisterEvent<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) => RemoveFromSimpleEventMap(eventName, action);


        public static void ExecuteEvent(GameObject sender, string eventName) => IterateObjectMap(eventName, (go, actionObject) =>
        {
            if (ReferenceEquals(sender, go) && actionObject is Action action)
                action?.Invoke();
        });

        public static void ExecuteEvent<T1>(GameObject sender, string eventName, T1 arg1) => IterateObjectMap(eventName, (go, actionObject) =>
        {
            if (ReferenceEquals(sender, go) && actionObject is Action<T1> action)
                action?.Invoke(arg1);
        });

        public static void ExecuteEvent<T1, T2>(GameObject sender, string eventName, T1 arg1, T2 arg2) => IterateObjectMap(eventName, (go, actionObject) =>
        {
            if (ReferenceEquals(sender, go) && actionObject is Action<T1, T2> action)
                action?.Invoke(arg1, arg2);
        });

        public static void ExecuteEvent<T1, T2, T3>(GameObject sender, string eventName, T1 arg1, T2 arg2, T3 arg3) => IterateObjectMap(eventName, (go, actionObject) =>
        {
            if (ReferenceEquals(sender, go) && actionObject is Action<T1, T2, T3> action)
                action?.Invoke(arg1, arg2, arg3);
        });

        public static void ExecuteEvent<T1, T2, T3, T4>(GameObject sender, string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => IterateObjectMap(eventName, (go, actionObject) =>
        {
            if (ReferenceEquals(sender, go) && actionObject is Action<T1, T2, T3, T4> action)
                action?.Invoke(arg1, arg2, arg3, arg4);
        });

        public static void ExecuteEvent<T1, T2, T3, T4, T5>(GameObject sender, string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => IterateObjectMap(eventName, (go, actionObject) =>
        {
            if (ReferenceEquals(sender, go) && actionObject is Action<T1, T2, T3, T4, T5> action)
                action?.Invoke(arg1, arg2, arg3, arg4, arg5);
        });

        public static void ExecuteEvent<T1, T2, T3, T4, T5, T6>(GameObject sender, string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => IterateObjectMap(eventName, (go, actionObject) =>
        {
            if (ReferenceEquals(sender, go) && actionObject is Action<T1, T2, T3, T4, T5, T6> action)
                action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        });

        public static void ExecuteEvent(string eventName) => IterateSimpleMap(eventName, actionObject =>
        {
            if (actionObject is Action action)
                action?.Invoke();
        });

        public static void ExecuteEvent<T1>(string eventName, T1 arg1) => IterateSimpleMap(eventName, actionObject =>
        {
            if (actionObject is Action<T1> action)
                action?.Invoke(arg1);
        });

        public static void ExecuteEvent<T1, T2>(string eventName, T1 arg1, T2 arg2) => IterateSimpleMap(eventName, actionObject =>
        {
            if (actionObject is Action<T1, T2> action)
                action?.Invoke(arg1, arg2);
        });

        public static void ExecuteEvent<T1, T2, T3>(string eventName, T1 arg1, T2 arg2, T3 arg3) => IterateSimpleMap(eventName, actionObject =>
        {
            if (actionObject is Action<T1, T2, T3> action)
                action?.Invoke(arg1, arg2, arg3);
        });

        public static void ExecuteEvent<T1, T2, T3, T4>(string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => IterateSimpleMap(eventName, actionObject =>
        {
            if (actionObject is Action<T1, T2, T3, T4> action)
                action?.Invoke(arg1, arg2, arg3, arg4);
        });

        public static void ExecuteEvent<T1, T2, T3, T4, T5>(string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => IterateSimpleMap(eventName, actionObject =>
        {
            if (actionObject is Action<T1, T2, T3, T4, T5> action)
                action?.Invoke(arg1, arg2, arg3, arg4, arg5);
        });

        public static void ExecuteEvent<T1, T2, T3, T4, T5, T6>(string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => IterateSimpleMap(eventName, actionObject =>
        {
            if (actionObject is Action<T1, T2, T3, T4, T5, T6> action)
                action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        });

        private static void IterateSimpleMap(string eventName, IterateSimpleEventMapCallback callback)
        {
            if (!m_simpleEventMap.ContainsKey(eventName))
                return;
            for (int i = 0, iMax = m_simpleEventMap[eventName].Count; i < iMax; i++)
            {
                callback?.Invoke(m_simpleEventMap[eventName][i]);
            }
        }

        private static void AddToSimpleEventMap(string eventName, object action)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                return;
            if (!m_simpleEventMap.ContainsKey(eventName))
                m_simpleEventMap.Add(eventName, new List<object>());
            m_simpleEventMap[eventName].Add(action);
        }

        private static void RemoveFromSimpleEventMap(string eventName, object action)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                return;
            if (!m_simpleEventMap.ContainsKey(eventName))
                return;
            m_simpleEventMap[eventName].Remove(action);
        }

        private static void IterateObjectMap(string eventName, IterateObjectEventMapCallback callback)
        {
            if (!m_objectEventMap.ContainsKey(eventName))
                return;

            bool hasDirty = false;

            foreach (var pair in m_objectEventMap[eventName])
            {
                if (pair.Key == null)
                {
                    hasDirty = true;
                    continue;
                }

                for (int i = 0, iMax = pair.Value.Count; i < iMax; i++)
                {
                    callback?.Invoke(pair.Key, pair.Value[i]);
                }
            }

            if (hasDirty)
            {
                m_objectEventMap = m_objectEventMap
                    .Where(om => om.Value.Count(omv => omv.Key != null) > 0)
                    .Select(om => new
                    {
                        om.Key,
                        Values = om.Value.Where(k => k.Key != null).Select(v => v).ToDictionary(y => y.Key, y => y.Value)
                    })
                .ToDictionary(x => x.Key, x => x.Values);
            }
        }


        private static void AddToObjectEventMap(GameObject go, string eventName, object action)
        {
            if (go == null)
                return;
            if (string.IsNullOrWhiteSpace(eventName))
                return;
            if (!m_objectEventMap.ContainsKey(eventName))
                m_objectEventMap.Add(eventName, new Dictionary<GameObject, List<object>>());
            if (!m_objectEventMap[eventName].ContainsKey(go))
                m_objectEventMap[eventName].Add(go, new List<object>());
            m_objectEventMap[eventName][go].Add(action);
        }

        private static void RemoveFromObjectEventMap(GameObject go, string eventName, object action)
        {
            if (go == null)
                return;
            if (string.IsNullOrWhiteSpace(eventName))
                return;
            if (!m_objectEventMap.ContainsKey(eventName))
                return;
            if (!m_objectEventMap[eventName].ContainsKey(go))
                return;
            m_objectEventMap[eventName][go].Remove(action);
        }

    }
}
