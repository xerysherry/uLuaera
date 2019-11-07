using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleImage : ConsoleBehaviour
{
    public class ImageInfo : MonoBehaviour
    {
        public static void OnLoadImageCallback(object obj, SpriteImage src, SpriteManager.SpriteInfo spriteinfo)
        {
            if(obj == null)
            {
                SpriteManager.GivebackSpriteInfo(spriteinfo);
                return;
            }
            var c = obj as ImageInfo;
            if(!c.gameObject.activeSelf)
            {
                SpriteManager.GivebackSpriteInfo(spriteinfo);
                return;
            }
            c.SetSprite(src, spriteinfo);
        }

        void Awake()
        {
            animator_ = gameObject.AddComponent<SpriteAnimator>();
            animator_.SetImageInfo(this);
            animator_.enabled = false;
        }
        public void Load(SpriteImage src)
        {
            animator_.SetUnitImage(null);
            SpriteManager.GetSprite(src, this, ImageInfo.OnLoadImageCallback);
        }
        public void Load(UnitImage ui)
        {
            animator_.SetUnitImage(ui);
            animator_.SetLoop(ui.playcount, ui.loop);
        }
        void SetSprite(SpriteImage src, SpriteManager.SpriteInfo spriteinfo)
        {
            if(spriteinfo == null)
            {
                image.sprite = null;
                image.color = kTransparent;
            }
            else
            {
                image.sprite = spriteinfo.sprite;
                //image.color = Color.white;
                if (src.sliced)
                    image.type = UnityEngine.UI.Image.Type.Sliced;
                else
                    image.type = UnityEngine.UI.Image.Type.Simple;
            }
            this.spriteinfo = spriteinfo;
        }
        public void Clear()
        {
            SpriteManager.GivebackSpriteInfo(spriteinfo);
        }

        public SpriteManager.SpriteInfo spriteinfo = null;
        public UnityEngine.UI.Image image
        {
            get
            {
                if(image_ == null)
                    image_ = GetComponent<UnityEngine.UI.Image>();
                return image_;
            }
        }

        UnityEngine.UI.Image image_ = null;
        SpriteAnimator animator_ = null;
    }
    static readonly Color kTransparent = new Color(0, 0, 0, 0);

    void Awake()
    {
        GenericHelper.SetListenerOnClick(gameObject, OnClick);
        click_handler_ = GetComponent<GenericHelper.PointerClickListener>();
    }
    public override void UpdateContent()
    {
        var ud = unit_desc;
        var image_indices = ud.image_indices;
        var ld = line_desc;
        //var consoleline = ld.console_line as ConsoleDisplayLine;
        //var cb = consoleline.Buttons[UnitIdx];
        var cb = ld.images;

        if(ud.flags.isbutton && ud.generation >= console.button_generation)
        {
            image.enabled = true;
            image.raycastTarget = true;
            click_handler_.enabled = true;
//#if UNITY_EDITOR
            code = ud.code;
            generation = ud.generation;
//#endif
        }
        else
        {
            image.enabled = false;
            image.raycastTarget = false;
            click_handler_.enabled = false;
        }

        int miny = int.MaxValue;
        for(int i = 0; i < image_indices.Count; ++i)
        {
            var str_index = image_indices[i];
            var image_part = cb[str_index];
            miny = System.Math.Min(miny, image_part.posy);
        }
        logic_y = line_desc.position_y + miny;
        logic_height = 0;

        var prt = rect_transform;
        int maxx = 0;
        for(int i = 0; i < image_indices.Count; ++i)
        {
            var image = console.PullImage();
            var imageinfo = image.gameObject.GetComponent<ImageInfo>();
            if(imageinfo == null)
                imageinfo = image.gameObject.AddComponent<ImageInfo>();
            image.raycastTarget = false;

            var rt = image.gameObject.transform as RectTransform;
            rt.SetParent(prt);

            var str_index = image_indices[i];
            var image_part = cb[str_index];
            image.name = image_part.name;
            if (image_part.isanimation)
                imageinfo.Load(image_part);
            else
                imageinfo.Load(image_part.src_image);
            image_infos_.Add(imageinfo);
            if(image_part.tiled)
                image.type = UnityEngine.UI.Image.Type.Tiled;
            image.color = image_part.color;

            //var image_rect = image_part.dest_rect;
            rt.anchoredPosition = new Vector2(/*image_part.PointX*/ - ud.posx + image_part.posx, miny - image_part.posy);
            rt.sizeDelta = new Vector2(image_part.width, image_part.height);
            rt.localScale = Vector3.one;
            logic_height = Mathf.Max(logic_height, image_part.height);

            maxx = Mathf.Max(image_part.width + (int)rt.anchoredPosition.x, maxx);
        }

        prt.sizeDelta = new Vector2(maxx, logic_height);
#if UNITY_EDITOR
        name = string.Format("image:{0}:{1}", LineNo, UnitIdx);
#endif
        Width = maxx;
    }
    public void Clear()
    {
        foreach(var image in image_infos_)
        {
            image.Clear();
            console.PushImage(image.image);
        }
        image_infos_.Clear();
    }
    public override void SetPosition(float x, float y)
    {
        var rt = (RectTransform)transform;
        rt.anchoredPosition = new Vector2(x, y);
    }

    GenericHelper.PointerClickListener click_handler_ = null;

    UnityEngine.UI.Image image
    {
        get
        {
            if(image_ == null)
                image_ = GetComponent<UnityEngine.UI.Image>();
            return image_;
        }
    }
    UnityEngine.UI.Image image_ = null;
    List<ImageInfo> image_infos_ = new List<ImageInfo>();
}
