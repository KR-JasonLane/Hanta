using LeeCoder.Hanta.Common.Shared.Helpers;

namespace LeeCoder.Hanta.Common.Shared.Models;

/// <summary>
/// 암호화 패스워드 제공 모델
/// </summary>
public partial class EncryptPasswordModel : ObservableObject
{
    /// <summary>
    /// 패스워드
    /// Json직렬화에는 포함되지 않음
    /// </summary>
    [ObservableProperty]
    [property: JsonIgnore]
    private string _password = string.Empty;

    /// <summary>
    /// 암호화된 패스워드
    /// </summary>
    public string Encrypted = string.Empty;

    /// <summary>
    /// 암호화
    /// </summary>
    public void Encrypt()
    {
        if (string.IsNullOrEmpty(Password)) return;

        Encrypted = AesCryptoHelper.Encrypt(Password, string.Empty);
    }

    /// <summary>
    /// 복호화
    /// </summary>
    public void Decrypt()
    { 
        if(string.IsNullOrEmpty(Encrypted)) return;

        Password = AesCryptoHelper.Decrypt(Encrypted, string.Empty);
    }
}
