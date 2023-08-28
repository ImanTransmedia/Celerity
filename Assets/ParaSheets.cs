using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;


public class ParaSheets : MonoBehaviour
{
    public TextMeshProUGUI Turno;
    public TextMeshProUGUI CasaTipo;
    public TextMeshProUGUI Dispositivo;
    public TextMeshProUGUI debug;

    private string _Turno;
    private string _CasaTipo;
    private string _Dispositivo;

    private string filePath;

    [SerializeField] private string Base_URL = "https://docs.google.com/forms/u/2/d/e/1FAIpQLSfaIzVwjexrw2jdaa7JpgbjrkOJji1UeP9OvznCZ2A7xp92fQ/formResponse";

    private void Start()
    {
        // Establece la ruta del archivo CSV
        string fileName = "BaseDatosCelerity.csv";
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        // Escribe la primera línea de encabezado si el archivo no existe
        if (!File.Exists(filePath))
        {
            string header = "Columna1,Columna2,Columna3";
            File.WriteAllText(filePath, header + Environment.NewLine);
        }
    }

    public IEnumerator Postear(string turno, string CasaTipo, string Dispositivo)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("entry.1191851147", turno));
        formData.Add(new MultipartFormDataSection("entry.1494990026", CasaTipo));
        formData.Add(new MultipartFormDataSection("entry.751019694", Dispositivo));

        UnityWebRequest www = UnityWebRequest.Post(Base_URL, formData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error al enviar el formulario: " + www.error);
        }
        else
        {
            Debug.Log("Formulario enviado exitosamente");
        }
    }

    public void PostearOffline(string turno, string CasaTipo, string Dispositivo)
    {
        // Datos que deseas guardar en el archivo CSV
        string data1 = turno;
        string data2 = CasaTipo;
        string data3 = Dispositivo;

        // Concatena los datos en una línea CSV
        string line = string.Format("{0},{1},{2}", data1, data2, data3);

        // Agrega la línea al archivo CSV
        File.AppendAllText(filePath, line + Environment.NewLine);

        Debug.Log("Datos guardados en el archivo CSV.");
    }

    public void Update()
    {
       /* if (OVRInput.GetDown(OVRInput.RawButton.A, OVRInput.Controller.RTouch))
        {
            Send();
        }*/
    }

    public void Send()
    {
        _Turno = Turno.text;
        _CasaTipo = CasaTipo.text;
        _Dispositivo = Dispositivo.text;

        //envia el request online
        StartCoroutine(Postear(_Turno, _CasaTipo, _Dispositivo));
        //envia el request online
        PostearOffline(_Turno, _CasaTipo, _Dispositivo);

        debug.text = "enviado";
        Debug.Log("Enviado");
    }

    
}
