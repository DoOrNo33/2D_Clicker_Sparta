# <p align="center"> **2D_Clicker_Sparta**  </p>

##### <p align="center"> <b> 내일 배움 캠프 Unity 게임개발 심화 개인과제  </b>

<br/>
<br/>

<br/>

---

### 📖 목차
+ [기여자 소개](#기여자-소개)
+ [프로젝트 소개](#프로젝트-소개)
+ [구현 기능](#구현-기능)
---

### ✨기여자 소개
| 이름   |
|--------|
| 권태하 |

---

### ✨프로젝트 소개

 `Info` 2D 클리커 게임입니다. 플레이어는 보상을 얻기 위해 가능한 빨리 누르면 됩니다. 얻은 보상으로는 클릭의 보상을 증가시키거나 & 자동 클릭을 할 수 있는 기능을 구매할 수 있습니다.

 `Stack` C#, Unity-2022.3.17f, Visual Studio2022-17.9.6   

 `Made by` **권태하** 
 
---

### ✨구현 기능

- 필수요구사항
1. **클릭 이벤트 처리**
    - 이벤트 구독을 통해 버튼을 클릭할 때마다 게임 자원인 Energy 총량을 증가시키고 텍스트를 업데이트 시키게 구현했습니다. 
```
    [SerializeField] public BigInteger energyAmount { get; private set; }

    private void Awake()
    {
        GameManager.Instance.EnergyChange += ChangeEnergyAmount;
    }

    public void ChangeEnergyAmount(long amount)
    {
        energyAmount += amount;
    }

==

    private TextMeshProUGUI energyText;

    void Start()
    {
        energyText = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.EnergyChange += UpdateEnergyUI;       
    }

    public void UpdateEnergyUI(long amount)
    {
        energyText.text = GameManager.Instance.EnergyController.GetEnergyAmount();
    }
```

      
2. **자동 클릭 기능** `Coroutine`
    - 코루틴을 통해 정해진 시간마다 클릭 이벤트가 발생하도록 했습니다.
```
    void Update()
    {
        if (GameManager.Instance.ClickSO.AutoClickEnabled && !isAutoClicking)
        {
            isAutoClicking = true;
            StartCoroutine(AutoClickRoutine());
        }
    }

    IEnumerator AutoClickRoutine()
    {
        while (GameManager.Instance.ClickSO.AutoClickEnabled)
        {
            GameManager.Instance.CallChangeEnergyEvent(GameManager.Instance.ClickSO.ClickValue);
            GameManager.Instance.ClickEvent?.Invoke(GameManager.Instance.ClickSO.ClickValue);
            yield return new WaitForSeconds(GameManager.Instance.ClickSO.AutoClickInterval);
        }
    }
```
      
3. **점수 시스템** `UGUI` 
    - 1번 항목과 동일하며, 점수이자 자원인 Energy를 통해 모든 활동이 움직입니다.
      
4. **아이템 및 업그레이드 시스템**
    - 아이템 클래스와 구매 인터페이스를 통해 자동 클릭 시간을 줄이거나 클릭시의 보상을 늘릴 수 있습니다.
    - Energy Cost가 충분하다면 Energy를 차감하고 Scriptable Object의 값을 조정하도록 스크립팅 했습니다.
```
    public override void PurchaseItem()
    {
        bool isPurchased = (cost <= GameManager.Instance.EnergyController.energyAmount);
        bool isMaxLevel = (level < maxLevel);
        if (isPurchased && isMaxLevel)
        {
            GameManager.Instance.CallChangeEnergyEvent(-cost);

            if (!GameManager.Instance.ClickSO.AutoClickEnabled)
            {
                GameManager.Instance.ClickSO.AutoClickEnabled = true;
            }
            else
            {
                GameManager.Instance.ClickSO.AutoClickInterval -= itemValue;
            }

            level++;
            cost = IncreaseCost(baseCost, level) * IncreaseCost(baseCost, level);

            itemStatsText[(int)TextType.Level].text = $"Level : {level} / {maxLevel}";
            if (level == maxLevel)
            {
                itemStatsText[(int)TextType.Cost].text = "Sold Out";
            }
            else
            {
                itemStatsText[(int)TextType.Cost].text = $"Cost : {GetBigInt(cost)}";
            }

        }
    }
```
      
5. **게임 내 통화 시스템**
    - 4번 설명과 동일합니다.

   
- 선택요구사항
1. **파티클 시스템**
    - 클릭 시 이벤트 구독을 통해 파티클이 발생됩니다.
```
    private void Start()
    {
        GameManager.Instance.mainParticle = this;
        GameManager.Instance.ClickEvent += PlayParticle;
    }
    
    public void PlayParticle(long temp)
    {
        clickParticle.Play();
    }
```
![파티클](https://github.com/DoOrNo33/2D_Clicker_Sparta/assets/167051416/750f6fe7-1777-4fa4-98b3-49adcc403f41)


2. **애니메이션** 
    - 오브젝트 풀을 이용해 추가되는 EnergyValue값이 애니메이션으로 표시되도록 구현했습니다.
```
    public void CreateText(long temp)
    {
        GameObject obj = gm.objectPool.SpawnFromPool("ClickTxt");
        TextMeshProUGUI txt = obj.GetComponent<TextMeshProUGUI>();
        Animator animator = obj.GetComponent<Animator>();

        txt.text = GetValue(gm.ClickSO.ClickValue);
        animator.SetTrigger(onClick);
    }
```
![애니메이션](https://github.com/DoOrNo33/2D_Clicker_Sparta/assets/167051416/c5724ef4-fa4c-4cba-a4b2-07ca3852267d)


3. **BigInteger 기능**
    - 매우 큰 숫자를 처리하기 위한 기능입니다.
```
    public string GetEnergyAmount()
    {
        int placeN = 3;  
        BigInteger value = energyAmount;
        List<int> numList = new List<int>();
        int p = (int)Mathf.Pow(10, placeN); 

        do
        {
            numList.Add((int)(value % p)); 
            value /= p; 
        }
        while (value >= 1); 

        string retStr = "";

        if (numList.Count < 3)
        {
            for (int i = numList.Count - 1; i >= 0; i--)
            {
                retStr = retStr + numList[i].ToString() + goldUnitArr[i];
            }
        }
        else
        {
            for (int i = numList.Count - 1; i >= numList.Count - 3; i--)
            {
                retStr = retStr + numList[i].ToString() + goldUnitArr[i];
            }
        }

        return retStr;
    }
```
![image](https://github.com/DoOrNo33/2D_Clicker_Sparta/assets/167051416/17acb9ef-d498-4fe3-87d5-71d653a1892c)


--- 

