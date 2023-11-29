namespace Hydra.Kernel.Interfaces.Settings
{
    public interface IImapSetting
    {
        string ImapServer { get; }
        int ImapPort { get; }
        string ImapUsername { get; }
        string ImapPassword { get; }
    }
}
