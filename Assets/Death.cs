using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {

        if (other.transform.name == "DeathZone")
        {
            PlayerManager.GetInstance()._playerList.Remove(this.gameObject.transform.parent.gameObject.GetComponent<Player>());
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

    void OnCollisionEnter(Collision parCollision)
    {
        if (parCollision.gameObject.tag == "Enemy")
        {
            transform.parent.GetComponent<Player>().OnCollisionEnter(parCollision);
        }

    }
}
