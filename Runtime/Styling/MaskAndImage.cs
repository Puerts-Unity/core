using ReactUnity.Interop;
using UnityEngine;
using UnityEngine.UI;

namespace ReactUnity.Styling
{
    public class MaskAndImage
    {
        public Mask Mask;
        public Image Image;

        public MaskAndImage(RectTransform parent)
        {
            var go = parent.gameObject;

            Image = go.GetComponent<Image>() ?? go.AddComponent<Image>();
            Image.type = Image.Type.Sliced;
            Image.pixelsPerUnitMultiplier = 100;

            Mask = go.GetComponent<Mask>() ?? go.AddComponent<Mask>();
            Mask.showMaskGraphic = false;
        }

        internal void SetEnabled(bool enabled)
        {
            Image.enabled = enabled;
            Mask.enabled = enabled;
        }

        internal void SetBorderRadius(int borderRadius)
        {
            MainThreadDispatcher.OnUpdate(() =>
            {
                if (Image) Image.sprite = BorderGraphic.CreateBorderSprite(borderRadius);
            });
        }
    }
}
