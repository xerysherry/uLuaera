using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ConsoleContent : MonoBehaviour
{
    public static ConsoleContent GetConsole(int index)
    {
        if(index < 0 || index >= consoles.Count)
            return null;
        return consoles[index];
    }
    static void RegisterConsole(int index, ConsoleContent console)
    {
        while(consoles.Count <= index)
            consoles.Add(null);
        consoles[index] = console;
    }
    static List<ConsoleContent> consoles = new List<ConsoleContent>();

    public int index;
    public Text template_text;
    public Image template_block;
    public ConsoleButtonStyle template_buttonstyle;
    public RectTransform template_images;
    public RectTransform image_content;
    public RectTransform text_content;
    public RectTransform cache_images;

    void Awake()
    {
        RegisterConsole(index, this);
        background_ = GetComponent<Image>();
        mask_ = GetComponent<RectMask2D>();
    }
    void Start ()
    {
        GenericHelper.SetListenerOnBeginDrag(gameObject, OnBeginDrag);
        GenericHelper.SetListenerOnDrag(gameObject, OnDrag);
        GenericHelper.SetListenerOnEndDrag(gameObject, OnEndDrag);
        GenericHelper.SetListenerOnClick(gameObject, OnClick);
        GenericHelper.SetListenerOnScroll(gameObject, OnScroll);
    }
    Image background_;
    RectMask2D mask_;

    int GetLineNoIndex(int lineno)
    {
        int high = end_index - 1;
        int low = begin_index;
        int mid = 0;
        int found = -1;

        while(low <= high)
        {
            mid = (low + high) / 2;
            int k = console_lines_[mid % max_log_count].LineNo;
            if(k > lineno)
                high = mid - 1;
            else if(k < lineno)
                low = mid + 1;
            else
            {
                found = mid;
                break;
            }
        }

        if(found < 0)
            return -1;
        return found;
    }

    int GetLineNoIndexForPosY(float y)
    {
        int high = end_index - 1;
        int low = begin_index;
        int mid = 0;
        while(low <= high)
        {
            mid = (low + high) / 2;
            var l = console_lines_[mid % max_log_count];
            float top = l.position_y;
            float bottom = l.position_y + l.height;
            if(y < top)
                high = mid - 1;
            else if(y > bottom)
                low = mid + 1;
            else
                return mid;
        }
        if(high <= begin_index)
            return begin_index;
        else if(low >= end_index - 1)
            return end_index - 1;
        return -1;
    }

    int GetPrevLineNoIndex(int index)
    {
        if(index > max_index || index < 0)
            return -1;

        var lineno = 0;
        var cindex = index;
        var zero = begin_index;

        if(!console_lines_[index % max_log_count].IsLogicalLine)
        {
            lineno = console_lines_[index % max_log_count].LineNo;
            for(; cindex >= zero; --cindex)
            {
                if(console_lines_[cindex % max_log_count].LineNo != lineno)
                    break;
            }
            return cindex + 1;
        }
        else
            return cindex;
    }

    int GetNextLineNoIndex(int index)
    {
        if(index > max_index || index < 0)
            return -1;

        var lineno = console_lines_[index % max_log_count].LineNo;
        var cindex = index;
        for(; cindex < max_index; ++cindex)
        {
            if(console_lines_[cindex % max_log_count].LineNo != lineno)
                break;
        }
        return cindex - 1;
    }

    public void Update()
    {
        if(!dirty && drag_delta == Vector2.zero)
            return;
        dirty = false;

        float display_width = DISPLAY_WIDTH;
        float display_height = DISPLAY_HEIGHT;

        if(drag_delta != Vector2.zero)
        {
            float t = drag_delta.magnitude;
            drag_delta *= (Mathf.Max(0, t - 300.0f * Time.deltaTime) / t);
            local_position = GetLimitPosition(local_position + drag_delta,
                                            display_width, display_height);
            if((local_position.x <= display_width - content_width && drag_delta.x < 0) ||
                (local_position.x >= 0 && drag_delta.x > 0))
                drag_delta.x = 0;
            if((local_position.y >= content_height - display_height && drag_delta.y > 0) ||
                (local_position.y <= offset_height && drag_delta.y < 0))
                drag_delta.y = 0;
        }

        var pos = local_position + (drag_curr_position - drag_begin_position);
        pos = GetLimitPosition(pos, display_width, display_height);

        int remove_count = 0;
        int count = display_lines_.Count;
        int max_line_no = -1;
        int min_line_no = int.MaxValue;
        for(int i = 0; i < count - remove_count; ++i)
        {
            var line = display_lines_[i];
            if(line.logic_y > pos.y + display_height ||
                line.logic_y + line.logic_height < pos.y)
            {
                display_lines_[i] = display_lines_[count - remove_count - 1];
                PushLine(line);
                ++remove_count;
                --i;
            }
            else
            {
                line.SetPosition(pos.x + line.unit_desc.posx, pos.y - line.logic_y);
                max_line_no = System.Math.Max(line.LineNo, max_line_no);
                min_line_no = System.Math.Min(line.LineNo, min_line_no);
            }
        }
        if(remove_count > 0)
            display_lines_.RemoveRange(count - remove_count, remove_count);

        List<ConsoleImage> image_removelist = null;
        foreach(var kv in display_images_)
        {
            var image = kv.Value;
            if(image.logic_y > pos.y + display_height ||
                image.logic_y + image.logic_height < pos.y)
            {
                if(image_removelist == null)
                    image_removelist = new List<ConsoleImage>();
                image_removelist.Add(image);
            }
            else
                image.SetPosition(pos.x + image.unit_desc.posx, pos.y - image.logic_y);
        }
        if(image_removelist != null)
        {
            foreach(var image in image_removelist)
            {
                PushImageContainer(image);
                display_images_.Remove(image.LineNo * 1000 + image.UnitIdx);
            }
        }

        var index = GetLineNoIndex(min_line_no - 1);
        index = GetPrevLineNoIndex(index);
        if(index >= 0)
        {
            UpdateLine(pos, display_height, index, -1);
        }
        index = GetLineNoIndex(max_line_no + 1);
        index = GetNextLineNoIndex(index);
        if(index >= 0)
        {
            UpdateLine(pos, display_height, index, +1);
        }
        if(display_lines_.Count == 0 &&
            console_lines_ != null && console_lines_.Count > 0)
        {
            index = GetLineNoIndexForPosY(pos.y);
            UpdateLine(pos, display_height, index, -1);
            UpdateLine(pos, display_height, index + 1, +1);
        }
    }
    //public void UpdateForce()
    //{
    //    dirty = true;
    //    float display_width = DISPLAY_WIDTH;
    //    float display_height = DISPLAY_HEIGHT;
    //    local_position = GetLimitPosition(
    //        local_position,
    //        display_width, display_height);

    //    drag_delta = new Vector2(0, 100);
    //    drag_begin_position = Vector2.zero;
    //    drag_curr_position = Vector2.zero;

    //    Update();
    //}
    void UpdateLine(Vector2 local, float display_height, int index, int delta)
    {
        var zero = begin_index;
        while(zero <= index && index < end_index)
        {
            var l = console_lines_[index % max_log_count];
            if(l.position_y > local.y + display_height ||
                l.position_y + l.height < local.y)
                break;

            if(l.units != null)
            {
                for(int li = 0; li < l.units.Count; ++li)
                {
                    var unit = l.units[li];
                    if(!unit.flags.empty && !string.IsNullOrEmpty(unit.text))
                    {
                        var lc = PullLine();
                        lc.line_desc = l;
                        lc.UnitIdx = li;
                        lc.Width = unit.width;
                        lc.UpdateContent();
                        lc.SetPosition(unit.posx + local.x, local.y - lc.logic_y);
                        display_lines_.Add(lc);
                        MaxWidth(unit.posx + local.x + lc.Width);
                    }
                    if(unit.image_indices != null && unit.image_indices.Count > 0)
                    {
                        var hash = l.LineNo * 1000 + li;
                        ConsoleImage ic = null;
                        if(!display_images_.TryGetValue(hash, out ic))
                        {
                            ic = PullImageContainer();
                            display_images_.Add(l.LineNo * 1000 + li, ic);
                        }
                        else
                            ic.Clear();
                        ic.line_desc = l;
                        ic.UnitIdx = li;
                        ic.Width = unit.width;
                        ic.UpdateContent();
                        ic.SetPosition(unit.posx + local.x, local.y - ic.logic_y);
                        MaxWidth(unit.posx + local.x + ic.Width);
                    }
                    
                }
            }
            index += delta;
        }
    }
    Vector2 GetLimitPosition(Vector2 local,
        float display_width, float display_height)
    {
        if(content_width > display_width)
        {
            //左右移动
            if(local.x > 0)
                local.x = 0;
            else if(local.x < display_width - content_width)
                local.x = display_width - content_width;
        }
        else
            local.x = 0;

        var valid_height = content_height - offset_height;
        if(offset_height > 0 && valid_height < display_height)
        {
            local.y = offset_height;
        }
        else
        {
            var display_delta = content_height - display_height;
            if(content_height <= display_height)
                local.y = display_delta;
            else if(local.y > display_delta)
                local.y = display_delta;
            else if(local.y < offset_height)
                local.y = offset_height;
        }

        return local;
    }
    public void SetDirty()
    {
        dirty = true;
        //ToBottom();
    }
    public void SetDragEnable(bool value)
    {
        drag_enable = value;
    }

    bool dirty = false;
    bool drag_enable = true;
    uint last_click_tic = 0;
    void OnBeginDrag(PointerEventData e)
    {
        if(!drag_enable)
            return;
        drag_begin_position = e.position;
        drag_curr_position = e.position;
        drag_delta = Vector3.zero;
    }
    void OnDrag(PointerEventData e)
    {
        if(!drag_enable)
            return;
        dirty = true;
        drag_curr_position = e.position;
        drag_delta = Vector3.zero;
    }
    void OnEndDrag(PointerEventData e)
    {
        if(!drag_enable)
            return;
        dirty = true;
        float display_width = DISPLAY_WIDTH;
        float display_height = DISPLAY_HEIGHT;
        local_position = GetLimitPosition(
            local_position + (e.position - drag_begin_position),
            display_width, display_height);

        drag_delta = e.position - drag_curr_position;
        drag_begin_position = Vector2.zero;
        drag_curr_position = Vector2.zero;
    }
    void OnClick()
    {
        var nowtick = GenericHelper.TickCount;
        //var skipflag = (nowtick - last_click_tic < 200);
        //EmueraThread.instance.Input("", false, skipflag);
        //Core.instance.Send("");
        Printer.SetMsg("");
        last_click_tic = nowtick;
    }
    void OnScroll(PointerEventData e)
    {
        if(!drag_enable)
            return;
        dirty = true;
        float display_width = DISPLAY_WIDTH;
        float display_height = DISPLAY_HEIGHT;
        local_position = GetLimitPosition(
            local_position - e.scrollDelta * Printer.LineHeight,
            display_width, display_height);

        drag_delta = Vector2.zero;
        drag_begin_position = Vector2.zero;
        drag_curr_position = Vector2.zero;
    }
    Vector2 drag_begin_position = Vector2.zero;
    Vector2 drag_curr_position = Vector2.zero;
    Vector2 drag_delta = Vector2.zero;

    public void SetBackgroundColor(Color color)
    {
        if(background_.color == color)
            return;
        background_.color = color;
    }
    public Color GetBackgroundColor()
    {
        return background_.color;
    }
    public void SetBackgroundImage(Sprite sp, bool tiled, bool aspect)
    {
        background_.sprite = sp;
        if(tiled)
            background_.type = Image.Type.Tiled;
        else
        {
            background_.type = Image.Type.Simple;
            background_.preserveAspect = aspect;
        }
    }

    public void Ready()
    {
        ready_ = true;
        //option_window.Ready();
        //option_window.gameObject.SetActive(true);

        //background.color = GenericUtils.ToUnityColor(Config.BackColor);
        //background_color = Config.BackColor;
        //content_width = Config.WindowX;
        SetBackgroundColor(Config.BackgroundColor);

        template_text.color = Config.FontColor;
        //template_text.font = FontUtils.default_font;
        //if(template_text.font == null)
        //    template_text.font = FontUtils.default_font;
        template_text.fontSize = Config.FontSize;
        template_text.rectTransform.sizeDelta =
            new Vector2(template_text.rectTransform.sizeDelta.x, 0);
        template_text.gameObject.SetActive(false);

        console_lines_ = new List<LineInfo>(max_log_count);
        while(console_lines_.Count < max_log_count)
            console_lines_.Add(null);
        invalid_count = max_log_count;
    }
    public void SetNoReady() { ready_ = false; }
    bool ready_ = false;

    public void Clear(bool clear_component = false)
    {
        if(console_lines_ == null)
            return;

        invalid_count = max_log_count;
        max_index = 0;
        for(int i = 0; i < console_lines_.Count; ++i)
            console_lines_[i] = null;

        for(int i = 0; i < display_lines_.Count; ++i)
        {
            PushLine(display_lines_[i]);
        }

        display_lines_.Clear();

        if(clear_component)
        {
            foreach(var line in cache_lines_)
                GameObject.Destroy(line.gameObject);
            foreach(var image in cache_images_)
                GameObject.Destroy(image.gameObject);
            foreach(var btn in button_styles_)
                GameObject.Destroy(btn.gameObject);

            cache_lines_.Clear();
            cache_images_.Clear();
            button_styles_.Clear();
        }

        content_width = 0;
        content_height = 0;
        offset_height = 0;
        local_position = Vector2.zero;
        drag_delta = Vector2.zero;
        dirty = true;
    }
    public void AddLine(LineInfo line, bool roll_to_bottom = false)
    {
        if(line == null)
            return;
        if(!ready_)
        {
            Ready();
            //ready_ = true;
        }
        //var ld = new LineInfo(line, content_height, Config.LineHeight);

        line.position_y = content_height;
        if(line.height <= 0.0001)
            line.height = Printer.LineHeight;

        var last_index = (max_index - 1) % max_log_count;
        if(last_index < 0)
            line.LineNo = 1;
        else
        {
            var last_line = console_lines_[last_index];
            if(last_line == null)
                line.LineNo = 1;
            else
                line.LineNo = last_line.LineNo + 1;
        }

        console_lines_[max_index % max_log_count] = line;
        if(invalid_count > 0)
            invalid_count -= 1;
        //添加偏移高
        if(valid_count >= max_log_count)
            offset_height += Printer.LineHeight;
        max_index += 1;

        //ld.Update();

        //添加容器高
        content_height += Printer.LineHeight;
        if(roll_to_bottom)
        {
            local_position.y = content_height - rect_transform.rect.height;
            drag_delta.y = 0;
        }
        else
        {
            drag_delta.y += Printer.LineHeight * 1.5f;
        }
        dirty = true;
    }
    //public object GetLine(int index)
    //{
    //    if(index < begin_index || index >= end_index)
    //        return null;
    //    return console_lines_[index % max_log_count].console_line;
    //}
    public int GetLineCount()
    {
        return valid_count;
    }
    public int GetMinIndex()
    {
        return begin_index;
    }
    public int GetMaxIndex()
    {
        if(valid_count == 0)
            return -1;
        return max_index;
    }
    public void RemoveLine(int count)
    {
        if(!ready_)
        {
            Ready();
            //ready_ = true;
        }
        if(count > valid_count)
            count = valid_count;
        if(count == 0)
            return;

        var lineno = console_lines_[(max_index - count) % max_log_count].LineNo;
        display_lines_.Sort((l, r) =>
        {
            return (l.LineNo * 10 + l.UnitIdx) -
                (r.LineNo * 10 + r.UnitIdx);
        });

        var i = 0;
        for(; i < display_lines_.Count; ++i)
        {
            if(display_lines_[i].LineNo >= lineno)
                break;
        }
        List<int> imageremove = new List<int>();
        foreach(var image in display_images_)
        {
            if(image.Key / 1000 >= lineno)
            {
                PushImageContainer(image.Value);
                imageremove.Add(image.Key);
            }
        }
        foreach(var key in imageremove)
        {
            display_images_.Remove(key);
        }

        var remove = 0;
        for(; i < display_lines_.Count; ++i, ++remove)
        {
            PushLine(display_lines_[i]);
        }
        if(remove > 0)
        {
            if(remove >= display_lines_.Count)
                display_lines_.Clear();
            else
                display_lines_.RemoveRange(display_lines_.Count - remove, remove);
        }

        var eidx = end_index - 1;
        var bidx = end_index - count;
        for(i = eidx; i >= bidx; --i)
            console_lines_[i % max_log_count] = null;

        content_height -= Printer.LineHeight * count;
        if(count >= valid_count)
        {
            offset_height = 0;
            content_height = 0;
        }
        else if(max_index > max_log_count)
        {
            if(max_index - count <= max_log_count)
            {
                //offset_height -= Config.LineHeight * (max_index - max_log_count);
                //offset_height = Config.LineHeight * (max_index - max_log_count);
                var l = console_lines_[max_index - count - 1];
                offset_height = l.position_y + l.height;
            }
        }

        invalid_count += count;
        max_index -= count;
        dirty = true;
    }
    public void ToBottom()
    {
        local_position.y = content_height - rect_transform.rect.height;
        drag_delta = Vector2.zero;
        dirty = true;
        Update();
    }
    public void ShowIsInProcess(bool value)
    {
        //option_window.inprogress.SetActive(value);
    }
    public void SetLastButtonGeneration(int generation)
    {
        last_button_generation = generation;

        //var quick_buttons = option_window.quick_buttons;
        //if(quick_buttons.IsShow)
        //{
        //    quick_buttons.Clear();
        //    if(last_button_generation < 0)
        //        return;

        //    for(int i = end_index - 1; i >= begin_index; --i)
        //    {
        //        var cl = console_lines_[i % max_log_count];
        //        if(cl.units == null)
        //            continue;
        //        var bl = 0;
        //        for(int j = 0; j < cl.units.Count; ++j)
        //        {
        //            var cu = cl.units[j];
        //            if(cu.isbutton)
        //            {
        //                if(cu.generation != last_button_generation)
        //                    return;
        //                if(cu.empty)
        //                    continue;
        //                quick_buttons.AddButton(cu.content, cu.color, cu.code);
        //                bl += 1;
        //            }
        //        }
        //        if(bl > 0)
        //            quick_buttons.ShiftLine();
        //    }
        //}
    }
    public void MaxWidth(float width)
    {
        if(width > content_width)
            content_width = width;
    }

    int max_index = 0;
    int invalid_count = 0;
    int begin_index
    {
        get
        {
            return System.Math.Max(0, max_index - valid_count);
        }
    }
    int end_index
    {
        get
        {
            return max_index;
        }
    }
    int valid_count
    {
        get
        {
            return max_log_count - invalid_count;
        }
    }
    public int max_log_count { get { return Config.MaxLog; } }
    List<LineInfo> console_lines_;

    public RectTransform rect_transform { get { return (RectTransform)transform; } }
    float DISPLAY_WIDTH { get { return rect_transform.rect.width; } }
    float DISPLAY_HEIGHT { get { return rect_transform.rect.height; } }

    /// <summary>
    /// 偏移高
    /// </summary>
    float offset_height = 0;
    /// <summary>
    /// 内容宽
    /// </summary>
    float content_width = 0;
    /// <summary>
    /// 内容高
    /// </summary>
    float content_height = 0;
    /// <summary>
    /// 当前移动点
    /// </summary>
    Vector2 local_position = Vector2.zero;

    List<ConsoleText> display_lines_ = new List<ConsoleText>();
    Dictionary<int, ConsoleImage> display_images_ = new Dictionary<int, ConsoleImage>();

    public void NextButtonGeneration()
    {
        last_button_generation += 1;
    }
    public int button_generation { get { return last_button_generation; } }
#if UNITY_EDITOR
    public
#endif
    int last_button_generation = 0;

    /// <summary>
    /// 获取文本显示控件
    /// </summary>
    /// <returns></returns>
    ConsoleText PullLine()
    {
        ConsoleText config = null;
        if(cache_lines_.Count > 0)
            config = cache_lines_.Dequeue();
        else
        {
            var obj = GameObject.Instantiate(template_text.gameObject);
            config = obj.GetComponent<ConsoleText>();
            config.transform.SetParent(text_content);
            config.transform.localScale = Vector3.one;
            config.console = this;
        }
        config.gameObject.SetActive(true);
        return config;
    }
    /// <summary>
    /// 交还文本显示控件
    /// </summary>
    /// <param name="line"></param>
    void PushLine(ConsoleText line)
    {
        line.Clear();
        line.gameObject.SetActive(false);
        line.gameObject.name = "unused";
        cache_lines_.Enqueue(line);
    }
    Queue<ConsoleText> cache_lines_ = new Queue<ConsoleText>();

    /// <summary>
    /// 获取图片显示控件
    /// </summary>
    /// <returns></returns>
    ConsoleImage PullImageContainer()
    {
        ConsoleImage image = null;
        if(cache_image_containers_.Count > 0)
            image = cache_image_containers_.Pop();
        else
        {
            var obj = GameObject.Instantiate(template_images.gameObject);
            image = obj.GetComponent<ConsoleImage>();
            image.console = this;
        }
        image.transform.SetParent(image_content);
        image.transform.localScale = Vector3.one;
        image.gameObject.SetActive(true);
        return image;
    }
    /// <summary>
    /// 交还图片显示控件
    /// </summary>
    /// <param name="image"></param>
    void PushImageContainer(ConsoleImage image)
    {
        image.Clear();
        image.gameObject.SetActive(false);
        image.gameObject.name = "unused";
        image.transform.SetParent(cache_images);
        cache_image_containers_.Push(image);
    }
    Stack<ConsoleImage> cache_image_containers_ = new Stack<ConsoleImage>();

    public Image PullImage()
    {
        Image image = null;
        if(cache_images_.Count > 0)
            image = cache_images_.Pop();
        else
        {
            var obj = new GameObject();
            image = obj.AddComponent<Image>();
            image.transform.SetParent(cache_images);
            var rt = image.transform as RectTransform;
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);
            rt.localScale = Vector3.one;
        }
        image.gameObject.SetActive(true);
        return image;
    }
    public void PushImage(Image image)
    {
        image.gameObject.SetActive(false);
        image.gameObject.name = "unused";
        image.sprite = null;
        image.transform.SetParent(cache_images);
        cache_images_.Push(image);
    }
    Stack<Image> cache_images_ = new Stack<Image>();

    /// <summary>
    /// 获取按钮风格控件
    /// </summary>
    /// <returns></returns>
    public ConsoleButtonStyle PullButtonStyle()
    {
        ConsoleButtonStyle config = null;
        if (button_styles_.Count > 0)
            config = button_styles_.Dequeue();
        else
        {
            var obj = GameObject.Instantiate(template_buttonstyle.gameObject);
            config = obj.GetComponent<ConsoleButtonStyle>();
            config.transform.SetParent(text_content);
            config.transform.localScale = Vector3.one;
            config.console = this;
        }
        config.gameObject.SetActive(true);
        return config;
    }
    /// <summary>
    /// 交还按钮风格控件
    /// </summary>
    /// <param name="line"></param>
    public void PushButtonStyle(ConsoleButtonStyle bs)
    {
        bs.Clear();
        bs.gameObject.SetActive(false);
        bs.gameObject.name = "unused";
        button_styles_.Enqueue(bs);
    }
    Queue<ConsoleButtonStyle> button_styles_ = new Queue<ConsoleButtonStyle>();
}
