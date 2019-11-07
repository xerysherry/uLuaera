using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgBox : MonoBehaviour
{
    public static void Show(string content, Printer.MsgType type)
    {
        instance_.gameObject.SetActive(true);

        instance_.content.text = content;
        instance_.right_button.gameObject.SetActive(true);
        if (type == Printer.MsgType.TWO_BUTTON)
            instance_.left_button.gameObject.SetActive(true);
        else
            instance_.left_button.gameObject.SetActive(false);
    }
    public static bool IsShow()
    {
        return instance.gameObject.activeSelf;
    }
    public static Printer.MsgResult LastResult()
    {
        return instance.result;
    }
    public static MsgBox instance { get { return instance_; } }
    static MsgBox instance_;

    void Awake()
    {
        instance_ = this;
        background = GetComponent<Image>();
        GenericHelper.SetListenerOnClick(left_button.gameObject, OnClickLeft);
        GenericHelper.SetListenerOnClick(right_button.gameObject, OnClickRight);

        border.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    void OnClickLeft()
    {
        gameObject.SetActive(false);
        result = Printer.MsgResult.LEFT;
    }
    void OnClickRight()
    {
        gameObject.SetActive(false);
        result = Printer.MsgResult.RIGHT;
    }

    Image background;
    public Image border;
    public Text content;
    public Image left_button;
    public Text left_button_text;
    public Image right_button;
    public Text right_button_text;

    Printer.MsgResult result;
}
