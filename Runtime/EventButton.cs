namespace EventManagement
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class EventButton : MonoBehaviour
    {
        private Button _button;
        [SerializeField]
        private string _event;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        protected virtual void OnButtonClicked()
        {
            EventHandler.ExecuteEvent(_event);
        }
    }
}