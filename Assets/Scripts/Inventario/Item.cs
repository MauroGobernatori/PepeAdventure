using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public enum ItemType
    {
        book,
        bronce_ring,
        clover,
        feather,
        scroll
    }
    public ItemType itemType;

    public Sprite getSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.book:
                return ItemAssets.Instance.book;
            case ItemType.bronce_ring:
                return ItemAssets.Instance.bronce_Ring;
            case ItemType.clover:
                return ItemAssets.Instance.clover;
            case ItemType.feather:
                return ItemAssets.Instance.feather;
            case ItemType.scroll:
                return ItemAssets.Instance.scroll;
        }
    }
}
