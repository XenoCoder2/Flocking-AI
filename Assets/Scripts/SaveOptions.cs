using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveOptions : MonoBehaviour
{
    static string path = "Assets/Resources/Config.txt";

    public static void SaveSettings(MenuHandler set)
    {
        StreamWriter write = new StreamWriter(path);

        write.WriteLine(set.orangeSize);
        write.WriteLine(set.greenSize);
        write.WriteLine(set.fireRate);

        write.Close();

        AssetDatabase.ImportAsset(path);
    }

    public static void ReadSettings(MenuHandler get)
    {
        StreamReader read = new StreamReader(path);

        get.orangeSize = float.Parse(read.ReadLine());
        get.greenSize = float.Parse(read.ReadLine());
        get.fireRate = float.Parse(read.ReadLine());

        read.Close();
    }
}
