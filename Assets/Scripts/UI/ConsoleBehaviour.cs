using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ConsoleBehaviour : MonoBehaviour
{
    public void OnClick(UnityEngine.EventSystems.PointerEventData e)
    {
        var obj = e.rawPointerPress;
        if(obj == null)
            return;
        if(!unit_desc.flags.isbutton)
            return;
        if(unit_desc.generation < console.button_generation)
            Printer.SetMsg("");
        else
            Printer.SetMsg(unit_desc.code);
    }
    public abstract void UpdateContent();

    public abstract void SetPosition(float x, float y);

    public RectTransform rect_transform { get { return transform as RectTransform; } }
    public ConsoleContent console;

    public LineInfo line_desc = null;
    public int LineNo { get { return line_desc.LineNo; } }
    [HideInInspector]
    public int UnitIdx = -1;
    public UnitInfo unit_desc
    {
        get
        {
            if(line_desc == null || UnitIdx >= line_desc.units.Count)
                return null;
            return line_desc.units[UnitIdx];
        }
    }
    [HideInInspector]
    public float Width = 0;
    //[HideInInspector]
    //public float Height = 0;
    [HideInInspector]
    public float logic_y = 0.0f;
    [HideInInspector]
    public float logic_height = 0.0f;

    public string code;
    public int generation;
}
