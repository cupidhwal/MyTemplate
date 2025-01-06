using System.Collections.Generic;
using UnityEngine;

namespace Seti
{
    public class Effect
    {
        public List<EffectClip> effectClips { get; set; }
    }

    /// <summary>
    /// Effect 속성 : 이펙트 프리팹, 경로, 타입 등...
    /// 기능 : 프리팹 사전 로딩, 이펙트 인스턴스
    /// </summary>
    public class EffectClip
    {
        // 필드
        #region Variables
        public int ID { get; set; }                 // Effect 인덱스
        public string Name { get; set; }            // Effect 이름
        public string EffectName { get; set; }      // Effect 프리팹 이름
        public string EffectPath { get; set; }      // Effect 프리팹 경로
        public EffectType EffectType { get; set; }  // Effect 타입

        private GameObject effectPrefab = null;
        #endregion

        // 생성자
        #region Constructor
        public EffectClip() { }
        #endregion

        // 메서드
        #region Methods
        // 프리팹 사전 로딩
        public void PreLoad()
        {
            if (EffectPath == null || EffectName == null) return;

            var effectFullPath = EffectPath + EffectName;
            if (effectFullPath != string.Empty && effectPrefab == null)
            {
                effectPrefab = ResourcesManager.Load(effectFullPath) as GameObject;
            }
        }

        // 프리팹 해제
        public void ReleaseEffect()
        {
            if (effectPrefab != null)
            {
                effectPrefab = null;
            }
        }

        // Effect Instantiate
        public GameObject Instantiate(Vector3 position)
        {
            if (effectPrefab == null)
            {
                PreLoad();
            }
            if (effectPrefab != null)
            {
                GameObject effectGo = GameObject.Instantiate(effectPrefab, position, Quaternion.identity);
                return effectGo;
            }
            return null;
        }
        #endregion
    }
}