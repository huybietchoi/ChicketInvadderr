using UnityEngine;
using System.Collections;
public class ChickenScript : MonoBehaviour
{
    [SerializeField] private GameObject EggPrefaps;
    private void Awake() //hàm mặc định Unity
                         // tự động chạy trước cả start
    {
        StartCoroutine(SpawmEgg());   
        //StartCoroutine() : hàm chạy 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawmEgg() // hàm có thể bắt vật tạm dừng hđ x time
    {
        while (true)
        {    
            Instantiate(EggPrefaps, transform.position, Quaternion.identity);
            //Instantiate : hàm sinh ra vật thể 
            // ( quả trứng , sinh ra ngay Chicken, giữ nguyên quả trứng )
            yield return new WaitForSeconds(Random.Range(2, 7));
            // yield : câu lệnh Return của IEnumerator

        }
    }

}
