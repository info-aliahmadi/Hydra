using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Setting.Enum;

namespace Hydra.Infrastructure.Setting.Domain
{
    public class SiteSetting : BaseEntity<int>
    {
        public required string Key { get; set; }
        public string? Value { get; set; }
        public SettingValueTypeEnum ValueType { get; set; }

    }
}
