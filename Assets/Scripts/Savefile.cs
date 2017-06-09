using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Savefile : MonoBehaviour {

    public bool loadGame;

    public string filename;
    public Object [] prefablist;

    [System.Serializable]
    public struct game_object_data
    {
        public int id;
        public float x, y, z;
        public float ax, ay, az;
    }

    [System.Serializable]
    public struct Game
    {
        public game_object_data[] data;
    }

    private bool gameReady = false;

    void Start()
    {
        if (loadGame)
        {
            setup_game(filename);
        }
    }

    public void startSave()
    {
            Game game;

        print("Saving...");

            List<game_object_data> objList = new List<game_object_data>();

            Transform[] everything = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];
            foreach (Transform t in everything)
            {
                SelectableObject sel = t.GetComponent<SelectableObject>();
                if (sel != null)
                {
                    game_object_data entry = new game_object_data();
                    entry.id = sel.index;
                    entry.x = sel.transform.position.x;
                    entry.y = sel.transform.position.y;
                    entry.z = sel.transform.position.z;
                    entry.ax = sel.transform.forward.x;
                    entry.ay = sel.transform.forward.y;
                    entry.az = sel.transform.forward.z;

                    objList.Add(entry);
                }
            }

            game.data = objList.ToArray();

            save(game);
    }

	public void save(Game savefile)
    {
        //Create a folder somewhere not stupid
        string save_folder = System.Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Saved Games");
        //Create the file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(save_folder + filename + ".sav");
        //Save the file
        bf.Serialize(file, savefile);

        file.Close();
    }

    public void load(string file_to_load, out Game loaded_game)
    {
        string save_folder = System.Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Saved Games");

        if (File.Exists(save_folder + file_to_load + ".sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(save_folder + file_to_load + ".sav", FileMode.Open);
            loaded_game = (Game)bf.Deserialize(file);
            file.Close();

            gameReady = true;
                      
        }
        else
        {
            gameReady = false;
            loaded_game = new Game();
            //Failed
            Debug.Log("Save file doesn't exists.");
        }
    }

    public void setup_game(string file_to_load)
    {
        Game game = new Game();
        load(file_to_load, out game);

        if (!gameReady) { return; }

        foreach(game_object_data data in game.data)
        {
            Instantiate(prefablist[data.id], new Vector3(data.x, data.y, data.z), Quaternion.LookRotation(new Vector3(data.ax, data.ay, data.az), Vector3.up));
        }
        
    }
}
