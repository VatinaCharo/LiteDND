namespace LiteDND.Event
{
    public delegate void InteractEventHandler();
    public delegate void StartEventHandler();
    public delegate void ValueGreaterThanEventHandler();
    public delegate void ValueLessThanEventHandler();
    public delegate void ValueEqualToEventHandler();
    public delegate void ValueChangeEventHandler();

    public interface IEffect{
        public abstract void Apply();
    }
    public abstract class Effect<T> : IEffect{
        public int TargetID;
        public T? Value;

        public abstract void Apply();
    }
    // TODO 实现各种类型的Effect的处理
}