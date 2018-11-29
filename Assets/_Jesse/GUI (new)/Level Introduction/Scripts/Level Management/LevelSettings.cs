using System;
using UnityEngine;

public class LevelSettings : MonoBehaviour {

    // You can customize each level individualy in editor

    // If you add 2 item Images in editor, You MUST enter 2 amounts to collect;
    // With amountToCollect[0] being a number of itemImage[0] to collect,
    // and amountToCollect[1] being a number of itemImage[1] to collect and so on.

    // Example:
    // itemImage[0] holds a PIZZA Sprite
    // itemImage[1] holds a CAKE Sprite
    // amountToCollect[0] = 7;
    // amountToCollect[1] = 3;
    // ^^^^ This means Player has to collect 7 Pizzas and 3 Cakes to finish the level.

    // If you add only 1 item Image, and you need the player to collect 10 of these items:
    // amountToCollect[0] = 10; Then player will have to collect 10 same looking items;

    // levelDiscription is the text which explains the goal to player before starting a level   

    public Sprite[] itemImage;
    public int[] amountToCollect;

    public string levelDiscription;


    // This method makes sure that size of both arrays are equal.

    void OnValidate() {
        if (amountToCollect.Length != itemImage.Length) {
            Debug.Log("Resized amountToCollect.Length to match itemImage.Length", transform);

            Array.Resize(ref amountToCollect, itemImage.Length);
        }
    }

    public int GetNumToCollectTotal() {
        int amount = 0;

        for (int i = 0; i < amountToCollect.Length; i++)
            amount += amountToCollect[i];

        return amount;
    }

    public int GetNumOfUniqueObjects() {
        return itemImage.Length;
    }

    public Sprite[] GetItemSpriteArray() {
        return itemImage;
    }

}
