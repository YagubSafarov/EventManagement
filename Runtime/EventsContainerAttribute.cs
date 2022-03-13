namespace EventManagement
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class EventsContainerAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class EventButtonAttribute : Attribute
    {
    }
}