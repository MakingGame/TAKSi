// This file is auto-generated by TAKSi v1.1.0, DO NOT EDIT!

using System;
using System.IO;
using System.Collections.Generic;

namespace Config
{

// 全局数值配置, 全局变量表.xlsx
public class GlobalPropertyDefine
{
    public float                    GoldExchangeTimeFactor1 = 0.0f;    // 金币兑换时间参数1
    public float                    GoldExchangeTimeFactor2 = 0.0f;    // 金币兑换时间参数2
    public float                    GoldExchangeTimeFactor3 = 0.0f;    // 金币兑换时间参数3
    public uint                     GoldExchangeResource1Price = 0;    // 金币兑换资源1价格
    public uint                     GoldExchangeResource2Price = 0;    // 金币兑换资源2价格
    public uint                     GoldExchangeResource3Price = 0;    // 金币兑换资源3价格
    public uint                     GoldExchangeResource4Price = 0;    // 金币兑换资源4价格
    public uint                     FreeCompleteSeconds = 0;           // 免费立即完成时间
    public uint                     CancelBuildReturnPercent = 0;      // 取消建造后返还资源比例
    public int[]                    SpawnLevelLimit = null;            // 最大刷新个数显示
    public Dictionary<string, int>  FirstRechargeReward = null;        // 首充奖励

    public static GlobalPropertyDefine Instance { get; private set; }

    // parse object fields from text rows
    public void ParseFromRows(string[][] rows)
    {
        if (rows.Length < 11) {
            throw new ArgumentException(string.Format("GlobalPropertyDefine: row length out of index, {0} < 11", rows.Length));
        }
        if (rows[0][3].Length > 0) {
            this.GoldExchangeTimeFactor1 = float.Parse(rows[0][3]);
        }
        if (rows[1][3].Length > 0) {
            this.GoldExchangeTimeFactor2 = float.Parse(rows[1][3]);
        }
        if (rows[2][3].Length > 0) {
            this.GoldExchangeTimeFactor3 = float.Parse(rows[2][3]);
        }
        if (rows[3][3].Length > 0) {
            this.GoldExchangeResource1Price = uint.Parse(rows[3][3]);
        }
        if (rows[4][3].Length > 0) {
            this.GoldExchangeResource2Price = uint.Parse(rows[4][3]);
        }
        if (rows[5][3].Length > 0) {
            this.GoldExchangeResource3Price = uint.Parse(rows[5][3]);
        }
        if (rows[6][3].Length > 0) {
            this.GoldExchangeResource4Price = uint.Parse(rows[6][3]);
        }
        if (rows[7][3].Length > 0) {
            this.FreeCompleteSeconds = uint.Parse(rows[7][3]);
        }
        if (rows[8][3].Length > 0) {
            this.CancelBuildReturnPercent = uint.Parse(rows[8][3]);
        }
        {
            var items = rows[9][3].Split(new char[]{'|'}, StringSplitOptions.RemoveEmptyEntries);
            this.SpawnLevelLimit = new int[items.Length];
            for(int i = 0; i < items.Length; i++) {
                var value = int.Parse(items[i]);
                this.SpawnLevelLimit[i] = value;
            }
        }
        {
            var items = rows[10][3].Split(new char[]{'|'}, StringSplitOptions.RemoveEmptyEntries);
            this.FirstRechargeReward = new Dictionary<string,int>();
            foreach(string text in items) {
                if (text.Length == 0) {
                    continue;
                }
                var item = text.Split(new char[]{'='}, StringSplitOptions.RemoveEmptyEntries);
                var key = item[0].Trim();
                var value = int.Parse(item[1]);
                this.FirstRechargeReward[key] = value;
            }
        }
    }

    public static void LoadFromLines(List<string> lines)
    {
        var rows = new string[lines.Count][];
        for(int i = 0; i < lines.Count; i++)
        {
            string line = lines[i];
            rows[i] = line.Split(',');
        }
        Instance = new GlobalPropertyDefine();
        Instance.ParseFromRows(rows);
    }

}

public class AutogenConfigManager
{

    public delegate void ContentReader(string filepath, Action<string> cb);
    
    public static ContentReader reader = ReadFileContent;
    
    public static bool ParseBool(string text)
    {
        if (text.Length > 0)
        {
            return string.Equals(text, "1") ||
                string.Equals(text, "on", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(text, "yes", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(text, "true", StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }
        
    public static List<string> ReadTextToLines(string content)
    {
        List<string> lines = new List<string>();
        using (StringReader reader = new StringReader(content))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        return lines;
    }
    
    public static void ReadFileContent(string filepath, Action<string> cb)
    {
        StreamReader reader = new StreamReader(filepath);
        var content = reader.ReadToEnd();
        cb(content);
    }
    
    public static void LoadAllConfig(Action completeFunc) 
    {
        reader("global_property_define.csv", (content) =>
        {
            var lines = ReadTextToLines(content);
            GlobalPropertyDefine.LoadFromLines(lines);

            if (completeFunc != null) completeFunc();
        });

    }
}


}
