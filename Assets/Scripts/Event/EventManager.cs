using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public List<GameObject> rootEventObject;
    public List<GameObject> randomEventObject;

    public GameObject dayCounter;//���ɂ����J�E���g����X�N���v�g
    public Button addMonthButton;//�����ɃX�L�b�v�ł���{�^��

    int random;//�����_���Ȓl��ۑ�����l
    int oldMonth;//�O�̌�

    // Start is called before the first frame update
    void Start()
    {
        oldMonth = globalValue.monthNumber;
    }

    // Update is called once per frame
    void Update()
    {
        //�ŏ��̐�������
        //TutorialFrag();

        //�����_���C�x���g����
        if (oldMonth != globalValue.monthNumber)
        {
            Debug.Log("�����_���C�x���g���I");
            UFOInvasion();//1%
            Infection();//1%
            disasterEvent();//5%
            oldMonth = globalValue.monthNumber;
        }
        
    }

    //�����Event���J�n����
    public void StartEvent(bool rootEvent ,int eventNumber)
    {
        if(rootEvent)//rootEvent�̏ꍇ
        {
            globalValue.eventExecution = true;
            DuringEvent();
            rootEventObject[eventNumber].SetActive(true);
        }
        else//randomEvent�̏ꍇ
        {
            globalValue.randomEventNumber = eventNumber;
            globalValue.eventExecution = true;
            DuringEvent();
            randomEventObject[eventNumber].SetActive(true);
        }
    }
    
    //�J�n���Ă���C�x���g���I������
    public void EndEvent(bool rootEvent, int eventNumber)
    {
        if (rootEvent)
        {
            globalValue.lineNumber = 0;
            globalValue.eventExecution = false;
            DuringEvent();
            rootEventObject[eventNumber].SetActive(false);
            globalValue.rootEventNumber++;
        }
        else
        {
            globalValue.lineNumber = 0;
            globalValue.eventExecution = false;
            DuringEvent();
            randomEventObject[eventNumber].SetActive(false);
        }
        
    }

    //�C�x���g���ɒ�~�������
    public void DuringEvent()
    {
        if (globalValue.eventExecution)//�C�x���g��
        {
            addMonthButton.interactable = false;
            dayCounter.SetActive(false);//�����J�E���^�[��~
        }
        else
        {
            addMonthButton.interactable = true;
            dayCounter.SetActive(true);//�����J�E���^�[�J�n
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

    // �����_���Ȓl(0 �` randomValue �̊�)���擾����֐�
    // ��randomValue�͊܂܂Ȃ�
    public void RandomFunction(int randomValue)
    {
        random = Random.Range(0, randomValue);
        //Debug.Log(random);
    }

    //UFO�P���C�x���g(1%�̊m��)
    public void UFOInvasion()
    {
        if (!globalValue.eventExecution)
        {
            RandomFunction(100);
            if (random < 1)
            {
                StartEvent(false, 0);
            }
        }
    }

    //�����ǃC�x���g�i1%�j
    public void Infection()
    {
        if (!globalValue.eventExecution)
        {
            RandomFunction(100);
            if (random < 1)
            {
                StartEvent(false, 1);
            }
        }
    }

    //�ЊQ�C�x���g(5%)
    public void disasterEvent()
    {
        if (!globalValue.eventExecution)
        {
            RandomFunction(100);
            if (random < 5)
            {
                StartEvent(false, 2);
            }
        }
    }
}
