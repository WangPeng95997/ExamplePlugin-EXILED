using System;
using CommandSystem;

namespace ExamplePlugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class TestCommand : ICommand
    {
        public string Command { get; } = "test";

        public string[] Aliases { get; } = new[] { "testcommand" };

        public string Description { get; } = "测试指令";

        public bool SanitizeResponse { get; } = false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = $"{Command}指令执行完毕!";
            return true;
        }
    }
}