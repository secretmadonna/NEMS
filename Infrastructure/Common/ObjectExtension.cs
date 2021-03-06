﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SecretMadonna.NEMS.Infrastructure.Common
{
    /// <summary>
    /// 扩展类的实例方法
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// object 转 T（强转）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T As<T>(this object obj)
            where T : class
        {
            return (T)obj;
        }

        /// <summary>
        /// object 转 T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T To<T>(this object obj)
            where T : struct
        {
            if (typeof(T) == typeof(Guid))
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(obj.ToString());
            }

            return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// item 是否在 array 中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsIn<T>(this T item, params T[] array)
        {
            return array.Contains(item);
        }

        #region Enum 扩展
        private static Dictionary<string, string> enumKeyValues = new Dictionary<string, string>();
        public static string Description(this Enum e)
        {
            var enumType = e.GetType();
            var name = Enum.GetName(enumType, e);
            var key = string.Format("{0}.{1}", enumType.FullName, name);
            if (enumKeyValues.ContainsKey(key))
            {
                return enumKeyValues[key];
            }
            var fieldInfo = enumType.GetField(name);
            var attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
            enumKeyValues.Add(key, attr.Description);
            return attr.Description;
        }
        #endregion

        #region MethodInfo 扩展
        public static string DescInfo(this MethodInfo method)
        {
            var sb = new StringBuilder();
            var parameterStrs = new List<string>();
            var parameters = method.GetParameters();
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    parameterStrs.Add(p.ToString());
                }
            }
            sb.AppendFormat("{0} {1}.{2}({3})", method.ReturnType.FullName, method.ReflectedType.FullName, method.Name, string.Join(", ", parameterStrs));
            return sb.ToString();
        }
        #endregion

        #region StackTrace 扩展
        public static string DescInfo(this StackTrace stackTrace)
        {
            var sb = new StringBuilder();
            var sfs = stackTrace?.GetFrames();
            if (sfs != null)
            {
                foreach (var sf in sfs)
                {
                    var method = (MethodInfo)sf.GetMethod();
                    var fileName = sf.GetFileName();
                    if (string.IsNullOrWhiteSpace(fileName))
                    {
                        sb.AppendFormat("{0}{1}", method.DescInfo(), Environment.NewLine);
                    }
                    else
                    {
                        sb.AppendFormat("{0} in file:line:column {1}:{2}:{3}{4}", method.DescInfo(), sf.GetFileName(), sf.GetFileLineNumber(), sf.GetFileColumnNumber(), Environment.NewLine);
                    }
                }
            }
            return sb.ToString().TrimEnd(Environment.NewLine.ToArray());
        }
        #endregion
    }
}
