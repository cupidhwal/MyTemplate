using System.Collections.Generic;
using UnityEngine;

namespace Seti
{
    /// <summary>
    /// Data 기본 클래스
    /// </summary>
    /// 공통적인 데이터 : 이름 목록
    /// 공통적인 기능 : 데이터의 갯수 가져오기, 이름 목록 리스트 얻어 오기, 데이터 추가, 복사, 삭제
    public class BaseData : ScriptableObject
    {
        // 필드
        #region Variables
        // 데이터 저장 경로
        public const string DataDirectory = "Resources/Data";

        //public string[] names;
        public List<string> names;
        #endregion

        // 속성
        #region Properties
        public string Directory => DataDirectory;
        #endregion

        // 생성자
        #region Constructor
        public BaseData() { }
        #endregion

        // 메서드
        #region Methods
        // 데이터의 갯수 가져오기
        public int GetDataCount()
        {
            if (names == null)
            {
                Debug.Log("저장된 데이터가 없습니다.");
                return 0;
            }
            return names.Count;
        }

        // 데이터의 리스트 가져오기
        public string[] GetNameList(bool showID, string filterWord = "")
        {
            int length = GetDataCount();
            string[] retList = new string[length];

            for (int i = 0; i < length; i++)
            {
                // 단어 필터
                if (filterWord != "")
                {
                    if (names[i].ToLower().Contains(filterWord.ToLower()))
                    {
                        continue;
                    }
                }

                // ID 유무
                if (showID)
                {
                    retList[i] = i.ToString() + " : " + names[i];
                }
                else
                {
                    retList[i] = names[i];
                }
            }

            return retList;
        }

        // 데이터 추가, 최종 갯수 리턴
        public virtual int AddData(string newName) => GetDataCount();

        // 데이터 복사
        public virtual void Copy(int index) { }

        // 데이터 삭제
        public virtual void RemoveData(int index) { }
        #endregion
    }
}