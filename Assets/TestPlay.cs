using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlay : MonoBehaviour
{
    [Tooltip("When assigned, will play the script after entering the dialogue mode.")]
    [ScriptAssetRef] public string Script;

    private IChoiceHandlerManager choiceHandler;

    [Tooltip("When 'Script' is assigned will start playing from the specified label inside the script.")]
    public string Label;

    void Update()
    {
        // Check if the K key is pressed down this frame
        if (Keyboard.current != null && Keyboard.current.kKey.wasPressedThisFrame)
        {
            Debug.Log("K key pressed but script already played (playOnce enabled)");

            if (string.IsNullOrWhiteSpace(Script))
                Dialogue.Enter().Forget();
            else 
                Dialogue.EnterAndPlayAsset(Script, Label).Forget();
            
        }

        var vars = Engine.GetService<ICustomVariableManager>();

        if(vars.VariableExists("choice"))
        {
            if (vars.GetVariableValue("choice").Number == 1)
            {
                print("HasChoosen One");
            }
            else if (vars.GetVariableValue("choice").Number == 2)
            {
                print("HasChoosen Two");
            }
            else
            {
                print("Error");
            }
        }

    }


}
