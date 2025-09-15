using UnityEngine;

public class Sunflower : MonoBehaviour
{
    private Animator animator;
    public GameObject sunPerfab;

    public float readyTime;
    private float timer;
    public int sunNum;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timer = 0;

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > readyTime)
        {
            animator.SetBool("isReady", true);
        }

    }

    public void BornOver()
    {
        BornSun();
        animator.SetBool("isReady", false);
        timer = 0;
    }

    public void BornSun()
    {
        GameObject sunTemp = Instantiate(sunPerfab);
        sunNum += 1;
        float randomX;
        if (sunNum % 2 == 1)
        {
            randomX = Random.Range(transform.position.x - 30, transform.position.x - 20);
        }
        else
        {
            randomX = Random.Range(transform.position.x + 20, transform.position.x - 30);
        }
        float randomY = Random.Range(transform.position.y - 20, transform.position.y + 20);
        sunTemp.transform.position = new Vector2(randomX, randomY);

    }


}
