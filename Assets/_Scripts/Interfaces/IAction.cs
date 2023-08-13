using Game.Core.Room;

namespace Game.Core.Mortal
{
    public interface IAction
    {
        public IAdvertise TargetAdvertiser { get; set; }
        public void DoAction();
    }
}