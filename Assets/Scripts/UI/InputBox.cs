using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputBox : MonoBehaviour
{
    public static void Show(string content)
    {
        instance_.gameObject.SetActive(true);
        instance_.content.text = content;
        instance_.right_button.gameObject.SetActive(true);
    }
    public static bool IsShow()
    {
        return instance.gameObject.activeSelf;
    }
    public static string LastResult()
    {
        return instance.result;
    }
    public static InputBox instance { get { return instance_; } }
    static InputBox instance_;

    void Awake()
    {
        instance_ = this;
        background = GetComponent<Image>();
        inputfield = input.GetComponent<InputField>();
        GenericHelper.SetListenerOnClick(right_button.gameObject, OnClick);
        border.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    void OnClick()
    {
        gameObject.SetActive(false);
        result = inputfield.text;
    }

    Image background;
    public Image border;
    public Text content;
    public Image right_button;
    public Text right_button_text;
    public Image input;
    public InputField inputfield { get; set; }
    public Text placeholder;
    public Text text;

    string result;
}
