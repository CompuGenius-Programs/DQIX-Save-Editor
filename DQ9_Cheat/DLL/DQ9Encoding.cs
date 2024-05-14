// Decompiled with JetBrains decompiler
// Type: FriedGinger.DQCheat.DQ9Encoding
// Assembly: DQCheat, Version=0.7.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8257ADC3-8608-472B-A2D6-0B748207D880
// Assembly location: dq9_save_editor_0.7\DQCheat.dll

using System.Collections.Generic;
using System.Text;

namespace FriedGinger.DQCheat;

public class DQ9Encoding : Encoding
{
    private static Dictionary<char, byte> decodeDictionary;
    private static Dictionary<byte, char> encodeDictionary;

    private static readonly byte[] bytes = new byte[95]
    {
        4,
        70,
        71,
        72,
        74,
        75,
        76,
        77,
        83,
        84,
        85,
        88,
        92,
        93,
        94,
        95,
        96,
        97,
        98,
        99,
        100,
        101,
        102,
        103,
        105,
        106,
        107,
        109,
        111,
        113,
        114,
        116,
        118,
        120,
        121,
        122,
        123,
        124,
        125,
        126,
        127,
        128,
        129,
        130,
        131,
        132,
        133,
        134,
        135,
        136,
        137,
        138,
        139,
        141,
        142,
        143,
        144,
        145,
        146,
        147,
        148,
        149,
        150,
        151,
        152,
        153,
        154,
        155,
        156,
        157,
        158,
        159,
        160,
        161,
        162,
        163,
        164,
        165,
        166,
        167,
        168,
        169,
        228,
        229,
        230,
        231,
        232,
        233,
        234,
        235,
        236,
        237,
        238,
        240,
        byte.MaxValue
    };

    private static readonly string chars =
        "'{|}€,„Œœ¡£«»¿!\"#$%&’()+-./;=?[]_ÀÁÂÄÆÇÈÉÊËÌÍÎÏÑÒÓÔÕÖÙÚÛÜßàáâäæçèéêëìíîïñòóôõöùúûü~☻*@¢ªº←↑→↓– ";

    public DQ9Encoding()
    {
        if (decodeDictionary != null && encodeDictionary != null)
            return;
        CreateDictionaries();
    }

    public override string EncodingName => "DQ9";

    public override string WebName => "dq9";

    public override string HeaderName => "DQ9";

    public override bool IsSingleByte => true;

    public override int GetByteCount(char[] chars, int index, int count)
    {
        return count;
    }

    public override int GetCharCount(byte[] bytes, int index, int count)
    {
        return count;
    }

    public override int GetMaxByteCount(int chars)
    {
        return chars;
    }

    public override int GetMaxCharCount(int bytes)
    {
        return bytes;
    }

    public override int GetChars(
        byte[] bytes,
        int byteIndex,
        int byteCount,
        char[] chars,
        int charIndex)
    {
        int index;
        for (index = byteIndex; index < byteCount; ++index)
            chars[charIndex++] = encodeDictionary.ContainsKey(bytes[index]) ? encodeDictionary[bytes[index]] : '?';
        return index - byteIndex;
    }

    public override int GetBytes(
        char[] chars,
        int charIndex,
        int charCount,
        byte[] bytes,
        int byteIndex)
    {
        int index;
        for (index = charIndex; index < charCount; ++index)
            bytes[byteIndex++] = decodeDictionary.ContainsKey(chars[index]) ? decodeDictionary[chars[index]] : (byte)1;
        return index - charIndex;
    }

    public override string GetString(byte[] bytes, int index, int count)
    {
        var chArray = new char[count];
        for (var index1 = 0; index1 < count; ++index1)
            chArray[index1] = encodeDictionary.ContainsKey(bytes[index1]) ? encodeDictionary[bytes[index1]] : '?';
        return new string(chArray);
    }

    private static void CreateDictionaries()
    {
        decodeDictionary = new Dictionary<char, byte>();
        encodeDictionary = new Dictionary<byte, char>();
        for (var index = 0; index < 26; ++index)
        {
            decodeDictionary.Add((char)(65 + index), (byte)(index + 18));
            decodeDictionary.Add((char)(97 + index), (byte)(index + 44));
            encodeDictionary.Add((byte)(index + 18), (char)(65 + index));
            encodeDictionary.Add((byte)(index + 44), (char)(97 + index));
        }

        for (var index = 0; index < 10; ++index)
        {
            decodeDictionary.Add((char)(48 + index), (byte)(index + 8));
            encodeDictionary.Add((byte)(index + 8), (char)(48 + index));
        }

        for (var index = 0; index < bytes.Length; ++index)
            try
            {
                decodeDictionary.Add(chars[index], bytes[index]);
                encodeDictionary.Add(bytes[index], chars[index]);
            }
            catch
            {
            }
    }
}