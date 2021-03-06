﻿using System;
using DotnetSpider.Core;

namespace DotnetSpider.Extension.Model.Formatter
{
	/// <summary>
	/// 数据格式化
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public abstract class Formatter : System.Attribute, INamed
	{
		/// <summary>
		/// 构造方法
		/// </summary>
		protected Formatter()
		{
			Name = GetType().Name;
		}

		/// <summary>
		/// 格式化的名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 如果被格式化的值为空的返回值
		/// </summary>
		public object ValueWhenNull { get; set; }

		/// <summary>
		/// 实现数值的转化
		/// </summary>
		/// <param name="value">数值</param>
		/// <returns>被格式化后的数值</returns>
		protected abstract object FormateValue(object value);

		/// <summary>
		/// 校验参数是否设置正确
		/// </summary>
		protected abstract void CheckArguments();

		/// <summary>
		/// 格式化数据
		/// </summary>
		/// <param name="value">数值</param>
		/// <returns>被格式化后的数值</returns>
		public object Formate(object value)
		{
			CheckArguments();

			if (value == null)
			{
				return ValueWhenNull;
			}
			return FormateValue(value);
		}
	}
}
