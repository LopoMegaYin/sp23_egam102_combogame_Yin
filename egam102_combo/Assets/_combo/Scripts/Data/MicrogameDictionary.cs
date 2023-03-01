using System.Collections.Generic;
using UnityEngine;

namespace MicroCombo
{
    [CreateAssetMenu(fileName = "Dictionary", menuName = "Combo/Dictionary", order = 20)]
    public class MicrogameDictionary : ScriptableObject
    {
        // Microgame data
        [SerializeField] private MicrogameData[] _microgameDatas = null;
        public MicrogameData[] microgameDatas 
        {
            get { return _microgameDatas; }
        }

        public void GetDatas(ref List<MicrogameData> datas, 
            string studentName, bool requireMicrogamePrefab, int requiredMicrogameIndex)
        {
            datas.Clear();

            // Add all of them
            datas.AddRange(_microgameDatas);

            // Prune based on settings
            for (int i = datas.Count - 1; i >= 0; i--)
            {
                if (!datas[i].isValid)
                {
                    datas.RemoveAt(i);
                }
            }

            if (requireMicrogamePrefab)
            {
                for (int i = datas.Count - 1; i >= 0; i--)
                {
                    if (!datas[i].isMicrogamePrefabSupported)
                    {
                        datas.RemoveAt(i);
                    }
                }
            }

            if (!string.IsNullOrEmpty(studentName))
            {
                for (int i = datas.Count - 1; i >= 0; i--)
                {
                    if (studentName != datas[i].studentName)
                    {
                        datas.RemoveAt(i);
                    }
                }
            }

            if (requiredMicrogameIndex >= 0)
            {
                for (int i = datas.Count - 1; i >= 0; i--)
                {
                    if (requiredMicrogameIndex != datas[i].microgameNumber)
                    {
                        datas.RemoveAt(i);
                    }
                }
            }
        }
    }
}