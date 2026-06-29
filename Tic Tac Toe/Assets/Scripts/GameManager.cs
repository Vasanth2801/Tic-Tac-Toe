using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event EventHandler<onClickedGridPositionEventArgs> onClickedOnGridPosition; 

    public class onClickedGridPositionEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("More than One GameManager exist");
        }
    }

    public void OnClickedPosition(int x, int y)
    {
        Debug.Log("OnClickedPosition" + x + "," + y);
        onClickedOnGridPosition?.Invoke(this, new onClickedGridPositionEventArgs
        {
            x = x,
            y = y,
        });
    }
}