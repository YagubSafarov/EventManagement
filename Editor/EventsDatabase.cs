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
            var db = Resources.Load<EventsDatabase>(RESOURCE_PATH);

            string assemblyFullName = typeof(EventsContainerAttribute).Assembly.FullName;

            db.events = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetReferencedAssemblies().Where(r => r.FullName == assemblyFullName).Count() > 0)
                .SelectMany(s => s.GetTypes())
                .Where(p => p.GetCustomAttributes<EventsContainerAttribute>().Count() > 0)
                .SelectMany(p => p.GetFields().Where(f => f.GetCustomAttributes<EventButtonAttribute>().Count() > 0))
                .Select(f => f.GetRawConstantValue().ToString()).ToArray();

            EditorUtility.SetDirty(db);
            Debug.Log($"Scan complated. Find {db.events.Length} events");
        }
    }
}