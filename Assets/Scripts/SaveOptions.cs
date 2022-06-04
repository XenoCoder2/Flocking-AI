using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOptions : MonoBehaviour
{
    #region Path
    //The path to the config file in StreamingAssets.
    static string path = Application.streamingAssetsPath + "/Config.txt";
    #endregion

    #region Save Settings
    public static void SaveSettings(MenuHandler set)
    {
        //Create a streamwriter which will write to the directory given to it. 
        StreamWriter write = new StreamWriter(path);

        //Write the Orange flock starting count to the text document.
        write.WriteLine(set.orangeSize);
        //Write the Green flock starting count to the text document.
        write.WriteLine(set.greenSize);
        //Write the player's fire rate to the text document.
        write.WriteLine(set.fireRate);

        //Close the writer.
        write.Close();
    }
    #endregion

    #region Read Settings
    public static void ReadSettings(MenuHandler get)
    {
        //Create a streamreader that will read the file from the directory given to it.
        StreamReader read = new StreamReader(path);

        //Set the Orange flock starting count to the value from the text document.
        get.orangeSize = float.Parse(read.ReadLine());
        //Set the Green flock starting count to the value from the text document.
        get.greenSize = float.Parse(read.ReadLine());
        //Set the player fire rate to the value from the text document.
        get.fireRate = float.Parse(read.ReadLine());

        //Close the reader.
        read.Close();
    }
    #endregion

}
