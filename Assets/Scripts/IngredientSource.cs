using System.Collections;
using System.Threading.Tasks;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class IngredientSource : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject ingredientPrefab;
    public int ingredientCapacity;
    private int ingredientAmount;
    public float refillTime;
    private float refillTimer;
    public GameObject spawned;
    private Slider slider;

    void Start()
    {
        ingredientAmount = ingredientCapacity;
        refillTimer = refillTime;
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(false);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ingredientAmount > 0) {
            spawned = Instantiate(ingredientPrefab, transform.parent);
            --ingredientAmount;
        }
    }

    void FixedUpdate()
    {
        if (ingredientAmount <= 0)
        {
            refillTimer -= Time.deltaTime;
            slider.gameObject.SetActive(true);
            slider.value =  1 - (refillTimer / refillTime);
        }
        if(refillTimer <= 0)
        {
            refillTimer = refillTime;
            ingredientAmount = ingredientCapacity;
            slider.gameObject.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(spawned != null)
            spawned.transform.position = new Vector3(Mouse.current.position.value.x, Mouse.current.position.value.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        StartCoroutine("DespawnCheck");
    }

    private IEnumerator DespawnCheck()
    {
        yield return new WaitForEndOfFrame();
        if (spawned != null && spawned.transform.parent == transform.parent)
            Destroy(spawned);
        spawned = null;
    }
}
