namespace EventManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using UnityEditor;
    using UnityEngine;

    //[CreateAssetMenu(menuName = "Tools/Events/DB", fileName = "__EditorEventsDatabase")]
    public class EventsDatabase : ScriptableObject
    {
        private const string RESOURCE_PATH = "__EditorEventsDatabase";
        public string[] events;

        public static EventsDatabase Load()
        {
            return Resources.Load<EventsDatabase>(RESOURCE_PATH);
        }

        [MenuItem("Tools/Events/Scan")]
        public static void Scan()
        {
            var iType = typeof(IEventConstants);
            var types = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetReferencedAssemblies().Where(r => r.FullName == iType.Assembly.FullName).Count() > 0)
                .SelectMany(s => s.GetTypes())
                .Where(p => iType.IsAssignableFrom(p));

            List<FieldInfo> constants = new List<FieldInfo>();
            foreach (var type in types)
            {
                constants.AddRange(type.GetFields(BindingFlags.Public | BindingFlags.Static |
                   BindingFlags.FlattenHierarchy)
                    .Where(fi => fi.IsLiteral && !fi.IsInitOnly));
            }

            var db = Resources.Load<EventsDatabase>(RESOURCE_PATH);
            db.events = constants.Select(e => e.GetRawConstantValue().ToString()).ToArray();
            EditorUtility.SetDirty(db);
            Debug.Log($"Scan complated. Find {db.events.Length} events");
        }
    }
}