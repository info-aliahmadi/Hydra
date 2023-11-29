namespace Hydra.Kernel.Interfaces.Settings
{
    public class ImapSetting : IImapSetting
    {
        public string ImapServer { get; set; }
        public int ImapPort { get; set; }
        public string ImapUsername { get; set; }
        public string ImapPassword { get; set; }
    }
}
