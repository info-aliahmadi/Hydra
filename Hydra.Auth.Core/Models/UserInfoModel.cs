﻿

namespace Hydra.Auth.Core.Models
{
    public class UserInfoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string? Avatar { get; set; }

    }
}
