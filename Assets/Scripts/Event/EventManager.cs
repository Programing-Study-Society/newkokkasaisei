using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public List<GameObject> rootEventObject;
    public List<GameObject> randomEventObject;

    public List<Button> EventNotSelectButton;
    public GameObject YesObject;
    public GameObject NoObject;
    public GameObject eventObject;//�C�x���g��p�I�u�W�F�N�g
    public GameObject dayCounter;//���ɂ����J�E���g����X�N���v�g
    public Button addMonthButton;//�����ɃX�L�b�v�ł���{�^��
    public SoundVolume soundVolume;

    int random;//�����_���Ȓl��ۑ�����l
    int oldMonth;//�O�̌�

    RandomEventManager randomEventManager;
    WarEventManager warEventManager;
    GameOverEvent gameOverEvent;

    // Start is called before the first frame update
    void Start()
    {
        oldMonth = globalValue.monthNumber;
    }

    // Update is called once per frame
    void Update()
    {
        //�ŏ��̐�������
        TutorialFrag();

        //�푈�C�x���g
        WarEvent();

        //�Q�[���I�[�o�[�C�x���g
        GameOver();

        //�����_���C�x���g����
        if (oldMonth != globalValue.monthNumber)
        {
            
            RandomFunction(100);
            
            //Debug.Log("�����_���C�x���g���I" + random);

            if (random < 1)//1%�̊m���łǂ��炩���I�������
            {
                //�O���̍X�V
                oldMonth = globalValue.monthNumber;

                RandomFunction(10);
                if (random < 1)
                {
                    UFOInvasion();
                }
                else
                {
                    Infection();
                }
            }
            else if (random < 6)//5%�̊m���łǂ��炩���I�������
            {
                //�O���̍X�V
                oldMonth = globalValue.monthNumber;
                RandomFunction(10);
                if (random < 3)
                {
                    LuckyEvent();
                }
                else
                {
                    disasterEvent();
                }
            }
            else if(random < 16)//10%�̊m���łǂ��炩���I�������
            {
                //�O���̍X�V
                oldMonth = globalValue.monthNumber;

                RandomFunction(10);
                if (random < 5)
                {
                    HelpEvent();
                }
                else
                {
                    MyCountryEvent();
                }
            }
            
            //�O���̍X�V
            oldMonth = globalValue.monthNumber;
        }
        
    }

    //�����_���C�x���g���ɒ�~�������
    public void DuringEvent()
    {
        int EventNotSelectButtonMaxCount = EventNotSelectButton.Count;

        if (globalValue.eventExecution)//�C�x���g��
        {
            dayCounter.SetActive(false);//�����J�E���^�[��~

            //�����ꂽ���Ȃ��{�^���������Ȃ��悤�ɂ���
            for (int i = 0;i < EventNotSelectButtonMaxCount; i++)
            {
                EventNotSelectButton[i].interactable = false;
            }
        }
        else
        {
            dayCounter.SetActive(true);//�����J�E���^�[�J�n
            //�����ꂽ���Ȃ��{�^����������悤�ɂ���
            for (int i = 0; i < EventNotSelectButtonMaxCount; i++)
            {
                EventNotSelectButton[i].interactable = true;
            }
        }
    }

    //�����Event���J�n����
    public void StartEvent(bool rootEvent ,int eventNumber)
    {
        if(rootEvent)//rootEvent�̏ꍇ
        {
            globalValue.eventExecution = true;
            dayCounter.SetActive(false);//�����J�E���^�[��~
            rootEventObject[eventNumber].SetActive(true);
            globalValue.rootEventNumber = eventNumber;

            if (globalValue.rootEventNumber >= 2)
            {
                DuringEvent();
            }
        }
        else//randomEvent�̏ꍇ
        {
            globalValue.randomEventNumber = eventNumber;
            globalValue.eventExecution = true;
            DuringEvent();
            randomEventObject[eventNumber].SetActive(true);
            eventObject.SetActive(true);
        }
    }
    
    //�J�n���Ă���C�x���g���I������
    public void EndEvent(bool rootEvent, int eventNumber)
    {
        if (rootEvent)
        {
            globalValue.lineNumber = 0;
            globalValue.eventExecution = false;
            dayCounter.SetActive(true);//�����J�E���^�[��~
            rootEventObject[eventNumber].SetActive(false);
            
            if (globalValue.rootEventNumber >= 2)
            {
                DuringEvent();
            }
            globalValue.rootEventNumber++;
            soundVolume.bgmVolume[1].Stop();
            soundVolume.bgmVolume[0].Play();
        }
        else
        {
            globalValue.lineNumber = 0;
            globalValue.eventExecution = false;
            DuringEvent();
            randomEventObject[eventNumber].SetActive(false);
            eventObject.SetActive(false);
            if (eventNumber < 4)
            {
                randomAddValue();
            }
            soundVolume.bgmVolume[2].Stop();
            soundVolume.bgmVolume[1].Stop();
            soundVolume.bgmVolume[0].Play();
        }
        
    }

    //�����_���C�x���g���I�������� static �l�ύX�֐�
    public void randomAddValue()
    {
        if (globalValue.randomEventNumber == 0)//UFO�C�x���g
        {
            globalValue.population -= 300;
        }
        else if(globalValue.randomEventNumber == 1)//�����ǃC�x���g
        {
            globalValue.gigaMoney -= 50;
        }
        else if (globalValue.randomEventNumber == 2)//�ЊQ�C�x���g
        {
            globalValue.gigaMoney -= 10;
        }
        else if (globalValue.randomEventNumber == 3)//���b�L�[�C�x���g
        {
            if (globalValue.randomValue == 0)
            {
                globalValue.population += 100;
            }
            else if (globalValue.randomValue == 1)
            {
                globalValue.population += 300;
            }
            else if (globalValue.randomValue == 2)
            {
                globalValue.gigaMoney += 50;
            }
            else if (globalValue.randomValue == 3)
            {
                for (int i = 0;i < 5;i++)
                {
                    if (globalValue.friendshipLevel[i] <= 100)
                    {
                        globalValue.friendshipLevel[i] += 10;
                    }
                }
                double magnification = 0;
                globalValue.tradeSize = 0;
                for (int i = 0; i < globalValue.tradeSituation.Count; i++)
                {
                    if (globalValue.tradeSituation[i] == "�f�Ւ�")
                    {
                        magnification += globalValue.friendshipLevel[i] - 50;
                        globalValue.tradeSize++;
                    }
                }
                magnification /= 10;
                magnification *= 0.5;
                globalValue.tradeSize += magnification;
            }    
        }
        else if (globalValue.randomEventNumber == 4)//�e���������C�x���g
        {
            if (globalValue.randomValue <= 1 || globalValue.randomValue == 4)
            {
                globalValue.gigaMoney -= 10;
            }
            else if (globalValue.randomValue == 2 || globalValue.randomValue == 3)
            {
                globalValue.population -= 100;
            }
        }
        else if (globalValue.randomEventNumber == 5)//�����v���C�x���g
        {
            globalValue.gigaMoney -= 10;
        }
    }

    // �����_���Ȓl(0 �` randomValue �̊�)���擾����֐� ��randomValue�͊܂܂Ȃ�
    public void RandomFunction(int randomValue)
    {
        random = Random.Range(0, randomValue);
        //Debug.Log(random);
    }

    //�����_���C�x���g�Ŏg���e�L�X�g��I������
    public void RandomEventTextSelect(int eventNumber,int textNumber)
    {
        randomEventManager = randomEventObject[eventNumber].GetComponent<RandomEventManager>();

        if (textNumber == 0)
        {
            randomEventManager.ChangeReadText(0);
        }
        else
        {
            RandomFunction(textNumber);
            globalValue.randomValue = random;
            //Debug.Log(random);
            randomEventManager.ChangeReadText(random);
        }
        
    }

    //�ŏ��̐������������
    public void TutorialFrag()
    {
        if(globalValue.rootEventNumber == 0)
        {
            if (!globalValue.eventExecution)
            {
                StartEvent(true,globalValue.rootEventNumber);
            }
        }
        else if(globalValue.rootEventNumber == 1)
        {
            StartEvent(true, globalValue.rootEventNumber);
        }
        else
        {

        }
    }

    //�Q�[���I�[�o�[�C�x���g
    public void GameOver()
    {
        if (!globalValue.eventExecution)
        {
            if (globalValue.complain >= globalValue.complainMax)
            {
                globalValue.rootEventNumber = 3;
                globalValue.randomValue = 0;
                gameOverEvent = rootEventObject[3].GetComponent<GameOverEvent>();
                gameOverEvent.ChangeReadText(globalValue.randomValue);
                StartEvent(true, globalValue.rootEventNumber);
            }
            if (globalValue.gigaMoney < 0)
            {
                if (globalValue.money < 0)
                {
                    globalValue.rootEventNumber = 3;
                    globalValue.randomValue = 1;
                    gameOverEvent = rootEventObject[3].GetComponent<GameOverEvent>();
                    gameOverEvent.ChangeReadText(globalValue.randomValue);
                    StartEvent(true, globalValue.rootEventNumber);
                }

            }
            if (globalValue.population < 0)
            {
                globalValue.rootEventNumber = 3;
                globalValue.randomValue = 2;
                gameOverEvent = rootEventObject[3].GetComponent<GameOverEvent>();
                gameOverEvent.ChangeReadText(globalValue.randomValue);
                StartEvent(true, globalValue.rootEventNumber);
            }
        }
    }

    //�푈�C�x���g
    public void WarEvent()
    {
        if (!globalValue.eventExecution)
        {
            for (int i = 0; i < 5; i++)
            {
                if (globalValue.tradeSituation[i] == "�푈��")
                {
                    globalValue.tradeSituation[i] = "���Ă��Ȃ�";
                    globalValue.friendshipLevel[i] = 10;
                    globalValue.rootEventNumber = 2;
                    globalValue.randomValue = i;
                    warEventManager = rootEventObject[2].GetComponent<WarEventManager>();
                    warEventManager.ChangeReadText(i);
                    StartEvent(true, globalValue.rootEventNumber);
                }
            }
        }
    }

    //UFO�P���C�x���g(1%�̊m��)
    public void UFOInvasion()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(0, 0);
            StartEvent(false, 0);
            soundVolume.bgmVolume[0].Stop();
            soundVolume.bgmVolume[1].Play();
            soundVolume.seVolume[7].Play();
        }
    }

    //�����ǃC�x���g�i1%�j
    public void Infection()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(1, 0);
            StartEvent(false, 1);
            soundVolume.bgmVolume[0].Stop();
            soundVolume.bgmVolume[1].Play();
            soundVolume.seVolume[6].Play();
        }
    }

    //�ЊQ�C�x���g(5%)
    public void disasterEvent()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(2, 3);
            StartEvent(false, 2);
            soundVolume.bgmVolume[0].Stop();
            soundVolume.bgmVolume[1].Play();
            soundVolume.seVolume[6].Play();
        }
    }

    //�����_���w���v�C�x���g
    public void HelpEvent()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(4, 5);
            YesObject.SetActive(true);
            NoObject.SetActive(true);
            StartEvent(false, 4);
        }
    }

    //�����_�����b�L�[�C�x���g
    public void LuckyEvent()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(3, 4);
            StartEvent(false, 3);
            soundVolume.bgmVolume[0].Stop();
            soundVolume.bgmVolume[2].Play();
        }
    }

    //�����_�������C�x���g
    public void MyCountryEvent()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(5, 3);
            YesObject.SetActive(true);
            NoObject.SetActive(true);
            StartEvent(false, 5);
        }
    }
}
