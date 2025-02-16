using Hydra.Kernel.Setting.Enum;
using Hydra.Kernel.Data;

namespace Hydra.Kernel.Setting.Domain
{
    public class SiteSetting : BaseEntity<int>
    {
        public required string Key { get; set; }
        public string? Value { get; set; }
        public SettingValueTypeEnum ValueType { get; set; }

    }
}
