using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToGameEvent : MonoBehaviour {
    [System.Serializable]
    public class Item
    {
        public KeyCode key;
        public GameEvent gameEvent;
    }

    public Item[] items;
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyUp(items[i].key))
            {
                items[i].gameEvent.Invoke();
            }
        }
	}
}
