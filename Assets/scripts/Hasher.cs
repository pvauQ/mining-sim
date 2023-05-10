using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System; // jep mahtavaa täältä array ja bitconverter metodit



public static class Hasher{
    // static class that can do hashes

	public static string DoHashMD5(string str){
    // returns  full MD5 as a string
        byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(str);
        byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

        
        int i;
        StringBuilder sOutput = new StringBuilder(tmpHash.Length);
        for (i=0;i < tmpHash.Length; i++)
        {
            sOutput.Append(tmpHash[i].ToString("X2"));
        }
        return sOutput.ToString();
	}
    public  static ulong DoHashMd5Long(string str){
        // does md5 returns first 64 bits as long
        // I want to use this as "mining hash"
        byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(str);
        byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        byte[] tmp8byte = new byte[8];
        Array.Copy(tmpHash,tmp8byte,8);

        ulong hash = BitConverter.ToUInt64(tmp8byte,0);
        return hash;

    }
}

