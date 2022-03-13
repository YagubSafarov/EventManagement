namespace EventManagement
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(EventButton))]
    public class EventButtonInspector : Editor
    {
        private int _index;
        private string[] _options;
        private SerializedProperty _eventsProperty;

        private void OnEnable()
        {
            _options = EventsDatabase.Load().events;
            _eventsProperty = serializedObject.FindProperty("_event");
            _index = ArrayUtility.IndexOf(_options, _eventsProperty.stringValue);
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            _index = EditorGUILayout.Popup(_index, _options);
            if (EditorGUI.EndChangeCheck())
            {
                _eventsProperty.stringValue = _options[_index];
                serializedObject.ApplyModifiedProperties();
            }

            if (GUILayout.Button("Update event list"))
            {
                EventsDatabase.Scan();
            }
        }
    }
}