using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSystem : MonoBehaviour {

    public static MessageSystem instance;
    [SerializeField] GameObject damageMessage;

    List<TMPro.TextMeshPro> messagePool;
    private int objectCount = 10;
    private int count = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        messagePool = new List<TMPro.TextMeshPro>();
        for(int i =0; i< objectCount;i++)
        {
            Populate();
        }
    }

    public void Populate()
    {
        GameObject go = Instantiate(damageMessage, transform);
        messagePool.Add(go.GetComponent<TMPro.TextMeshPro>());
    }

    public void PostMessage(string text, Vector3 worldPosition)
    {
        messagePool[count].gameObject.SetActive(true);
        messagePool[count].transform.position = worldPosition;
        messagePool[count].text = text;
        count++;
        if(count >= objectCount) {count = 0;}
    }
}
