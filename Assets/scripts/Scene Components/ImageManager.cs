using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImageManager : OnNodeActivatedListener
{

    [SerializeField]
    private Image image;

    [SerializeField]
    private BackgroundImage[] activatedImages;

    private void Start()
    {
        foreach (var img in activatedImages)
        {
            var g = new ImageManagerEventListenerThing(img, image);
            UnityEvent e = new UnityEvent();
            e.AddListener(g.ActivateImage);
            CreateCustomEventListener(img.onNodeActivationEvent, e);
        }
    }

    private class ImageManagerEventListenerThing
    {

        private BackgroundImage backgroundImage;

        private Image image;

        public ImageManagerEventListenerThing(BackgroundImage img, Image imageobj)
        {
            backgroundImage = img;
            image = imageobj;
        }

        public void ActivateImage()
        {
            image.sprite = backgroundImage.sprite;
        }
    }

}

[Serializable]
public struct BackgroundImage
{
    public Sprite sprite;
    public string onNodeActivationEvent;
}
