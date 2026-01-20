using System.Collections;
using UnityEngine;

public class OrderSpawner : MonoBehaviour
{
    public float spawnTimer = 10f;
    public Transform orderHolder;
    public GameObject orderPrefab;
    public bool stopSpawning;

    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        while (!stopSpawning)
        {
            yield return new WaitForSeconds(spawnTimer);

            GameObject spawned = Instantiate(orderPrefab, orderHolder);
            Order order = spawned.GetComponent<Order>();

            // —— 临时写死一个订单（替代 DatabaseManager）——
            order.blended = false;
            order.coffeeJelly = 0;
            order.tapioka = 1;
            order.sugar = 1;
            order.ice = 0;
            order.cookieCrumble = 0;
            order.flavour = "Original";

            Debug.Log("Order spawned (no DatabaseManager)");
        }
    }
}
