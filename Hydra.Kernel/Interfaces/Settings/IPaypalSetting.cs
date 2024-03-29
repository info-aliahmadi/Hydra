﻿namespace Hydra.Kernel.Interfaces.Settings
{
    public interface IPaypalSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public string Mode { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientId { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientSecret { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string BaseUrl { get; }
    }
}
