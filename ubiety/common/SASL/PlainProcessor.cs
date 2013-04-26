// PlainProcessor.cs
//
//Ubiety XMPP Library Copyright (C) 2006 - 2012 Dieter Lunn
//
//This library is free software; you can redistribute it and/or modify it under
//the terms of the GNU Lesser General Public License as published by the Free
//Software Foundation; either version 3 of the License, or (at your option)
//any later version.
//
//This library is distributed in the hope that it will be useful, but WITHOUT
//ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
//FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
//
//You should have received a copy of the GNU Lesser General Public License along
//with this library; if not, write to the Free Software Foundation, Inc., 59
//Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Text;
using System.Xml;
using ubiety.common.logging;
using ubiety.core;
using ubiety.core.SASL;
using ubiety.registries;

namespace ubiety.common.SASL
{
	///<summary>
	///</summary>
	public class PlainProcessor : SASLProcessor
	{
		///<summary>
		///</summary>
		///<param name="tag"></param>
		///<exception cref="NotImplementedException"></exception>
		public override Tag Step(Tag tag)
		{
			return tag;
		}

		///<summary>
		///</summary>
		///<exception cref="NotImplementedException"></exception>
		public override Tag Initialize()
		{
			Logger.Debug(this, "Initializing Plain Processor");
			Logger.DebugFormat(this, "ID User: {0}", UbietySettings.Id.User);

			var sb = new StringBuilder();

			sb.Append((char) 0);
			sb.Append(UbietySettings.Id.User);
			sb.Append((char) 0);
			sb.Append(UbietySettings.Password);

			var auth = TagRegistry.GetTag<Auth>("auth", Namespaces.SASL);

			auth.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(sb.ToString()));
			auth.Mechanism = Mechanism.GetMechanism(MechanismType.Plain);

			return auth;
		}
	}
}