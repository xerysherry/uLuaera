using UnityEngine;
using UnityEditor;
using System.Collections;


class ToolKit : EditorWindow
{
    [MenuItem("Tools/ToolKit", false, 100)]
    public static void Show()
    {
        EditorWindow.GetWindow(typeof(ToolKit), false, "ToolKit");
    }

    void OnGUI()
    {
        string_hash_tool.OnGUI();
        distance_tool_.OnGUI();
        child_count_tool_.OnGUI();
        some_utils_tool_.OnGUI();
    }

    class StringHashTool
    {
        public void OnGUI()
        {
            fold_out_ = EditorGUILayout.Foldout(fold_out_, "StringHashTool");
            if(!fold_out_)
                return;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("String:", GUILayout.Width(60));
            content_ = EditorGUILayout.TextField(content_);
            EditorGUILayout.EndHorizontal();

            if(content_ != last_content_)
            {
                hash_ = Animator.StringToHash(content_);
                last_content_ = content_;
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Result:", GUILayout.Width(60));
            EditorGUILayout.TextField(hash_.ToString());
            EditorGUILayout.EndHorizontal();
        }

        bool fold_out_ = true;
        string last_content_ = "";
        string content_ = "";
        int hash_ = 0;
    }
    StringHashTool string_hash_tool = new StringHashTool();

    class DistanceTool
    {
        public void OnGUI()
        {
            fold_out_ = EditorGUILayout.Foldout(fold_out_, "DistanceTool");
            if(!fold_out_)
                return;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Object :", GUILayout.Width(50));
            obj1_ = EditorGUILayout.ObjectField(obj1_, typeof(GameObject), true) as GameObject;
            //EditorGUILayout.EndHorizontal();

            //EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Object :", GUILayout.Width(50));
            obj2_ = EditorGUILayout.ObjectField(obj2_, typeof(GameObject), true) as GameObject;
            EditorGUILayout.EndHorizontal();

            if(obj1_ && obj2_)
            {
                EditorGUILayout.LabelField("Distance = " +
                                    Vector3.Distance(obj1_.transform.position, obj2_.transform.position).ToString());
            }
        }

        bool fold_out_ = true;
        GameObject obj1_ = null;
        GameObject obj2_ = null;
    }
    DistanceTool distance_tool_ = new DistanceTool();

    class ChildCountTool
    {
        public void OnGUI()
        {
            fold_out_ = EditorGUILayout.Foldout(fold_out_, "ChildCountTool");
            if(!fold_out_)
                return;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Object :", GUILayout.Width(50));
            var obj = EditorGUILayout.ObjectField(obj_, typeof(GameObject), true) as GameObject;
            if(obj != obj_)
            {
                obj_ = obj;
                if(obj_)
                    count_ = obj_.GetComponentsInChildren<Transform>(true).Length;
                else
                    count_ = 0;
            }
            EditorGUILayout.EndHorizontal();

            if(obj_)
            {
                EditorGUILayout.LabelField("Child Count = " + count_);
            }
        }

        bool fold_out_ = true;
        GameObject obj_ = null;
        int count_ = 0;
    }
    ChildCountTool child_count_tool_ = new ChildCountTool();

    class SomeUtilsTool
    {
        public void OnGUI()
        {
            fold_out_ = EditorGUILayout.Foldout(fold_out_, "SomeUtilsTool");
            if(!fold_out_)
                return;

            if(GUILayout.Button("Open persistentDataPath"))
            {
                System.Diagnostics.Process.Start(Application.persistentDataPath);
            }
            if(GUILayout.Button("Open dataPath"))
            {
                System.Diagnostics.Process.Start(Application.dataPath);
            }
            var newkey = EditorGUILayout.TextField("Player Prefs Key:", key);
            if(newkey != key)
            {
                key = newkey;
                text = PlayerPrefs.GetString(newkey, "");
            }
            var ptext = EditorGUILayout.TextField(text);
            if(ptext != text)
            {
                PlayerPrefs.SetString(key, ptext);
                text = ptext;
            }
            if(GUILayout.Button("Delete"))
            {
                PlayerPrefs.DeleteKey(key);
            }
        }
        bool fold_out_ = true;

        string key = "";
        string text = "";
    }
    SomeUtilsTool some_utils_tool_ = new SomeUtilsTool();
}

