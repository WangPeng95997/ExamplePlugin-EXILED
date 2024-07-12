using Exiled.Events.EventArgs.Player;

namespace ExamplePlugin.Events
{
    public class PlayerHandler
    {
        public PlayerHandler() { }

        // 玩家加入游戏事件
        internal void OnVerified(VerifiedEventArgs ev)
        {
            ev.Player.Broadcast(10, "欢迎来到萌新天堂服务器(°∀°)ﾉ");
        }
    }
}