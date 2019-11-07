using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleText : ConsoleBehaviour
{
    void Awake()
    {
        text = GetComponent<Text>();
        monospaced = GetComponent<Monospaced>();
        gradientfont = GetComponent<GradientFont>();
        outline = gameObject.AddComponent<Outline>();
        outline.enabled = false;
        shadow = gameObject.AddComponent<Shadow>();
        shadow.enabled = false;

        sizefitter = GetComponent<ContentSizeFitter>();
        sizefitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        GenericHelper.SetListenerOnClick(gameObject, OnClick);
        click_handler = GetComponent<GenericHelper.PointerClickListener>();
    }

    Text text;
    Monospaced monospaced;
    GradientFont gradientfont;
    Outline outline;
    Shadow shadow;
    ContentSizeFitter sizefitter;
    GenericHelper.PointerClickListener click_handler = null;

    /// <summary>
    /// 更新内容
    /// </summary>
    public override void UpdateContent()
    {
        var ud = unit_desc as UnitText;

        text.text = ud.content;
        text.fontSize = ud.fontsize;
        //text.alignment = (TextAnchor)line_desc.align;
        //if((int)text.alignment > 0)
        //    ud.posx = 0;
        text.color = ud.color;
        text.supportRichText = ud.flags.richedit;
        if(ud.flags.bold && ud.flags.italic)
            text.fontStyle = FontStyle.BoldAndItalic;
        else if(ud.flags.bold)
            text.fontStyle = FontStyle.Bold;
        else if(ud.flags.italic)
            text.fontStyle = FontStyle.Italic;
        else
            text.fontStyle = FontStyle.Normal;

        if(ud.flags.isbutton && ud.buttonstyle != null)
        {
            button_style_ = console.PullButtonStyle();
            transform.SetParent(button_style_.transform);

            var rt = (RectTransform)transform;
            rt.anchoredPosition = Vector2.zero;
        }

        if(ud.flags.isbutton && ud.generation >= console.button_generation)
        {
            click_handler.enabled = true;
            text.raycastTarget = true;
        }
        else
        {
            click_handler.enabled = false;
            text.raycastTarget = false;
        }

        code = ud.code;
        generation = ud.generation;

        monospaced.enabled = ud.flags.monospaced;

        logic_y = line_desc.position_y;
        logic_height = line_desc.height;

        var sfitter = false;
        if(Width == 0)
            sfitter = true;
        else
            sfitter = false;
        if(sfitter)
        {
            sizefitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        else
        {
            sizefitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            text.rectTransform.sizeDelta = new Vector2(Width, 0);
        }

        if(button_style_)
        {
            var rt = (RectTransform)button_style_.transform;
            float w = 0, h = 0;
            var s = text.rectTransform.sizeDelta;
            if(s.x == 0)
                w = StringHelper.GetDisplayLength(text.text);
            else
                w = s.x;
            if(s.y == 0)
                h = Config.LineHeight;
            else
                h = s.y;
            rt.sizeDelta = new Vector2(w, h);

            text.raycastTarget = false;
            button_style_.SetButtonStyle(ud.buttonstyle);
            button_style_.name = string.Format("button:{0}:{1}", LineNo, UnitIdx);
            button_style_.SetConsoleText(this);
            button_style_.SetEnable(true);
        }
        if(button_style_)
            button_style_.TestEnable();

        if(ud.flags.underline)
        {
            if(underline_ == null)
            {
                var obj = GameObject.Instantiate(console.template_block.gameObject);
                obj.name = "underline";
                underline_ = obj.GetComponent<RectTransform>();
                underline_.transform.SetParent(this.transform);
                underline_.anchorMin = new Vector2(0, 1);
                underline_.anchorMax = new Vector2(1, 1);
                underline_.localScale = Vector3.one;
                //underline_.position = transform.position + new Vector3(0, 1 - font.fontSize);
                underline_.anchoredPosition = new Vector2(0, -ud.fontsize - 1);

                underline_image = underline_.GetComponent<Image>();
                underline_shadow = underline_.gameObject.AddComponent<Shadow>();
                underline_outline = underline_.gameObject.AddComponent<Outline>();
            }
            underline_.sizeDelta = new Vector2(0, 1.5f);
            underline_image.color = unit_desc.color;
            underline_.gameObject.SetActive(true);
        }
        else if(underline_ != null)
            underline_.gameObject.SetActive(false);

        if(ud.flags.strickout)
        {
            if(strickout_ == null)
            {
                var obj = GameObject.Instantiate(console.template_block.gameObject);
                obj.name = "strickout";
                strickout_ = obj.GetComponent<RectTransform>();
                strickout_.transform.SetParent(this.transform);
                strickout_.anchorMin = new Vector2(0, 1);
                strickout_.anchorMax = new Vector2(1, 1);
                strickout_.localScale = Vector3.one;
                //strickout_.position = transform.position + new Vector3(0, - font.fontSize / 2.0f);
                strickout_.anchoredPosition = new Vector2(0, -ud.fontsize / 2.0f);

                strickout_image = strickout_.GetComponent<Image>();
                strickout_shadow = strickout_.gameObject.AddComponent<Shadow>();
                strickout_outline = strickout_.gameObject.AddComponent<Outline>();
            }
            strickout_.sizeDelta = new Vector2(0, 1.5f);
            strickout_image.color = unit_desc.color;
            strickout_.gameObject.SetActive(true);
        }
        else if(strickout_ != null)
            strickout_.gameObject.SetActive(false);

        if(ud.flags.gradient)
        {
            gradientfont.enabled = true;
            gradientfont.color1 = ud.second_color;
            gradientfont.color2 = ud.color;

            if(strickout_image)
                strickout_image.color = (gradientfont.color1 + gradientfont.color2) / 2;
        }
        else
        {
            gradientfont.enabled = false;
        }
        if(ud.flags.shadow)
        {
            shadow.enabled = true;
            shadow.effectColor = ud.shadow_color;

            if(strickout_shadow)
            {
                strickout_shadow.enabled = true;
                strickout_shadow.effectColor = ud.shadow_color;
            }
            if(underline_shadow)
            {
                underline_shadow.enabled = true;
                underline_shadow.effectColor = ud.shadow_color;
            }
        }
        else
        {
            shadow.enabled = false;
            if(strickout_shadow)
                strickout_shadow.enabled = false;
            if(underline_shadow)
                underline_shadow.enabled = false;
        }
        if(ud.flags.outline)
        {
            outline.enabled = true;
            outline.effectColor = ud.outline_color;

            if(strickout_outline)
            {
                strickout_outline.enabled = true;
                strickout_outline.effectColor = ud.shadow_color;
            }
            if(underline_outline)
            {
                underline_outline.enabled = true;
                underline_outline.effectColor = ud.shadow_color;
            }
        }
        else
        {
            outline.enabled = false;
            if(strickout_outline)
                strickout_outline.enabled = false;
            if(underline_outline)
                underline_outline.enabled = false;
        }
        gameObject.name = string.Format("line:{0}:{1}", LineNo, UnitIdx);
        gameObject.SetActive(true);
    }
    public override void SetPosition(float x, float y)
    {
        var rt = (RectTransform)transform;
        if (button_style_ == null)
        {
            rt.anchoredPosition = new Vector2(x, y);
        }
        else
        {
            rt.anchoredPosition = Vector2.zero;   
            button_style_.SetPosition(x, y);
        }
    }
    public void Clear()
    {
        line_desc = null;
        UnitIdx = -1;
        text.text = "";
        if(underline_ != null)
            underline_.gameObject.SetActive(false);
        if(strickout_ != null)
            strickout_.gameObject.SetActive(false);
        if(button_style_ != null)
        {
            console.PushButtonStyle(button_style_);
            button_style_ = null;
            text.transform.SetParent(console.text_content);
        }
    }
    RectTransform underline_ = null;
    Image underline_image = null;
    Shadow underline_shadow = null;
    Outline underline_outline = null;

    RectTransform strickout_ = null;
    Image strickout_image = null;
    Shadow strickout_shadow = null;
    Outline strickout_outline = null;

    ConsoleButtonStyle button_style_ = null;
}
