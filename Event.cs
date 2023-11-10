using LiteDND.Exception;

namespace LiteDND.Event
{
    public delegate void InteractEventHandler();
    public delegate void StartEventHandler();
    public delegate void ValueGreaterThanEventHandler();
    public delegate void ValueLessThanEventHandler();
    public delegate void ValueEqualToEventHandler();
    public delegate void ValueChangeEventHandler();

    public interface IEffect
    {
        public abstract void Apply();
    }
    public abstract class Effect<T> : IEffect
    {
        public int TargetID;
        public T? Value;

        public abstract void Apply();
    }
    public class ReplaceEffect : Effect<int>
    {
        public override void Apply()
        {
            var targetQuest = QuestSystem.GetQuestByID(TargetID) ?? throw new NullQuestException($"No Quest match ID({TargetID})");
            var valueQuest = QuestSystem.GetQuestByID(Value) ?? throw new NullQuestException($"No Quest match ID({TargetID})");
            var parentQuest = targetQuest.Parent;
            if (parentQuest == null){
                QuestSystem.QuestRoot = valueQuest;
                return;
            }
            parentQuest.Children.Remove(targetQuest);
            parentQuest.Children.Add(valueQuest);
        }
    }
    public class NodeJoinEffect : Effect<int>
    {
        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
    public class NodeDropEffect : Effect<int>
    {
        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
    public class AddEffect : Effect<int>
    {
        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
    public class MinusEffect : Effect<int>
    {
        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
    public class MultiplyEffect : Effect<int>
    {
        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
    public class EqualEffect : Effect<int>
    {
        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
    public class TextSetEffect : Effect<string>
    {
        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
    public class TextAddEffect : Effect<string>
    {
        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
    public class TitleSetEffect : Effect<string>
    {
        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
}