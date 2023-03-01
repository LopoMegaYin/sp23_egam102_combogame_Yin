using UnityEngine;

public static class EgamMicrogameInput
{
    // Input mapping
    private static readonly KeyCode[] LeftKeyCodes = 
    {
        KeyCode.A,
        KeyCode.LeftArrow
    };

    private static readonly KeyCode[] RightKeyCodes = 
    {
        KeyCode.D,
        KeyCode.RightArrow
    };

    private static readonly KeyCode[] UpKeyCodes = 
    {
        KeyCode.W,
        KeyCode.UpArrow
    };

    private static readonly KeyCode[] DownKeyCodes = 
    {
        KeyCode.S,
        KeyCode.DownArrow
    };

    private static readonly KeyCode[] ActionKeyCodes = 
    {
        KeyCode.Space        
    };

    public enum Key
    {
        Up,
        Right,
        Down,
        Left,
        Action
    }

    public enum State
    {
        Up,
        Down,
        Held
    }

    public static bool GetKeyDown(Key key)
    {
        return GetValue(key, State.Down);
    }

    public static bool GetKey(Key key)
    {
        return GetValue(key, State.Held);
    }

    public static bool GetKeyUp(Key key)
    {
        return GetValue(key, State.Up);
    }

    private static bool GetValue(Key key, State state)
    {
        bool isKey = false;
        KeyCode[] keys = GetKeyCodes(key);
        foreach(KeyCode code in keys)
        {
            switch (state)
            {
                case State.Up:
                    isKey |= Input.GetKeyUp(code);
                    break;
                case State.Down:
                    isKey |= Input.GetKeyDown(code);
                    break;
                case State.Held:
                    isKey |= Input.GetKey(code);
                    break;
            }
        }
        return isKey;
    }

    private static KeyCode[] GetKeyCodes(Key key)
    {
        KeyCode[] keys = ActionKeyCodes;
        switch (key)
        {
            case Key.Left:
                keys = LeftKeyCodes;
                break;
            case Key.Right:
                keys = RightKeyCodes;
                break;
            case Key.Up:
                keys = UpKeyCodes;
                break;
            case Key.Down:
                keys = DownKeyCodes;
                break;
        }
        return keys;
    }
}
