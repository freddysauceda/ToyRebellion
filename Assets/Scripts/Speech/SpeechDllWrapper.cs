using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class SpeechDllWrapper {

#if UNITY_STANDALONE || UNITY_EDITOR
    const string dll = "pocketsphinx_unity";
#endif

    [DllImport(dll, EntryPoint = "Read_Mic")]
    public static extern int Read_Mic();

    [DllImport(dll, EntryPoint = "GetScore")]
    public static extern int GetScore();

    [DllImport(dll, EntryPoint = "GetLength")]
    public static extern int GetLength();

    [DllImport(dll, EntryPoint = "Dequeue_String")]
    public static extern int Dequeue_String(StringBuilder str, int strlen);


    [DllImport(dll, EntryPoint = "Test")]
    public static extern int Test();

    [DllImport(dll, EntryPoint = "Init")]
    public static extern int Init(int audio, int search,
        StringBuilder hmm, StringBuilder lm, StringBuilder dict,
        StringBuilder jsgf, StringBuilder kws);
    /*
    [DllImport(dll, EntryPoint = "Get_Search_Model")]
    public static extern int Get_Search_Model(StringBuilder str, int strlen);

    [DllImport(dll, EntryPoint = "Set_Search_Model")]
    public static extern int Set_Search_Model(int search);

    [DllImport(dll, EntryPoint = "Set_kws")]
    public static extern int Set_kws(StringBuilder str);

    [DllImport(dll, EntryPoint = "Set_jsgf")]
    public static extern int Set_jsgf(StringBuilder str);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Dequeue_String")]
    public static extern int Dequeue_String(StringBuilder str, int strlen);

    [DllImport(dll, EntryPoint = "Get_Queue_Length")]
    public static extern int Get_Queue_Length();

    [DllImport(dll, EntryPoint = "Request_Buffer_Length")]
    public static extern int Request_Buffer_Length();*/
}
