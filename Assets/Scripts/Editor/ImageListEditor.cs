using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class ImageListEditor : EditorWindow
{
    class ImageInfo
    {
        public string name;
        public string file;
        public List<int> rect;
        public List<int> border;
    }

    const int kNameWidth = 200;
    const int kFileWidth = 200;
    const int kXWidth = 60;
    const int kYWidth = 60;
    const int kWWidth = 60;
    const int kHWidth = 60;

    [MenuItem("Tools/ImageListEditor", false, 100)]
    static void Open()
    {
        GetWindow<ImageListEditor>();
    }

    void OnGUI()
    {
        if(images != null)
        {
            EditorGUILayout.LabelField("Parent Path", parent_path);

            EditorGUILayout.Separator();
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Name", GUILayout.Width(kNameWidth));
            EditorGUILayout.LabelField("File", GUILayout.Width(kFileWidth));
            EditorGUILayout.LabelField("X", GUILayout.Width(kXWidth));
            EditorGUILayout.LabelField("Y", GUILayout.Width(kYWidth));
            EditorGUILayout.LabelField("W", GUILayout.Width(kWWidth));
            EditorGUILayout.LabelField("H", GUILayout.Width(kHWidth));
            EditorGUILayout.LabelField("BX", GUILayout.Width(kXWidth));
            EditorGUILayout.LabelField("BY", GUILayout.Width(kYWidth));
            EditorGUILayout.LabelField("BW", GUILayout.Width(kWWidth));
            EditorGUILayout.LabelField("BH", GUILayout.Width(kHWidth));

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            scroll = EditorGUILayout.BeginScrollView(scroll);

            for(var i = 0; i < images.Count; ++i)
            {
                var img = images[i];
                EditorGUILayout.BeginHorizontal();
                img.name = EditorGUILayout.TextField(img.name, GUILayout.Width(kNameWidth));
                img.file = EditorGUILayout.TextField(img.file, GUILayout.Width(kFileWidth));
                EditorGUILayout.IntField(img.rect[0], GUILayout.Width(kXWidth));
                EditorGUILayout.IntField(img.rect[1], GUILayout.Width(kYWidth));
                EditorGUILayout.IntField(img.rect[2], GUILayout.Width(kWWidth));
                EditorGUILayout.IntField(img.rect[3], GUILayout.Width(kHWidth));

                if (img.border != null)
                {
                    EditorGUILayout.IntField(img.border[0], GUILayout.Width(kXWidth));
                    EditorGUILayout.IntField(img.border[1], GUILayout.Width(kYWidth));
                    EditorGUILayout.IntField(img.border[2], GUILayout.Width(kWWidth));
                    EditorGUILayout.IntField(img.border[3], GUILayout.Width(kHWidth));
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.Separator();
            EditorGUILayout.Separator();
        }

        if(GUILayout.Button("Enum Files"))
        {
            var path = EditorUtility.OpenFolderPanel("Enum File", ".", "");
            if(!string.IsNullOrEmpty(path))
            {
                ParseFile(path);
            }
        }
        if(GUILayout.Button("Generate Lua File"))
        {
            if(images != null && images.Count > 0)
            {
                var path = EditorUtility.SaveFilePanel("Generate Lua File", ".", "Sprites.lua", "lua");
                if(!string.IsNullOrEmpty(path))
                {
                    GenerateFile(path);
                }
            }
        }
        EditorGUILayout.Separator();
    }

    void ParseFile(string path)
    {
        parent_path = GenericHelper.NormalizePath(path);
        images = new List<ImageInfo>();

        var files = Directory.GetFiles(parent_path, "*.*", SearchOption.AllDirectories);
        foreach(var f in files)
        {
            var suffix = GenericHelper.GetSuffix(f);
            if(suffix != "png" &&
                suffix != "jpeg" &&
                suffix != "jpg" &&
                suffix != "bmp" &&
                suffix != "tga")
                continue;

            var list = GetImage(parent_path, f);
            if(list != null)
                images.AddRange(list);
        }
    }

    List<ImageInfo> GetImage(string parent_path, string fullpath)
    {
        fullpath = GenericHelper.NormalizePath(fullpath);
        var relative_path = fullpath.Substring(parent_path.Length+1);

        FileInfo fi = new FileInfo(fullpath);
        if(!fi.Exists)
            return null;

        TextureFormat format = TextureFormat.DXT1;

        var datapath = Application.dataPath;
        if(string.Compare(datapath, 0, fullpath, 0, datapath.Length) == 0)
        {
            var assetpath = string.Concat("Assets", fullpath.Substring(datapath.Length));
            var importer = (TextureImporter)AssetImporter.GetAtPath(assetpath);

            if(importer != null)
            {
                if(importer.spriteImportMode == SpriteImportMode.Multiple && importer.spritesheet != null && importer.spritesheet.Length > 0)
                {
                    List<ImageInfo> images = new List<ImageInfo>();
                    var fn = GenericHelper.GetFilename(relative_path);
                    foreach(var sheet in importer.spritesheet)
                    {
                        var img = new ImageInfo();
                        img.name = string.Concat(fn, "_", sheet.name);
                        img.file = relative_path;
                        img.rect = new List<int>
                        {
                            (int)sheet.rect.x,
                            (int)sheet.rect.y,
                            (int)sheet.rect.width,
                            (int)sheet.rect.height
                        };
                        if(sheet.border.magnitude != 0)
                        {
                            img.border = new List<int>
                        {
                            (int)sheet.border.x,
                            (int)sheet.border.y,
                            (int)sheet.border.z,
                            (int)sheet.border.w,
                        };
                        }
                        images.Add(img);
                    }
                    return images;
                }
                else if(importer.spriteImportMode == SpriteImportMode.Single)
                {
                    List<ImageInfo> images = new List<ImageInfo>();
                    var img = new ImageInfo();
                    img.name = GenericHelper.GetFilename(relative_path);

                    FileStream texfs = fi.OpenRead();
                    var texfilesize = texfs.Length;
                    byte[] texcontent = new byte[texfilesize];
                    texfs.Read(texcontent, 0, (int)texfilesize);
                    texfs.Close();

                    if(GenericHelper.GetSuffix(fullpath).ToLower() == "png")
                        format = TextureFormat.DXT5;
                    var texinfo = new Texture2D(4, 4, format, false);
                    if(!texinfo.LoadImage(texcontent))
                        return null;

                    img.file = relative_path;
                    img.rect = new List<int> { 0, 0, texinfo.width, texinfo.height};

                    if( importer.spriteBorder.x != 0 &&
                        importer.spriteBorder.y != 0 &&
                        importer.spriteBorder.z != 0 &&
                        importer.spriteBorder.w != 0)
                    {
                        img.border = new List<int> {
                        (int)importer.spriteBorder.x,
                        (int)importer.spriteBorder.y,
                        (int)importer.spriteBorder.z,
                        (int)importer.spriteBorder.w,
                    };
                    }
                    images.Add(img);

                    GameObject.DestroyImmediate(texinfo);
                    return images;
                }   
            }

        }

        FileStream fs = fi.OpenRead();
        var filesize = fs.Length;
        byte[] content = new byte[filesize];
        fs.Read(content, 0, (int)filesize);
        fs.Close();

        if(GenericHelper.GetSuffix(fullpath).ToLower() == "png")
            format = TextureFormat.DXT5;

        var tex = new Texture2D(4, 4, format, false);
        if(!tex.LoadImage(content))
            return null;

        var imageinfo = new ImageInfo();
        imageinfo.name = GenericHelper.GetFilename(relative_path);
        imageinfo.file = relative_path;
        imageinfo.rect = new List<int> { 0, 0, tex.width, tex.height };

        GameObject.DestroyImmediate(tex);
        return new List<ImageInfo> { imageinfo };
    }

    void GenerateFile(string path)
    {
        if(images == null || images.Count == 0)
            return;

        FileInfo fi = new FileInfo(path);
        var sw = fi.CreateText();

        try
        {
            sw.WriteLine("local sprites = {");

            string lastfile = null;
            for(var i = 0; i < images.Count; ++i)
            {
                var img = images[i];
                if(img.file != lastfile)
                {
                    if(i != 0)
                        sw.WriteLine();
                    sw.WriteLine("    -- " + img.file);
                    lastfile = img.file;
                }

                if (img.border != null)
                {
                    sw.WriteLine("    {{\"{0}\", \"{1}\", {{ {2}, {3}, {4}, {5} }}, {{ {6}, {7}, {8}, {9} }} }},",
                        img.name, img.file, 
                        img.rect[0], img.rect[1], img.rect[2], img.rect[3],
                        img.border[0], img.border[1], img.border[2], img.border[3]);
                }
                else
                {
                    sw.WriteLine("    {{\"{0}\", \"{1}\", {{ {2}, {3}, {4}, {5} }} }},",
                        img.name, img.file, img.rect[0], img.rect[1], img.rect[2], img.rect[3]);
                }
            }

            sw.WriteLine("}");
            if(string.Compare(parent_path, 0, Application.dataPath, 0, Application.dataPath.Length) == 0)
                parent_path = parent_path.Substring(Application.dataPath.Length + 1);
            sw.WriteLine("SetResourcePath(\"{0}\", FILE_SYSTEM)", parent_path);
            sw.WriteLine("SetSpriteImages(sprites)");
        }
        catch(System.Exception e)
        {
            Debug.LogError(e);
        }

        sw.Close();
        fi.Refresh();
    }

    Vector2 scroll;
    string parent_path;
    List<ImageInfo> images;
}
