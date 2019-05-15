using SteamBoiler.tPart.ARSteamBoiler;
using tung.IntroBoiler;
using UnityEngine;

[RequireComponent(typeof(IntroSelectable))]
public class ShowIntroPopupAfterClick : MonoBehaviour
{

    IntroSelectable _introSelect = null;
    IntroSelectable introSelect
    {
        get
        {
            if (_introSelect == null) _introSelect = GetComponent<IntroSelectable>();
            return _introSelect;
        }
    }

    public void OnEnable()
    {
        introSelect.delAfter += ActiveIntroPopup;
    }

    void ActiveIntroPopup(string name)
    {
        CanvasManager manager = FindObjectOfType<CanvasManager>();
        if (string.IsNullOrEmpty(manager.currentBoiler.imageName))
            return;

        ASteamBoiler currentBoiler = manager.database.GetASteamBoiler(manager.currentBoiler.imageName);
        BoilerPart boilerPart = currentBoiler.GetBoilerPart(name);

        manager.introPanel.gameObject.SetActive(true);
        manager.introPanel.introText.text = "This is the " + boilerPart.partIntro;
    }

    public void OnDisable()
    {
        introSelect.delAfter -= ActiveIntroPopup;
    }
}
