"# Event-Management" 


public class EventTest : MonoBehaviour
{
    void Start()
    {
        EventHandler.RegisterEvent<int, string>("TestEvent", Testing);
        EventHandler.ExecuteEvent("TestEvent", 5, "asd");
    }

    void Testing(int val, string s)
    {
        Debug.Log(s);
    }
}