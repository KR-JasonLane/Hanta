namespace LeeCoder.Hanta.Common.Shared.Helpers;

/// <summary>
/// 사용자설정 파일 헬퍼
/// </summary>
public class SettingFileHelper
{
    #region Readonly Properties

    /// <summary>
    /// 현재 실행중인 폴더경로 기억
    /// </summary>
    private static readonly string _baseFilePath = Directory.GetCurrentDirectory();

    /// <summary>
    /// 사용자 설정 파일 폴더 경로 기억
    /// </summary>
    private static readonly string _settingFilePath = Path.Combine(_baseFilePath, "Setting");

    #endregion

    #region Static Methods

    /// <summary>
    /// 사용자 설정 모델을 Json형태로 저장.
    /// </summary>
    /// <typeparam name="T"> SettingModel 타입 </typeparam>
    /// <param name="model"> 저장하고자 하는 SettingModel </param>
    /// <exception cref="ArgumentNullException"> 파라미터가 null일 때 발생                </exception>
    /// <exception cref="ArgumentException"    > 파라미터 타입이 SettingModel이 아닐때 발생</exception>
    public static void SaveSettingModel<T>(T model) where T : class, new()
    {
        try
        {
            ////////////////////////////////////////
            // 파라미터 검사
            ////////////////////////////////////////
            {
                if (model == null                                   ) throw new ArgumentNullException($"[{typeof(T).Name}]객체가 null 입니다."               );
                if (typeof(T).Name.Contains("SettingModel") == false) throw new ArgumentException    ($"[{typeof(T).Name}]타입은 SettingModel타입이 아닙니다.");
            }


            ////////////////////////////////////////
            // 세팅 저장
            ////////////////////////////////////////
            {
                string filePath = Path.Combine(_settingFilePath, typeof(T).Name[..^5]);

                JsonHelper.SaveJsonProperties(model, filePath);
            }
        }
        catch(Exception ex) 
        {
            ExceptionHelper.ProcessException(ex, true, "사용자 설정을 저장하는 중 오류가 발생했습니다.");
        }
    }

    public static T GetSettingModel<T>() where T : class, new()
    {
        try
        {
            ////////////////////////////////////////
            // 타입 검사
            ////////////////////////////////////////
            {
                if (typeof(T).Name.Contains("SettingModel") == false) throw new ArgumentException($"[{typeof(T).Name}]타입은 SettingModel타입이 아닙니다.");
            }

            ////////////////////////////////////////
            // 사용자 설정 모델 반환
            ////////////////////////////////////////
            {
                string filePath = Path.Combine(_settingFilePath, typeof(T).Name[..^5]);

                // 저장된 설정이 없으면 내부에서 생성 후 반환해줌.
                return JsonHelper.GetJsonProperties<T>(filePath);
            }
        }
        catch(Exception ex)
        {
            ExceptionHelper.ProcessException(ex, true, "사용자 설정을 불러오는 중 오류가 발생했습니다.");

            return new T();
        }
    }

    #endregion
}
