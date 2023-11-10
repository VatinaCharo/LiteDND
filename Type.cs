namespace LiteDND.Type
{
    public enum QuestType
    {
        NORMAL,
        PASSWORD
    }
    public enum EventType
    {
        INTERACT,
        START,
        VALUE_GREATER_THAN,
        VALUE_LESS_THAN,
        VALUE_EQUAL_TO,
        VALUE_CHANGE
    }
    public enum EffectType
    {
        REPLACE,
        NODE_JOIN,
        NODE_DROP,
        ADD,
        MINUS,
        MULTIPLY,
        EQUAL,
        TEXT_SET,
        TEXT_ADD,
        TITLE_SET
    }
}