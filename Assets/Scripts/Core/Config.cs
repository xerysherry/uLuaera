using UnityEngine;

public static class Config
{
    public enum Location
    {
        /// <summary>
        /// 文件系统
        /// </summary>
        FILE_SYSTEM,
        /// <summary>
        /// 游戏包（Resource）
        /// </summary>
        PACKAGE,
        ///// <summary>
        ///// 资源包内（AssetBundle）
        ///// </summary>
        //ASSET_BUNDLE,
    }

    static Config()
    {
        FlagBit.monospaced = true;
#if UNITY_EDITOR
        project_path = Application.dataPath;
        SetSavePath("Save");
        SetCsvPath("Csv");
#elif UNITY_STANDALONE
        project_path = GenericHelper.GetFolder(Application.dataPath);
        SetSavePath("Save");
        SetCsvPath("Csv");
#elif UNITY_ANDROID
        project_path = Application.persistentDataPath;
        SetSavePath("Save");
        SetCsvPath("Csv");
#else
        project_path = Application.persistentDataPath;
        SetSavePath("Save");
        SetCsvPath("Csv");
#endif
    }

    /// <summary>
    /// 默认标记
    /// </summary>
    public static uint Flags
    {
        get { return FlagBit.GetFlags(); }
        set { FlagBit.SetFlags(value); }
    }
    public static FlagBit FlagBit = new FlagBit();
    /// <summary>
    /// 字体默认颜色
    /// </summary>
    public static Color32 FontColor = Color.white;
    /// <summary>
    /// 字体默认渐变色
    /// </summary>
    public static Color32 FontGradientColor = Color.white;
    /// <summary>
    /// 字体默认阴影色
    /// </summary>
    public static Color32 FontShadowColor = Color.gray;
    /// <summary>
    /// 字体默认描边色
    /// </summary>
    public static Color32 FontOutlineColor = Color.gray;
    /// <summary>
    /// 字体默认大小
    /// </summary>
    public static int FontSize = 24;
    /// <summary>
    /// 图片颜色
    /// </summary>
    public static Color32 ImageColor = Color.white;
    /// <summary>
    /// 默认背景色
    /// </summary>
    public static Color BackgroundColor = Color.black;

    public static string GetProjectPath()
    {
        return project_path;
    }
    static string project_path = null;


    public static string GetSavePath()
    {
        return save_path;
    }
    public static void SetSavePath(string path)
    {
        save_path = string.Concat(project_path, "/", path);
        try
        {
            System.IO.Directory.CreateDirectory(save_path);
        }
        catch(System.Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }
    static string save_path = null;

    public static string GetCsvPath()
    {
        return csv_path;
    }
    public static void SetCsvPath(string path)
    {
        csv_path = string.Concat(project_path, "/", path);
    }
    static string csv_path = null;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    public static void SetResourcePath(string path, Location l)
    {
        if (l == Location.FILE_SYSTEM)
        {
            if (System.IO.Directory.Exists(path))
                ResourcePath = path;
            else
                ResourcePath = GenericHelper.NormalizePath(string.Concat(project_path, "/", path));
        }
        else
        {
            ResourcePath = path;
        }
        location = l;

    }
    /// <summary>
    /// 资源路径
    /// </summary>
    public static string ResourcePath = Application.dataPath;
    public static Location location = Config.Location.FILE_SYSTEM;

    public static string FontName = "";
    public static int MaxLog = 5000;
    public static int LineHeight = FontSize + 1;

    
}