using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalLib
{
    public static class  StringExt
    {
        #region 格式化
        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="sInput">本身字符串</param>
        /// <param name="args"></param>
        /// <returns></returns>      
        public static string format(this string sInput, params object[] args)
        {
            return String.Format(sInput, args);
        }
        #endregion

        #region 倒转字符串
        /// <summary>
        /// 倒转字符串
        /// </summary>
        public static string Reverse(this string sInput)
        {
            char[] chars = sInput.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
        #endregion

        #region 判断是否为email
        /// <summary>
        /// 判断是否为email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            string pattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        #endregion

        #region 判断是否为手机号
        /// <summary>
        /// 判断是否为手机号
        /// </summary>
        /// <param name="mobile">待判断</param>
        /// <returns></returns>
        public static bool IsMobile(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
            {
                return false;
            }
            string pattern = "^(13|15|18|17)[0-9]{9}$";
            return Regex.IsMatch(mobile, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        #endregion

        #region 判断是否为电话
        /// <summary>
        /// 判断是否为电话
        /// </summary>
        /// <param name="phone">0755-45784678-85</param>
        /// <returns></returns>
        public static bool IsPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }
            string pattern = "^(([0-9]{3,4})|[0-9]{3,4}-)?[0-9]{7,8}(-[0-9]{2,4})?$";
            return Regex.IsMatch(phone, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        #endregion

        #region 判断是否为邮编
        /// <summary>
        /// 判断是否为邮编
        /// </summary>
        /// <param name="phone">415118</param>
        /// <returns></returns>
        public static bool IsPostCode(string postcode)
        {
            if (string.IsNullOrWhiteSpace(postcode))
            {
                return false;
            }
            string pattern = "^[0-9]{6}$";
            return Regex.IsMatch(postcode, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        #endregion

        #region 是否有效的姓名
        /// <summary>
        /// 是否有效的姓名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            string pattern = "^(([\u4e00-\u9fa5]{2,5})|([a-zA-Z]{1,10}[a-zA-Z. ]{1,20}[a-zA-Z]{1,10}))$";
            return Regex.IsMatch(name, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        #endregion

        #region 是否有效的中文名
        /// <summary>
        /// 是否有效的中文名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidChineseName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            string pattern = "^[\u4e00-\u9fa5]{2,5}$";
            return Regex.IsMatch(name, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        #endregion

        #region 是否为正确的QQ号
        /// <summary>
        /// 是否为正确的QQ号
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static bool IsQQ(string qq)
        {
            if (string.IsNullOrWhiteSpace(qq))
            {
                return false;
            }
            string pattern = "^[1-9][0-9]{4,}$";
            return Regex.IsMatch(qq, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        #endregion

        #region 是否数字
        /// <summary>
        /// 是否数字
        /// </summary>
        /// <param name="sNumeric"></param>
        /// <returns></returns>
        public static bool IsNumeric(string sNumeric)
        {
            return (new Regex("^[\\+\\-]?[0-9]*\\.?[0-9]+$")).IsMatch(sNumeric);
        }
        #endregion

        #region 是否整数
        /// <summary>
        /// 是否整数
        /// </summary>
        /// <param name="sNumeric"></param>
        /// <returns></returns>
        public static bool IsInt(string intString)
        {
            return (new Regex("^[\\+\\-]?[0-9]+$")).IsMatch(intString);
        }
        #endregion

        #region 是否为正整数
        /// <summary>
        /// 是否为正整数
        /// </summary>
        /// <param name="sNumeric"></param>
        /// <returns></returns>
        public static bool IsPosInt(string intString)
        {
            return (new Regex("^[0-9]*[1-9][0-9]*$")).IsMatch(intString);
        }
        #endregion

        #region 自定义截取字符串
        /// <summary>
        /// 自定义截取字符串
        /// </summary>
        /// <param name="str">待截取的字符串</param>
        /// <param name="len">长度</param>
        /// <param name="hasDots">是否带"..."</param>
        /// <returns></returns>
        public static string SubString(string str, int len, bool hasDots)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;

            string dots = string.Empty;

            if (len >= str.Length)
                return str;

            if (hasDots)
                dots = "...";

            return str.Substring(0, len) + dots;
        }
        #endregion

        #region 取得客户端IP地址
        //获取客户端IP
        public static string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            if (null == result || result == String.Empty)
            {
                return "0.0.0.0";
            }
            if (result.Equals("::1"))
            {
                return "127.0.0.1";
            }
            return result;
        }

        /// <summary>
        /// 将最后一位数字换为*
        /// </summary>
        /// <param name="ip">输入的ip</param>
        /// <returns></returns>
        public static string FilterLastNum(string ip)
        {
            string result = string.Empty;

            string[] s = ip.Split('.');

            for (int i = 0; i < s.Length - 1; i++)
            {
                result += s[i] + ".";
            }
            result += "*";

            return result;
        }
        #endregion

        #region 将ID字符串转化为int数组

        /// <summary>
        /// 将ID字符串转化为int数组,默认使用空格和逗号分割
        /// </summary>
        /// <param name="idString"></param>
        /// <param name="splitChars"> </param>
        /// <returns></returns>
        public static List<int> ConvertFromIdString(string idString, params char[] splitChars)
        {
            if (!string.IsNullOrWhiteSpace(idString))
            {
                List<string> strings;
                if (splitChars == null || splitChars.Length == 0)
                {
                    strings = idString.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else
                {
                    strings = idString.Split(splitChars, StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                return strings.ConvertAll(DataTypeHelper.GetInt32);

            }
            return new List<int>();
        }
        #endregion

        #region 获取合法的主键字符串
        /// <summary>
        /// 获取合法的主键字符串，比如 1,3,6,7
        /// </summary>
        /// <param name="strKeys"></param>
        /// <returns></returns>
        public static String GetLegalKeyStr(String strKeys)
        {
            if (String.IsNullOrWhiteSpace(strKeys))
            {
                return String.Empty;
            }
            List<String> list = new List<String>();
            foreach (String key in strKeys.Split(',', ' '))
            {
                if (Regex.IsMatch(key, @"^[0-9]+$", RegexOptions.Compiled))
                {
                    list.Add(key);
                }
            }
            list.Sort();
            return String.Join(",", list.Distinct().ToArray());
        }
        #endregion

        #region 获取合法的字典字符串
        /// <summary>
        /// 获取合法的字典字符串，比如 a,b,d,e
        /// </summary>
        /// <param name="strKeys"></param>
        /// <returns></returns>
        public static string GetLegalDictKey(string strKeys)
        {
            if (string.IsNullOrWhiteSpace(strKeys))
            {
                return string.Empty;
            }
            strKeys = strKeys.ToLower();
            strKeys = Regex.Replace(strKeys, "[^,a-z0-9_]", string.Empty, RegexOptions.Compiled);
            strKeys = Regex.Replace(strKeys, "[,]{2,}", ",", RegexOptions.Compiled);
            strKeys = strKeys.Trim(',');
            return strKeys;
        }
        #endregion

        #region 获取合法的主键字符串
        /// <summary>
        /// 获取前后有,的主键字符串，比如 ,1,3,6,7,
        /// </summary>
        /// <param name="strKeys"></param>
        /// <returns></returns>
        public static string GetWrapedKeyStr(string strKeys)
        {
            return strKeys = string.Format(",{0},", GetLegalKeyStr(strKeys));
        }
        #endregion

        #region 获取合法的字典字符串
        /// <summary>
        /// 获取有'的字典字符串，比如 'a','b','c','d'
        /// </summary>
        /// <param name="strKeys"></param>
        /// <returns></returns>
        public static string GetWrapedDictKey(string strKeys)
        {
            strKeys = GetLegalDictKey(strKeys);
            if (string.IsNullOrEmpty(strKeys))
            {
                return string.Empty;
            }
            strKeys = strKeys.Replace(",", "','");
            return strKeys = string.Format("'{0}'", strKeys);
        }
        #endregion

        #region 转换文件大小
        /// <summary>
        /// 转换文件大小
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public static String FormatFileSize(long fileSize)
        {
            String fileSizeString = "";
            if (fileSize < 1024)
            {
                fileSizeString = fileSize + " B";
            }
            else if (fileSize < 1024 * 1024)
            {
                fileSizeString = String.Format("{0:F2}", (double)fileSize / 1024) + " K";
            }
            else if (fileSize < 1024 * 1024 * 1024)
            {
                fileSizeString = String.Format("{0:F2}", (double)fileSize / (1024 * 1024)) + " M";
            }
            else
            {
                fileSizeString = String.Format("{0:F2}", (double)fileSize / (1024 * 1024 * 1024)) + " G";
            }
            return fileSizeString;
        }
        #endregion

        #region 通过正则匹配获取值
        /// <summary>
        /// 通过正则匹配获取值
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static GroupCollection GetPatternValue(string input, string pattern)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            if (match.Success && match.Groups.Count > 0)
            {
                return match.Groups;
            }
            return null;
        }

        /// <summary>
        /// 通过正则匹配获取值
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static MatchCollection GetPatternValues(string input, string pattern)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            MatchCollection match = Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return match;
        }
        #endregion

        #region 合并路径
        /// <summary>
        /// 合并路径
        /// </summary>
        /// <param name="separator"></param>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns></returns>
        public static string CombinPath(char separator, string path1, string path2)
        {
            if (string.IsNullOrWhiteSpace(path1) || string.IsNullOrWhiteSpace(path2))
            {
                return path1 ?? path2;
            }

            bool b1 = path1[path1.Length - 1] == separator;
            bool b2 = path2[0] == separator;

            if (b1 && b2)
            {
                return path1 + path2.TrimStart(separator);
            }

            if (b1 || b2)
            {
                return path1 + path2;
            }

            return string.Concat(path1, separator, path2);
        }

        /// <summary>
        /// 合并路径
        /// </summary>
        /// <param name="separator"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string CombinPath(char separator, params string[] paths)
        {
            if (paths == null || paths.Length == 0)
            {
                return string.Empty;
            }
            else if (paths.Length == 1)
            {
                return paths[0];
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder(paths[0]);

            for (int i = 1; i < paths.Length; ++i)
            {
                string path = paths[i];
                if (string.IsNullOrEmpty(path))
                {
                    continue;
                }

                bool b1 = sb[sb.Length - 1] == separator;
                bool b2 = path[0] == separator;

                if (b1 && b2)
                {
                    sb.Append(path.TrimStart(separator));
                }
                else if (b1 || b2)
                {
                    sb.Append(path);
                }
                else
                {
                    sb.Append(separator);
                    sb.Append(path);
                }
            }

            return sb.ToString();
        }
        #endregion

        #region 计算页数
        /// <summary>
        /// 计算页数
        /// </summary>
        /// <param name="totalRecordCount"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int GetPageCount(int totalRecordCount, int pageSize)
        {
            return Convert.ToInt32(Math.Ceiling((double)totalRecordCount / pageSize));
        }
        #endregion

        #region 版本比较
        /// <summary>
        /// 版本比较
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public static int CompareVersion(string version1, string version2)
        {
            version1 = Regex.Replace(version1, "[^0-9.]", "", RegexOptions.Compiled);
            version2 = Regex.Replace(version2, "[^0-9.]", "", RegexOptions.Compiled);

            if (string.IsNullOrEmpty(version1) || string.IsNullOrEmpty(version2))
            {
                return string.Compare(version1, version2);
            }

            Version v1 = new Version(version1);
            Version v2 = new Version(version2);

            return v1.CompareTo(v2);
        }
        #endregion

        #region 将字符串形式的IP转换位long
        ///<summary>
        /// 将字符串形式的IP转换位long
        ///</summary>
        ///<param name="ipAddress"></param>
        ///<returns></returns>
        public static long IpToLong(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress)) return 0;

            byte[] ip_bytes = new byte[8];
            string[] strArr = ipAddress.Split(new char[] { '.' });
            if (strArr.Length != 4) return 0;

            for (int i = 0; i < 4; i++)
            {
                byte b = 0;
                if (byte.TryParse(strArr[3 - i], out b))
                {
                    ip_bytes[i] = b;
                }
                else
                {
                    return 0;
                }
            }
            return BitConverter.ToInt64(ip_bytes, 0);
        }
        #endregion

        #region 混淆密码(如将123456变为1****6)
        /// <summary>
        /// 混淆密码(如将123456变为1****6)
        /// </summary>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public static string MixPasswd(string passwd)
        {
            if (string.IsNullOrEmpty(passwd)) return string.Empty;

            char[] newPasswd = new char[passwd.Length];

            int mixed = 0;
            int i = 0;
            Random rand = new Random();
            foreach (char ch in passwd)
            {
                if (rand.Next(100) > 55)
                {
                    ++mixed;
                    newPasswd[i++] = '*';
                }
                else
                {
                    newPasswd[i++] = ch;
                }
            }

            i = 0;
            while (mixed < passwd.Length / 2) // 至少一半替换为*
            {
                if (newPasswd[i] != '*')
                {
                    ++mixed;
                    newPasswd[i++] = '*';
                }
            }

            return new string(newPasswd);
        }
        #endregion

        #region 日期

        /// <summary>
        /// 判断今天是第几周
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int WeekNumber(DateTime date)
        {
            string firstDateText = date.Year + "-1-1";
            DateTime firstDay = Convert.ToDateTime(firstDateText);
            int theday;
            switch (firstDay.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    theday = -1;
                    break;
                case DayOfWeek.Tuesday:
                    theday = 0;
                    break;
                case DayOfWeek.Wednesday:
                    theday = 1;
                    break;
                case DayOfWeek.Thursday:
                    theday = 2;
                    break;
                case DayOfWeek.Friday:
                    theday = 3;
                    break;
                case DayOfWeek.Saturday:
                    theday = 4;
                    break;
                default:
                    theday = 5;
                    break;
            }
            int weekNum = (date.DayOfYear + theday) / 7 + 1;
            return weekNum;
        }

        /// <summary>
        /// 年内某周的日期范围
        /// </summary>
        /// <param name="yearNum"></param>
        /// <param name="weekNum"></param>
        /// <returns></returns>
        public static String WeekRange(int yearNum, int weekNum)
        {
            DateTime firstOfYear = new DateTime(yearNum, 1, 1);
            System.DayOfWeek dayofweek = firstOfYear.DayOfWeek;
            DateTime stand = firstOfYear.AddDays(weekNum * 7);
            DateTime start = default(DateTime);
            DateTime end = default(DateTime);
            switch (dayofweek)
            {
                case DayOfWeek.Monday:
                    start = stand.AddDays(0);
                    end = stand.AddDays(6);
                    break;
                case DayOfWeek.Tuesday:
                    start = stand.AddDays(-1);
                    end = stand.AddDays(5);
                    break;
                case DayOfWeek.Wednesday:
                    start = stand.AddDays(-2);
                    end = stand.AddDays(4);
                    break;
                case DayOfWeek.Thursday:
                    start = stand.AddDays(-3);
                    end = stand.AddDays(3);
                    break;
                case DayOfWeek.Friday:
                    start = stand.AddDays(-4);
                    end = stand.AddDays(2);
                    break;
                case DayOfWeek.Saturday:
                    start = stand.AddDays(-5);
                    end = stand.AddDays(1);
                    break;
                default:
                    start = stand.AddDays(-6);
                    end = stand.AddDays(0);
                    break;
            }
            return start.ToString("yyyy/MM/dd") + " — " + end.ToString("yyyy/MM/dd");
        }

        #endregion
    }
}
