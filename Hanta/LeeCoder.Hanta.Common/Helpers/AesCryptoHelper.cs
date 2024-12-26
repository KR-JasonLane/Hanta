using LeeCoder.Hanta.Common.Shared.Extensions;

namespace LeeCoder.Hanta.Common.Shared.Helpers;

/// <summary>
/// AES 알고리즘 헬퍼
/// </summary>
public class AesCryptoHelper
{
    #region Readonly Properties

    /// <summary>
    /// 암호화 키
    /// </summary>
    private static readonly string _defaultKey = "L~E!E@C#O$D^E&R*H(A)N_T+A?";

    #endregion

    #region Static Methods

    /// <summary>
    /// 암호화
    /// </summary>
    public static string Encrypt(string plainText, string key)
    {
        try
        {
            //파라미터 검사
            if (plainText.IsNullOrEmpty()) return string.Empty;

            //키 파라미터 검사 후 비어있으면 기본키로 암호화
            key = key.IsNullOrEmpty() ? _defaultKey : key;

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = GenerateHashKey (key);
                aesAlg.IV  = GenerateRandomIV(   );

                string ivString = Convert.ToBase64String(aesAlg.IV);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        string encryptedString = Convert.ToBase64String(msEncrypt.ToArray());

                        //암호화 시 생성된 IV값을 암호화된 문자열 앞에다가 같이저장.
                        //복호화 시 키값과 함께 조합하여 복호화 됨.
                        return $"{ivString}{encryptedString}";
                    }
                }
            }
        }
        catch(Exception ex) 
        {
            ExceptionHelper.ProcessException(ex, true, "암호화 도중 에러가 발생했습니다.");

            return string.Empty;
        }
    }

    /// <summary>
    /// 복호화
    /// </summary>
    public static string Decrypt(string cypherText, string key)
    {
        try
        {
            //파라미터 검사
            if (cypherText.IsNullOrEmpty()) return string.Empty;

            //키 파라미터 검사 후 비어있으면 기본키로 복호화
            key = key.IsNullOrEmpty() ? _defaultKey : key;

            //암호화 시 함께 저장된 IV값과 암호화 문자열 분리
            SplitIvAndEncryptedFromCypherString(cypherText, out string ivString, out string encryptedString);

            byte[] encryptedByte = Convert.FromBase64String(encryptedString);

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = GenerateHashKey         (key     );
                aesAlg.IV  = Convert.FromBase64String(ivString);

                // 복호화 객체 생성
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                //복호화 파이프라인
                using (MemoryStream msDecrypt = new MemoryStream(encryptedByte))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionHelper.ProcessException(ex, true, "복호화 도중 에러가 발생했습니다.");

            return string.Empty;
        }
    }

    /// <summary>
    /// SHA-256 해시 알고리즘을 사용하여 평문키를 32바이트 키로 변환한다.
    /// </summary>
    /// <returns>생성된 키</returns>
    private static byte[] GenerateHashKey(string key)
    {
        using (var sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
        }
    }

    /// <summary>
    /// 랜덤 IV값 생성
    /// </summary>
    /// <returns> 생성된 IV </returns>
    private static byte[] GenerateRandomIV()
    {
        byte[] iv = new byte[16]; // AES의 블록 크기는 16바이트

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(iv);
        }

        return iv;
    }

    private static void SplitIvAndEncryptedFromCypherString(string cypherString, out string iv, out string encryptedString)
    {
        //iv의 byte길이는 16.
        //이것을 문자열로 변경하면 24길이의 문자열이 생성된다.
        //앞에서부터 24까지는 iv텍스트, 나머지는 암호화된 문자열
        const int splitSize = 24;

        iv              = cypherString.Substring(0        , splitSize                      );
        encryptedString = cypherString.Substring(splitSize, cypherString.Length - splitSize);
    }

    #endregion
}
