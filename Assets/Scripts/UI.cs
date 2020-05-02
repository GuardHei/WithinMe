using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Image UIBox;

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            UIBox.gameObject.SetActive(false);
        }
    }
}
