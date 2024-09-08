using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///
    ///<summary>
    public enum FSMStateID
    {
        Start,//����
        Wait,//�ȴ�������Ҳ���
        BeChosen,//��ѡ��
        TrueDead,//����
        BeforeDead,//����
        ReceiveCards,//����
        PlayCards,//����
        AbandonCards//����
    }

    public enum FSMTriggerID
    {
        NoHealth,//����Ϊ0
        GetSaved,//������
        NoSave,//û���˾�
        ToBeChosen,//��ѡ��
        GameStart,//��Ϸ��ʼ
        AfterStart,//����֮��
        Action,//����ж�
        FinishReceive,//��������
        FinishPlay,//��������
        FinishAbandon,//��������
        FinishBeChosen//������ѡ��
    }
}
