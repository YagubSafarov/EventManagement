namespace EventManagement
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(EventButton), true)]
    public class EventButtonInspector : Editor
    {
        private EventListHandler _eventListHandler;

        private void OnEnable()
        {
            _eventListHandler = EvenManagementEditorHelper.CreateHandler(serializedObject, "_event");
        }

        private void OnDisable()
        {
            _eventListHandler = null;
        }

        public override void OnInspectorGUI()
        {
            EvenManagementEditorHelper.Draw(_eventListHandler);
        }
    }
}