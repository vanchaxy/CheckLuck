using TerrariaApi.Server;
using Terraria;
using TShockAPI;
using Microsoft.Xna.Framework;

namespace PluginTemplate;

[ApiVersion(2, 1)]
public class CheckLuck : TerrariaPlugin
{
    public override string Name => "Check luck";

    public override Version Version => new Version(1, 0, 0);

    public override string Author => "Maksym Ivanchenko";

    public override string Description => "Add a command for luck checking.";

    public CheckLuck(Main game) : base(game)
    {
    }

    public override void Initialize()
    {
        Commands.ChatCommands.Add(new Command(SendLuck, "luck"));
    }

    private void SendLuck(CommandArgs args)
    {
        float luck = args.Player.TPlayer.luck;
        string msg = $"Current luck is {luck}.";
        var color = luck switch
        {
            >= 0.75f => Color.DarkGreen,
            >= 0.5f => Color.Green,
            >= 0.25f => Color.LightGreen,
            > 0f => Color.LimeGreen,
            0f => Color.LightGray,
            >= -0.15f => Color.Coral,
            _ => Color.DarkRed,
        };
        args.Player.SendMessage(msg, color);
    }
}
