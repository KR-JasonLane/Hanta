namespace LeeCoder.Hanta.Common.Shared.Helpers;

/// <summary>
/// Json 파싱헬퍼
/// </summary>
public class JsonHelper
{
    #region Static Methods

    /// <summary>
    /// 폴더경로와 파일경로가 유효한지 확인하고 유효하지 않으면 기본값으로 생성
    /// </summary>
    /// <returns> 결과 반환 </returns>
    public static bool SaveJsonProperties<T>(T jsonObject, string jsonPath)
    {
        try
        {
            string directoryPath = Path.GetDirectoryName(jsonPath)!;

            ////////////////////////////////////////
            // 폴더경로, 파일경로 입력검사
            ////////////////////////////////////////
            {
                if (string.IsNullOrEmpty(directoryPath) || string.IsNullOrEmpty(jsonPath))
                {
                    throw new Exception($"Error : Invalid path.");
                }
            }


            ////////////////////////////////////////
            // 폴더 생성 시도
            ////////////////////////////////////////
            {
                Directory.CreateDirectory(directoryPath);
            }


            ////////////////////////////////////////
            // 파일 생성 시도
            ////////////////////////////////////////
            {
                string convertedJsonText = JsonConvert.SerializeObject(jsonObject, Formatting.None);

                File.WriteAllText(jsonPath, convertedJsonText);
            }


            ////////////////////////////////////////
            // 결과반환
            ////////////////////////////////////////
            {
                return File.Exists(jsonPath);
            }
        }
        catch (Exception ex)
        {
            ExceptionHelper.ProcessException(ex, false,"Json파일 생성 중 오류가 발생했습니다.");

            return false;
        }
    }

    /// <summary>
    /// Json파일 파싱
    /// </summary>
    /// <returns> Json 파싱데이터 </returns>
    public static T GetJsonProperties<T>(string jsonPath) where T : class, new()
    {
        try
        {
            if (File.Exists(jsonPath) == false)
            {
                T result = new();
                SaveJsonProperties(result, jsonPath);

                return result;
            }
            else
            {
                T? result = JsonConvert.DeserializeObject<T>(File.ReadAllText(jsonPath));

                if (result == null)
                {
                    result = new();
                    SaveJsonProperties(result, jsonPath);
                }

                return result;
            }
        }
        catch (Exception ex)
        {
            ExceptionHelper.ProcessException(ex, false,"Json파일을 불러오는 중 오류가 발생했습니다.");

            return new T();
        }
    }

    #endregion
}
