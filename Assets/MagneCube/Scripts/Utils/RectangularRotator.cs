using System.Collections.Generic;
using UnityEngine;

public static class RectangularRotator<T>{
    public static void Rotate(Dictionary<string, T> dictionary, int angle) {
        angle %= 360;

        if (angle < 0) {
            angle += 360;
        }

        switch (angle) {
            case 90: Rotate90(dictionary); break;
            case 180: Rotate180(dictionary); break;
            case 270: Rotate270(dictionary); break;
            default:break;
        }
    }

    public static void Rotate90(Dictionary<string, T> dictionary)
    {
        T temp = dictionary[GameConstants.UP_BOX];
        dictionary[GameConstants.UP_BOX] = dictionary[GameConstants.LEFT_BOX];
        dictionary[GameConstants.LEFT_BOX] = dictionary[GameConstants.DOWN_BOX];
        dictionary[GameConstants.DOWN_BOX] = dictionary[GameConstants.RIGHT_BOX];
        dictionary[GameConstants.RIGHT_BOX] = temp;
    }

    public static void Rotate180(Dictionary<string, T> dictionary)
    {
        T tempUp = dictionary[GameConstants.UP_BOX];
        T tempLeft = dictionary[GameConstants.LEFT_BOX];
        dictionary[GameConstants.UP_BOX] = dictionary[GameConstants.DOWN_BOX];
        dictionary[GameConstants.DOWN_BOX] = tempUp;
        dictionary[GameConstants.LEFT_BOX] = dictionary[GameConstants.RIGHT_BOX];
        dictionary[GameConstants.RIGHT_BOX] = tempLeft;
    }

    public static void Rotate270(Dictionary<string, T> dictionary)
    {
        T temp = dictionary[GameConstants.UP_BOX];
        dictionary[GameConstants.UP_BOX] = dictionary[GameConstants.RIGHT_BOX];
        dictionary[GameConstants.RIGHT_BOX] = dictionary[GameConstants.DOWN_BOX];
        dictionary[GameConstants.DOWN_BOX] = dictionary[GameConstants.LEFT_BOX];
        dictionary[GameConstants.LEFT_BOX] = temp;
    }

}