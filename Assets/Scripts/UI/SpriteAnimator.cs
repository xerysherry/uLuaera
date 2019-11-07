using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (anim == null)
        {
            enabled = false;
            return;
        }
        if (play_count >= loop_count)
            return;
        curr_time += Time.deltaTime;
        UpdateAnimation();
        if(ui != null)
            ui.playcount = play_count;
    }
    public void SetImageInfo(ConsoleImage.ImageInfo info)
    {
        imageinfo = info;
    }
    public void SetUnitImage(UnitImage ui)
    {
        if (ui == null)
        {
            Clear();
            return;
        }
        SetAnimation(ui.src_animation);
        this.ui = ui;
    }
    public void SetAnimation(SpriteAnimation sa)
    {
        if (sa == null)
        {
            Clear();
            return;
        }
        if (sa == anim && image.sprite != null)
            return;

        enabled = true;
        anim = sa;
        curr_index = 0;
        curr_time = 0;
        play_count = 0;
        SpriteManager.GetSpriteSync(currframe.sprite, imageinfo,
            ConsoleImage.ImageInfo.OnLoadImageCallback);
    }
    public void SetLoop(int curr, int count)
    {
        play_count = curr;
        loop_count = count;
    }
    void Clear()
    {
        ui = null;
        curr_index = 0;
        curr_time = 0;
        play_count = 0;
        anim = null;
        enabled = false;
    }
    void UpdateAnimation()
    {
        if (curr_time < currframe.time)
            return;

        curr_index += 1;
        if (curr_index >= anim.frames.Count)
        {
            curr_index = 0;
            curr_time = 0;
            play_count += 1;
        }
        if (play_count >= loop_count)
            return;
        SpriteManager.GetSpriteSync(currframe.sprite, imageinfo,
            ConsoleImage.ImageInfo.OnLoadImageCallback);
    }

    ConsoleImage.ImageInfo imageinfo;
    Image image;
    UnitImage ui;

    SpriteAnimation anim;
    int curr_index = 0;
    SpriteAnimation.Frame currframe { get { return anim.frames[curr_index]; } }
    float curr_time;

    public int playcount { get { return play_count; } }
    int play_count = 0;
    int loop_count = 0;
}
