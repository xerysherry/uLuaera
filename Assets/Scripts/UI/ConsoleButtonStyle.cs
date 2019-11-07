using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConsoleButtonStyle : ConsoleBehaviour
{
    void Awake()
    {
        img = GetComponent<Image>();
        GenericHelper.SetListenerOnClick(gameObject, OnClick);
        click_handler = GetComponent<GenericHelper.PointerClickListener>();
    }
    GenericHelper.PointerClickListener click_handler = null;

    void Update()
    {
        if(!btn.enabled)
            return;
        TestEnable();
    }
    public void TestEnable()
    {
        if(generation < console.button_generation)
        {
            btn.enabled = false;
            img.raycastTarget = false;
            img.color = btn.colors.disabledColor;
        }
    }
    public void SetEnable(bool value)
    {
        btn.enabled = true;
        img.raycastTarget = true;
        if(value)
            img.color = btn.colors.normalColor;
        else
            img.color = btn.colors.disabledColor;
    }
    public override void UpdateContent()
    { }
    public override void SetPosition(float x, float y)
    {
        var rt = (RectTransform)transform;
        rt.anchoredPosition = new Vector2(x, y);
    }
    public void SetSize(float x, float y)
    {
        var rt = (RectTransform)transform;
        rt.sizeDelta = new Vector2(x, y);
    }
    public void SetConsoleText(ConsoleText t)
    {
        code = t.code;
        generation = t.generation;
        text = t;
        UnitIdx = t.UnitIdx;
        line_desc = t.line_desc;
    }
    public void Clear()
    {
        text = null;
        UnitIdx = -1;
        line_desc = null;
    }
    public void SetButtonStyle(ButtonStyle style)
    {
        ColorBlock cb = new ColorBlock
        {
            normalColor = style.normal,
            highlightedColor = style.highlighted,
            pressedColor = style.pressed,
            disabledColor = style.disabled,
            colorMultiplier = 1, 
            fadeDuration = 0.01f,
        };
        btn.colors = cb;
    }
    public ConsoleText text;
    public Button btn;
    Image img;
}
