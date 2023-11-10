namespace LiteDND.Exception
{
    [System.Serializable]
    public class EffectException : System.Exception
    {
        public EffectException() { }
        public EffectException(string message) : base(message) { }
        public EffectException(string message, System.Exception inner) : base(message, inner) { }
        protected EffectException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    [System.Serializable]
    public class NullQuestException : System.Exception
    {
        public NullQuestException() { }
        public NullQuestException(string message) : base(message) { }
        public NullQuestException(string message, System.Exception inner) : base(message, inner) { }
        protected NullQuestException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}