using System.Collections;
using UnityEngine;

using Random = UnityEngine.Random;

public enum CreatureType {
    GoodMob,
    EvilMob
}

public enum CreatureDirection {
    Positive,
    Negative
}

public class Creature : MonoBehaviour {
    public AudioClip clip;
    [Range(0.0f, 1.0f)]
    public float audioClipVol;

    public CreaturesData data;

    public Vector3 position;    
    public BoxCollider2D boxCollider2D;    
    public GameObject[] partsToPaint;


    public float Speed { get; set; }
    public float Size { get; set; }

    private float Hp { get; set; }
    private float MaxHp { get; set; }
    private int Points { get; set; }
    private bool isAutoDestroy = false;
    private float destroyTimer = 0;
    private bool isShuttingDown = false;

    private CreatureDirection directionX;
    private CreatureDirection directionY;
    private SpriteRenderer spriteRenderer;
    private GameObject particle;

    void Start() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        boxCollider2D = GetComponentInChildren<BoxCollider2D>();

        var coroutine = ChangeDirection();
        StartCoroutine(coroutine);
    }

    // Setup mob using asset
    public static Creature Create(GameObject go, Vector3 position, CreatureType creatureType) {                                
        Creature creature = go.GetComponent<Creature>();

        MobData mobData = Resources.Load("MobsData/" + creatureType.ToString()) as MobData;

        creature.Hp = mobData.rangeHP ? Random.Range(mobData.HP, mobData.maxHp) : mobData.HP;           
        creature.MaxHp = mobData.maxHp;
        creature.Points = mobData.points;
        creature.position = position;
        creature.SetSize();
        creature.particle = mobData.particle;
        creature.SetSpeed(); 
          
        creature.directionX = Helper.GetRandomEnum<CreatureDirection>();
        creature.directionY = Helper.GetRandomEnum<CreatureDirection>();
        creature.SetPartsColor(mobData.Color);
        
        return creature;        
    }


    public void SetPartsColor(Color color) {
        foreach (var part in partsToPaint) {
            part.GetComponentInChildren<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
    }

    public void SetSize() {
        Size = Hp * data.sizeFactor;
        if (Size > MaxHp * data.sizeFactor)
            Size = MaxHp * data.sizeFactor;

        var scaleX = directionX == CreatureDirection.Positive ? 1 : -1;
        Vector3 scale = new Vector3(Size * scaleX, Size, 1f);
        transform.localScale = scale;
    }


    public void SetSpeed() {
        Speed = (data.speedFactor / Hp) * data.speedAcceleration;
    }


    public void SetDamage(float damage) {
        if (Hp <= data.MinHp) {            
            Destroy(gameObject);            
        }

        Hp -= damage;
        SetSize();
        SetSpeed();
    }


    public float GetRealSize() {
        return boxCollider2D.size.x * Size;
    }


    private void Update() {              
        position.x = directionX == CreatureDirection.Positive ? position.x + Speed * Time.deltaTime : position.x - Speed * Time.deltaTime;
        position.y = directionY == CreatureDirection.Positive ? position.y + Speed * Time.deltaTime : position.y - Speed * Time.deltaTime;        
        transform.position = position;        

        // autodestroy mob if it went out of screen bounds
        if (IsOutOfScreenBounds()) {
            if (destroyTimer > data.destroyTime) {
                isAutoDestroy = true;
                Destroy(gameObject);
            }

            destroyTimer += Time.deltaTime;
            return;
        }

        ResetDestroyTime();
    }
   

    bool IsOutOfScreenBounds() {
        Vector3 pos = Camera.main.WorldToScreenPoint(position);        
        
        if (pos.x - spriteRenderer.sprite.rect.size.x/2 > Screen.width || pos.x + spriteRenderer.sprite.rect.size.x/2 < 0 || pos.y - spriteRenderer.sprite.rect.size.y/2 > Screen.height || pos.y + spriteRenderer.sprite.rect.size.y/2 < 0)
            return true;

        return false;
    }


    void ResetDestroyTime() {
        destroyTimer = 0;
    }


    void OnDestroy() {
        if (isAutoDestroy) 
            return;

        if (isShuttingDown)
            return;
        
        if (GameManager.isPaused)
            return;

        ShowDestroyEffect(transform.position);
        PlayDeathSound();
        GameManager.SetPoints(Points);
    }

    private void PlayDeathSound() {
        GameObject go = new GameObject();
        var source = go.AddComponent<AudioSource>();
        source.volume = audioClipVol;
        source.clip = clip;        
        source.Play();
        Destroy(go, 0.5f);
    }


    IEnumerator ChangeDirection() {
        while (true) {
            directionX = Helper.GetRandomEnum<CreatureDirection>();
            directionY = Helper.GetRandomEnum<CreatureDirection>();

            var scaleX = 1;
            var localScaleX = transform.localScale.x;
            if ((localScaleX > 0 && directionX == CreatureDirection.Negative) || (localScaleX < 0 && directionX == CreatureDirection.Positive))
                scaleX = -1;
            
            transform.localScale = new Vector3(localScaleX * scaleX, transform.localScale.y, transform.localScale.z);

            yield return new WaitForSeconds(data.changeDirectionTime);
        }
    }


    void ShowDestroyEffect(Vector3 pos) {        
        GameObject particleObj = Instantiate(particle, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity) as GameObject;
        particleObj.transform.Find("Explosion").GetComponent<ParticleSystem>().Play();
    }

    void OnApplicationQuit() {
        isShuttingDown = true;
    }
}
