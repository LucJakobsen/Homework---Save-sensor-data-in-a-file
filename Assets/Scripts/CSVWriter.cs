using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

// NOTE: I had quite a bit of help with the coding from Daniel Lerche to make sure the values that were printed into the CSV file was the once measured from the gyroscope

public class CSVWriter : MonoBehaviour
{
    SensorReader sensorReader;
    string filename = "";
    bool isMeasuring = false;

    [SerializeField]
    Button button;
    
    [System.Serializable]

    public class GyroData
    {
        public float x;
        public int y;
        public int z;
    }

    [System.Serializable]
    public class GyroDataList
    {
        public GyroData[] gyrodata;
    }

    public List<Quaternion> myGyroDataList = new List<Quaternion>();

    void Start()
    {
        filename = Application.dataPath + "/test.csv";
        button.onClick.AddListener(StartMeasuring);

    }

    // Update is called once per frame
    void Update()
    {
        if(isMeasuring)
        {
            myGyroDataList.Add(Input.gyro.attitude);
        }
        if(myGyroDataList.Count > 0)
        {
            WriteCSV();
        }
    }

    public void StartMeasuring()
    {
        if(isMeasuring)
        {
            isMeasuring = false;
        }
        else
        {
            isMeasuring = true;
        }
    }

    public void WriteCSV()
    {       
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("x; y; z");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for(int i = 0; i < myGyroDataList.Count; i++)
            {
                tw.WriteLine(myGyroDataList[i].x + ";" + myGyroDataList[i].y + ";" + myGyroDataList[i].z);
            }
            tw.Close();

    }

}
