using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class StateController : MonoBehaviour {

    // The current state of things is stored here
    // This includes equipped items and inventory

    //References
    [SerializeField] Item starting_accessory;
    [SerializeField] Item starting_shirt;
    [SerializeField] Item starting_pants;
    [SerializeField] Item starting_hat;

    // Local Variables
    Item body_skin;
    Item body_eyes;

    Item equipped_accessory;
    Item equipped_hat;
    Item equipped_shirt;
    Item equipped_pants;

    // Setters And Getters

    #region Player

        #region Body
        
        #endregion

        #region Clothes
        public Item EquippedAccessory { 
            get { return equipped_accessory; } 
            set { equipped_accessory = value; Public.Player.UpdateClothes(); }
        }
        public Item EquippedHat { 
            get { return equipped_hat; } 
            set { equipped_hat = value; Public.Player.UpdateClothes(); } 
        }
        public Item EquippedShirt { 
            get { return equipped_shirt; } 
            set { equipped_shirt = value; Public.Player.UpdateClothes(); } 
        }
        public Item EquippedPants { 
            get { return equipped_pants; } 
            set { equipped_pants = value; Public.Player.UpdateClothes(); } 
        }
        #endregion

        #region Inventory

        #endregion

        #region Stats

        #endregion

    #endregion

    #region Saving
    string save_path = "FOUND IN AWAKE";
    Item[] cache_item_list;
    #endregion

    void Awake() {
        //Set Starting Variables
        save_path = Application.persistentDataPath + "/save.json";

        //Debugging
        DebugStart();
    }

    void Start() {

    }

    void Update() {
        //Debugging
        Debug();
    }

    void DebugStart() {
        equipped_accessory = starting_accessory;
        equipped_shirt = starting_shirt;
        equipped_pants = starting_pants;
        equipped_hat = starting_hat;
    }

    void Debug() {
        if(Public.Controls.e_pressed) {
            LoadItemFromID(1000);
        }

        // Saving And Loading
        if(Public.Controls.left_control_pressed) SaveGame();
        if(Public.Controls.right_control_pressed) LoadGame();
    }

    #region Json Writing And Reading
    public void SaveGame() {
        GameSave _game_save = new GameSave();

        // Testing
        Console.Log("---Saving State---");
        Console.Log(equipped_accessory.item_name);
        Console.Log(equipped_hat.item_name);
        Console.Log(equipped_shirt.item_name);
        Console.Log(equipped_pants.item_name);
        Console.Log("------------");

        // Save Clothes
        _game_save.equipped_accessory = equipped_accessory.item_index;
        _game_save.equipped_hat = equipped_hat.item_index;
        _game_save.equipped_shirt = equipped_shirt.item_index;
        _game_save.equipped_pants = equipped_pants.item_index;

        //Save To File
        string _game_save_json = JsonUtility.ToJson(_game_save);
        File.WriteAllText(save_path, _game_save_json);

        Console.Log("Saved!", Console.green);
    }

    public void LoadGame() {
        // Check If Save Exists
        if(!File.Exists(save_path)) return;

        // Read Save To GameSave
        GameSave _game_save = JsonUtility.FromJson<GameSave>(File.ReadAllText(save_path));

        // Load Clothes
        equipped_accessory = LoadItemFromID(_game_save.equipped_accessory);
        equipped_hat = LoadItemFromID(_game_save.equipped_hat);
        equipped_shirt = LoadItemFromID(_game_save.equipped_shirt);
        equipped_pants = LoadItemFromID(_game_save.equipped_pants);

        // Update Player's Clothes
        Public.Player.UpdateClothes();

        Console.Log("Loaded!", Console.green);
    }

    /// <summary>
    /// Returns item object using item's index id
    /// </summary>
    public Item LoadItemFromID(int id) {
        //Caches items if not already loaded
        if(cache_item_list == null) CacheItemList();

        //Locate Item From Index ID
        foreach(Item item in cache_item_list) {
            if(item.item_index == id) { 
                Console.Log($"Found Item: {item.item_name}", Console.magenta);
                return item;
            }
        }

        //Item not found
        Console.Log($"Failed to load item {id}", Console.red);
        return null;
    }

    void CacheItemList() {
        cache_item_list = Resources.LoadAll<Item>("Items");

        // Debugging
        Console.Log("-- Creating Item List Cache --");
        foreach(Item item in cache_item_list) {
            Console.Log(item.item_name + " #" + item.item_index, Console.magenta);
        }
    }

    private class GameSave {
        public int equipped_accessory;
        public int equipped_hat;
        public int equipped_shirt;
        public int equipped_pants;
    }
    #endregion
}