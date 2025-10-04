using System.IO;
using System;


string[] FishyGrapesShuffle(string path)
{

    Random ran = new Random();
    string[] data = File.ReadAllLines(path);
    int n = data.Length;
    var unshuffled = data.ToArray();
    for (int i = n - 1; i > 0; i--)
    {
        int j = ran.Next(i + 1);
        string tmp = data[i];
        data[i] = data[j];
        data[j] = tmp;
    }
    return data;
}

