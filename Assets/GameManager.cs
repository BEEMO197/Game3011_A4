using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject easyBoard;
    public GameObject mediumBoard;
    public GameObject hardBoard;

    public GameObject startGameButton;
    public GameObject changeDifficultyButton;
    public GameObject hakcingSkillObject;
    public GameObject resartGameButton;

    public GameObject winObject;
    public GameObject loseObject;

    public Difficulty difficulty = Difficulty.EASY;

    public TMPro.TextMeshProUGUI currentDifficultyText;
    public TMPro.TextMeshProUGUI nextDifficultyText;

    public int hackingSkill = 10;
    public TMPro.TextMeshProUGUI hackingSkillLevelText;


    public void StartGame()
    {
        switch(difficulty)
        {
            case Difficulty.EASY:
                easyBoard.SetActive(true);
                break;

            case Difficulty.MEDIUM:
                mediumBoard.SetActive(true);
                break;

            case Difficulty.HARD:
                hardBoard.SetActive(true);
                break;
        }
    }

    public void changeGamemode()
    {
        switch(difficulty)
        {
            case Difficulty.EASY:
                difficulty = Difficulty.MEDIUM;
                currentDifficultyText.text = "Medium";
                nextDifficultyText.text = "Hard";
                break;

            case Difficulty.MEDIUM:
                difficulty = Difficulty.HARD;
                currentDifficultyText.text = "Hard";
                nextDifficultyText.text = "Easy";
                break;

            case Difficulty.HARD:
                difficulty = Difficulty.EASY;
                currentDifficultyText.text = "Easy";
                nextDifficultyText.text = "Medium";
                break;
        }
    }

    public void increaseHackingSkill(int skillIncrease)
    {
        hackingSkill += skillIncrease;
        hackingSkillLevelText.text = hackingSkill.ToString();
    }

    public void decreaseHackingSkill(int skillDecrease)
    {
        hackingSkill -= skillDecrease;
        hackingSkillLevelText.text = hackingSkill.ToString();
    }

    public void WinGame()
    {
        easyBoard.SetActive(false);
        mediumBoard.SetActive(false);
        hardBoard.SetActive(false);
        startGameButton.SetActive(false);
        changeDifficultyButton.SetActive(false);
        hakcingSkillObject.SetActive(false);
        resartGameButton.SetActive(false);

        winObject.SetActive(true);
    }

    public void LoseGame()
    {
        easyBoard.SetActive(false);
        mediumBoard.SetActive(false);
        hardBoard.SetActive(false);
        startGameButton.SetActive(false);
        changeDifficultyButton.SetActive(false);
        hakcingSkillObject.SetActive(false);
        resartGameButton.SetActive(false);

        loseObject.SetActive(true);
    }

    public void RetartGame()
    {
        startGameButton.SetActive(true);
        changeDifficultyButton.SetActive(true);
        hakcingSkillObject.SetActive(true);
        resartGameButton.SetActive(true);

        easyBoard.SetActive(false);
        mediumBoard.SetActive(false);
        hardBoard.SetActive(false);

        winObject.SetActive(false);
        loseObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
