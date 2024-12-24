using LeeCoder.Hanta.Common.Shared.Helpers;

namespace LeeCoder.Hanta.Common.Shared.Models;

/// <summary>
/// 암호화 패스워드 제공 모델
/// </summary>
public partial class EncryptPasswordModel : ObservableObject
{
    /// <summary>
    /// 패스워드 저장
    /// Json직렬화에는 포함되지 않음
    /// </summary>
    [JsonIgnore]
    [ObservableProperty]
    private string _password = string.Empty;

    /// <summary>
    /// 암호화된 패스워드
    /// </summary>
    public string EncryptedPassword = string.Empty;

    /// <summary>
    /// 암호화
    /// </summary>
    public void Encrypt()
    {
        if (string.IsNullOrEmpty(Password)) return;

        EncryptedPassword = AesCryptoHelper.Encrypt(Password, string.Empty);
    }

    /// <summary>
    /// 복호화
    /// </summary>
    public void Decrypt()
    { 
        if(string.IsNullOrEmpty(EncryptedPassword)) return;

        Password = AesCryptoHelper.Decrypt(EncryptedPassword, string.Empty);
    }
}
