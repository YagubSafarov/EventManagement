namespace EventManagement
{
    using UnityEngine;
    using UnityEditor;

    public class EvenManagementEditorHelper
    {
        private static string[] _options;
        private static string[] Options
        {
            get
            {
                if (_options == null)
                {
                    LoadOptions();
                }
                return _options;
            }
        }

        public static void LoadOptions()
        {
            _options = EventsDatabase.Load().events;
        }

        public static EventListHandler CreateHandler(SerializedObject serializedObject, string field)
        {
            var prop = serializedObject.FindProperty(field);
            var index = ArrayUtility.IndexOf(Options, prop.stringValue);

            return new EventListHandler
            {
                index = index,
                property = prop,
                serializedObject = serializedObject
            };
        }


        public static void Draw(EventListHandler handler)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.LabelField("Event", GUILayout.Width(50));
            handler.index = EditorGUILayout.Popup(handler.index, Options);
            if (EditorGUI.EndChangeCheck())
            {
                handler.property.stringValue = Options[handler.index];
                handler.serializedObject.ApplyModifiedProperties();
            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Update event list"))
            {
                EventsDatabase.Scan();
                LoadOptions();
                handler.index = ArrayUtility.IndexOf(Options, handler.property.stringValue);
            }
        }
    }

    public class EventListHandler
    {
        public int index;
        public SerializedObject serializedObject;
        public SerializedProperty property;
    }
}