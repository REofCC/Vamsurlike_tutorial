using UnityEngine;

public class MapManager : MonoBehaviour
{
    void start()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Area"))
            return;
        Vector2 playerPos = GameManager.instance.player.transform.position;
        Vector2 myPos = transform.position;
        float xDiff = Mathf.Abs(playerPos.x - myPos.x);
        float yDiff = Mathf.Abs(playerPos.y - myPos.y);

        Vector2 playerDir = GameManager.instance.player.inputVec;
        float xDir = playerDir.x < 0 ? -1 : 1;
        float yDir = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (xDiff > yDiff)
                {
                    transform.Translate(Vector2.right * xDir * 40);
                }
                else if (xDiff < yDiff)
                {
                    transform.Translate(Vector2.up * yDir * 40);
                }
                break;
            case "Enemy":
            {
                break;
            }
        }
    }
    void RePosition()
    {

    }
}
