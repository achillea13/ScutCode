using UnityEngine;

public class TestGUI : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //todo 启用自定的结构
        Net.Instance.HeadFormater = new CustomHeadFormater();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {

        // Now create any Controls you like, and they will be displayed with the custom Skin
        if (GUILayout.Button("Click Http"))
        {
            NetWriter.SetUrl("http://127.0.0.1:81/service.aspx");
            Net.Instance.Send((int)ActionType.UserLogin, null);
        }

        // Any Controls created here will use the default Skin and not the custom Skin
        if (GUILayout.Button("Click Socket"))
        {
            NetWriter.SetUrl("127.0.0.1:9001");
            Net.Instance.Send((int)ActionType.UserRegister, null);
        }
    }
}