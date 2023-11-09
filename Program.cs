using LiteDND.Event;
using LiteDND.Type;

namespace LiteDND
{
    public record Effectbean(EffectType EffectType, int EffectTarget, string EffectValue);
    public record EventBean(EventType Type, int Source, List<Effectbean> Effects);
    public record QuestNodeBean(int ID, QuestType Type, string Title, int Value, List<int> ChildrenIDs, List<EventBean> Events);
    public record QuestScriptBean(string Name, List<QuestNodeBean> QuestNodes);
    public class Quest
    {
        public int ID;
        public string Name;
        public int Value;
        public Quest? Parent;
        public List<Quest> Children;
        public Dictionary<EventType, List<IEffect>> EffectDict;
        public Quest(int ID, string Name, int Value, Quest Parent, List<Quest> Children, Dictionary<EventType, List<IEffect>> EffectDict)
        {
            this.ID = ID;
            this.Name = Name;
            this.Value = Value;
            this.Parent = Parent;
            this.Children = Children;
            this.EffectDict = EffectDict;
        }
        public Quest GetQuestRoot()
        {
            if (Parent == null) return this;
            return Parent.GetQuestRoot();
        }
        public List<Quest> GetChildrenQuestList()
        {
            var questList = new List<Quest>();
            if (Children == null) return questList;
            foreach (var child in Children)
            {
                questList.AddRange(child.GetChildrenQuestList());
            };
            return questList;
        }
        public void OnInteract(){
            EffectDict[EventType.INTERACT].ForEach(effect => effect.Apply());
        }
        public void OnStart(){
            EffectDict[EventType.START].ForEach(effect => effect.Apply());
        }
        public void OnValueGreaterThan(){
            EffectDict[EventType.VALUE_GREATER_THAN].ForEach(effect => effect.Apply());
        }
        public void OnValueLessThan(){
            EffectDict[EventType.VALUE_LESS_THAN].ForEach(effect => effect.Apply());
        }
        public void OnValueEqualTo(){
            EffectDict[EventType.VALUE_EQUAL_TO].ForEach(effect => effect.Apply());
        }
        public void OnValueChange(){
            EffectDict[EventType.VALUE_CHANGE].ForEach(effect => effect.Apply());
        }
    }
    public class NormalQuest : Quest
    {
        public NormalQuest(int ID, string Name, int Value, Quest Parent, List<Quest> Children, Dictionary<EventType, List<IEffect>> EffectDict) : base(ID, Name, Value, Parent, Children, EffectDict){}
    }
    public class PasswordQuest : Quest
    {
        public PasswordQuest(int ID, string Name, int Value, Quest Parent, List<Quest> Children, Dictionary<EventType, List<IEffect>> EffectDict) : base(ID, Name, Value, Parent, Children, EffectDict){}
        public void SetCode(int code)
        {
            if (code < 0 || code > 9) throw new ArgumentException("Wrong Password Code");
            Value = code;
        }
    }
    public static class QuestSystem
    {
        public static string Name { get; set; } = "";
        public static QuestScriptBean? ScriptBean { get; set; }

        public static Quest? QuestRoot { get; set; }

        public static Quest? GetQuestByID(int ID){
            if(QuestRoot == null) return null;
            return QuestRoot.GetChildrenQuestList().Find(x => x.ID == ID);
        }
        public static QuestScriptBean LoadQuestScript(string ScriptPath)
        {
            // TODO 实现不同剧本的加载
            throw new NotImplementedException();
        }
        public static void Init(){
            LoadQuestScript("default.yaml");
            // TODO 实现事件挂载和操作事件的触发
        }
        // TODO 实现游戏操作，通过抛出异常来处理错误并调用Show显示
        public static void Operation(string cmd){
            // xxx + yyy Interact
            // xxx Click
        }
        public static void Interact(int sourceID, int targetID){}
        public static void Click(int targetID){}
        public static string Show(string text){
            // TODO 实现游戏文字界面的展示
            // ===========================================
            // -> current_node
            // 
            //   text----------------------------text
            // ===========================================
            //   || {ID} root
            //   || {ID}    - node
            //   || {ID}        - node
            //   || {ID}    - node
            //   ||
            //   || quit   结束游戏
            // ===========================================
            return "";
        }
    }
}