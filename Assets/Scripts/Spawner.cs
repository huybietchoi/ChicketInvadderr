using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float gridSize = 1 ; // khoảng cách gà
    private Vector3 SpawnPos; //điểm Spawn gà
    [SerializeField] private GameObject ChickenPrefaps;
    [SerializeField] private Transform GridChicken;
    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height; //cam nhìn được 
                              //Pixel -> World Position
        SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height, 0));//toạ độ ở góc trên bên trái
        SpawnPos.x += ( (width / 8));
        SpawnPos.y -= gridSize;
        SpawnPos.z = 0;
        SpawnChicken(Mathf.FloorToInt(height/2/gridSize),Mathf.FloorToInt(width/gridSize/1.5f));
    }

    void SpawnChicken(int row, int numberChicken)
    {
        float x = SpawnPos.x;
        for(int i = 0;i < row ; i++)
        {
            for (int j = 0; j < numberChicken; j++)
            {
                SpawnPos.x = SpawnPos.x + gridSize;
                GameObject Chicken =  Instantiate(ChickenPrefaps, SpawnPos, Quaternion.identity);
                Chicken.transform.parent = GridChicken;
            }

            SpawnPos.x = x;
            SpawnPos.y -= gridSize;
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
