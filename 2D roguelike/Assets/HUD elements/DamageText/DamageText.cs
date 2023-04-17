using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{

    public float timeToLive = 1f;
    public float floatSpeed = 250;
    public Vector3 floatDirection = new Vector3(0, 1, 0);

    public TextMeshProUGUI textMesh;
    public GameObject player;

    float timeElapsed = 0f;

    RectTransform rTransform;
    Color startingColor;


    // Start is called before the first frame update
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        startingColor = textMesh.color;
        Destroy(gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        rTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed / timeToLive));
        textMesh.text = player.GetComponent<PlayerCombat>().attackDamage.ToString();
    }
}
