using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelpFunctions {

    public static train.Types StringToType(string name)
    {
        train.Types type = train.Types.Default;
        switch (name)
        {
            case "Default":
                type = train.Types.Default;
                break;
            case "MainTrain":
                type = train.Types.MainTrain;
                break;
            case "Cargo":
                type = train.Types.Cargo;
                break;
            case "Fuel":
                type = train.Types.Fuel;
                break;
            case "Passanger":
                type = train.Types.Passanger;
                break;
            case "Platform":
                type = train.Types.Platform;
                break;
        }
        return type;
    }
}
