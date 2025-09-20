using System;
using UnityEngine;
using UnityEngine.UI;

public class BillionaireState : MonoBehaviour
{
    public Sprite neutral;
    public Sprite happy;
    public Sprite mad;
    public Image image;

    public void SetState(BillionaireMood mood)
    {
        switch (mood)
        {
            case BillionaireMood.NEUTRAL:
                image.sprite = neutral;
                break;
            case BillionaireMood.HAPPY:
                image.sprite = happy;
                break;
            case BillionaireMood.MAD:
                image.sprite = mad;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mood), mood, null);
        }
    }
}

public enum BillionaireMood
{
    NEUTRAL,
    HAPPY,
    MAD
}
