using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LuaTool : EditorWindow
{
    [MenuItem("Tools/LuaWrapGenerator", false, 100)]
    static void OpenWindow()
    {
        // Get existing open window or if none, make a new one:
        LuaTool.GetWindow(typeof(LuaTool));
    }

    void OnGUI()
    {
        if(GUILayout.Button("Generate"))
        {
            Generate();
        }
        if(GUILayout.Button("DeployDevelopment"))
        {
            Lua.Resource.Deploy(Lua.Resource.kLuaScriptDevelopmentPath);
            AssetDatabase.Refresh();
        }
        if(GUILayout.Button("DeployRuntime"))
        {
            Lua.Resource.Deploy(Lua.Resource.kLuaScriptRuntimePath);
            AssetDatabase.Refresh();
        }
    }

    void Generate()
    {
        if(EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("Please Wait Compile Finish",
                                        "Please Wait Compile Finish", "OK");
            return;
        }

        LuaWrapGenerator.ClearClass();
        LuaWrapGenerator.SetSkipClass(new List<System.Type> 
        {
            typeof(Motion),
        });
        LuaWrapGenerator.SetSkipMethod(new List<string>
        {
            "UnityEngine.Texture2D.alphaIsTransparency",
            "UnityEngine.UI.Graphic.OnRebuildRequested",
            "UnityEngine.UI.Text.OnRebuildRequested",
            "UnityEngine.Camera.scene",
        });
        LuaWrapGenerator.Create(new List<System.Type>
        {
            typeof(UnityEngine.Color),
            typeof(UnityEngine.Time),
            typeof(UnityEngine.Debug),
            typeof(LuaUtils),
            typeof(Printer),
            typeof(StringHelper),
            typeof(Config),
        });

        LuaWrapGenerator.CreateWrapClassScript();
        AssetDatabase.Refresh();
    }
}
