using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 资源信息
/// </summary>
public class ResourceInfo
{
    public ResourceInfo(string f)
    {
        file_ = f;
        filepath_ = GenericHelper.NormalizePath(Config.ResourcePath + "/" + file_);
        location = Config.location;
    }
    public readonly Config.Location location;
    string file_ = null;

    public string filepath { get { return filepath_; } }
    string filepath_ = null;
}