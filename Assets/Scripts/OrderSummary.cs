using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class OrderSummary : MonoBehaviour
{
    public Text orderSummary;

    // Start is called before the first frame update
    void Start()
    {

        if (MyStorage.firstOrderName != null)
            orderSummary.text += "• " + MyStorage.firstOrderName + "\n";

        if (MyStorage.secondOrderName != null)
            orderSummary.text += "• " + MyStorage.secondOrderName + "\n";

        if (MyStorage.thirdOrderName != null)
            orderSummary.text += "• " + MyStorage.thirdOrderName + "\n";

        if (MyStorage.forthOrderName != null)
            orderSummary.text += "• " + MyStorage.forthOrderName + "\n";

        if(MyStorage.fifthOrderName != null)
            orderSummary.text += "• " + MyStorage.fifthOrderName;

        Debug.Log(MyStorage.secondOrderName);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
