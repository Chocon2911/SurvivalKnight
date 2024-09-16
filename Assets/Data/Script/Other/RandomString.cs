using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomString
{
    private const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

    public static string GetRandomId(int amount)
    {
        if (amount <= 0) return "error";

        string result = "";
        for (int i = 0; i < amount; i++)
        {
            char randomChar = chars[Random.Range(0, chars.Length - 1)];
            result += randomChar;
            //Debug.Log(randomChar);
        }

        //Debug.Log("RandomChar: " + result);
        return result;
    }
}
