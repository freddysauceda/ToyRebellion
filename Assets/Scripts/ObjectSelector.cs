using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour {
    public string deselectButton = "deselectButton";
    public List<FriendlyAI> selectedObjects = new List<FriendlyAI>();

    public AudioSource source;

    public AudioClip[] selectSounds;
    public AudioClip[] moveSounds;
    public AudioClip[] attackSounds;

    void Update() {
        bool z = OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch);
        if (z)
        {
            DeselectAll();
        }
    }

    void playRandomSound(AudioClip[] clips)
    {
        int index = UnityEngine.Random.Range(0, clips.Length);
        AudioClip clip = clips[index];
        source.PlayOneShot(clip);
    }


    public void SelectObject(FriendlyAI sel)
    {
        playRandomSound(selectSounds);
        selectedObjects.Add(sel);
        sel.Highlight(true);
    }

    public void DeselectObject(FriendlyAI sel)
    {
        selectedObjects.Remove(sel);
        sel.Highlight(false);
    }

    public void DeselectAll()
    {
        foreach (FriendlyAI o in selectedObjects)
        {
            o.Highlight(false);
        }
        selectedObjects.Clear();
    }

    public void ToggleObject(FriendlyAI sel)
    {
        if (selectedObjects.Contains(sel))
        {
            DeselectObject(sel);
        } else
        {
            SelectObject(sel);
        }
    }
    
    public void GiveOrder(AiAction order)
    {
        switch (order.order)
        {
            case AiActionType.Attack:
                playRandomSound(attackSounds);
                break;
            case AiActionType.Move:
                playRandomSound(moveSounds);
                break;
        }

        foreach (FriendlyAI o in selectedObjects)
        {
            o.SetOrder(order);
        }
        DeselectAll();
    }


    public void GiveOrderAll(AiAction order)
    {
        FriendlyAI[] list = FindObjectsOfType<FriendlyAI>();
        foreach (FriendlyAI o in list)
        {
            o.SetOrder(order);
        }
        DeselectAll();
    }
}
