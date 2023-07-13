namespace Hydra.FileStorage.Core.Settings
{
    public enum ValidationFileEnum
    {
        Ok = 0,
        FileNotFound = 1,
        FileIsTooLarge = 2,
        FileIsTooSmall = 3,
        FileNotSupported = 4,
        InvalidSignature = 5,
    }
}
