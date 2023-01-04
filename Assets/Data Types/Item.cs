using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", order = 0)]
public class Item : ScriptableObject {
    // [Header("Basic Information")]
    public int item_index;
    public string item_name;
    public float value;
    public Texture icon;

    // [Header("Clothing")]
    public Texture sprite;
    public bool is_accessory;
    public bool is_shirt;
    public bool is_pants;
    public bool is_hat;

    public bool hide_shirt;
    public bool hide_pants;
    public bool hide_hair;
    public bool hide_eyes;

    // [Header("Inventory Behavior")]
    public int max_stack_size;
}