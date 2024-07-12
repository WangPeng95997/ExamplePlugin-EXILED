using System;
using CommandSystem;
using Exiled.API.Features;

namespace ExamplePlugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class TestCommand : ICommand
    {
        public string Command { get; } = "test";

        public string[] Aliases { get; } = new[] { "" };

        public string Description { get; } = "控制台测试命令";

        public bool SanitizeResponse => false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            player.Broadcast(10, "Hello World!");

            response = $"{Command}指令执行完毕!";
            return true;
        }
    }
}